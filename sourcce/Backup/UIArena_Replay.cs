// Decompiled with JetBrains decompiler
// Type: UIArena_Replay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIArena_Replay : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private ArenaManager AM;
  private Transform GameT;
  private Transform ItemT;
  private Door door;
  private Font TTFont;
  private UISpritesArray SArray;
  private UIButton btn_EXIT;
  private UIButton[] tmpItemBtn = new UIButton[7];
  private UIButton[] tmpItemHintBtn = new UIButton[7];
  private UIHIBtn tmpHIBtn;
  private UIHIBtn[] tmpItemHIBtn = new UIHIBtn[7];
  private Image Img_NoReplay;
  private Image[] Img_ItmeRank = new Image[7];
  private Image[] Img_ItmeNew = new Image[7];
  private Image[] Img_ItmeHint = new Image[7];
  private UIText text_Title;
  private UIText text_NoReplay;
  private UIText[] tmpText = new UIText[7];
  private UIText[] text_ItmeRank = new UIText[7];
  private UIText[] text_ItmeResult_W = new UIText[7];
  private UIText[] text_ItmeResult_L = new UIText[7];
  private UIText[] text_ItmeTime = new UIText[7];
  private UIText[] text_ItmeName = new UIText[7];
  private UIText[] text_ItmeHint = new UIText[7];
  private CString[] Cstr_Rank = new CString[7];
  private CString[] Cstr_Name = new CString[7];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[7];
  private List<float> tmplist = new List<float>();
  private bool bOpen = true;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.AM = ArenaManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    for (int index = 0; index < 7; ++index)
    {
      this.Cstr_Rank[index] = StringManager.Instance.SpawnString();
      this.Cstr_Name[index] = StringManager.Instance.SpawnString();
    }
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Material material = this.door.LoadMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.text_Title = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(9122U);
    Transform child1 = this.GameT.GetChild(1);
    this.m_ScrollPanel = child1.GetChild(0).GetComponent<ScrollPanel>();
    Transform child2 = child1.GetChild(1);
    this.tmpHIBtn = child2.GetChild(3).GetComponent<UIHIBtn>();
    ((Component) this.tmpHIBtn).gameObject.AddComponent<IgnoreRaycast>();
    this.GUIM.InitianHeroItemImg(((Component) this.tmpHIBtn).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.tmpText[0] = child2.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.tmpText[0].font = this.TTFont;
    this.tmpText[0].text = this.DM.mStringTable.GetStringByID(6048U);
    UIButton component1 = child2.GetChild(5).GetComponent<UIButton>();
    component1.m_BtnID1 = 1;
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.SoundIndex = (byte) 64;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
    child2.GetChild(5).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    UIButton component2 = child2.GetChild(6).GetComponent<UIButton>();
    component2.m_BtnID1 = 2;
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.SoundIndex = (byte) 64;
    UIButtonHint uiButtonHint = ((Component) component2).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    this.tmpText[1] = child2.GetChild(7).GetComponent<UIText>();
    this.tmpText[1].font = this.TTFont;
    this.tmpText[2] = child2.GetChild(8).GetComponent<UIText>();
    this.tmpText[2].font = this.TTFont;
    this.tmpText[2].text = this.DM.mStringTable.GetStringByID(9123U);
    this.tmpText[3] = child2.GetChild(9).GetComponent<UIText>();
    this.tmpText[3].font = this.TTFont;
    this.tmpText[3].text = this.DM.mStringTable.GetStringByID(9124U);
    this.tmpText[4] = child2.GetChild(10).GetComponent<UIText>();
    this.tmpText[4].font = this.TTFont;
    this.tmpText[5] = child2.GetChild(11).GetComponent<UIText>();
    this.tmpText[5].font = this.TTFont;
    this.tmpText[6] = child2.GetChild(12).GetChild(0).GetComponent<UIText>();
    this.tmpText[6].font = this.TTFont;
    this.tmplist.Clear();
    for (int index = 0; index < this.AM.m_ArenaReportData.Count; ++index)
      this.tmplist.Add(95f);
    this.m_ScrollPanel.IntiScrollPanel(509f, 0.0f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
    Transform child3 = this.GameT.GetChild(2);
    this.Img_NoReplay = child3.GetComponent<Image>();
    this.text_NoReplay = child3.GetChild(0).GetComponent<UIText>();
    this.text_NoReplay.font = this.TTFont;
    this.text_NoReplay.text = this.DM.mStringTable.GetStringByID(9156U);
    if (this.AM.m_ArenaReportData.Count > 0)
    {
      this.m_ScrollPanel.gameObject.SetActive(true);
      ((Component) this.Img_NoReplay).gameObject.SetActive(false);
    }
    else
    {
      this.m_ScrollPanel.gameObject.SetActive(false);
      ((Component) this.Img_NoReplay).gameObject.SetActive(true);
    }
    Image component3 = this.GameT.GetChild(3).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component3).material = material;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component3).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(3).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    for (int index = 0; index < 7; ++index)
    {
      if (this.Cstr_Rank[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Rank[index]);
      if (this.Cstr_Name[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Name[index]);
    }
    ArenaReportDataType arenaReportDataType1 = new ArenaReportDataType();
    for (int index = 0; index < this.AM.m_ArenaReportData.Count; ++index)
    {
      if (((int) this.AM.m_ArenaReportData[index].Flag >> 2 & 1) == 0)
      {
        ArenaReportDataType arenaReportDataType2 = this.AM.m_ArenaReportData[index];
        arenaReportDataType2.Flag += (byte) 4;
        this.AM.m_ArenaReportData[index] = arenaReportDataType2;
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((GUIArena_Replay) sender.m_BtnID1)
    {
      case GUIArena_Replay.btn_EXIT:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case GUIArena_Replay.btn_Replay:
        int btnId1 = ((Component) sender).gameObject.transform.parent.GetComponent<ScrollPanelItem>().m_BtnID1;
        if (!this.AM.SetReportIDToPlayingData(btnId1) || !WarManager.CheckVersion(this.AM.ArenaPlayingData.SimulatorVersion, this.AM.ArenaPlayingData.SimulatorPatchNo))
          break;
        int index1 = btnId1;
        if (this.AM.m_ArenaReportData.Count > index1)
          index1 = this.AM.m_ArenaReportData.Count - 1 - index1;
        ushort[] battleHeroID = new ushort[10];
        for (int index2 = 0; index2 < 5; ++index2)
          battleHeroID[index2] = this.AM.m_ArenaReportData[index1].MyHeroData[index2].ID;
        for (int index3 = 0; index3 < 5; ++index3)
          battleHeroID[index3 + 5] = this.AM.m_ArenaReportData[index1].EnemyHeroData[index3].ID;
        if (!this.DM.CheckHeroBattleResourceReady(HeroFightType.HeorArena, battleHeroID))
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
          break;
        }
        GUIManager instance = GUIManager.Instance;
        instance.bClearWindowStack = false;
        BattleController.BattleMode = EBattleMode.PVP_Replay;
        instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MonsterBattle);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    this.ItemT = item.GetComponent<Transform>();
    if ((UnityEngine.Object) this.tmpItem[panelObjectIdx] == (UnityEngine.Object) null)
    {
      this.Img_ItmeRank[panelObjectIdx] = this.ItemT.GetChild(1).GetComponent<Image>();
      this.tmpItemHIBtn[panelObjectIdx] = this.ItemT.GetChild(3).GetComponent<UIHIBtn>();
      this.Img_ItmeNew[panelObjectIdx] = this.ItemT.GetChild(4).GetComponent<Image>();
      this.tmpItemBtn[panelObjectIdx] = this.ItemT.GetChild(5).GetComponent<UIButton>();
      this.tmpItemBtn[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.tmpItemHintBtn[panelObjectIdx] = this.ItemT.GetChild(6).GetComponent<UIButton>();
      this.tmpItemHintBtn[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.tmpItemHintBtn[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      this.text_ItmeRank[panelObjectIdx] = this.ItemT.GetChild(7).GetComponent<UIText>();
      this.text_ItmeResult_W[panelObjectIdx] = this.ItemT.GetChild(8).GetComponent<UIText>();
      this.text_ItmeResult_L[panelObjectIdx] = this.ItemT.GetChild(9).GetComponent<UIText>();
      this.text_ItmeTime[panelObjectIdx] = this.ItemT.GetChild(10).GetComponent<UIText>();
      this.text_ItmeName[panelObjectIdx] = this.ItemT.GetChild(11).GetComponent<UIText>();
      this.Img_ItmeHint[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<Image>();
      this.text_ItmeHint[panelObjectIdx] = this.ItemT.GetChild(12).GetChild(0).GetComponent<UIText>();
      UIButtonHint component = this.ItemT.GetChild(6).GetComponent<UIButtonHint>();
      component.m_Handler = (MonoBehaviour) this;
      component.ControlFadeOut = ((Component) this.Img_ItmeHint[panelObjectIdx]).gameObject;
    }
    if (dataIdx >= this.AM.m_ArenaReportData.Count)
      return;
    int index = this.AM.m_ArenaReportData.Count - 1 - dataIdx;
    if (((int) this.AM.m_ArenaReportData[index].Flag >> 1 & 1) == 1 && ((int) this.AM.m_ArenaReportData[index].Flag & 1) == 0)
    {
      ((Component) this.Img_ItmeRank[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.text_ItmeRank[panelObjectIdx]).gameObject.SetActive(false);
    }
    else
    {
      if (this.AM.m_ArenaReportData[index].ChangePlace > 0U)
        ((Component) this.Img_ItmeRank[panelObjectIdx]).gameObject.SetActive(true);
      else
        ((Component) this.Img_ItmeRank[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.text_ItmeRank[panelObjectIdx]).gameObject.SetActive(true);
    }
    if (((int) this.AM.m_ArenaReportData[index].Flag & 1) == 1)
    {
      this.Img_ItmeRank[panelObjectIdx].sprite = this.SArray.m_Sprites[0];
      ((Component) this.text_ItmeResult_W[panelObjectIdx]).gameObject.SetActive(true);
      ((Component) this.text_ItmeResult_L[panelObjectIdx]).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.text_ItmeResult_W[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.text_ItmeResult_L[panelObjectIdx]).gameObject.SetActive(true);
      if (((int) this.AM.m_ArenaReportData[index].Flag >> 1 & 1) == 0)
        this.Img_ItmeRank[panelObjectIdx].sprite = this.SArray.m_Sprites[1];
    }
    if (((int) this.AM.m_ArenaReportData[index].Flag >> 1 & 1) == 1)
    {
      this.tmpItemHintBtn[panelObjectIdx].image.sprite = this.SArray.m_Sprites[2];
      this.text_ItmeHint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9166U);
    }
    else
    {
      this.tmpItemHintBtn[panelObjectIdx].image.sprite = this.SArray.m_Sprites[3];
      this.text_ItmeHint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9165U);
    }
    this.text_ItmeHint[panelObjectIdx].SetAllDirty();
    this.text_ItmeHint[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.text_ItmeHint[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_ItmeHint[panelObjectIdx].preferredWidth > (double) ((Graphic) this.text_ItmeHint[panelObjectIdx]).rectTransform.sizeDelta.x)
    {
      ((Graphic) this.text_ItmeHint[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItmeHint[panelObjectIdx].preferredWidth, ((Graphic) this.text_ItmeHint[panelObjectIdx]).rectTransform.sizeDelta.y);
      ((Graphic) this.Img_ItmeHint[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItmeHint[panelObjectIdx].preferredWidth + 10f, ((Graphic) this.Img_ItmeHint[panelObjectIdx]).rectTransform.sizeDelta.y);
    }
    if (((int) this.AM.m_ArenaReportData[index].Flag >> 2 & 1) == 0)
      ((Component) this.Img_ItmeNew[panelObjectIdx]).gameObject.SetActive(true);
    else
      ((Component) this.Img_ItmeNew[panelObjectIdx]).gameObject.SetActive(false);
    this.Cstr_Rank[panelObjectIdx].ClearString();
    if (this.AM.m_ArenaReportData[index].ChangePlace > 0U)
    {
      this.Cstr_Rank[panelObjectIdx].IntToFormat((long) this.AM.m_ArenaReportData[index].ChangePlace, bNumber: true);
      this.Cstr_Rank[panelObjectIdx].AppendFormat("{0}");
    }
    this.text_ItmeRank[panelObjectIdx].text = this.Cstr_Rank[panelObjectIdx].ToString();
    this.text_ItmeRank[panelObjectIdx].SetAllDirty();
    this.text_ItmeRank[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.GUIM.ChangeHeroItemImg(((Component) this.tmpItemHIBtn[panelObjectIdx]).transform, eHeroOrItem.Hero, this.AM.m_ArenaReportData[index].EnemyHead, (byte) 11, (byte) 0);
    this.Cstr_Name[panelObjectIdx].ClearString();
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    Name.ClearString();
    Tag.ClearString();
    Name.Append(this.AM.m_ArenaReportData[index].EnemyName);
    if (this.AM.m_ArenaReportData[index].EnemyAllianceTag != string.Empty)
    {
      Tag.Append(this.AM.m_ArenaReportData[index].EnemyAllianceTag);
      GameConstants.FormatRoleName(this.Cstr_Name[panelObjectIdx], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
      GameConstants.FormatRoleName(this.Cstr_Name[panelObjectIdx], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    this.text_ItmeName[panelObjectIdx].text = this.Cstr_Name[panelObjectIdx].ToString();
    this.text_ItmeName[panelObjectIdx].SetAllDirty();
    this.text_ItmeName[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.text_ItmeTime[panelObjectIdx].text = GameConstants.GetDateTime(this.AM.m_ArenaReportData[index].Time).ToString("MM/dd/yy HH:mm:ss");
    this.text_ItmeTime[panelObjectIdx].SetAllDirty();
    this.text_ItmeTime[panelObjectIdx].cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton component = sender.transform.GetComponent<UIButton>();
    if (component.m_BtnID1 != 2 || !((UnityEngine.Object) this.Img_ItmeHint[component.m_BtnID2] != (UnityEngine.Object) null))
      return;
    ((Component) this.Img_ItmeHint[component.m_BtnID2]).gameObject.SetActive(true);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    UIButton component = sender.transform.GetComponent<UIButton>();
    if (component.m_BtnID1 != 2 || !((UnityEngine.Object) this.Img_ItmeHint[component.m_BtnID2] != (UnityEngine.Object) null))
      return;
    ((Component) this.Img_ItmeHint[component.m_BtnID2]).gameObject.SetActive(false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.AM.SendArena_Report();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NoReplay != (UnityEngine.Object) null && ((Behaviour) this.text_NoReplay).enabled)
    {
      ((Behaviour) this.text_NoReplay).enabled = false;
      ((Behaviour) this.text_NoReplay).enabled = true;
    }
    if ((UnityEngine.Object) this.tmpHIBtn != (UnityEngine.Object) null && ((Behaviour) this.tmpHIBtn).enabled)
      this.tmpHIBtn.Refresh_FontTexture();
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.tmpText[index] != (UnityEngine.Object) null && ((Behaviour) this.tmpText[index]).enabled)
      {
        ((Behaviour) this.tmpText[index]).enabled = false;
        ((Behaviour) this.tmpText[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.text_ItmeRank[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItmeRank[index]).enabled)
      {
        ((Behaviour) this.text_ItmeRank[index]).enabled = false;
        ((Behaviour) this.text_ItmeRank[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItmeResult_W[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItmeResult_W[index]).enabled)
      {
        ((Behaviour) this.text_ItmeResult_W[index]).enabled = false;
        ((Behaviour) this.text_ItmeResult_W[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItmeResult_L[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItmeResult_L[index]).enabled)
      {
        ((Behaviour) this.text_ItmeResult_L[index]).enabled = false;
        ((Behaviour) this.text_ItmeResult_L[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItmeTime[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItmeTime[index]).enabled)
      {
        ((Behaviour) this.text_ItmeTime[index]).enabled = false;
        ((Behaviour) this.text_ItmeTime[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItmeName[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItmeName[index]).enabled)
      {
        ((Behaviour) this.text_ItmeName[index]).enabled = false;
        ((Behaviour) this.text_ItmeName[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItmeHint[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItmeHint[index]).enabled)
      {
        ((Behaviour) this.text_ItmeHint[index]).enabled = false;
        ((Behaviour) this.text_ItmeHint[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.tmpItemHIBtn[index] != (UnityEngine.Object) null && ((Behaviour) this.tmpItemHIBtn[index]).enabled)
        this.tmpItemHIBtn[index].Refresh_FontTexture();
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.tmplist.Clear();
        for (int index = 0; index < this.AM.m_ArenaReportData.Count; ++index)
          this.tmplist.Add(95f);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if (this.AM.m_ArenaReportData.Count == 0)
        {
          this.m_ScrollPanel.gameObject.SetActive(false);
          ((Component) this.Img_NoReplay).gameObject.SetActive(true);
        }
        else if (!this.m_ScrollPanel.gameObject.activeSelf)
        {
          this.m_ScrollPanel.gameObject.SetActive(true);
          ((Component) this.Img_NoReplay).gameObject.SetActive(false);
        }
        Array.Clear((Array) this.AM.RepoetUnRead, 0, this.AM.RepoetUnRead.Length);
        this.AM.RepoetUnReadCount = (byte) 0;
        break;
      case 2:
        this.AM.SendArena_Report();
        break;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (!this.bOpen)
      return;
    this.AM.SendArena_Report();
    this.bOpen = false;
  }
}
