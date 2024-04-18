// Decompiled with JetBrains decompiler
// Type: UILegBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UILegBattle : GUIWindow, IUIButtonClickHandler
{
  private int MaxHudMsg;
  private Font TTF;
  private UISpritesArray m_SpArray;
  private Transform alertBlock;
  private Image alertBlock_T;
  private Image alertBlock_B;
  private Image alertBlock_L;
  private Image alertBlock_R;
  private UIText m_AttackName;
  private UIText m_AttackValue;
  private UIText m_DefendName;
  private UIText m_DefendValue;
  private UIText m_AttackMoraleValue;
  private UIText m_DefendMoraleValue;
  private UIText m_ClearPanelAttackName;
  private UIText m_ClearPanelDefendName;
  private UIText m_ClearPanelAttackValue;
  private UIText m_ClearPanelDefendValue;
  private UIText m_ClearPanelTitle;
  private UIText m_ClearPanelResult;
  private Shadow m_ClearPanelResultShadow;
  private Outline m_ClearPanelResultOutline;
  private Image m_AttackSlider;
  private Image m_DefendSlider;
  private Image m_WallSlider;
  private Image m_ClearPanelAttackImage;
  private Image m_ClearPanelDefendImage;
  private Image m_ClearPanelWinOrLose;
  private Image m_ClearPanelVS;
  private Image[] m_FlashImage = new Image[2];
  private Transform m_RotationTf;
  private Transform m_PausePanel;
  private Transform m_BattleClearPanel;
  private Transform m_BattlePanel;
  private Transform m_BattlePanel_Top;
  private Transform m_BattlePanel_Down;
  private Transform m_SimulationPanel;
  private Transform m_SimulationExitPanel;
  private Transform m_IPhoneXPanel;
  private RectTransform m_SimulationPanel_Left;
  private RectTransform m_SimulationPanel_Right;
  private RectTransform m_AttackSlider_Rt;
  private RectTransform m_DefendSlider_Rt;
  private RectTransform m_VSImage_Rt;
  private Transform m_ClearPanelTitleTf;
  private Transform m_Hint;
  private Image m_HintIcon;
  private UIText m_HintText1;
  private UIText m_HintText2;
  private RectTransform m_HintRect;
  private UIText m_CenterMsgText;
  private Transform m_CenterMsg;
  private Image m_CenterMsgBg;
  private Image m_CenterMsgIcon;
  private sHudMsg[] m_HudArray;
  private List<sHudMsg> m_HudWorkArray_L;
  private List<sHudMsg> m_HudWorkArray_R;
  private SimulationAtkObj m_SimulationAtkObj = new SimulationAtkObj();
  private SimulationDefObj m_SimulationDefObj = new SimulationDefObj();
  private float m_HudHeight = 32f;
  private Vector2 mHudBeginPos_L;
  private Vector2 mHudBeginPos_R;
  private float m_TickTime = 0.1f;
  private float m_TickTime_Info = 1f;
  private float m_TickFlash = 0.03f;
  private float[] m_FlashColorA = new float[3]
  {
    0.5f,
    0.5f,
    0.5f
  };
  private float[] m_FlashColorDelta = new float[3]
  {
    0.03f,
    0.01f,
    0.03f
  };
  private float m_CenterTick = 0.1f;
  private float m_CenterMsgColorA = 1f;
  private bool bCountDownCenMsg;
  private float m_AnimTick = 1f;
  private CString[] m_Str;
  private CString[] m_HudStr;
  private bool IsPlayerAttack;
  private bool IsSimulation;
  private eLegBattleSimulationType m_SimulationType;
  private bool playAnim;

  public override void OnOpen(int arg1, int arg2)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (GUIManager.Instance.IsArabic)
    {
      this.mHudBeginPos_L = new Vector2(250f, -200f);
      this.mHudBeginPos_R = new Vector2(-250f, -200f);
    }
    else
    {
      this.mHudBeginPos_L = new Vector2(-250f, -200f);
      this.mHudBeginPos_R = new Vector2(250f, -200f);
    }
    this.TTF = GUIManager.Instance.GetTTFFont();
    this.IsPlayerAttack = arg1 == 0;
    this.IsSimulation = arg2 != 0;
    this.m_SimulationType = (eLegBattleSimulationType) arg2;
    this.alertBlock = this.transform.GetChild(0);
    this.alertBlock_T = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    this.alertBlock_B = this.transform.GetChild(0).GetChild(1).GetComponent<Image>();
    this.alertBlock_R = this.transform.GetChild(0).GetChild(2).GetComponent<Image>();
    this.alertBlock_L = this.transform.GetChild(0).GetChild(3).GetComponent<Image>();
    this.m_BattlePanel = this.transform.GetChild(1);
    this.MaxHudMsg = this.m_BattlePanel.GetChild(6).childCount;
    this.m_HudArray = new sHudMsg[this.MaxHudMsg];
    this.m_CenterMsg = this.m_BattlePanel.GetChild(7).GetChild(0);
    this.m_CenterMsgBg = this.m_CenterMsg.GetComponent<Image>();
    this.m_CenterMsgText = this.m_CenterMsg.GetChild(0).GetComponent<UIText>();
    this.m_CenterMsgIcon = this.m_CenterMsg.GetChild(1).GetComponent<Image>();
    this.m_CenterMsgText.font = this.TTF;
    this.m_Str = new CString[9];
    this.m_HudStr = new CString[this.MaxHudMsg];
    this.m_HudWorkArray_L = new List<sHudMsg>();
    this.m_HudWorkArray_R = new List<sHudMsg>();
    for (int index = 0; index < this.MaxHudMsg; ++index)
    {
      this.m_HudArray[index] = new sHudMsg();
      this.m_HudArray[index].Trnas = this.m_BattlePanel.GetChild(6).GetChild(index);
      this.m_HudArray[index].Msg = this.m_BattlePanel.GetChild(6).GetChild(index).GetChild(0).GetComponent<UIText>();
      this.m_HudArray[index].Msg.font = this.TTF;
      this.m_HudArray[index].Bg = this.m_BattlePanel.GetChild(6).GetChild(index).GetComponent<Image>();
      this.m_HudArray[index].Idx = index;
      this.m_HudStr[index] = StringManager.Instance.SpawnString(40);
    }
    this.m_SpArray = this.transform.GetComponent<UISpritesArray>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
    {
      this.m_BattlePanel.GetChild(2).GetChild(0).GetComponent<Image>().sprite = this.m_SpArray.GetSprite(8);
      this.m_BattlePanel.GetChild(2).GetChild(1).GetComponent<Image>().sprite = this.m_SpArray.GetSprite(9);
    }
    this.m_FlashImage[0] = this.m_BattlePanel.GetChild(2).GetChild(1).GetComponent<Image>();
    this.m_Hint = this.m_BattlePanel.GetChild(3);
    this.m_HintRect = this.m_Hint.GetComponent<RectTransform>();
    this.m_HintRect.anchorMax = Vector2.zero;
    this.m_HintRect.anchorMin = Vector2.zero;
    this.m_HintRect.pivot = new Vector2(0.5f, 0.5f);
    this.m_HintIcon = this.m_Hint.GetChild(0).GetComponent<Image>();
    this.m_HintText1 = this.m_Hint.GetChild(1).GetComponent<UIText>();
    this.m_HintText1.font = this.TTF;
    this.m_HintText2 = this.m_Hint.GetChild(2).GetComponent<UIText>();
    this.m_HintText2.font = this.TTF;
    this.m_AttackName = this.m_BattlePanel.GetChild(0).GetChild(7).GetComponent<UIText>();
    this.m_AttackName.font = this.TTF;
    this.m_AttackValue = this.m_BattlePanel.GetChild(0).GetChild(9).GetComponent<UIText>();
    this.m_AttackValue.font = this.TTF;
    this.m_AttackMoraleValue = this.m_BattlePanel.GetChild(0).GetChild(8).GetComponent<UIText>();
    this.m_AttackMoraleValue.font = this.TTF;
    this.m_AttackSlider = this.m_BattlePanel.GetChild(0).GetChild(3).GetComponent<Image>();
    this.m_DefendName = this.m_BattlePanel.GetChild(1).GetChild(7).GetComponent<UIText>();
    this.m_DefendName.font = this.TTF;
    this.m_DefendValue = this.m_BattlePanel.GetChild(1).GetChild(9).GetComponent<UIText>();
    this.m_DefendValue.font = this.TTF;
    this.m_DefendMoraleValue = this.m_BattlePanel.GetChild(1).GetChild(8).GetComponent<UIText>();
    this.m_DefendMoraleValue.font = this.TTF;
    this.m_DefendSlider = this.m_BattlePanel.GetChild(1).GetChild(3).GetComponent<Image>();
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      Image component = this.m_BattlePanel.GetChild(4).GetComponent<Image>();
      if ((bool) (UnityEngine.Object) component)
        ((Behaviour) component).enabled = false;
    }
    UIButton component1 = this.m_BattlePanel.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 0;
    UIButton component2 = this.m_BattlePanel.GetChild(5).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 3;
    this.m_PausePanel = this.transform.GetChild(2);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.m_PausePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_PausePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    UIButton component3 = this.m_PausePanel.GetChild(0).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 1;
    UIText component4 = this.m_PausePanel.GetChild(0).GetChild(0).GetComponent<UIText>();
    component4.font = this.TTF;
    component4.text = DataManager.Instance.mStringTable.GetStringByID(241U);
    UIButton component5 = this.m_PausePanel.GetChild(1).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    UIText component6 = this.m_PausePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
    component6.font = this.TTF;
    component6.text = DataManager.Instance.mStringTable.GetStringByID(240U);
    component5.m_BtnID1 = 2;
    if (GUIManager.Instance.IsArabic)
      this.m_PausePanel.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_BattleClearPanel = this.transform.GetChild(3);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform child1 = (RectTransform) this.m_BattleClearPanel.GetChild(0);
      child1.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, child1.offsetMin.y);
      child1.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, child1.offsetMax.y);
      RectTransform child2 = (RectTransform) this.m_BattleClearPanel.GetChild(1);
      child2.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, child2.offsetMin.y);
      child2.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, child2.offsetMax.y);
      RectTransform child3 = (RectTransform) this.m_BattleClearPanel.GetChild(2);
      child3.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, child3.offsetMin.y);
      child3.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, child3.offsetMax.y);
    }
    this.m_ClearPanelAttackImage = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetComponent<Image>();
    this.m_ClearPanelAttackName = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.m_ClearPanelAttackName.font = this.TTF;
    UIText component7 = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
    component7.font = this.TTF;
    component7.text = DataManager.Instance.mStringTable.GetStringByID(580U);
    this.m_ClearPanelAttackValue = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(2).GetComponent<UIText>();
    this.m_ClearPanelAttackValue.font = this.TTF;
    this.m_ClearPanelDefendImage = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetComponent<Image>();
    this.m_ClearPanelDefendName = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetChild(0).GetComponent<UIText>();
    this.m_ClearPanelDefendName.font = this.TTF;
    UIText component8 = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetChild(1).GetComponent<UIText>();
    component8.font = this.TTF;
    component8.text = DataManager.Instance.mStringTable.GetStringByID(580U);
    this.m_ClearPanelDefendValue = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetChild(2).GetComponent<UIText>();
    this.m_ClearPanelDefendValue.font = this.TTF;
    this.m_ClearPanelVS = this.m_BattleClearPanel.GetChild(3).GetChild(7).GetChild(0).GetComponent<Image>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
    {
      this.m_BattleClearPanel.GetChild(3).GetChild(7).GetComponent<Image>().sprite = this.m_SpArray.GetSprite(8);
      this.m_BattleClearPanel.GetChild(3).GetChild(7).GetChild(0).GetComponent<Image>().sprite = this.m_SpArray.GetSprite(9);
    }
    this.m_FlashImage[1] = this.m_ClearPanelVS;
    this.m_ClearPanelTitleTf = this.m_BattleClearPanel.GetChild(4).GetChild(0);
    this.m_ClearPanelTitle = this.m_ClearPanelTitleTf.GetChild(0).GetComponent<UIText>();
    this.m_ClearPanelTitle.font = this.TTF;
    this.m_ClearPanelWinOrLose = this.m_BattleClearPanel.GetChild(4).GetChild(3).GetComponent<Image>();
    this.m_ClearPanelResult = this.m_BattleClearPanel.GetChild(4).GetChild(4).GetComponent<UIText>();
    this.m_ClearPanelResult.font = this.TTF;
    this.m_ClearPanelResultShadow = this.m_BattleClearPanel.GetChild(4).GetChild(4).GetComponent<Shadow>();
    this.m_ClearPanelResultOutline = this.m_BattleClearPanel.GetChild(4).GetChild(4).GetComponent<Outline>();
    this.m_RotationTf = ((Component) this.m_BattleClearPanel.GetChild(4).GetChild(3).GetComponent<Image>()).transform;
    UIButton component9 = this.m_BattleClearPanel.GetChild(4).GetChild(1).GetComponent<UIButton>();
    component9.m_Handler = (IUIButtonClickHandler) this;
    component9.m_BtnID1 = 4;
    UIButton component10 = this.m_BattleClearPanel.GetChild(4).GetChild(2).GetComponent<UIButton>();
    component10.m_Handler = (IUIButtonClickHandler) this;
    component10.m_BtnID1 = 5;
    this.m_SimulationPanel = this.transform.GetChild(4);
    this.m_SimulationPanel_Left = (RectTransform) this.transform.GetChild(4).GetChild(0);
    this.m_SimulationPanel_Right = (RectTransform) this.transform.GetChild(4).GetChild(1);
    this.m_AttackSlider_Rt = (RectTransform) this.transform.GetChild(1).GetChild(0);
    this.m_DefendSlider_Rt = (RectTransform) this.transform.GetChild(1).GetChild(1);
    this.m_VSImage_Rt = (RectTransform) this.transform.GetChild(1).GetChild(2);
    this.m_SimulationAtkObj.Init();
    this.m_SimulationDefObj.Init();
    this.m_SimulationAtkObj.SelectArmy = this.transform.GetChild(4).GetChild(0).GetChild(2).GetComponent<UIText>();
    this.m_SimulationAtkObj.SelectArmy.font = this.TTF;
    for (int index = 0; index < 6; ++index)
    {
      Transform child = this.transform.GetChild(4).GetChild(0).GetChild(3 + index);
      this.m_SimulationAtkObj.Btn[index] = child.GetComponent<UIButton>();
      this.m_SimulationAtkObj.Btn[index].m_Handler = (IUIButtonClickHandler) this;
      this.m_SimulationAtkObj.Btn[index].m_BtnID1 = 10 + index;
      this.m_SimulationAtkObj.BtnText[index] = child.GetChild(1).GetComponent<UIText>();
      this.m_SimulationAtkObj.BtnText[index].font = this.TTF;
      this.m_SimulationAtkObj.BtnText[index].text = DataManager.Instance.mStringTable.GetStringByID((uint) (9778 + index));
      this.m_SimulationAtkObj.SelectImage[index] = child.GetChild(2).GetComponent<Image>();
    }
    this.m_SimulationDefObj.SelectArmy = this.transform.GetChild(4).GetChild(1).GetChild(2).GetComponent<UIText>();
    this.m_SimulationDefObj.SelectArmy.font = this.TTF;
    for (int index = 0; index < 3; ++index)
    {
      Transform child = this.transform.GetChild(4).GetChild(1).GetChild(3 + index);
      this.m_SimulationDefObj.Btn[index] = child.GetComponent<UIButton>();
      this.m_SimulationDefObj.Btn[index].m_Handler = (IUIButtonClickHandler) this;
      this.m_SimulationDefObj.Btn[index].m_BtnID1 = 20 + index;
      this.m_SimulationDefObj.BtnText[index] = child.GetChild(1).GetComponent<UIText>();
      this.m_SimulationDefObj.BtnText[index].font = this.TTF;
      this.m_SimulationDefObj.BtnText[index].text = DataManager.Instance.mStringTable.GetStringByID((uint) (9791 - index));
      this.m_SimulationDefObj.SelectImage[index] = child.GetChild(2).GetComponent<Image>();
    }
    UIButton component11 = this.m_SimulationPanel.GetChild(2).GetComponent<UIButton>();
    component11.m_Handler = (IUIButtonClickHandler) this;
    component11.m_BtnID1 = 30;
    UIButton component12 = this.m_SimulationPanel.GetChild(3).GetChild(0).GetComponent<UIButton>();
    component12.m_Handler = (IUIButtonClickHandler) this;
    component12.m_BtnID1 = 35;
    Image component13 = this.m_SimulationPanel.GetChild(3).GetComponent<Image>();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component13)
      ((Behaviour) component13).enabled = false;
    if ((bool) (UnityEngine.Object) menu)
    {
      component12.image.sprite = menu.LoadSprite("UI_main_close");
      ((MaskableGraphic) component12.image).material = menu.LoadMaterial();
    }
    UIButton component14 = this.m_SimulationPanel.GetChild(4).GetComponent<UIButton>();
    component14.m_Handler = (IUIButtonClickHandler) this;
    component14.m_BtnID1 = 36;
    this.m_SimulationExitPanel = this.transform.GetChild(5);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.m_SimulationExitPanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_SimulationExitPanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    UIButton component15 = this.m_SimulationExitPanel.GetChild(1).GetComponent<UIButton>();
    component15.m_Handler = (IUIButtonClickHandler) this;
    component15.m_BtnID1 = 31;
    UIText component16 = this.m_SimulationExitPanel.GetChild(1).GetChild(0).GetComponent<UIText>();
    component16.font = this.TTF;
    component16.text = DataManager.Instance.mStringTable.GetStringByID(241U);
    UIButton component17 = this.m_SimulationExitPanel.GetChild(2).GetComponent<UIButton>();
    component17.m_Handler = (IUIButtonClickHandler) this;
    component17.m_BtnID1 = 32;
    UIText component18 = this.m_SimulationExitPanel.GetChild(2).GetChild(0).GetComponent<UIText>();
    component18.font = this.TTF;
    component18.text = DataManager.Instance.mStringTable.GetStringByID(9786U);
    UIButton component19 = this.m_SimulationExitPanel.GetChild(3).GetComponent<UIButton>();
    component19.m_Handler = (IUIButtonClickHandler) this;
    component19.m_BtnID1 = 33;
    if (GUIManager.Instance.IsArabic)
      this.m_SimulationExitPanel.GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
    UIText component20 = this.m_SimulationExitPanel.GetChild(3).GetChild(0).GetComponent<UIText>();
    component20.font = this.TTF;
    component20.text = DataManager.Instance.mStringTable.GetStringByID(240U);
    UIButton component21 = this.m_SimulationExitPanel.GetChild(4).GetComponent<UIButton>();
    component21.m_Handler = (IUIButtonClickHandler) this;
    component21.m_BtnID1 = 34;
    UIText component22 = this.m_SimulationExitPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
    component22.font = this.TTF;
    component22.text = DataManager.Instance.mStringTable.GetStringByID(9785U);
    this.m_IPhoneXPanel = this.transform.GetChild(6);
    if (GUIManager.Instance.bOpenOnIPhoneX)
      this.m_IPhoneXPanel.gameObject.SetActive(true);
    if (this.IsPlayerAttack)
    {
      this.m_AttackSlider.sprite = this.m_SpArray.GetSprite(0);
      this.m_DefendSlider.sprite = this.m_SpArray.GetSprite(1);
      ((Graphic) this.m_AttackName).color = new Color(0.341f, 0.854f, 1f);
      ((Graphic) this.m_DefendName).color = new Color(1f, 0.29f, 0.458f);
      this.m_ClearPanelAttackImage.sprite = this.m_SpArray.GetSprite(2);
      this.m_ClearPanelDefendImage.sprite = this.m_SpArray.GetSprite(3);
    }
    else
    {
      this.m_AttackSlider.sprite = this.m_SpArray.GetSprite(1);
      this.m_DefendSlider.sprite = this.m_SpArray.GetSprite(0);
      ((Graphic) this.m_DefendName).color = new Color(0.341f, 0.854f, 1f);
      ((Graphic) this.m_AttackName).color = new Color(1f, 0.29f, 0.458f);
      this.m_ClearPanelAttackImage.sprite = this.m_SpArray.GetSprite(3);
      this.m_ClearPanelDefendImage.sprite = this.m_SpArray.GetSprite(2);
    }
    if (this.IsSimulation)
    {
      this.SetAutoSelect();
      if (this.m_SimulationType == eLegBattleSimulationType.eReplay)
      {
        this.SetSimulationName();
        this.OpenmBattlePanel();
      }
      else if (this.m_SimulationType == eLegBattleSimulationType.eSimulation || this.m_SimulationType == eLegBattleSimulationType.eFirstSimulation)
        this.OpenSimulationPanel();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
    GUIManager.Instance.BattleOpenChatBox();
    GUIManager.Instance.CheckBattleAttackState();
    if (!GUIManager.Instance.IsArabic)
      return;
    for (int index = 0; index < 3; ++index)
    {
      RectTransform component23 = this.m_BattlePanel.GetChild(index).GetComponent<RectTransform>();
      Vector3 localScale = ((Transform) component23).localScale;
      localScale.x *= -1f;
      ((Transform) component23).localScale = localScale;
    }
    this.m_BattlePanel.GetChild(0).GetChild(7).GetComponent<UIText>().alignment = TextAnchor.MiddleLeft;
    this.m_BattlePanel.GetChild(0).GetChild(9).GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
    for (int index = 0; index < 3; ++index)
    {
      RectTransform component24 = this.m_BattlePanel.GetChild(0).GetChild(7 + index).GetComponent<RectTransform>();
      Quaternion rotation = ((Transform) component24).rotation with
      {
        y = 180f
      };
      ((Transform) component24).rotation = rotation;
    }
    RectTransform component25 = this.m_BattleClearPanel.GetChild(3).GetComponent<RectTransform>();
    Vector3 localScale1 = ((Transform) component25).localScale;
    localScale1.x *= -1f;
    ((Transform) component25).localScale = localScale1;
    for (int index = 0; index < 3; ++index)
    {
      RectTransform component26 = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(index).GetComponent<RectTransform>();
      Quaternion rotation = ((Transform) component26).rotation with
      {
        y = 180f
      };
      ((Transform) component26).rotation = rotation;
    }
    RectTransform component27 = this.transform.GetChild(4).GetComponent<RectTransform>();
    Vector3 localScale2 = ((Transform) component27).localScale;
    localScale2.x *= -1f;
    ((Transform) component27).localScale = localScale2;
    UIText component28 = this.transform.GetChild(4).GetChild(0).GetChild(2).GetComponent<UIText>();
    Quaternion rotation1 = ((Transform) ((Graphic) component28).rectTransform).rotation with
    {
      y = 180f
    };
    ((Transform) ((Graphic) component28).rectTransform).rotation = rotation1;
    component28.alignment = TextAnchor.MiddleLeft;
    UIText component29 = this.transform.GetChild(4).GetChild(1).GetChild(2).GetComponent<UIText>();
    rotation1 = ((Transform) ((Graphic) component29).rectTransform).rotation with
    {
      y = 180f
    };
    ((Transform) ((Graphic) component29).rectTransform).rotation = rotation1;
    component29.alignment = TextAnchor.MiddleRight;
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.m_Str.Length; ++index)
    {
      if (this.m_Str[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
      this.m_Str[index] = (CString) null;
    }
    this.m_Str = (CString[]) null;
    for (int index = 0; index < this.m_HudStr.Length; ++index)
    {
      if (this.m_HudStr[index] != null)
        StringManager.Instance.DeSpawnString(this.m_HudStr[index]);
      this.m_HudStr[index] = (CString) null;
    }
    this.m_HudStr = (CString[]) null;
    if (this.m_SimulationAtkObj.CStr != null)
    {
      StringManager.Instance.DeSpawnString(this.m_SimulationAtkObj.CStr);
      this.m_SimulationAtkObj.CStr = (CString) null;
    }
    if (this.m_SimulationDefObj.CStr != null)
    {
      StringManager.Instance.DeSpawnString(this.m_SimulationDefObj.CStr);
      this.m_SimulationDefObj.CStr = (CString) null;
    }
    Time.timeScale = 1f;
    GUIManager.Instance.BattleCloseChatBox();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        if (this.m_Str[5] == null)
          this.m_Str[5] = StringManager.Instance.SpawnString();
        else
          this.m_Str[5].ClearString();
        if (this.m_Str[6] == null)
          this.m_Str[6] = StringManager.Instance.SpawnString();
        else
          this.m_Str[6].ClearString();
        if (DataManager.Instance.AllianceTag_War[0].Length != 0)
        {
          StringManager.Instance.StringToFormat(DataManager.Instance.AllianceTag_War[0]);
          StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[0]);
          this.m_Str[5].AppendFormat("[{0}] {1}");
        }
        else
        {
          StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[0]);
          this.m_Str[5].AppendFormat("{0}");
        }
        if (DataManager.Instance.AllianceTag_War[1].Length != 0)
        {
          StringManager.Instance.StringToFormat(DataManager.Instance.AllianceTag_War[1]);
          StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[1]);
          this.m_Str[6].AppendFormat("[{0}] {1}");
        }
        else
        {
          StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[1]);
          this.m_Str[6].AppendFormat("{0}");
        }
        if (!this.IsSimulation)
        {
          this.m_AttackName.text = this.m_Str[5].ToString();
          this.m_DefendName.text = this.m_Str[6].ToString();
        }
        for (int sliderType = 0; sliderType < 2; ++sliderType)
          this.SetSlider(sliderType, (long) DataManager.Instance.WarMorale[sliderType], 100L);
        for (int type = 0; type < 2; ++type)
          this.SetArmyNum(type, DataManager.Instance.NowValue_War[type]);
        break;
      case 1:
        if (arg2 >= 2 || arg2 < 0)
          break;
        this.SetSlider(arg2, (long) DataManager.Instance.WarMorale[arg2], 100L);
        this.SetArmyNum(arg2, DataManager.Instance.NowValue_War[arg2]);
        break;
      case 2:
        this.AddCenterMsg((ushort) arg2, (byte) 0);
        break;
      case 3:
        this.SetCountDown();
        break;
      case 4:
        this.OpenClearPanel(arg2);
        if (this.IsSimulation)
          this.OpenSimulationExitPanelWithoutBg();
        GUIManager.Instance.HideChatBox();
        if (arg2 == 0 || arg2 == 1)
        {
          AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionVictory, (byte) 0);
          break;
        }
        AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionDefeat, (byte) 0);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.transform.GetChild(1).GetChild(0).GetChild(7).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.transform.GetChild(1).GetChild(0).GetChild(8).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.transform.GetChild(1).GetChild(0).GetChild(9).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.transform.GetChild(1).GetChild(1).GetChild(7).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.transform.GetChild(1).GetChild(1).GetChild(8).GetComponent<UIText>();
    if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.transform.GetChild(1).GetChild(1).GetChild(9).GetComponent<UIText>();
    if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.transform.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.transform.GetChild(1).GetChild(6).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.transform.GetChild(1).GetChild(6).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.transform.GetChild(1).GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.transform.GetChild(1).GetChild(6).GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UIText component13 = this.transform.GetChild(1).GetChild(6).GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UIText component14 = this.transform.GetChild(1).GetChild(6).GetChild(5).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UIText component15 = this.transform.GetChild(1).GetChild(7).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UIText component16 = this.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    UIText component17 = this.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component17 != (UnityEngine.Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UIText component18 = this.transform.GetChild(3).GetChild(3).GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component18 != (UnityEngine.Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UIText component19 = this.transform.GetChild(3).GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component19 != (UnityEngine.Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    UIText component20 = this.transform.GetChild(3).GetChild(3).GetChild(3).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component20 != (UnityEngine.Object) null && ((Behaviour) component20).enabled)
    {
      ((Behaviour) component20).enabled = false;
      ((Behaviour) component20).enabled = true;
    }
    UIText component21 = this.transform.GetChild(3).GetChild(3).GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component21 != (UnityEngine.Object) null && ((Behaviour) component21).enabled)
    {
      ((Behaviour) component21).enabled = false;
      ((Behaviour) component21).enabled = true;
    }
    UIText component22 = this.transform.GetChild(3).GetChild(3).GetChild(4).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component22 != (UnityEngine.Object) null && ((Behaviour) component22).enabled)
    {
      ((Behaviour) component22).enabled = false;
      ((Behaviour) component22).enabled = true;
    }
    UIText component23 = this.transform.GetChild(3).GetChild(3).GetChild(4).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component23 != (UnityEngine.Object) null && ((Behaviour) component23).enabled)
    {
      ((Behaviour) component23).enabled = false;
      ((Behaviour) component23).enabled = true;
    }
    UIText component24 = this.transform.GetChild(3).GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component24 != (UnityEngine.Object) null && ((Behaviour) component24).enabled)
    {
      ((Behaviour) component24).enabled = false;
      ((Behaviour) component24).enabled = true;
    }
    UIText component25 = this.transform.GetChild(3).GetChild(4).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component25 != (UnityEngine.Object) null && ((Behaviour) component25).enabled)
    {
      ((Behaviour) component25).enabled = false;
      ((Behaviour) component25).enabled = true;
    }
    if ((UnityEngine.Object) this.m_SimulationAtkObj.SelectArmy != (UnityEngine.Object) null && ((Behaviour) this.m_SimulationAtkObj.SelectArmy).enabled)
    {
      ((Behaviour) this.m_SimulationAtkObj.SelectArmy).enabled = false;
      ((Behaviour) this.m_SimulationAtkObj.SelectArmy).enabled = true;
    }
    if (this.m_SimulationAtkObj.BtnText != null)
    {
      for (int index = 0; index < this.m_SimulationAtkObj.BtnText.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_SimulationAtkObj.BtnText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_SimulationAtkObj.BtnText[index]).enabled)
        {
          ((Behaviour) this.m_SimulationAtkObj.BtnText[index]).enabled = false;
          ((Behaviour) this.m_SimulationAtkObj.BtnText[index]).enabled = true;
        }
      }
    }
    if ((UnityEngine.Object) this.m_SimulationDefObj.SelectArmy != (UnityEngine.Object) null && ((Behaviour) this.m_SimulationDefObj.SelectArmy).enabled)
    {
      ((Behaviour) this.m_SimulationDefObj.SelectArmy).enabled = false;
      ((Behaviour) this.m_SimulationDefObj.SelectArmy).enabled = true;
    }
    if (this.m_SimulationDefObj.BtnText == null)
      return;
    for (int index = 0; index < this.m_SimulationDefObj.BtnText.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_SimulationDefObj.BtnText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_SimulationDefObj.BtnText[index]).enabled)
      {
        ((Behaviour) this.m_SimulationDefObj.BtnText[index]).enabled = false;
        ((Behaviour) this.m_SimulationDefObj.BtnText[index]).enabled = true;
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    WarManager activeGameplay = GameManager.ActiveGameplay as WarManager;
    switch (sender.m_BtnID1)
    {
      case 0:
        Time.timeScale = 0.0f;
        if (this.IsSimulation)
        {
          this.OpenSimulationExitPanel(true);
          break;
        }
        this.m_PausePanel.gameObject.SetActive(true);
        break;
      case 1:
      case 31:
        this.OnExit();
        break;
      case 2:
        Time.timeScale = 1f;
        this.m_PausePanel.gameObject.SetActive(false);
        break;
      case 3:
      case 36:
        activeGameplay?.SetWarCameraModel();
        break;
      case 4:
        activeGameplay?.resetWar();
        break;
      case 5:
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.WarToMap);
        break;
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
        this.SimulationActClick(sender.m_BtnID1);
        break;
      case 20:
      case 21:
      case 22:
        this.SimulationDefClick(sender.m_BtnID1);
        break;
      case 30:
        if (activeGameplay != null)
        {
          activeGameplay.WCamera.CoordCamMode = false;
          activeGameplay.StartTestCoordWar();
        }
        this.SetSimulationName();
        this.playAnim = true;
        this.m_AnimTick = 0.0f;
        this.m_SimulationPanel.GetChild(2).gameObject.SetActive(false);
        this.m_SimulationPanel.GetChild(3).gameObject.SetActive(false);
        break;
      case 32:
        Time.timeScale = 1f;
        activeGameplay?.resetWar(eLegBattleSimulationType.eSimulation, true);
        this.OpenSimulationPanel();
        break;
      case 33:
        Time.timeScale = 1f;
        this.OpenSimulationExitPanel(false);
        break;
      case 34:
        Time.timeScale = 1f;
        if (activeGameplay == null)
          break;
        activeGameplay.resetWar(eLegBattleSimulationType.eReplay);
        activeGameplay.StartTestCoordWar();
        break;
      case 35:
        this.OnExit();
        break;
    }
  }

  private void Update()
  {
    this.m_TickTime += Time.deltaTime;
    if ((double) this.m_TickTime >= 0.10000000149011612)
    {
      this.m_TickTime = 0.0f;
      for (int index = this.m_HudWorkArray_L.Count - 1; index >= 0; --index)
      {
        if (this.m_HudWorkArray_L[index] != null && this.m_HudWorkArray_L[index].Enable)
        {
          this.m_HudWorkArray_L[index].ColorA -= 0.03f;
          ((Graphic) this.m_HudWorkArray_L[index].Msg).color = new Color(((Graphic) this.m_HudWorkArray_L[index].Msg).color.r, ((Graphic) this.m_HudWorkArray_L[index].Msg).color.g, ((Graphic) this.m_HudWorkArray_L[index].Msg).color.b, this.m_HudWorkArray_L[index].ColorA);
          ((Graphic) this.m_HudWorkArray_L[index].Bg).color = new Color(((Graphic) this.m_HudWorkArray_L[index].Bg).color.r, ((Graphic) this.m_HudWorkArray_L[index].Bg).color.g, ((Graphic) this.m_HudWorkArray_L[index].Bg).color.b, this.m_HudWorkArray_L[index].ColorA);
          if ((double) this.m_HudWorkArray_L[index].ColorA <= 0.0)
            this.Remove(index);
        }
      }
      for (int index = this.m_HudWorkArray_R.Count - 1; index >= 0; --index)
      {
        if (this.m_HudWorkArray_R[index] != null && this.m_HudWorkArray_R[index].Enable)
        {
          this.m_HudWorkArray_R[index].ColorA -= 0.03f;
          ((Graphic) this.m_HudWorkArray_R[index].Msg).color = new Color(((Graphic) this.m_HudWorkArray_R[index].Msg).color.r, ((Graphic) this.m_HudWorkArray_R[index].Msg).color.g, ((Graphic) this.m_HudWorkArray_R[index].Msg).color.b, this.m_HudWorkArray_R[index].ColorA);
          ((Graphic) this.m_HudWorkArray_R[index].Bg).color = new Color(((Graphic) this.m_HudWorkArray_R[index].Bg).color.r, ((Graphic) this.m_HudWorkArray_R[index].Bg).color.g, ((Graphic) this.m_HudWorkArray_R[index].Bg).color.b, this.m_HudWorkArray_R[index].ColorA);
          if ((double) this.m_HudWorkArray_R[index].ColorA <= 0.0)
            this.Remove(index, 1);
        }
      }
    }
    this.m_TickFlash += Time.deltaTime;
    if ((double) this.m_TickFlash >= 0.029999999329447746)
    {
      this.m_TickFlash = 0.0f;
      for (int index = 0; index < this.m_FlashImage.Length; ++index)
      {
        if ((double) this.m_FlashColorA[index] > 1.5)
          this.m_FlashColorA[index] = 0.5f;
        else
          this.m_FlashColorA[index] += this.m_FlashColorDelta[index];
        if ((double) this.m_FlashColorA[index] >= 1.0)
          ((Graphic) this.m_FlashImage[index]).color = new Color(1f, 1f, 1f, 2f - this.m_FlashColorA[index]);
        else
          ((Graphic) this.m_FlashImage[index]).color = new Color(1f, 1f, 1f, this.m_FlashColorA[index]);
      }
    }
    if (this.bCountDownCenMsg)
    {
      this.m_CenterTick += Time.deltaTime;
      if ((double) this.m_CenterTick >= 0.10000000149011612)
      {
        this.m_CenterTick = 0.0f;
        this.m_CenterMsgColorA -= 0.03f;
        ((Graphic) this.m_CenterMsgText).color = new Color(((Graphic) this.m_CenterMsgText).color.r, ((Graphic) this.m_CenterMsgText).color.g, ((Graphic) this.m_CenterMsgText).color.b, this.m_CenterMsgColorA);
        ((Graphic) this.m_CenterMsgBg).color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
        ((Graphic) this.m_CenterMsgIcon).color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
        if ((double) this.m_CenterMsgColorA <= 0.0)
        {
          this.m_CenterMsg.gameObject.SetActive(false);
          this.bCountDownCenMsg = false;
          this.m_CenterMsgColorA = 1f;
        }
      }
    }
    this.m_RotationTf.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if (!this.playAnim)
      return;
    this.Anim();
  }

  private void SetSlider(int sliderType, long value, long max)
  {
    switch (sliderType)
    {
      case 0:
        if (this.m_Str[0] == null)
          this.m_Str[0] = StringManager.Instance.SpawnString(15);
        this.m_Str[0].ClearString();
        StringManager.Instance.IntToFormat(value, bNumber: true);
        this.m_Str[0].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(827U));
        this.m_AttackMoraleValue.text = this.m_Str[0].ToString();
        this.m_AttackMoraleValue.SetAllDirty();
        this.m_AttackMoraleValue.cachedTextGenerator.Invalidate();
        this.m_AttackSlider.fillAmount = (float) value / (float) max;
        break;
      case 1:
        if (this.m_Str[1] == null)
          this.m_Str[1] = StringManager.Instance.SpawnString(15);
        this.m_Str[1].ClearString();
        StringManager.Instance.IntToFormat(value, bNumber: true);
        this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(827U));
        this.m_DefendMoraleValue.text = this.m_Str[1].ToString();
        this.m_DefendMoraleValue.SetAllDirty();
        this.m_DefendMoraleValue.cachedTextGenerator.Invalidate();
        this.m_DefendSlider.fillAmount = (float) value / (float) max;
        break;
    }
  }

  private void SetArmyNum(int type, long value)
  {
    switch (type)
    {
      case 0:
        if (this.m_Str[7] == null)
          this.m_Str[7] = StringManager.Instance.SpawnString(15);
        this.m_Str[7].ClearString();
        StringManager.Instance.IntToFormat(value, bNumber: true);
        this.m_Str[7].AppendFormat("{0}");
        this.m_AttackValue.text = this.m_Str[7].ToString();
        this.m_AttackValue.SetAllDirty();
        this.m_AttackValue.cachedTextGenerator.Invalidate();
        break;
      case 1:
        if (this.m_Str[8] == null)
          this.m_Str[8] = StringManager.Instance.SpawnString(15);
        this.m_Str[8].ClearString();
        StringManager.Instance.IntToFormat(value, bNumber: true);
        this.m_Str[8].AppendFormat("{0}");
        this.m_DefendValue.text = this.m_Str[8].ToString();
        this.m_DefendValue.SetAllDirty();
        this.m_DefendValue.cachedTextGenerator.Invalidate();
        break;
    }
  }

  public RectTransform SetHint(bool bShow, bool bLord, ushort heroId = 1, ushort stringid = 1)
  {
    float num1 = 10f;
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(heroId);
    if (bShow)
    {
      this.m_HintText1.resizeTextForBestFit = false;
      this.m_HintText1.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
      this.m_HintText2.text = DataManager.Instance.mStringTable.GetStringByID((uint) stringid);
      this.m_HintIcon.sprite = !bLord ? this.m_SpArray.GetSprite(6) : this.m_SpArray.GetSprite(7);
      this.m_HintIcon.SetNativeSize();
      float num2 = this.m_HintText1.preferredWidth + ((Graphic) this.m_HintIcon).rectTransform.sizeDelta.x;
      float x = (double) num2 >= 156.0 - (double) num1 * 2.0 ? 10f : (float) ((156.0 - (double) num2) / 2.0);
      this.m_HintRect.sizeDelta = new Vector2(num2 + x * 2f, 86f);
      ((Graphic) this.m_HintIcon).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) this.m_HintIcon).rectTransform.anchoredPosition.y);
      ((Graphic) this.m_HintText1).rectTransform.anchoredPosition = this.m_HintText1.ArabicFixPos(new Vector2(x + ((Graphic) this.m_HintIcon).rectTransform.sizeDelta.x, ((Graphic) this.m_HintText1).rectTransform.anchoredPosition.y));
    }
    this.m_Hint.gameObject.SetActive(bShow);
    return this.m_HintRect;
  }

  private sHudMsg GetEmptyHud(ref int Idx)
  {
    Idx = 0;
    for (int index = 0; index < this.MaxHudMsg; ++index)
    {
      if (!this.m_HudArray[index].Enable)
      {
        Idx = index;
        return this.m_HudArray[index];
      }
    }
    return (sHudMsg) null;
  }

  public void AddCenterMsg(ushort MsgID, byte color = 0)
  {
    this.m_CenterMsgColorA = 1f;
    this.bCountDownCenMsg = false;
    this.m_CenterMsg.gameObject.SetActive(true);
    switch (MsgID)
    {
      case 0:
        this.m_CenterMsgText.text = DataManager.Instance.mStringTable.GetStringByID(828U);
        this.m_CenterMsgIcon.sprite = this.m_SpArray.GetSprite(4);
        if (this.IsPlayerAttack)
        {
          ((Graphic) this.m_CenterMsgText).color = new Color(0.341f, 0.854f, 1f, this.m_CenterMsgColorA);
          break;
        }
        ((Graphic) this.m_CenterMsgText).color = new Color(1f, 0.29f, 0.458f, this.m_CenterMsgColorA);
        break;
      case 1:
        UIText centerMsgText = this.m_CenterMsgText;
        string stringById = DataManager.Instance.mStringTable.GetStringByID(829U);
        this.m_CenterMsgText.text = stringById;
        string str = stringById;
        centerMsgText.text = str;
        this.m_CenterMsgIcon.sprite = this.m_SpArray.GetSprite(5);
        if (!this.IsPlayerAttack)
        {
          ((Graphic) this.m_CenterMsgText).color = new Color(0.341f, 0.854f, 1f, this.m_CenterMsgColorA);
          break;
        }
        ((Graphic) this.m_CenterMsgText).color = new Color(1f, 0.29f, 0.458f, this.m_CenterMsgColorA);
        break;
      default:
        this.m_CenterMsgText.text = DataManager.Instance.mStringTable.GetStringByID((uint) MsgID);
        this.m_CenterMsgIcon.sprite = this.m_SpArray.GetSprite(5);
        if (color == (byte) 0)
        {
          ((Graphic) this.m_CenterMsgText).color = new Color(0.341f, 0.854f, 1f, this.m_CenterMsgColorA);
          break;
        }
        ((Graphic) this.m_CenterMsgText).color = new Color(1f, 0.29f, 0.458f, this.m_CenterMsgColorA);
        break;
    }
    this.m_CenterMsgIcon.SetNativeSize();
    this.m_CenterMsgColorA = 1f;
    ((Graphic) this.m_CenterMsgBg).color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
    ((Graphic) this.m_CenterMsgIcon).color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
    this.m_CenterMsgText.SetAllDirty();
    this.m_CenterMsgText.cachedTextGenerator.Invalidate();
    this.m_CenterMsgText.cachedTextGeneratorForLayout.Invalidate();
    this.m_CenterMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(this.m_CenterMsgText.preferredWidth + 125f, 47f);
  }

  public void SetCountDown() => this.bCountDownCenMsg = true;

  public void AddHudMsg(int hudType = 0, int strType = 0, ushort tableKey = 1)
  {
    // ISSUE: unable to decompile the method.
  }

  private void Remove(int Idx = 0, int hudType = 0)
  {
    if (hudType == 0)
    {
      if (this.m_HudWorkArray_L.Count <= 0)
        return;
      this.m_HudWorkArray_L[Idx].Enable = false;
      this.m_HudWorkArray_L[Idx].Trnas.gameObject.SetActive(false);
      this.m_HudWorkArray_L.Remove(this.m_HudWorkArray_L[Idx]);
    }
    else
    {
      if (this.m_HudWorkArray_R.Count <= 0)
        return;
      this.m_HudWorkArray_R[Idx].Enable = false;
      this.m_HudWorkArray_R[Idx].Trnas.gameObject.SetActive(false);
      this.m_HudWorkArray_R.Remove(this.m_HudWorkArray_R[Idx]);
    }
  }

  private void OpenClearPanel(int type)
  {
    this.SetClearPanelType(type);
    this.m_PausePanel.gameObject.SetActive(false);
    this.m_BattlePanel.gameObject.SetActive(false);
    this.m_BattleClearPanel.gameObject.SetActive(true);
  }

  private void OpenmBattlePanel()
  {
    this.m_BattlePanel.gameObject.SetActive(true);
    this.m_SimulationPanel.gameObject.SetActive(false);
    this.m_SimulationExitPanel.gameObject.SetActive(false);
  }

  private void OpenSimulationPanel()
  {
    this.m_BattlePanel.gameObject.SetActive(false);
    this.m_SimulationPanel.gameObject.SetActive(true);
    this.m_SimulationExitPanel.gameObject.SetActive(false);
  }

  private void OpenSimulationExitPanel(bool bOpen)
  {
    this.m_SimulationExitPanel.gameObject.SetActive(bOpen);
    ((Behaviour) this.m_SimulationExitPanel.GetChild(0).GetComponent<Image>()).enabled = true;
    this.m_SimulationExitPanel.GetChild(3).gameObject.SetActive(true);
    this.m_SimulationExitPanel.GetChild(4).gameObject.SetActive(false);
  }

  private void OpenSimulationExitPanelWithoutBg(bool bOpen = true)
  {
    this.m_SimulationExitPanel.gameObject.SetActive(bOpen);
    ((Behaviour) this.m_SimulationExitPanel.GetChild(0).GetComponent<Image>()).enabled = false;
    this.m_SimulationExitPanel.GetChild(3).gameObject.SetActive(false);
    this.m_SimulationExitPanel.GetChild(4).gameObject.SetActive(true);
    this.m_BattleClearPanel.GetChild(4).GetChild(1).gameObject.SetActive(false);
    this.m_BattleClearPanel.GetChild(4).GetChild(2).gameObject.SetActive(false);
  }

  private void OpenSimulationBattle()
  {
    this.m_BattlePanel.gameObject.SetActive(true);
    this.m_SimulationPanel.gameObject.SetActive(false);
    this.m_SimulationExitPanel.gameObject.SetActive(false);
  }

  private void SetAutoSelect()
  {
    this.SimulationActClick((int) WarManager.CoordSimuIndex_Left + 10, false);
    this.SimulationDefClick((int) WarManager.TroopKindSimuIndex_Right + 20, false);
  }

  private void SimulationActClick(int btnID, bool bSetCoordDirty = true)
  {
    int index1 = 0;
    if (btnID >= 10 && btnID < 16)
    {
      index1 = btnID - 10;
      if (((UIBehaviour) this.m_SimulationAtkObj.SelectImage[index1]).IsActive())
        return;
      for (int index2 = 0; index2 < this.m_SimulationAtkObj.SelectImage.Length; ++index2)
        ((Component) this.m_SimulationAtkObj.SelectImage[index2]).gameObject.SetActive(false);
      ((Component) this.m_SimulationAtkObj.SelectImage[index1]).gameObject.SetActive(true);
      this.m_SimulationAtkObj.CStr.ClearString();
      this.m_SimulationAtkObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) (9778 + index1)));
      this.m_SimulationAtkObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5317U));
      this.m_SimulationAtkObj.CStr.AppendFormat("{0} {1}");
      this.m_SimulationAtkObj.SelectArmy.text = this.m_SimulationAtkObj.CStr.ToString();
      this.m_SimulationAtkObj.SelectArmy.SetAllDirty();
      this.m_SimulationAtkObj.SelectArmy.cachedTextGenerator.Invalidate();
    }
    if (!bSetCoordDirty || !(GameManager.ActiveGameplay is WarManager activeGameplay))
      return;
    WarManager.CoordSimuIndex_Left = (ushort) index1;
    activeGameplay.SetCoordDirty();
  }

  private void SimulationDefClick(int btnID, bool bSetCoordDirty = true)
  {
    int index1 = 0;
    if (btnID >= 20 && btnID < 23)
    {
      index1 = btnID - 20;
      if (((UIBehaviour) this.m_SimulationDefObj.SelectImage[index1]).IsActive())
        return;
      for (int index2 = 0; index2 < this.m_SimulationDefObj.SelectImage.Length; ++index2)
        ((Component) this.m_SimulationDefObj.SelectImage[index2]).gameObject.SetActive(false);
      ((Component) this.m_SimulationDefObj.SelectImage[index1]).gameObject.SetActive(true);
      this.m_SimulationDefObj.CStr.ClearString();
      this.m_SimulationDefObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) (9791 - index1)));
      this.m_SimulationDefObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9792U));
      this.m_SimulationDefObj.CStr.AppendFormat("{0} {1}");
      this.m_SimulationDefObj.SelectArmy.text = this.m_SimulationDefObj.CStr.ToString();
      this.m_SimulationDefObj.SelectArmy.SetAllDirty();
      this.m_SimulationDefObj.SelectArmy.cachedTextGenerator.Invalidate();
    }
    if (!bSetCoordDirty || !(GameManager.ActiveGameplay is WarManager activeGameplay))
      return;
    WarManager.TroopKindSimuIndex_Right = (ushort) index1;
    activeGameplay.SetCoordDirty();
  }

  private void SetSimulationName()
  {
    this.m_AttackName.text = this.m_SimulationAtkObj.CStr.ToString();
    this.m_AttackName.SetAllDirty();
    this.m_AttackName.cachedTextGenerator.Invalidate();
    this.m_DefendName.text = this.m_SimulationDefObj.CStr.ToString();
    this.m_DefendName.SetAllDirty();
    this.m_DefendName.cachedTextGenerator.Invalidate();
    this.m_ClearPanelAttackName.text = this.m_SimulationAtkObj.CStr.ToString();
    this.m_ClearPanelAttackName.SetAllDirty();
    this.m_ClearPanelAttackName.cachedTextGenerator.Invalidate();
    this.m_ClearPanelDefendName.text = this.m_SimulationDefObj.CStr.ToString();
    this.m_ClearPanelDefendName.SetAllDirty();
    this.m_ClearPanelDefendName.cachedTextGenerator.Invalidate();
  }

  private void SetClearPanelType(int type)
  {
    DataManager instance = DataManager.Instance;
    if (this.m_Str[0] == null)
      this.m_Str[0] = StringManager.Instance.SpawnString(40);
    this.m_Str[0].ClearString();
    if (this.m_Str[1] == null)
      this.m_Str[1] = StringManager.Instance.SpawnString(40);
    this.m_Str[1].ClearString();
    if (!this.IsSimulation)
    {
      if ((int) instance.KindomID_War[0] != (int) instance.KindomID_War[1])
      {
        StringManager.Instance.IntToFormat((long) instance.KindomID_War[0]);
        if (instance.AllianceTag_War[0].Length != 0)
        {
          StringManager.Instance.StringToFormat(instance.AllianceTag_War[0]);
          StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
          this.m_Str[0].AppendFormat("#{0}\n[{1}] {2}");
        }
        else
        {
          StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
          this.m_Str[0].AppendFormat("#{0}\n{1}");
        }
        this.m_ClearPanelAttackName.text = this.m_Str[0].ToString();
        this.m_ClearPanelAttackName.SetAllDirty();
        this.m_ClearPanelAttackName.cachedTextGenerator.Invalidate();
        StringManager.Instance.IntToFormat((long) instance.KindomID_War[1]);
        if (instance.AllianceTag_War[1].Length != 0)
        {
          StringManager.Instance.StringToFormat(instance.AllianceTag_War[1]);
          StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
          this.m_Str[1].AppendFormat("#{0}\n[{1}] {2}");
        }
        else
        {
          StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
          this.m_Str[1].AppendFormat("#{0}\n{1}");
        }
        this.m_ClearPanelDefendName.text = this.m_Str[1].ToString();
        this.m_ClearPanelDefendName.SetAllDirty();
        this.m_ClearPanelDefendName.cachedTextGenerator.Invalidate();
      }
      else
      {
        if (instance.AllianceTag_War[0].Length != 0)
        {
          StringManager.Instance.StringToFormat(instance.AllianceTag_War[0]);
          StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
          this.m_Str[0].AppendFormat("[{0}] {1}");
        }
        else
        {
          StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
          this.m_Str[0].AppendFormat("{0}");
        }
        this.m_ClearPanelAttackName.text = this.m_Str[0].ToString();
        this.m_ClearPanelAttackName.SetAllDirty();
        this.m_ClearPanelAttackName.cachedTextGenerator.Invalidate();
        if (instance.AllianceTag_War[1].Length != 0)
        {
          StringManager.Instance.StringToFormat(instance.AllianceTag_War[1]);
          StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
          this.m_Str[1].AppendFormat("[{0}] {1}");
        }
        else
        {
          StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
          this.m_Str[1].AppendFormat("{0}");
        }
        this.m_ClearPanelDefendName.text = this.m_Str[1].ToString();
        this.m_ClearPanelDefendName.SetAllDirty();
        this.m_ClearPanelDefendName.cachedTextGenerator.Invalidate();
      }
    }
    if (this.m_Str[2] == null)
      this.m_Str[2] = StringManager.Instance.SpawnString(15);
    long x1 = (long) Mathf.Clamp((float) (instance.MaxValue_War[0] - instance.NowValue_War[0]), 0.0f, (float) instance.MaxValue_War[0]);
    this.m_Str[2].ClearString();
    StringManager.Instance.IntToFormat(x1);
    this.m_Str[2].AppendFormat("{0}");
    this.m_ClearPanelAttackValue.text = this.m_Str[2].ToString();
    this.m_ClearPanelAttackValue.SetAllDirty();
    this.m_ClearPanelAttackValue.cachedTextGenerator.Invalidate();
    if (this.m_Str[4] == null)
      this.m_Str[4] = StringManager.Instance.SpawnString(15);
    long x2 = Math.Max((long) Mathf.Clamp((float) (instance.MaxValue_War[1] - instance.NowValue_War[1]), 0.0f, (float) instance.MaxValue_War[1]) - instance.CastleTrapsDestroyedCount, 0L);
    this.m_Str[4].ClearString();
    StringManager.Instance.IntToFormat(x2);
    this.m_Str[4].AppendFormat("{0}");
    this.m_ClearPanelDefendValue.text = this.m_Str[4].ToString();
    this.m_ClearPanelDefendValue.SetAllDirty();
    this.m_ClearPanelDefendValue.cachedTextGenerator.Invalidate();
    switch (type)
    {
      case 0:
        ((Graphic) this.m_ClearPanelWinOrLose).color = new Color(1f, 0.9f, 0.564f);
        this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(574U);
        ((Graphic) this.m_ClearPanelResult).color = new Color(1f, 0.925f, 0.529f);
        this.m_ClearPanelResultShadow.effectColor = new Color(0.282f, 0.0f, 0.0f);
        ((Shadow) this.m_ClearPanelResultOutline).effectColor = new Color(0.843f, 0.0f, 0.0f);
        this.m_ClearPanelTitleTf.gameObject.SetActive(false);
        break;
      case 1:
        ((Graphic) this.m_ClearPanelWinOrLose).color = new Color(1f, 0.9f, 0.564f);
        ((Graphic) this.m_ClearPanelResult).color = new Color(1f, 0.925f, 0.529f);
        this.m_ClearPanelResultShadow.effectColor = new Color(0.282f, 0.0f, 0.0f);
        ((Shadow) this.m_ClearPanelResultOutline).effectColor = new Color(0.843f, 0.0f, 0.0f);
        this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(575U);
        this.m_ClearPanelTitle.text = instance.mStringTable.GetStringByID(578U);
        this.m_ClearPanelTitleTf.gameObject.SetActive(true);
        break;
      case 2:
        ((Graphic) this.m_ClearPanelWinOrLose).color = new Color(0.639f, 0.0f, 0.14f);
        ((Graphic) this.m_ClearPanelResult).color = new Color(0.694f, 0.901f, 1f);
        this.m_ClearPanelResultShadow.effectColor = new Color(0.0f, 0.047f, 0.282f);
        ((Shadow) this.m_ClearPanelResultOutline).effectColor = new Color(0.247f, 0.607f, 0.729f);
        this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(576U);
        this.m_ClearPanelTitleTf.gameObject.SetActive(false);
        break;
      case 3:
        ((Graphic) this.m_ClearPanelWinOrLose).color = new Color(0.639f, 0.0f, 0.14f);
        ((Graphic) this.m_ClearPanelResult).color = new Color(0.694f, 0.901f, 1f);
        this.m_ClearPanelResultShadow.effectColor = new Color(0.0f, 0.047f, 0.282f);
        ((Shadow) this.m_ClearPanelResultOutline).effectColor = new Color(0.247f, 0.607f, 0.729f);
        this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(577U);
        this.m_ClearPanelTitle.text = instance.mStringTable.GetStringByID(579U);
        this.m_ClearPanelTitleTf.gameObject.SetActive(true);
        break;
    }
  }

  private void OnExit()
  {
    WarManager activeGameplay = GameManager.ActiveGameplay as WarManager;
    Time.timeScale = 1f;
    if (activeGameplay != null)
      activeGameplay.m_WarState = WarManager.WarState.STOP;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.WarToMap);
  }

  public override bool OnBackButtonClick()
  {
    if (this.playAnim)
      return true;
    Time.timeScale = 0.0f;
    if (!this.IsSimulation)
    {
      this.m_PausePanel.gameObject.SetActive(!this.m_PausePanel.gameObject.activeSelf);
      Time.timeScale = !this.m_PausePanel.gameObject.activeSelf ? 1f : 0.0f;
    }
    else if (this.m_BattlePanel.gameObject.activeSelf)
    {
      this.OpenSimulationExitPanel(!this.m_SimulationExitPanel.gameObject.activeSelf);
      Time.timeScale = !this.m_SimulationExitPanel.gameObject.activeSelf ? 1f : 0.0f;
    }
    else if (this.m_SimulationPanel.gameObject.activeSelf)
      this.OnExit();
    else if (this.m_BattleClearPanel.gameObject.activeSelf)
    {
      this.OpenSimulationExitPanelWithoutBg(!this.m_SimulationExitPanel.gameObject.activeSelf);
      Time.timeScale = !this.m_SimulationExitPanel.gameObject.activeSelf ? 1f : 0.0f;
    }
    else
      Time.timeScale = 1f;
    return true;
  }

  public void OnBattlePause()
  {
    if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Settlement) || NewbieManager.IsWorking())
      return;
    Time.timeScale = 0.0f;
    if (!this.IsSimulation)
      this.m_PausePanel.gameObject.SetActive(true);
    else if (this.m_BattlePanel.gameObject.activeSelf)
      this.OpenSimulationExitPanel(true);
    else if (this.m_BattleClearPanel.gameObject.activeSelf)
    {
      Time.timeScale = 1f;
      this.OpenSimulationExitPanelWithoutBg();
    }
    else
      Time.timeScale = 1f;
  }

  private void Anim()
  {
    this.m_AnimTick += Time.unscaledDeltaTime;
    float num1 = 0.5f;
    float num2 = 0.3f;
    float num3 = 0.2f;
    if ((double) this.m_AnimTick <= (double) num1)
    {
      if ((double) this.m_AnimTick >= (double) num3)
      {
        this.m_AttackSlider_Rt.offsetMin = new Vector2(0.0f, Mathf.Lerp(-190f, 0.0f, (float) (((double) this.m_AnimTick - (double) num3) / ((double) num1 - (double) num3))));
        this.m_DefendSlider_Rt.offsetMin = new Vector2(0.0f, Mathf.Lerp(-190f, 0.0f, (float) (((double) this.m_AnimTick - (double) num3) / ((double) num1 - (double) num3))));
        this.m_VSImage_Rt.offsetMin = new Vector2(0.0f, Mathf.Lerp(-190f, 0.0f, (float) (((double) this.m_AnimTick - (double) num3) / ((double) num1 - (double) num3))));
        this.m_BattlePanel.gameObject.SetActive(true);
        Debug.Log((object) ("step2 " + (object) this.m_AnimTick));
      }
      if ((double) this.m_AnimTick > (double) num2)
        return;
      this.m_SimulationPanel_Left.anchoredPosition = new Vector2(Mathf.Lerp(0.0f, -390f, this.m_AnimTick / num2), 0.0f);
      this.m_SimulationPanel_Right.anchoredPosition = new Vector2(Mathf.Lerp(0.0f, 390f, this.m_AnimTick / num2), 0.0f);
      Debug.Log((object) ("step1 " + (object) this.m_AnimTick));
    }
    else
    {
      Debug.Log((object) ("OpenSimulationBattle " + (object) this.m_AnimTick));
      this.m_AttackSlider_Rt.offsetMin = new Vector2(0.0f, 0.0f);
      this.m_DefendSlider_Rt.offsetMin = new Vector2(0.0f, 0.0f);
      this.m_VSImage_Rt.offsetMin = new Vector2(0.0f, 0.0f);
      this.OpenSimulationBattle();
      this.playAnim = false;
    }
  }

  public void SetAlertImageAlpha(float Alpha)
  {
    if (GUIManager.Instance.m_AlertImageIndex != 0 || !((UnityEngine.Object) this.alertBlock != (UnityEngine.Object) null) || !this.alertBlock.gameObject.activeSelf)
      return;
    Color color = new Color(1f, 1f, 1f, Alpha);
    if ((UnityEngine.Object) this.alertBlock_T != (UnityEngine.Object) null)
      ((Graphic) this.alertBlock_T).color = color;
    if ((UnityEngine.Object) this.alertBlock_B != (UnityEngine.Object) null)
      ((Graphic) this.alertBlock_B).color = color;
    if ((UnityEngine.Object) this.alertBlock_L != (UnityEngine.Object) null)
      ((Graphic) this.alertBlock_L).color = color;
    if (!((UnityEngine.Object) this.alertBlock_R != (UnityEngine.Object) null))
      return;
    ((Graphic) this.alertBlock_R).color = color;
  }

  public void SetAlertBlock(bool bOpenAlertBlock)
  {
    this.alertBlock.gameObject.SetActive(bOpenAlertBlock);
  }
}
