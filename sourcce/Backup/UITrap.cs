// Decompiled with JetBrains decompiler
// Type: UITrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITrap : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUTimeBarOnTimer
{
  private DataManager DM;
  private GUIManager GUIM;
  private ScrollPanel m_itemView;
  private RectTransform m_ItemConet;
  private ScrollPanel m_itemView2;
  private RectTransform m_ItemX;
  private RectTransform m_ItemConetY;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private string AssetName;
  private string AssetName1;
  private string AssetName2;
  private Door door;
  private Material m_BW;
  private Material m_Arms;
  private Material m_Mat;
  private Material m_Barrack;
  private Transform GameT;
  private UIButton btn_EXIT;
  private Image BG;
  private Image tmpImg;
  private Image Img_Hint_Info;
  private Image Img_Hint;
  private Image Img_ArmyHint;
  private UIText tmptext;
  private UIText text_TrapValue;
  private UIText text_Manufacturing;
  private UIText text_Hint_Info;
  private UIText[] text_tmpStr = new UIText[2];
  private UIText[] text_timeBar = new UIText[2];
  private UITimeBar timeBar;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];
  private UIButton[] tmpItemBtn = new UIButton[9];
  private Image[] tmpItemImg_Soldier = new Image[9];
  private Image[] tmpItemImg = new Image[9];
  private Image[] tmpItemIcon = new Image[9];
  private UIText[] tmpItemtextNum = new UIText[9];
  private UIText[] tmpItemtextName = new UIText[9];
  private UIText[] tmpItemtextTitle = new UIText[3];
  private CString tmpStr = StringManager.Instance.StaticString1024();
  private CString Cstr_TrapValue;
  private CString Cstr_TimeBar;
  private CString Cstr_Hint_Info;
  private CString[] Cstr_Num = new CString[9];
  private long begin;
  private long target;
  private long notify;
  private SoldierData tmpSD;
  private StringBuilder tmpString = new StringBuilder();
  private RoleBuildingData mBD;
  private BuildLevelRequest mBR;
  private uint UnitMax;
  private ushort GuideSoldierID;
  private Sprite[] msprite = new Sprite[12];
  private Sprite[] mIcon = new Sprite[4];

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.AssetName = "BuildingWindow";
    this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
    this.AssetName1 = "UI_trap";
    this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName1);
    this.AssetName2 = "UIBarrack";
    this.GUIM.AddSpriteAsset(this.AssetName2);
    this.m_Barrack = this.GUIM.LoadMaterial(this.AssetName2, "UI_teach_Arrow_m");
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.m_Mat = this.door.LoadMaterial();
    this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 12, (ushort) 0);
    this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 12, this.mBD.Level);
    this.UnitMax = this.mBR.Value1;
    for (int index = 0; index < 9; ++index)
      this.Cstr_Num[index] = StringManager.Instance.SpawnString();
    this.Cstr_TrapValue = StringManager.Instance.SpawnString();
    this.Cstr_TimeBar = StringManager.Instance.SpawnString();
    this.Cstr_Hint_Info = StringManager.Instance.SpawnString(200);
    for (int index = 0; index < 12; ++index)
    {
      this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index + 17));
      this.tmpStr.ClearString();
      this.tmpStr.IntToFormat((long) this.tmpSD.Icon);
      this.tmpStr.AppendFormat("q{0}");
      this.msprite[index] = this.GUIM.LoadSprite(this.AssetName1, this.tmpStr);
    }
    this.mIcon[0] = this.door.LoadSprite("UI_legion_icon_e");
    this.mIcon[1] = this.door.LoadSprite("UI_legion_icon_f");
    this.mIcon[2] = this.door.LoadSprite("UI_legion_icon_g");
    this.mIcon[3] = this.door.LoadSprite("UI_walllist_icon_01");
    Transform child1 = this.GameT.GetChild(0);
    this.tmpImg = child1.GetComponent<Image>();
    this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_04");
    ((MaskableGraphic) this.tmpImg).material = this.m_BW;
    Transform child2 = child1.GetChild(0);
    this.tmpImg = child2.GetComponent<Image>();
    this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_19");
    ((MaskableGraphic) this.tmpImg).material = this.m_BW;
    this.text_tmpStr[0] = child2.GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(3748U);
    this.tmpImg = child1.GetChild(1).GetComponent<Image>();
    this.tmpImg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_box_99");
    ((MaskableGraphic) this.tmpImg).material = this.m_BW;
    this.tmpImg = child1.GetChild(2).GetComponent<Image>();
    this.tmpImg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
    ((MaskableGraphic) this.tmpImg).material = this.m_BW;
    Transform child3 = child1.GetChild(3);
    this.timeBar = child3.GetComponent<UITimeBar>();
    this.begin = this.DM.ServerTime;
    this.target = this.DM.SoldierBeginTime + (long) this.DM.SoldierNeedTime - this.begin;
    this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
    this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.timeBar.m_TimeBarID = 1;
    this.timeBar.gameObject.SetActive(false);
    this.text_timeBar[0] = child3.GetChild(2).GetComponent<UIText>();
    this.text_timeBar[1] = child3.GetChild(3).GetComponent<UIText>();
    this.text_Manufacturing = child1.GetChild(4).GetComponent<UIText>();
    this.text_Manufacturing.font = this.TTFont;
    this.text_Manufacturing.text = this.DM.mStringTable.GetStringByID(3763U);
    this.text_TrapValue = child1.GetChild(5).GetComponent<UIText>();
    this.text_TrapValue.font = this.TTFont;
    this.Cstr_TrapValue.ClearString();
    this.Cstr_TrapValue.ClearString();
    this.Cstr_TrapValue.IntToFormat((long) this.DM.TrapTotal, bNumber: true);
    this.Cstr_TrapValue.IntToFormat((long) this.UnitMax, bNumber: true);
    this.Cstr_TrapValue.AppendFormat(this.DM.mStringTable.GetStringByID(3762U));
    this.text_TrapValue.text = this.Cstr_TrapValue.ToString();
    if (this.DM.queueBarData[14].bActive)
    {
      this.begin = this.DM.queueBarData[14].StartTime;
      this.target = this.begin + (long) this.DM.queueBarData[14].TotalTime;
      this.notify = 0L;
      this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((int) this.DM.TrapKind * 4 + (int) this.DM.TrapRank + 17));
      this.Cstr_TimeBar.ClearString();
      this.Cstr_TimeBar.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
      this.Cstr_TimeBar.IntToFormat((long) this.DM.TrapTrainingQty, bNumber: true);
      this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4048U));
      this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(3764U), this.Cstr_TimeBar.ToString());
      this.timeBar.gameObject.SetActive(true);
    }
    else
      ((Component) this.text_Manufacturing).gameObject.SetActive(true);
    this.text_tmpStr[1] = child1.GetChild(6).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(3771U);
    this.Img_Hint = child1.GetChild(7).GetComponent<Image>();
    this.Img_Hint.sprite = this.mIcon[3];
    ((MaskableGraphic) this.Img_Hint).material = this.m_Mat;
    ((Component) this.Img_Hint).gameObject.SetActive(true);
    this.Img_ArmyHint = child1.GetChild(8).GetComponent<Image>();
    this.Img_ArmyHint.sprite = this.door.LoadSprite("UI_EO_icon_02");
    ((MaskableGraphic) this.Img_ArmyHint).material = this.m_Mat;
    UIButtonHint uiButtonHint1 = ((Component) this.Img_ArmyHint).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.Parm1 = (ushort) 2;
    ((Component) this.Img_ArmyHint).gameObject.SetActive(true);
    Transform child4 = this.GameT.GetChild(1);
    this.m_itemView = child4.GetComponent<ScrollPanel>();
    this.m_itemView.m_ScrollPanelID = 1;
    this.tmpImg = child4.gameObject.GetComponent<Image>();
    this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_alp");
    ((MaskableGraphic) this.tmpImg).material = this.m_BW;
    Transform child5 = this.GameT.GetChild(2);
    for (int index = 0; index < 3; ++index)
    {
      Transform child6 = child5.GetChild(index);
      UIButton component = child6.GetComponent<UIButton>();
      component.image.sprite = this.GUIM.LoadSprite(this.AssetName1, "q10350");
      ((MaskableGraphic) component.image).material = this.m_Arms;
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID1 = index + 1;
      component.SoundIndex = (byte) 64;
      component.m_EffectType = e_EffectType.e_Scale;
      component.transition = (Selectable.Transition) 0;
      this.tmpImg = child6.GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName1, "q10350");
      ((MaskableGraphic) this.tmpImg).material = this.m_Arms;
      if (this.GUIM.IsArabic)
        ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
      this.tmpImg = child6.GetChild(1).GetComponent<Image>();
      this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_23");
      ((MaskableGraphic) this.tmpImg).material = this.m_BW;
      this.tmptext = child6.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.tmpImg = child6.GetChild(1).GetChild(1).GetComponent<Image>();
      this.tmpImg.sprite = this.mIcon[0];
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      this.tmpImg = child6.GetChild(2).GetComponent<Image>();
      this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_20");
      ((MaskableGraphic) this.tmpImg).material = this.m_BW;
      this.tmptext = child6.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.tmpImg = child6.GetChild(3).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_lock");
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      this.tmpImg.SetNativeSize();
    }
    this.tmptext = child5.GetChild(3).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < 4; ++index)
      _DataHeight.Add(227f);
    this.m_itemView.IntiScrollPanel(285f, 0.0f, 20f, _DataHeight, 3, (IUpDateScrollPanel) this);
    this.m_ItemConet = this.m_itemView.transform.GetChild(0).GetComponent<RectTransform>();
    if ((double) this.GUIM.UIBarrack_TrapY > -1.0)
      this.m_itemView.GoTo(0, this.GUIM.UIBarrack_TrapY);
    Transform child7 = this.GameT.GetChild(3);
    this.BG = child7.GetComponent<Image>();
    this.BG.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
    ((MaskableGraphic) this.BG).material = this.m_BW;
    this.Img_Hint_Info = child7.GetChild(0).GetComponent<Image>();
    this.Img_Hint_Info.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Img_Hint_Info).material = this.m_Mat;
    UIButtonHint uiButtonHint2 = ((Component) this.Img_Hint).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    uiButtonHint2.ControlFadeOut = ((Component) this.Img_Hint_Info).gameObject;
    uiButtonHint2.Parm1 = (ushort) 1;
    this.text_Hint_Info = child7.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Hint_Info.font = this.TTFont;
    this.Cstr_Hint_Info.ClearString();
    this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID(3895U));
    this.Cstr_Hint_Info.AppendFormat(this.DM.mStringTable.GetStringByID(11157U));
    this.text_Hint_Info.text = this.Cstr_Hint_Info.ToString();
    this.text_Hint_Info.SetAllDirty();
    this.text_Hint_Info.cachedTextGenerator.Invalidate();
    this.text_Hint_Info.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.text_Hint_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Hint_Info).rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 1f);
    ((Graphic) this.Img_Hint_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint_Info).rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 21f);
    Transform child8 = this.GameT.GetChild(4);
    this.m_itemView2 = child8.GetComponent<ScrollPanel>();
    this.m_itemView2.m_ScrollPanelID = 2;
    this.tmpImg = child8.GetComponent<Image>();
    this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName2, "UI_lett_alpha_d002");
    ((MaskableGraphic) this.tmpImg).material = this.m_Barrack;
    this.tmpImg = this.GameT.GetChild(5).GetChild(0).GetComponent<Image>();
    this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName2, "UI_new_arrow_01");
    ((MaskableGraphic) this.tmpImg).material = this.m_Barrack;
    this.m_itemView2.IntiScrollPanel(285f, 0.0f, 20f, _DataHeight, 3, (IUpDateScrollPanel) this);
    this.m_ItemX = this.m_itemView2.transform.GetComponent<RectTransform>();
    this.m_ItemConetY = this.m_itemView2.transform.GetChild(0).GetComponent<RectTransform>();
    if (this.GUIM.BuildingData.GuideSoldierID != (ushort) 0)
    {
      this.GuideSoldierID = this.GUIM.BuildingData.GuideSoldierID;
      this.m_itemView2.gameObject.SetActive(true);
      this.m_itemView.GoTo(((int) this.GuideSoldierID - 17) % 4);
      this.m_itemView2.GoTo(((int) this.GuideSoldierID - 17) % 4);
      this.m_ItemX.anchoredPosition = new Vector2((float) (241 * (((int) this.GuideSoldierID - 17) / 4) - 376), this.m_ItemX.anchoredPosition.y);
      this.GUIM.BuildingData.GuideSoldierID = (ushort) 0;
    }
    this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
      case 2:
      case 3:
        this.GUIM.UIBarrack_TrapY = this.m_ItemConet.anchoredPosition.y;
        this.door.OpenMenu(EGUIWindow.UI_Barrack_Soldier, 17 + ((Component) sender).gameObject.transform.parent.GetComponent<ScrollPanelItem>().m_BtnID1 + (sender.m_BtnID1 - 1) * 4);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 1)
      ((Component) this.Img_Hint_Info).gameObject.SetActive(true);
    else
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, (byte) 0, 0.0f, 0, 1, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.Img_Hint_Info).gameObject.SetActive(false);
    GUIManager.Instance.m_Hint.Hide(true);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId == 1)
    {
      if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
      {
        this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
        this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
        for (int index1 = 0; index1 < 3; ++index1)
        {
          int index2 = panelObjectIdx * 3 + index1;
          int num = this.tmpItem[panelObjectIdx].m_BtnID1 + index1 * 4 + 16;
          this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (num + 1));
          Transform child1 = item.transform.GetChild(index1);
          this.tmpItemBtn[index2] = child1.GetComponent<UIButton>();
          this.tmpItemBtn[index2].m_Handler = (IUIButtonClickHandler) this;
          ((MaskableGraphic) this.tmpItemBtn[index2].image).material = this.m_Arms;
          Transform child2 = child1.GetChild(0);
          this.tmpItemImg_Soldier[index2] = child2.GetComponent<Image>();
          ((MaskableGraphic) this.tmpItemImg_Soldier[index2]).material = this.m_Arms;
          Transform child3 = child1.GetChild(1).GetChild(0);
          this.tmpItemtextName[index2] = child3.GetComponent<UIText>();
          Transform child4 = child1.GetChild(1).GetChild(1);
          this.tmpItemIcon[index2] = child4.GetComponent<Image>();
          if (num / 4 - 4 < 3)
            this.tmpItemIcon[index2].sprite = this.mIcon[num / 4 - 4];
          ((Component) this.tmpItemIcon[index2]).gameObject.SetActive(true);
          ((Graphic) this.tmpItemtextName[index2]).rectTransform.anchoredPosition = new Vector2(-52f, ((Graphic) this.tmpItemtextName[index2]).rectTransform.anchoredPosition.y);
          ((Graphic) this.tmpItemtextName[index2]).rectTransform.sizeDelta = new Vector2(139f, ((Graphic) this.tmpItemtextName[index2]).rectTransform.sizeDelta.y);
          Transform child5 = child1.GetChild(2).GetChild(0);
          this.tmpItemtextNum[index2] = child5.GetComponent<UIText>();
          Transform child6 = child1.GetChild(3);
          this.tmpItemImg[index2] = child6.GetComponent<Image>();
        }
        Transform child = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(3);
        this.tmpItemtextTitle[panelObjectIdx] = child.GetComponent<UIText>();
        this.tmpItemtextTitle[panelObjectIdx].font = this.TTFont;
      }
      for (int index3 = 0; index3 < 3; ++index3)
      {
        int index4 = panelObjectIdx * 3 + index3;
        int num = this.tmpItem[panelObjectIdx].m_BtnID1 + index3 * 4 + 16;
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (num + 1));
        this.tmpItemBtn[index4].image.sprite = this.msprite[num - 16];
        this.tmpItemImg_Soldier[index4].sprite = this.msprite[num - 16];
        this.tmpItemtextName[index4].text = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
        this.Cstr_Num[index4].ClearString();
        GameConstants.FormatResourceValue(this.Cstr_Num[index4], this.DM.mTrapQty[num - 16]);
        this.tmpItemtextNum[index4].text = this.Cstr_Num[index4].ToString();
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
      this.tmpItemtextTitle[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint) (3767 + item.GetComponent<ScrollPanelItem>().m_BtnID1));
    }
    else if (dataIdx == ((int) this.GuideSoldierID - 17) % 4)
      item.transform.GetChild(0).gameObject.SetActive(true);
    else
      item.transform.GetChild(0).gameObject.SetActive(false);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    if (this.AssetName != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName);
    if (this.AssetName1 != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName1);
    if (this.AssetName2 != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName2);
    this.GUIM.UIBarrack_TrapY = this.m_ItemConet.anchoredPosition.y;
    if (this.Cstr_TrapValue != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TrapValue);
    if (this.Cstr_TimeBar != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TimeBar);
    if (this.Cstr_Hint_Info != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Hint_Info);
    for (int index = 0; index < 9; ++index)
    {
      if (this.Cstr_Num[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Num[index]);
    }
    if (!((Object) this.timeBar != (Object) null))
      return;
    this.GUIM.RemoverTimeBaarToList(this.timeBar);
  }

  public void OnTimer(UITimeBar sender)
  {
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
    if (sender.m_TimerSpriteType != eTimerSpriteType.Speed)
      return;
    this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 14);
  }

  public void OnCancel(UITimeBar sender)
  {
    this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3735U), this.DM.mStringTable.GetStringByID(3766U), 4, YesText: this.DM.mStringTable.GetStringByID(3925U), NoText: this.DM.mStringTable.GetStringByID(3926U));
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 4 || !GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_CANCELTRAPCONSTRUCT;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Trap)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          if (!((Object) this.timeBar != (Object) null) || !this.timeBar.enabled)
            break;
          this.timeBar.Refresh_FontTexture();
          break;
        }
        for (int index1 = 0; index1 < 3; ++index1)
        {
          for (int index2 = 0; index2 < 3; ++index2)
          {
            int index3 = index2 * 4 + this.tmpItem[index1].m_BtnID1;
            this.tmpString.Length = 0;
            GameConstants.FormatResourceValue(this.tmpString, this.DM.mTrapQty[index3]);
            this.tmpItemtextNum[index1 * 3 + index2].text = this.tmpString.ToString();
          }
        }
        this.UnitMax = this.DM.GetMaxTrapValue();
        this.Cstr_TrapValue.ClearString();
        this.Cstr_TrapValue.IntToFormat((long) this.DM.TrapTotal, bNumber: true);
        this.Cstr_TrapValue.IntToFormat((long) this.UnitMax, bNumber: true);
        this.Cstr_TrapValue.AppendFormat(this.DM.mStringTable.GetStringByID(3762U));
        this.text_TrapValue.text = this.Cstr_TrapValue.ToString();
        this.text_TrapValue.SetAllDirty();
        this.text_TrapValue.cachedTextGenerator.Invalidate();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_TrapValue != (Object) null && ((Behaviour) this.text_TrapValue).enabled)
    {
      ((Behaviour) this.text_TrapValue).enabled = false;
      ((Behaviour) this.text_TrapValue).enabled = true;
    }
    if ((Object) this.text_Manufacturing != (Object) null && ((Behaviour) this.text_Manufacturing).enabled)
    {
      ((Behaviour) this.text_Manufacturing).enabled = false;
      ((Behaviour) this.text_Manufacturing).enabled = true;
    }
    if ((Object) this.text_Hint_Info != (Object) null && ((Behaviour) this.text_Hint_Info).enabled)
    {
      ((Behaviour) this.text_Hint_Info).enabled = false;
      ((Behaviour) this.text_Hint_Info).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
      if ((Object) this.text_timeBar[index] != (Object) null && ((Behaviour) this.text_timeBar[index]).enabled)
      {
        ((Behaviour) this.text_timeBar[index]).enabled = false;
        ((Behaviour) this.text_timeBar[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.tmpItemtextTitle[index] != (Object) null && ((Behaviour) this.tmpItemtextTitle[index]).enabled)
      {
        ((Behaviour) this.tmpItemtextTitle[index]).enabled = false;
        ((Behaviour) this.tmpItemtextTitle[index]).enabled = true;
      }
    }
    for (int index = 0; index < 9; ++index)
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
    switch (arg1)
    {
      case 1:
        if (this.DM.queueBarData[14].bActive)
        {
          long startTime = this.DM.queueBarData[14].StartTime;
          long target = startTime + (long) this.DM.queueBarData[14].TotalTime;
          long notifyTime = 0;
          this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((int) this.DM.TrapKind * 4 + (int) this.DM.TrapRank + 17));
          this.Cstr_TimeBar.ClearString();
          this.Cstr_TimeBar.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
          this.Cstr_TimeBar.IntToFormat((long) this.DM.TrapQuantity, bNumber: true);
          this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4048U));
          this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(3764U), this.Cstr_TimeBar.ToString());
          this.timeBar.gameObject.SetActive(true);
          ((Component) this.text_Manufacturing).gameObject.SetActive(false);
          break;
        }
        this.GUIM.RemoverTimeBaarToList(this.timeBar);
        this.timeBar.gameObject.SetActive(false);
        ((Component) this.text_Manufacturing).gameObject.SetActive(true);
        break;
      case 2:
        int index1 = (int) this.DM.TrapKind * 4 + (int) this.DM.TrapRank;
        this.tmpString.Length = 0;
        GameConstants.FormatResourceValue(this.tmpString, this.DM.mTrapQty[index1]);
        for (int index2 = 0; index2 < 3; ++index2)
        {
          if (this.tmpItem[index2].m_BtnID2 == (int) this.DM.TrapRank && index2 == (int) this.DM.TrapKind)
            this.tmpItemtextNum[index2 * 3 + (int) this.DM.TrapKind].text = this.tmpString.ToString();
        }
        this.UnitMax = this.DM.GetMaxTrapValue();
        this.Cstr_TrapValue.ClearString();
        this.Cstr_TrapValue.IntToFormat((long) this.DM.TrapTotal, bNumber: true);
        this.Cstr_TrapValue.IntToFormat((long) this.UnitMax, bNumber: true);
        this.Cstr_TrapValue.AppendFormat(this.DM.mStringTable.GetStringByID(3762U));
        this.text_TrapValue.text = this.Cstr_TrapValue.ToString();
        this.text_TrapValue.SetAllDirty();
        this.text_TrapValue.cachedTextGenerator.Invalidate();
        break;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (!this.m_itemView2.gameObject.activeSelf)
      return;
    this.m_ItemConetY.anchoredPosition = new Vector2(this.m_ItemConetY.anchoredPosition.x, this.m_ItemConet.anchoredPosition.y);
  }
}
