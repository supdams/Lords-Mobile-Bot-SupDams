// Decompiled with JetBrains decompiler
// Type: UIHeroList_Soldier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIHeroList_Soldier : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private Transform m_InfoPanel;
  private Transform m_SortPanel;
  private Transform m_SkillPanel;
  private UnityEngine.UI.Text m_TitleText;
  private UnityEngine.UI.Text m_OKBtnText1;
  private UnityEngine.UI.Text m_OKBtnText2;
  private RectTransform m_OKBtnText1Rt;
  private ScrollPanel m_ScrollPanel;
  private UIButton m_ExitBtn;
  private UIButton m_OKBtn;
  private UIButton m_SortBtn;
  private UIButton m_AutoBtn;
  private Image m_OKLoadBg;
  private Image m_OKLoadFlash;
  private Transform m_HiBtn1;
  private Transform m_HiBtn2;
  private UnityEngine.UI.Text m_SoldierCountText;
  private UnityEngine.UI.Text m_SoldierValueCount;
  private UnityEngine.UI.Text m_SortBtnText;
  private UIHIBtn m_SkillHero;
  private UIHIBtn m_SkillBtn1;
  private UIHIBtn m_SkillBtn2;
  private UIHIBtn m_SkillBtn3;
  private UIHIBtn m_SkillBtn4;
  private Image m_SkillEnhance;
  private int MaxSelectHero = 10;
  private StringBuilder sb;
  private int m_MaxPanelObject;
  private UIHIBtn[] m_ItemHIBtns1;
  private Image[] m_ItemArmsIcons1;
  private Image[] m_ItemEnhanceIcons1;
  private UnityEngine.UI.Text[] m_ItemArmsTexts1;
  private UnityEngine.UI.Text[] m_ItemNumTexts1;
  private UIHIBtn[] m_ItemHIBtns2;
  private Image[] m_ItemArmsIcons2;
  private Image[] m_ItemEnhanceIcons2;
  private UnityEngine.UI.Text[] m_ItemArmsTexts2;
  private UnityEngine.UI.Text[] m_ItemNumTexts2;
  private Transform[] m_Item1;
  private Transform[] m_Item2;
  private Transform[] m_ItemLines;
  private Transform[] m_MaskImage1s;
  private Transform[] m_MaskImage2s;
  private Transform[] m_SelectImage1s;
  private Transform[] m_SelectImage2s;
  private Transform[] m_LineItem;
  private Transform[] m_LastStrItem;
  private UIButton[] m_ItemBtns1;
  private UIButton[] m_ItemBtns2;
  private Transform[] m_FightIcons1;
  private Transform[] m_FightIcons2;
  private Transform[] m_ItemLordBgs;
  private Transform[] m_ItemLordFlash;
  private uint[] m_SrotStrIDs = new uint[5]
  {
    343U,
    3841U,
    3842U,
    3843U,
    3844U
  };
  private bool m_bShowSortPanel;
  private eSort m_SortType;
  private uint FightHeroNum;
  private uint NonFightHeroNum;
  private int DataCount = (int) DataManager.Instance.CurHeroDataCount + 4;
  private float m_HintTick;
  private bool bShowHint;
  private bool bCanClick;
  private Image[] m_FlashLords;
  private float m_ColorA;
  private float m_ColorTick;
  private int LoadsDataIdx;
  private int m_LordID = 1;
  public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items;
  public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items2;
  public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items3;
  public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items4;
  public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items5;
  public List<float> m_HeightData;

  public override void OnOpen(int arg1, int arg2)
  {
    this.sb = new StringBuilder();
    GUIManager.Instance.AddSpriteAsset("UIExpedition");
    GUIManager.Instance.AddSpriteAsset("UI_frame");
    this.m_TitleText = this.transform.GetChild(18).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(339U);
    this.m_TitleText.font = GUIManager.Instance.GetTTFFont();
    this.m_InfoPanel = this.transform.GetChild(15);
    Transform child1 = this.m_InfoPanel.GetChild(3);
    this.m_OKBtn = child1.GetComponent<UIButton>();
    this.m_OKBtn.m_BtnID1 = 1;
    this.m_OKBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_OKLoadBg = child1.GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.m_OKLoadBg).material = this.GetArmsMat();
    this.m_OKLoadBg.sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_13");
    this.m_OKLoadFlash = child1.GetChild(1).GetComponent<Image>();
    ((MaskableGraphic) this.m_OKLoadFlash).material = this.GetArmsMat();
    this.m_OKLoadFlash.sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_12");
    this.m_OKBtnText1Rt = child1.GetChild(2).GetComponent<RectTransform>();
    this.m_OKBtnText1 = child1.GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_OKBtnText1.font = GUIManager.Instance.GetTTFFont();
    this.m_OKBtnText1.text = DataManager.Instance.mStringTable.GetStringByID(3U);
    this.m_OKBtnText2 = child1.GetChild(3).GetComponent<UnityEngine.UI.Text>();
    this.m_OKBtnText2.font = GUIManager.Instance.GetTTFFont();
    this.m_OKBtnText2.text = "領主在軍團中";
    this.m_ExitBtn = this.transform.GetChild(13).GetChild(0).GetComponent<UIButton>();
    this.m_ExitBtn.m_BtnID1 = 2;
    this.m_ExitBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_SoldierCountText = this.m_InfoPanel.GetChild(0).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_SoldierCountText.font = GUIManager.Instance.GetTTFFont();
    this.m_SoldierCountText.text = DataManager.Instance.LegionBattleSildoers.ToString();
    DataManager.Instance.LegionBattleHero.Clear();
    DataManager.Instance.LegionBattleSildoers = 0;
    this.m_SoldierValueCount = this.transform.GetChild(15).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_SoldierCountText.font = GUIManager.Instance.GetTTFFont();
    this.m_SoldierValueCount.font = GUIManager.Instance.GetTTFFont();
    this.sb.Length = 0;
    this.sb.AppendFormat("{0}/{1}", (object) 0, (object) this.MaxSelectHero);
    this.m_SoldierValueCount.text = this.sb.ToString();
    this.m_ScrollPanel = this.transform.GetChild(14).GetComponent<ScrollPanel>();
    Transform child2 = this.transform.GetChild(20).GetChild(0);
    UIButtonHint uiButtonHint1 = child2.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    child2.GetComponent<UIButton>().m_BtnID1 = 98;
    child2.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_HiBtn1 = child2.GetChild(0);
    GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn1, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    child2.GetChild(3).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    child2.GetChild(4).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    Transform child3 = this.transform.GetChild(20).GetChild(1);
    UIButtonHint uiButtonHint2 = child3.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    child3.GetComponent<UIButton>().m_BtnID1 = 99;
    child3.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_HiBtn2 = child3.GetChild(0);
    GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn2, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    child3.GetChild(3).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    child3.GetChild(4).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    Transform child4 = this.transform.GetChild(16);
    this.m_SortBtn = child4.GetComponent<UIButton>();
    this.m_SortBtn.m_BtnID1 = 8;
    this.m_SortBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_SortBtnText = child4.GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_SortBtnText.font = GUIManager.Instance.GetTTFFont();
    this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(343U);
    Transform child5 = this.transform.GetChild(17);
    this.m_AutoBtn = child5.GetComponent<UIButton>();
    this.m_AutoBtn.m_BtnID1 = 9;
    this.m_AutoBtn.m_Handler = (IUIButtonClickHandler) this;
    UnityEngine.UI.Text component1 = child5.GetChild(0).GetComponent<UnityEngine.UI.Text>();
    component1.font = GUIManager.Instance.GetTTFFont();
    component1.text = DataManager.Instance.mStringTable.GetStringByID(340U);
    this.m_SortPanel = this.transform.GetChild(19);
    for (int index = 0; index < 5; ++index)
    {
      Transform child6 = this.m_SortPanel.GetChild(index);
      UIButton component2 = child6.GetComponent<UIButton>();
      component2.m_BtnID1 = 3 + index;
      component2.m_Handler = (IUIButtonClickHandler) this;
      UnityEngine.UI.Text component3 = child6.GetChild(0).GetComponent<UnityEngine.UI.Text>();
      component3.font = GUIManager.Instance.GetTTFFont();
      component3.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[index]);
    }
    Transform child7 = this.transform.GetChild(20).GetChild(3);
    UnityEngine.UI.Text component4 = child7.GetChild(0).GetComponent<UnityEngine.UI.Text>();
    component4.font = GUIManager.Instance.GetTTFFont();
    component4.text = DataManager.Instance.mStringTable.GetStringByID(338U);
    UnityEngine.UI.Text component5 = child7.GetChild(1).GetComponent<UnityEngine.UI.Text>();
    component5.font = GUIManager.Instance.GetTTFFont();
    component5.text = DataManager.Instance.mStringTable.GetStringByID(339U);
    UnityEngine.UI.Text component6 = this.transform.GetChild(20).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    component6.font = GUIManager.Instance.GetTTFFont();
    component6.text = DataManager.Instance.mStringTable.GetStringByID(339U);
    this.m_SkillPanel = this.transform.GetChild(21);
    this.m_SkillHero = this.m_SkillPanel.GetChild(0).GetChild(1).GetComponent<UIHIBtn>();
    this.m_SkillBtn1 = this.m_SkillPanel.GetChild(1).GetChild(1).GetComponent<UIHIBtn>();
    this.m_SkillBtn2 = this.m_SkillPanel.GetChild(2).GetChild(1).GetComponent<UIHIBtn>();
    this.m_SkillBtn3 = this.m_SkillPanel.GetChild(3).GetChild(1).GetComponent<UIHIBtn>();
    this.m_SkillBtn4 = this.m_SkillPanel.GetChild(4).GetChild(1).GetComponent<UIHIBtn>();
    this.m_SkillEnhance = this.m_SkillPanel.GetChild(0).GetChild(2).GetComponent<Image>();
    ((MaskableGraphic) this.m_SkillEnhance).material = this.GetEnhanceMat();
    this.m_SkillEnhance.sprite = this.GetEnhanceIcon((byte) 1);
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_SkillHero).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_SkillBtn1).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_SkillBtn2).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_SkillBtn3).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_SkillBtn4).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    this.m_MaxPanelObject = 8;
    this.m_ItemHIBtns1 = new UIHIBtn[this.m_MaxPanelObject];
    this.m_ItemArmsTexts1 = new UnityEngine.UI.Text[this.m_MaxPanelObject];
    this.m_ItemNumTexts1 = new UnityEngine.UI.Text[this.m_MaxPanelObject];
    this.m_ItemHIBtns2 = new UIHIBtn[this.m_MaxPanelObject];
    this.m_ItemArmsIcons1 = new Image[this.m_MaxPanelObject];
    this.m_ItemArmsIcons2 = new Image[this.m_MaxPanelObject];
    this.m_ItemEnhanceIcons1 = new Image[this.m_MaxPanelObject];
    this.m_ItemEnhanceIcons2 = new Image[this.m_MaxPanelObject];
    this.m_ItemArmsTexts1 = new UnityEngine.UI.Text[this.m_MaxPanelObject];
    this.m_ItemArmsTexts2 = new UnityEngine.UI.Text[this.m_MaxPanelObject];
    this.m_ItemNumTexts1 = new UnityEngine.UI.Text[this.m_MaxPanelObject];
    this.m_ItemNumTexts2 = new UnityEngine.UI.Text[this.m_MaxPanelObject];
    this.m_Item1 = new Transform[this.m_MaxPanelObject];
    this.m_Item2 = new Transform[this.m_MaxPanelObject];
    this.m_ItemLines = new Transform[this.m_MaxPanelObject];
    this.m_MaskImage1s = new Transform[this.m_MaxPanelObject];
    this.m_MaskImage2s = new Transform[this.m_MaxPanelObject];
    this.m_SelectImage1s = new Transform[this.m_MaxPanelObject];
    this.m_SelectImage2s = new Transform[this.m_MaxPanelObject];
    this.m_LineItem = new Transform[this.m_MaxPanelObject];
    this.m_LastStrItem = new Transform[this.m_MaxPanelObject];
    this.m_ItemBtns1 = new UIButton[this.m_MaxPanelObject];
    this.m_ItemBtns2 = new UIButton[this.m_MaxPanelObject];
    this.m_FightIcons1 = new Transform[this.m_MaxPanelObject];
    this.m_FightIcons2 = new Transform[this.m_MaxPanelObject];
    this.m_ItemLordBgs = new Transform[this.m_MaxPanelObject];
    this.m_ItemLordFlash = new Transform[this.m_MaxPanelObject];
    this.m_HeroList_Soldier_Items = new List<HeroList_Soldier_Item>();
    this.m_HeroList_Soldier_Items2 = new List<HeroList_Soldier_Item>();
    this.m_HeroList_Soldier_Items3 = new List<HeroList_Soldier_Item>();
    this.m_HeroList_Soldier_Items4 = new List<HeroList_Soldier_Item>();
    this.m_HeroList_Soldier_Items5 = new List<HeroList_Soldier_Item>();
    this.m_FlashLords = new Image[3];
    this.m_FlashLords[2] = this.m_OKLoadFlash;
    this.m_HeightData = new List<float>();
    this.CheckSendBtn();
    this.UpdateScrollData();
    this.SortAllType();
    this.UpdateScrollPanel(true);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 6);
  }

  public override void OnClose()
  {
    this.DespawnPool();
    this.m_HeroList_Soldier_Items = (List<HeroList_Soldier_Item>) null;
    GUIManager.Instance.RemoveSpriteAsset("UIExpedition");
    GUIManager.Instance.RemoveSpriteAsset("UI_frame");
  }

  private void DespawnPool()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    for (int index = this.m_HeroList_Soldier_Items.Count - 1; index >= 0; --index)
      GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.despawn(this.m_HeroList_Soldier_Items[index]);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
  }

  private void Update()
  {
    if (this.bShowHint)
    {
      this.m_HintTick += Time.deltaTime;
      if ((double) this.m_HintTick > 0.30000001192092896)
      {
        this.m_SkillPanel.gameObject.SetActive(true);
        this.m_HintTick = 0.0f;
        this.bShowHint = false;
        this.bCanClick = false;
      }
    }
    this.m_ColorTick += Time.deltaTime;
    if ((double) this.m_ColorTick < 0.05000000074505806)
      return;
    this.m_ColorA += 0.1f;
    if ((double) this.m_ColorA >= 2.0)
      this.m_ColorA = 0.0f;
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.m_FlashLords[index] != (Object) null)
      {
        if ((double) this.m_ColorA > 1.0)
          ((Graphic) this.m_FlashLords[index]).color = new Color(1f, 1f, 1f, 2f - this.m_ColorA);
        else
          ((Graphic) this.m_FlashLords[index]).color = new Color(1f, 1f, 1f, this.m_ColorA);
      }
    }
    this.m_ColorTick = 0.0f;
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    this.bCanClick = true;
    this.bShowHint = true;
    this.m_HintTick = 0.0f;
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    this.m_SkillPanel.gameObject.SetActive(false);
    this.bShowHint = false;
    this.m_HintTick = 0.0f;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.m_ItemHIBtns1[panelObjectIdx] == (Object) null)
    {
      Transform child1 = item.transform.GetChild(0);
      this.m_Item1[panelObjectIdx] = child1;
      this.m_ItemBtns1[panelObjectIdx] = child1.GetComponent<UIButton>();
      this.m_ItemHIBtns1[panelObjectIdx] = child1.GetChild(0).GetComponent<UIHIBtn>();
      this.m_ItemArmsIcons1[panelObjectIdx] = child1.GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) this.m_ItemArmsIcons1[panelObjectIdx]).material = this.GetArmsMat();
      this.m_ItemEnhanceIcons1[panelObjectIdx] = child1.GetChild(2).GetComponent<Image>();
      ((MaskableGraphic) this.m_ItemEnhanceIcons1[panelObjectIdx]).material = this.GetEnhanceMat();
      this.m_ItemArmsTexts1[panelObjectIdx] = child1.GetChild(3).GetComponent<UnityEngine.UI.Text>();
      this.m_ItemNumTexts1[panelObjectIdx] = child1.GetChild(4).GetComponent<UnityEngine.UI.Text>();
      this.m_MaskImage1s[panelObjectIdx] = child1.GetChild(5);
      this.m_SelectImage1s[panelObjectIdx] = child1.GetChild(6);
      this.m_FightIcons1[panelObjectIdx] = child1.GetChild(7);
      this.m_ItemLordBgs[panelObjectIdx] = child1.GetChild(8);
      this.m_ItemLordFlash[panelObjectIdx] = child1.GetChild(9);
      ((MaskableGraphic) this.m_ItemLordBgs[panelObjectIdx].GetComponent<Image>()).material = this.GetArmsMat();
      this.m_ItemLordBgs[panelObjectIdx].GetComponent<Image>().sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_13");
      ((MaskableGraphic) this.m_ItemLordFlash[panelObjectIdx].GetComponent<Image>()).material = this.GetArmsMat();
      this.m_ItemLordFlash[panelObjectIdx].GetComponent<Image>().sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_12");
      Transform child2 = item.transform.GetChild(1);
      this.m_Item2[panelObjectIdx] = child2;
      this.m_ItemBtns2[panelObjectIdx] = child2.GetComponent<UIButton>();
      this.m_ItemHIBtns2[panelObjectIdx] = child2.GetChild(0).GetComponent<UIHIBtn>();
      this.m_ItemArmsIcons2[panelObjectIdx] = child2.GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) this.m_ItemArmsIcons2[panelObjectIdx]).material = this.GetArmsMat();
      this.m_ItemEnhanceIcons2[panelObjectIdx] = child2.GetChild(2).GetComponent<Image>();
      ((MaskableGraphic) this.m_ItemEnhanceIcons2[panelObjectIdx]).material = this.GetEnhanceMat();
      this.m_ItemArmsTexts2[panelObjectIdx] = child2.GetChild(3).GetComponent<UnityEngine.UI.Text>();
      this.m_ItemNumTexts2[panelObjectIdx] = child2.GetChild(4).GetComponent<UnityEngine.UI.Text>();
      this.m_MaskImage2s[panelObjectIdx] = child2.GetChild(5);
      this.m_SelectImage2s[panelObjectIdx] = child2.GetChild(6);
      this.m_FightIcons2[panelObjectIdx] = child2.GetChild(7);
      this.m_LineItem[panelObjectIdx] = item.transform.GetChild(2);
      this.m_LastStrItem[panelObjectIdx] = item.transform.GetChild(3);
    }
    int index1 = dataIdx * 2;
    int index2 = index1 + 1;
    List<HeroList_Soldier_Item> heroListSoldierItemList = this.m_HeroList_Soldier_Items;
    if (this.m_SortType == eSort.Sort1)
      heroListSoldierItemList = this.m_HeroList_Soldier_Items;
    else if (this.m_SortType == eSort.Sort2)
      heroListSoldierItemList = this.m_HeroList_Soldier_Items2;
    else if (this.m_SortType == eSort.Sort3)
      heroListSoldierItemList = this.m_HeroList_Soldier_Items3;
    else if (this.m_SortType == eSort.Sort4)
      heroListSoldierItemList = this.m_HeroList_Soldier_Items4;
    else if (this.m_SortType == eSort.Sort5)
      heroListSoldierItemList = this.m_HeroList_Soldier_Items5;
    if (index1 >= heroListSoldierItemList.Count)
      return;
    byte type = heroListSoldierItemList[index1].Type;
    if (type == (byte) 0)
    {
      this.m_ItemBtns1[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.m_ItemBtns1[panelObjectIdx].m_BtnID1 = 98;
      this.m_ItemBtns1[panelObjectIdx].m_BtnID2 = index1;
      this.m_Item1[panelObjectIdx].gameObject.SetActive(true);
      this.m_Item2[panelObjectIdx].gameObject.SetActive(true);
      this.m_LineItem[panelObjectIdx].gameObject.SetActive(false);
      this.m_LastStrItem[panelObjectIdx].gameObject.SetActive(false);
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_ItemHIBtns1[panelObjectIdx]).gameObject.transform, eHeroOrItem.Hero, heroListSoldierItemList[index1].HeroID, heroListSoldierItemList[index1].Enhance, (byte) 0);
      this.m_ItemArmsIcons1[panelObjectIdx].sprite = this.GetArmsIcon(heroListSoldierItemList[index1].Arms);
      this.m_ItemEnhanceIcons1[panelObjectIdx].sprite = this.GetEnhanceIcon(heroListSoldierItemList[index1].Enhance);
      this.m_ItemArmsTexts1[panelObjectIdx].text = this.GetArmsStr(heroListSoldierItemList[index1].Arms);
      this.m_ItemNumTexts1[panelObjectIdx].text = heroListSoldierItemList[index1].MaxNum.ToString();
      if (heroListSoldierItemList[index1].HeroID == (ushort) 0)
        this.m_Item1[panelObjectIdx].gameObject.SetActive(false);
      if (heroListSoldierItemList[index1].bSelect)
      {
        this.m_MaskImage1s[panelObjectIdx].gameObject.SetActive(true);
        this.m_SelectImage1s[panelObjectIdx].gameObject.SetActive(true);
      }
      else
      {
        this.m_MaskImage1s[panelObjectIdx].gameObject.SetActive(false);
        this.m_SelectImage1s[panelObjectIdx].gameObject.SetActive(false);
      }
      if (heroListSoldierItemList[index1].bIsFight)
        this.m_FightIcons1[panelObjectIdx].gameObject.SetActive(true);
      else
        this.m_FightIcons1[panelObjectIdx].gameObject.SetActive(false);
      if (this.LoadsDataIdx == dataIdx)
      {
        this.m_ItemLordBgs[panelObjectIdx].gameObject.SetActive(false);
        this.m_ItemLordFlash[panelObjectIdx].gameObject.SetActive(false);
        this.SetLordIcon(0, this.m_ItemLordFlash[panelObjectIdx].GetComponent<Image>());
      }
      else
      {
        this.m_ItemLordBgs[panelObjectIdx].gameObject.SetActive(false);
        this.m_ItemLordFlash[panelObjectIdx].gameObject.SetActive(false);
      }
      if (index2 >= heroListSoldierItemList.Count)
        return;
      this.m_ItemBtns2[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.m_ItemBtns2[panelObjectIdx].m_BtnID1 = 99;
      this.m_ItemBtns2[panelObjectIdx].m_BtnID2 = index2;
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_ItemHIBtns2[panelObjectIdx]).gameObject.transform, eHeroOrItem.Hero, heroListSoldierItemList[index2].HeroID, heroListSoldierItemList[index2].Enhance, (byte) 0);
      this.m_ItemArmsIcons2[panelObjectIdx].sprite = this.GetArmsIcon(heroListSoldierItemList[index2].Arms);
      this.m_ItemEnhanceIcons2[panelObjectIdx].sprite = this.GetEnhanceIcon(heroListSoldierItemList[index2].Enhance);
      this.m_ItemArmsTexts2[panelObjectIdx].text = this.GetArmsStr(heroListSoldierItemList[index2].Arms);
      this.m_ItemNumTexts2[panelObjectIdx].text = heroListSoldierItemList[index2].MaxNum.ToString();
      if (heroListSoldierItemList[index2].HeroID == (ushort) 0)
        this.m_Item2[panelObjectIdx].gameObject.SetActive(false);
      if (heroListSoldierItemList[index2].bSelect)
      {
        this.m_MaskImage2s[panelObjectIdx].gameObject.SetActive(true);
        this.m_SelectImage2s[panelObjectIdx].gameObject.SetActive(true);
      }
      else
      {
        this.m_MaskImage2s[panelObjectIdx].gameObject.SetActive(false);
        this.m_SelectImage2s[panelObjectIdx].gameObject.SetActive(false);
      }
      if (heroListSoldierItemList[index2].bIsFight)
        this.m_FightIcons2[panelObjectIdx].gameObject.SetActive(true);
      else
        this.m_FightIcons2[panelObjectIdx].gameObject.SetActive(false);
    }
    else
    {
      this.m_Item1[panelObjectIdx].gameObject.SetActive(false);
      this.m_Item2[panelObjectIdx].gameObject.SetActive(false);
      if (type == (byte) 1)
      {
        this.m_LineItem[panelObjectIdx].gameObject.SetActive(true);
      }
      else
      {
        if (type != (byte) 2)
          return;
        this.m_LastStrItem[panelObjectIdx].gameObject.SetActive(true);
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
      case 2:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu();
        break;
      case 3:
        this.OnSortClick(0);
        break;
      case 4:
        this.OnSortClick(1);
        break;
      case 5:
        this.OnSortClick(2);
        break;
      case 6:
        this.OnSortClick(3);
        break;
      case 7:
        this.OnSortClick(4);
        break;
      case 8:
        this.OpenSortPanel(!this.m_bShowSortPanel);
        break;
      case 9:
        Debug.Log((object) "AutonBtn");
        this.AutoSelect(this.MaxSelectHero);
        break;
      case 98:
        if (!this.bCanClick || this.m_HeroList_Soldier_Items[sender.m_BtnID2].bIsFight)
          break;
        int index1 = sender.m_BtnID2 / 2;
        if (this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect)
        {
          this.m_MaskImage1s[index1].gameObject.SetActive(false);
          this.m_SelectImage1s[index1].gameObject.SetActive(false);
          this.RemoveSelect(sender.m_BtnID2);
          this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = false;
        }
        else
        {
          this.m_MaskImage1s[index1].gameObject.SetActive(true);
          this.m_SelectImage1s[index1].gameObject.SetActive(true);
          this.AddSelect(sender.m_BtnID2);
          this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = true;
        }
        this.CheckSendBtn();
        break;
      case 99:
        if (!this.bCanClick || this.m_HeroList_Soldier_Items[sender.m_BtnID2].bIsFight)
          break;
        int index2 = sender.m_BtnID2 / 2;
        if (this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect)
        {
          this.m_MaskImage2s[index2].gameObject.SetActive(false);
          this.m_SelectImage2s[index2].gameObject.SetActive(false);
          this.RemoveSelect(sender.m_BtnID2);
          this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = false;
        }
        else
        {
          this.m_MaskImage2s[index2].gameObject.SetActive(true);
          this.m_SelectImage2s[index2].gameObject.SetActive(true);
          this.AddSelect(sender.m_BtnID2);
          this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = true;
        }
        this.CheckSendBtn();
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void SetLordIcon(int iconIdx, Image image)
  {
    if (iconIdx < 0 || iconIdx >= 3)
      return;
    this.m_FlashLords[iconIdx] = image;
  }

  private void SetSkillPanel()
  {
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_SkillHero).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0);
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_SkillBtn1).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0);
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_SkillBtn2).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0);
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_SkillBtn3).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0);
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_SkillBtn4).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0);
  }

  private void CheckSendBtn()
  {
    if (DataManager.Instance.LegionBattleHero.Count > 0)
      this.m_OKBtn.interactable = true;
    else
      this.m_OKBtn.interactable = false;
    int count = DataManager.Instance.LegionBattleHero.Count;
    ((Component) this.m_OKLoadBg).gameObject.SetActive(false);
    ((Component) this.m_OKLoadFlash).gameObject.SetActive(false);
    this.m_OKBtnText1Rt.anchoredPosition = new Vector2(0.0f, 2f);
    ((Component) this.m_OKBtnText2).gameObject.SetActive(false);
    for (int index = 0; index < count; ++index)
    {
      if ((int) DataManager.Instance.LegionBattleHero[index] == this.m_LordID)
      {
        ((Component) this.m_OKLoadBg).gameObject.SetActive(true);
        ((Component) this.m_OKLoadFlash).gameObject.SetActive(true);
        this.m_OKBtnText1Rt.anchoredPosition = new Vector2(27f, 2f);
        ((Component) this.m_OKBtnText2).gameObject.SetActive(true);
        break;
      }
    }
  }

  private void AutoSelect(int num)
  {
    int count = this.m_HeroList_Soldier_Items.Count;
    for (int index = 0; index < count; ++index)
      this.m_HeroList_Soldier_Items[index].bSelect = false;
    DataManager.Instance.LegionBattleHero.Clear();
    DataManager.Instance.LegionBattleSildoers = 0;
    for (int index = 0; index < num && index < count && (long) index < (long) this.NonFightHeroNum; ++index)
    {
      this.AddSelect(index);
      this.m_HeroList_Soldier_Items[index].bSelect = true;
    }
    this.CheckSendBtn();
    this.UpdateScrollPanel(false);
  }

  private void AddSelect(int idx)
  {
    DataManager.Instance.LegionBattleHero.Add(this.m_HeroList_Soldier_Items[idx].HeroID);
    DataManager.Instance.LegionBattleSildoers += (int) this.m_HeroList_Soldier_Items[idx].MaxNum;
    this.m_SoldierCountText.text = DataManager.Instance.LegionBattleSildoers.ToString();
    int count = DataManager.Instance.LegionBattleHero.Count;
    this.sb.Length = 0;
    this.sb.AppendFormat("{0}/{1}", (object) count, (object) this.MaxSelectHero);
    this.m_SoldierValueCount.text = this.sb.ToString();
  }

  private void RemoveSelect(int idx)
  {
    DataManager.Instance.LegionBattleHero.Remove(this.m_HeroList_Soldier_Items[idx].HeroID);
    DataManager.Instance.LegionBattleSildoers -= (int) this.m_HeroList_Soldier_Items[idx].MaxNum;
    this.m_SoldierCountText.text = DataManager.Instance.LegionBattleSildoers.ToString();
    int count = DataManager.Instance.LegionBattleHero.Count;
    this.sb.Length = 0;
    this.sb.AppendFormat("{0}/{1}", (object) count, (object) this.MaxSelectHero);
    this.m_SoldierValueCount.text = this.sb.ToString();
  }

  private void OpenSortPanel(bool bShow)
  {
    this.m_SortPanel.gameObject.SetActive(bShow);
    this.m_bShowSortPanel = bShow;
  }

  private void SortAllType()
  {
    this.m_HeroList_Soldier_Items.Sort(0, (int) DataManager.Instance.CurHeroDataCount, (IComparer<HeroList_Soldier_Item>) new UIHeroList_Soldier.SoldierComparer()
    {
      SortType = eSort.Sort1
    });
  }

  private void OnSortClick(int sortType)
  {
    switch (sortType)
    {
      case 0:
        this.m_SortType = eSort.Sort1;
        this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
        break;
      case 1:
        this.m_SortType = eSort.Sort2;
        this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
        break;
      case 2:
        this.m_SortType = eSort.Sort3;
        this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
        break;
      case 3:
        this.m_SortType = eSort.Sort4;
        this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
        break;
      case 4:
        this.m_SortType = eSort.Sort5;
        this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
        break;
    }
    this.UpdateScrollPanel(false);
    this.m_SortPanel.gameObject.SetActive(false);
    this.m_bShowSortPanel = false;
  }

  private void UpdateScrollData()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.FightHeroNum = DataManager.Instance.FightHeroCount;
    this.NonFightHeroNum = DataManager.Instance.CurHeroDataCount - this.FightHeroNum;
    this.DespawnPool();
    this.m_HeroList_Soldier_Items.Clear();
    this.m_HeroList_Soldier_Items2.Clear();
    this.m_HeroList_Soldier_Items3.Clear();
    this.m_HeroList_Soldier_Items4.Clear();
    this.m_HeroList_Soldier_Items5.Clear();
    this.m_HeightData.Clear();
    this.DataCount = (int) DataManager.Instance.CurHeroDataCount % 2 != 0 ? (int) DataManager.Instance.CurHeroDataCount + 1 + 4 : (int) DataManager.Instance.CurHeroDataCount + 4;
    int num1 = this.NonFightHeroNum % 2U != 0U ? (int) this.NonFightHeroNum + 1 : (int) this.NonFightHeroNum;
    for (int index = 0; index < num1; ++index)
    {
      HeroList_Soldier_Item heroListSoldierItem = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
      this.m_HeroList_Soldier_Items.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items2.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items3.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items4.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items5.Add(heroListSoldierItem);
      heroListSoldierItem.Arms = (byte) 0;
      CurHeroData curHeroData = DataManager.Instance.curHeroData[DataManager.Instance.NonFightHeroID[index]];
      heroListSoldierItem.Enhance = curHeroData.Enhance;
      heroListSoldierItem.HeroID = curHeroData.ID;
      heroListSoldierItem.MaxNum = DataManager.Instance.RankSoldiers[(int) curHeroData.Enhance];
      heroListSoldierItem.bIsLords = false;
      heroListSoldierItem.bSelect = false;
      heroListSoldierItem.bIsFight = false;
      heroListSoldierItem.Type = (byte) 0;
      if (index % 2 == 0)
        this.m_HeightData.Add(80f);
    }
    for (int index = 0; index < 2; ++index)
    {
      HeroList_Soldier_Item heroListSoldierItem = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
      this.m_HeroList_Soldier_Items.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items2.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items3.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items4.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items5.Add(heroListSoldierItem);
      heroListSoldierItem.Type = (byte) 1;
      if (index % 2 == 0)
        this.m_HeightData.Add(40f);
    }
    int num2 = this.FightHeroNum % 2U != 0U ? (int) this.FightHeroNum + 1 : (int) this.FightHeroNum;
    for (int index = 0; index < num2; ++index)
    {
      HeroList_Soldier_Item heroListSoldierItem = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
      this.m_HeroList_Soldier_Items.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items2.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items3.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items4.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items5.Add(heroListSoldierItem);
      heroListSoldierItem.Arms = (byte) 0;
      CurHeroData curHeroData = DataManager.Instance.curHeroData[DataManager.Instance.FightHeroID[index]];
      heroListSoldierItem.Enhance = curHeroData.Enhance;
      heroListSoldierItem.HeroID = curHeroData.ID;
      heroListSoldierItem.MaxNum = DataManager.Instance.RankSoldiers[(int) curHeroData.Enhance];
      heroListSoldierItem.bIsLords = false;
      heroListSoldierItem.bSelect = false;
      heroListSoldierItem.bIsFight = true;
      heroListSoldierItem.Type = (byte) 0;
      if (index % 2 == 0)
        this.m_HeightData.Add(80f);
    }
    for (int index = 0; index < 2; ++index)
    {
      HeroList_Soldier_Item heroListSoldierItem = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
      this.m_HeroList_Soldier_Items.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items2.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items3.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items4.Add(heroListSoldierItem);
      this.m_HeroList_Soldier_Items5.Add(heroListSoldierItem);
      heroListSoldierItem.Type = (byte) 2;
      if (index % 2 == 0)
        this.m_HeightData.Add(60f);
    }
  }

  private void UpdateScrollPanel(bool bInit)
  {
    if (bInit)
      this.m_ScrollPanel.IntiScrollPanel(442.7f, 10f, 4f, this.m_HeightData, this.m_MaxPanelObject, (IUpDateScrollPanel) this);
    else
      this.m_ScrollPanel.AddNewDataHeight(this.m_HeightData);
  }

  private string GetArmsStr(byte arms)
  {
    return DataManager.Instance.mStringTable.GetStringByID(3841U + (uint) arms);
  }

  private Sprite GetArmsIcon(byte arms)
  {
    switch (arms)
    {
      case 0:
        return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_a");
      case 1:
        return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_b");
      case 2:
        return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_c");
      case 3:
        return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_d");
      default:
        return (Sprite) null;
    }
  }

  private Material GetArmsMat() => GUIManager.Instance.LoadMaterial("UIExpedition", "UI_legion_m");

  private Sprite GetEnhanceIcon(byte Enhance)
  {
    this.sb.Length = 0;
    this.sb.AppendFormat("hf{0}", (object) ((int) Enhance + 100));
    return GUIManager.Instance.LoadSprite("UI_frame", this.sb.ToString());
  }

  private Material GetEnhanceMat() => GUIManager.Instance.GetFrameMaterial();

  public class SoldierComparer : IComparer<HeroList_Soldier_Item>
  {
    public eSort SortType;
    private UIHeroList_Soldier heroList_Soldier = GUIManager.Instance.FindMenu(EGUIWindow.UI_HeroList_Soldier) as UIHeroList_Soldier;

    public int Compare(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
    {
      if (this.SortType == eSort.Sort1)
        return this.CompareType1(x, y);
      if (this.SortType == eSort.Sort2)
        return this.CompareType2(x, y);
      return this.SortType == eSort.Sort3 ? this.CompareType3(x, y) : this.CompareType4(x, y);
    }

    public int CompareType1(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
    {
      return x.Arms == (byte) 0 && (int) x.MaxNum < (int) y.MaxNum ? 1 : -1;
    }

    public int CompareType2(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
    {
      return x.Arms == (byte) 0 && (int) x.MaxNum > (int) y.MaxNum ? 1 : -1;
    }

    public int CompareType3(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
    {
      return x.Arms == (byte) 0 && (int) x.MaxNum > (int) y.MaxNum ? 1 : -1;
    }

    public int CompareType4(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
    {
      return x.Arms == (byte) 0 && (int) x.MaxNum > (int) y.MaxNum ? 1 : -1;
    }
  }
}
