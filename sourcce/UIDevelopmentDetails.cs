// Decompiled with JetBrains decompiler
// Type: UIDevelopmentDetails
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIDevelopmentDetails : GUIWindow, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform Tmp;
  private Transform Tmp1;
  private RectTransform Img_BGRT;
  private RectTransform Img_PanelRT;
  private RectTransform Custom_PanelRT;
  private RectTransform Custom_ContentRT;
  public UIButton btn_EXIT;
  private UIButton tmpbtn;
  private Image tmpImg;
  private Image Img_Panel;
  private UIText text_Title;
  public CustomPanel tmpPanel;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private List<int> _DataIdx = new List<int>();
  private bool bOpen = true;
  private bool bOpenEnd;
  private bool UpdateLater;
  private EDevelopmentDetail_OpenKind mOpenType;
  private int DataIdx;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mOpenType = (EDevelopmentDetail_OpenKind) arg1;
    this.DataIdx = arg2;
    Transform transform = this.gameObject.transform;
    this.tmpImg = transform.GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      ((Graphic) this.tmpImg).rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      ((Graphic) this.tmpImg).rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.tmpbtn = transform.GetChild(0).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpbtn.m_BtnID1 = 1;
    this.tmpbtn.image.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.tmpbtn.image).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Tmp = transform.GetChild(1);
    this.tmpImg = this.Tmp.GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_009");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    this.Img_BGRT = this.Tmp.GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(0);
    this.tmpImg = this.Tmp1.GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_con_title_orange");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    this.Img_Panel = this.Tmp.GetChild(1).GetComponent<Image>();
    this.Img_Panel.sprite = this.door.LoadSprite("UI_main_box_010");
    ((MaskableGraphic) this.Img_Panel).material = this.door.LoadMaterial();
    this.Img_PanelRT = this.Tmp.GetChild(1).GetComponent<RectTransform>();
    this.text_Title = this.Tmp.GetChild(2).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.tmpImg = transform.GetChild(2).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      ((Behaviour) this.tmpImg).enabled = false;
      ((Graphic) this.tmpImg).rectTransform.anchoredPosition = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.btn_EXIT = transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 1;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.door.LoadMaterial();
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    switch (this.mOpenType)
    {
      case EDevelopmentDetail_OpenKind.WatchTower:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.text_Title.text = this.DM.mStringTable.GetStringByID(4042U);
        this._DataIdx.Clear();
        this._DataIdx.Add(15);
        break;
      case EDevelopmentDetail_OpenKind.ArmyInfo:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.tmpPanel.DataIdx = this.DataIdx;
        this.text_Title.text = this.DM.mStringTable.GetStringByID(570U);
        this._DataIdx.Clear();
        if (this.DM.MarchEventData[this.DataIdx].Type != EMarchEventType.EMET_HitMonsterMarching && this.DM.MarchEventData[this.DataIdx].Type != EMarchEventType.EMET_HitMonsterReturn && this.DM.MarchEventData[this.DataIdx].Type != EMarchEventType.EMET_HitMonsterRetreat)
          this._DataIdx.Add(16);
        int num = 0;
        for (int index = 0; index < 5; ++index)
        {
          if (this.DM.MarchEventData[this.DataIdx].HeroID[index] != (ushort) 0)
            ++num;
        }
        if (num > 0)
        {
          this._DataIdx.Add(17);
          break;
        }
        break;
      case EDevelopmentDetail_OpenKind.Home_Wall_TrapInfo:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.text_Title.text = this.DM.mStringTable.GetStringByID(4926U);
        this._DataIdx.Clear();
        this._DataIdx.Add(18);
        this._DataIdx.Add(19);
        this._DataIdx.Add(20);
        this._DataIdx.Add(21);
        break;
      case EDevelopmentDetail_OpenKind.Home_ArmyInfo:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.text_Title.text = this.DM.mStringTable.GetStringByID(4917U);
        this._DataIdx.Clear();
        this._DataIdx.Add(22);
        this._DataIdx.Add(23);
        this._DataIdx.Add(24);
        break;
      case EDevelopmentDetail_OpenKind.Home_WatchTower:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.text_Title.text = this.DM.mStringTable.GetStringByID(7225U);
        this.tmpPanel.SetPVE_Data((ushort) ((uint) DataManager.StageDataController.StageRecord[2] + 1U));
        this._DataIdx.Clear();
        this._DataIdx.Add(30);
        this._DataIdx.Add(25);
        this._DataIdx.Add(29);
        this._DataIdx.Add(27);
        this._DataIdx.Add(28);
        this._DataIdx.Add(26);
        NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, (object) this);
        break;
      case EDevelopmentDetail_OpenKind.JailPrisoners:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.text_Title.text = this.DM.mStringTable.GetStringByID(7789U);
        this._DataIdx.Clear();
        this._DataIdx.Add(31);
        break;
      case EDevelopmentDetail_OpenKind.CaveInfo:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.text_Title.text = this.DM.mStringTable.GetStringByID(570U);
        this._DataIdx.Clear();
        this._DataIdx.Add(33);
        if (HideArmyManager.Instance.IsLordInShelter())
        {
          this._DataIdx.Add(34);
          break;
        }
        break;
      case EDevelopmentDetail_OpenKind.KingRewardList:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.tmpPanel.DataIdx = this.DataIdx;
        this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(DataManager.Instance.KingGift.GetGiftList()[this.DataIdx].ItemID).EquipName);
        this._DataIdx.Clear();
        this._DataIdx.Add(35);
        break;
      case EDevelopmentDetail_OpenKind.WorldKingRewardList:
      case EDevelopmentDetail_OpenKind.NobilityRewardList:
        this.tmpPanel = ((Component) this.Img_Panel).gameObject.AddComponent<CustomPanel>();
        this.tmpPanel.DataIdx = this.DataIdx;
        this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(DataManager.Instance.KingGift.GetGiftList()[this.DataIdx].ItemID).EquipName);
        this._DataIdx.Clear();
        this._DataIdx.Add(39);
        break;
    }
    switch (this.mOpenType)
    {
      case EDevelopmentDetail_OpenKind.Home_WatchTower:
        this.tmpPanel.SetPanelData(this._DataIdx, true, mLV: 1110, mKind: 10, mHeight: 0.0f);
        break;
      case EDevelopmentDetail_OpenKind.CaveInfo:
        this.tmpPanel.SetPanelData(this._DataIdx, true, mLV: (int) this.GUIM.BuildingData.GetBuildData((ushort) 13, (ushort) 0).Level, mHeight: 0.0f);
        break;
      default:
        this.tmpPanel.SetPanelData(this._DataIdx, true, mLV: 1110, mHeight: 0.0f);
        break;
    }
    this.PreResizeForm();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 6);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1 || !((Object) this.door != (Object) null))
      return;
    this.door.CloseMenu();
  }

  public override void UpdateUI(int arg1, int arg2) => this.ReflashContent(arg1, arg2);

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.bOpen)
    {
      this.UpdateLater = true;
    }
    else
    {
      NetworkNews networkNews = (NetworkNews) meg[0];
      switch (networkNews)
      {
        case NetworkNews.Login:
        case NetworkNews.Refresh:
          switch (this.mOpenType)
          {
            case EDevelopmentDetail_OpenKind.WatchTower:
              return;
            case EDevelopmentDetail_OpenKind.ArmyInfo:
              return;
            case EDevelopmentDetail_OpenKind.Home_Wall_TrapInfo:
            case EDevelopmentDetail_OpenKind.Home_ArmyInfo:
              switch ((NetworkNews) meg[0])
              {
                case NetworkNews.Refresh_Resource:
                  return;
                case NetworkNews.Refresh_ServerTime:
                  return;
              }
              break;
          }
          this.ReflashContent(0, 0);
          break;
        default:
          if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
          {
            if ((Object) this.tmpPanel != (Object) null)
            {
              this.tmpPanel.Refresh_FontTexture();
              this.Refresh_FontTexture();
            }
            if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
            {
              ((Behaviour) this.text_Title).enabled = false;
              ((Behaviour) this.text_Title).enabled = true;
              goto case NetworkNews.Login;
            }
            else
              goto case NetworkNews.Login;
          }
          else
            goto case NetworkNews.Login;
      }
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.tmpPanel.tmpText_Info != (Object) null && ((Behaviour) this.tmpPanel.tmpText_Info).enabled)
    {
      ((Behaviour) this.tmpPanel.tmpText_Info).enabled = false;
      ((Behaviour) this.tmpPanel.tmpText_Info).enabled = true;
    }
    for (int index1 = 0; index1 < 6; ++index1)
    {
      if ((Object) this.tmpPanel.Text_Info[index1] != (Object) null && ((Behaviour) this.tmpPanel.Text_Info[index1]).enabled)
      {
        ((Behaviour) this.tmpPanel.Text_Info[index1]).enabled = false;
        ((Behaviour) this.tmpPanel.Text_Info[index1]).enabled = true;
      }
      if ((Object) this.tmpPanel.Text_End[index1] != (Object) null && ((Behaviour) this.tmpPanel.Text_End[index1]).enabled)
      {
        ((Behaviour) this.tmpPanel.Text_End[index1]).enabled = false;
        ((Behaviour) this.tmpPanel.Text_End[index1]).enabled = true;
      }
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if ((Object) this.tmpPanel.Text_Title[index1][index2] != (Object) null && ((Behaviour) this.tmpPanel.Text_Title[index1][index2]).enabled)
        {
          ((Behaviour) this.tmpPanel.Text_Title[index1][index2]).enabled = false;
          ((Behaviour) this.tmpPanel.Text_Title[index1][index2]).enabled = true;
        }
        if ((Object) this.tmpPanel.Text_TextStr[index1][index2] != (Object) null && ((Behaviour) this.tmpPanel.Text_TextStr[index1][index2]).enabled)
        {
          ((Behaviour) this.tmpPanel.Text_TextStr[index1][index2]).enabled = false;
          ((Behaviour) this.tmpPanel.Text_TextStr[index1][index2]).enabled = true;
        }
        if ((Object) this.tmpPanel.Text_LeftAlign[index1][index2] != (Object) null && ((Behaviour) this.tmpPanel.Text_LeftAlign[index1][index2]).enabled)
        {
          ((Behaviour) this.tmpPanel.Text_LeftAlign[index1][index2]).enabled = false;
          ((Behaviour) this.tmpPanel.Text_LeftAlign[index1][index2]).enabled = true;
        }
      }
      for (int index3 = 0; index3 < 5; ++index3)
      {
        if ((Object) this.tmpPanel.Text_Resources[index1][index3] != (Object) null && ((Behaviour) this.tmpPanel.Text_Resources[index1][index3]).enabled)
        {
          ((Behaviour) this.tmpPanel.Text_Resources[index1][index3]).enabled = false;
          ((Behaviour) this.tmpPanel.Text_Resources[index1][index3]).enabled = true;
        }
      }
    }
  }

  public override void OnClose()
  {
    this._DataIdx = (List<int>) null;
    if ((Object) this.tmpPanel != (Object) null)
      this.tmpPanel.Destroy();
    if (this.mOpenType != EDevelopmentDetail_OpenKind.JailPrisoners)
      return;
    for (int index = 0; index < this.DM.MapPrisoners.Count; ++index)
    {
      StringManager.Instance.DeSpawnString(this.DM.MapPrisoners[index].TagName);
      this.DM.MapPrisoners[index].TagName = (CString) null;
    }
    this.DM.MapPrisoners.Clear();
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (!this.bOpen)
      return;
    this.tmpPanel.InitScrollPanel();
    this.Custom_PanelRT = this.tmpPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.Custom_ContentRT = this.tmpPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.ResizeForm();
    this.bOpen = false;
    if (this.UpdateLater)
      this.ReflashContent(0, 0);
    this.bOpenEnd = true;
  }

  private void PreResizeForm()
  {
    float num = this.tmpPanel.CurrentPanelHeight - 149f;
    if ((double) num < 0.0)
      num = 0.0f;
    else if ((double) num > 312.0)
      num = 312f;
    this.Img_BGRT.sizeDelta = new Vector2(this.Img_BGRT.sizeDelta.x, 269f + num);
    this.Img_PanelRT.sizeDelta = new Vector2(this.Img_PanelRT.sizeDelta.x, 160f + num);
  }

  private void ResizeForm()
  {
    if ((double) this.Custom_ContentRT.sizeDelta.y <= 149.0)
    {
      this.Custom_PanelRT.sizeDelta = new Vector2(this.Custom_PanelRT.sizeDelta.x, 149f);
    }
    else
    {
      float num = this.Custom_ContentRT.sizeDelta.y - 149f;
      if ((double) num > 312.0)
      {
        float y = this.Custom_ContentRT.sizeDelta.y - (num - 312f);
        if ((double) y > 461.0)
          y = 461f;
        this.Custom_PanelRT.sizeDelta = new Vector2(this.Custom_PanelRT.sizeDelta.x, y);
        num = 312f;
      }
      this.Img_BGRT.sizeDelta = new Vector2(this.Img_BGRT.sizeDelta.x, 269f + num);
      this.Img_PanelRT.sizeDelta = new Vector2(this.Img_PanelRT.sizeDelta.x, 160f + num);
    }
  }

  private void ReflashContent(int arg1, int arg2)
  {
    switch (this.mOpenType)
    {
      case EDevelopmentDetail_OpenKind.ArmyInfo:
        switch (arg1)
        {
          case 1:
            if (this.DataIdx == arg2 && this.bOpenEnd)
            {
              this._DataIdx.Clear();
              this._DataIdx.Add(16);
              int num = 0;
              for (int index = 0; index < 5; ++index)
              {
                if (this.DM.MarchEventData[this.DataIdx].HeroID[index] != (ushort) 0)
                  ++num;
              }
              if (num > 0)
                this._DataIdx.Add(17);
              this.tmpPanel.SetPanelData(this._DataIdx, true, false, 1110, mHeight: 0.0f);
              break;
            }
            break;
          case 2:
            if (this.mOpenType == EDevelopmentDetail_OpenKind.ArmyInfo && this.DM.MarchEventData[this.DataIdx].Type == EMarchEventType.EMET_Standby)
            {
              this.door.CloseMenu();
              return;
            }
            break;
        }
        break;
      case EDevelopmentDetail_OpenKind.Home_Wall_TrapInfo:
        this._DataIdx.Clear();
        this._DataIdx.Add(18);
        this._DataIdx.Add(19);
        this._DataIdx.Add(20);
        this._DataIdx.Add(21);
        this.tmpPanel.SetPanelData(this._DataIdx, bOpen: false, mHeight: 0.0f);
        break;
      case EDevelopmentDetail_OpenKind.Home_ArmyInfo:
        this._DataIdx.Clear();
        this._DataIdx.Add(22);
        this._DataIdx.Add(23);
        this._DataIdx.Add(24);
        this.tmpPanel.SetPanelData(this._DataIdx, bOpen: false, mHeight: 0.0f);
        break;
      case EDevelopmentDetail_OpenKind.CaveInfo:
        if (arg1 == 6 && (Object) this.door != (Object) null)
        {
          this.door.CloseMenu();
          return;
        }
        break;
      case EDevelopmentDetail_OpenKind.KingRewardList:
        if (arg1 == 1 && (Object) this.door != (Object) null)
        {
          this.door.CloseMenu();
          return;
        }
        break;
    }
    if (!this.bOpenEnd)
      return;
    this.ResizeForm();
  }
}
