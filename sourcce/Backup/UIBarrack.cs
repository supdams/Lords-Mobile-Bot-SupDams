// Decompiled with JetBrains decompiler
// Type: UIBarrack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBarrack : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUTimeBarOnTimer
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private ScrollPanel m_itemView;
  private CScrollRect m_ScrollRect;
  private RectTransform m_ItemConet;
  private ScrollPanel m_itemView2;
  private RectTransform m_ItemX;
  private RectTransform m_ItemConetY;
  private Image BG;
  private Image BG1;
  private Image BGArmy;
  private UIText text_Total;
  private UIText text_Training;
  private StringBuilder tmpString = new StringBuilder();
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private SoldierData tmpSD;
  public BuildingWindow baseBuild;
  public UITimeBar timeBar;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];
  public UIButton[] tmpItemBtn = new UIButton[12];
  private Image[] tmpItemImg_Soldier = new Image[12];
  private Image[] tmpItemImg = new Image[12];
  private Image[] tmpItemIcon = new Image[12];
  private UIText[] tmpItemtextNum = new UIText[12];
  private UIText[] tmpItemtextName = new UIText[12];
  private UIText[] tmpItemtextTitle = new UIText[3];
  private long SoldierTotal;
  private bool bTraining;
  private string AssetName;
  private string AssetName1;
  private Door door;
  private Material m_BW;
  private Material m_Arms;
  private int B_ID;
  private CString Cstr_Total;
  private ushort GuideSoldierID;
  private UISpritesArray SArray;

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
    {
      ((Component) this.BG).gameObject.SetActive(true);
      ((Component) this.BG1).gameObject.SetActive(true);
      this.m_itemView.gameObject.SetActive(true);
      if (this.GuideSoldierID != (ushort) 0)
        this.m_itemView2.gameObject.SetActive(true);
      if (this.bTraining)
        return;
      ((Component) this.text_Training).gameObject.SetActive(true);
    }
    else
    {
      this.m_ScrollRect.StopMovement();
      ((Component) this.BG).gameObject.SetActive(false);
      ((Component) this.BG1).gameObject.SetActive(false);
      this.m_itemView.gameObject.SetActive(false);
      this.m_itemView2.gameObject.SetActive(false);
      this.GuideSoldierID = (ushort) 0;
      this.DM.GuideSoldierNum = (ushort) 0;
      if (this.bTraining)
        return;
      ((Component) this.text_Training).gameObject.SetActive(false);
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.B_ID = arg1;
    this.AssetName = "BuildingWindow";
    this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
    this.AssetName1 = "UI_arms";
    this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName1);
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.Cstr_Total = StringManager.Instance.SpawnString();
    Transform child1 = this.GameT.GetChild(0);
    this.BG = child1.GetComponent<Image>();
    this.BG.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_04");
    ((MaskableGraphic) this.BG).material = this.m_BW;
    this.timeBar = child1.GetChild(0).GetComponent<UITimeBar>();
    long num = this.DM.SoldierBeginTime + (long) this.DM.SoldierNeedTime - this.DM.ServerTime;
    this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
    this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.timeBar.m_TimeBarID = 1;
    this.timeBar.gameObject.SetActive(false);
    this.text_Training = child1.GetChild(1).GetComponent<UIText>();
    this.text_Training.font = this.TTFont;
    this.text_Training.text = this.DM.mStringTable.GetStringByID(3833U);
    if (this.DM.queueBarData[10].bActive)
    {
      long startTime = this.DM.queueBarData[10].StartTime;
      long target = startTime + (long) this.DM.queueBarData[10].TotalTime;
      long notifyTime = 0;
      this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((int) this.DM.SoldierKind * 4 + (int) this.DM.SoldierRank + 1));
      CString s = StringManager.Instance.StaticString1024();
      StringManager.IntToStr(s, (long) this.DM.SoldierTrainingQty, bNumber: true);
      this.tmpString.Length = 0;
      this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(4048U), (object) this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name), (object) s.ToString());
      this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4047U), this.tmpString.ToString());
      this.timeBar.gameObject.SetActive(true);
      ((Component) this.text_Training).gameObject.SetActive(false);
      this.bTraining = true;
    }
    this.text_Total = child1.GetChild(2).GetComponent<UIText>();
    this.text_Total.font = this.TTFont;
    this.SoldierTotal = this.DM.SoldierTotal;
    this.Cstr_Total.ClearString();
    this.Cstr_Total.IntToFormat(this.SoldierTotal, bNumber: true);
    this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873U));
    this.text_Total.text = this.Cstr_Total.ToString();
    this.BGArmy = child1.GetChild(3).GetComponent<Image>();
    this.BGArmy.sprite = this.door.LoadSprite("UI_EO_icon_01");
    ((MaskableGraphic) this.BGArmy).material = this.door.LoadMaterial();
    UIButtonHint uiButtonHint = ((Component) this.BGArmy).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    uiButtonHint.Parm1 = (ushort) 1;
    ((Component) this.BGArmy).gameObject.SetActive(true);
    Transform child2 = this.GameT.GetChild(1);
    this.m_itemView = child2.GetComponent<ScrollPanel>();
    this.m_itemView.m_ScrollPanelID = 1;
    Image component1 = child2.gameObject.GetComponent<Image>();
    component1.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_alp");
    ((MaskableGraphic) component1).material = this.m_BW;
    Transform child3 = this.GameT.GetChild(2);
    for (int index = 0; index < 4; ++index)
    {
      Transform child4 = child3.GetChild(index);
      UIButton component2 = child4.GetComponent<UIButton>();
      component2.image.sprite = this.GUIM.LoadSprite("UI_arms", "q10010");
      ((MaskableGraphic) component2.image).material = this.m_Arms;
      component2.image.type = (Image.Type) 0;
      component2.m_Handler = (IUIButtonClickHandler) this;
      component2.m_BtnID1 = index + 1;
      component2.SoundIndex = (byte) 64;
      component2.m_EffectType = e_EffectType.e_Scale;
      component2.transition = (Selectable.Transition) 0;
      Image component3 = child4.GetChild(0).GetComponent<Image>();
      component3.sprite = this.GUIM.LoadSprite("UI_arms", "q10010");
      ((MaskableGraphic) component3).material = this.m_Arms;
      if (this.GUIM.IsArabic)
        ((Component) component3).transform.localScale = new Vector3(-1f, ((Component) component3).transform.localScale.y, ((Component) component3).transform.localScale.z);
      Transform child5 = child4.GetChild(1);
      Image component4 = child5.GetComponent<Image>();
      component4.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_23");
      ((MaskableGraphic) component4).material = this.m_BW;
      child5.GetChild(0).GetComponent<UIText>().font = this.TTFont;
      Transform child6 = child4.GetChild(2);
      Image component5 = child6.GetComponent<Image>();
      component5.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
      ((MaskableGraphic) component5).material = this.m_BW;
      child6.GetChild(0).GetComponent<UIText>().font = this.TTFont;
      Image component6 = child4.GetChild(3).GetComponent<Image>();
      component6.sprite = this.door.LoadSprite("UI_main_lock");
      ((MaskableGraphic) component6).material = this.door.LoadMaterial();
      component6.SetNativeSize();
    }
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < 4; ++index)
      _DataHeight.Add(227f);
    this.m_itemView.IntiScrollPanel(285f, 0.0f, 20f, _DataHeight, 3, (IUpDateScrollPanel) this);
    this.m_ScrollRect = this.m_itemView.GetComponent<CScrollRect>();
    this.m_ItemConet = this.m_itemView.transform.GetChild(0).GetComponent<RectTransform>();
    if ((double) this.GUIM.UIBarrack_Y > -1.0)
      this.m_itemView.GoTo(0, this.GUIM.UIBarrack_Y);
    this.BG1 = this.GameT.GetChild(3).GetComponent<Image>();
    this.BG1.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
    ((MaskableGraphic) this.BG1).material = this.m_BW;
    this.m_itemView2 = this.GameT.GetChild(4).GetComponent<ScrollPanel>();
    this.m_itemView2.m_ScrollPanelID = 2;
    this.GameT.GetChild(5).GetChild(0);
    this.m_itemView2.IntiScrollPanel(285f, 0.0f, 20f, _DataHeight, 3, (IUpDateScrollPanel) this);
    this.m_ItemX = this.m_itemView2.transform.GetComponent<RectTransform>();
    this.m_ItemConetY = this.m_itemView2.transform.GetChild(0).GetComponent<RectTransform>();
    if (!NewbieManager.IsWorking())
      NewbieManager.EntryTeach(ETeachKind.SPAWN_SOLDIERS);
    if (this.GUIM.BuildingData.GuideSoldierID > (ushort) 0 && this.GUIM.BuildingData.GuideSoldierID < (ushort) 17 && !NewbieManager.IsWorking())
    {
      this.GuideSoldierID = this.GUIM.BuildingData.GuideSoldierID;
      this.DM.GuideSoldierNum = (ushort) this.GUIM.BuildingData.GuideSoldierNum;
      this.m_itemView2.gameObject.SetActive(true);
      this.m_itemView.GoTo(((int) this.GuideSoldierID - 1) % 4);
      this.m_itemView2.GoTo(((int) this.GuideSoldierID - 1) % 4);
      this.m_ItemX.anchoredPosition = new Vector2((float) (189 * (((int) this.GuideSoldierID - 1) / 4) - 376), this.m_ItemX.anchoredPosition.y);
    }
    if (this.GuideSoldierID == (ushort) 0)
      this.DM.GuideSoldierNum = (ushort) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 < 1 || sender.m_BtnID1 > 4)
      return;
    this.GUIM.UIBarrack_Y = this.m_ItemConet.anchoredPosition.y;
    int num = 1 + ((Component) sender).gameObject.transform.parent.GetComponent<ScrollPanelItem>().m_BtnID1 + (sender.m_BtnID1 - 1) * 4;
    if ((int) this.GuideSoldierID != num)
      this.DM.GuideSoldierNum = (ushort) 0;
    this.door.OpenMenu(EGUIWindow.UI_Barrack_Soldier, num);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId == 1)
    {
      if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
      {
        this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
        for (int index1 = 0; index1 < 4; ++index1)
        {
          int index2 = panelObjectIdx * 4 + index1;
          Transform child1 = item.transform.GetChild(index1);
          this.tmpItemBtn[index2] = child1.GetComponent<UIButton>();
          this.tmpItemBtn[index2].m_Handler = (IUIButtonClickHandler) this;
          ((MaskableGraphic) this.tmpItemBtn[index2].image).material = this.m_Arms;
          Transform child2 = child1.GetChild(0);
          this.tmpItemImg_Soldier[index2] = child2.GetComponent<Image>();
          Transform child3 = child1.GetChild(1).GetChild(0);
          this.tmpItemtextName[index2] = child3.GetComponent<UIText>();
          int num = this.tmpItem[panelObjectIdx].m_BtnID1 + index1 * 4;
          this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (num + 1));
          Transform child4 = child1.GetChild(1).GetChild(1);
          this.tmpItemIcon[index2] = child4.GetComponent<Image>();
          this.tmpItemIcon[index2].sprite = this.SArray.m_Sprites[num / 4];
          ((Component) this.tmpItemIcon[index2]).gameObject.SetActive(true);
          ((Graphic) this.tmpItemtextName[index2]).rectTransform.anchoredPosition = new Vector2(-52f, ((Graphic) this.tmpItemtextName[index2]).rectTransform.anchoredPosition.y);
          ((Graphic) this.tmpItemtextName[index2]).rectTransform.sizeDelta = new Vector2(139f, ((Graphic) this.tmpItemtextName[index2]).rectTransform.sizeDelta.y);
          Transform child5 = child1.GetChild(2).GetChild(0);
          this.tmpItemtextNum[index2] = child5.GetComponent<UIText>();
          Transform child6 = child1.GetChild(3);
          this.tmpItemImg[index2] = child6.GetComponent<Image>();
        }
        Transform child = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(5);
        this.tmpItemtextTitle[panelObjectIdx] = child.GetComponent<UIText>();
        this.tmpItemtextTitle[panelObjectIdx].font = this.TTFont;
      }
      for (int index3 = 0; index3 < 4; ++index3)
      {
        int index4 = panelObjectIdx * 4 + index3;
        this.tmpString.Length = 0;
        this.tmpString.AppendFormat("q10{0:000}", (object) (index3 * 100 + (dataIdx + 1) * 10));
        this.tmpItemBtn[index4].image.sprite = this.GUIM.LoadSprite("UI_arms", this.tmpString.ToString());
        this.tmpItemImg_Soldier[index4].sprite = this.GUIM.LoadSprite("UI_arms", this.tmpString.ToString());
        int index5 = this.tmpItem[panelObjectIdx].m_BtnID1 + index3 * 4;
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index5 + 1));
        this.tmpItemtextName[index4].text = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
        this.tmpString.Length = 0;
        GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[index5]);
        this.tmpItemtextNum[index4].text = this.tmpString.ToString();
        if (this.tmpSD.Science != (ushort) 0 && this.DM.GetTechLevel(this.tmpSD.Science) == (byte) 0)
        {
          ((Graphic) this.tmpItemImg_Soldier[index4]).color = Color.gray;
          ((Component) this.tmpItemImg[index4]).gameObject.SetActive(true);
        }
        else
        {
          ((Graphic) this.tmpItemImg_Soldier[index4]).color = Color.white;
          ((Component) this.tmpItemImg[index4]).gameObject.SetActive(false);
        }
      }
      this.tmpItemtextTitle[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint) (3834 + item.GetComponent<ScrollPanelItem>().m_BtnID1));
    }
    else if (dataIdx == ((int) this.GuideSoldierID - 1) % 4)
      item.transform.GetChild(0).gameObject.SetActive(true);
    else
      item.transform.GetChild(0).gameObject.SetActive(false);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 6, (ushort) this.B_ID, (byte) 2, this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    if (NewbieManager.CheckNewbie((object) this))
      return;
    NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, (object) this);
  }

  public override void OnClose()
  {
    if (this.AssetName != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName);
    if (this.AssetName1 != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName1);
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if ((Object) this.timeBar != (Object) null)
      this.GUIM.RemoverTimeBaarToList(this.timeBar);
    this.GUIM.UIBarrack_Y = this.m_ItemConet.anchoredPosition.y;
    if (this.Cstr_Total == null)
      return;
    StringManager.Instance.DeSpawnString(this.Cstr_Total);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, (byte) 0, 0.0f, 0, 0, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide(true);

  public void OnTimer(UITimeBar sender)
  {
    this.timeBar.gameObject.SetActive(false);
    ((Component) this.text_Training).gameObject.SetActive(true);
    this.bTraining = false;
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
    if (sender.m_TimerSpriteType != eTimerSpriteType.Speed)
      return;
    this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 10);
  }

  public void OnCancel(UITimeBar sender)
  {
    this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3924U), this.DM.mStringTable.GetStringByID(3853U), YesText: this.DM.mStringTable.GetStringByID(3925U), NoText: this.DM.mStringTable.GetStringByID(3926U));
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 0 || !GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_CANCELTRAINING;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_Soldier:
        for (int index1 = 0; index1 < 3; ++index1)
        {
          for (int index2 = 0; index2 < 4; ++index2)
          {
            int index3 = index2 * 4 + this.tmpItem[index1].m_BtnID1;
            this.tmpString.Length = 0;
            GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[index3]);
            this.tmpItemtextNum[index1 * 4 + index2].text = this.tmpString.ToString();
          }
        }
        this.Cstr_Total.ClearString();
        this.Cstr_Total.IntToFormat(this.DM.SoldierTotal, bNumber: true);
        this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873U));
        this.text_Total.text = this.Cstr_Total.ToString();
        this.text_Total.SetAllDirty();
        this.text_Total.cachedTextGenerator.Invalidate();
        break;
      case NetworkNews.Refresh_BuildBase:
        if (meg[1] == (byte) 1)
        {
          this.door.CloseMenu(true);
          break;
        }
        if (!((Object) this.baseBuild != (Object) null))
          break;
        this.baseBuild.MyUpdate(meg[1]);
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            if (this.DM.queueBarData[10].bActive)
            {
              long startTime = this.DM.queueBarData[10].StartTime;
              long target = startTime + (long) this.DM.queueBarData[10].TotalTime;
              long notifyTime = 0;
              this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((int) this.DM.SoldierKind * 4 + (int) this.DM.SoldierRank + 1));
              CString s = StringManager.Instance.StaticString1024();
              StringManager.IntToStr(s, (long) this.DM.SoldierTrainingQty, bNumber: true);
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(4048U), (object) this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name), (object) s.ToString());
              this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4047U), this.tmpString.ToString());
              this.timeBar.gameObject.SetActive(true);
              ((Component) this.text_Training).gameObject.SetActive(false);
              this.bTraining = true;
            }
            else
            {
              this.GUIM.RemoverTimeBaarToList(this.timeBar);
              this.timeBar.gameObject.SetActive(false);
              ((Component) this.text_Training).gameObject.SetActive(true);
              this.bTraining = false;
            }
            int index4 = (int) this.DM.SoldierKind * 4 + (int) this.DM.SoldierRank;
            this.tmpString.Length = 0;
            GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[index4]);
            for (int index5 = 0; index5 < 3; ++index5)
            {
              if (this.tmpItem[index5].m_BtnID1 == (int) this.DM.SoldierRank)
                this.tmpItemtextNum[index5 * 4 + (int) this.DM.SoldierKind].text = this.tmpString.ToString();
            }
            this.Cstr_Total.ClearString();
            this.Cstr_Total.IntToFormat(this.DM.SoldierTotal, bNumber: true);
            this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873U));
            this.text_Total.text = this.Cstr_Total.ToString();
            this.text_Total.SetAllDirty();
            this.text_Total.cachedTextGenerator.Invalidate();
            return;
          case NetworkNews.Refresh_AttribEffectVal:
            if (!((Object) this.baseBuild != (Object) null))
              return;
            this.baseBuild.MyUpdate((byte) 0);
            return;
          case NetworkNews.Refresh_FontTextureRebuilt:
            this.Refresh_FontTexture();
            if ((Object) this.baseBuild != (Object) null)
              this.baseBuild.Refresh_FontTexture();
            if (!((Object) this.timeBar != (Object) null) || !this.timeBar.enabled)
              return;
            this.timeBar.Refresh_FontTexture();
            return;
          default:
            return;
        }
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Total != (Object) null && ((Behaviour) this.text_Total).enabled)
    {
      ((Behaviour) this.text_Total).enabled = false;
      ((Behaviour) this.text_Total).enabled = true;
    }
    if ((Object) this.text_Training != (Object) null && ((Behaviour) this.text_Training).enabled)
    {
      ((Behaviour) this.text_Training).enabled = false;
      ((Behaviour) this.text_Training).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.tmpItemtextTitle[index] != (Object) null && ((Behaviour) this.tmpItemtextTitle[index]).enabled)
      {
        ((Behaviour) this.tmpItemtextTitle[index]).enabled = false;
        ((Behaviour) this.tmpItemtextTitle[index]).enabled = true;
      }
    }
    for (int index = 0; index < 12; ++index)
    {
      if ((Object) this.tmpItemtextNum[index] != (Object) null && ((Behaviour) this.tmpItemtextNum[index]).enabled)
      {
        ((Behaviour) this.tmpItemtextNum[index]).enabled = false;
        ((Behaviour) this.tmpItemtextNum[index]).enabled = true;
      }
      if ((Object) this.tmpItemtextName[index] != (Object) null && ((Behaviour) this.tmpItemtextName[index]).enabled)
      {
        ((Behaviour) this.tmpItemtextName[index]).enabled = false;
        ((Behaviour) this.tmpItemtextName[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if ((Object) this.baseBuild == (Object) null)
      return;
    switch (arg1)
    {
      case 1:
        if (this.DM.queueBarData[10].bActive)
        {
          long startTime = this.DM.queueBarData[10].StartTime;
          long target = startTime + (long) this.DM.queueBarData[10].TotalTime;
          long notifyTime = 0;
          this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((int) this.DM.SoldierKind * 4 + (int) this.DM.SoldierRank + 1));
          CString s = StringManager.Instance.StaticString1024();
          StringManager.IntToStr(s, (long) this.DM.SoldierTrainingQty, bNumber: true);
          this.tmpString.Length = 0;
          this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(4048U), (object) this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name), (object) s.ToString());
          this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4047U), this.tmpString.ToString());
          this.timeBar.gameObject.SetActive(true);
          ((Component) this.text_Training).gameObject.SetActive(false);
          this.bTraining = true;
          break;
        }
        this.GUIM.RemoverTimeBaarToList(this.timeBar);
        this.timeBar.gameObject.SetActive(false);
        ((Component) this.text_Training).gameObject.SetActive(true);
        this.bTraining = false;
        break;
      case 2:
        int index1 = (int) this.DM.SoldierKind * 4 + (int) this.DM.SoldierRank;
        this.tmpString.Length = 0;
        GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[index1]);
        for (int index2 = 0; index2 < 3; ++index2)
        {
          if (this.tmpItem[index2].m_BtnID1 == (int) this.DM.SoldierRank)
            this.tmpItemtextNum[index2 * 4 + (int) this.DM.SoldierKind].text = this.tmpString.ToString();
        }
        this.Cstr_Total.ClearString();
        this.Cstr_Total.IntToFormat(this.DM.SoldierTotal, bNumber: true);
        this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873U));
        this.text_Total.text = this.Cstr_Total.ToString();
        this.text_Total.SetAllDirty();
        this.text_Total.cachedTextGenerator.Invalidate();
        break;
    }
  }

  private void Update()
  {
    if (!this.m_itemView2.gameObject.activeSelf)
      return;
    this.m_ItemConetY.anchoredPosition = new Vector2(this.m_ItemConetY.anchoredPosition.x, this.m_ItemConet.anchoredPosition.y);
  }
}
