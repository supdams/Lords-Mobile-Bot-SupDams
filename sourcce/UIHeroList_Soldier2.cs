// Decompiled with JetBrains decompiler
// Type: UIHeroList_Soldier2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIHeroList_Soldier2 : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const int m_MaxTextObj = 12;
  private const int m_MaxPanelObject = 8;
  private const int TextMax = 3;
  private Transform m_ItemPanel;
  private Transform m_SkillHintPanel;
  private Transform m_LeaderImageTf;
  private Transform m_IconHintPanel;
  private Transform m_LockText;
  private Transform[] m_SkillMaskTf;
  private Transform m_BtnLeaderImageTf;
  private UIText m_BtnText;
  private UIText m_EmptyStr;
  private UIText m_AutoText;
  private ScrollPanel m_ScrollPanel;
  private ScrollPanel m_EffScrollPanel;
  private UIButton m_AutoBtn;
  private UIText m_MaxNumText;
  private UISpritesArray m_SpritesArray;
  private uTweenAlpha[] m_TweenAlpha;
  private Image[] m_TweenAlphaImage;
  private UIText m_HeroNameText;
  private UIText m_HeroArmsText;
  private UIText m_HeroMaxNum;
  private Image m_HeroEnhanceIcon;
  private UIHIBtn m_HeroIcon;
  private UIText[] m_SkliiNameText;
  private UIText[] m_SkillInfoText;
  private Image[] m_SkillImage;
  private Image[] m_SkillFrame;
  private List<SoldierScrollItem> m_Data;
  private List<SkillEffect> m_EffetData;
  private ScrollPanelObject[] m_ScrollObj;
  private TextItem[] m_TextItem;
  private UIHIBtn[] m_BattleHero;
  private Image[] m_BattleHeroPlus;
  private Image[] m_BattleHeroLock;
  private UIHIBtn[] m_MoveHero;
  private MoveObject[] moveStack;
  private bool bCanClick;
  private int MoveBtnCount;
  private bool bCanClickbtn;
  private byte m_BattleHeroNum;
  private ushort[] m_BattleHeroID;
  private bool bMoving;
  private bool bOnClick;
  private int m_SelectNum;
  private uint m_MaxNum;
  private bool bHaveLeader;
  private bool bHint;
  private CString m_SpriteStr;
  private CString[] m_SkillInfoStr;
  private CString m_HeroMaxNumStr;
  private CString m_MaxNumStr;
  private float[] m_ColorTick;
  private float[] m_ColorA;
  private Image[] m_ColoeAImage;
  private int m_OpenType;
  private GUIManager GM;
  private DataManager DM;
  private Door door;
  private Font TTF;
  private UIText context;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[3];
  private bool bPreselectedTeam;

  public override void OnOpen(int arg1, int arg2)
  {
    GameObject gameObject = new GameObject();
    this.context = gameObject.AddComponent<UIText>();
    ((Behaviour) this.context).enabled = false;
    gameObject.transform.SetParent(this.transform, false);
    this.m_OpenType = arg1;
    this.bPreselectedTeam = arg2 == 1;
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.TTF = this.GM.GetTTFFont();
    this.m_Data = new List<SoldierScrollItem>();
    this.m_EffetData = new List<SkillEffect>();
    this.m_TweenAlpha = new uTweenAlpha[5];
    this.m_TweenAlphaImage = new Image[5];
    this.m_SkliiNameText = new UIText[4];
    this.m_SkillInfoText = new UIText[4];
    this.m_SkillImage = new Image[4];
    this.m_SkillFrame = new Image[4];
    this.m_SkillMaskTf = new Transform[4];
    this.m_ColorTick = new float[5];
    this.m_ColorA = new float[5];
    this.m_ColoeAImage = new Image[5];
    this.m_BattleHero = new UIHIBtn[5];
    this.m_BattleHeroPlus = new Image[5];
    this.m_BattleHeroLock = new Image[5];
    this.m_MoveHero = new UIHIBtn[5];
    this.moveStack = new MoveObject[5];
    this.bCanClick = true;
    this.MoveBtnCount = 0;
    this.bCanClickbtn = false;
    this.m_BattleHeroNum = (byte) this.DM.GetMaxDefenders();
    this.m_BattleHeroID = new ushort[5];
    this.m_SelectNum = 0;
    for (int index = 0; index < this.m_BattleHeroID.Length; ++index)
    {
      this.moveStack[index] = new MoveObject();
      this.m_BattleHeroID[index] = (ushort) 0;
    }
    this.m_MaxNum = 0U;
    this.m_SpriteStr = StringManager.Instance.SpawnString();
    this.m_SkillInfoStr = new CString[4];
    for (int index = 0; index < 4; ++index)
      this.m_SkillInfoStr[index] = StringManager.Instance.SpawnString();
    this.m_HeroMaxNumStr = StringManager.Instance.SpawnString();
    this.m_MaxNumStr = StringManager.Instance.SpawnString();
    GUIManager.Instance.AddSpriteAsset("UI_frame");
    this.InitUI();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 6);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.m_SpriteStr);
    for (int index1 = 0; index1 < this.m_ScrollObj.Length; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if (this.m_ScrollObj[index1].PanelItem[index2].MaxNumStr != null)
          StringManager.Instance.DeSpawnString(this.m_ScrollObj[index1].PanelItem[index2].MaxNumStr);
      }
    }
    for (int index = 0; index < 12; ++index)
    {
      StringManager.Instance.DeSpawnString(this.m_TextItem[index].Text1Str);
      StringManager.Instance.DeSpawnString(this.m_TextItem[index].Text2Str);
    }
    for (int index = 0; index < 4; ++index)
      StringManager.Instance.DeSpawnString(this.m_SkillInfoStr[index]);
    StringManager.Instance.DeSpawnString(this.m_HeroMaxNumStr);
    for (int index = this.m_Data.Count - 1; index >= 0; --index)
    {
      this.m_Data[index].Item[0].Type = (byte) 0;
      this.m_Data[index].Item[1].Type = (byte) 0;
      this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(this.m_Data[index]);
    }
    GUIManager.Instance.RemoveSpriteAsset("UI_frame");
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    ushort leaderId = this.DM.GetLeaderID();
    for (int index = 0; index < this.m_BattleHeroID.Length; ++index)
    {
      if (this.m_BattleHeroID[index] != (ushort) 0 && (int) this.m_BattleHeroID[index] == (int) leaderId && this.DM.beCaptured.nowCaptureStat != LoadCaptureState.None)
      {
        this.OnHIButtonClick(this.m_BattleHero[index]);
        break;
      }
    }
    for (int index = this.m_Data.Count - 1; index >= 0; --index)
    {
      this.m_Data[index].Item[0].Type = (byte) 0;
      this.m_Data[index].Item[1].Type = (byte) 0;
      this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(this.m_Data[index]);
    }
    this.m_Data.Clear();
    this.m_EffetData.Clear();
    this.m_SelectNum = 0;
    this.m_MaxNum = 0U;
    this.SetData();
    this.UpdateData();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
      case NetworkNews.Refresh_Hero:
        this.UpdateUI(0, 0);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.m_BtnText != (UnityEngine.Object) null && ((Behaviour) this.m_BtnText).enabled)
    {
      ((Behaviour) this.m_BtnText).enabled = false;
      ((Behaviour) this.m_BtnText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_EmptyStr != (UnityEngine.Object) null && ((Behaviour) this.m_EmptyStr).enabled)
    {
      ((Behaviour) this.m_EmptyStr).enabled = false;
      ((Behaviour) this.m_EmptyStr).enabled = true;
    }
    if ((UnityEngine.Object) this.m_AutoText != (UnityEngine.Object) null && ((Behaviour) this.m_AutoText).enabled)
    {
      ((Behaviour) this.m_AutoText).enabled = false;
      ((Behaviour) this.m_AutoText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_MaxNumText != (UnityEngine.Object) null && ((Behaviour) this.m_MaxNumText).enabled)
    {
      ((Behaviour) this.m_MaxNumText).enabled = false;
      ((Behaviour) this.m_MaxNumText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HeroNameText != (UnityEngine.Object) null && ((Behaviour) this.m_HeroNameText).enabled)
    {
      ((Behaviour) this.m_HeroNameText).enabled = false;
      ((Behaviour) this.m_HeroNameText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HeroArmsText != (UnityEngine.Object) null && ((Behaviour) this.m_HeroArmsText).enabled)
    {
      ((Behaviour) this.m_HeroArmsText).enabled = false;
      ((Behaviour) this.m_HeroArmsText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HeroMaxNum != (UnityEngine.Object) null && ((Behaviour) this.m_HeroMaxNum).enabled)
    {
      ((Behaviour) this.m_HeroMaxNum).enabled = false;
      ((Behaviour) this.m_HeroMaxNum).enabled = true;
    }
    if ((UnityEngine.Object) this.context != (UnityEngine.Object) null && ((Behaviour) this.context).enabled)
    {
      ((Behaviour) this.context).enabled = false;
      ((Behaviour) this.context).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.m_SkliiNameText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_SkliiNameText[index]).enabled)
      {
        ((Behaviour) this.m_SkliiNameText[index]).enabled = false;
        ((Behaviour) this.m_SkliiNameText[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.m_SkillInfoText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_SkillInfoText[index]).enabled)
      {
        ((Behaviour) this.m_SkillInfoText[index]).enabled = false;
        ((Behaviour) this.m_SkillInfoText[index]).enabled = true;
      }
    }
    if ((bool) (UnityEngine.Object) this.m_HeroIcon)
      this.m_HeroIcon.Refresh_FontTexture();
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.m_tmptext[index] != (UnityEngine.Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    if (this.m_TextItem != null)
    {
      for (int index = 0; index < this.m_TextItem.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_TextItem[index].Text1 != (UnityEngine.Object) null && ((Behaviour) this.m_TextItem[index].Text1).enabled)
        {
          ((Behaviour) this.m_TextItem[index].Text1).enabled = false;
          ((Behaviour) this.m_TextItem[index].Text1).enabled = true;
        }
        if ((UnityEngine.Object) this.m_TextItem[index].Text2 != (UnityEngine.Object) null && ((Behaviour) this.m_TextItem[index].Text2).enabled)
        {
          ((Behaviour) this.m_TextItem[index].Text2).enabled = false;
          ((Behaviour) this.m_TextItem[index].Text2).enabled = true;
        }
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
            if ((UnityEngine.Object) this.m_ScrollObj[index1].PanelItem[index2].HeroBtn != (UnityEngine.Object) null && ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].HeroBtn).enabled)
              this.m_ScrollObj[index1].PanelItem[index2].HeroBtn.Refresh_FontTexture();
            if ((UnityEngine.Object) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText != (UnityEngine.Object) null && (UnityEngine.Object) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText != (UnityEngine.Object) null)
            {
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText).enabled = false;
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText).enabled = true;
            }
            if ((UnityEngine.Object) this.m_ScrollObj[index1].PanelItem[index2].ArmsText != (UnityEngine.Object) null && (UnityEngine.Object) this.m_ScrollObj[index1].PanelItem[index2].ArmsText != (UnityEngine.Object) null)
            {
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].ArmsText).enabled = false;
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].ArmsText).enabled = true;
            }
          }
        }
      }
    }
    if (this.m_BattleHero != null)
    {
      for (int index = 0; index < this.m_BattleHero.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_BattleHero[index] != (UnityEngine.Object) null)
          this.m_BattleHero[index].Refresh_FontTexture();
      }
    }
    if (this.m_MoveHero == null)
      return;
    for (int index = 0; index < this.m_MoveHero.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_MoveHero[index] != (UnityEngine.Object) null)
        this.m_MoveHero[index].Refresh_FontTexture();
    }
  }

  private void InitUI()
  {
    this.m_SpritesArray = this.transform.GetComponent<UISpritesArray>();
    this.m_AutoBtn = this.transform.GetChild(4).GetChild(3).GetComponent<UIButton>();
    this.m_AutoBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_AutoBtn.m_BtnID1 = 998;
    this.m_AutoText = this.transform.GetChild(4).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.m_AutoText.font = this.TTF;
    UIButton component1 = this.transform.GetChild(4).GetChild(4).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 1000;
    this.m_BtnText = this.transform.GetChild(4).GetChild(4).GetChild(1).GetComponent<UIText>();
    this.m_BtnText.font = this.TTF;
    this.m_BtnText.text = this.DM.mStringTable.GetStringByID(189U);
    this.m_BtnLeaderImageTf = this.transform.GetChild(4).GetChild(4).GetChild(0);
    Image component2 = this.transform.GetChild(5).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component2)
      ((Behaviour) component2).enabled = false;
    UIButton component3 = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
    component3.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3.image).material = this.door.LoadMaterial();
    component3.m_BtnID1 = 999;
    component3.m_Handler = (IUIButtonClickHandler) this;
    for (int index = 0; index < 5; ++index)
    {
      this.m_BattleHero[index] = this.transform.GetChild(1).GetChild(index).GetChild(1).GetComponent<UIHIBtn>();
      this.m_BattleHero[index].m_Handler = (IUIHIBtnClickHandler) this;
      this.m_BattleHero[index].m_BtnID1 = index;
      this.GM.InitianHeroItemImg(((Component) this.m_BattleHero[index]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      this.m_MoveHero[index] = this.transform.GetChild(1).GetChild(index + 5).GetComponent<UIHIBtn>();
      this.GM.InitianHeroItemImg(((Component) this.m_MoveHero[index]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      this.m_TweenAlpha[index] = this.transform.GetChild(1).GetChild(index).GetChild(4).GetComponent<uTweenAlpha>();
      this.m_TweenAlphaImage[index] = this.transform.GetChild(1).GetChild(index).GetChild(4).GetComponent<Image>();
      ((Behaviour) this.m_TweenAlphaImage[index]).enabled = false;
      this.m_BattleHeroPlus[index] = this.transform.GetChild(1).GetChild(index).GetChild(2).GetComponent<Image>();
      this.m_BattleHeroLock[index] = this.transform.GetChild(1).GetChild(index).GetChild(3).GetComponent<Image>();
      UIButton component4 = this.transform.GetChild(1).GetChild(index).GetChild(3).GetComponent<UIButton>();
      component4.m_BtnID1 = 997;
      component4.m_Handler = (IUIButtonClickHandler) this;
      if (index < (int) this.m_BattleHeroNum)
      {
        ((Behaviour) this.m_BattleHeroPlus[index]).enabled = true;
        ((Behaviour) this.m_BattleHeroLock[index]).enabled = false;
      }
      else
      {
        ((Behaviour) this.m_BattleHeroPlus[index]).enabled = false;
        ((Behaviour) this.m_BattleHeroLock[index]).enabled = true;
      }
    }
    this.m_LeaderImageTf = this.transform.GetChild(1).GetChild(10);
    this.m_ScrollObj = new ScrollPanelObject[8];
    for (int index = 0; index < 8; ++index)
      this.m_ScrollObj[index].PanelItem = new SoldierPanelObject[2];
    this.m_TextItem = new TextItem[12];
    for (int index = 0; index < 12; ++index)
    {
      this.m_TextItem[index].Text1Str = StringManager.Instance.SpawnString();
      this.m_TextItem[index].Text2Str = StringManager.Instance.SpawnString();
    }
    this.m_MaxNumText = this.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<UIText>();
    this.m_MaxNumText.font = this.TTF;
    this.m_MaxNumStr.ClearString();
    UIButtonHint uiButtonHint = this.transform.GetChild(4).GetChild(1).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_SkillHintPanel = this.transform.GetChild(10);
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
    for (int index = 0; index < 4; ++index)
    {
      this.m_SkillImage[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(1).GetComponent<Image>();
      this.m_SkillFrame[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(1).GetChild(0).GetComponent<Image>();
      this.m_SkliiNameText[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(2).GetComponent<UIText>();
      this.m_SkliiNameText[index].font = this.TTF;
      this.m_SkillInfoText[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(3).GetComponent<UIText>();
      this.m_SkillInfoText[index].font = this.TTF;
      this.m_SkillMaskTf[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(4);
    }
    this.m_ItemPanel = this.transform.GetChild(3);
    this.GM.InitianHeroItemImg(((Component) this.m_ItemPanel.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0, bAutoShowHint: false);
    UIHIBtn component5 = this.m_ItemPanel.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component6 = this.m_ItemPanel.GetChild(0).GetChild(0).GetChild(7).GetComponent<RectTransform>();
      Vector3 localScale = ((Transform) component6).localScale with
      {
        x = -1f
      };
      ((Transform) component6).localScale = localScale;
      RectTransform component7 = this.m_ItemPanel.GetChild(0).GetChild(1).GetChild(7).GetComponent<RectTransform>();
      localScale = ((Transform) component7).localScale with
      {
        x = -1f
      };
      ((Transform) component7).localScale = localScale;
    }
    this.GM.InitianHeroItemImg(((Component) component5).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0, bAutoShowHint: false);
    this.m_ItemPanel.GetChild(0).GetChild(0).GetChild(0).gameObject.AddComponent<UIButtonHint>().m_Handler = (MonoBehaviour) this;
    this.m_ItemPanel.GetChild(0).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>().m_Handler = (MonoBehaviour) this;
    this.m_IconHintPanel = this.transform.GetChild(8);
    Image component8 = this.m_IconHintPanel.GetComponent<Image>();
    component8.type = (Image.Type) 1;
    component8.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) component8).material = this.door.LoadMaterial();
    this.m_tmptext[this.mTextCount] = this.m_IconHintPanel.GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    if (this.m_OpenType == 1)
    {
      ((Graphic) component8).rectTransform.sizeDelta = new Vector2(330f, 88f);
      ((Graphic) this.m_tmptext[this.mTextCount]).rectTransform.sizeDelta = new Vector2(280f, 78f);
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(816U);
    }
    else
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(713U);
    ++this.mTextCount;
    this.m_EmptyStr = this.transform.GetChild(9).GetComponent<UIText>();
    this.m_EmptyStr.font = this.TTF;
    this.m_EmptyStr.resizeTextForBestFit = true;
    this.m_EmptyStr.resizeTextMaxSize = 22;
    this.m_EmptyStr.resizeTextMinSize = 10;
    ((Graphic) this.m_EmptyStr).rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
    ((Graphic) this.m_EmptyStr).rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
    ((Graphic) this.m_EmptyStr).rectTransform.pivot = new Vector2(0.0f, 1f);
    this.m_EmptyStr.text = this.DM.mStringTable.GetStringByID(714U);
    ((Graphic) this.m_EmptyStr).rectTransform.sizeDelta = ((Graphic) this.m_EmptyStr).rectTransform.sizeDelta with
    {
      y = this.m_EmptyStr.preferredHeight
    };
    ((Graphic) this.m_EmptyStr).rectTransform.anchoredPosition = new Vector2(169f, 163f);
    this.m_tmptext[this.mTextCount] = this.m_ItemPanel.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(341U);
    ++this.mTextCount;
    this.m_LockText = this.transform.GetChild(11);
    this.m_tmptext[this.mTextCount] = this.m_LockText.GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(726U);
    ((Graphic) this.m_tmptext[this.mTextCount]).color = new Color(0.811f, 0.662f, 0.447f, 1f);
    ++this.mTextCount;
    this.m_ScrollPanel = this.transform.GetChild(2).GetComponent<ScrollPanel>();
    this.m_EffScrollPanel = this.transform.GetChild(4).GetChild(2).GetChild(0).GetComponent<ScrollPanel>();
    this.InitData();
    UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.CheckAutoSelectText();
  }

  private void InitData()
  {
    this.SetData();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(this.m_Data[index].Height);
    this.m_ScrollPanel.IntiScrollPanel(403f, 10f, 6f, _DataHeight, 8, (IUpDateScrollPanel) this);
    _DataHeight.Clear();
    for (int index = 0; index < this.m_EffetData.Count; ++index)
    {
      if (this.m_EffetData[index].Type == (byte) 2)
        _DataHeight.Add(60f);
      else
        _DataHeight.Add(this.m_EffetData[index].TextHeight);
    }
    this.m_EffScrollPanel.IntiScrollPanel(284f, 0.0f, 0.0f, _DataHeight, 12, (IUpDateScrollPanel) this);
    if (_DataHeight.Count == 0)
      ((Component) this.m_EmptyStr).gameObject.SetActive(true);
    if (this.m_OpenType == 1)
      this.m_LockText.gameObject.SetActive(true);
    else
      this.m_LockText.gameObject.SetActive(false);
  }

  private void SetData()
  {
    SoldierScrollItem t = (SoldierScrollItem) null;
    this.DM.SetSortNonFightHeroID();
    this.DM.SetSortFightHeroID();
    bool flag = false;
    for (int index1 = 0; (long) index1 < (long) this.DM.NonFightHeroCount; ++index1)
    {
      int index2 = index1 % 2;
      uint num = this.DM.SortNonFightHeroID[index1];
      eHeroState heroState = this.DM.GetHeroState((ushort) num);
      if (index2 == 0)
      {
        t = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
        t.Item[0].Enable = false;
        t.Item[0].Type = (byte) 0;
        t.Item[1].Enable = false;
        t.Item[1].Type = (byte) 0;
        t.Item[0].HeroID = (ushort) 0;
        t.Item[1].HeroID = (ushort) 0;
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
        t.Item[index2].bIsLords = (int) num == (int) this.DM.GetLeaderID();
        t.Item[index2].bSelect = false;
        for (int index3 = 0; index3 < this.m_BattleHeroID.Length; ++index3)
        {
          if (index3 < this.m_BattleHeroID.Length && this.m_BattleHeroID[index3] != (ushort) 0 && (int) this.m_BattleHeroID[index3] == (int) num && heroState == eHeroState.None)
          {
            this.m_MaxNum += (uint) this.DM.RankSoldiers[(int) curHeroData.Enhance];
            t.Item[index2].bSelect = true;
            flag = true;
            ++this.m_SelectNum;
            if ((int) this.m_BattleHeroID[index3] == (int) this.DM.GetLeaderID())
              this.bHaveLeader = true;
          }
        }
        if (this.m_OpenType == 0)
        {
          for (int index4 = 0; index4 < this.DM.LegionBattleHero.Count; ++index4)
          {
            if (!flag && (int) this.DM.LegionBattleHero[index4] == (int) num)
            {
              t.Item[index2].bSelect = true;
              this.m_MaxNum += (uint) this.DM.RankSoldiers[(int) curHeroData.Enhance];
              this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[index4]).transform, eHeroOrItem.Hero, (ushort) num, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
              ((Component) this.m_BattleHero[index4]).gameObject.SetActive(true);
              ((Behaviour) this.m_BattleHeroPlus[index4]).enabled = false;
              this.m_BattleHeroID[index4] = (ushort) num;
              ++this.m_SelectNum;
              if ((int) this.DM.LegionBattleHero[index4] == (int) this.DM.GetLeaderID())
              {
                this.bHaveLeader = true;
                break;
              }
              break;
            }
          }
        }
        else
        {
          for (int index5 = 0; index5 < this.DM.m_DefendersID.Length; ++index5)
          {
            if (!flag && this.DM.m_DefendersID[index5] != (ushort) 0 && (int) num == (int) this.DM.m_DefendersID[index5])
            {
              t.Item[index2].bSelect = true;
              this.m_MaxNum += (uint) this.DM.RankSoldiers[(int) curHeroData.Enhance];
              this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[index5]).transform, eHeroOrItem.Hero, (ushort) num, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
              ((Component) this.m_BattleHero[index5]).gameObject.SetActive(true);
              ((Behaviour) this.m_BattleHeroPlus[index5]).enabled = false;
              this.m_BattleHeroID[index5] = (ushort) num;
              ++this.m_SelectNum;
              if ((int) this.DM.m_DefendersID[index5] == (int) this.DM.GetLeaderID())
              {
                this.bHaveLeader = true;
                break;
              }
              break;
            }
          }
        }
        t.Item[index2].bIsFight = false;
        t.Item[index2].Type = (byte) 0;
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
      t.Height = 50f;
      this.m_Data.Add(t);
    }
    for (int index6 = 0; (long) index6 < (long) this.DM.FightHeroCount; ++index6)
    {
      int index7 = index6 % 2;
      uint num = this.DM.SortFightHeroID[index6];
      eHeroState heroState = this.DM.GetHeroState((ushort) num);
      if (index7 == 0)
      {
        t = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
        t.Item[0].Enable = false;
        t.Item[0].Type = (byte) 0;
        t.Item[1].Enable = false;
        t.Item[1].Type = (byte) 0;
        t.Item[0].HeroID = (ushort) 0;
        t.Item[1].HeroID = (ushort) 0;
      }
      t.Item[index7].Type = (byte) 0;
      t.Item[index7].HeroID = (ushort) num;
      t.Height = 80f;
      if (DataManager.Instance.curHeroData.ContainsKey(num))
      {
        t.Item[index7].Enable = false;
        t.Item[index7].HeroID = (ushort) num;
        Hero recordByKey = this.DM.HeroTable.GetRecordByKey((ushort) num);
        t.Item[index7].Enable = true;
        CurHeroData curHeroData = DataManager.Instance.curHeroData[num];
        t.Item[index7].Lv = curHeroData.Level;
        t.Item[index7].Enhance = curHeroData.Enhance;
        t.Item[index7].Arms = recordByKey.SoldierKind;
        t.Item[index7].Star = curHeroData.Star;
        t.Item[index7].MaxNum = this.DM.RankSoldiers[(int) curHeroData.Enhance];
        t.Item[index7].bIsLords = (int) num == (int) this.DM.GetLeaderID();
        t.Item[index7].bSelect = false;
        t.Item[index7].bIsFight = true;
        t.Item[index7].Type = (byte) 0;
        if (this.m_OpenType == 1)
        {
          for (int index8 = 0; index8 < this.DM.m_DefendersID.Length; ++index8)
          {
            if (this.DM.m_DefendersID[index8] != (ushort) 0 && (int) num == (int) this.DM.m_DefendersID[index8])
            {
              t.Item[index7].bSelect = true;
              this.m_MaxNum += (uint) this.DM.RankSoldiers[(int) curHeroData.Enhance];
              this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[index8]).transform, eHeroOrItem.Hero, (ushort) num, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
              ((Graphic) this.m_BattleHero[index8].HIImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) this.m_BattleHero[index8].CircleImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) this.m_BattleHero[index8].HeroRankImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) this.m_BattleHero[index8].LvOrNum).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Component) this.m_BattleHero[index8]).gameObject.SetActive(true);
              ((Behaviour) this.m_BattleHeroPlus[index8]).enabled = false;
              this.m_BattleHeroID[index8] = (ushort) num;
              if (heroState != eHeroState.None)
                ++this.m_SelectNum;
              if ((int) this.DM.m_DefendersID[index8] == (int) this.DM.GetLeaderID())
              {
                this.bHaveLeader = true;
                break;
              }
              break;
            }
          }
        }
        else if (this.m_OpenType == 0 && this.bPreselectedTeam)
        {
          for (int index9 = 0; index9 < this.DM.LegionBattleHero.Count; ++index9)
          {
            if (this.DM.LegionBattleHero[index9] != (ushort) 0 && (int) num == (int) this.DM.LegionBattleHero[index9])
            {
              t.Item[index7].bSelect = true;
              this.m_MaxNum += (uint) this.DM.RankSoldiers[(int) curHeroData.Enhance];
              this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[index9]).transform, eHeroOrItem.Hero, (ushort) num, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
              ((Graphic) this.m_BattleHero[index9].HIImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) this.m_BattleHero[index9].CircleImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) this.m_BattleHero[index9].HeroRankImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) this.m_BattleHero[index9].LvOrNum).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Component) this.m_BattleHero[index9]).gameObject.SetActive(true);
              ((Behaviour) this.m_BattleHeroPlus[index9]).enabled = false;
              this.m_BattleHeroID[index9] = (ushort) num;
              if (heroState != eHeroState.None)
                ++this.m_SelectNum;
              if ((int) this.DM.LegionBattleHero[index9] == (int) this.DM.GetLeaderID())
              {
                this.bHaveLeader = true;
                break;
              }
              break;
            }
          }
        }
        if (index7 == 1 || (long) index6 == (long) (this.DM.FightHeroCount - 1U))
          this.m_Data.Add(t);
      }
      else if (index7 == 1 || (long) index6 == (long) (this.DM.FightHeroCount - 1U))
        this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(t);
    }
    this.m_MaxNumStr.ClearString();
    if (this.m_OpenType == 1)
    {
      this.m_MaxNumText.text = this.m_MaxNum <= 0U ? string.Empty : this.DM.mStringTable.GetStringByID(815U);
    }
    else
    {
      StringManager.Instance.IntToFormat((long) this.m_MaxNum, bNumber: true);
      if (GUIManager.Instance.IsArabic)
        this.m_MaxNumStr.AppendFormat("{0}+");
      else
        this.m_MaxNumStr.AppendFormat("+{0}");
      this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
    }
    this.SetEffectData();
    this.m_MaxNumText.SetAllDirty();
    this.m_MaxNumText.cachedTextGenerator.Invalidate();
    if (this.bHaveLeader)
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(true);
      this.m_LeaderImageTf.gameObject.SetActive(true);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(27f, 0.0f);
    }
    else
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(false);
      this.m_LeaderImageTf.gameObject.SetActive(false);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    }
  }

  private void UpdateData(bool bMoveTop = true)
  {
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(this.m_Data[index].Height);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, bMoveTop);
  }

  private void AddToMoveStack(
    int beginIdx,
    ushort heroID,
    Vector2 begin,
    Vector2 end,
    int endBtnIdx)
  {
    if (endBtnIdx < 0 || endBtnIdx >= 5 || beginIdx < 0 || beginIdx >= 5)
      return;
    if (this.moveStack[beginIdx].bMoving)
    {
      GUIManager.Instance.AddHUDMessage("moveStack[{0}].bMoving", (ushort) byte.MaxValue);
    }
    else
    {
      ((Component) this.m_MoveHero[beginIdx]).gameObject.SetActive(true);
      ((Component) this.m_BattleHero[beginIdx]).gameObject.SetActive(false);
      ((Behaviour) this.m_BattleHeroPlus[beginIdx]).enabled = true;
      CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint) heroID];
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_MoveHero[beginIdx]).transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHero[endBtnIdx]).transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
      ((Component) this.m_MoveHero[beginIdx]).gameObject.GetComponent<RectTransform>().anchoredPosition = begin;
      ((Component) this.m_BattleHero[endBtnIdx]).gameObject.SetActive(false);
      this.moveStack[beginIdx].heroID = heroID;
      this.moveStack[beginIdx].begin = begin;
      this.moveStack[beginIdx].end = end;
      this.moveStack[beginIdx].battleBtnIdx = endBtnIdx;
      this.moveStack[beginIdx].bMoving = true;
      ++this.MoveBtnCount;
    }
  }

  private void RemoveBattleHero(int index)
  {
    if (!this.bCanClick || this.MoveBtnCount > 0)
      return;
    for (int endBtnIdx = index; endBtnIdx < this.m_SelectNum - 1; ++endBtnIdx)
    {
      Vector2 anchoredPosition1 = ((Component) this.m_BattleHero[endBtnIdx + 1]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
      Vector2 anchoredPosition2 = ((Component) this.m_BattleHero[endBtnIdx]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
      this.AddToMoveStack(endBtnIdx + 1, this.m_BattleHeroID[endBtnIdx + 1], anchoredPosition1, anchoredPosition2, endBtnIdx);
      this.m_BattleHeroID[endBtnIdx] = this.m_BattleHeroID[endBtnIdx + 1];
      this.m_BattleHero[endBtnIdx].m_BtnID2 = this.m_BattleHero[endBtnIdx + 1].m_BtnID2;
      this.m_BattleHero[endBtnIdx].m_BtnID3 = this.m_BattleHero[endBtnIdx + 1].m_BtnID3;
    }
    --this.m_SelectNum;
    this.m_BattleHeroID[this.m_SelectNum] = (ushort) 0;
    ((Component) this.m_BattleHero[this.m_SelectNum]).gameObject.SetActive(false);
    ((Behaviour) this.m_BattleHeroPlus[this.m_SelectNum]).enabled = true;
  }

  private void Update()
  {
    this.bMoving = false;
    for (int index = 0; index < this.moveStack.Length; ++index)
    {
      if (this.moveStack[index].bMoving)
      {
        this.bMoving = true;
        Vector2 vector2 = Vector2.MoveTowards(this.moveStack[index].begin, this.moveStack[index].end, 2000f * Time.deltaTime);
        ((Component) this.m_MoveHero[index]).GetComponent<RectTransform>().anchoredPosition = vector2;
        this.moveStack[index].begin = vector2;
        if (this.moveStack[index].begin == this.moveStack[index].end)
        {
          ((Component) this.m_BattleHero[this.moveStack[index].battleBtnIdx]).gameObject.SetActive(true);
          ((Behaviour) this.m_BattleHeroPlus[this.moveStack[index].battleBtnIdx]).enabled = false;
          ((Component) this.m_MoveHero[index]).gameObject.SetActive(false);
          this.moveStack[index].bMoving = false;
          --this.MoveBtnCount;
        }
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.m_TweenAlphaImage[index] != (UnityEngine.Object) null && ((Behaviour) this.m_TweenAlphaImage[index]).enabled)
      {
        this.m_ColorTick[index] += Time.deltaTime;
        if ((double) this.m_ColorTick[index] >= 0.0099999997764825821)
        {
          this.m_ColorA[index] -= 0.02f;
          ((Graphic) this.m_TweenAlphaImage[index]).color = new Color(1f, 1f, 1f, this.m_ColorA[index]);
          if ((double) this.m_ColorA[index] < 0.0)
          {
            this.m_ColorA[index] = 1f;
            ((Behaviour) this.m_TweenAlphaImage[index]).enabled = false;
          }
          this.m_ColorTick[index] = 0.0f;
        }
      }
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    Transform[] transformArray = new Transform[2];
    bool[] flagArray = new bool[2]{ true, true };
    if (panelId == 1)
    {
      if (dataIdx >= this.m_EffetData.Count)
        return;
      if ((UnityEngine.Object) this.m_TextItem[panelObjectIdx].Text1 == (UnityEngine.Object) null)
      {
        this.m_TextItem[panelObjectIdx].Text1 = item.transform.GetChild(0).GetComponent<UIText>();
        this.m_TextItem[panelObjectIdx].Text2 = item.transform.GetChild(1).GetComponent<UIText>();
        ((Graphic) this.m_TextItem[panelObjectIdx].Text2).rectTransform.sizeDelta = new Vector2(80f, 30f);
        ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.anchoredPosition = new Vector2(5f, 0.0f);
        ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta = new Vector2(156f, 30f);
        this.m_TextItem[panelObjectIdx].Text1.resizeTextForBestFit = true;
        this.m_TextItem[panelObjectIdx].Text1.resizeTextMaxSize = 20;
        this.m_TextItem[panelObjectIdx].Text1.resizeTextMinSize = 10;
        this.m_TextItem[panelObjectIdx].Text2.resizeTextForBestFit = true;
        this.m_TextItem[panelObjectIdx].Text2.resizeTextMaxSize = 20;
        this.m_TextItem[panelObjectIdx].Text2.resizeTextMinSize = 10;
        this.m_TextItem[panelObjectIdx].Text1.font = this.TTF;
        this.m_TextItem[panelObjectIdx].Text2.font = this.TTF;
      }
      if (this.m_EffetData[dataIdx].Type == (byte) 0)
      {
        ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta = new Vector2(148.7f, 30f);
        this.m_TextItem[panelObjectIdx].Text1.alignment = TextAnchor.MiddleLeft;
        this.m_TextItem[panelObjectIdx].Text1Str.ClearString();
        this.m_TextItem[panelObjectIdx].Text2Str.ClearString();
        GameConstants.GetEffectValue(this.m_TextItem[panelObjectIdx].Text1Str, this.m_EffetData[dataIdx].EffectID, (uint) this.m_EffetData[dataIdx].Value, (byte) 8, 0.0f);
        GameConstants.GetEffectValue(this.m_TextItem[panelObjectIdx].Text2Str, this.m_EffetData[dataIdx].EffectID, 0U, (byte) 5, this.m_EffetData[dataIdx].Value);
        this.m_TextItem[panelObjectIdx].Text1.text = this.m_TextItem[panelObjectIdx].Text1Str.ToString();
        this.m_TextItem[panelObjectIdx].Text2.text = this.m_TextItem[panelObjectIdx].Text2Str.ToString();
        Vector2 sizeDelta = ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta with
        {
          y = this.m_EffetData[dataIdx].TextHeight
        };
        ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta = sizeDelta;
        this.m_TextItem[panelObjectIdx].Text1.SetAllDirty();
        this.m_TextItem[panelObjectIdx].Text1.cachedTextGeneratorForLayout.Invalidate();
        this.m_TextItem[panelObjectIdx].Text1.cachedTextGenerator.Invalidate();
        this.m_TextItem[panelObjectIdx].Text1.UpdateArabicPos();
        this.m_TextItem[panelObjectIdx].Text2.SetAllDirty();
        this.m_TextItem[panelObjectIdx].Text2.cachedTextGenerator.Invalidate();
        this.m_TextItem[panelObjectIdx].Text2.UpdateArabicPos();
      }
      else if (this.m_EffetData[dataIdx].Type == (byte) 1)
      {
        ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta = new Vector2(222.65f, 30f);
        this.m_TextItem[panelObjectIdx].Text1.alignment = TextAnchor.MiddleCenter;
        this.m_TextItem[panelObjectIdx].Text2Str.ClearString();
        this.m_TextItem[panelObjectIdx].Text2.text = this.m_TextItem[panelObjectIdx].Text2Str.ToString();
        this.m_TextItem[panelObjectIdx].Text2.SetAllDirty();
        this.m_TextItem[panelObjectIdx].Text2.cachedTextGenerator.Invalidate();
        this.m_TextItem[panelObjectIdx].Text1.text = this.DM.mStringTable.GetStringByID((uint) this.m_EffetData[dataIdx].EffectID);
      }
      else
      {
        if (this.m_EffetData[dataIdx].Type != (byte) 2)
          return;
        ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta = new Vector2(222.65f, 60f);
        this.m_TextItem[panelObjectIdx].Text1.alignment = TextAnchor.MiddleLeft;
        this.m_TextItem[panelObjectIdx].Text2Str.ClearString();
        this.m_TextItem[panelObjectIdx].Text2.text = this.m_TextItem[panelObjectIdx].Text2Str.ToString();
        this.m_TextItem[panelObjectIdx].Text2.SetAllDirty();
        this.m_TextItem[panelObjectIdx].Text2.cachedTextGenerator.Invalidate();
        this.m_TextItem[panelObjectIdx].Text1.text = this.DM.mStringTable.GetStringByID((uint) this.m_EffetData[dataIdx].EffectID);
        Vector2 sizeDelta = ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta with
        {
          y = this.m_TextItem[panelObjectIdx].Text1.preferredHeight
        };
        ((Graphic) this.m_TextItem[panelObjectIdx].Text1).rectTransform.sizeDelta = sizeDelta;
      }
    }
    else
    {
      ScrollPanelItem component1 = item.transform.GetComponent<ScrollPanelItem>();
      component1.m_BtnID1 = dataIdx;
      component1.m_BtnID2 = panelObjectIdx;
      if ((UnityEngine.Object) this.m_ScrollObj[panelObjectIdx].PanelItem[0].HeroBtn == (UnityEngine.Object) null)
      {
        for (int index = 0; index < 2; ++index)
        {
          transformArray[index] = item.transform.GetChild(0).GetChild(index);
          transformArray[index].GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].HeroBtn = transformArray[index].GetChild(0).GetComponent<UIHIBtn>();
          UIButtonHint component2 = transformArray[index].GetChild(0).GetComponent<UIButtonHint>();
          component2.m_Handler = (MonoBehaviour) this;
          component2.m_eHint = EUIButtonHint.Slider;
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
            UIButton component3 = transformArray[index].GetComponent<UIButton>();
            component3.m_BtnID1 = dataIdx;
            component3.m_BtnID2 = panelObjectIdx;
            component3.m_BtnID3 = index;
            this.GM.ChangeHeroItemImg(((Component) this.m_ScrollObj[panelObjectIdx].PanelItem[index].HeroBtn).transform, eHeroOrItem.Hero, (ushort) heroId, this.m_Data[dataIdx].Item[index].Star, (byte) 0, (int) this.m_Data[dataIdx].Item[index].Lv);
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].EnhanceIcon.sprite = this.GetEnhanceIcon(this.m_Data[dataIdx].Item[index].Enhance);
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsIcons.sprite = this.GetArmsIcon(this.m_Data[dataIdx].Item[index].Arms);
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText = transformArray[index].GetChild(3).GetComponent<UIText>();
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText.text = this.GetArmsStr(this.m_Data[dataIdx].Item[index].Arms);
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText.SetAllDirty();
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText.cachedTextGenerator.Invalidate();
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText = transformArray[index].GetChild(4).GetComponent<UIText>();
            if (this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr == null)
              this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr = StringManager.Instance.SpawnString();
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr.ClearString();
            StringManager.Instance.IntToFormat((long) this.m_Data[dataIdx].Item[index].MaxNum, bNumber: true);
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr.AppendFormat("{0}");
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText.text = this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr.ToString();
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText.SetAllDirty();
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText.cachedTextGenerator.Invalidate();
            if (this.m_Data[dataIdx].Item[index].bSelect || this.m_Data[dataIdx].Item[index].bIsFight)
            {
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaskImage).enabled = true;
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = false;
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = false;
              if (this.m_Data[dataIdx].Item[index].bSelect)
                ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = true;
              if (this.m_Data[dataIdx].Item[index].bIsFight)
              {
                ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = true;
                if (this.m_Data[dataIdx].Item[index].bIsLords)
                {
                  if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
                    this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage.sprite = this.m_SpritesArray.GetSprite(5);
                  else if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
                    this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage.sprite = this.m_SpritesArray.GetSprite(4);
                  else if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
                    this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage.sprite = this.m_SpritesArray.GetSprite(6);
                }
                else
                  this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage.sprite = this.m_SpritesArray.GetSprite(4);
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

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    int btnId1 = sender.m_BtnID1;
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < this.m_Data.Count; ++index3)
    {
      for (int index4 = 0; index4 < 2; ++index4)
      {
        if ((int) this.m_Data[index3].Item[index4].HeroID == (int) this.m_BattleHeroID[btnId1])
        {
          index1 = index3;
          index2 = index4;
          break;
        }
      }
    }
    if (this.bMoving || !this.m_Data[index1].Item[index2].bSelect)
      return;
    uint heroId = (uint) this.m_Data[index1].Item[index2].HeroID;
    if (this.m_OpenType == 0)
    {
      if ((int) heroId == (int) this.DM.GetLeaderID())
        this.bHaveLeader = false;
    }
    else if ((int) heroId == (int) this.DM.GetLeaderID())
    {
      this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(725U), (ushort) byte.MaxValue);
      return;
    }
    CurHeroData curHeroData = DataManager.Instance.curHeroData[heroId];
    this.m_Data[index1].Item[index2].bSelect = false;
    this.m_Data[index1].Item[index2].Type = (byte) 0;
    this.m_MaxNum -= (uint) this.DM.RankSoldiers[(int) curHeroData.Enhance];
    ((Behaviour) this.m_TweenAlphaImage[btnId1]).enabled = false;
    ((Graphic) this.m_TweenAlphaImage[btnId1]).color = new Color(1f, 1f, 1f, 0.0f);
    this.RemoveBattleHero(btnId1);
    ((Component) this.m_BattleHero[btnId1]).gameObject.SetActive(false);
    ((Behaviour) this.m_BattleHeroPlus[btnId1]).enabled = true;
    if (this.bHaveLeader)
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(true);
      this.m_LeaderImageTf.gameObject.SetActive(true);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(27f, 0.0f);
    }
    else
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(false);
      this.m_LeaderImageTf.gameObject.SetActive(false);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    }
    this.m_MaxNumStr.ClearString();
    if (this.m_OpenType == 1)
    {
      this.m_MaxNumText.text = this.m_MaxNum <= 0U ? string.Empty : this.DM.mStringTable.GetStringByID(815U);
    }
    else
    {
      StringManager.Instance.IntToFormat((long) this.m_MaxNum, bNumber: true);
      if (GUIManager.Instance.IsArabic)
        this.m_MaxNumStr.AppendFormat("{0}+");
      else
        this.m_MaxNumStr.AppendFormat("+{0}");
      this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
    }
    this.SetEffectData();
    List<float> _DataHeight = new List<float>();
    for (int index5 = 0; index5 < this.m_EffetData.Count; ++index5)
      _DataHeight.Add(this.m_EffetData[index5].TextHeight);
    this.m_EffScrollPanel.AddNewDataHeight(_DataHeight, false);
    _DataHeight.Clear();
    for (int index6 = 0; index6 < this.m_Data.Count; ++index6)
      _DataHeight.Add(this.m_Data[index6].Height);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
    this.m_MaxNumText.SetAllDirty();
    this.m_MaxNumText.cachedTextGenerator.Invalidate();
    this.CheckBattleHero();
    this.CheckAutoSelectText();
  }

  public void OnButtonClick(UIButton sender)
  {
    int btnId1 = sender.m_BtnID1;
    int btnId2 = sender.m_BtnID2;
    int btnId3 = sender.m_BtnID3;
    int num = (int) this.m_BattleHeroNum - this.m_SelectNum;
    if (this.bHint)
    {
      this.bHint = false;
      this.bOnClick = false;
    }
    else if (this.bOnClick || this.MoveBtnCount > 0)
    {
      this.bOnClick = false;
    }
    else
    {
      if ((UnityEngine.Object) ((Component) sender).gameObject.GetComponent<UIButtonHint>() != (UnityEngine.Object) null)
      {
        ((Component) sender).gameObject.GetComponent<UIButtonHint>().bCountDown = false;
        ((Component) sender).gameObject.GetComponent<UIButtonHint>().m_Time = 0.0f;
      }
      this.bOnClick = true;
      if (btnId1 >= 0 && btnId1 < 100 && !this.bMoving)
      {
        if (this.m_OpenType == 0)
        {
          if (!this.bPreselectedTeam && this.m_Data[btnId1].Item[btnId3].bIsFight)
          {
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(708U), (ushort) byte.MaxValue);
            this.bOnClick = false;
            return;
          }
        }
        else if ((int) this.m_Data[btnId1].Item[btnId3].HeroID == (int) this.DM.GetLeaderID())
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(725U), (ushort) byte.MaxValue);
          this.bOnClick = false;
          return;
        }
        this.SetItemType(sender);
        this.CheckAutoSelectText();
      }
      else if (sender.m_BtnID1 == 997)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(330U), (ushort) byte.MaxValue);
      else if (sender.m_BtnID1 == 998)
      {
        if ((this.m_OpenType != 0 ? (int) this.m_BattleHeroNum : Mathf.Clamp((int) this.DM.NonFightHeroCount, 0, (int) this.m_BattleHeroNum)) == this.m_SelectNum)
          this.AutoClear();
        else
          this.AutoSelect();
        this.CheckAutoSelectText();
      }
      else if (sender.m_BtnID1 == 999)
        this.door.CloseMenu();
      else if (sender.m_BtnID1 == 1000)
      {
        if (this.m_OpenType == 0)
        {
          this.DM.LegionBattleHero.Clear();
          for (int index = 0; index < 5; ++index)
          {
            if (this.m_BattleHeroID[index] != (ushort) 0)
              this.DM.LegionBattleHero.Add(this.m_BattleHeroID[index]);
          }
          this.door.CloseMenu();
        }
        else
        {
          Array.Clear((Array) this.DM.m_DefendersID, 0, this.DM.m_DefendersID.Length);
          for (int index = 0; index < 5; ++index)
            this.DM.m_DefendersID[index] = this.m_BattleHeroID[index];
          if (this.m_BattleHeroNum > (byte) 1)
            this.DM.SendDefenderID();
          this.door.CloseMenu();
        }
      }
      this.bOnClick = false;
    }
  }

  public void CheckAutoSelectText()
  {
    if (this.m_SelectNum == (int) this.m_BattleHeroNum)
      this.m_AutoText.text = this.DM.mStringTable.GetStringByID(825U);
    else
      this.m_AutoText.text = this.DM.mStringTable.GetStringByID(824U);
  }

  public void SetEffectData()
  {
    ushort[] numArray1 = new ushort[4];
    bool flag1 = false;
    byte[] numArray2 = new byte[5]
    {
      (byte) 1,
      (byte) 2,
      (byte) 4,
      (byte) 8,
      (byte) 20
    };
    this.m_EffetData.Clear();
    if (this.bHaveLeader)
    {
      SkillEffect skillEffect;
      skillEffect.Type = (byte) 1;
      skillEffect.EffectID = (ushort) 351;
      skillEffect.Value = 0.0f;
      skillEffect.TextHeight = 30f;
      this.m_EffetData.Add(skillEffect);
    }
    for (int index1 = 0; index1 < this.m_SelectNum && index1 < this.m_BattleHeroID.Length; ++index1)
    {
      Hero recordByKey1 = this.DM.HeroTable.GetRecordByKey(this.m_BattleHeroID[index1]);
      numArray1[0] = recordByKey1.GroupSkill1;
      numArray1[1] = recordByKey1.GroupSkill2;
      numArray1[2] = recordByKey1.GroupSkill3;
      numArray1[3] = recordByKey1.GroupSkill4;
      for (int index2 = 0; index2 < numArray1.Length; ++index2)
      {
        Skill recordByKey2 = this.DM.SkillTable.GetRecordByKey(numArray1[index2]);
        if (this.DM.curHeroData.ContainsKey((uint) this.m_BattleHeroID[index1]))
        {
          CurHeroData curHeroData = this.DM.curHeroData[(uint) this.m_BattleHeroID[index1]];
          if (recordByKey2.SkillType == (byte) 11 && curHeroData.SkillLV[index2] > (byte) 0 && index2 < curHeroData.SkillLV.Length)
          {
            float num1 = 0.0f;
            if (this.m_BattleHeroID[index1] != (ushort) 0)
            {
              float num2 = ((float) recordByKey2.HurtValue + (float) ((int) numArray2[(int) curHeroData.Star - 1] * (int) recordByKey2.HurtIncreaseValue) / 1000f) * 100f;
              SkillEffect skillEffect;
              skillEffect.Type = (byte) 0;
              skillEffect.EffectID = recordByKey2.HurtAddition;
              skillEffect.Value = num2;
              skillEffect.TextHeight = this.CalculateTextHeight(skillEffect.EffectID, 156f, this.context);
              bool flag2 = false;
              for (int index3 = 0; index3 < this.m_EffetData.Count; ++index3)
              {
                if ((int) this.m_EffetData[index3].EffectID == (int) skillEffect.EffectID && this.m_EffetData[index3].Type == (byte) 0)
                {
                  skillEffect.Value += this.m_EffetData[index3].Value;
                  this.m_EffetData[index3] = skillEffect;
                  flag2 = true;
                  break;
                }
              }
              if (!flag2)
              {
                this.m_EffetData.Add(skillEffect);
                num1 = 0.0f;
              }
              flag1 = true;
            }
          }
        }
      }
    }
    if (this.m_OpenType == 0 && !flag1 && this.m_SelectNum > 0)
    {
      SkillEffect skillEffect;
      skillEffect.Type = (byte) 2;
      skillEffect.EffectID = (ushort) 814;
      skillEffect.Value = 0.0f;
      skillEffect.TextHeight = this.CalculateTextHeight(skillEffect.EffectID, 156f, this.context);
      if (this.bHaveLeader)
        this.m_EffetData.Insert(1, skillEffect);
      else
        this.m_EffetData.Insert(0, skillEffect);
    }
    if (this.m_EffetData.Count == 0)
      ((Component) this.m_EmptyStr).gameObject.SetActive(true);
    else
      ((Component) this.m_EmptyStr).gameObject.SetActive(false);
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

  private void AutoSelect()
  {
    int num = (int) this.m_BattleHeroNum - this.m_SelectNum;
    if (this.DM.NonFightHeroCount == 0U)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(875U), (ushort) byte.MaxValue);
    }
    else
    {
      for (int index1 = 0; index1 < this.m_Data.Count; ++index1)
      {
        for (int index2 = 0; index2 < 2 && num > 0; ++index2)
        {
          if (!this.m_Data[index1].Item[index2].bSelect && this.m_Data[index1].Item[index2].HeroID != (ushort) 0 && (this.m_OpenType != 0 || !this.m_Data[index1].Item[index2].bIsFight))
          {
            this.m_Data[index1].Item[index2].bSelect = true;
            this.m_MaxNum += (uint) this.m_Data[index1].Item[index2].MaxNum;
            if (this.m_Data[index1].Item[index2].bIsLords)
            {
              for (int selectNum = this.m_SelectNum; selectNum > 0; --selectNum)
              {
                Vector2 anchoredPosition1 = ((Component) this.m_BattleHero[selectNum - 1]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
                Vector2 anchoredPosition2 = ((Component) this.m_BattleHero[selectNum]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
                this.AddToMoveStack(selectNum - 1, this.m_BattleHeroID[selectNum - 1], anchoredPosition1, anchoredPosition2, selectNum);
                this.m_BattleHeroID[selectNum] = this.m_BattleHeroID[selectNum - 1];
              }
              this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[0]).transform, eHeroOrItem.Hero, this.m_Data[index1].Item[index2].HeroID, this.m_Data[index1].Item[index2].Star, this.m_Data[index1].Item[index2].Enhance, (int) this.m_Data[index2].Item[index2].Lv);
              this.m_BattleHeroID[0] = this.m_Data[index1].Item[index2].HeroID;
              ((Component) this.m_BattleHero[0]).gameObject.SetActive(true);
              ((Behaviour) this.m_BattleHeroPlus[0]).enabled = false;
              ((Behaviour) this.m_TweenAlphaImage[0]).enabled = true;
              if (this.m_SelectNum < (int) this.m_BattleHeroNum)
                ++this.m_SelectNum;
              this.bHaveLeader = true;
            }
            else if (this.m_SelectNum < (int) this.m_BattleHeroNum)
            {
              this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[this.m_SelectNum]).transform, eHeroOrItem.Hero, this.m_Data[index1].Item[index2].HeroID, this.m_Data[index1].Item[index2].Star, this.m_Data[index1].Item[index2].Enhance, (int) this.m_Data[index1].Item[index2].Lv);
              ((Component) this.m_BattleHero[this.m_SelectNum]).gameObject.SetActive(true);
              ((Behaviour) this.m_BattleHeroPlus[this.m_SelectNum]).enabled = false;
              this.m_BattleHeroID[this.m_SelectNum] = this.m_Data[index1].Item[index2].HeroID;
              ((Behaviour) this.m_TweenAlphaImage[this.m_SelectNum]).enabled = true;
              this.m_ColorTick[this.m_SelectNum] = 0.01f;
              this.m_ColorA[this.m_SelectNum] = 1f;
              ++this.m_SelectNum;
            }
            --num;
          }
        }
      }
      this.m_MaxNumStr.ClearString();
      if (this.m_OpenType == 1)
      {
        this.m_MaxNumText.text = this.DM.mStringTable.GetStringByID(815U);
      }
      else
      {
        StringManager.Instance.IntToFormat((long) this.m_MaxNum, bNumber: true);
        if (GUIManager.Instance.IsArabic)
          this.m_MaxNumStr.AppendFormat("{0}+");
        else
          this.m_MaxNumStr.AppendFormat("+{0}");
        this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
      }
      this.CheckBattleHero();
      this.UpdateData(false);
      this.SetEffectData();
      this.m_MaxNumText.SetAllDirty();
      this.m_MaxNumText.cachedTextGenerator.Invalidate();
      List<float> _DataHeight = new List<float>();
      for (int index = 0; index < this.m_EffetData.Count; ++index)
      {
        if (this.m_EffetData[index].Type == (byte) 2)
          _DataHeight.Add(60f);
        else
          _DataHeight.Add(this.m_EffetData[index].TextHeight);
      }
      this.m_EffScrollPanel.AddNewDataHeight(_DataHeight, false);
      if (this.bHaveLeader)
      {
        this.m_BtnLeaderImageTf.gameObject.SetActive(true);
        this.m_LeaderImageTf.gameObject.SetActive(true);
        ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(27f, 0.0f);
      }
      else
      {
        this.m_BtnLeaderImageTf.gameObject.SetActive(false);
        this.m_LeaderImageTf.gameObject.SetActive(false);
        ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
      }
    }
  }

  private void AutoClear()
  {
    for (int index1 = 0; index1 < this.m_Data.Count; ++index1)
    {
      for (int index2 = 0; index2 < 2 && this.m_SelectNum > 0; ++index2)
      {
        if (this.m_Data[index1].Item[index2].bSelect && this.m_Data[index1].Item[index2].HeroID != (ushort) 0)
        {
          if ((int) this.m_Data[index1].Item[index2].HeroID == (int) this.DM.GetLeaderID())
          {
            if (this.m_OpenType != 1)
              this.bHaveLeader = false;
            else
              continue;
          }
          this.m_Data[index1].Item[index2].bSelect = false;
          this.m_MaxNum -= (uint) this.m_Data[index1].Item[index2].MaxNum;
          --this.m_SelectNum;
          this.m_BattleHeroID[this.m_SelectNum] = (ushort) 0;
          ((Component) this.m_BattleHero[this.m_SelectNum]).gameObject.SetActive(false);
          ((Behaviour) this.m_BattleHeroPlus[this.m_SelectNum]).enabled = true;
        }
      }
    }
    if (this.bHaveLeader)
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(true);
      this.m_LeaderImageTf.gameObject.SetActive(true);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(27f, 0.0f);
    }
    else
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(false);
      this.m_LeaderImageTf.gameObject.SetActive(false);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    }
    this.m_MaxNumStr.ClearString();
    if (this.m_OpenType == 1)
    {
      this.m_MaxNumText.text = this.DM.mStringTable.GetStringByID(815U);
    }
    else
    {
      StringManager.Instance.IntToFormat((long) this.m_MaxNum, bNumber: true);
      if (GUIManager.Instance.IsArabic)
        this.m_MaxNumStr.AppendFormat("{0}+");
      else
        this.m_MaxNumStr.AppendFormat("+{0}");
      this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
    }
    this.UpdateData(false);
    this.SetEffectData();
    this.m_MaxNumText.SetAllDirty();
    this.m_MaxNumText.cachedTextGenerator.Invalidate();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_EffetData.Count; ++index)
    {
      if (this.m_EffetData[index].Type == (byte) 2)
        _DataHeight.Add(60f);
      else
        _DataHeight.Add(this.m_EffetData[index].TextHeight);
    }
    this.m_EffScrollPanel.AddNewDataHeight(_DataHeight, false);
    if (this.bHaveLeader)
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(true);
      this.m_LeaderImageTf.gameObject.SetActive(true);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(27f, 0.0f);
    }
    else
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(false);
      this.m_LeaderImageTf.gameObject.SetActive(false);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.m_eHint == EUIButtonHint.DownUpHandler)
    {
      this.m_IconHintPanel.gameObject.SetActive(true);
    }
    else
    {
      int btnId1 = sender.transform.parent.GetComponent<UIButton>().m_BtnID1;
      int btnId3 = sender.transform.parent.GetComponent<UIButton>().m_BtnID3;
      this.SetSkillHint(this.m_Data[btnId1].Item[btnId3].HeroID, this.m_Data[btnId1].Item[btnId3].Enhance, (int) this.m_Data[btnId1].Item[btnId3].MaxNum, this.m_Data[btnId1].Item[btnId3].Arms);
      this.m_SkillHintPanel.gameObject.SetActive(true);
      this.bHint = true;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (sender.m_eHint == EUIButtonHint.DownUpHandler)
    {
      this.m_IconHintPanel.gameObject.SetActive(false);
    }
    else
    {
      sender.bCountDown = false;
      sender.m_Time = 0.0f;
      this.bHint = false;
      this.m_SkillHintPanel.gameObject.SetActive(false);
    }
  }

  public void SetItemType(UIButton sender)
  {
    int btnId1 = sender.m_BtnID1;
    int btnId3 = sender.m_BtnID3;
    if (btnId1 >= this.m_Data.Count)
      return;
    int selectNum = this.m_SelectNum;
    int num = (int) this.m_BattleHeroNum - this.m_SelectNum;
    if (!this.m_Data[btnId1].Item[btnId3].bSelect)
    {
      if (num > 0)
      {
        if (this.m_Data[btnId1].Item[btnId3].bIsLords)
        {
          for (int endBtnIdx = selectNum; endBtnIdx > 0; --endBtnIdx)
          {
            Vector2 anchoredPosition1 = ((Component) this.m_BattleHero[endBtnIdx - 1]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
            Vector2 anchoredPosition2 = ((Component) this.m_BattleHero[endBtnIdx]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
            this.AddToMoveStack(endBtnIdx - 1, this.m_BattleHeroID[endBtnIdx - 1], anchoredPosition1, anchoredPosition2, endBtnIdx);
            this.m_BattleHeroID[endBtnIdx] = this.m_BattleHeroID[endBtnIdx - 1];
            this.m_BattleHero[endBtnIdx].m_BtnID2 = this.m_BattleHero[endBtnIdx - 1].m_BtnID2;
            this.m_BattleHero[endBtnIdx].m_BtnID3 = this.m_BattleHero[endBtnIdx - 1].m_BtnID3;
          }
          this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[0]).transform, eHeroOrItem.Hero, this.m_Data[btnId1].Item[btnId3].HeroID, this.m_Data[btnId1].Item[btnId3].Star, this.m_Data[btnId1].Item[btnId3].Enhance, (int) this.m_Data[btnId1].Item[btnId3].Lv);
          this.m_BattleHeroID[0] = this.m_Data[btnId1].Item[btnId3].HeroID;
          ((Component) this.m_BattleHero[0]).gameObject.SetActive(true);
          ((Behaviour) this.m_BattleHeroPlus[0]).enabled = false;
          ((Behaviour) this.m_TweenAlphaImage[0]).enabled = true;
          if (this.m_SelectNum < (int) this.m_BattleHeroNum)
            ++this.m_SelectNum;
          this.bHaveLeader = true;
        }
        else if (this.m_SelectNum < (int) this.m_BattleHeroNum)
        {
          this.GM.ChangeHeroItemImg(((Component) this.m_BattleHero[this.m_SelectNum]).transform, eHeroOrItem.Hero, this.m_Data[btnId1].Item[btnId3].HeroID, this.m_Data[btnId1].Item[btnId3].Star, this.m_Data[btnId1].Item[btnId3].Enhance, (int) this.m_Data[btnId1].Item[btnId3].Lv);
          ((Component) this.m_BattleHero[this.m_SelectNum]).gameObject.SetActive(true);
          ((Behaviour) this.m_BattleHeroPlus[this.m_SelectNum]).enabled = false;
          this.m_BattleHeroID[this.m_SelectNum] = this.m_Data[btnId1].Item[btnId3].HeroID;
          ((Behaviour) this.m_TweenAlphaImage[this.m_SelectNum]).enabled = true;
          this.m_ColorTick[this.m_SelectNum] = 0.01f;
          this.m_ColorA[this.m_SelectNum] = 1f;
          this.m_BattleHero[this.m_SelectNum].m_BtnID2 = btnId1;
          this.m_BattleHero[this.m_SelectNum].m_BtnID3 = btnId3;
          ++this.m_SelectNum;
        }
        this.m_MaxNum += (uint) this.m_Data[btnId1].Item[btnId3].MaxNum;
        this.m_Data[btnId1].Item[btnId3].bSelect = true;
      }
      else
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(770U), (ushort) byte.MaxValue);
    }
    else
    {
      for (int index = 0; index < (int) this.m_BattleHeroNum; ++index)
      {
        if ((int) this.m_BattleHeroID[index] == (int) this.m_Data[btnId1].Item[btnId3].HeroID)
        {
          ((Behaviour) this.m_TweenAlphaImage[index]).enabled = false;
          ((Graphic) this.m_TweenAlphaImage[index]).color = new Color(1f, 1f, 1f, 0.0f);
          this.RemoveBattleHero(index);
          if ((int) this.m_Data[btnId1].Item[btnId3].HeroID == (int) this.DM.GetLeaderID())
            this.bHaveLeader = false;
        }
      }
      this.m_MaxNum -= (uint) this.m_Data[btnId1].Item[btnId3].MaxNum;
      this.m_Data[btnId1].Item[btnId3].bSelect = false;
    }
    this.m_MaxNumStr.ClearString();
    if (this.m_OpenType == 1)
    {
      this.m_MaxNumText.text = this.m_MaxNum <= 0U ? string.Empty : this.DM.mStringTable.GetStringByID(815U);
    }
    else
    {
      StringManager.Instance.IntToFormat((long) this.m_MaxNum, bNumber: true);
      if (GUIManager.Instance.IsArabic)
        this.m_MaxNumStr.AppendFormat("{0}+");
      else
        this.m_MaxNumStr.AppendFormat("+{0}");
      this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
    }
    this.SetEffectData();
    this.m_MaxNumText.SetAllDirty();
    this.m_MaxNumText.cachedTextGenerator.Invalidate();
    if (this.bHaveLeader)
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(true);
      this.m_LeaderImageTf.gameObject.SetActive(true);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(27f, 0.0f);
    }
    else
    {
      this.m_BtnLeaderImageTf.gameObject.SetActive(false);
      this.m_LeaderImageTf.gameObject.SetActive(false);
      ((Graphic) this.m_BtnText).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    }
    this.CheckBattleHero();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_EffetData.Count; ++index)
    {
      if (this.m_EffetData[index].Type == (byte) 2)
        _DataHeight.Add(60f);
      else
        _DataHeight.Add(this.m_EffetData[index].TextHeight);
    }
    this.m_EffScrollPanel.AddNewDataHeight(_DataHeight, false);
    _DataHeight.Clear();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(this.m_Data[index].Height);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
  }

  public void CheckBattleHero()
  {
    for (int index = 0; index < this.m_BattleHero.Length; ++index)
    {
      ((Graphic) this.m_BattleHero[index].HIImage).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.m_BattleHero[index].CircleImage).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.m_BattleHero[index].HeroRankImage).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.m_BattleHero[index].LvOrNum).color = new Color(1f, 1f, 1f, 1f);
    }
    for (int index1 = 0; (long) index1 < (long) this.DM.FightHeroID[index1]; ++index1)
    {
      for (int index2 = 0; index2 < this.m_BattleHero.Length; ++index2)
      {
        if ((int) this.DM.FightHeroID[index1] == (int) this.m_BattleHeroID[index2])
        {
          ((Graphic) this.m_BattleHero[index2].HIImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          ((Graphic) this.m_BattleHero[index2].CircleImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          ((Graphic) this.m_BattleHero[index2].HeroRankImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          ((Graphic) this.m_BattleHero[index2].LvOrNum).color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
      }
    }
  }

  public float CalculateTextHeight(ushort meffectId, float width, UIText context)
  {
    int num = 20;
    context.fontSize = num;
    context.font = this.TTF;
    context.resizeTextForBestFit = true;
    context.resizeTextMaxSize = num;
    context.resizeTextMinSize = 10;
    ((Graphic) context).rectTransform.sizeDelta = new Vector2(width, 30f);
    Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(meffectId);
    context.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID);
    context.SetAllDirty();
    context.cachedTextGeneratorForLayout.Invalidate();
    return Mathf.Clamp(context.preferredHeight + 2f, 25f, context.preferredHeight + 2f);
  }
}
