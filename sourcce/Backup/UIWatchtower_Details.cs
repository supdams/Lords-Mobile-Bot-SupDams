// Decompiled with JetBrains decompiler
// Type: UIWatchtower_Details
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIWatchtower_Details : GUIWindow, IUIButtonClickHandler, IUTimeBarOnTimer
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform Tmp;
  private Transform CustomPanelT;
  private RectTransform tmpRC;
  private RectTransform[] Coordinate1_RT = new RectTransform[3];
  private RectTransform[] Coordinate2_RT = new RectTransform[3];
  private UIButton btn_EXIT;
  private UIButton btn_Coordinate_1;
  private UIButton btn_Coordinate_2;
  private UIButton btn_Prepare;
  private UIButton btn_Hero;
  private Image Img_Status;
  private Image Img_Lock;
  private Image Img_NoHero;
  private Image Img_Hero;
  private Image Img_HeroBG;
  private Image Img_HeroFrame;
  private Image Img_Drop;
  private Image[] ImgShowMain = new Image[2];
  private Sprite[] ImgList = new Sprite[15];
  private UIText text_Title;
  private UIText text_Title2;
  private UIText text_Drop;
  private UIText text_MainHero;
  private UIText text_NoTroops;
  private UIText text_TimeBar;
  private UIText text_Time;
  private UIText text_btnStr;
  private UIText[] text_PlayerName = new UIText[2];
  private UIText[] text_btnCoordinate = new UIText[2];
  private UIText[] text_tmpStr = new UIText[2];
  private UIText[] text_tmptimeBar = new UIText[2];
  private CString Cstr_Title;
  private CString[] Cstr_PlayerName = new CString[2];
  private CString[] Cstr_btnCoordinate = new CString[2];
  private UITimeBar timeBar;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private Material door_M;
  private Color R_Color = new Color(1f, 0.2941f, 0.4588f, 1f);
  private RoleBuildingData mBD;
  private int mStatus;
  private ushort m_Effect;
  private ushort[] stringStatus1 = new ushort[13];
  private ushort[] stringStatus2 = new ushort[15];
  private bool bHaveTroops = true;
  private bool bOpen;
  private float ShowTime;
  private List<int> _DataIdx = new List<int>();
  private CustomPanel tmpPanel;
  private Vector2 tmpV;
  private WatchTowerData tmpData;
  private UISpritesArray SArray;
  private bool bYolk;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    if (this.DM.m_WTList_Idx < 0 || this.DM.m_WTList_Idx > this.DM.m_WatchTowerData.Count || this.DM.m_WatchTowerData.Count == 0)
    {
      this.door.CloseMenu();
    }
    else
    {
      this.tmpData = this.DM.tmp_WatchTowerData[(int) this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx];
      if (this.tmpData.Index >= (byte) 0 && this.tmpData.Index <= (byte) 7 && this.DM.MarchEventData[(int) this.tmpData.Index].PointKind == POINT_KIND.PK_YOLK)
        this.bYolk = true;
      switch (this.tmpData.LineType)
      {
        case 5:
        case 7:
          this.mStatus = this.tmpData.Index == byte.MaxValue || this.bYolk ? 2 : 3;
          break;
        case 6:
          if (this.tmpData.Index == byte.MaxValue)
          {
            this.mStatus = 11;
            break;
          }
          if (this.bYolk)
          {
            this.mStatus = 12;
            break;
          }
          break;
        case 8:
          this.mStatus = this.tmpData.Index == byte.MaxValue || this.bYolk ? 5 : 6;
          break;
        case 10:
          this.mStatus = 8;
          break;
        case 11:
          this.mStatus = 7;
          break;
        case 12:
          this.mStatus = 1;
          break;
        case 13:
          this.mStatus = 9;
          break;
        case 22:
          this.mStatus = 13;
          break;
        default:
          this.mStatus = 2;
          break;
      }
      Transform transform = this.gameObject.transform;
      this.SArray = transform.GetComponent<UISpritesArray>();
      this.ImgList[0] = this.SArray.m_Sprites[6];
      this.ImgList[1] = this.SArray.m_Sprites[1];
      this.ImgList[2] = this.SArray.m_Sprites[1];
      this.ImgList[3] = this.SArray.m_Sprites[5];
      this.ImgList[4] = this.SArray.m_Sprites[0];
      this.ImgList[5] = this.SArray.m_Sprites[0];
      this.ImgList[6] = this.SArray.m_Sprites[4];
      this.ImgList[7] = this.SArray.m_Sprites[3];
      this.ImgList[8] = this.SArray.m_Sprites[2];
      this.ImgList[9] = this.SArray.m_Sprites[7];
      this.ImgList[10] = this.SArray.m_Sprites[8];
      this.ImgList[11] = this.SArray.m_Sprites[9];
      this.ImgList[12] = this.SArray.m_Sprites[10];
      this.ImgList[13] = this.SArray.m_Sprites[11];
      this.ImgList[14] = this.SArray.m_Sprites[12];
      this.Cstr_Title = StringManager.Instance.SpawnString(200);
      for (int index = 0; index < 2; ++index)
      {
        this.Cstr_PlayerName[index] = StringManager.Instance.SpawnString();
        this.Cstr_btnCoordinate[index] = StringManager.Instance.SpawnString();
      }
      this.text_tmpStr[0] = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[0].font = this.TTFont;
      this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(3896U);
      this.Tmp = transform.GetChild(1);
      this.Img_Status = this.Tmp.GetChild(2).GetComponent<Image>();
      if (this.mStatus > 0)
      {
        if (!this.bYolk)
        {
          this.Img_Status.sprite = this.mStatus != 11 ? (this.mStatus != 13 ? this.ImgList[this.mStatus - 1] : this.ImgList[14]) : this.ImgList[13];
        }
        else
        {
          Status_Kind mStatus = (Status_Kind) this.mStatus;
          switch (mStatus)
          {
            case Status_Kind.K_MusterAttack:
              this.Img_Status.sprite = this.ImgList[9];
              break;
            case Status_Kind.K_Attack:
              this.Img_Status.sprite = this.ImgList[10];
              break;
            case Status_Kind.K_Investigate:
              this.Img_Status.sprite = this.ImgList[11];
              break;
            case Status_Kind.K_Reinforce:
              this.Img_Status.sprite = this.ImgList[12];
              break;
            default:
              if (mStatus == Status_Kind.K_WonderHost)
              {
                this.Img_Status.sprite = this.ImgList[12];
                break;
              }
              break;
          }
        }
      }
      else
        this.Img_Status.sprite = this.ImgList[0];
      this.Img_Status.SetNativeSize();
      this.door_M = this.door.LoadMaterial();
      this.btn_Coordinate_1 = this.Tmp.GetChild(3).GetComponent<UIButton>();
      this.btn_Coordinate_1.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Coordinate_1.m_BtnID1 = 2;
      this.Coordinate1_RT[0] = this.Tmp.GetChild(3).GetComponent<RectTransform>();
      this.Coordinate1_RT[1] = this.Tmp.GetChild(3).GetChild(0).GetComponent<RectTransform>();
      this.Coordinate1_RT[2] = this.Tmp.GetChild(3).GetChild(1).GetComponent<RectTransform>();
      this.text_btnCoordinate[0] = this.Tmp.GetChild(3).GetChild(1).GetComponent<UIText>();
      this.text_btnCoordinate[0].font = this.TTFont;
      this.Cstr_btnCoordinate[0].ClearString();
      if (this.mStatus == 3 || this.mStatus == 6 || this.bYolk && (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 5 || this.mStatus == 8 || this.mStatus == 12) || this.tmpData.Index >= (byte) 0 && this.tmpData.Index <= (byte) 7 && this.DM.MarchEventData[(int) this.tmpData.Index].IsAmbushCamp() && this.mStatus == 1)
      {
        this.tmpV = this.bYolk ? DataManager.MapDataController.GetYolkPos((ushort) this.DM.MarchEventData[(int) this.tmpData.Index].DesPointLevel, DataManager.MapDataController.OtherKingdomData.kingdomID) : GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.DM.MarchEventData[(int) this.tmpData.Index].Point.zoneID, this.DM.MarchEventData[(int) this.tmpData.Index].Point.pointID));
        this.Cstr_btnCoordinate[0].StringToFormat(this.DM.mStringTable.GetStringByID(4505U));
        this.Cstr_btnCoordinate[0].IntToFormat((long) (int) this.tmpV.x);
        this.Cstr_btnCoordinate[0].StringToFormat(this.DM.mStringTable.GetStringByID(4506U));
        this.Cstr_btnCoordinate[0].IntToFormat((long) (int) this.tmpV.y);
        if (this.GUIM.IsArabic)
          this.Cstr_btnCoordinate[0].AppendFormat("{3}{2} {1}{0}");
        else
          this.Cstr_btnCoordinate[0].AppendFormat("{0}{1} {2}{3}");
        this.text_btnCoordinate[0].text = this.Cstr_btnCoordinate[0].ToString();
        this.text_btnCoordinate[0].SetAllDirty();
        this.text_btnCoordinate[0].cachedTextGenerator.Invalidate();
        for (int index = 0; index < 3; ++index)
          this.Coordinate1_RT[index].sizeDelta = new Vector2(this.text_btnCoordinate[0].preferredWidth, this.Coordinate1_RT[index].sizeDelta.y);
      }
      this.timeBar = this.Tmp.GetChild(4).GetComponent<UITimeBar>();
      this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.NormalType, string.Empty, string.Empty);
      this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
      this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
      this.timeBar.m_TimeBarID = 1;
      this.text_tmptimeBar[0] = this.Tmp.GetChild(4).GetChild(2).GetComponent<UIText>();
      this.text_tmptimeBar[1] = this.Tmp.GetChild(4).GetChild(3).GetComponent<UIText>();
      this.stringStatus1[0] = (ushort) 4984;
      this.stringStatus1[1] = (ushort) 4005;
      this.stringStatus1[2] = (ushort) 4004;
      this.stringStatus1[3] = (ushort) 9753;
      this.stringStatus1[4] = (ushort) 4006;
      this.stringStatus1[5] = (ushort) 4878;
      this.stringStatus1[6] = (ushort) 4008;
      this.stringStatus1[7] = (ushort) 4007;
      this.stringStatus1[8] = (ushort) 4003;
      this.stringStatus1[9] = (ushort) 9743;
      this.stringStatus1[10] = (ushort) 9762;
      this.stringStatus1[11] = (ushort) 9763;
      this.stringStatus1[12] = (ushort) 12099;
      this.stringStatus2[0] = (ushort) 4983;
      this.stringStatus2[1] = (ushort) 3997;
      this.stringStatus2[2] = (ushort) 3998;
      this.stringStatus2[3] = (ushort) 3998;
      this.stringStatus2[4] = (ushort) 3999;
      this.stringStatus2[5] = (ushort) 3999;
      this.stringStatus2[6] = (ushort) 4000;
      this.stringStatus2[7] = (ushort) 4001;
      this.stringStatus2[8] = (ushort) 4002;
      this.stringStatus2[9] = (ushort) 8577;
      this.stringStatus2[10] = (ushort) 8578;
      this.stringStatus2[11] = (ushort) 8579;
      this.stringStatus2[12] = (ushort) 8580;
      this.stringStatus2[13] = (ushort) 9739;
      this.stringStatus2[14] = (ushort) 12101;
      this.text_Title = this.Tmp.GetChild(5).GetComponent<UIText>();
      this.text_Title.font = this.TTFont;
      ((Graphic) this.text_Title).color = this.R_Color;
      this.text_Title2 = this.Tmp.GetChild(6).GetComponent<UIText>();
      this.text_Title2.font = this.TTFont;
      if (!this.bYolk)
      {
        if (this.mStatus == 11)
        {
          this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus1[9]);
          this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[13]);
        }
        else if (this.mStatus == 13)
        {
          this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus1[12]);
          this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[14]);
        }
        else if (this.tmpData.Index >= (byte) 0 && this.tmpData.Index <= (byte) 7 && this.DM.MarchEventData[(int) this.tmpData.Index].IsAmbushCamp())
        {
          switch (this.mStatus)
          {
            case 1:
              this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus1[10]);
              this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[0]);
              break;
            case 3:
              this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus1[3]);
              this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[3]);
              break;
            case 6:
              this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus1[11]);
              this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[5]);
              break;
          }
        }
        else if (this.mStatus > 0)
        {
          this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus1[this.mStatus - 1]);
          this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[this.mStatus - 1]);
        }
      }
      else
      {
        this.Cstr_Title.ClearString();
        this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.DM.MarchEventData[(int) this.tmpData.Index].DesPointLevel, (ushort) 0));
        Status_Kind mStatus = (Status_Kind) this.mStatus;
        switch (mStatus)
        {
          case Status_Kind.K_MusterAttack:
            this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8544U));
            this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[9]);
            break;
          case Status_Kind.K_Attack:
            this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8545U));
            this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[10]);
            break;
          case Status_Kind.K_Investigate:
            this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8546U));
            this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[11]);
            break;
          case Status_Kind.K_Reinforce:
            this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8547U));
            this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint) this.stringStatus2[12]);
            break;
          default:
            if (mStatus == Status_Kind.K_WonderHost)
            {
              this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(9917U));
              this.text_Title2.text = this.DM.mStringTable.GetStringByID(9918U);
              break;
            }
            break;
        }
        this.text_Title.text = this.Cstr_Title.ToString();
      }
      this.text_Title.SetAllDirty();
      this.text_Title.cachedTextGenerator.Invalidate();
      this.text_Title2.SetAllDirty();
      this.text_Title2.cachedTextGenerator.Invalidate();
      this.text_PlayerName[0] = this.Tmp.GetChild(7).GetComponent<UIText>();
      this.text_PlayerName[0].font = this.TTFont;
      this.text_PlayerName[0].text = this.DM.mStringTable.GetStringByID(4009U);
      this.text_PlayerName[1] = this.Tmp.GetChild(8).GetComponent<UIText>();
      this.text_PlayerName[1].font = this.TTFont;
      this.text_Time = this.Tmp.GetChild(9).GetComponent<UIText>();
      this.text_Time.font = this.TTFont;
      this.text_Time.text = this.DM.mStringTable.GetStringByID(4041U);
      this.text_TimeBar = this.Tmp.GetChild(10).GetComponent<UIText>();
      this.text_TimeBar.font = this.TTFont;
      this.text_TimeBar.alignment = TextAnchor.UpperLeft;
      this.CustomPanelT = transform.GetChild(2);
      this.Tmp = transform.GetChild(3);
      this.Img_Lock = this.Tmp.GetComponent<Image>();
      this.Img_Lock.sprite = this.door.LoadSprite("UI_main_lock");
      ((MaskableGraphic) this.Img_Lock).material = this.door_M;
      ((Component) this.Img_Lock).gameObject.SetActive(false);
      this.text_tmpStr[1] = this.Tmp.GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[1].font = this.TTFont;
      this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(4015U);
      this.Tmp = transform.GetChild(4);
      this.Img_NoHero = this.Tmp.GetChild(0).GetComponent<Image>();
      this.Img_Hero = this.Tmp.GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) this.Img_Hero).material = this.GUIM.m_IconSpriteAsset.GetMaterial();
      this.btn_Hero = this.Tmp.GetChild(1).GetComponent<UIButton>();
      this.btn_Hero.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Hero.m_BtnID1 = 5;
      this.btn_Hero.m_EffectType = e_EffectType.e_Scale;
      this.btn_Hero.transition = (Selectable.Transition) 0;
      this.Img_HeroBG = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) this.Img_HeroBG).material = this.GUIM.m_IconSpriteAsset.GetMaterial();
      this.tmpRC = ((Component) this.Img_HeroBG).transform.GetComponent<RectTransform>();
      this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Img_HeroFrame = this.Tmp.GetChild(1).GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) this.Img_HeroFrame).material = this.GUIM.GetFrameMaterial();
      this.tmpRC = ((Component) this.Img_HeroFrame).transform.GetComponent<RectTransform>();
      this.tmpRC.anchorMin = Vector2.zero;
      this.tmpRC.anchorMax = new Vector2(1f, 1f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Img_Drop = this.Tmp.GetChild(2).GetComponent<Image>();
      this.text_Drop = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_Drop.font = this.TTFont;
      this.text_Drop.text = this.DM.mStringTable.GetStringByID(4016U);
      this.btn_Prepare = this.Tmp.GetChild(3).GetComponent<UIButton>();
      this.btn_Prepare.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Prepare.m_BtnID1 = 4;
      this.btn_Prepare.m_EffectType = e_EffectType.e_Scale;
      this.btn_Prepare.transition = (Selectable.Transition) 0;
      this.text_btnStr = this.Tmp.GetChild(3).GetChild(1).GetComponent<UIText>();
      this.text_btnStr.font = this.TTFont;
      this.text_btnStr.text = this.DM.mStringTable.GetStringByID(8532U);
      this.btn_Coordinate_2 = this.Tmp.GetChild(4).GetComponent<UIButton>();
      this.btn_Coordinate_2.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Coordinate_2.m_BtnID1 = 3;
      this.Coordinate2_RT[0] = this.Tmp.GetChild(4).GetComponent<RectTransform>();
      this.Coordinate2_RT[1] = this.Tmp.GetChild(4).GetChild(0).GetComponent<RectTransform>();
      this.Coordinate2_RT[2] = this.Tmp.GetChild(4).GetChild(1).GetComponent<RectTransform>();
      this.text_btnCoordinate[1] = this.Tmp.GetChild(4).GetChild(1).GetComponent<UIText>();
      this.text_btnCoordinate[1].font = this.TTFont;
      this.text_MainHero = this.Tmp.GetChild(5).GetComponent<UIText>();
      this.text_MainHero.font = this.TTFont;
      this.ImgShowMain[0] = this.Tmp.GetChild(6).GetComponent<Image>();
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_legion_icon_13");
      this.ImgShowMain[0].sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.ImgShowMain[0]).material = this.GUIM.GetFrameMaterial();
      this.ImgShowMain[1] = this.Tmp.GetChild(6).GetChild(0).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_legion_icon_12");
      this.ImgShowMain[1].sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.ImgShowMain[1]).material = this.GUIM.GetFrameMaterial();
      Image component = transform.GetChild(5).GetComponent<Image>();
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) component).enabled = false;
      this.btn_EXIT = transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 1;
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
      this.text_NoTroops = transform.GetChild(6).GetComponent<UIText>();
      this.text_NoTroops.font = this.TTFont;
      this.text_NoTroops.text = this.DM.mStringTable.GetStringByID(3974U);
      this.tmpRC = ((Component) this.text_Title).GetComponent<RectTransform>();
      if (this.mStatus == 3 || this.mStatus == 6 || this.bYolk && (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 5 || this.mStatus == 8 || this.mStatus == 12) || this.tmpData.Index >= (byte) 0 && this.tmpData.Index <= (byte) 7 && this.DM.MarchEventData[(int) this.tmpData.Index].IsAmbushCamp() && this.mStatus == 1)
      {
        if ((double) this.text_Title.preferredWidth > (double) ((Graphic) this.text_Title).rectTransform.sizeDelta.x)
        {
          ((Graphic) this.text_Title).rectTransform.anchoredPosition = new Vector2(-50f, this.tmpRC.anchoredPosition.y);
          ((Graphic) this.text_Title).rectTransform.sizeDelta = new Vector2(600f, ((Graphic) this.text_Title).rectTransform.sizeDelta.y);
          this.Coordinate1_RT[0].anchoredPosition = new Vector2(670f, this.Coordinate1_RT[0].anchoredPosition.y);
        }
        else
        {
          ((Graphic) this.text_Title).rectTransform.sizeDelta = new Vector2(this.text_Title.preferredWidth, ((Graphic) this.text_Title).rectTransform.sizeDelta.y);
          this.Coordinate1_RT[0].anchoredPosition = new Vector2((float) (420.0 + (double) this.text_Title.preferredWidth / 2.0), this.Coordinate1_RT[0].anchoredPosition.y);
        }
      }
      else if ((double) this.text_Title.preferredWidth > (double) this.tmpRC.sizeDelta.x)
        this.tmpRC.sizeDelta = (double) this.text_Title.preferredWidth <= 710.0 ? new Vector2(this.text_Title.preferredWidth, this.tmpRC.sizeDelta.y) : new Vector2(710f, this.tmpRC.sizeDelta.y);
      switch (this.mStatus)
      {
        case 1:
        case 2:
          if (this.bYolk)
            ((Component) this.btn_Coordinate_1).gameObject.SetActive(true);
          if (this.mStatus == 1 && this.tmpData.Index >= (byte) 0 && this.tmpData.Index <= (byte) 7 && this.DM.MarchEventData[(int) this.tmpData.Index].IsAmbushCamp())
          {
            ((Component) this.btn_Coordinate_1).gameObject.SetActive(true);
            break;
          }
          break;
        case 3:
          ((Component) this.text_MainHero).gameObject.SetActive(true);
          ((Component) this.btn_Coordinate_1).gameObject.SetActive(true);
          break;
        case 5:
          this.bHaveTroops = false;
          break;
        case 6:
          ((Component) this.btn_Coordinate_1).gameObject.SetActive(true);
          this.bHaveTroops = false;
          break;
        case 7:
          if (this.bYolk)
          {
            ((Component) this.btn_Coordinate_1).gameObject.SetActive(true);
            break;
          }
          break;
        case 8:
          if (this.bYolk)
          {
            ((Component) this.btn_Coordinate_1).gameObject.SetActive(true);
            break;
          }
          break;
        case 9:
          this.bHaveTroops = false;
          break;
        case 12:
          if (this.bYolk)
          {
            ((Component) this.btn_Coordinate_1).gameObject.SetActive(true);
            break;
          }
          break;
        case 13:
          this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 13, (ushort) 0);
          this.bHaveTroops = this.mBD.Level >= (byte) 19;
          break;
      }
      this._DataIdx.Clear();
      if (this.bHaveTroops)
      {
        this.tmpPanel = this.CustomPanelT.gameObject.AddComponent<CustomPanel>();
        if (this.mStatus == 13)
        {
          this._DataIdx.Add(43);
        }
        else
        {
          this._DataIdx.Add(1);
          if (this.mStatus != 8 && this.mStatus != 7)
            this._DataIdx.Add(2);
        }
      }
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
      this.bOpen = true;
    }
  }

  public void CheckEffect()
  {
    this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 13, (ushort) 0);
    this.m_Effect = (ushort) this.mBD.Level;
    this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(3931U);
    this.text_TimeBar.alignment = TextAnchor.UpperCenter;
    ((Component) this.Img_NoHero).gameObject.SetActive(true);
    bool flag = true;
    if (this.m_Effect == (ushort) 25)
    {
      if (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 3 || this.mStatus == 5 || this.mStatus == 12)
      {
        if (!this.bYolk)
          ((Component) this.btn_Prepare).gameObject.SetActive(true);
        flag = false;
      }
      if ((this.mStatus == 1 || this.mStatus == 2) && !this.bYolk)
        ((Component) this.Img_Drop).gameObject.SetActive(true);
    }
    if (this.m_Effect >= (ushort) 23 && this.mStatus == 11)
      flag = false;
    if (this.m_Effect >= (ushort) 21 && (this.mStatus == 7 || this.mStatus == 8))
      flag = false;
    if (this.m_Effect >= (ushort) 19 && this.mStatus == 13)
      flag = false;
    if (this.m_Effect < (ushort) 17)
      ;
    if (this.m_Effect >= (ushort) 15)
    {
      ((Component) this.Img_Hero).gameObject.SetActive(true);
      ((Component) this.Img_NoHero).gameObject.SetActive(false);
      Hero recordByKey = this.DM.HeroTable.GetRecordByKey(this.DM.m_WT_MH);
      this.Img_Hero.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
      this.Img_HeroBG.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
      this.Img_HeroFrame.sprite = this.GUIM.LoadFrameSprite("hf011");
      if (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 3 || this.mStatus == 11 || this.mStatus == 12)
        ((Component) this.text_MainHero).gameObject.SetActive(true);
      if (this.DM.m_WT_WithSupremeLeader > (byte) 0)
      {
        this.text_MainHero.text = this.DM.mStringTable.GetStringByID(4012U);
        ((Component) this.ImgShowMain[0]).gameObject.SetActive(true);
      }
      else
      {
        this.text_MainHero.text = this.DM.mStringTable.GetStringByID(4013U);
        ((Component) this.ImgShowMain[0]).gameObject.SetActive(false);
      }
      if (this.mStatus == 9)
        flag = false;
    }
    if (this.m_Effect < (ushort) 13)
      ;
    if (this.m_Effect < (ushort) 10)
      ;
    if (this.m_Effect >= (ushort) 7)
    {
      if (this.DM.m_WTList_Idx == -1)
      {
        this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(5776U);
        this.text_TimeBar.SetAllDirty();
        this.text_TimeBar.cachedTextGenerator.Invalidate();
        this.text_TimeBar.alignment = TextAnchor.UpperCenter;
        this.timeBar.gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.text_TimeBar).gameObject.SetActive(false);
        long beginTime = this.DM.tmp_WatchTowerData[(int) this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.BeginTime;
        long target = beginTime + (long) this.DM.tmp_WatchTowerData[(int) this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.RequireTime;
        this.GUIM.SetTimerBar(this.timeBar, beginTime, target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985U), string.Empty);
        this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
      }
    }
    if (this.m_Effect >= (ushort) 4)
    {
      this.Cstr_PlayerName[0].ClearString();
      ((Graphic) this.text_PlayerName[1]).color = Color.white;
      this.Cstr_PlayerName[0].Append(this.DM.mStringTable.GetStringByID(4009U));
      this.text_PlayerName[0].text = this.Cstr_PlayerName[0].ToString();
      this.text_PlayerName[0].SetAllDirty();
      this.text_PlayerName[0].cachedTextGenerator.Invalidate();
      this.Cstr_PlayerName[1].ClearString();
      CString Name = StringManager.Instance.StaticString1024();
      CString Tag = StringManager.Instance.StaticString1024();
      CString cstring = StringManager.Instance.StaticString1024();
      Name.ClearString();
      Tag.ClearString();
      cstring.ClearString();
      if (this.m_Effect >= (ushort) 10)
      {
        Name.Append(this.DM.m_WT_Name);
        if (this.DM.m_WT_AllianceName.Length > 0)
        {
          Tag.Append(this.DM.m_WT_AllianceName);
          if ((int) this.DM.m_WT_KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
          {
            ((Graphic) this.text_PlayerName[1]).color = new Color(1f, 0.294f, 0.459f);
            GameConstants.FormatRoleName(this.Cstr_PlayerName[1], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: this.DM.m_WT_KingdomID);
          }
          else
            GameConstants.FormatRoleName(this.Cstr_PlayerName[1], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        }
        else if ((int) this.DM.m_WT_KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          ((Graphic) this.text_PlayerName[1]).color = new Color(1f, 0.294f, 0.459f);
          GameConstants.FormatRoleName(this.Cstr_PlayerName[1], Name, bCheckedNickname: (byte) 0, KingdomID: this.DM.m_WT_KingdomID);
        }
        else
          GameConstants.FormatRoleName(this.Cstr_PlayerName[1], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
      {
        Name.Append(this.DM.m_WT_Name);
        if ((int) this.DM.m_WT_KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          ((Graphic) this.text_PlayerName[1]).color = new Color(1f, 0.294f, 0.459f);
          GameConstants.FormatRoleName(this.Cstr_PlayerName[1], Name, bCheckedNickname: (byte) 0, KingdomID: this.DM.m_WT_KingdomID);
        }
        else
          GameConstants.FormatRoleName(this.Cstr_PlayerName[1], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      this.text_PlayerName[1].text = this.Cstr_PlayerName[1].ToString();
      this.text_PlayerName[1].SetAllDirty();
      this.text_PlayerName[1].cachedTextGenerator.Invalidate();
      this.Cstr_btnCoordinate[1].ClearString();
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.DM.m_WT_Point.zoneID, this.DM.m_WT_Point.pointID));
      this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4505U));
      this.Cstr_btnCoordinate[1].IntToFormat((long) (int) this.tmpV.x);
      this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4506U));
      this.Cstr_btnCoordinate[1].IntToFormat((long) (int) this.tmpV.y);
      if (this.GUIM.IsArabic)
        this.Cstr_btnCoordinate[1].AppendFormat("{3}{2} {1}{0}");
      else
        this.Cstr_btnCoordinate[1].AppendFormat("{0}{1} {2}{3}");
      this.text_btnCoordinate[1].text = this.Cstr_btnCoordinate[1].ToString();
      this.text_btnCoordinate[1].SetAllDirty();
      this.text_btnCoordinate[1].cachedTextGenerator.Invalidate();
      for (int index = 0; index < 3; ++index)
        this.Coordinate2_RT[index].sizeDelta = new Vector2(this.text_btnCoordinate[1].preferredWidth, this.Coordinate2_RT[index].sizeDelta.y);
    }
    else
    {
      this.text_PlayerName[1].text = this.DM.mStringTable.GetStringByID(3931U);
      this.Cstr_btnCoordinate[1].ClearString();
      this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4505U));
      this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(3931U));
      this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4506U));
      this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(3931U));
      if (this.GUIM.IsArabic)
        this.Cstr_btnCoordinate[1].AppendFormat("{3}{2} {1}{0}");
      else
        this.Cstr_btnCoordinate[1].AppendFormat("{0}{1} {2}{3}");
      this.text_btnCoordinate[1].text = this.Cstr_btnCoordinate[1].ToString();
      this.text_btnCoordinate[1].SetAllDirty();
      this.text_btnCoordinate[1].cachedTextGenerator.Invalidate();
      for (int index = 0; index < 3; ++index)
        this.Coordinate2_RT[index].sizeDelta = new Vector2(this.text_btnCoordinate[1].preferredWidth, this.Coordinate2_RT[index].sizeDelta.y);
    }
    ((Component) this.Img_Lock).gameObject.SetActive(flag);
    if (((UIBehaviour) this.text_TimeBar).IsActive())
      ((Component) this.timeBar.m_TimeText).gameObject.SetActive(false);
    else if (!((UIBehaviour) this.timeBar.m_TimeText).IsActive())
      ((Component) this.timeBar.m_TimeText).gameObject.SetActive(true);
    if (this.bHaveTroops)
    {
      this.tmpPanel.SetPanelData(this._DataIdx, mLV: (int) this.m_Effect, mKind: this.mStatus, mHeight: 0.0f);
      this.tmpPanel.InitScrollPanel();
    }
    else
      ((Component) this.text_NoTroops).gameObject.SetActive(true);
  }

  public override void OnClose()
  {
    this._DataIdx = (List<int>) null;
    if ((Object) this.tmpPanel != (Object) null)
      this.tmpPanel.Destroy();
    if ((Object) this.timeBar != (Object) null)
      this.GUIM.RemoverTimeBaarToList(this.timeBar);
    if (this.Cstr_Title != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Title);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_PlayerName[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_PlayerName[index]);
      if (this.Cstr_btnCoordinate[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_btnCoordinate[index]);
    }
  }

  public void OnTimer(UITimeBar sender)
  {
    if (this.m_Effect < (ushort) 4 || !this.timeBar.gameObject.activeSelf)
      return;
    this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(5776U);
    this.text_TimeBar.SetAllDirty();
    this.text_TimeBar.cachedTextGenerator.Invalidate();
    this.text_TimeBar.alignment = TextAnchor.UpperCenter;
    this.timeBar.gameObject.SetActive(false);
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

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 2:
        this.door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.DM.MarchEventData[(int) this.tmpData.Index].Point.zoneID, this.DM.MarchEventData[(int) this.tmpData.Index].Point.pointID, (byte) 0);
        break;
      case 3:
        if (this.m_Effect < (ushort) 4)
          break;
        this.door.GoToPointCode(this.DM.m_WTInfo_KID, this.DM.m_WT_Point.zoneID, this.DM.m_WT_Point.pointID, (byte) 0);
        break;
      case 4:
        this.door.OpenMenu(EGUIWindow.UI_BuffList, 2);
        break;
      case 5:
        if (this.m_Effect < (ushort) 4 || this.DM.m_WT_Name == null || !(this.DM.m_WT_Name != string.Empty))
          break;
        DataManager.Instance.ShowLordProfile(this.DM.m_WT_Name);
        break;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (this.bOpen && (Object) this.text_TimeBar != (Object) null)
    {
      this.CheckEffect();
      this.bOpen = false;
    }
    if (!((Object) this.ImgShowMain[0] != (Object) null) || !((UIBehaviour) this.ImgShowMain[0]).IsActive())
      return;
    this.ShowTime += Time.smoothDeltaTime;
    if ((double) this.ShowTime < 0.0)
      return;
    if ((double) this.ShowTime >= 2.0)
      this.ShowTime = 0.0f;
    ((Graphic) this.ImgShowMain[1]).color = new Color(1f, 1f, 1f, (double) this.ShowTime <= 1.0 ? this.ShowTime : 2f - this.ShowTime);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.CheckEffect();
        break;
      case 2:
        if (this.m_Effect < (ushort) 7 || arg2 != this.DM.m_WTList_Idx)
          break;
        long beginTime = this.DM.tmp_WatchTowerData[(int) this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.BeginTime;
        long target = beginTime + (long) this.DM.tmp_WatchTowerData[(int) this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.RequireTime;
        this.GUIM.SetTimerBar(this.timeBar, beginTime, target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985U), string.Empty);
        break;
      case 3:
        if (arg2 != this.DM.m_WTList_Idx)
          break;
        ((Component) this.text_TimeBar).gameObject.SetActive(true);
        this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(5776U);
        this.text_TimeBar.alignment = TextAnchor.UpperCenter;
        this.timeBar.gameObject.SetActive(false);
        break;
    }
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
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        if ((Object) this.tmpPanel != (Object) null)
          this.tmpPanel.Refresh_FontTexture();
        if (!((Object) this.timeBar != (Object) null) || !this.timeBar.enabled)
          break;
        this.timeBar.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_Title2 != (Object) null && ((Behaviour) this.text_Title2).enabled)
    {
      ((Behaviour) this.text_Title2).enabled = false;
      ((Behaviour) this.text_Title2).enabled = true;
    }
    if ((Object) this.text_Drop != (Object) null && ((Behaviour) this.text_Drop).enabled)
    {
      ((Behaviour) this.text_Drop).enabled = false;
      ((Behaviour) this.text_Drop).enabled = true;
    }
    if ((Object) this.text_MainHero != (Object) null && ((Behaviour) this.text_MainHero).enabled)
    {
      ((Behaviour) this.text_MainHero).enabled = false;
      ((Behaviour) this.text_MainHero).enabled = true;
    }
    if ((Object) this.text_NoTroops != (Object) null && ((Behaviour) this.text_NoTroops).enabled)
    {
      ((Behaviour) this.text_NoTroops).enabled = false;
      ((Behaviour) this.text_NoTroops).enabled = true;
    }
    if ((Object) this.text_TimeBar != (Object) null && ((Behaviour) this.text_TimeBar).enabled)
    {
      ((Behaviour) this.text_TimeBar).enabled = false;
      ((Behaviour) this.text_TimeBar).enabled = true;
    }
    if ((Object) this.text_Time != (Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_Time).enabled = false;
      ((Behaviour) this.text_Time).enabled = true;
    }
    if ((Object) this.text_btnStr != (Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_btnStr).enabled = false;
      ((Behaviour) this.text_btnStr).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_PlayerName[index] != (Object) null && ((Behaviour) this.text_PlayerName[index]).enabled)
      {
        ((Behaviour) this.text_PlayerName[index]).enabled = false;
        ((Behaviour) this.text_PlayerName[index]).enabled = true;
      }
      if ((Object) this.text_btnCoordinate[index] != (Object) null && ((Behaviour) this.text_btnCoordinate[index]).enabled)
      {
        ((Behaviour) this.text_btnCoordinate[index]).enabled = false;
        ((Behaviour) this.text_btnCoordinate[index]).enabled = true;
      }
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
      if ((Object) this.text_tmptimeBar[index] != (Object) null && ((Behaviour) this.text_tmptimeBar[index]).enabled)
      {
        ((Behaviour) this.text_tmptimeBar[index]).enabled = false;
        ((Behaviour) this.text_tmptimeBar[index]).enabled = true;
      }
    }
  }
}
