// Decompiled with JetBrains decompiler
// Type: UIForge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIForge : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUTimeBarOnTimer
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private Transform Item_T;
  private Transform BG_T;
  private Transform BG1_T;
  private UIButton btn_Magnifier;
  private UIButton[] btn_Itme = new UIButton[3];
  private ScrollPanel m_ScrollPanel;
  private CScrollRect m_ScrollRect;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private BuildingWindow baseBuild;
  private UITimeBar timeBar;
  private Door door;
  private UIText[] text_tmpStr = new UIText[4];
  private UIText[] text_tmpItme = new UIText[3];
  private UIText[] text_timeBar = new UIText[2];
  private Image Img_isEquipEvoReady;
  private int B_ID;
  private long begin;
  private long target;
  private bool Forging;
  private List<float> tmplist = new List<float>();
  private string[] m_ItemName = new string[3];

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
    {
      this.BG_T.gameObject.SetActive(true);
      this.BG1_T.gameObject.SetActive(true);
      this.m_ScrollPanel.gameObject.SetActive(true);
      if (this.Forging)
        this.timeBar.gameObject.SetActive(true);
      else
        this.timeBar.gameObject.SetActive(false);
    }
    else
    {
      this.m_ScrollRect.StopMovement();
      this.BG_T.gameObject.SetActive(false);
      this.BG1_T.gameObject.SetActive(false);
      this.m_ScrollPanel.gameObject.SetActive(false);
      if (!this.Forging)
        return;
      this.timeBar.gameObject.SetActive(false);
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.B_ID = arg1;
    for (int index = 0; index < 3; ++index)
      this.m_ItemName[index] = this.DM.mStringTable.GetStringByID((uint) (7402 + index));
    this.GameT = this.gameObject.transform;
    this.BG_T = this.GameT.GetChild(0);
    this.timeBar = this.BG_T.GetChild(0).GetComponent<UITimeBar>();
    if (this.DM.queueBarData[18].bActive)
    {
      this.begin = this.DM.queueBarData[18].StartTime;
      this.target = this.begin + (long) this.DM.queueBarData[18].TotalTime;
      this.GUIM.CreateTimerBar(this.timeBar, this.begin, this.target, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(261U), this.DM.mStringTable.GetStringByID(261U));
      this.timeBar.gameObject.SetActive(true);
      this.Forging = true;
    }
    else
    {
      this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
      this.timeBar.gameObject.SetActive(false);
    }
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
    this.text_timeBar[0] = this.BG_T.GetChild(0).GetChild(2).GetComponent<UIText>();
    this.text_timeBar[1] = this.BG_T.GetChild(0).GetChild(3).GetComponent<UIText>();
    this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.timeBar.m_TimeBarID = 1;
    this.btn_Magnifier = this.BG_T.GetChild(1).GetComponent<UIButton>();
    this.btn_Magnifier.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Magnifier.m_BtnID1 = 1;
    this.btn_Magnifier.m_EffectType = e_EffectType.e_Scale;
    this.btn_Magnifier.transition = (Selectable.Transition) 0;
    ((Component) this.btn_Magnifier).gameObject.SetActive(this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0);
    this.text_tmpStr[0] = this.BG_T.GetChild(2).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level >= (byte) 17 ? this.DM.mStringTable.GetStringByID(7496U) : this.DM.mStringTable.GetStringByID(7401U);
    this.m_ScrollPanel = this.GameT.GetChild(1).GetComponent<ScrollPanel>();
    this.Item_T = this.GameT.GetChild(2);
    for (int index = 0; index < 3; ++index)
    {
      UIButton component = this.Item_T.GetChild(index).GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID1 = 2 + index;
      component.SoundIndex = (byte) 64;
      component.m_EffectType = e_EffectType.e_Scale;
      component.transition = (Selectable.Transition) 0;
      this.text_tmpStr[1 + index] = this.Item_T.GetChild(index).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[1 + index].font = this.TTFont;
      this.text_tmpStr[1 + index].text = this.m_ItemName[index];
    }
    for (int index = 0; index < 1; ++index)
      this.tmplist.Add(227f);
    this.m_ScrollPanel.IntiScrollPanel(285f, 0.0f, 0.0f, this.tmplist, 1, (IUpDateScrollPanel) this);
    this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.BG1_T = this.GameT.GetChild(3);
    if (this.DM.mLordEquip == null)
      this.DM.mLordEquip = LordEquipData.Instance();
    if (this.DM.mLordEquip.isEquipEvoReady)
      ((Component) this.Img_isEquipEvoReady).gameObject.SetActive(true);
    else
      ((Component) this.Img_isEquipEvoReady).gameObject.SetActive(false);
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    NewbieManager.CheckTeach(ETeachKind.SMITH, bEntry: true);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        UIAnvil.SetOpen(eUI_Anvil_OpenKind.NowForging, 0, 0);
        break;
      case 2:
        this.door.OpenMenu(EGUIWindow.UI_Forge_Item);
        break;
      case 3:
        this.door.OpenMenu(EGUIWindow.UI_Forge_ActivityItem, 1);
        break;
      case 4:
        UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
        this.door.OpenMenu(EGUIWindow.UI_LordEquip, 1);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (!((Object) this.tmpItem[panelObjectIdx] == (Object) null))
      return;
    this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
    for (int index = 0; index < 3; ++index)
    {
      this.btn_Itme[index] = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(index).GetComponent<UIButton>();
      this.btn_Itme[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Itme[index].m_BtnID1 = 2 + index;
      this.text_tmpItme[index] = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(index).GetComponent<UIText>();
      if (index == 2)
        this.Img_isEquipEvoReady = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(index).GetChild(1).GetComponent<Image>();
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
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
    this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 18);
  }

  public void OnCancel(UITimeBar sender)
  {
    this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7514U), this.DM.mStringTable.GetStringByID(7513U), 1, YesText: this.DM.mStringTable.GetStringByID(7426U), NoText: this.DM.mStringTable.GetStringByID(188U));
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1)
      return;
    LordEquipData.CancelCombine();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
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
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.Refresh_FontTexture();
        if (!((Object) this.timeBar != (Object) null) || !this.timeBar.enabled)
          break;
        this.timeBar.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_timeBar[index] != (Object) null && ((Behaviour) this.text_timeBar[index]).enabled)
      {
        ((Behaviour) this.text_timeBar[index]).enabled = false;
        ((Behaviour) this.text_timeBar[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_tmpItme[index] != (Object) null && ((Behaviour) this.text_tmpItme[index]).enabled)
      {
        ((Behaviour) this.text_tmpItme[index]).enabled = false;
        ((Behaviour) this.text_tmpItme[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if ((Object) this.baseBuild == (Object) null)
      return;
    switch (arg1)
    {
      case 0:
        if (this.DM.mLordEquip.isEquipEvoReady)
        {
          ((Component) this.Img_isEquipEvoReady).gameObject.SetActive(true);
          break;
        }
        ((Component) this.Img_isEquipEvoReady).gameObject.SetActive(false);
        break;
      case 1:
        if (this.DM.queueBarData[18].bActive)
        {
          long startTime = this.DM.queueBarData[18].StartTime;
          long target = startTime + (long) this.DM.queueBarData[18].TotalTime;
          this.GUIM.SetTimerBar(this.timeBar, startTime, target, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(261U), this.DM.mStringTable.GetStringByID(261U));
          this.timeBar.gameObject.SetActive(true);
        }
        else
        {
          this.GUIM.RemoverTimeBaarToList(this.timeBar);
          this.timeBar.gameObject.SetActive(false);
        }
        ((Component) this.btn_Magnifier).gameObject.SetActive(this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0);
        break;
    }
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 15, (ushort) this.B_ID, (byte) 2, this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
  }

  private void Update()
  {
  }
}
