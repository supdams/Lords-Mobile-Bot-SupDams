// Decompiled with JetBrains decompiler
// Type: UIWatchtower
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIWatchtower : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUTimeBarOnTimer
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform Tmp;
  private Transform[] ItemT = new Transform[6];
  private Transform[] Item_StausT1 = new Transform[6];
  private Transform[] Item_StausT2 = new Transform[6];
  private RectTransform[] Item_btn_CRT = new RectTransform[6];
  private RectTransform[] Item_Img_CRT = new RectTransform[6];
  private UIButton tmpbtn;
  private UIButton[] Item_btnTroops = new UIButton[6];
  private UIButton[] Item_btnCoordinate = new UIButton[6];
  private Image tmpImg;
  private Image[] Item_ImgIcon = new Image[6];
  private Image[] Item_Img = new Image[6];
  private Sprite[] ImgList = new Sprite[14];
  private UIText tmptext;
  private UIText text_No;
  private UIText[] Item_textCoordinate = new UIText[6];
  private UIText[] Item_textStatus = new UIText[6];
  private UIText[] Item_textStatus_C = new UIText[6];
  private UIText[] Item_text = new UIText[6];
  private UIText[] Item_textTimebar1 = new UIText[6];
  private UIText[] Item_textTimebar2 = new UIText[6];
  private CString[] Cstr_textCoordinate = new CString[6];
  private CString[] Cstr_Status = new CString[6];
  private ScrollPanel m_ScrollPanel;
  private CScrollRect m_ScrollRect;
  private UITimeBar timeBar;
  private UITimeBar[] Item_timebar = new UITimeBar[6];
  private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private BuildingWindow baseBuild;
  private RoleBuildingData mBD;
  private BuildLevelRequest mBR;
  private int B_ID;
  private Door door;
  private string AssetName;
  public string[] mStrStatus = new string[15];
  private Vector2 tmpV2 = new Vector2(0.0f, 0.0f);
  private bool bWatch = true;
  private long begin;
  private long target;
  private ushort m_Effect;
  private List<float> tmplist = new List<float>();
  private UISpritesArray SArray;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 13, (ushort) 0);
    this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 13, this.mBD.Level);
    this.m_Effect = (ushort) this.mBR.Level;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.AssetName = "BuildingWindow";
    Transform transform = this.gameObject.transform;
    this.SArray = transform.GetComponent<UISpritesArray>();
    this.ImgList[0] = this.SArray.m_Sprites[1];
    this.ImgList[1] = this.SArray.m_Sprites[1];
    this.ImgList[2] = this.SArray.m_Sprites[5];
    this.ImgList[3] = this.SArray.m_Sprites[0];
    this.ImgList[4] = this.SArray.m_Sprites[4];
    this.ImgList[5] = this.SArray.m_Sprites[3];
    this.ImgList[6] = this.SArray.m_Sprites[2];
    this.ImgList[7] = this.SArray.m_Sprites[6];
    this.ImgList[8] = this.SArray.m_Sprites[7];
    this.ImgList[9] = this.SArray.m_Sprites[8];
    this.ImgList[10] = this.SArray.m_Sprites[9];
    this.ImgList[11] = this.SArray.m_Sprites[10];
    this.ImgList[12] = this.SArray.m_Sprites[11];
    this.ImgList[13] = this.SArray.m_Sprites[12];
    this.mStrStatus[0] = this.DM.mStringTable.GetStringByID(4982U);
    this.mStrStatus[1] = this.DM.mStringTable.GetStringByID(3978U);
    this.mStrStatus[2] = this.DM.mStringTable.GetStringByID(3852U);
    this.mStrStatus[3] = this.DM.mStringTable.GetStringByID(3979U);
    this.mStrStatus[4] = this.DM.mStringTable.GetStringByID(3980U);
    this.mStrStatus[5] = this.DM.mStringTable.GetStringByID(5804U);
    this.mStrStatus[6] = this.DM.mStringTable.GetStringByID(3981U);
    this.mStrStatus[7] = this.DM.mStringTable.GetStringByID(3982U);
    this.mStrStatus[8] = this.DM.mStringTable.GetStringByID(3983U);
    this.mStrStatus[9] = this.DM.mStringTable.GetStringByID(9744U);
    this.mStrStatus[10] = this.DM.mStringTable.GetStringByID(9760U);
    this.mStrStatus[11] = this.DM.mStringTable.GetStringByID(9764U);
    this.mStrStatus[12] = this.DM.mStringTable.GetStringByID(9765U);
    this.mStrStatus[13] = this.DM.mStringTable.GetStringByID(9920U);
    this.mStrStatus[14] = this.DM.mStringTable.GetStringByID(12100U);
    for (int index = 0; index < 6; ++index)
    {
      this.Cstr_textCoordinate[index] = StringManager.Instance.SpawnString();
      this.Cstr_Status[index] = StringManager.Instance.SpawnString();
    }
    this.Tmp = transform.GetChild(0);
    this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
    Transform child = transform.GetChild(1);
    this.text_No = transform.GetChild(2).GetComponent<UIText>();
    this.text_No.font = this.TTFont;
    this.text_No.text = this.DM.mStringTable.GetStringByID(3975U);
    this.tmpImg = child.GetChild(1).GetChild(0).GetComponent<Image>();
    this.tmpImg.sprite = this.ImgList[0];
    this.timeBar = child.GetChild(2).GetComponent<UITimeBar>();
    this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.NormalType, string.Empty, string.Empty);
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
    this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.timeBar.m_TimeBarID = 1;
    this.tmptext = child.GetChild(3).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmpbtn = child.GetChild(4).GetChild(0).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpbtn.m_BtnID1 = 1;
    this.tmptext = child.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.text = this.DM.mStringTable.GetStringByID(3976U);
    this.tmpbtn = child.GetChild(4).GetChild(1).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpbtn.m_BtnID1 = 2;
    this.tmptext = child.GetChild(4).GetChild(1).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(4).GetChild(2).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmplist.Clear();
    for (int index = 0; index < this.DM.m_WatchTowerData.Count; ++index)
      this.tmplist.Add(112f);
    this.m_ScrollPanel.IntiScrollPanel(490f, 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
    this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.B_ID = arg1;
    if (this.DM.m_WatchTowerData.Count > 0)
    {
      ((Component) this.text_No).gameObject.SetActive(false);
    }
    else
    {
      this.bWatch = false;
      this.m_ScrollPanel.gameObject.SetActive(false);
      ((Component) this.text_No).gameObject.SetActive(true);
    }
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if (this.AssetName != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName);
    this.tmplist = (List<float>) null;
    if ((Object) this.timeBar != (Object) null)
      this.GUIM.RemoverTimeBaarToList(this.timeBar);
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.Item_timebar[index] != (Object) null)
        this.GUIM.RemoverTimeBaarToList(this.Item_timebar[index]);
      if (this.Cstr_textCoordinate[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_textCoordinate[index]);
      if (this.Cstr_Status[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Status[index]);
    }
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
    {
      if (this.bWatch)
      {
        ((Component) this.text_No).gameObject.SetActive(false);
        this.m_ScrollPanel.gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.text_No).gameObject.SetActive(true);
        this.m_ScrollPanel.gameObject.SetActive(false);
      }
    }
    else
    {
      ((Component) this.text_No).gameObject.SetActive(false);
      this.m_ScrollPanel.gameObject.SetActive(false);
      this.m_ScrollRect.StopMovement();
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        this.Tmp = ((Component) sender).gameObject.transform.parent;
        this.door.GoToGroup((int) this.DM.mtmpIdx[(int) this.DM.m_WatchTowerData[sender.m_BtnID2].ListIdx - 1].LineID - 1, (byte) 0);
        break;
      case 2:
        int index = (int) this.DM.m_WatchTowerData[sender.m_BtnID2].ListIdx - 1;
        this.door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.DM.MarchEventData[index].Point.zoneID, this.DM.MarchEventData[index].Point.pointID, (byte) 0);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.ItemT[panelObjectIdx] == (Object) null)
    {
      this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
      this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.Item_ImgIcon[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<Image>();
      this.Item_timebar[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2).GetComponent<UITimeBar>();
      this.Item_timebar[panelObjectIdx].m_Handler = (IUTimeBarOnTimer) this;
      this.Item_timebar[panelObjectIdx].m_ListID = 0;
      this.Item_timebar[panelObjectIdx].gameObject.SetActive(false);
      this.Item_textTimebar1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2).GetChild(2).GetComponent<UIText>();
      this.Item_textTimebar2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2).GetChild(3).GetComponent<UIText>();
      this.Item_StausT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(3).GetComponent<Transform>();
      this.Item_Img[panelObjectIdx] = this.Item_StausT1[panelObjectIdx].GetChild(0).GetComponent<Image>();
      this.Item_textStatus[panelObjectIdx] = this.Item_StausT1[panelObjectIdx].GetChild(1).GetComponent<UIText>();
      this.Item_StausT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(4).GetComponent<Transform>();
      this.Item_btnTroops[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(0).GetComponent<UIButton>();
      this.Item_btnTroops[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.Item_btnTroops[panelObjectIdx].m_BtnID2 = dataIdx;
      this.Item_btnCoordinate[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetComponent<UIButton>();
      this.Item_btnCoordinate[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.Item_btnCoordinate[panelObjectIdx].m_BtnID2 = dataIdx;
      this.Item_btn_CRT[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetComponent<RectTransform>();
      this.Item_Img_CRT[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<RectTransform>();
      this.Item_text[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIText>();
      this.Item_textCoordinate[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<UIText>();
      this.Item_textStatus_C[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(2).GetComponent<UIText>();
    }
    else if (this.DM.m_WatchTowerData.Count > dataIdx)
    {
      if (this.mScrollItem[panelObjectIdx].m_BtnID2 == 1)
        this.Item_StausT1[panelObjectIdx].gameObject.SetActive(false);
      else
        this.Item_StausT2[panelObjectIdx].gameObject.SetActive(false);
    }
    if (this.DM.m_WatchTowerData[dataIdx].LineType > (byte) 0)
    {
      this.mScrollItem[panelObjectIdx].m_BtnID2 = 1;
      int listIdx = (int) this.DM.m_WatchTowerData[dataIdx].ListIdx;
      this.Item_StausT1[panelObjectIdx].gameObject.SetActive(true);
      if (this.m_Effect >= (ushort) 7)
      {
        this.begin = this.DM.tmp_WatchTowerData[listIdx].MarchTimeData.BeginTime;
        this.target = this.begin + (long) this.DM.tmp_WatchTowerData[listIdx].MarchTimeData.RequireTime;
        this.GUIM.SetTimerBar(this.Item_timebar[panelObjectIdx], this.begin, this.target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985U).ToString(), string.Empty);
        this.Item_timebar[panelObjectIdx].gameObject.SetActive(true);
      }
      bool flag = false;
      if (this.DM.tmp_WatchTowerData[listIdx].Index >= (byte) 0 && this.DM.tmp_WatchTowerData[listIdx].Index <= (byte) 7 && this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].PointKind == POINT_KIND.PK_YOLK)
        flag = true;
      switch (this.DM.m_WatchTowerData[dataIdx].LineType)
      {
        case 5:
        case 7:
          if (flag)
          {
            this.Cstr_Status[panelObjectIdx].ClearString();
            this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].DesPointLevel, (ushort) 0));
            this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8549U));
            this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
            this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[9];
            break;
          }
          this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[1];
          this.Item_textStatus[panelObjectIdx].text = this.DM.tmp_WatchTowerData[listIdx].Index != byte.MaxValue ? (this.DM.tmp_WatchTowerData[listIdx].Index < (byte) 0 || this.DM.tmp_WatchTowerData[listIdx].Index > (byte) 7 || !this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].IsAmbushCamp() ? this.mStrStatus[2] : this.mStrStatus[10]) : this.mStrStatus[1];
          break;
        case 6:
          if (this.DM.tmp_WatchTowerData[listIdx].Index == byte.MaxValue)
          {
            this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[12];
            this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[9];
            break;
          }
          if (flag)
          {
            this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[5];
            this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[13];
            break;
          }
          break;
        case 8:
          if (flag)
          {
            this.Cstr_Status[panelObjectIdx].ClearString();
            this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].DesPointLevel, (ushort) 0));
            this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8550U));
            this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
            this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[10];
            break;
          }
          this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[3];
          this.Item_textStatus[panelObjectIdx].text = this.DM.tmp_WatchTowerData[listIdx].Index != byte.MaxValue ? (this.DM.tmp_WatchTowerData[listIdx].Index < (byte) 0 || this.DM.tmp_WatchTowerData[listIdx].Index > (byte) 7 || !this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].IsAmbushCamp() ? this.mStrStatus[5] : this.mStrStatus[12]) : this.mStrStatus[4];
          break;
        case 10:
          if (flag)
          {
            this.Cstr_Status[panelObjectIdx].ClearString();
            this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].DesPointLevel, (ushort) 0));
            this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8551U));
            this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
            this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[11];
            break;
          }
          this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[5];
          this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[7];
          break;
        case 11:
          this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[4];
          this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[6];
          break;
        case 12:
          if (flag)
          {
            this.Cstr_Status[panelObjectIdx].ClearString();
            this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].DesPointLevel, (ushort) 0));
            this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8548U));
            this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
            this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[8];
            break;
          }
          this.Item_textStatus[panelObjectIdx].text = this.DM.tmp_WatchTowerData[listIdx].Index < (byte) 0 || this.DM.tmp_WatchTowerData[listIdx].Index > (byte) 7 || !this.DM.MarchEventData[(int) this.DM.tmp_WatchTowerData[listIdx].Index].IsAmbushCamp() ? this.mStrStatus[0] : this.mStrStatus[11];
          this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[7];
          break;
        case 13:
          this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[6];
          this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[8];
          break;
        case 22:
          this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[13];
          this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[14];
          break;
      }
      this.Item_textStatus[panelObjectIdx].SetAllDirty();
      this.Item_textStatus[panelObjectIdx].cachedTextGenerator.Invalidate();
    }
    else
    {
      this.Item_btnTroops[panelObjectIdx].m_BtnID2 = dataIdx;
      this.Item_btnCoordinate[panelObjectIdx].m_BtnID2 = dataIdx;
      this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[2];
      this.Item_textStatus_C[panelObjectIdx].text = this.mStrStatus[3];
      int index = (int) this.DM.m_WatchTowerData[dataIdx].ListIdx - 1;
      if (this.m_Effect >= (ushort) 7)
      {
        this.begin = this.DM.MarchEventTime[index].BeginTime;
        this.target = this.begin + (long) this.DM.MarchEventTime[index].RequireTime;
        this.GUIM.SetTimerBar(this.Item_timebar[panelObjectIdx], this.begin, this.target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985U).ToString(), string.Empty);
        this.Item_timebar[panelObjectIdx].gameObject.SetActive(true);
      }
      this.mScrollItem[panelObjectIdx].m_BtnID2 = 2;
      this.Item_StausT2[panelObjectIdx].gameObject.SetActive(true);
      this.Cstr_textCoordinate[1].ClearString();
      this.tmpV2 = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.DM.MarchEventData[index].Point.zoneID, this.DM.MarchEventData[index].Point.pointID));
      this.Cstr_textCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4505U));
      this.Cstr_textCoordinate[1].IntToFormat((long) (int) this.tmpV2.x);
      this.Cstr_textCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4506U));
      this.Cstr_textCoordinate[1].IntToFormat((long) (int) this.tmpV2.y);
      if (this.GUIM.IsArabic)
        this.Cstr_textCoordinate[1].AppendFormat("{3}{2} {1}{0}");
      else
        this.Cstr_textCoordinate[1].AppendFormat("{0}{1} {2}{3}");
      this.Item_textCoordinate[panelObjectIdx].text = this.Cstr_textCoordinate[1].ToString();
      this.Item_textCoordinate[panelObjectIdx].SetAllDirty();
      this.Item_textCoordinate[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.Item_btn_CRT[panelObjectIdx].sizeDelta = new Vector2(this.Item_textCoordinate[panelObjectIdx].preferredWidth, this.Item_btn_CRT[panelObjectIdx].sizeDelta.y);
      this.Item_Img_CRT[panelObjectIdx].sizeDelta = new Vector2(this.Item_textCoordinate[panelObjectIdx].preferredWidth, this.Item_Img_CRT[panelObjectIdx].sizeDelta.y);
    }
    this.Item_ImgIcon[panelObjectIdx].SetNativeSize();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (this.DM.m_WatchTowerData.Count <= 0 || dataIndex <= -1 || dataIndex >= this.DM.m_WatchTowerData.Count)
      return;
    if (this.DM.m_WatchTowerData[dataIndex].LineType > (byte) 0)
    {
      if (this.mBD.Level >= (byte) 4)
      {
        if (!this.GUIM.ShowUILock(EUILock.WatchTower))
          return;
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_WATCHTOWER_LINEDETAIL;
        messagePacket.AddSeqId();
        messagePacket.Add(this.DM.tmp_WatchTowerData[(int) this.DM.m_WatchTowerData[dataIndex].ListIdx].LineID);
        messagePacket.Send();
        this.DM.m_WTList_Idx = dataIndex;
      }
      else
      {
        this.DM.m_WTList_Idx = dataIndex;
        this.door.OpenMenu(EGUIWindow.UI_Watchtower_Details, (int) this.DM.m_WatchTowerData[dataIndex].LineType, (int) this.mBD.Level);
      }
    }
    else
    {
      int index = (int) this.DM.m_WatchTowerData[dataIndex].ListIdx - 1;
      this.door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.DM.MarchEventData[index].Point.zoneID, this.DM.MarchEventData[index].Point.pointID, (byte) 0);
    }
  }

  public void OnTimer(UITimeBar sender)
  {
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
  }

  public void OnCancel(UITimeBar sender)
  {
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 13, (ushort) this.B_ID, (byte) 1, this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
  }

  private void Update()
  {
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
        if (networkNews != NetworkNews.Refresh_BuildBase)
        {
          if (networkNews != NetworkNews.Refresh_AttribEffectVal)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              break;
            this.Refresh_FontTexture();
            if ((Object) this.baseBuild != (Object) null)
              this.baseBuild.Refresh_FontTexture();
            if ((Object) this.timeBar != (Object) null && this.timeBar.enabled)
              this.timeBar.Refresh_FontTexture();
            for (int index = 0; index < 6; ++index)
            {
              if ((Object) this.Item_timebar[index] != (Object) null && this.Item_timebar[index].enabled)
                this.Item_timebar[index].Refresh_FontTexture();
            }
            break;
          }
          if (!((Object) this.baseBuild != (Object) null))
            break;
          this.baseBuild.MyUpdate((byte) 0);
          break;
        }
        this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 13, (ushort) 0);
        this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 13, this.mBD.Level);
        if (meg[1] == (byte) 1)
        {
          this.door.CloseMenu(true);
          break;
        }
        if (!((Object) this.baseBuild != (Object) null))
          break;
        this.baseBuild.MyUpdate(meg[1]);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_No != (Object) null && ((Behaviour) this.text_No).enabled)
    {
      ((Behaviour) this.text_No).enabled = false;
      ((Behaviour) this.text_No).enabled = true;
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.Item_textCoordinate[index] != (Object) null && ((Behaviour) this.Item_textCoordinate[index]).enabled)
      {
        ((Behaviour) this.Item_textCoordinate[index]).enabled = false;
        ((Behaviour) this.Item_textCoordinate[index]).enabled = true;
      }
      if ((Object) this.Item_textStatus[index] != (Object) null && ((Behaviour) this.Item_textStatus[index]).enabled)
      {
        ((Behaviour) this.Item_textStatus[index]).enabled = false;
        ((Behaviour) this.Item_textStatus[index]).enabled = true;
      }
      if ((Object) this.Item_textStatus_C[index] != (Object) null && ((Behaviour) this.Item_textStatus_C[index]).enabled)
      {
        ((Behaviour) this.Item_textStatus_C[index]).enabled = false;
        ((Behaviour) this.Item_textStatus_C[index]).enabled = true;
      }
      if ((Object) this.Item_text[index] != (Object) null && ((Behaviour) this.Item_text[index]).enabled)
      {
        ((Behaviour) this.Item_text[index]).enabled = false;
        ((Behaviour) this.Item_text[index]).enabled = true;
      }
      if ((Object) this.Item_textTimebar1[index] != (Object) null && ((Behaviour) this.Item_textTimebar1[index]).enabled)
      {
        ((Behaviour) this.Item_textTimebar1[index]).enabled = false;
        ((Behaviour) this.Item_textTimebar1[index]).enabled = true;
      }
      if ((Object) this.Item_textTimebar2[index] != (Object) null && ((Behaviour) this.Item_textTimebar2[index]).enabled)
      {
        ((Behaviour) this.Item_textTimebar2[index]).enabled = false;
        ((Behaviour) this.Item_textTimebar2[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        int topIdx = this.m_ScrollPanel.GetTopIdx();
        this.tmplist.Clear();
        if (this.DM.m_WatchTowerData.Count == 0)
        {
          this.bWatch = false;
          if (this.baseBuild.buildType == e_BuildType.Normal || this.baseBuild.buildType == e_BuildType.SelfUpgradeing || this.baseBuild.buildType == e_BuildType.SelfBackOuting)
            ((Component) this.text_No).gameObject.SetActive(true);
          this.m_ScrollPanel.gameObject.SetActive(false);
          break;
        }
        this.bWatch = true;
        for (int index = 0; index < this.DM.m_WatchTowerData.Count; ++index)
          this.tmplist.Add(112f);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        if (topIdx > 1)
          this.m_ScrollPanel.GoTo(topIdx + 1);
        if (!((UIBehaviour) this.text_No).IsActive())
          break;
        ((Component) this.text_No).gameObject.SetActive(false);
        if (this.baseBuild.buildType != e_BuildType.Normal && this.baseBuild.buildType != e_BuildType.SelfUpgradeing && this.baseBuild.buildType != e_BuildType.SelfBackOuting)
          break;
        this.m_ScrollPanel.gameObject.SetActive(true);
        break;
      case 2:
        if (this.DM.m_WTList_Idx == -1)
          break;
        this.door.OpenMenu(EGUIWindow.UI_Watchtower_Details, this.DM.m_WTInfo_Status, (int) this.mBD.Level);
        break;
      case 3:
        for (int index = 0; index < 6; ++index)
        {
          if ((Object) this.mScrollItem[index] != (Object) null && this.mScrollItem[index].m_BtnID1 != -1)
          {
            int listIdx = (int) this.DM.m_WatchTowerData[this.mScrollItem[index].m_BtnID1].ListIdx;
            if (this.mScrollItem[index].m_BtnID2 == 1 && this.m_Effect >= (ushort) 7 && listIdx == arg2)
            {
              this.begin = this.DM.tmp_WatchTowerData[listIdx].MarchTimeData.BeginTime;
              this.target = this.begin + (long) this.DM.tmp_WatchTowerData[listIdx].MarchTimeData.RequireTime;
              this.GUIM.SetTimerBar(this.Item_timebar[index], this.begin, this.target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985U).ToString(), string.Empty);
            }
          }
        }
        break;
    }
  }
}
