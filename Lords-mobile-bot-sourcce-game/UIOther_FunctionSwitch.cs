// Decompiled with JetBrains decompiler
// Type: UIOther_FunctionSwitch
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIOther_FunctionSwitch : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private ScrollPanel m_ScrollPanel;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private Transform GameT;
  private Transform[] Item_TilteT = new Transform[12];
  private Transform[] Item_TextT = new Transform[12];
  private UIButton btn_EXIT;
  private UIButton[] btnItem = new UIButton[12];
  private Image tmpImg;
  private Image[] Img_Item = new Image[12];
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[12];
  private UIText tmptext;
  private UIText text_tmpStr;
  private UIText[] textItem_Title = new UIText[12];
  private UIText[] textItem = new UIText[12];
  private Material m_Mat;
  private string[] mStr_Title = new string[12];
  private string[] mStr = new string[12];
  private List<float> tmplist = new List<float>();
  private List<string> mListItemStr = new List<string>();
  private List<FunctionSwitch_Type> mListItemType = new List<FunctionSwitch_Type>();
  private int mOpenType;
  private ulong tmpValue;
  private PushNotificationData tmpPushNData = new PushNotificationData();

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.m_Mat = this.door.LoadMaterial();
    this.mOpenType = arg1;
    this.text_tmpStr = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr.font = this.TTFont;
    this.text_tmpStr.text = this.mOpenType != 0 ? this.DM.mStringTable.GetStringByID(7026U) : this.DM.mStringTable.GetStringByID(7025U);
    Transform child1 = this.GameT.GetChild(2);
    UIButton component1 = child1.GetChild(1).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.SoundIndex = (byte) 64;
    this.tmpImg = child1.GetChild(2).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
    this.tmptext = child1.GetChild(3).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child1.GetChild(4).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.m_ScrollPanel = this.GameT.GetChild(3).GetComponent<ScrollPanel>();
    this.tmplist.Clear();
    Transform child2 = this.GameT.GetChild(4);
    this.tmptext = child2.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    UIButton component2 = child2.GetChild(1).GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.SoundIndex = (byte) 64;
    this.tmpImg = child2.GetChild(1).GetChild(1).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
    this.tmptext = child2.GetChild(1).GetChild(2).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    if (this.mOpenType == 0)
    {
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7039U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7052U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowMission);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7040U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9049U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowTrainingIdle);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7041U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7054U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowBuildingIdle);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7042U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7055U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowResearchingIdle);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(8417U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(8418U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowBuildUp);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7538U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7539U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowEquipUp);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9042U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9043U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowArena);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9663U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9664U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowPrison);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9064U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9065U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowChatFight);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9082U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9083U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowTimeBar);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(16073U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(16074U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowMainMenu);
      this.tmplist.Add(33f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(10138U));
      this.mListItemType.Add(FunctionSwitch_Type.e_Title);
      this.tmplist.Add(70f);
      this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(10139U));
      this.mListItemType.Add(FunctionSwitch_Type.e_ShowMonsterPointMax);
    }
    else
    {
      this.CheckPushSwitch();
      for (int Index = 0; Index < this.DM.PushNotification.TableCount; ++Index)
      {
        this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int) (ushort) Index);
        if (this.tmpPushNData.PushNType == (byte) 0)
        {
          this.tmplist.Add(33f);
          this.mListItemType.Add(FunctionSwitch_Type.e_Title);
        }
        else if (this.tmpPushNData.PushNType == (byte) 2)
        {
          this.tmplist.Add(70f);
          this.mListItemType.Add(FunctionSwitch_Type.e_Updata);
        }
        else if (this.tmpPushNData.PushNType == (byte) 1)
        {
          this.tmplist.Add(65f);
          this.mListItemType.Add(FunctionSwitch_Type.e_Updata);
        }
        this.mListItemStr.Add(this.DM.mStringTable.GetStringByID((uint) this.tmpPushNData.PushNStr));
      }
    }
    this.m_ScrollPanel.IntiScrollPanel(504f, 10f, 0.0f, this.tmplist, 12, (IUpDateScrollPanel) this);
    this.tmpImg = this.GameT.GetChild(5).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(5).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void CheckPushSwitch()
  {
    if (this.DM.mSetNotice == ushort.MaxValue)
      return;
    if (((int) this.DM.mSetNotice & 1) != 1)
      this.DM.mNewPushSwitch |= 1UL;
    if (((int) this.DM.mSetNotice >> 1 & 1) != 1)
    {
      this.DM.mNewPushSwitch |= 2UL;
      this.DM.mNewPushSwitch |= 4UL;
      this.DM.mNewPushSwitch |= 8UL;
      this.DM.mNewPushSwitch |= 16UL;
    }
    if (((int) this.DM.mSetNotice >> 2 & 1) != 1)
    {
      this.DM.mNewPushSwitch |= 32UL;
      this.DM.mNewPushSwitch |= 64UL;
    }
    if (((int) this.DM.mSetNotice >> 3 & 1) != 1)
      this.DM.mNewPushSwitch |= 32768UL;
    if (((int) this.DM.mSetNotice >> 4 & 1) != 1)
      this.DM.mNewPushSwitch |= 65536UL;
    if (((int) this.DM.mSetNotice >> 5 & 1) != 1)
      this.DM.mNewPushSwitch |= 131072UL;
    if (((int) this.DM.mSetNotice >> 6 & 1) != 1)
      this.DM.mNewPushSwitch |= 262144UL;
    if (((int) this.DM.mSetNotice >> 7 & 1) != 1)
      this.DM.mNewPushSwitch |= 524288UL;
    if (((int) this.DM.mSetNotice >> 8 & 1) != 1)
      this.DM.mNewPushSwitch |= 2048UL;
    if (((int) this.DM.mSetNotice >> 9 & 1) != 1)
    {
      this.DM.mNewPushSwitch |= 256UL;
      this.DM.mNewPushSwitch |= 512UL;
      this.DM.mNewPushSwitch |= 1024UL;
    }
    if (((int) this.DM.mSetNotice >> 10 & 1) != 1)
      this.DM.mNewPushSwitch |= 2097152UL;
    if (((int) this.DM.mSetNotice >> 11 & 1) != 1)
      this.DM.mNewPushSwitch |= 1048576UL;
    if (((int) this.DM.mSetNotice >> 12 & 1) != 1)
      this.DM.mNewPushSwitch |= 128UL;
    this.DM.mSetNotice = ushort.MaxValue;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SET_PUSH_SWITCH;
    messagePacket.AddSeqId();
    messagePacket.Add(this.DM.mSetNotice);
    messagePacket.Send();
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((GUI_OFS_btn) sender.m_BtnID1)
    {
      case GUI_OFS_btn.btn_EXIT:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case GUI_OFS_btn.btn_Item:
        if (this.mOpenType == 0)
        {
          this.SetFunctionSwitch(this.tmpItem[sender.m_BtnID3].m_BtnID1, this.tmpItem[sender.m_BtnID3].m_BtnID2);
          break;
        }
        this.SetSysNotice(sender.m_BtnID3, sender.m_BtnID2);
        break;
    }
  }

  public void SetFunctionSwitch(int mIdx, int itemIdx)
  {
    if (this.mOpenType != 0)
      return;
    switch (this.mListItemType[mIdx])
    {
      case FunctionSwitch_Type.e_ShowMission:
        this.DM.MySysSetting.bShowMission = !this.DM.MySysSetting.bShowMission;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowMission);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
        break;
      case FunctionSwitch_Type.e_ShowTrainingIdle:
        this.DM.MySysSetting.bShowTrainingIdle = !this.DM.MySysSetting.bShowTrainingIdle;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowTrainingIdle);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        break;
      case FunctionSwitch_Type.e_ShowBuildingIdle:
        this.DM.MySysSetting.bShowBuildingIdle = !this.DM.MySysSetting.bShowBuildingIdle;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowBuildingIdle);
        break;
      case FunctionSwitch_Type.e_ShowResearchingIdle:
        this.DM.MySysSetting.bShowResearchingIdle = !this.DM.MySysSetting.bShowResearchingIdle;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowResearchingIdle);
        break;
      case FunctionSwitch_Type.e_ShowBuildUp:
        this.DM.MySysSetting.bShowBuildUp = !this.DM.MySysSetting.bShowBuildUp;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowBuildUp);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 9, (ushort) byte.MaxValue);
        break;
      case FunctionSwitch_Type.e_ShowEquipUp:
        this.DM.MySysSetting.bShowEquipUp = !this.DM.MySysSetting.bShowEquipUp;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowEquipUp);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        break;
      case FunctionSwitch_Type.e_ShowArena:
        this.DM.MySysSetting.bShowArena = !this.DM.MySysSetting.bShowArena;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowArena);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        break;
      case FunctionSwitch_Type.e_ShowChatFight:
        this.DM.MySysSetting.bShowChatFight = !this.DM.MySysSetting.bShowChatFight;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowChatFight);
        break;
      case FunctionSwitch_Type.e_ShowTimeBar:
        this.DM.MySysSetting.bShowTimeBar = !this.DM.MySysSetting.bShowTimeBar;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowTimeBar);
        break;
      case FunctionSwitch_Type.e_ShowPrison:
        this.DM.MySysSetting.bShowPrison = !this.DM.MySysSetting.bShowPrison;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowPrison);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 11, (ushort) byte.MaxValue);
        break;
      case FunctionSwitch_Type.e_ShowMainMenu:
        this.DM.MySysSetting.bShowMainMenu = !this.DM.MySysSetting.bShowMainMenu;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowMainMenu);
        break;
      case FunctionSwitch_Type.e_ShowMonsterPointMax:
        this.DM.MySysSetting.bShowMonsterPointMax = !this.DM.MySysSetting.bShowMonsterPointMax;
        ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowMonsterPointMax);
        GameManager.OnRefresh(NetworkNews.Refresh_MonsterPoint);
        break;
    }
  }

  public ulong GetValuebyIdx(int Idx)
  {
    if (Idx < this.DM.PushNotification.TableCount)
    {
      this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int) (ushort) Idx);
      if (this.tmpPushNData.PushNType != (byte) 0)
        this.tmpValue = 1UL << (int) this.tmpPushNData.PushNswitch;
    }
    return this.tmpValue;
  }

  public bool CheckValuebyIdx(int Idx)
  {
    bool flag = false;
    if (Idx < this.DM.PushNotification.TableCount)
    {
      this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int) (ushort) Idx);
      if (this.tmpPushNData.PushNType != (byte) 0)
        flag = ((long) (this.DM.mNewPushSwitch >> (int) this.tmpPushNData.PushNswitch) & 1L) != 1L;
    }
    return flag;
  }

  public void SetSysNotice(int itemIdx, int Idx)
  {
    this.tmpValue = this.GetValuebyIdx(Idx);
    if (Idx >= this.DM.PushNotification.TableCount)
      return;
    this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int) (ushort) Idx);
    if (this.tmpPushNData.PushNType == (byte) 0)
      return;
    this.tmpValue = 1UL << (int) this.tmpPushNData.PushNswitch;
    if (((long) (this.DM.mNewPushSwitch >> (int) this.tmpPushNData.PushNswitch) & 1L) != 1L)
    {
      this.DM.mNewPushSwitch += this.tmpValue;
      ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(false);
    }
    else
    {
      this.DM.mNewPushSwitch -= this.tmpValue;
      ((Component) this.Img_Item[itemIdx]).gameObject.SetActive(true);
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.Item_TilteT[panelObjectIdx] = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(0);
      this.textItem_Title[panelObjectIdx] = this.Item_TilteT[panelObjectIdx].GetChild(1).GetComponent<UIText>();
      this.textItem_Title[panelObjectIdx].font = this.TTFont;
      this.Item_TextT[panelObjectIdx] = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(1);
      this.btnItem[panelObjectIdx] = this.Item_TextT[panelObjectIdx].GetChild(0).GetComponent<UIButton>();
      this.btnItem[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.Img_Item[panelObjectIdx] = this.Item_TextT[panelObjectIdx].GetChild(1).GetComponent<Image>();
      this.textItem[panelObjectIdx] = this.Item_TextT[panelObjectIdx].GetChild(2).GetComponent<UIText>();
      this.textItem[panelObjectIdx].font = this.TTFont;
    }
    this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
    if (this.mListItemType[dataIdx] == FunctionSwitch_Type.e_Title)
    {
      this.Item_TilteT[panelObjectIdx].gameObject.SetActive(true);
      this.Item_TextT[panelObjectIdx].gameObject.SetActive(false);
    }
    else
    {
      this.Item_TilteT[panelObjectIdx].gameObject.SetActive(false);
      this.Item_TextT[panelObjectIdx].gameObject.SetActive(true);
    }
    if (this.mListItemType[dataIdx] == FunctionSwitch_Type.e_Title)
      this.textItem_Title[panelObjectIdx].text = this.mListItemStr[dataIdx];
    else
      this.textItem[panelObjectIdx].text = this.mListItemStr[dataIdx];
    this.btnItem[panelObjectIdx].m_BtnID1 = 1;
    this.btnItem[panelObjectIdx].m_BtnID2 = dataIdx;
    this.btnItem[panelObjectIdx].m_BtnID3 = panelObjectIdx;
    if (this.mOpenType == 0)
    {
      switch (this.mListItemType[dataIdx])
      {
        case FunctionSwitch_Type.e_ShowMission:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowMission);
          break;
        case FunctionSwitch_Type.e_ShowTrainingIdle:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowTrainingIdle);
          break;
        case FunctionSwitch_Type.e_ShowBuildingIdle:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowBuildingIdle);
          break;
        case FunctionSwitch_Type.e_ShowResearchingIdle:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowResearchingIdle);
          break;
        case FunctionSwitch_Type.e_ShowBuildUp:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowBuildUp);
          break;
        case FunctionSwitch_Type.e_ShowEquipUp:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowEquipUp);
          break;
        case FunctionSwitch_Type.e_ShowArena:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowArena);
          break;
        case FunctionSwitch_Type.e_ShowChatFight:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowChatFight);
          break;
        case FunctionSwitch_Type.e_ShowTimeBar:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowTimeBar);
          break;
        case FunctionSwitch_Type.e_ShowPrison:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowPrison);
          break;
        case FunctionSwitch_Type.e_ShowMainMenu:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowMainMenu);
          break;
        case FunctionSwitch_Type.e_ShowMonsterPointMax:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.DM.MySysSetting.bShowMonsterPointMax);
          break;
        default:
          ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(false);
          break;
      }
    }
    else
    {
      ((Component) this.btnItem[panelObjectIdx]).gameObject.SetActive(true);
      ((Component) this.Img_Item[panelObjectIdx]).gameObject.SetActive(this.CheckValuebyIdx(dataIdx));
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    if (this.mOpenType == 1)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_SET_NEW_PUSHSWITCH;
      messagePacket.AddSeqId();
      messagePacket.Add(this.DM.mNewPushSwitch);
      messagePacket.Send();
    }
    this.DM.SetSysSettingSave();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (this.mOpenType != 1)
          break;
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
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
    if ((Object) this.text_tmpStr != (Object) null && ((Behaviour) this.text_tmpStr).enabled)
    {
      ((Behaviour) this.text_tmpStr).enabled = false;
      ((Behaviour) this.text_tmpStr).enabled = true;
    }
    for (int index = 0; index < 12; ++index)
    {
      if ((Object) this.textItem_Title[index] != (Object) null && ((Behaviour) this.textItem_Title[index]).enabled)
      {
        ((Behaviour) this.textItem_Title[index]).enabled = false;
        ((Behaviour) this.textItem_Title[index]).enabled = true;
      }
      if ((Object) this.textItem[index] != (Object) null && ((Behaviour) this.textItem[index]).enabled)
      {
        ((Behaviour) this.textItem[index]).enabled = false;
        ((Behaviour) this.textItem[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 1)
      ;
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
