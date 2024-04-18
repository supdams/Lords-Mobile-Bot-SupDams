// Decompiled with JetBrains decompiler
// Type: UIAlliance_List
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_List : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxScrollPanelObj = 10;
  private const int DismissLeaderMoney = 2000;
  private Transform m_ManagePanel;
  private Transform m_RankChangePanel;
  private Transform m_EmptyText;
  private Transform m_ManagePanelGiftTf;
  private RectTransform m_ManagePanelGiftRectTf;
  private UIText m_ManagePanelNameText;
  private Image m_ManagePanelRankImage;
  private UIText m_RankChangePanelNameText;
  private Image[] m_RankChangePanelCheckImages = new Image[4];
  private Image[] m_RankChangePanelBtnImages = new Image[4];
  private int m_ManagePanelIdx;
  private int m_SelectRankLv;
  private ScrollPanel m_ScrollPanel;
  private UISpritesArray m_SpritesArray;
  private AllianceGroup[] m_Group;
  private List<int> m_Data;
  private StringBuilder sb;
  private eAllianceType m_AllianceType;
  private long m_UserID;
  private AllianceRank m_Rank;
  private CString[][] m_ItemStr = new CString[10][];
  private CString m_DemiseStr;
  private CString m_Expel;
  private CString m_RankName;
  private CString m_RewardCount;
  private string m_DemiseName;
  private uint m_AllianceID;
  private byte m_AllianceMember;
  private byte m_AllianceApplyMember;
  private long m_SeletUserId;
  private int m_RankChangePanelIdx;
  private Door door;
  private bool bFirstUpdate = true;
  private RectTransform m_Content;
  private AllianceListText[] m_AllianceListText = new AllianceListText[10];
  private UIHIBtn[] m_TempUIHIBtn = new UIHIBtn[10];
  private int m_SendRewardIdx = -1;
  private ushort m_RewardItemID;
  private int m_KingGiftInfoIdx;
  private bool[] m_KingGiftInfoData = new bool[100];
  private UIText m_RewardCountText;
  private bool bOpenDismissLeader;
  private CString m_ManagementName;

  public override void OnOpen(int arg1, int arg2)
  {
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.m_AllianceType = (eAllianceType) arg1;
    if (this.m_AllianceType == eAllianceType.eReward)
      this.m_RewardItemID = (ushort) arg2;
    else if (this.m_AllianceType == eAllianceType.ePublicMember)
      this.m_AllianceID = (uint) arg2;
    this.sb = new StringBuilder();
    this.m_Data = new List<int>();
    this.m_Group = new AllianceGroup[5];
    this.m_DemiseStr = StringManager.Instance.SpawnString(200);
    this.m_Expel = StringManager.Instance.SpawnString(100);
    this.m_RankName = StringManager.Instance.SpawnString(100);
    this.m_RewardCount = StringManager.Instance.SpawnString(100);
    this.m_ManagementName = StringManager.Instance.SpawnString(100);
    this.m_SpritesArray = this.transform.GetComponent<UISpritesArray>();
    UIText component1 = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    if (this.m_AllianceType == eAllianceType.eManagement || this.m_AllianceType == eAllianceType.eResourceTransport || this.m_AllianceType == eAllianceType.eReinforce || this.m_AllianceType == eAllianceType.eReward || this.m_AllianceType == eAllianceType.eAmbush)
      component1.text = DataManager.Instance.mStringTable.GetStringByID(4737U);
    else if (this.m_AllianceType == eAllianceType.eApply)
      component1.text = DataManager.Instance.mStringTable.GetStringByID(4741U);
    else if (this.m_AllianceType == eAllianceType.eDemise)
      component1.text = DataManager.Instance.mStringTable.GetStringByID(4744U);
    else if (this.m_AllianceType == eAllianceType.ePublicMember)
      component1.text = DataManager.Instance.mStringTable.GetStringByID(4737U);
    UIButton component2 = this.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
    component2.m_BtnID1 = 4;
    component2.m_Handler = (IUIButtonClickHandler) this;
    ((Component) component2).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_RewardCountText = this.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
    this.m_RewardCountText.font = ttfFont;
    if (this.m_AllianceType == eAllianceType.eReward)
    {
      ((Component) component2).gameObject.SetActive(false);
      this.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
      this.SetRewardCountText(this.GetGiftCount());
    }
    Image component3 = this.transform.GetChild(2).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component3).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component3)
      ((Behaviour) component3).enabled = false;
    UIButton component4 = this.transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
    component4.m_BtnID1 = 3;
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component4.image).material = this.door.LoadMaterial();
    this.transform.GetChild(4).GetChild(0).GetChild(4).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(0).GetChild(5).GetComponent<UIText>().font = ttfFont;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component5 = this.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<RectTransform>();
      Vector2 anchoredPosition = component5.anchoredPosition with
      {
        x = 88f
      };
      component5.anchoredPosition = anchoredPosition;
      Vector3 localScale1 = ((Transform) component5).localScale with
      {
        x = -1f
      };
      ((Transform) component5).localScale = localScale1;
      RectTransform component6 = this.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<RectTransform>();
      Vector3 localScale2 = ((Transform) component6).localScale with
      {
        x = -1f
      };
      ((Transform) component6).localScale = localScale2;
      this.transform.GetChild(4).GetChild(1).GetChild(10).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    GUIManager.Instance.InitianHeroItemImg(((Component) this.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.transform.GetChild(4).GetChild(1).GetChild(0).gameObject.AddComponent<IgnoreRaycast>();
    this.transform.GetChild(4).GetChild(1).GetChild(4).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(1).GetChild(5).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(1).GetChild(6).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(1).GetChild(7).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(1).GetChild(10).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.m_ManagePanel = this.transform.GetChild(5);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.m_ManagePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_ManagePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.m_ManagePanelNameText = this.m_ManagePanel.GetChild(3).GetComponent<UIText>();
    this.m_ManagePanelNameText.font = ttfFont;
    this.m_ManagePanelGiftTf = this.m_ManagePanel.GetChild(4);
    if ((UnityEngine.Object) this.m_ManagePanelGiftTf != (UnityEngine.Object) null)
    {
      this.m_ManagePanelGiftRectTf = this.m_ManagePanelGiftTf.GetComponent<RectTransform>();
      if ((UnityEngine.Object) this.m_ManagePanelGiftRectTf != (UnityEngine.Object) null)
      {
        this.m_ManagePanelGiftRectTf.anchorMax = new Vector2(0.5f, 0.5f);
        this.m_ManagePanelGiftRectTf.anchorMin = new Vector2(0.5f, 0.5f);
        this.m_ManagePanelGiftRectTf.pivot = new Vector2(0.5f, 0.5f);
        this.m_ManagePanelGiftRectTf.anchoredPosition = new Vector2(135f, 124.5f);
      }
    }
    this.m_ManagePanelRankImage = this.m_ManagePanel.GetChild(2).GetComponent<Image>();
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform rectTransform = ((Graphic) this.m_ManagePanelRankImage).rectTransform;
      Vector3 localScale = ((Transform) rectTransform).localScale with
      {
        x = -1f
      };
      ((Transform) rectTransform).localScale = localScale;
    }
    UIText component7 = this.m_ManagePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = DataManager.Instance.mStringTable.GetStringByID(4754U);
    UIText component8 = this.m_ManagePanel.GetChild(4).GetChild(1).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = DataManager.Instance.mStringTable.GetStringByID(4755U);
    UIButton component9 = this.m_ManagePanel.GetChild(4).GetComponent<UIButton>();
    component9.m_BtnID1 = 101;
    component9.m_Handler = (IUIButtonClickHandler) this;
    ((Component) component9).gameObject.SetActive(false);
    UIText component10 = this.m_ManagePanel.GetChild(5).GetChild(1).GetComponent<UIText>();
    component10.font = ttfFont;
    UIButton component11 = this.m_ManagePanel.GetChild(5).GetComponent<UIButton>();
    component11.m_BtnID1 = 103;
    component11.m_Handler = (IUIButtonClickHandler) this;
    component10.text = DataManager.Instance.mStringTable.GetStringByID(4756U);
    UIText component12 = this.m_ManagePanel.GetChild(6).GetChild(1).GetComponent<UIText>();
    component12.font = ttfFont;
    UIButton component13 = this.m_ManagePanel.GetChild(6).GetComponent<UIButton>();
    component13.m_BtnID1 = 104;
    component13.m_Handler = (IUIButtonClickHandler) this;
    component12.text = DataManager.Instance.mStringTable.GetStringByID(4757U);
    UIText component14 = this.m_ManagePanel.GetChild(7).GetChild(1).GetComponent<UIText>();
    component14.font = ttfFont;
    UIButton component15 = this.m_ManagePanel.GetChild(7).GetComponent<UIButton>();
    component15.m_BtnID1 = 105;
    component15.m_Handler = (IUIButtonClickHandler) this;
    component14.text = DataManager.Instance.mStringTable.GetStringByID(4758U);
    UIText component16 = this.m_ManagePanel.GetChild(8).GetChild(1).GetComponent<UIText>();
    component16.font = ttfFont;
    UIButton component17 = this.m_ManagePanel.GetChild(8).GetComponent<UIButton>();
    component17.m_BtnID1 = 106;
    component17.m_Handler = (IUIButtonClickHandler) this;
    component16.text = DataManager.Instance.mStringTable.GetStringByID(4759U);
    UIButton component18 = this.m_ManagePanel.GetChild(9).GetComponent<UIButton>();
    component18.m_BtnID1 = 102;
    component18.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component18.image).material = this.door.LoadMaterial();
    component18.m_Handler = (IUIButtonClickHandler) this;
    UIText component19 = this.m_ManagePanel.GetChild(10).GetChild(1).GetComponent<UIText>();
    component19.font = ttfFont;
    component19.text = DataManager.Instance.mStringTable.GetStringByID(9348U);
    UIButton component20 = this.m_ManagePanel.GetChild(10).GetComponent<UIButton>();
    component20.m_BtnID1 = 107;
    component20.m_Handler = (IUIButtonClickHandler) this;
    UIText component21 = this.m_ManagePanel.GetChild(11).GetChild(1).GetComponent<UIText>();
    component21.font = ttfFont;
    component21.text = DataManager.Instance.mStringTable.GetStringByID(9529U);
    UIButton component22 = this.m_ManagePanel.GetChild(11).GetComponent<UIButton>();
    component22.m_BtnID1 = 108;
    component22.m_Handler = (IUIButtonClickHandler) this;
    HelperUIButton helperUiButton1 = this.m_ManagePanel.gameObject.AddComponent<HelperUIButton>();
    helperUiButton1.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton1.m_BtnID1 = 102;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_ManagePanel.GetChild(0).GetComponent<IgnoreRaycast>());
    this.m_RankChangePanel = this.transform.GetChild(6);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.m_RankChangePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_RankChangePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    UIText component23 = this.m_RankChangePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
    component23.font = ttfFont;
    component23.text = DataManager.Instance.mStringTable.GetStringByID(4760U);
    this.m_RankChangePanelNameText = this.m_RankChangePanel.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.m_RankChangePanelNameText.font = ttfFont;
    UIText component24 = this.m_RankChangePanel.GetChild(3).GetChild(0).GetComponent<UIText>();
    component24.font = ttfFont;
    component24.text = DataManager.Instance.mStringTable.GetStringByID(4762U);
    UIText component25 = this.m_RankChangePanel.GetChild(4).GetChild(3).GetComponent<UIText>();
    component25.font = ttfFont;
    component25.text = DataManager.Instance.mStringTable.GetStringByID(4763U);
    this.m_RankChangePanelBtnImages[3] = this.m_RankChangePanel.GetChild(4).GetComponent<Image>();
    this.m_RankChangePanelCheckImages[3] = this.m_RankChangePanel.GetChild(4).GetChild(2).GetComponent<Image>();
    UIButton component26 = this.m_RankChangePanel.GetChild(4).GetComponent<UIButton>();
    component26.m_BtnID1 = 201;
    component26.m_Handler = (IUIButtonClickHandler) this;
    UIText component27 = this.m_RankChangePanel.GetChild(5).GetChild(3).GetComponent<UIText>();
    component27.font = ttfFont;
    component27.text = DataManager.Instance.mStringTable.GetStringByID(4764U);
    this.m_RankChangePanelBtnImages[2] = this.m_RankChangePanel.GetChild(5).GetComponent<Image>();
    this.m_RankChangePanelCheckImages[2] = this.m_RankChangePanel.GetChild(5).GetChild(2).GetComponent<Image>();
    UIButton component28 = this.m_RankChangePanel.GetChild(5).GetComponent<UIButton>();
    component28.m_BtnID1 = 202;
    component28.m_Handler = (IUIButtonClickHandler) this;
    UIText component29 = this.m_RankChangePanel.GetChild(6).GetChild(3).GetComponent<UIText>();
    component29.font = ttfFont;
    component29.text = DataManager.Instance.mStringTable.GetStringByID(4765U);
    this.m_RankChangePanelBtnImages[1] = this.m_RankChangePanel.GetChild(6).GetComponent<Image>();
    this.m_RankChangePanelCheckImages[1] = this.m_RankChangePanel.GetChild(6).GetChild(2).GetComponent<Image>();
    UIButton component30 = this.m_RankChangePanel.GetChild(6).GetComponent<UIButton>();
    component30.m_BtnID1 = 203;
    component30.m_Handler = (IUIButtonClickHandler) this;
    UIText component31 = this.m_RankChangePanel.GetChild(7).GetChild(3).GetComponent<UIText>();
    component31.font = ttfFont;
    component31.text = DataManager.Instance.mStringTable.GetStringByID(4766U);
    this.m_RankChangePanelBtnImages[0] = this.m_RankChangePanel.GetChild(7).GetComponent<Image>();
    this.m_RankChangePanelCheckImages[0] = this.m_RankChangePanel.GetChild(7).GetChild(2).GetComponent<Image>();
    UIButton component32 = this.m_RankChangePanel.GetChild(7).GetComponent<UIButton>();
    component32.m_BtnID1 = 204;
    component32.m_Handler = (IUIButtonClickHandler) this;
    UIText component33 = this.m_RankChangePanel.GetChild(8).GetChild(0).GetComponent<UIText>();
    component33.font = ttfFont;
    component33.text = DataManager.Instance.mStringTable.GetStringByID(4767U);
    UIButton component34 = this.m_RankChangePanel.GetChild(8).GetComponent<UIButton>();
    component34.m_BtnID1 = 205;
    component34.m_Handler = (IUIButtonClickHandler) this;
    UIButton component35 = this.m_RankChangePanel.GetChild(9).GetComponent<UIButton>();
    component35.m_BtnID1 = 206;
    component35.m_Handler = (IUIButtonClickHandler) this;
    component35.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component35.image).material = this.door.LoadMaterial();
    HelperUIButton helperUiButton2 = this.m_RankChangePanel.gameObject.AddComponent<HelperUIButton>();
    helperUiButton2.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton2.m_BtnID1 = 206;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_RankChangePanel.GetChild(0).GetComponent<IgnoreRaycast>());
    this.m_EmptyText = this.transform.GetChild(7);
    UIText component36 = this.m_EmptyText.GetChild(0).GetComponent<UIText>();
    component36.font = ttfFont;
    component36.text = DataManager.Instance.mStringTable.GetStringByID(595U);
    if (GUIManager.Instance.IsArabic)
    {
      for (int index = 0; index < 4; ++index)
      {
        RectTransform component37 = this.m_RankChangePanel.GetChild(4 + index).GetChild(0).GetComponent<RectTransform>();
        Vector2 anchoredPosition1 = component37.anchoredPosition with
        {
          x = 93f
        };
        component37.anchoredPosition = anchoredPosition1;
        Vector3 localScale3 = ((Transform) component37).localScale with
        {
          x = -1f
        };
        ((Transform) component37).localScale = localScale3;
        RectTransform component38 = this.m_RankChangePanel.GetChild(4 + index).GetChild(2).GetComponent<RectTransform>();
        Vector2 anchoredPosition2 = component38.anchoredPosition with
        {
          x = 447f
        };
        component38.anchoredPosition = anchoredPosition2;
        Vector3 localScale4 = ((Transform) component38).localScale with
        {
          x = -1f
        };
        ((Transform) component38).localScale = localScale4;
      }
    }
    this.CheckEmptyStr();
    this.SetMgrData();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
    {
      if (this.m_Data[index] < 0)
        _DataHeight.Add(53f);
      else
        _DataHeight.Add(74f);
    }
    this.m_ScrollPanel = this.transform.GetChild(3).GetComponent<ScrollPanel>();
    this.m_ScrollPanel.IntiScrollPanel(506f, 6f, 0.0f, _DataHeight, 10, (IUpDateScrollPanel) this);
    this.m_Content = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    this.m_AllianceMember = DataManager.Instance.RoleAlliance.Member;
    this.m_AllianceApplyMember = DataManager.Instance.RoleAlliance.Applicant;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    for (int index1 = 0; index1 < 10; ++index1)
    {
      if (this.m_ItemStr[index1] != null)
      {
        for (int index2 = 0; index2 < this.m_ItemStr[index1].Length; ++index2)
        {
          if (this.m_ItemStr[index1][index2] != null)
          {
            StringManager.Instance.DeSpawnString(this.m_ItemStr[index1][index2]);
            this.m_ItemStr[index1][index2] = (CString) null;
          }
        }
      }
    }
    this.m_ItemStr = (CString[][]) null;
    if (this.m_DemiseStr != null)
    {
      StringManager.Instance.DeSpawnString(this.m_DemiseStr);
      this.m_DemiseStr = (CString) null;
    }
    if (this.m_Expel != null)
    {
      StringManager.Instance.DeSpawnString(this.m_Expel);
      this.m_Expel = (CString) null;
    }
    if (this.m_RankName != null)
    {
      StringManager.Instance.DeSpawnString(this.m_RankName);
      this.m_RankName = (CString) null;
    }
    if (this.m_RewardCount != null)
    {
      StringManager.Instance.DeSpawnString(this.m_RewardCount);
      this.m_RewardCount = (CString) null;
    }
    if (this.m_ManagementName != null)
    {
      StringManager.Instance.DeSpawnString(this.m_ManagementName);
      this.m_ManagementName = (CString) null;
    }
    if (this.m_AllianceType != eAllianceType.eApply)
    {
      GUIManager.Instance.AllianceListTopIdx = this.m_ScrollPanel.GetTopIdx();
      GUIManager.Instance.AllienceListContentY = this.m_Content.anchoredPosition.y;
      for (int index = 0; index < this.m_Group.Length && index < GUIManager.Instance.AllienceListGroupOpen.Length; ++index)
        GUIManager.Instance.AllienceListGroupOpen[index] = this.m_Group[index].bOpen;
    }
    if (!this.bOpenDismissLeader)
      return;
    GUIManager.Instance.CloseOKCancelBox();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        if (this.m_AllianceType != eAllianceType.eApply)
        {
          for (int index = 0; index < this.m_Group.Length; ++index)
          {
            if (this.bFirstUpdate)
            {
              if (index < GUIManager.Instance.AllienceListGroupOpen.Length)
                this.m_Group[index].bOpen = GUIManager.Instance.AllienceListGroupOpen[index];
            }
            else
              this.m_Group[index].bOpen = true;
          }
        }
        this.SetData();
        if (this.m_AllianceType == eAllianceType.eReward)
          this.UpdateRewardData(this.m_RewardItemID);
        List<float> _DataHeight1 = new List<float>();
        for (int index = 0; index < this.m_Data.Count; ++index)
        {
          if (this.m_Data[index] < 0)
            _DataHeight1.Add(53f);
          else
            _DataHeight1.Add(74f);
        }
        this.m_ScrollPanel.AddNewDataHeight(_DataHeight1, false);
        if (this.m_AllianceType != eAllianceType.eApply && this.bFirstUpdate)
        {
          this.m_ScrollPanel.GoTo(GUIManager.Instance.AllianceListTopIdx, GUIManager.Instance.AllienceListContentY);
          this.bFirstUpdate = false;
        }
        if (this.m_ManagePanel.gameObject.activeSelf)
        {
          for (int index1 = 0; index1 < this.m_Data.Count; ++index1)
          {
            if (this.m_Data[index1] >= 0 && this.m_Data[index1] < DataManager.Instance.AllianceMember.Length)
            {
              int index2 = this.m_Data[index1];
              if (DataManager.Instance.AllianceMember[index2].UserId == this.m_UserID)
              {
                this.SetManagementPanel(DataManager.Instance.AllianceMember[index2].Rank, index1);
                break;
              }
            }
          }
          if ((int) this.m_AllianceMember > (int) DataManager.Instance.RoleAlliance.Member)
          {
            if (this.m_ManagePanel.gameObject.activeSelf && !this.FindUserId(this.m_UserID))
            {
              this.OpenManagement(false);
              this.OpenRankChange(false);
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4750U), (ushort) byte.MaxValue);
            }
          }
          else if ((int) this.m_AllianceMember >= (int) DataManager.Instance.RoleAlliance.Member)
            ;
        }
        this.m_AllianceMember = DataManager.Instance.RoleAlliance.Member;
        this.CheckEmptyStr();
        break;
      case 1:
        int removeIndex = DataManager.Instance.m_RemoveIndex;
        if (removeIndex >= 0 && removeIndex < this.m_Data.Count)
        {
          this.m_Data.RemoveAt(removeIndex);
          List<float> _DataHeight2 = new List<float>();
          for (int index = 0; index < this.m_Data.Count; ++index)
            _DataHeight2.Add(74f);
          this.m_ScrollPanel.AddNewDataHeight(_DataHeight2, false);
        }
        this.CheckEmptyStr();
        break;
      case 2:
        if (!(bool) (UnityEngine.Object) this.door)
          break;
        this.door.CloseMenu();
        break;
      case 3:
        if (this.m_SendRewardIdx >= 0 && this.m_SendRewardIdx < this.m_KingGiftInfoData.Length)
          this.m_KingGiftInfoData[this.m_SendRewardIdx] = true;
        List<float> _DataHeight3 = new List<float>();
        for (int index = 0; index < this.m_Data.Count; ++index)
        {
          if (this.m_Data[index] < 0)
            _DataHeight3.Add(53f);
          else
            _DataHeight3.Add(74f);
        }
        this.m_ScrollPanel.AddNewDataHeight(_DataHeight3, false);
        this.SetRewardCountText(this.GetGiftCount());
        break;
      case 4:
        this.m_SendRewardIdx = -1;
        break;
      case 5:
        this.SetMgrData();
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(508U), DataManager.Instance.mStringTable.GetStringByID(9531U), DataManager.Instance.mStringTable.GetStringByID(508U), (GUIWindow) this);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    List<float> floatList = new List<float>();
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.SetMgrData();
        break;
      case NetworkNews.Refresh_Alliance:
        if (DataManager.Instance.RoleAlliance.Id == 0U && (bool) (UnityEngine.Object) this.door)
        {
          this.door.CloseMenu();
          break;
        }
        if (DataManager.Instance.RoleAlliance.Member == (byte) 0)
          DataManager.Instance.ResetAllianceMemberData();
        else if ((int) this.m_AllianceMember > (int) DataManager.Instance.RoleAlliance.Member)
          this.SetMgrData();
        else if ((int) this.m_AllianceMember < (int) DataManager.Instance.RoleAlliance.Member)
          this.SetMgrData();
        if (this.m_AllianceType != eAllianceType.eApply)
          break;
        if (DataManager.Instance.RoleAlliance.Applicant == (byte) 0)
        {
          this.m_AllianceApplyMember = DataManager.Instance.RoleAlliance.Applicant;
          DataManager.Instance.ResetAllianceMemberData();
          break;
        }
        if ((int) this.m_AllianceApplyMember == (int) DataManager.Instance.RoleAlliance.Applicant)
          break;
        this.m_AllianceApplyMember = DataManager.Instance.RoleAlliance.Applicant;
        this.SetMgrData();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        this.RefreshAllianceListText();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.transform.GetChild(4).GetChild(0).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.transform.GetChild(4).GetChild(0).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.transform.GetChild(4).GetChild(1).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.transform.GetChild(4).GetChild(1).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.transform.GetChild(4).GetChild(1).GetChild(6).GetComponent<UIText>();
    if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.transform.GetChild(4).GetChild(1).GetChild(7).GetComponent<UIText>();
    if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.transform.GetChild(4).GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.transform.GetChild(4).GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.transform.GetChild(5).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.transform.GetChild(5).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.transform.GetChild(5).GetChild(4).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UIText component13 = this.transform.GetChild(5).GetChild(5).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UIText component14 = this.transform.GetChild(5).GetChild(6).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UIText component15 = this.transform.GetChild(5).GetChild(7).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UIText component16 = this.transform.GetChild(5).GetChild(8).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    UIText component17 = this.transform.GetChild(6).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component17 != (UnityEngine.Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UIText component18 = this.transform.GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component18 != (UnityEngine.Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UIText component19 = this.transform.GetChild(6).GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component19 != (UnityEngine.Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    UIText component20 = this.transform.GetChild(6).GetChild(4).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component20 != (UnityEngine.Object) null && ((Behaviour) component20).enabled)
    {
      ((Behaviour) component20).enabled = false;
      ((Behaviour) component20).enabled = true;
    }
    UIText component21 = this.transform.GetChild(6).GetChild(5).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component21 != (UnityEngine.Object) null && ((Behaviour) component21).enabled)
    {
      ((Behaviour) component21).enabled = false;
      ((Behaviour) component21).enabled = true;
    }
    UIText component22 = this.transform.GetChild(6).GetChild(6).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component22 != (UnityEngine.Object) null && ((Behaviour) component22).enabled)
    {
      ((Behaviour) component22).enabled = false;
      ((Behaviour) component22).enabled = true;
    }
    UIText component23 = this.transform.GetChild(6).GetChild(7).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component23 != (UnityEngine.Object) null && ((Behaviour) component23).enabled)
    {
      ((Behaviour) component23).enabled = false;
      ((Behaviour) component23).enabled = true;
    }
    UIText component24 = this.transform.GetChild(6).GetChild(8).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component24 != (UnityEngine.Object) null && ((Behaviour) component24).enabled)
    {
      ((Behaviour) component24).enabled = false;
      ((Behaviour) component24).enabled = true;
    }
    UIText component25 = this.transform.GetChild(7).GetChild(0).GetComponent<UIText>();
    if (!((UnityEngine.Object) component25 != (UnityEngine.Object) null) || !((Behaviour) component25).enabled)
      return;
    ((Behaviour) component25).enabled = false;
    ((Behaviour) component25).enabled = true;
  }

  public void RefreshAllianceListText()
  {
    if (this.m_AllianceListText != null)
    {
      for (int index = 0; index < this.m_AllianceListText.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_AllianceListText[index].BtnText1 != (UnityEngine.Object) null && ((Behaviour) this.m_AllianceListText[index].BtnText1).enabled)
        {
          ((Behaviour) this.m_AllianceListText[index].BtnText1).enabled = false;
          ((Behaviour) this.m_AllianceListText[index].BtnText1).enabled = true;
        }
        if ((UnityEngine.Object) this.m_AllianceListText[index].BtnText2 != (UnityEngine.Object) null && ((Behaviour) this.m_AllianceListText[index].BtnText2).enabled)
        {
          ((Behaviour) this.m_AllianceListText[index].BtnText2).enabled = false;
          ((Behaviour) this.m_AllianceListText[index].BtnText2).enabled = true;
        }
        if ((UnityEngine.Object) this.m_AllianceListText[index].KillNum != (UnityEngine.Object) null && ((Behaviour) this.m_AllianceListText[index].KillNum).enabled)
        {
          ((Behaviour) this.m_AllianceListText[index].KillNum).enabled = false;
          ((Behaviour) this.m_AllianceListText[index].KillNum).enabled = true;
        }
        if ((UnityEngine.Object) this.m_AllianceListText[index].LeaveTime != (UnityEngine.Object) null && ((Behaviour) this.m_AllianceListText[index].LeaveTime).enabled)
        {
          ((Behaviour) this.m_AllianceListText[index].LeaveTime).enabled = false;
          ((Behaviour) this.m_AllianceListText[index].LeaveTime).enabled = true;
        }
        if ((UnityEngine.Object) this.m_AllianceListText[index].Name != (UnityEngine.Object) null && ((Behaviour) this.m_AllianceListText[index].Name).enabled)
        {
          ((Behaviour) this.m_AllianceListText[index].Name).enabled = false;
          ((Behaviour) this.m_AllianceListText[index].Name).enabled = true;
        }
        if ((UnityEngine.Object) this.m_AllianceListText[index].Power != (UnityEngine.Object) null && ((Behaviour) this.m_AllianceListText[index].Power).enabled)
        {
          ((Behaviour) this.m_AllianceListText[index].Power).enabled = false;
          ((Behaviour) this.m_AllianceListText[index].Power).enabled = true;
        }
      }
    }
    if (this.m_TempUIHIBtn == null)
      return;
    for (int index = 0; index < this.m_TempUIHIBtn.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_TempUIHIBtn[index] != (UnityEngine.Object) null && ((Behaviour) this.m_TempUIHIBtn[index]).enabled)
        this.m_TempUIHIBtn[index].Refresh_FontTexture();
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    switch (this.m_AllianceType)
    {
      case eAllianceType.eManagement:
        if (!bOK)
          break;
        switch (arg1)
        {
          case 1:
            if (arg2 >= this.m_Data.Count || this.m_Data[arg2] >= DataManager.Instance.m_RecvDataIdx)
              return;
            this.m_Expel.ClearString();
            StringManager.Instance.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[arg2]].Name);
            this.m_Expel.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4772U));
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(4768U), this.m_Expel.ToString(), 2, arg2, DataManager.Instance.mStringTable.GetStringByID(4774U), DataManager.Instance.mStringTable.GetStringByID(4773U));
            return;
          case 2:
            if (arg2 >= this.m_Data.Count || this.m_Data[arg2] >= DataManager.Instance.m_RecvDataIdx)
              return;
            DataManager.Instance.m_RemoveIndex = arg1;
            DataManager.Instance.SendAllianceQuitMember(DataManager.Instance.AllianceMember[this.m_Data[arg2]].UserId);
            this.OpenManagement(false);
            return;
          case 3:
            if (!bOK)
              return;
            if (this.m_Data[1] >= 0 && this.m_Data[1] < DataManager.Instance.AllianceMember.Length)
            {
              if (2000U > DataManager.Instance.RoleAttr.Diamond)
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966U), DataManager.Instance.mStringTable.GetStringByID(646U), DataManager.Instance.mStringTable.GetStringByID(3968U), (GUIWindow) this, 4, bCloseIDSet: true);
              else if (!GUIManager.Instance.OpenCheckCrystal(2000U, (byte) 7, this.m_Data[1]))
                DataManager.Instance.SendAllanceDismissLeader(DataManager.Instance.AllianceMember[this.m_Data[1]].UserId);
            }
            this.bOpenDismissLeader = false;
            return;
          case 4:
            MallManager.Instance.Send_Mall_Info();
            return;
          default:
            return;
        }
      case eAllianceType.eDemise:
        if (!bOK)
          break;
        if (arg1 == 0)
        {
          this.m_DemiseStr.ClearString();
          StringManager.Instance.StringToFormat(this.m_DemiseName);
          this.m_DemiseStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4795U));
          GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(4793U), this.m_DemiseStr.ToString(), 1, YesText: DataManager.Instance.mStringTable.GetStringByID(4797U), NoText: DataManager.Instance.mStringTable.GetStringByID(4796U));
          break;
        }
        if (arg1 != 1)
          break;
        DataManager.Instance.SendAllianceStepDown(this.m_UserID);
        break;
    }
  }

  public override bool OnBackButtonClick()
  {
    switch (this.m_AllianceType)
    {
      case eAllianceType.eDemise:
        return false;
      default:
        return false;
    }
  }

  public void OpenManagement(bool bOpen, int dataIdx = 0)
  {
    if (dataIdx < this.m_Data.Count)
    {
      int index = this.m_Data[dataIdx];
      if (index >= 0 && index < DataManager.Instance.AllianceMember.Length)
      {
        this.m_SeletUserId = DataManager.Instance.AllianceMember[index].UserId;
        this.m_ManagePanelNameText.text = DataManager.Instance.AllianceMember[index].Name;
        this.m_ManagePanelIdx = dataIdx;
        this.SetManagementPanel(DataManager.Instance.AllianceMember[index].Rank, dataIdx);
      }
      if (bOpen)
      {
        this.m_ManagePanelGiftTf.gameObject.SetActive(this.ShowGiftBtn());
        this.m_ManagementName.ClearString();
        this.m_ManagementName.Append(DataManager.Instance.AllianceMember[index].Name);
      }
    }
    this.m_ManagePanel.gameObject.SetActive(bOpen);
  }

  public void OpenRankChange(bool bOpen, int dataIdx = 0)
  {
    this.m_RankChangePanel.gameObject.SetActive(bOpen);
    if (dataIdx >= this.m_Data.Count)
      return;
    int mgrDataIdx = this.m_Data[dataIdx];
    if (mgrDataIdx < 0 || mgrDataIdx >= DataManager.Instance.AllianceMember.Length)
      return;
    this.SetSelectRank((int) DataManager.Instance.AllianceMember[mgrDataIdx].Rank);
    this.SetRankChangePanel(mgrDataIdx);
  }

  public void SetManagementPanel(AllianceRank otherRank, int dataIdx)
  {
    UIButton component1 = this.m_ManagePanel.GetChild(5).GetComponent<UIButton>();
    UIButton component2 = this.m_ManagePanel.GetChild(6).GetComponent<UIButton>();
    UIButton component3 = this.m_ManagePanel.GetChild(7).GetComponent<UIButton>();
    UIButton component4 = this.m_ManagePanel.GetChild(8).GetComponent<UIButton>();
    UIButton component5 = this.m_ManagePanel.GetChild(10).GetComponent<UIButton>();
    UIButton component6 = this.m_ManagePanel.GetChild(11).GetComponent<UIButton>();
    AllianceRank rank = DataManager.Instance.RoleAlliance.Rank;
    this.m_UserID = DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId;
    component1.m_BtnID2 = dataIdx;
    component2.m_BtnID2 = dataIdx;
    this.m_ManagePanelRankImage.sprite = this.m_SpritesArray.GetSprite((int) (otherRank + (byte) 1));
    if (rank > otherRank && rank > AllianceRank.RANK2)
    {
      component3.ForTextChange(e_BtnType.e_Normal);
      component3.m_BtnID2 = dataIdx;
    }
    else
    {
      component3.ForTextChange(e_BtnType.e_ChangeText);
      component3.m_BtnID2 = 200;
    }
    if (rank >= AllianceRank.RANK4 && rank > otherRank)
    {
      component4.ForTextChange(e_BtnType.e_Normal);
      component4.m_BtnID2 = dataIdx;
    }
    else
    {
      component4.ForTextChange(e_BtnType.e_ChangeText);
      component4.m_BtnID2 = 200;
    }
    component5.m_BtnID2 = dataIdx;
    int recall = this.IsTimeToRecall();
    if (this.IsKingOrConqueror())
    {
      component6.ForTextChange(e_BtnType.e_ChangeText);
      component6.m_BtnID2 = 201;
    }
    else if (recall != 0)
    {
      component6.ForTextChange(e_BtnType.e_ChangeText);
      switch (rank)
      {
        case AllianceRank.RANK1:
        case AllianceRank.RANK2:
          component6.m_BtnID2 = recall;
          break;
        case AllianceRank.RANK3:
        case AllianceRank.RANK4:
          component6.m_BtnID2 = recall;
          break;
      }
    }
    else
    {
      component6.ForTextChange(e_BtnType.e_Normal);
      component6.m_BtnID2 = dataIdx;
    }
    if (this.ShowCanonizedBtnByTableID() > (byte) 0)
      this.SetManagementPos(eManagementType.IsKing);
    else if (otherRank == AllianceRank.RANK5)
      this.SetManagementPos(eManagementType.CanRecall);
    else
      this.SetManagementPos(eManagementType.Normal);
  }

  private void SetManagementPos(eManagementType Type)
  {
    float[] numArray1 = new float[12]
    {
      -17f,
      197f,
      128.5f,
      130f,
      124f,
      36.5f,
      -36.5f,
      -109.5f,
      -182.5f,
      195.5f,
      -233f,
      61f
    };
    float[] numArray2 = new float[12]
    {
      -21f,
      222f,
      153f,
      154f,
      149f,
      -12f,
      -85f,
      -158f,
      -233f,
      220f,
      -233f,
      61f
    };
    float[] numArray3 = new float[12]
    {
      -21f,
      222f,
      153f,
      154f,
      149f,
      61f,
      -12f,
      -85f,
      -158f,
      220f,
      -233f,
      61f
    };
    Vector2 vector2;
    for (int index = 0; index < 12; ++index)
    {
      RectTransform component = this.m_ManagePanel.GetChild(index).GetComponent<RectTransform>();
      vector2 = component.anchoredPosition;
      switch (Type)
      {
        case eManagementType.IsKing:
          vector2.y = numArray3[index];
          break;
        case eManagementType.CanRecall:
          vector2.y = numArray2[index];
          break;
        default:
          vector2.y = numArray1[index];
          break;
      }
      component.anchoredPosition = vector2;
    }
    RectTransform rectTransform = ((Graphic) this.m_ManagePanel.GetChild(0).GetComponent<Image>()).rectTransform;
    vector2 = rectTransform.sizeDelta;
    switch (Type)
    {
      case eManagementType.Normal:
        vector2.y = 476f;
        this.m_ManagePanel.GetChild(10).gameObject.SetActive(false);
        this.m_ManagePanel.GetChild(11).gameObject.SetActive(false);
        break;
      case eManagementType.IsKing:
        vector2.y = 550f;
        this.m_ManagePanel.GetChild(10).gameObject.SetActive(true);
        this.m_ManagePanel.GetChild(11).gameObject.SetActive(false);
        break;
      case eManagementType.CanRecall:
        vector2.y = 550f;
        this.m_ManagePanel.GetChild(10).gameObject.SetActive(false);
        this.m_ManagePanel.GetChild(11).gameObject.SetActive(true);
        break;
    }
    rectTransform.sizeDelta = vector2;
  }

  public void SetRankChangePanel(int mgrDataIdx)
  {
    if (mgrDataIdx >= DataManager.Instance.m_RecvDataIdx || mgrDataIdx < 0)
      return;
    this.m_RankChangePanelIdx = mgrDataIdx;
    UIButton component1 = this.m_RankChangePanel.GetChild(4).GetComponent<UIButton>();
    UIButton component2 = this.m_RankChangePanel.GetChild(5).GetComponent<UIButton>();
    UIButton component3 = this.m_RankChangePanel.GetChild(6).GetComponent<UIButton>();
    UIButton component4 = this.m_RankChangePanel.GetChild(7).GetComponent<UIButton>();
    AllianceRank rank1 = DataManager.Instance.RoleAlliance.Rank;
    AllianceRank rank2 = DataManager.Instance.AllianceMember[mgrDataIdx].Rank;
    this.m_RankName.ClearString();
    this.m_RankName.StringToFormat(DataManager.Instance.AllianceMember[mgrDataIdx].Name);
    this.m_RankName.IntToFormat((long) rank2);
    this.m_RankName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4761U));
    this.m_RankChangePanelNameText.text = this.m_RankName.ToString();
    this.m_RankChangePanelNameText.SetAllDirty();
    this.m_RankChangePanelNameText.cachedTextGenerator.Invalidate();
    if (rank1 > AllianceRank.RANK4)
    {
      component1.ForTextChange(e_BtnType.e_Normal);
      component1.m_BtnID2 = 100;
    }
    else
    {
      component1.ForTextChange(e_BtnType.e_ChangeText);
      component1.m_BtnID2 = 200;
    }
    if (rank1 > AllianceRank.RANK3)
    {
      component2.ForTextChange(e_BtnType.e_Normal);
      component2.m_BtnID2 = 100;
    }
    else
    {
      component2.ForTextChange(e_BtnType.e_ChangeText);
      component2.m_BtnID2 = 200;
    }
    if (rank1 > AllianceRank.RANK2)
    {
      component3.ForTextChange(e_BtnType.e_Normal);
      component3.m_BtnID2 = 100;
    }
    else
    {
      component3.ForTextChange(e_BtnType.e_ChangeText);
      component3.m_BtnID2 = 200;
    }
    if (rank1 > AllianceRank.RANK1)
    {
      component4.ForTextChange(e_BtnType.e_Normal);
      component4.m_BtnID2 = 100;
    }
    else
    {
      component4.ForTextChange(e_BtnType.e_ChangeText);
      component4.m_BtnID2 = 200;
    }
  }

  public void SetSelectRank(int RankLv)
  {
    this.m_SelectRankLv = RankLv;
    for (int index = 0; index < this.m_RankChangePanelCheckImages.Length; ++index)
    {
      if (((Component) this.m_RankChangePanelCheckImages[index]).gameObject.activeSelf)
        ((Component) this.m_RankChangePanelCheckImages[index]).gameObject.SetActive(false);
      this.m_RankChangePanelBtnImages[index].sprite = this.m_SpritesArray.GetSprite(7);
    }
    if (this.m_SelectRankLv < 5)
    {
      ((Component) this.m_RankChangePanelCheckImages[this.m_SelectRankLv - 1]).gameObject.SetActive(true);
      this.m_RankChangePanelBtnImages[this.m_SelectRankLv - 1].sprite = this.m_SpritesArray.GetSprite(8);
    }
    this.m_Rank = (AllianceRank) RankLv;
  }

  public void OnButtonClick(UIButton sender)
  {
    int btnId2 = sender.m_BtnID2;
    switch (sender.m_BtnID1)
    {
      case 1:
        if (this.m_AllianceType != eAllianceType.eApply)
          break;
        DataManager.Instance.m_RemoveIndex = btnId2;
        if (btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] < 0 || this.m_Data[btnId2] >= DataManager.Instance.AllianceMember.Length)
          break;
        DataManager.Instance.SendAllianceApplyResult((byte) 2, DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId);
        break;
      case 2:
        if (this.m_AllianceType == eAllianceType.eManagement)
        {
          this.OpenManagement(true, btnId2);
          break;
        }
        if (this.m_AllianceType == eAllianceType.eApply)
        {
          DataManager.Instance.m_RemoveIndex = btnId2;
          if (btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] < 0 || this.m_Data[btnId2] >= DataManager.Instance.AllianceMember.Length)
            break;
          DataManager.Instance.SendAllianceApplyResult((byte) 1, DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId);
          break;
        }
        if (this.m_AllianceType == eAllianceType.eDemise)
        {
          if (btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] < 0 || this.m_Data[btnId2] >= DataManager.Instance.AllianceMember.Length)
            break;
          this.m_DemiseStr.ClearString();
          this.m_DemiseName = DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name;
          DataManager.Instance.m_DemiseName = this.m_DemiseName;
          StringManager.Instance.StringToFormat(this.m_DemiseName);
          this.m_DemiseStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4794U));
          this.m_UserID = DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId;
          GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(4793U), this.m_DemiseStr.ToString(), arg2: btnId2, YesText: DataManager.Instance.mStringTable.GetStringByID(4797U), NoText: DataManager.Instance.mStringTable.GetStringByID(4796U));
          break;
        }
        if (this.m_AllianceType == eAllianceType.ePublicMember)
        {
          if (!(bool) (UnityEngine.Object) this.door || btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] >= this.m_Data.Count || this.m_Data[btnId2] < 0)
            break;
          DataManager.Instance.Letter_ReplyName = DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name;
          this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2);
          break;
        }
        if (this.m_AllianceType == eAllianceType.eResourceTransport)
        {
          if (!GUIManager.Instance.CanResourceTransport() || !(bool) (UnityEngine.Object) this.door || btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] >= this.m_Data.Count || this.m_Data[btnId2] < 0)
            break;
          DataManager.Instance.AllyMemberIdx = this.m_Data[btnId2];
          DataManager.Instance.SendAllyPoint(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name);
          break;
        }
        if (this.m_AllianceType == eAllianceType.eReinforce)
        {
          if (!this.door.m_GroundInfo.ReinforceCheck() || !(bool) (UnityEngine.Object) this.door || btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] >= DataManager.Instance.AllianceMember.Length)
            break;
          DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenReinforce_NoLoc;
          DataManager.Instance.m_InForceName = DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name;
          DataManager.Instance.SendAllyInforceInfo(DataManager.Instance.m_InForceName);
          break;
        }
        if (this.m_AllianceType == eAllianceType.eReward)
        {
          if (btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] >= DataManager.Instance.AllianceMember.Length)
            break;
          this.m_SendRewardIdx = this.m_Data[btnId2];
          byte giftCount = this.GetGiftCount();
          if ((int) DataManager.MapDataController.FocusKingdomID == (int) ActivityManager.Instance.KOWKingdomID)
          {
            if (DataManager.Instance.KingGift.WonderID == (byte) 0 && DataManager.MapDataController.CheckWorldKingFunction(eWorldKingFunction.eReward))
            {
              if (giftCount > (byte) 0)
              {
                if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
                {
                  DataManager.Instance.KingGift.SendKingGift(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId, this.m_RewardItemID, true);
                  break;
                }
                DataManager.Instance.KingGift.SendKingGift(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId, this.m_RewardItemID, true, true);
                break;
              }
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744U), (ushort) byte.MaxValue);
              break;
            }
            if (!DataManager.MapDataController.CheckNobilityFunction(eNobilityFunction.eReward, DataManager.Instance.KingGift.WonderID))
              break;
            if (giftCount > (byte) 0)
            {
              if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
              {
                DataManager.Instance.KingGift.SendNobilityGift(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId, this.m_RewardItemID);
                break;
              }
              DataManager.Instance.KingGift.SendNobilityGift(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId, this.m_RewardItemID, true);
              break;
            }
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744U), (ushort) byte.MaxValue);
            break;
          }
          if (giftCount > (byte) 0)
          {
            if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eReward))
              break;
            DataManager.Instance.KingGift.SendKingGift(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].UserId, this.m_RewardItemID);
            break;
          }
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744U), (ushort) byte.MaxValue);
          break;
        }
        if (this.m_AllianceType != eAllianceType.eAmbush || !(bool) (UnityEngine.Object) this.door || !this.door.m_GroundInfo.CheckMarchEventDataCount() || btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] >= DataManager.Instance.AllianceMember.Length)
          break;
        AmbushManager.Instance.SendAllyAmbushInfo(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name);
        break;
      case 3:
        if (!(bool) (UnityEngine.Object) this.door)
          break;
        this.door.CloseMenu();
        break;
      case 4:
        switch (this.m_AllianceType)
        {
          case eAllianceType.eManagement:
          case eAllianceType.ePublicMember:
          case eAllianceType.eResourceTransport:
          case eAllianceType.eReinforce:
          case eAllianceType.eAmbush:
            if (!(bool) (UnityEngine.Object) this.door)
              return;
            this.door.OpenMenu(EGUIWindow.UI_Alliance_Permission);
            return;
          case eAllianceType.eApply:
            GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(4741U), DataManager.Instance.mStringTable.GetStringByID(800U), bInfo: true, BackExit: true);
            return;
          case eAllianceType.eDemise:
            GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(4744U), DataManager.Instance.mStringTable.GetStringByID(798U), bInfo: true, BackExit: true);
            return;
          case eAllianceType.eReward:
            return;
          default:
            return;
        }
      case 101:
        if (this.m_ManagePanelIdx >= this.m_Data.Count)
          break;
        int num = this.m_Data[this.m_ManagePanelIdx];
        if (num < 0 || num >= DataManager.Instance.AllianceMember.Length || this.m_ManagementName == null)
          break;
        GUIManager.Instance.OpenSendGiftUI(DataManager.Instance.RoleAlliance.Tag, this.m_ManagementName);
        break;
      case 102:
        this.OpenManagement(false);
        break;
      case 103:
        if (btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] < 0 || this.m_Data[btnId2] >= DataManager.Instance.m_RecvDataIdx || this.m_Data[btnId2] < 0)
          break;
        DataManager.Instance.ShowLordProfile(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name);
        break;
      case 104:
        if (!(bool) (UnityEngine.Object) this.door || this.m_Data[btnId2] < 0 || this.m_Data[btnId2] >= DataManager.Instance.AllianceMember.Length)
          break;
        DataManager.Instance.Letter_ReplyName = DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name;
        this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2);
        break;
      case 105:
        if (sender.m_BtnID2 == 200)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        this.OpenRankChange(true, this.m_ManagePanelIdx);
        break;
      case 106:
        if (sender.m_BtnID2 == 200)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        if (btnId2 >= this.m_Data.Count || this.m_Data[btnId2] >= DataManager.Instance.m_RecvDataIdx || this.m_Data[btnId2] < 0)
          break;
        this.m_Expel.ClearString();
        StringManager.Instance.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name);
        this.m_Expel.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4769U));
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(4768U), this.m_Expel.ToString(), 1, btnId2, DataManager.Instance.mStringTable.GetStringByID(4771U), DataManager.Instance.mStringTable.GetStringByID(4770U));
        break;
      case 107:
        if (btnId2 < 0 || btnId2 >= this.m_Data.Count || this.m_Data[btnId2] >= DataManager.Instance.m_RecvDataIdx || this.m_Data[btnId2] < 0)
          break;
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.ClearString();
        cstring.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[btnId2]].Name);
        cstring.AppendFormat("{0}");
        byte btnType = this.ShowCanonizedBtnByTableID();
        switch (btnType)
        {
          case 1:
            TitleManager.Instance.OpenTitleSet(cstring);
            return;
          case 2:
            TitleManager.Instance.OpenTitleListW(cstring);
            return;
          case 3:
          case 5:
          case 6:
          case 7:
            GUIManager.Instance.OpenCanonizedPanel(cstring, (byte) 1, (int) btnType);
            return;
          case 4:
            TitleManager.Instance.OpenNobilityTitleSet(cstring);
            return;
          default:
            return;
        }
      case 108:
        if (sender.m_BtnID2 >= 200)
        {
          this.ShowMessage(sender.m_BtnID2);
          break;
        }
        int x = DataManager.Instance.RoleAlliance.Rank == AllianceRank.RANK1 || DataManager.Instance.RoleAlliance.Rank == AllianceRank.RANK2 ? 10 : 5;
        GUIManager.Instance.MsgStr.ClearString();
        GUIManager.Instance.MsgStr.IntToFormat((long) x);
        GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9530U));
        GUIManager.Instance.OpenSpendWindow_Normal((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(9529U), GUIManager.Instance.MsgStr.ToString(), 2000, 3, Buttontext: DataManager.Instance.mStringTable.GetStringByID(9537U));
        this.bOpenDismissLeader = true;
        break;
      case 201:
        if (sender.m_BtnID2 == 200)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        this.SetSelectRank(4);
        this.m_Rank = AllianceRank.RANK4;
        break;
      case 202:
        if (sender.m_BtnID2 == 200)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        this.SetSelectRank(3);
        this.m_Rank = AllianceRank.RANK3;
        break;
      case 203:
        if (sender.m_BtnID2 == 200)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        this.SetSelectRank(2);
        this.m_Rank = AllianceRank.RANK2;
        break;
      case 204:
        if (sender.m_BtnID2 == 200)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        this.SetSelectRank(1);
        this.m_Rank = AllianceRank.RANK1;
        break;
      case 205:
        if (this.m_RankChangePanelIdx >= DataManager.Instance.m_RecvDataIdx || this.m_RankChangePanelIdx < 0)
          break;
        if (DataManager.Instance.AllianceMember[this.m_RankChangePanelIdx].UserId == this.m_UserID && DataManager.Instance.AllianceMember[this.m_RankChangePanelIdx].Rank == this.m_Rank)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(797U), (ushort) byte.MaxValue);
          break;
        }
        DataManager.Instance.SendAllianceModifyRank(this.m_UserID, this.m_Rank);
        this.OpenManagement(false);
        this.OpenRankChange(false);
        break;
      case 206:
        this.OpenRankChange(false);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    AllianceMemberClientDataType[] allianceMember = DataManager.Instance.AllianceMember;
    if (dataIdx >= this.m_Data.Count || panelObjectIdx >= this.m_AllianceListText.Length)
      return;
    if (this.m_Data[dataIdx] < 0)
    {
      item.GetComponent<RectTransform>().sizeDelta = new Vector2(829f, 53f);
      int index = Mathf.Abs(this.m_Data[dataIdx]) - 1;
      item.transform.GetChild(0).gameObject.SetActive(true);
      item.transform.GetChild(1).gameObject.SetActive(false);
      if (this.m_ItemStr[panelObjectIdx] == null)
        this.m_ItemStr[panelObjectIdx] = new CString[10];
      if (this.m_ItemStr[panelObjectIdx][0] == null)
        this.m_ItemStr[panelObjectIdx][0] = StringManager.Instance.SpawnString(4);
      this.m_ItemStr[panelObjectIdx][0].ClearString();
      StringManager.Instance.IntToFormat((long) (index + 1));
      this.m_ItemStr[panelObjectIdx][0].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4738U));
      this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4738U), (object) (index + 1));
      UIText component1 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
      component1.text = this.m_ItemStr[panelObjectIdx][0].ToString();
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      item.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = this.m_SpritesArray.GetSprite(index + 2);
      if (this.m_ItemStr[panelObjectIdx] == null)
        this.m_ItemStr[panelObjectIdx] = new CString[10];
      if (this.m_ItemStr[panelObjectIdx][1] == null)
        this.m_ItemStr[panelObjectIdx][1] = StringManager.Instance.SpawnString(2);
      this.m_ItemStr[panelObjectIdx][1].ClearString();
      StringManager.Instance.IntToFormat((long) this.m_Group[index].Count);
      this.m_ItemStr[panelObjectIdx][1].AppendFormat("{0}");
      UIText component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
      component2.text = this.m_ItemStr[panelObjectIdx][1].ToString();
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      if (this.m_Group[index].bOpen && this.m_Group[index].Count > (byte) 0)
        item.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = this.m_SpritesArray.GetSprite(0);
      else
        item.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = this.m_SpritesArray.GetSprite(1);
    }
    else
    {
      item.GetComponent<RectTransform>().sizeDelta = new Vector2(829f, 74f);
      item.transform.GetChild(1).gameObject.SetActive(true);
      item.transform.GetChild(0).gameObject.SetActive(false);
      UIHIBtn component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
      ushort head = DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Head;
      int rank = (int) DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Rank;
      GUIManager.Instance.ChangeHeroItemImg(((Component) component3).transform, eHeroOrItem.Hero, head, (byte) 11, (byte) 0);
      Image component4 = item.transform.GetChild(1).GetChild(1).GetComponent<Image>();
      if (this.m_AllianceType != eAllianceType.eApply)
      {
        component4.sprite = this.m_SpritesArray.GetSprite(rank + 1);
        ((Component) component4).gameObject.SetActive(true);
      }
      else
        ((Component) component4).gameObject.SetActive(false);
      if (this.m_ItemStr[panelObjectIdx] == null)
        this.m_ItemStr[panelObjectIdx] = new CString[10];
      if (this.m_ItemStr[panelObjectIdx][5] == null)
        this.m_ItemStr[panelObjectIdx][5] = StringManager.Instance.SpawnString(200);
      CString Nickname = StringManager.Instance.StaticString1024();
      Nickname.ClearString();
      if ((this.m_AllianceType == eAllianceType.eManagement || this.m_AllianceType == eAllianceType.eResourceTransport || this.m_AllianceType == eAllianceType.eReinforce || this.m_AllianceType == eAllianceType.eReward) && DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].NickName != null && DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].NickName.Length != 0)
      {
        Nickname.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].NickName);
        Nickname.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9097U));
      }
      CString Name = StringManager.Instance.StaticString1024();
      Name.Append(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Name);
      GameConstants.FormatRoleName(this.m_ItemStr[panelObjectIdx][5], Name, Nickname: Nickname, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      UIText component5 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component5.SetCheckArabic(true);
      component5.text = this.m_ItemStr[panelObjectIdx][5].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.m_AllianceListText[panelObjectIdx].Name = component5;
      if (this.m_ItemStr[panelObjectIdx] == null)
        this.m_ItemStr[panelObjectIdx] = new CString[10];
      if (this.m_ItemStr[panelObjectIdx][2] == null)
        this.m_ItemStr[panelObjectIdx][2] = StringManager.Instance.SpawnString(20);
      this.m_ItemStr[panelObjectIdx][2].ClearString();
      StringManager.Instance.uLongToFormat(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Power, bNumber: true);
      this.m_ItemStr[panelObjectIdx][2].AppendFormat("{0}");
      UIText component6 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component6.text = this.m_ItemStr[panelObjectIdx][2].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      this.m_AllianceListText[panelObjectIdx].Power = component6;
      if (this.m_ItemStr[panelObjectIdx] == null)
        this.m_ItemStr[panelObjectIdx] = new CString[10];
      if (this.m_ItemStr[panelObjectIdx][3] == null)
        this.m_ItemStr[panelObjectIdx][3] = StringManager.Instance.SpawnString(20);
      this.m_ItemStr[panelObjectIdx][3].ClearString();
      StringManager.Instance.uLongToFormat(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].TroopKillNum, bNumber: true);
      this.m_ItemStr[panelObjectIdx][3].AppendFormat("{0}");
      UIText component7 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component7.text = this.m_ItemStr[panelObjectIdx][3].ToString();
      component7.SetAllDirty();
      component7.cachedTextGenerator.Invalidate();
      this.m_AllianceListText[panelObjectIdx].KillNum = component7;
      UIText component8 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
      this.m_AllianceListText[panelObjectIdx].LeaveTime = component8;
      long num = 0;
      if (allianceMember[this.m_Data[dataIdx]].LogoutTime != 0L && DataManager.Instance.ServerTime > allianceMember[this.m_Data[dataIdx]].LogoutTime)
        num = DataManager.Instance.ServerTime - allianceMember[this.m_Data[dataIdx]].LogoutTime;
      long x1 = 0;
      long x2 = 0;
      long x3 = 0;
      if (num > 0L)
      {
        x3 = num / 60L;
        x1 = x3 / 60L;
        x2 = (long) Mathf.Clamp((float) (x1 / 24L), 0.0f, 99f);
      }
      if (this.m_ItemStr[panelObjectIdx] == null)
        this.m_ItemStr[panelObjectIdx] = new CString[10];
      if (this.m_ItemStr[panelObjectIdx][4] == null)
        this.m_ItemStr[panelObjectIdx][4] = StringManager.Instance.SpawnString(200);
      this.m_ItemStr[panelObjectIdx][4].ClearString();
      CString tmpS = StringManager.Instance.StaticString1024();
      if (this.m_AllianceType != eAllianceType.eApply && this.m_AllianceType != eAllianceType.ePublicMember)
      {
        if (x2 > 0L)
        {
          tmpS.ClearString();
          if (GUIManager.Instance.IsArabic)
          {
            tmpS.IntToFormat(x2);
            tmpS.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4739U));
            tmpS.AppendFormat("{0} {1}");
          }
          else
          {
            tmpS.IntToFormat(x2);
            tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4739U));
          }
          this.m_ItemStr[panelObjectIdx][4].StringToFormat(tmpS);
          this.m_ItemStr[panelObjectIdx][4].AppendFormat("<color=#B4BEC1>{0}</color>");
          component8.text = this.m_ItemStr[panelObjectIdx][4].ToString();
          ((Component) component8).gameObject.SetActive(true);
        }
        else if (x1 > 0L)
        {
          tmpS.ClearString();
          if (GUIManager.Instance.IsArabic)
          {
            tmpS.IntToFormat(x1);
            tmpS.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(450U));
            tmpS.AppendFormat("{0} {1}");
          }
          else
          {
            tmpS.IntToFormat(x1);
            tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(450U));
          }
          this.m_ItemStr[panelObjectIdx][4].StringToFormat(tmpS);
          this.m_ItemStr[panelObjectIdx][4].AppendFormat("<color=#B4BEC1>{0}</color>");
          component8.text = this.m_ItemStr[panelObjectIdx][4].ToString();
          ((Component) component8).gameObject.SetActive(true);
        }
        else if (x3 > 0L)
        {
          tmpS.ClearString();
          if (GUIManager.Instance.IsArabic)
          {
            tmpS.IntToFormat(x3);
            tmpS.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(447U));
            tmpS.AppendFormat("{0} {1}");
          }
          else
          {
            tmpS.IntToFormat(x3);
            tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(447U));
          }
          this.m_ItemStr[panelObjectIdx][4].StringToFormat(tmpS);
          this.m_ItemStr[panelObjectIdx][4].AppendFormat("<color=#B4BEC1>{0}</color>");
          component8.text = this.m_ItemStr[panelObjectIdx][4].ToString();
          ((Component) component8).gameObject.SetActive(true);
        }
        else
          ((Component) component8).gameObject.SetActive(false);
        component8.SetAllDirty();
        component8.cachedTextGenerator.Invalidate();
      }
      this.m_AllianceListText[panelObjectIdx].BtnText1 = item.transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>();
      this.m_AllianceListText[panelObjectIdx].BtnText2 = item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>();
      if (this.m_AllianceType == eAllianceType.eManagement)
      {
        UIButton component9 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component9.m_Handler = (IUIButtonClickHandler) this;
        component9.m_BtnID1 = 1;
        component9.m_BtnID2 = dataIdx;
        ((Component) component9).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4740U);
        UIButton component10 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component10.m_Handler = (IUIButtonClickHandler) this;
        component10.m_BtnID1 = 2;
        component10.m_BtnID2 = dataIdx;
        RectTransform component11 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        component11.anchoredPosition = new Vector2(240.5f, component11.anchoredPosition.y);
        component11.sizeDelta = new Vector2(169f, 61f);
        if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
          ((Component) component10).gameObject.SetActive(false);
        else
          ((Component) component10).gameObject.SetActive(true);
        float[] numArray = new float[10]
        {
          33f,
          98f,
          108f,
          303f,
          139f,
          139f,
          333f,
          480f,
          157.5f,
          320f
        };
        Vector2 vector2;
        for (int index = 0; index < numArray.Length; ++index)
        {
          RectTransform component12 = item.transform.GetChild(1).GetChild(index).GetComponent<RectTransform>();
          vector2 = component12.anchoredPosition with
          {
            x = numArray[index]
          };
          component12.anchoredPosition = vector2;
        }
        if (GUIManager.Instance.IsArabic)
        {
          RectTransform component13 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
          vector2 = component13.anchoredPosition with
          {
            x = 134f
          };
          component13.anchoredPosition = vector2;
        }
        RectTransform component14 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
        vector2 = component14.sizeDelta with { x = 500f };
        component14.sizeDelta = vector2;
        RectTransform component15 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        vector2 = component15.anchoredPosition with
        {
          x = 312f
        };
        component15.anchoredPosition = vector2;
        RectTransform component16 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
        vector2 = component16.anchoredPosition with
        {
          x = 487.5f,
          y = -43f
        };
        component16.anchoredPosition = vector2;
        vector2 = component16.sizeDelta with { x = 143f };
        component16.sizeDelta = vector2;
        if (!GUIManager.Instance.IsArabic)
          return;
        UIText component17 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
        ((Graphic) component17).rectTransform.anchoredPosition = component17.ArabicFixPos(((Graphic) component17).rectTransform.anchoredPosition);
        UIText component18 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
        ((Graphic) component18).rectTransform.anchoredPosition = component18.ArabicFixPos(((Graphic) component18).rectTransform.anchoredPosition);
        UIText component19 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
        ((Graphic) component19).rectTransform.anchoredPosition = component19.ArabicFixPos(((Graphic) component19).rectTransform.anchoredPosition);
        UIText component20 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
        ((Graphic) component20).rectTransform.anchoredPosition = component20.ArabicFixPos(((Graphic) component20).rectTransform.anchoredPosition);
      }
      else if (this.m_AllianceType == eAllianceType.eApply)
      {
        item.transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4742U);
        UIButton component21 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component21.m_Handler = (IUIButtonClickHandler) this;
        component21.m_BtnID1 = 1;
        component21.m_BtnID2 = dataIdx;
        ((Component) component21).gameObject.SetActive(true);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4743U);
        UIButton component22 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component22.m_Handler = (IUIButtonClickHandler) this;
        component22.m_BtnID1 = 2;
        component22.m_BtnID2 = dataIdx;
        ((Component) component22).gameObject.SetActive(true);
      }
      else if (this.m_AllianceType == eAllianceType.eDemise)
      {
        UIButton component23 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component23.m_Handler = (IUIButtonClickHandler) this;
        component23.m_BtnID1 = 1;
        component23.m_BtnID2 = dataIdx;
        ((Component) component23).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4747U);
        UIButton component24 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component24.m_Handler = (IUIButtonClickHandler) this;
        component24.m_BtnID1 = 2;
        component24.m_BtnID2 = dataIdx;
        ((Component) component24).gameObject.SetActive(true);
        RectTransform component25 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        component25.anchoredPosition = new Vector2(240.5f, component25.anchoredPosition.y);
        component25.sizeDelta = new Vector2(169f, 61f);
      }
      else if (this.m_AllianceType == eAllianceType.ePublicMember)
      {
        UIButton component26 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component26.m_Handler = (IUIButtonClickHandler) this;
        component26.m_BtnID1 = 1;
        component26.m_BtnID2 = dataIdx;
        ((Component) component26).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4757U);
        UIButton component27 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component27.m_Handler = (IUIButtonClickHandler) this;
        component27.m_BtnID1 = 2;
        component27.m_BtnID2 = dataIdx;
        RectTransform component28 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        component28.anchoredPosition = new Vector2(240.5f, component28.anchoredPosition.y);
        component28.sizeDelta = new Vector2(169f, 61f);
        if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
          ((Component) component27).gameObject.SetActive(false);
        else
          ((Component) component27).gameObject.SetActive(true);
        if (!GUIManager.Instance.IsArabic)
          return;
        RectTransform component29 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
        Vector2 anchoredPosition = component29.anchoredPosition with
        {
          x = 146f
        };
        component29.anchoredPosition = anchoredPosition;
      }
      else if (this.m_AllianceType == eAllianceType.eResourceTransport)
      {
        UIButton component30 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component30.m_Handler = (IUIButtonClickHandler) this;
        component30.m_BtnID1 = 1;
        component30.m_BtnID2 = dataIdx;
        ((Component) component30).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(3951U);
        UIButton component31 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component31.m_Handler = (IUIButtonClickHandler) this;
        component31.m_BtnID1 = 2;
        component31.m_BtnID2 = dataIdx;
        RectTransform component32 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        component32.anchoredPosition = new Vector2(240.5f, component32.anchoredPosition.y);
        component32.sizeDelta = new Vector2(169f, 61f);
        if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
          ((Component) component31).gameObject.SetActive(false);
        else
          ((Component) component31).gameObject.SetActive(true);
        float[] numArray = new float[10]
        {
          33f,
          98f,
          108f,
          303f,
          139f,
          139f,
          333f,
          480f,
          157.5f,
          320f
        };
        Vector2 vector2;
        for (int index = 0; index < numArray.Length; ++index)
        {
          RectTransform component33 = item.transform.GetChild(1).GetChild(index).GetComponent<RectTransform>();
          vector2 = component33.anchoredPosition with
          {
            x = numArray[index]
          };
          component33.anchoredPosition = vector2;
        }
        if (GUIManager.Instance.IsArabic)
        {
          RectTransform component34 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
          vector2 = component34.anchoredPosition with
          {
            x = 134f
          };
          component34.anchoredPosition = vector2;
        }
        RectTransform component35 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
        vector2 = component35.sizeDelta with { x = 500f };
        component35.sizeDelta = vector2;
        RectTransform component36 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        vector2 = component36.anchoredPosition with
        {
          x = 312f
        };
        component36.anchoredPosition = vector2;
        RectTransform component37 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
        vector2 = component37.anchoredPosition with
        {
          x = 487.5f,
          y = -43f
        };
        component37.anchoredPosition = vector2;
        vector2 = component37.sizeDelta with { x = 143f };
        component37.sizeDelta = vector2;
        if (!GUIManager.Instance.IsArabic)
          return;
        UIText component38 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
        ((Graphic) component38).rectTransform.anchoredPosition = component38.ArabicFixPos(((Graphic) component38).rectTransform.anchoredPosition);
        UIText component39 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
        ((Graphic) component39).rectTransform.anchoredPosition = component39.ArabicFixPos(((Graphic) component39).rectTransform.anchoredPosition);
        UIText component40 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
        ((Graphic) component40).rectTransform.anchoredPosition = component40.ArabicFixPos(((Graphic) component40).rectTransform.anchoredPosition);
        UIText component41 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
        ((Graphic) component41).rectTransform.anchoredPosition = component41.ArabicFixPos(((Graphic) component41).rectTransform.anchoredPosition);
      }
      else if (this.m_AllianceType == eAllianceType.eReinforce)
      {
        UIButton component42 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component42.m_Handler = (IUIButtonClickHandler) this;
        component42.m_BtnID1 = 1;
        component42.m_BtnID2 = dataIdx;
        ((Component) component42).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4859U);
        UIButton component43 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component43.m_Handler = (IUIButtonClickHandler) this;
        component43.m_BtnID1 = 2;
        component43.m_BtnID2 = dataIdx;
        RectTransform component44 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        component44.anchoredPosition = new Vector2(240.5f, component44.anchoredPosition.y);
        component44.sizeDelta = new Vector2(169f, 61f);
        if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
          ((Component) component43).gameObject.SetActive(false);
        else
          ((Component) component43).gameObject.SetActive(true);
        float[] numArray = new float[10]
        {
          33f,
          98f,
          108f,
          303f,
          139f,
          139f,
          333f,
          480f,
          157.5f,
          320f
        };
        Vector2 vector2;
        for (int index = 0; index < numArray.Length; ++index)
        {
          RectTransform component45 = item.transform.GetChild(1).GetChild(index).GetComponent<RectTransform>();
          vector2 = component45.anchoredPosition with
          {
            x = numArray[index]
          };
          component45.anchoredPosition = vector2;
        }
        if (GUIManager.Instance.IsArabic)
        {
          RectTransform component46 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
          vector2 = component46.anchoredPosition with
          {
            x = 134f
          };
          component46.anchoredPosition = vector2;
        }
        RectTransform component47 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
        vector2 = component47.sizeDelta with { x = 500f };
        component47.sizeDelta = vector2;
        RectTransform component48 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        vector2 = component48.anchoredPosition with
        {
          x = 312f
        };
        component48.anchoredPosition = vector2;
        RectTransform component49 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
        vector2 = component49.anchoredPosition with
        {
          x = 487.5f,
          y = -43f
        };
        component49.anchoredPosition = vector2;
        vector2 = component49.sizeDelta with { x = 143f };
        component49.sizeDelta = vector2;
        if (!GUIManager.Instance.IsArabic)
          return;
        UIText component50 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
        ((Graphic) component50).rectTransform.anchoredPosition = component50.ArabicFixPos(((Graphic) component50).rectTransform.anchoredPosition);
        UIText component51 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
        ((Graphic) component51).rectTransform.anchoredPosition = component51.ArabicFixPos(((Graphic) component51).rectTransform.anchoredPosition);
        UIText component52 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
        ((Graphic) component52).rectTransform.anchoredPosition = component52.ArabicFixPos(((Graphic) component52).rectTransform.anchoredPosition);
        UIText component53 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
        ((Graphic) component53).rectTransform.anchoredPosition = component53.ArabicFixPos(((Graphic) component53).rectTransform.anchoredPosition);
      }
      else if (this.m_AllianceType == eAllianceType.eReward)
      {
        UIButton component54 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component54.m_Handler = (IUIButtonClickHandler) this;
        component54.m_BtnID1 = 1;
        component54.m_BtnID2 = dataIdx;
        ((Component) component54).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9712U);
        UIButton component55 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component55.m_Handler = (IUIButtonClickHandler) this;
        component55.m_BtnID1 = 2;
        component55.m_BtnID2 = dataIdx;
        RectTransform component56 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        component56.anchoredPosition = new Vector2(240.5f, component56.anchoredPosition.y);
        component56.sizeDelta = new Vector2(169f, 61f);
        if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
        {
          ((Component) component55).gameObject.SetActive(false);
          item.transform.GetChild(1).GetChild(10).gameObject.SetActive(false);
        }
        else if (this.IsReward(this.m_Data[dataIdx]))
        {
          ((Component) component55).gameObject.SetActive(false);
          item.transform.GetChild(1).GetChild(10).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9713U);
          item.transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
        }
        else
        {
          ((Component) component55).gameObject.SetActive(true);
          item.transform.GetChild(1).GetChild(10).gameObject.SetActive(false);
        }
        float[] numArray = new float[10]
        {
          33f,
          98f,
          108f,
          303f,
          139f,
          139f,
          333f,
          480f,
          157.5f,
          320f
        };
        Vector2 vector2;
        for (int index = 0; index < numArray.Length; ++index)
        {
          RectTransform component57 = item.transform.GetChild(1).GetChild(index).GetComponent<RectTransform>();
          vector2 = component57.anchoredPosition with
          {
            x = numArray[index]
          };
          component57.anchoredPosition = vector2;
        }
        if (GUIManager.Instance.IsArabic)
        {
          RectTransform component58 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
          vector2 = component58.anchoredPosition with
          {
            x = 134f
          };
          component58.anchoredPosition = vector2;
        }
        RectTransform component59 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
        vector2 = component59.sizeDelta with { x = 500f };
        component59.sizeDelta = vector2;
        RectTransform component60 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        vector2 = component60.anchoredPosition with
        {
          x = 312f
        };
        component60.anchoredPosition = vector2;
        RectTransform component61 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
        vector2 = component61.anchoredPosition with
        {
          x = 487.5f,
          y = -43f
        };
        component61.anchoredPosition = vector2;
        vector2 = component61.sizeDelta with { x = 143f };
        component61.sizeDelta = vector2;
        if (!GUIManager.Instance.IsArabic)
          return;
        UIText component62 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
        ((Graphic) component62).rectTransform.anchoredPosition = component62.ArabicFixPos(((Graphic) component62).rectTransform.anchoredPosition);
        UIText component63 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
        ((Graphic) component63).rectTransform.anchoredPosition = component63.ArabicFixPos(((Graphic) component63).rectTransform.anchoredPosition);
        UIText component64 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
        ((Graphic) component64).rectTransform.anchoredPosition = component64.ArabicFixPos(((Graphic) component64).rectTransform.anchoredPosition);
        UIText component65 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
        ((Graphic) component65).rectTransform.anchoredPosition = component65.ArabicFixPos(((Graphic) component65).rectTransform.anchoredPosition);
      }
      else
      {
        if (this.m_AllianceType != eAllianceType.eAmbush)
          return;
        UIButton component66 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
        component66.m_Handler = (IUIButtonClickHandler) this;
        component66.m_BtnID1 = 1;
        component66.m_BtnID2 = dataIdx;
        ((Component) component66).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9739U);
        UIButton component67 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
        component67.m_Handler = (IUIButtonClickHandler) this;
        component67.m_BtnID1 = 2;
        component67.m_BtnID2 = dataIdx;
        RectTransform component68 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        component68.anchoredPosition = new Vector2(240.5f, component68.anchoredPosition.y);
        component68.sizeDelta = new Vector2(169f, 61f);
        if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
          ((Component) component67).gameObject.SetActive(false);
        else
          ((Component) component67).gameObject.SetActive(true);
        float[] numArray = new float[10]
        {
          33f,
          98f,
          108f,
          303f,
          139f,
          139f,
          333f,
          480f,
          157.5f,
          320f
        };
        Vector2 vector2;
        for (int index = 0; index < numArray.Length; ++index)
        {
          RectTransform component69 = item.transform.GetChild(1).GetChild(index).GetComponent<RectTransform>();
          vector2 = component69.anchoredPosition with
          {
            x = numArray[index]
          };
          component69.anchoredPosition = vector2;
        }
        if (GUIManager.Instance.IsArabic)
        {
          RectTransform component70 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
          vector2 = component70.anchoredPosition with
          {
            x = 134f
          };
          component70.anchoredPosition = vector2;
        }
        RectTransform component71 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
        vector2 = component71.sizeDelta with { x = 500f };
        component71.sizeDelta = vector2;
        RectTransform component72 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
        vector2 = component72.anchoredPosition with
        {
          x = 312f
        };
        component72.anchoredPosition = vector2;
        RectTransform component73 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
        vector2 = component73.anchoredPosition with
        {
          x = 487.5f,
          y = -43f
        };
        component73.anchoredPosition = vector2;
        vector2 = component73.sizeDelta with { x = 143f };
        component73.sizeDelta = vector2;
        if (!GUIManager.Instance.IsArabic)
          return;
        UIText component74 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
        ((Graphic) component74).rectTransform.anchoredPosition = component74.ArabicFixPos(((Graphic) component74).rectTransform.anchoredPosition);
        UIText component75 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
        ((Graphic) component75).rectTransform.anchoredPosition = component75.ArabicFixPos(((Graphic) component75).rectTransform.anchoredPosition);
        UIText component76 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
        ((Graphic) component76).rectTransform.anchoredPosition = component76.ArabicFixPos(((Graphic) component76).rectTransform.anchoredPosition);
        UIText component77 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
        ((Graphic) component77).rectTransform.anchoredPosition = component77.ArabicFixPos(((Graphic) component77).rectTransform.anchoredPosition);
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (dataIndex >= this.m_Data.Count)
      return;
    if (this.m_Data[dataIndex] < 0)
    {
      int index1 = Mathf.Abs(this.m_Data[dataIndex]) - 1;
      if (this.m_Group[index1].Count <= (byte) 0)
        return;
      this.m_Group[index1].bOpen = !this.m_Group[index1].bOpen;
      this.SetData();
      List<float> _DataHeight = new List<float>();
      for (int index2 = 0; index2 < this.m_Data.Count; ++index2)
      {
        if (this.m_Data[index2] < 0)
          _DataHeight.Add(53f);
        else
          _DataHeight.Add(74f);
      }
      this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
    }
    else
    {
      if (dataIndex < 0 || dataIndex >= this.m_Data.Count || this.m_Data[dataIndex] < 0 || this.m_Data[dataIndex] >= DataManager.Instance.m_RecvDataIdx)
        return;
      DataManager.Instance.ShowLordProfile(DataManager.Instance.AllianceMember[this.m_Data[dataIndex]].Name);
    }
  }

  private void SetMgrData()
  {
    switch (this.m_AllianceType)
    {
      case eAllianceType.eManagement:
      case eAllianceType.eResourceTransport:
      case eAllianceType.eReinforce:
      case eAllianceType.eReward:
      case eAllianceType.eAmbush:
        int num1 = -5;
        for (int index = 0; index < 5; ++index)
        {
          this.m_Data.Add(num1);
          ++num1;
          this.m_Group[index].bOpen = false;
        }
        DataManager.Instance.SendAllianceMember();
        break;
      case eAllianceType.eApply:
        DataManager.Instance.SendAllianceApplyMember();
        break;
      case eAllianceType.eDemise:
        int num2 = -5;
        for (int index = 0; index < 5; ++index)
        {
          this.m_Data.Add(num2);
          ++num2;
          this.m_Group[index].bOpen = false;
        }
        DataManager.Instance.SendAllianceMember();
        break;
      case eAllianceType.ePublicMember:
        int num3 = -5;
        for (int index = 0; index < 5; ++index)
        {
          this.m_Data.Add(num3);
          ++num3;
          this.m_Group[index].bOpen = false;
          DataManager.Instance.SendAllianceOthorMemberInfo(this.m_AllianceID);
        }
        break;
    }
  }

  private void SetData()
  {
    switch (this.m_AllianceType)
    {
      case eAllianceType.eManagement:
      case eAllianceType.eResourceTransport:
      case eAllianceType.eReinforce:
      case eAllianceType.eReward:
      case eAllianceType.eAmbush:
        this.SetMenberData();
        break;
      case eAllianceType.eApply:
        this.SetAllianceApplyMember();
        break;
      case eAllianceType.eDemise:
        this.SetDemise();
        break;
      case eAllianceType.ePublicMember:
        this.SetMenberData();
        break;
    }
  }

  private void SetMenberData()
  {
    this.m_Data.Clear();
    for (int index = 0; index < this.m_Group.Length; ++index)
      this.m_Group[index].Count = (byte) 0;
    int num1 = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
    int num2 = 5;
    int[] numArray = new int[5];
    int index1 = 0;
    for (int index2 = 0; index2 < numArray.Length; ++index2)
      numArray[index2] = 1;
    int index3 = 0;
    for (int index4 = 0; index4 < num1 + 5; ++index4)
    {
      if (index4 == 0)
      {
        this.m_Data.Add(-num2);
      }
      else
      {
        int num3;
        if (index3 < num1)
        {
          num3 = (int) DataManager.Instance.AllianceMember[index3].Rank;
          if (num3 < 1)
          {
            ++index3;
            continue;
          }
        }
        else
          num3 = 1;
        if (index1 < numArray.Length && numArray[index1] == 1 && num3 != num2 && num2 != 0)
        {
          --num2;
          this.m_Data.Add(-num2);
          ++index1;
        }
        else if (index3 < num1)
        {
          if (this.m_Group[num3 - 1].bOpen)
            this.m_Data.Add(index3);
          ++index3;
          ++this.m_Group[num3 - 1].Count;
        }
      }
    }
  }

  private void SetAllianceApplyMember()
  {
    this.m_Data.Clear();
    for (int index = 0; index < this.m_Group.Length; ++index)
      this.m_Group[index].Count = (byte) 0;
    int recvDataIdx = DataManager.Instance.m_RecvDataIdx;
    for (int index = 0; index < recvDataIdx; ++index)
      this.m_Data.Add(index);
  }

  private void SetDemise()
  {
    this.m_Data.Clear();
    for (int index = 0; index < this.m_Group.Length; ++index)
      this.m_Group[index].Count = (byte) 0;
    int num1 = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
    int num2 = 4;
    int[] numArray = new int[5];
    int index1 = 1;
    for (int index2 = 0; index2 < numArray.Length; ++index2)
      numArray[index2] = 1;
    int index3 = 0;
    for (int index4 = 0; index4 < num1 + 4; ++index4)
    {
      if (index4 == 0)
      {
        this.m_Data.Add(-num2);
      }
      else
      {
        int num3;
        if (index3 < num1)
        {
          num3 = (int) DataManager.Instance.AllianceMember[index3].Rank;
          if (num3 < 1 || num3 == 5)
          {
            ++index3;
            continue;
          }
        }
        else
          num3 = 1;
        if (index1 < numArray.Length && numArray[index1] == 1 && num3 != num2 && num2 != 0)
        {
          --num2;
          this.m_Data.Add(-num2);
          ++index1;
        }
        else if (index3 < num1)
        {
          if (this.m_Group[num3 - 1].bOpen)
            this.m_Data.Add(index3);
          ++index3;
          ++this.m_Group[num3 - 1].Count;
        }
      }
    }
  }

  private bool FindUserId(long UserId)
  {
    bool userId = false;
    for (int index1 = 0; index1 < this.m_Data.Count; ++index1)
    {
      int index2 = this.m_Data[index1];
      if (index2 >= 0 && index2 < DataManager.Instance.AllianceMember.Length && DataManager.Instance.AllianceMember[index2].UserId == UserId)
      {
        userId = true;
        break;
      }
    }
    return userId;
  }

  private void CheckEmptyStr()
  {
    if (this.m_AllianceType != eAllianceType.eApply)
      return;
    if (DataManager.Instance.RoleAlliance.Applicant == (byte) 0)
      this.m_EmptyText.gameObject.SetActive(true);
    else
      this.m_EmptyText.gameObject.SetActive(false);
  }

  private bool ShowGiftBtn() => DataManager.Instance.CheckPrizeFlag((byte) 9);

  private void UpdateRewardData(ushort itemid)
  {
    DataManager instance = DataManager.Instance;
    List<KingGiftInfo> giftList = instance.KingGift.GetGiftList();
    int count = giftList.Count;
    for (int index = 0; index < count; ++index)
    {
      if ((int) giftList[index].ItemID == (int) itemid)
      {
        this.m_KingGiftInfoIdx = index;
        break;
      }
    }
    if (this.m_KingGiftInfoIdx < giftList.Count)
    {
      int listCount = (int) giftList[this.m_KingGiftInfoIdx].ListCount;
      Array.Clear((Array) this.m_KingGiftInfoData, 0, this.m_KingGiftInfoData.Length);
      for (int index1 = 0; index1 < this.m_Data.Count && index1 < this.m_KingGiftInfoData.Length; ++index1)
      {
        int index2 = this.m_Data[index1];
        for (int index3 = 0; index3 < listCount; ++index3)
        {
          if (index2 >= 0 && index2 < instance.AllianceMember.Length && instance.AllianceMember[index2].UserId == giftList[this.m_KingGiftInfoIdx].List[index3].UserID)
            this.m_KingGiftInfoData[index2] = true;
        }
      }
    }
    this.SetRewardCountText(this.GetGiftCount());
  }

  private bool IsReward(int dataIdx)
  {
    return dataIdx >= 0 && dataIdx < this.m_KingGiftInfoData.Length && this.m_KingGiftInfoData[dataIdx];
  }

  private byte GetGiftCount()
  {
    DataManager instance = DataManager.Instance;
    return this.m_KingGiftInfoIdx < instance.KingGift.GetGiftList().Count ? instance.KingGift.GetGiftList()[this.m_KingGiftInfoIdx].GetRemainCount() : (byte) 0;
  }

  private void SetRewardCountText(byte count)
  {
    if (this.m_RewardCount == null)
      return;
    this.m_RewardCount.ClearString();
    this.m_RewardCount.IntToFormat((long) count);
    this.m_RewardCount.AppendFormat("{0}");
    this.m_RewardCountText.text = this.m_RewardCount.ToString();
    this.m_RewardCountText.SetAllDirty();
    this.m_RewardCountText.cachedTextGenerator.Invalidate();
  }

  private bool IsKingOrConqueror()
  {
    DataManager instance = DataManager.Instance;
    bool flag = false;
    for (int index = 0; index < instance.m_Wonders.Count; ++index)
    {
      if (instance.m_Wonders[index].WonderID == (byte) 0)
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  private int IsTimeToRecall()
  {
    int recall = 0;
    DataManager instance = DataManager.Instance;
    long num1 = 0;
    long num2 = 0;
    if (this.m_Data.Count >= 2 && this.m_Data[1] >= 0 && this.m_Data[1] < instance.AllianceMember.Length)
    {
      num1 = instance.AllianceMember[this.m_Data[1]].LogoutTime;
      num2 = DataManager.Instance.ServerTime - num1;
    }
    if (instance.RoleAlliance.Rank == AllianceRank.RANK1 || instance.RoleAlliance.Rank == AllianceRank.RANK2)
    {
      if (num1 == 0L || num2 < 864000L)
        recall = 204;
    }
    else if ((instance.RoleAlliance.Rank == AllianceRank.RANK3 || instance.RoleAlliance.Rank == AllianceRank.RANK4) && (num1 == 0L || num2 < 432000L))
      recall = 203;
    return recall;
  }

  private void ShowMessage(int ErrorCode)
  {
    switch (ErrorCode)
    {
      case 201:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9532U), (ushort) byte.MaxValue);
        break;
      case 203:
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.ClearString();
        cstring1.IntToFormat(5L);
        cstring1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9536U));
        GUIManager.Instance.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
        break;
      case 204:
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.ClearString();
        cstring2.IntToFormat(10L);
        cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9536U));
        GUIManager.Instance.AddHUDMessage(cstring2.ToString(), (ushort) byte.MaxValue);
        break;
    }
  }

  private byte ShowCanonizedBtnByTableID()
  {
    byte num = 0;
    byte[] numArray = new byte[4]
    {
      (byte) 0,
      (byte) 1,
      (byte) 2,
      (byte) 4
    };
    if (DataManager.MapDataController.IsKing() || DataManager.MapDataController.IsKingdomChief())
      num += numArray[1];
    if (DataManager.MapDataController.IsWorldKing() || DataManager.MapDataController.IsWorldChief())
      num += numArray[2];
    if (DataManager.MapDataController.IsNobilityKing() || DataManager.MapDataController.IsNobilityChief())
      num += numArray[3];
    return num;
  }
}
