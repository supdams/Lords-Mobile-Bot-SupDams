// Decompiled with JetBrains decompiler
// Type: UISynthesis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISynthesis : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler
{
  private const int m_MaxSourceItemPanelObject = 3;
  private const int TextMax = 5;
  private Transform m_SynPanel;
  private Transform m_HeroItemPanel;
  private Transform m_ItemPanel;
  private Transform m_RequirementPanel;
  private Transform m_ItemSourcePanel;
  private Transform[] m_SourceBtn;
  private Image m_ExiteBtnImage;
  public UIButton m_ExiteBtn;
  private UIButton m_ReturnBtn;
  private ScrollPanel m_ItemScrollPanel;
  private UIHIBtn m_Item;
  private UIHIBtn m_ResultItem;
  private UIText m_ResultItemText;
  private UIHIBtn[] m_SynthesisBtns;
  private UIText[] m_SynthesisBtnTexts;
  private UIButton m_TransBtn;
  private UIText m_NeedMoneyText;
  private UIHIBtn m_HeroItem;
  private UIText m_HeroItemText;
  private UIButton m_InfoBtn;
  private Image[] m_EffectImage;
  private Transform m_EffectPanel;
  private RectTransform m_EffectImage1Rt;
  private ScrollPanel m_SourceItemScrollPanel;
  private UIHIBtn m_ItemSource1;
  private UIHIBtn m_ItemSource2;
  private UIHIBtn m_ItemSource3;
  private UIText m_ItemSourceName;
  private CString m_ItemSourceNameStr;
  private Transform[] m_ArrowImgae;
  private UIText[] m_FuncBtnText;
  private Image[] m_FuncBtnImage;
  private UIText m_SourceText;
  private int m_MaxItemPanelObject = 6;
  private UIHIBtn[] m_ItemBtns;
  private Image[] m_ItemSelects;
  private Transform[] m_SourceItemBtn1s;
  private Transform[] m_SourceItemBtn2s;
  private Transform[] m_SourceItemBtn3s;
  private UIHIBtn[] m_SourceBtn1s;
  private UIHIBtn[] m_SourceBtn2s;
  private UIHIBtn[] m_SourceBtn3s;
  private UIButton[] m_SourceUIBtn1s;
  private UIButton[] m_SourceUIBtn2s;
  private UIButton[] m_SourceUIBtn3s;
  private e_SynPageType m_PageType;
  private LevelTableKind m_LevelTableKind;
  private ushort m_FisetItemID = 105;
  private List<ushort> m_ItemData;
  private List<ushort> m_ItemSourceData;
  private ushort m_SourceItemPanelID;
  private float m_ItemHeight = 64f;
  private float m_SourceItemHeight = 160f;
  private float m_ColorTick;
  private float m_ColorA;
  private bool m_ShowTransEffect;
  private Vector2 m_BeginMove = new Vector2(-33f, 145.5f);
  private Vector2 m_EndMove = new Vector2(-33f, 0.0f);
  private Vector2 m_Step;
  private bool m_Moveing;
  private bool m_CenterPos;
  private bool _m_MovingExit;
  private uint MixPrice;
  private RectTransform m_SourceItemScrollPanelRect;
  private StringBuilder sb;
  private Transform m_TransForm;
  private GUIManager GM = GUIManager.Instance;
  private bool bNeedSaveUIState;
  private bool bSaveUIState_Money;
  private byte NowClickIdx;
  private ushort[] Fragment = new ushort[5];
  private ushort[] FragmentMax = new ushort[5];
  private ushort[] RequirementNum = new ushort[5];
  private ushort[] SynthesisItemNum = new ushort[5];
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[5];
  private UIText m_tmpStr1;
  private UIText m_tmpStr2;
  private UIText[][] m_tmpItemtext1 = new UIText[3][];
  private UIText[][] m_tmpItemtext2 = new UIText[3][];
  private UIText[][] m_tmpItemtext3 = new UIText[3][];
  private float MoveDelta;
  private short PassFrame = 3;
  private bool bInit;

  public bool m_MovingExit
  {
    get => this._m_MovingExit;
    set
    {
      this._m_MovingExit = value;
      if (!this._m_MovingExit)
        return;
      Vector2 beginMove = this.m_BeginMove;
      this.m_BeginMove = this.m_EndMove;
      this.m_EndMove = beginMove;
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager.Instance.bClearWindowStack = true;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
    this.m_LevelTableKind = LevelTableKind.NormalStage;
    this.m_ItemData = new List<ushort>();
    this.m_FisetItemID = (ushort) arg1;
    this.m_ItemSourceData = new List<ushort>();
    this.sb = new StringBuilder();
    this.m_ItemSourceNameStr = StringManager.Instance.SpawnString();
    this.m_BeginMove.x = (double) GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta.x / (double) GUIManager.Instance.m_UICanvas.scaleFactor > 853.0 ? (this.m_EndMove.x = 0.0f) : (this.m_EndMove.x = -32.5f);
    this.InitUI();
    if (!((Component) GUIManager.Instance.m_ItemInfo.m_RectTransform).gameObject.activeSelf)
      GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.HeroEquip, this.m_FisetItemID, (ushort) 0, (byte) 0);
    this.m_Step = this.m_BeginMove;
    this.m_Moveing = true;
  }

  public void MyOnOpen(int arg1, Transform tf)
  {
    ((Graphic) this.transform.GetComponent<Image>()).color = new Color(1f, 1.01f, 1f, 0.7f);
    this.m_LevelTableKind = LevelTableKind.AdvanceStage;
    this.m_ItemData = new List<ushort>();
    this.m_FisetItemID = (ushort) arg1;
    this.m_ItemSourceData = new List<ushort>();
    this.sb = new StringBuilder();
    this.m_ItemSourceNameStr = StringManager.Instance.SpawnString();
    this.InitUI(tf);
    this.m_TransForm = tf;
    this.m_CenterPos = true;
    this.m_Moveing = true;
    this.m_EndMove = this.m_BeginMove;
    this.m_Step = this.m_EndMove;
    ((RectTransform) this.m_SynPanel).anchorMax = new Vector2(0.5f, 0.5f);
    ((RectTransform) this.m_SynPanel).anchorMin = new Vector2(0.5f, 0.5f);
    ((RectTransform) this.m_SynPanel).pivot = new Vector2(0.5f, 0.5f);
    ((RectTransform) this.m_SynPanel).anchoredPosition = new Vector2(0.0f, 0.0f);
    ((RectTransform) ((Component) this.m_ExiteBtn).transform.parent).pivot = new Vector2(0.5f, 0.5f);
    ((RectTransform) ((Component) this.m_ExiteBtn).transform.parent).anchorMax = new Vector2(0.5f, 0.5f);
    ((RectTransform) ((Component) this.m_ExiteBtn).transform.parent).anchorMin = new Vector2(0.5f, 0.5f);
    ((RectTransform) ((Component) this.m_ExiteBtn).transform.parent).anchoredPosition = new Vector2(359.5f, 136f);
    ((Behaviour) this.m_ExiteBtnImage).enabled = false;
    ((Component) this.m_ReturnBtn).gameObject.SetActive(false);
    this.bInit = true;
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.m_ItemSourceNameStr);
    GUIManager.Instance.m_ItemInfo.Hide();
    if (this.bNeedSaveUIState)
      this.SaveUIState();
    else if (this.bSaveUIState_Money)
      this.SaveUIState();
    else
      this.GM.ClearSynthesisUIData();
  }

  public void Destroy()
  {
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        if (this.m_ItemData.Count <= 0)
          break;
        if (this.m_ItemData.Count > 1)
          this.GoTo(this.m_ItemData.Count - 2);
        this.UpdatePageType(this.m_ItemData[this.m_ItemData.Count - 1], false);
        break;
      case 1:
        if (!((Object) this.m_ExiteBtn != (Object) null))
          break;
        this.OnButtonClick(this.m_ExiteBtn);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    List<float> _DataHeight = new List<float>();
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_VIP:
        for (int index = 0; index < this.m_ItemSourceData.Count; ++index)
          _DataHeight.Add(this.m_SourceItemHeight);
        this.m_SourceItemScrollPanel.AddNewDataHeight(_DataHeight, false);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
      default:
        if (networkNews != NetworkNews.Login)
          break;
        goto case NetworkNews.Refresh_VIP;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_ResultItemText != (Object) null && ((Behaviour) this.m_ResultItemText).enabled)
    {
      ((Behaviour) this.m_ResultItemText).enabled = false;
      ((Behaviour) this.m_ResultItemText).enabled = true;
    }
    if ((Object) this.m_NeedMoneyText != (Object) null && ((Behaviour) this.m_NeedMoneyText).enabled)
    {
      ((Behaviour) this.m_NeedMoneyText).enabled = false;
      ((Behaviour) this.m_NeedMoneyText).enabled = true;
    }
    if ((Object) this.m_HeroItemText != (Object) null && ((Behaviour) this.m_HeroItemText).enabled)
    {
      ((Behaviour) this.m_HeroItemText).enabled = false;
      ((Behaviour) this.m_HeroItemText).enabled = true;
    }
    if ((Object) this.m_ItemSourceName != (Object) null && ((Behaviour) this.m_ItemSourceName).enabled)
    {
      ((Behaviour) this.m_ItemSourceName).enabled = false;
      ((Behaviour) this.m_ItemSourceName).enabled = true;
    }
    if ((Object) this.m_SourceText != (Object) null && ((Behaviour) this.m_SourceText).enabled)
    {
      ((Behaviour) this.m_SourceText).enabled = false;
      ((Behaviour) this.m_SourceText).enabled = true;
    }
    if ((Object) this.m_tmpStr1 != (Object) null && ((Behaviour) this.m_tmpStr1).enabled)
    {
      ((Behaviour) this.m_tmpStr1).enabled = false;
      ((Behaviour) this.m_tmpStr1).enabled = true;
    }
    if ((Object) this.m_tmpStr2 != (Object) null && ((Behaviour) this.m_tmpStr2).enabled)
    {
      ((Behaviour) this.m_tmpStr2).enabled = false;
      ((Behaviour) this.m_tmpStr2).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.m_FuncBtnText[index] != (Object) null && ((Behaviour) this.m_FuncBtnText[index]).enabled)
      {
        ((Behaviour) this.m_FuncBtnText[index]).enabled = false;
        ((Behaviour) this.m_FuncBtnText[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.m_SynthesisBtnTexts[index] != (Object) null && ((Behaviour) this.m_SynthesisBtnTexts[index]).enabled)
      {
        ((Behaviour) this.m_SynthesisBtnTexts[index]).enabled = false;
        ((Behaviour) this.m_SynthesisBtnTexts[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.m_tmptext[index] != (Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 3; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if ((Object) this.m_tmpItemtext1[index1][index2] != (Object) null && ((Behaviour) this.m_tmpItemtext1[index1][index2]).enabled)
        {
          ((Behaviour) this.m_tmpItemtext1[index1][index2]).enabled = false;
          ((Behaviour) this.m_tmpItemtext1[index1][index2]).enabled = true;
        }
        if ((Object) this.m_tmpItemtext2[index1][index2] != (Object) null && ((Behaviour) this.m_tmpItemtext2[index1][index2]).enabled)
        {
          ((Behaviour) this.m_tmpItemtext2[index1][index2]).enabled = false;
          ((Behaviour) this.m_tmpItemtext2[index1][index2]).enabled = true;
        }
        if ((Object) this.m_tmpItemtext3[index1][index2] != (Object) null && ((Behaviour) this.m_tmpItemtext3[index1][index2]).enabled)
        {
          ((Behaviour) this.m_tmpItemtext3[index1][index2]).enabled = false;
          ((Behaviour) this.m_tmpItemtext3[index1][index2]).enabled = true;
        }
      }
    }
    if (this.m_ItemBtns != null)
    {
      for (int index = 0; index < this.m_ItemBtns.Length; ++index)
      {
        if ((Object) this.m_ItemBtns[index] != (Object) null && ((Behaviour) this.m_ItemBtns[index]).enabled)
          this.m_ItemBtns[index].Refresh_FontTexture();
      }
    }
    if (this.m_SourceBtn1s != null)
    {
      for (int index = 0; index < this.m_SourceBtn1s.Length; ++index)
      {
        if ((Object) this.m_SourceBtn1s[index] != (Object) null && ((Behaviour) this.m_SourceBtn1s[index]).enabled)
          this.m_SourceBtn1s[index].Refresh_FontTexture();
      }
    }
    if (this.m_SourceBtn2s != null)
    {
      for (int index = 0; index < this.m_SourceBtn2s.Length; ++index)
      {
        if ((Object) this.m_SourceBtn2s[index] != (Object) null && ((Behaviour) this.m_SourceBtn2s[index]).enabled)
          this.m_SourceBtn2s[index].Refresh_FontTexture();
      }
    }
    if (this.m_SourceBtn3s == null)
      return;
    for (int index = 0; index < this.m_SourceBtn2s.Length; ++index)
    {
      if ((Object) this.m_SourceBtn3s[index] != (Object) null && ((Behaviour) this.m_SourceBtn3s[index]).enabled)
        this.m_SourceBtn3s[index].Refresh_FontTexture();
    }
  }

  private void Update()
  {
    if (this.m_ShowTransEffect)
    {
      this.m_ColorTick += Time.deltaTime;
      if ((double) this.m_ColorTick >= 0.05000000074505806)
      {
        this.m_ColorA += 0.1f;
        if ((double) this.m_ColorA >= 2.0)
        {
          this.m_ColorA = 0.0f;
          ((Transform) this.m_EffectImage1Rt).localScale = new Vector3(1f, 1f, 1f);
          this.m_ShowTransEffect = false;
        }
        for (int index = 0; index < 3; ++index)
        {
          if ((Object) this.m_EffectImage[index] != (Object) null)
          {
            if ((double) this.m_ColorA > 1.0)
              ((Graphic) this.m_EffectImage[index]).color = new Color(1f, 1f, 1f, 2f - this.m_ColorA);
            else
              ((Graphic) this.m_EffectImage[index]).color = new Color(1f, 1f, 1f, this.m_ColorA);
            if (index == 2 && (double) this.m_ColorA > 1.0)
              ((Transform) this.m_EffectImage1Rt).localScale = new Vector3(this.m_ColorA, this.m_ColorA, this.m_ColorA);
          }
        }
        this.m_ColorTick = 0.0f;
      }
    }
    if (this.m_Moveing)
    {
      if (!this.m_CenterPos && !this.bInit)
      {
        if (this.PassFrame > (short) 0)
        {
          ((RectTransform) this.m_SynPanel).anchoredPosition = this.m_BeginMove;
          --this.PassFrame;
          return;
        }
        float num = 0.3f;
        this.MoveDelta = Mathf.Clamp(this.MoveDelta + Time.deltaTime, 0.0f, num);
        this.m_Step = ((RectTransform) this.m_SynPanel).anchoredPosition;
        this.m_Step.y = EasingEffect.Linear(this.MoveDelta, this.m_BeginMove.y, this.m_EndMove.y - this.m_BeginMove.y, num);
        ((RectTransform) this.m_SynPanel).anchoredPosition = this.m_Step;
        GUIManager.Instance.m_ItemInfo.UpdatePosition(this.MoveDelta);
        if (this.m_Step == this.m_EndMove)
        {
          this.MoveDelta = 0.0f;
          this.bInit = true;
          return;
        }
      }
      if (this.bInit)
      {
        this.m_Moveing = false;
        this.InitHintn();
        List<float> _DataHeight = new List<float>();
        _DataHeight.Add(this.m_ItemHeight);
        this.m_ItemScrollPanel.IntiScrollPanel(370f, 10f, 5f, _DataHeight, this.m_MaxItemPanelObject, (IUpDateScrollPanel) this);
        _DataHeight.Clear();
        _DataHeight.Add(this.m_SourceItemHeight);
        this.m_SourceItemScrollPanel.IntiScrollPanel(237f, 0.0f, 0.0f, _DataHeight, 3, (IUpDateScrollPanel) this);
        this.m_SourceItemScrollPanelRect = this.m_SourceItemScrollPanel.gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        this.UpdatePageType(this.m_FisetItemID);
        this.SetUIState();
        this.GM.ClearSynthesisUIData();
      }
    }
    if (!this._m_MovingExit)
      return;
    float num1 = 0.3f;
    this.MoveDelta = Mathf.Clamp(this.MoveDelta + Time.deltaTime, 0.0f, num1);
    this.m_Step = ((RectTransform) this.m_SynPanel).anchoredPosition;
    this.m_Step.y = EasingEffect.Linear(this.MoveDelta, this.m_BeginMove.y, this.m_EndMove.y - this.m_BeginMove.y, num1);
    ((RectTransform) this.m_SynPanel).anchoredPosition = this.m_Step;
    GUIManager.Instance.m_ItemInfo.UpdatePosition(this.MoveDelta);
    if (!(this.m_Step == this.m_EndMove))
      return;
    --this.PassFrame;
    if (this.PassFrame != (short) -2)
      return;
    ((Component) GUIManager.Instance.m_ItemInfo.m_Background).gameObject.SetActive(true);
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    UIItemInfo itemInfo = GUIManager.Instance.m_ItemInfo;
    GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.HeroEquip, itemInfo.m_ItemID, itemInfo.m_HeroID, itemInfo.m_EquipPos);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    switch (panelId)
    {
      case 1:
        if (dataIdx >= this.m_ItemData.Count)
          break;
        if ((Object) this.m_ItemBtns[panelObjectIdx] == (Object) null)
        {
          Transform child1 = item.transform.GetChild(0);
          this.m_ItemBtns[panelObjectIdx] = child1.GetComponent<UIHIBtn>();
          this.m_ItemBtns[panelObjectIdx].m_BtnID1 = 100;
          this.m_ItemBtns[panelObjectIdx].m_BtnID2 = dataIdx;
          this.m_ItemBtns[panelObjectIdx].m_Handler = (IUIHIBtnClickHandler) this;
          Transform child2 = item.transform.GetChild(2);
          this.m_ItemSelects[panelObjectIdx] = child2.GetComponent<Image>();
        }
        ushort num = this.m_ItemData[dataIdx];
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_ItemBtns[panelObjectIdx]).transform, eHeroOrItem.Item, num, recordByKey.Color, (byte) 0);
        if (dataIdx == this.m_ItemData.Count - 1)
        {
          ((Component) this.m_ItemSelects[panelObjectIdx]).gameObject.SetActive(true);
          break;
        }
        ((Component) this.m_ItemSelects[panelObjectIdx]).gameObject.SetActive(false);
        break;
      case 2:
        if ((Object) this.m_SourceItemBtn1s[panelObjectIdx] == (Object) null)
        {
          this.m_SourceItemBtn1s[panelObjectIdx] = item.transform.GetChild(1);
          this.m_SourceBtn1s[panelObjectIdx] = this.m_SourceItemBtn1s[panelObjectIdx].GetChild(0).GetComponent<UIHIBtn>();
          this.m_SourceBtn1s[panelObjectIdx].m_BtnID1 = 101;
          this.m_SourceBtn1s[panelObjectIdx].m_Handler = (IUIHIBtnClickHandler) this;
          this.m_SourceUIBtn1s[panelObjectIdx] = this.m_SourceItemBtn1s[panelObjectIdx].GetComponent<UIButton>();
          this.m_SourceUIBtn1s[panelObjectIdx].m_BtnID1 = 101;
          this.m_SourceUIBtn1s[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
          this.m_tmpItemtext1[panelObjectIdx][0] = this.m_SourceItemBtn1s[panelObjectIdx].GetChild(2).GetComponent<UIText>();
          this.m_tmpItemtext1[panelObjectIdx][0].font = GUIManager.Instance.GetTTFFont();
          this.m_tmpItemtext1[panelObjectIdx][1] = this.m_SourceItemBtn1s[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
          this.m_tmpItemtext1[panelObjectIdx][1].font = GUIManager.Instance.GetTTFFont();
          this.m_SourceItemBtn2s[panelObjectIdx] = item.transform.GetChild(2);
          this.m_SourceBtn2s[panelObjectIdx] = this.m_SourceItemBtn2s[panelObjectIdx].GetChild(0).GetComponent<UIHIBtn>();
          this.m_SourceBtn2s[panelObjectIdx].m_BtnID1 = 101;
          this.m_SourceBtn2s[panelObjectIdx].m_Handler = (IUIHIBtnClickHandler) this;
          this.m_SourceUIBtn2s[panelObjectIdx] = this.m_SourceItemBtn2s[panelObjectIdx].GetComponent<UIButton>();
          this.m_SourceUIBtn2s[panelObjectIdx].m_BtnID1 = 101;
          this.m_SourceUIBtn2s[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
          this.m_tmpItemtext2[panelObjectIdx][0] = this.m_SourceItemBtn2s[panelObjectIdx].GetChild(2).GetComponent<UIText>();
          this.m_tmpItemtext2[panelObjectIdx][0].font = GUIManager.Instance.GetTTFFont();
          this.m_tmpItemtext2[panelObjectIdx][1] = this.m_SourceItemBtn2s[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
          this.m_tmpItemtext2[panelObjectIdx][1].font = GUIManager.Instance.GetTTFFont();
          this.m_SourceItemBtn3s[panelObjectIdx] = item.transform.GetChild(3);
          this.m_SourceBtn3s[panelObjectIdx] = this.m_SourceItemBtn3s[panelObjectIdx].GetChild(0).GetComponent<UIHIBtn>();
          this.m_SourceBtn3s[panelObjectIdx].m_BtnID1 = 101;
          this.m_SourceBtn3s[panelObjectIdx].m_Handler = (IUIHIBtnClickHandler) this;
          this.m_SourceUIBtn2s[panelObjectIdx] = this.m_SourceItemBtn3s[panelObjectIdx].GetComponent<UIButton>();
          this.m_SourceUIBtn2s[panelObjectIdx].m_BtnID1 = 101;
          this.m_SourceUIBtn2s[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
          this.m_tmpItemtext3[panelObjectIdx][0] = this.m_SourceItemBtn3s[panelObjectIdx].GetChild(2).GetComponent<UIText>();
          this.m_tmpItemtext3[panelObjectIdx][0].font = GUIManager.Instance.GetTTFFont();
          this.m_tmpItemtext3[panelObjectIdx][1] = this.m_SourceItemBtn3s[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
          this.m_tmpItemtext3[panelObjectIdx][1].font = GUIManager.Instance.GetTTFFont();
        }
        ushort index1 = (ushort) (dataIdx * 3);
        if ((int) index1 < this.m_ItemSourceData.Count)
        {
          this.SetStageBtn(this.m_ItemSourceData[(int) index1], this.m_SourceItemBtn1s[panelObjectIdx], this.m_LevelTableKind);
          this.m_SourceItemBtn1s[panelObjectIdx].gameObject.SetActive(true);
        }
        else
          this.m_SourceItemBtn1s[panelObjectIdx].gameObject.SetActive(false);
        ushort index2 = (ushort) (dataIdx * 3 + 1);
        if ((int) index2 < this.m_ItemSourceData.Count)
        {
          this.SetStageBtn(this.m_ItemSourceData[(int) index2], this.m_SourceItemBtn2s[panelObjectIdx], this.m_LevelTableKind);
          this.m_SourceItemBtn2s[panelObjectIdx].gameObject.SetActive(true);
        }
        else
          this.m_SourceItemBtn2s[panelObjectIdx].gameObject.SetActive(false);
        ushort index3 = (ushort) (dataIdx * 3 + 2);
        if ((int) index3 < this.m_ItemSourceData.Count)
        {
          this.SetStageBtn(this.m_ItemSourceData[(int) index3], this.m_SourceItemBtn3s[panelObjectIdx], this.m_LevelTableKind);
          this.m_SourceItemBtn3s[panelObjectIdx].gameObject.SetActive(true);
          break;
        }
        this.m_SourceItemBtn3s[panelObjectIdx].gameObject.SetActive(false);
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 95:
        if (this.m_ItemData.Count <= 0)
          break;
        if (sender.m_BtnID2 == 0)
        {
          DataManager.Instance.SendSynthesis(this.m_ItemData[this.m_ItemData.Count - 1]);
          this.m_ShowTransEffect = true;
          break;
        }
        if (sender.m_BtnID2 == 1)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(2715U), (ushort) byte.MaxValue);
          break;
        }
        if (sender.m_BtnID2 != 2)
          break;
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          break;
        this.bSaveUIState_Money = true;
        menu.OpenMenu(EGUIWindow.UI_BagFilter, 589825, (int) this.MixPrice);
        break;
      case 96:
        if (this.m_LevelTableKind == LevelTableKind.NormalStage)
          break;
        this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.NormalStage);
        break;
      case 97:
        if (this.m_LevelTableKind == LevelTableKind.AdvanceStage)
          break;
        this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.AdvanceStage);
        break;
      case 98:
        if (this.m_ItemData.Count <= 1)
          break;
        this.ReturnItem();
        this.UpdatePageType(this.m_ItemData[this.m_ItemData.Count - 1], false);
        break;
      case 99:
        if ((Object) this.m_TransForm != (Object) null)
        {
          GUIManager.Instance.m_IsOpenedUISynthesis = false;
          GUIManager.Instance.CloseMenu(EGUIWindow.UI_Synthesis);
          break;
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hero_Info, 9);
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
        break;
      case 101:
        if (sender.m_BtnID2 != 0)
        {
          this.bNeedSaveUIState = true;
          GUIManager.Instance.m_ItemInfo.Hide();
          DataManager.StageDataController.SaveCurrentChapter();
          DataManager.StageDataController.currentChapterID = sender.m_BtnID2 % 6 != 0 ? (byte) (sender.m_BtnID2 / 6 + 1) : (byte) (sender.m_BtnID2 / 6);
          if (this.m_LevelTableKind == LevelTableKind.AdvanceStage)
          {
            DataManager.StageDataController._stageMode = StageMode.Lean;
            DataManager.StageDataController.currentPointID = (ushort) sender.m_BtnID2;
          }
          else
          {
            DataManager.StageDataController._stageMode = StageMode.Full;
            DataManager.StageDataController.currentPointID = (ushort) (sender.m_BtnID2 * 3);
          }
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hero_Info, 9);
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_StageInfo, bCameraMode: true);
          GUIManager.Instance.bClearWindowStack = false;
          if (!((Object) this.m_TransForm != (Object) null))
            break;
          GUIManager.Instance.m_IsOpenedUISynthesis = true;
          GUIManager.Instance.m_UISynthesisID = this.m_FisetItemID;
          GUIManager.Instance.CloseMenu(EGUIWindow.UI_Synthesis);
          break;
        }
        Debug.Log((object) "關卡未開放");
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(237U), (ushort) byte.MaxValue);
        break;
      case 102:
        if (!((Object) this.m_HeroItem != (Object) null))
          break;
        UIButtonHint component = ((Component) this.m_HeroItem).GetComponent<UIButtonHint>();
        if (!((Object) component != (Object) null))
          break;
        component.ControlFadeOut = ((Component) GUIManager.Instance.m_SimpleItemInfo.m_RectTransform).gameObject;
        GUIManager.Instance.m_SimpleItemInfo.Show(component, this.m_HeroItem.HIID);
        GUIManager.Instance.HintMaskObj.Show(component);
        GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = (IUIButtonClickHandler) component;
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
        GUIManager.Instance.m_SynthesisItemIdx = (ushort) sender.m_BtnID1;
        this.NowClickIdx = (byte) sender.m_BtnID1;
        this.UpdatePageType((ushort) sender.m_BtnID2);
        break;
      case 100:
        if (((Component) GUIManager.Instance.m_SimpleItemInfo.m_RectTransform).gameObject.activeSelf && (int) sender.HIID == (int) GUIManager.Instance.m_SimpleItemInfo.m_ItemBtn.HIID)
          GUIManager.Instance.m_SimpleItemInfo.m_ButtonHint.SkipDisabelEvent = (byte) 1;
        this.GoTo(sender.m_BtnID2);
        break;
    }
  }

  private void InitUI(Transform tf = null)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((Object) tf != (Object) null)
    {
      this.m_SynPanel = tf.GetChild(0);
      this.m_ExiteBtnImage = tf.GetChild(1).GetComponent<Image>();
      this.m_ExiteBtn = tf.GetChild(1).GetChild(0).GetComponent<UIButton>();
    }
    else
    {
      this.m_SynPanel = this.transform.GetChild(0);
      this.m_ExiteBtnImage = this.transform.GetChild(1).GetComponent<Image>();
      this.m_ExiteBtn = this.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
    }
    if (this.GM.bOpenOnIPhoneX)
    {
      ((RectTransform) this.transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
    }
    HelperUIButton helperUiButton = this.gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 99;
    Object.Destroy((Object) this.m_SynPanel.GetChild(0).GetComponent<IgnoreRaycast>());
    this.m_ExiteBtn.m_BtnID1 = 99;
    this.m_ExiteBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_ExiteBtnImage.sprite = menu.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.m_ExiteBtnImage).material = menu.LoadMaterial();
    this.m_ExiteBtn.image.sprite = menu.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.m_ExiteBtn.image).material = menu.LoadMaterial();
    this.m_HeroItemPanel = this.m_SynPanel.GetChild(1);
    this.m_ItemPanel = this.m_SynPanel.GetChild(2);
    this.m_ItemScrollPanel = this.m_ItemPanel.GetChild(0).GetComponent<ScrollPanel>();
    this.m_RequirementPanel = this.m_SynPanel.GetChild(3);
    this.m_SynthesisBtns = new UIHIBtn[5];
    this.m_SynthesisBtnTexts = new UIText[5];
    this.m_ResultItem = this.m_RequirementPanel.GetChild(1).GetComponent<UIHIBtn>();
    this.m_ResultItemText = this.m_RequirementPanel.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.m_ResultItemText.font = GUIManager.Instance.GetTTFFont();
    this.m_TransBtn = this.m_RequirementPanel.GetChild(7).GetComponent<UIButton>();
    this.m_TransBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TransBtn.m_BtnID1 = 95;
    this.m_NeedMoneyText = this.m_RequirementPanel.GetChild(7).GetChild(1).GetComponent<UIText>();
    this.m_NeedMoneyText.font = GUIManager.Instance.GetTTFFont();
    this.m_tmptext[this.mTextCount] = this.m_RequirementPanel.GetChild(7).GetChild(2).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
    this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(87U);
    ++this.mTextCount;
    this.m_HeroItem = this.m_HeroItemPanel.GetChild(1).GetComponent<UIHIBtn>();
    this.m_HeroItemText = this.m_HeroItemPanel.GetChild(2).GetComponent<UIText>();
    this.m_HeroItemText.font = GUIManager.Instance.GetTTFFont();
    this.m_InfoBtn = this.m_HeroItemPanel.GetChild(3).GetComponent<UIButton>();
    this.m_InfoBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_InfoBtn.m_BtnID1 = 102;
    if (GUIManager.Instance.IsArabic)
      ((Component) this.m_InfoBtn).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_EffectPanel = this.m_RequirementPanel.GetChild(8);
    this.m_EffectImage = new Image[3];
    this.m_EffectImage[0] = this.m_EffectPanel.GetChild(0).GetComponent<Image>();
    this.m_EffectImage[1] = this.m_EffectPanel.GetChild(1).GetComponent<Image>();
    this.m_EffectImage[2] = this.m_EffectPanel.GetChild(2).GetComponent<Image>();
    this.m_EffectImage1Rt = this.m_EffectPanel.GetChild(2).GetComponent<RectTransform>();
    this.m_ItemSourcePanel = this.m_SynPanel.GetChild(4);
    this.m_SourceItemScrollPanel = this.m_ItemSourcePanel.GetChild(4).GetComponent<ScrollPanel>();
    this.m_ReturnBtn = this.m_SynPanel.GetChild(5).GetComponent<UIButton>();
    this.m_ReturnBtn.m_BtnID1 = 98;
    this.m_ReturnBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_tmptext[this.mTextCount] = this.m_SynPanel.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
    this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(196U);
    ++this.mTextCount;
    this.m_ItemSourceName = this.m_SynPanel.GetChild(4).GetChild(3).GetComponent<UIText>();
    this.m_ItemSourceName.font = GUIManager.Instance.GetTTFFont();
    this.m_ArrowImgae = new Transform[2];
    this.m_FuncBtnText = new UIText[2];
    this.m_FuncBtnImage = new Image[2];
    this.m_SourceBtn = new Transform[2];
    this.m_SourceBtn[0] = this.m_SynPanel.GetChild(4).GetChild(5);
    this.m_FuncBtnText[0] = this.m_SynPanel.GetChild(4).GetChild(5).GetChild(0).GetComponent<UIText>();
    this.m_FuncBtnText[0].font = GUIManager.Instance.GetTTFFont();
    this.m_FuncBtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(197U);
    this.m_ArrowImgae[0] = this.m_SynPanel.GetChild(4).GetChild(5).GetChild(1);
    this.m_FuncBtnImage[0] = this.m_SynPanel.GetChild(4).GetChild(5).GetComponent<Image>();
    UIButton component1 = this.m_SynPanel.GetChild(4).GetChild(5).GetComponent<UIButton>();
    component1.m_BtnID1 = 96;
    component1.m_Handler = (IUIButtonClickHandler) this;
    this.m_SourceBtn[1] = this.m_SynPanel.GetChild(4).GetChild(6);
    this.m_FuncBtnText[1] = this.m_SynPanel.GetChild(4).GetChild(6).GetChild(0).GetComponent<UIText>();
    this.m_FuncBtnText[1].font = GUIManager.Instance.GetTTFFont();
    this.m_FuncBtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(198U);
    this.m_ArrowImgae[1] = this.m_SynPanel.GetChild(4).GetChild(6).GetChild(1);
    this.m_FuncBtnImage[1] = this.m_SynPanel.GetChild(4).GetChild(6).GetComponent<Image>();
    UIButton component2 = this.m_SynPanel.GetChild(4).GetChild(6).GetComponent<UIButton>();
    component2.m_BtnID1 = 97;
    component2.m_Handler = (IUIButtonClickHandler) this;
    this.m_SourceText = this.m_SynPanel.GetChild(4).GetChild(7).GetComponent<UIText>();
    this.m_SourceText.font = GUIManager.Instance.GetTTFFont();
    for (int index = 1; index <= 3; ++index)
    {
      Image component3 = this.m_SynPanel.GetChild(7).GetChild(index).GetChild(1).GetComponent<Image>();
      component3.sprite = GUIManager.Instance.LoadFrameSprite("UI_complex_box_006");
      ((MaskableGraphic) component3).material = GUIManager.Instance.GetFrameMaterial();
      this.m_tmptext[this.mTextCount] = this.m_SynPanel.GetChild(7).GetChild(index).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
      this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(198U);
      ++this.mTextCount;
      Image component4 = this.m_SynPanel.GetChild(7).GetChild(index).GetChild(3).GetComponent<Image>();
      component4.sprite = GUIManager.Instance.LoadFrameSprite("UI_black_top");
      ((MaskableGraphic) component4).material = GUIManager.Instance.GetFrameMaterial();
    }
    this.m_ItemBtns = new UIHIBtn[this.m_MaxItemPanelObject];
    this.m_ItemSelects = new Image[this.m_MaxItemPanelObject];
    this.m_SourceItemBtn1s = new Transform[3];
    this.m_SourceItemBtn2s = new Transform[3];
    this.m_SourceItemBtn3s = new Transform[3];
    for (int index = 0; index < 3; ++index)
    {
      this.m_tmpItemtext1[index] = new UIText[2];
      this.m_tmpItemtext2[index] = new UIText[2];
      this.m_tmpItemtext3[index] = new UIText[2];
    }
    this.m_SourceBtn1s = new UIHIBtn[3];
    this.m_SourceBtn2s = new UIHIBtn[3];
    this.m_SourceBtn3s = new UIHIBtn[3];
    this.m_SourceUIBtn1s = new UIButton[3];
    this.m_SourceUIBtn2s = new UIButton[3];
    this.m_SourceUIBtn3s = new UIButton[3];
  }

  private void InitHintn()
  {
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_ResultItem).transform, eHeroOrItem.Item, (ushort) 1, (byte) 1, (byte) 0, bShowText: false);
    for (int index = 0; index < 5; ++index)
    {
      this.m_SynthesisBtnTexts[index] = this.m_RequirementPanel.GetChild(index + 2).GetChild(0).GetComponent<UIText>();
      this.m_SynthesisBtnTexts[index].font = GUIManager.Instance.GetTTFFont();
      this.m_SynthesisBtns[index] = this.m_RequirementPanel.GetChild(index + 2).GetComponent<UIHIBtn>();
      this.m_SynthesisBtns[index].m_BtnID1 = index;
      this.m_SynthesisBtns[index].m_Handler = (IUIHIBtnClickHandler) this;
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_SynthesisBtns[index]).transform, eHeroOrItem.Item, (ushort) 1, (byte) 1, (byte) 0, bShowText: false, bAutoShowHint: false);
    }
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_HeroItem).transform, eHeroOrItem.Item, (ushort) 1, (byte) 1, (byte) 0, bShowText: false);
    this.m_Item = this.m_SynPanel.GetChild(6).GetChild(0).GetComponent<UIHIBtn>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_Item).transform, eHeroOrItem.Item, this.m_FisetItemID, (byte) 1, (byte) 0, bShowText: false);
    this.m_ItemSource1 = this.m_SynPanel.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
    ((Component) this.m_ItemSource1).gameObject.AddComponent<IgnoreRaycast>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_ItemSource1).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0, bShowText: false, bAutoShowHint: false);
    Image image1 = this.m_SynPanel.GetChild(7).GetChild(1).gameObject.AddComponent<Image>();
    ((MaskableGraphic) image1).material = GUIManager.Instance.GetFrameMaterial();
    ((Graphic) image1).color = new Color(1f, 1f, 1f, 0.0f);
    this.m_SynPanel.GetChild(7).GetChild(1).gameObject.AddComponent<UIButton>();
    this.m_ItemSource2 = this.m_SynPanel.GetChild(7).GetChild(2).GetChild(0).GetComponent<UIHIBtn>();
    ((Component) this.m_ItemSource2).gameObject.AddComponent<IgnoreRaycast>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_ItemSource2).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0, bShowText: false, bAutoShowHint: false);
    Image image2 = this.m_SynPanel.GetChild(7).GetChild(2).gameObject.AddComponent<Image>();
    ((MaskableGraphic) image2).material = GUIManager.Instance.GetFrameMaterial();
    ((Graphic) image2).color = new Color(1f, 1f, 1f, 0.0f);
    this.m_SynPanel.GetChild(7).GetChild(2).gameObject.AddComponent<UIButton>();
    this.m_ItemSource3 = this.m_SynPanel.GetChild(7).GetChild(3).GetChild(0).GetComponent<UIHIBtn>();
    ((Component) this.m_ItemSource3).gameObject.AddComponent<IgnoreRaycast>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_ItemSource3).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 0, bShowText: false, bAutoShowHint: false);
    Image image3 = this.m_SynPanel.GetChild(7).GetChild(3).gameObject.AddComponent<Image>();
    ((MaskableGraphic) image3).material = GUIManager.Instance.GetFrameMaterial();
    ((Graphic) image3).color = new Color(1f, 1f, 1f, 0.0f);
    this.m_SynPanel.GetChild(7).GetChild(3).gameObject.AddComponent<UIButton>();
  }

  private void UpdatePageType(ushort itemID, bool bAdd = true)
  {
    bool flag = true;
    this.m_PageType = e_SynPageType.Synthesis;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
    byte num = (byte) ((uint) recordByKey.EquipKind - 1U);
    if (num >= (byte) 0 && num <= (byte) 2)
    {
      int length = recordByKey.SyntheticParts.Length;
      for (int index = 0; index < length; ++index)
      {
        if (recordByKey.SyntheticParts[index].SyntheticItem != (ushort) 0)
        {
          flag = false;
          break;
        }
      }
      if (flag)
        this.m_PageType = e_SynPageType.ItemSource;
    }
    else
      this.m_PageType = num != (byte) 3 ? e_SynPageType.HeroSource : e_SynPageType.FragmentSource;
    this.TypeChange(itemID, bAdd);
  }

  private void TypeChange(ushort itemID, bool bAdd = true)
  {
    if (this.m_PageType == e_SynPageType.Synthesis)
    {
      if (bAdd)
        this.AddItem(itemID);
      this.UpdateRequirementPanel(itemID);
      this.m_ItemPanel.gameObject.SetActive(true);
      this.m_HeroItemPanel.gameObject.SetActive(false);
      this.m_ItemSourcePanel.gameObject.SetActive(false);
      this.m_RequirementPanel.gameObject.SetActive(true);
    }
    else if (this.m_PageType == e_SynPageType.ItemSource || this.m_PageType == e_SynPageType.FragmentSource)
    {
      if (bAdd)
        this.AddItem(itemID);
      this.m_SourceItemPanelID = itemID;
      this.SetLevelTableKind(itemID, this.m_LevelTableKind);
      this.m_ItemPanel.gameObject.SetActive(true);
      this.m_HeroItemPanel.gameObject.SetActive(false);
      this.m_ItemSourcePanel.gameObject.SetActive(true);
      this.m_RequirementPanel.gameObject.SetActive(false);
      this.m_SourceBtn[0].gameObject.SetActive(true);
      this.m_SourceBtn[1].gameObject.SetActive(true);
      ((RectTransform) this.m_SourceBtn[1]).anchoredPosition = new Vector2(644f, -524.5f);
    }
    else if (this.m_PageType == e_SynPageType.HeroSource)
    {
      this.m_SourceBtn[0].gameObject.SetActive(false);
      this.m_SourceBtn[1].gameObject.SetActive(true);
      this.m_SourceItemPanelID = itemID;
      this.m_HeroItemPanel.gameObject.SetActive(true);
      this.UpdateHeroItemPanel(this.m_SourceItemPanelID);
      this.m_ItemPanel.gameObject.SetActive(false);
      this.SetLevelTableKind(itemID, LevelTableKind.AdvanceStage);
      this.m_ItemSourcePanel.gameObject.SetActive(true);
      this.m_RequirementPanel.gameObject.SetActive(false);
      ((RectTransform) this.m_SourceBtn[1]).anchoredPosition = new Vector2(644f, -451.5f);
    }
    if (this.m_ItemData.Count > 1)
      ((Component) this.m_ReturnBtn).gameObject.SetActive(true);
    else
      ((Component) this.m_ReturnBtn).gameObject.SetActive(false);
  }

  private void UpdateRequirementPanel(ushort resItemID)
  {
    this.MixPrice = 0U;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(resItemID);
    byte color = recordByKey.Color;
    this.m_TransBtn.m_BtnID2 = 0;
    this.m_TransBtn.ForTextChange(e_BtnType.e_Normal);
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_ResultItem).transform, eHeroOrItem.Item, resItemID, color, (byte) 0);
    this.m_ResultItemText.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName);
    this.MixPrice = recordByKey.MixPrice;
    for (int index1 = 0; index1 < 5; ++index1)
    {
      ushort syntheticItem = recordByKey.SyntheticParts[index1].SyntheticItem;
      ushort syntheticItemNum = (ushort) recordByKey.SyntheticParts[index1].SyntheticItemNum;
      ushort num1 = syntheticItemNum;
      for (int index2 = 0; index2 < 5; ++index2)
      {
        if (index1 != index2 && (int) syntheticItem == (int) recordByKey.SyntheticParts[index2].SyntheticItem)
          num1 += (ushort) recordByKey.SyntheticParts[index2].SyntheticItemNum;
      }
      if (syntheticItem != (ushort) 0)
      {
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_SynthesisBtns[index1]).transform, eHeroOrItem.Item, syntheticItem, (byte) 0, (byte) 0);
        ((Component) this.m_SynthesisBtns[index1]).gameObject.SetActive(true);
        this.m_SynthesisBtns[index1].m_BtnID2 = (int) syntheticItem;
        ushort num2 = DataManager.Instance.GetCurItemQuantity(syntheticItem, (byte) 0);
        if ((int) num2 < (int) num1)
        {
          for (int index3 = 0; index3 < index1; ++index3)
          {
            if (index1 != index3 && (int) syntheticItem == (int) recordByKey.SyntheticParts[index3].SyntheticItem && (int) num2 >= (int) recordByKey.SyntheticParts[index1].SyntheticItemNum)
              num2 -= (ushort) recordByKey.SyntheticParts[index1].SyntheticItemNum;
          }
        }
        if (num2 < (ushort) 0)
          num2 = (ushort) 0;
        this.sb.Length = 0;
        if (index1 < this.Fragment.Length)
        {
          this.Fragment[index1] = num2;
          this.FragmentMax[index1] = syntheticItemNum;
          this.RequirementNum[index1] = num1;
        }
        if ((int) num2 >= (int) syntheticItemNum)
        {
          if (this.GM.IsArabic)
            this.sb.AppendFormat("{0} / {1}", (object) syntheticItemNum, (object) num2);
          else
            this.sb.AppendFormat("{0} / {1}", (object) num2, (object) syntheticItemNum);
        }
        else
        {
          this.m_TransBtn.m_BtnID2 = 1;
          this.m_TransBtn.ForTextChange(e_BtnType.e_ChangeText);
          if (this.GM.IsArabic)
            this.sb.AppendFormat("{0} / <color=#FF0000>{1}</color>", (object) syntheticItemNum, (object) num2);
          else
            this.sb.AppendFormat("<color=#FF0000>{0}</color> / {1}", (object) num2, (object) syntheticItemNum);
        }
        this.m_SynthesisBtnTexts[index1].text = this.sb.ToString();
        ((Component) this.m_SynthesisBtnTexts[index1]).gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.m_SynthesisBtns[index1]).gameObject.SetActive(false);
        ((Component) this.m_SynthesisBtnTexts[index1]).gameObject.SetActive(false);
      }
    }
    this.m_NeedMoneyText.text = this.MixPrice.ToString();
    if (this.MixPrice > DataManager.Instance.Resource[4].Stock)
    {
      this.m_TransBtn.ForTextChange(e_BtnType.e_ChangeText);
      this.m_TransBtn.m_BtnID2 = 2;
    }
    GUIManager.Instance.m_ItemInfo.UpdateSynthesis();
  }

  private bool UpdateSourceItemPanel(ushort resItemID, LevelTableKind kind)
  {
    int num1 = 0;
    int tableCount = DataManager.StageDataController.LevelTable[(int) kind].TableCount;
    bool flag = false;
    this.m_ItemSourceData.Clear();
    for (int Index = 0; Index < tableCount; ++Index)
    {
      Level recordByIndex = DataManager.StageDataController.LevelTable[(int) kind].GetRecordByIndex(Index);
      for (int index = 0; index < 7; ++index)
      {
        RewardScore recordByKey = DataManager.Instance.RewardScoreTable.GetRecordByKey(recordByIndex.TreasureNo);
        if (recordByKey.Rewards != null && (int) recordByKey.Rewards[index] == (int) resItemID)
        {
          this.m_ItemSourceData.Add(recordByIndex.LevelKey);
          ++num1;
          break;
        }
      }
    }
    int num2 = this.m_ItemSourceData.Count % 3 != 0 ? this.m_ItemSourceData.Count / 3 + 1 : this.m_ItemSourceData.Count / 3;
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < num2; ++index)
      _DataHeight.Add(this.m_SourceItemHeight);
    this.m_SourceItemScrollPanel.AddNewDataHeight(_DataHeight);
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(resItemID);
    this.m_ItemSourceNameStr.ClearString();
    UIItemInfo.SetNameProperties(this.m_ItemSourceName, (UIText) null, this.m_ItemSourceNameStr, (CString) null, ref recordByKey1);
    ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(resItemID, (byte) 0);
    if (this.m_PageType == e_SynPageType.FragmentSource && (int) this.NowClickIdx < this.Fragment.Length)
    {
      this.sb.Length = 0;
      if ((int) curItemQuantity < (int) this.FragmentMax[(int) this.NowClickIdx])
        this.sb.AppendFormat("{0} <color=#FF0000>{1}</color><color=#FFFFFF> / {2}</color>", (object) this.m_ItemSourceName.text, (object) curItemQuantity, (object) this.FragmentMax[(int) this.NowClickIdx]);
      else
        this.sb.AppendFormat("{0} <color=#FFFFFF>{1}</color><color=#FFFFFF> / {2}</color>", (object) this.m_ItemSourceName.text, (object) curItemQuantity, (object) this.FragmentMax[(int) this.NowClickIdx]);
      this.m_ItemSourceName.text = this.sb.ToString();
    }
    if (recordByKey1.SyntheticParts != null && recordByKey1.SyntheticParts[1].SyntheticItem != (ushort) 0)
    {
      ((Behaviour) this.m_SourceText).enabled = true;
      this.m_SourceText.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey1.SyntheticParts[1].SyntheticItem);
      flag = true;
    }
    else
      ((Behaviour) this.m_SourceText).enabled = false;
    return flag;
  }

  private void UpdateHeroItemPanel(ushort itemID)
  {
    ushort[] numArray = new ushort[5]
    {
      (ushort) 10,
      (ushort) 30,
      (ushort) 80,
      (ushort) 180,
      (ushort) 330
    };
    bool flag = false;
    ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(itemID, (byte) 0);
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
    if (recordByKey1.SyntheticParts == null)
      return;
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_HeroItem).gameObject.transform, eHeroOrItem.Item, itemID, recordByKey1.Color, (byte) 0);
    ushort syntheticItemNum = (ushort) recordByKey1.SyntheticParts[0].SyntheticItemNum;
    this.sb.Length = 0;
    Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey1.SyntheticParts[0].SyntheticItem);
    if (!DataManager.Instance.curHeroData.ContainsKey((uint) recordByKey1.SyntheticParts[0].SyntheticItem))
    {
      if (recordByKey2.defaultStar >= (byte) 1 && (int) recordByKey2.defaultStar - 1 < numArray.Length)
        syntheticItemNum = numArray[(int) recordByKey2.defaultStar - 1];
    }
    else
    {
      CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint) recordByKey2.HeroKey];
      int length = DataManager.Instance.Medal.Length;
      if (curHeroData.Star >= (byte) 0 && (int) curHeroData.Star < length)
        syntheticItemNum = (ushort) DataManager.Instance.Medal[(int) curHeroData.Star];
      else
        flag = true;
    }
    if (!flag)
    {
      if ((int) curItemQuantity >= (int) syntheticItemNum)
      {
        if (this.GM.IsArabic)
          this.sb.AppendFormat("{0} / {1}", (object) syntheticItemNum, (object) curItemQuantity);
        else
          this.sb.AppendFormat("{0} / {1}", (object) curItemQuantity, (object) syntheticItemNum);
      }
      else if (this.GM.IsArabic)
        this.sb.AppendFormat("{0} / <color=#FF0000>{1}</color>", (object) syntheticItemNum, (object) curItemQuantity);
      else
        this.sb.AppendFormat("<color=#FF0000>{0}</color> / {1}", (object) curItemQuantity, (object) syntheticItemNum);
    }
    else
      this.sb.AppendFormat("{0} {1}", (object) DataManager.Instance.mStringTable.GetStringByID(281U), (object) curItemQuantity);
    this.m_HeroItemText.text = this.sb.ToString();
  }

  private void SetStageBtn(ushort stageKey, Transform btn, LevelTableKind kind)
  {
    HeroTeam recordByKey1 = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.StageDataController.LevelTable[(int) kind].GetRecordByKey(stageKey).Team[2]);
    int length = recordByKey1.Arrays.Length;
    for (int index = 0; index < length; ++index)
    {
      if (recordByKey1.Arrays[index].Type == (byte) 3)
      {
        GUIManager.Instance.ChangeHeroItemImg(btn.GetChild(0), eHeroOrItem.Hero, recordByKey1.Arrays[index].Hero, recordByKey1.HeroStar, (byte) 0);
        this.m_tmpStr1 = btn.GetChild(2).GetComponent<UIText>();
        this.sb.Length = 0;
        int num1 = (int) stageKey % 6 != 0 ? (int) stageKey / 6 + 1 : (int) stageKey / 6;
        int num2 = (int) stageKey % 6 != 0 ? (int) stageKey % 6 : 6;
        if (this.GM.IsArabic)
          this.sb.AppendFormat("{1}-{0}", (object) num1, (object) (num2 * 3));
        else
          this.sb.AppendFormat("{0}-{1}", (object) num1, (object) (num2 * 3));
        this.m_tmpStr1.text = this.sb.ToString();
        ushort num3 = kind != LevelTableKind.NormalStage ? DataManager.StageDataController.StageRecord[1] : DataManager.StageDataController.StageRecord[0];
        ushort num4 = kind != LevelTableKind.NormalStage ? stageKey : (ushort) ((uint) stageKey * 3U);
        int num5 = 0;
        if (this.m_LevelTableKind == LevelTableKind.NormalStage)
          num5 = DataManager.StageDataController.GetStagePoint((ushort) ((uint) stageKey * 3U), (byte) 1);
        else if (this.m_LevelTableKind == LevelTableKind.AdvanceStage)
          num5 = DataManager.StageDataController.GetStagePoint(stageKey, (byte) 2);
        if ((int) num4 <= (int) num3 && num5 > 0)
        {
          btn.GetComponent<UIButton>().m_BtnID2 = (int) stageKey;
          ((Graphic) btn.GetChild(0).GetChild(0).GetComponent<Image>()).color = new Color(1f, 1f, 1f);
          if (kind == LevelTableKind.AdvanceStage)
          {
            btn.GetChild(1).gameObject.SetActive(true);
            btn.GetChild(3).gameObject.SetActive(true);
            this.m_tmpStr2 = btn.GetChild(3).GetChild(0).GetComponent<UIText>();
            int num6 = (int) DataManager.StageDataController.StageInfo[1][(int) stageKey - 1] >> 2 & 63;
            VIP_DataTbl recordByKey2 = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort) DataManager.Instance.RoleAttr.VIPLevel);
            if (recordByKey2.DailyResetElite == byte.MaxValue)
            {
              this.m_tmpStr2.resizeTextMaxSize = 30;
              this.m_tmpStr2.text = DataManager.Instance.mStringTable.GetStringByID(5808U);
              ((Graphic) this.m_tmpStr2).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_tmpStr2).rectTransform.sizeDelta.x, 36f);
              break;
            }
            this.m_tmpStr2.resizeTextMaxSize = 20;
            ((Graphic) this.m_tmpStr2).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_tmpStr2).rectTransform.sizeDelta.x, 26f);
            int num7 = (int) recordByKey2.DailyResetElite - num6;
            this.sb.Length = 0;
            if (num7 <= 0)
            {
              if (this.GM.IsArabic)
                this.sb.AppendFormat("{0} / <color=#FF0000>{1}</color>", (object) recordByKey2.DailyResetElite, (object) num7);
              else
                this.sb.AppendFormat("<color=#FF0000>{0}</color> / {1}", (object) num7, (object) recordByKey2.DailyResetElite);
            }
            else if (this.GM.IsArabic)
              this.sb.AppendFormat("{0} / {1}", (object) recordByKey2.DailyResetElite, (object) num7);
            else
              this.sb.AppendFormat("{0} / {1}", (object) num7, (object) recordByKey2.DailyResetElite);
            this.m_tmpStr2.text = this.sb.ToString();
            break;
          }
          btn.GetChild(3).gameObject.SetActive(false);
          btn.GetChild(1).gameObject.SetActive(false);
          break;
        }
        btn.GetComponent<UIButton>().m_BtnID2 = 0;
        ((Graphic) btn.GetChild(0).GetChild(0).GetComponent<Image>()).color = new Color(0.5f, 0.5f, 0.5f);
        if (kind == LevelTableKind.AdvanceStage)
          btn.GetChild(1).gameObject.SetActive(true);
        else
          btn.GetChild(1).gameObject.SetActive(false);
        btn.GetChild(3).gameObject.SetActive(false);
        break;
      }
    }
  }

  private void SetLevelTableKind(ushort resItemID, LevelTableKind kind)
  {
    this.m_LevelTableKind = kind;
    bool flag = this.UpdateSourceItemPanel(resItemID, this.m_LevelTableKind);
    this.m_ArrowImgae[0].gameObject.SetActive(false);
    this.m_ArrowImgae[1].gameObject.SetActive(false);
    ((Graphic) this.m_FuncBtnText[0]).color = new Color(0.7f, 0.7f, 0.7f, 1f);
    ((Graphic) this.m_FuncBtnText[1]).color = new Color(0.7f, 0.7f, 0.7f, 1f);
    ((Graphic) this.m_FuncBtnImage[0]).color = new Color(0.7f, 0.7f, 0.7f, 1f);
    ((Graphic) this.m_FuncBtnImage[1]).color = new Color(0.7f, 0.7f, 0.7f, 1f);
    if (kind == LevelTableKind.AdvanceStage)
    {
      if (flag)
      {
        this.m_SourceBtn[1].gameObject.SetActive(false);
        this.m_ArrowImgae[1].gameObject.SetActive(false);
      }
      else
        this.m_ArrowImgae[1].gameObject.SetActive(true);
      ((Graphic) this.m_FuncBtnText[1]).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.m_FuncBtnImage[1]).color = new Color(1f, 1f, 1f, 1f);
    }
    else
    {
      this.m_ArrowImgae[0].gameObject.SetActive(true);
      ((Graphic) this.m_FuncBtnText[0]).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.m_FuncBtnImage[0]).color = new Color(1f, 1f, 1f, 1f);
    }
  }

  private void AddItem(ushort itemID)
  {
    this.m_ItemData.Add(itemID);
    int count = this.m_ItemData.Count;
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < count; ++index)
      _DataHeight.Add(this.m_ItemHeight);
    this.m_ItemScrollPanel.AddNewDataHeight(_DataHeight);
  }

  private void ReturnItem()
  {
    int index1 = this.m_ItemData.Count - 1;
    if (index1 < 0 || index1 >= this.m_ItemData.Count)
      return;
    this.m_ItemData.RemoveAt(index1);
    List<float> _DataHeight = new List<float>();
    for (int index2 = 0; index2 < this.m_ItemData.Count; ++index2)
      _DataHeight.Add(this.m_ItemHeight);
    this.m_ItemScrollPanel.AddNewDataHeight(_DataHeight);
    if (_DataHeight.Count > 1)
      ((Component) this.m_ReturnBtn).gameObject.SetActive(true);
    else
      ((Component) this.m_ReturnBtn).gameObject.SetActive(false);
  }

  private void GoTo(int idx)
  {
    ushort itemID = this.m_ItemData[idx];
    int num = this.m_ItemData.Count - 1;
    this.m_ItemData.RemoveRange(idx, this.m_ItemData.Count - idx);
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_ItemData.Count; ++index)
      _DataHeight.Add(this.m_ItemHeight);
    this.m_ItemScrollPanel.AddNewDataHeight(_DataHeight);
    this.UpdatePageType(itemID);
  }

  public override bool OnBackButtonClick()
  {
    if (((Component) GUIManager.Instance.m_ItemInfo.m_RectTransform).gameObject.activeSelf)
      GUIManager.Instance.m_ItemInfo.Hide();
    return false;
  }

  public void SaveUIState()
  {
    int count = this.m_ItemData.Count;
    for (int index = 1; index < count; ++index)
      this.GM.m_SynthesisItemData.Add(this.m_ItemData[index]);
    this.GM.m_SynthesisPageType = this.m_PageType;
    this.GM.m_SynthesisScrollIdx = this.m_SourceItemScrollPanel.GetTopIdx();
    this.GM.m_SynthesisScrollRectY = this.m_SourceItemScrollPanelRect.anchoredPosition.y;
    this.GM.m_SynthesisBtnType = this.m_LevelTableKind;
    for (int index = 0; index < this.RequirementNum.Length; ++index)
      this.GM.m_RequirementNum[index] = this.RequirementNum[index];
  }

  public void SetUIState()
  {
    if (this.m_PageType != e_SynPageType.HeroSource)
      this.m_PageType = GUIManager.Instance.m_SynthesisPageType;
    int count = this.GM.m_SynthesisItemData.Count;
    if (this.m_PageType != e_SynPageType.HeroSource)
    {
      this.m_LevelTableKind = this.GM.m_SynthesisBtnType;
      if (this.m_LevelTableKind == LevelTableKind.NormalStage)
        this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.NormalStage);
      else
        this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.AdvanceStage);
    }
    for (int index = 0; index < count; ++index)
      this.UpdatePageType(this.GM.m_SynthesisItemData[index]);
    ushort synthesisItemIdx = GUIManager.Instance.m_SynthesisItemIdx;
    if (this.GM.m_RequirementNum[(int) synthesisItemIdx] != (ushort) 0 && (int) this.Fragment[(int) synthesisItemIdx] >= (int) this.GM.m_RequirementNum[(int) synthesisItemIdx])
    {
      if (this.m_PageType != e_SynPageType.Synthesis)
        this.ReturnItem();
      if (this.m_ItemData.Count > 0)
        this.UpdatePageType(this.m_ItemData[this.m_ItemData.Count - 1], false);
    }
    this.m_SourceItemScrollPanel.GoTo(this.GM.m_SynthesisScrollIdx, this.GM.m_SynthesisScrollRectY);
  }
}
