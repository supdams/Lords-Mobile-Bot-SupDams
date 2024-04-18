// Decompiled with JetBrains decompiler
// Type: UILetter_Collection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UILetter_Collection : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform PreviousT;
  private Transform NextT;
  private Transform[] ItemT = new Transform[6];
  private Transform[] Itme_PT1 = new Transform[6];
  private Transform[] Itme_PT2 = new Transform[6];
  private RectTransform[] BtnXY_ItemRT = new RectTransform[6];
  private RectTransform[] ImgXY_ItemRT = new RectTransform[6];
  private RectTransform[] TextXY_ItemRT = new RectTransform[6];
  private RectTransform[] Title_RT = new RectTransform[6];
  private RectTransform[] ImgBG_ItemRT = new RectTransform[6];
  private RectTransform[] Img_ItemIconRT = new RectTransform[6];
  private RectTransform[] ImgHeros_RT = new RectTransform[6];
  private RectTransform[] ImgItems_RT = new RectTransform[6];
  private RectTransform[] ImgItems_1_RT = new RectTransform[6];
  private RectTransform[] ImgItems_2_RT = new RectTransform[6];
  private RectTransform[] ImgItems_L1_RT = new RectTransform[6];
  private RectTransform[] ImgItems_L2_RT = new RectTransform[6];
  private RectTransform[] textItems_1_RT = new RectTransform[6];
  private RectTransform[] textItems_2_RT = new RectTransform[6];
  private RectTransform[] Hero_1_RT = new RectTransform[6];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];
  private UIButton btn_EXIT;
  private UIButton btn_Delete;
  private UIButton btn_Previous;
  private UIButton btn_Next;
  private UIButton[] btn_ItemXY = new UIButton[6];
  private UIHIBtn tmpHbtn;
  private UILEBtn tmpLbtn;
  private UIHIBtn[][] Hbtn_Item = new UIHIBtn[6][];
  private UILEBtn[][] Lbtn_Item = new UILEBtn[6][];
  private Image tmpImg;
  private Image[] Img_ItemNew = new Image[6];
  private Image[] Img_ItemIcon = new Image[6];
  private UIText tmptext;
  private UIText text_TitleName;
  private UIText text_Page;
  private UIText text_LastTitle;
  private UIText[] text_Time = new UIText[2];
  private UIText[] text_ItemNew = new UIText[6];
  private UIText[] text_ItemXY = new UIText[6];
  private UIText[] text_Item_Title = new UIText[6];
  private UIText[] text_Item_Time = new UIText[6];
  private UIText[] text_Item_ResourcesNum = new UIText[6];
  private UIText[][] text_Item_Num = new UIText[6][];
  private CString Cstr_Page;
  private CString Cstr_LastTitle;
  private CString[] Cstr_ItemXY = new CString[6];
  private CString[] Cstr_Item_Title = new CString[6];
  private CString[] Cstr_Item_Time = new CString[6];
  private CString[] Cstr_Item_ResourcesNum = new CString[6];
  private CString[][] Cstr_Item_Num = new CString[6][];
  private Material mMaT;
  private UISpritesArray SArray;
  private Vector3 Vec3Instance;
  private Vector2 tmpV2;
  private float tempL;
  private float MoveTime1;
  private float MoveTime2;
  private float TmpTime;
  private byte[] mItems = new byte[20];
  private byte[] mResourcesKind = new byte[20];
  private float tmpHH;
  private int mCollectionMax;
  private int MaxLetterNum;
  private int UnRead;
  private CombatReport Report;
  private CombatReport tmpCR;
  private MyFavorite Favor = new MyFavorite(Id: 0U);
  private List<float> tmplist = new List<float>();
  private Equip tmpEquip;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.mMaT = this.door.LoadMaterial();
    this.Favor.Serial = this.DM.OpenMail.Serial;
    this.Favor.Type = this.DM.OpenMail.Type;
    this.Favor.Kind = this.DM.OpenMail.Kind;
    if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
    {
      this.Report = this.Favor.Combat;
      if (this.Report.UnSeen > (byte) 0)
        this.DM.BattleReportRead(this.Report.SerialID, false);
      this.mCollectionMax = (int) this.Report.More;
      for (int index = 0; index < this.mCollectionMax; ++index)
      {
        this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + index));
        if (!this.tmpCR.BeRead)
          ++this.UnRead;
      }
      CString SpriteName = StringManager.Instance.StaticString1024();
      this.Cstr_Page = StringManager.Instance.SpawnString();
      this.Cstr_LastTitle = StringManager.Instance.SpawnString();
      for (int index1 = 0; index1 < 6; ++index1)
      {
        this.Hbtn_Item[index1] = new UIHIBtn[10];
        this.Lbtn_Item[index1] = new UILEBtn[5];
        this.text_Item_Num[index1] = new UIText[15];
        this.Cstr_Item_Num[index1] = new CString[10];
        for (int index2 = 0; index2 < 10; ++index2)
          this.Cstr_Item_Num[index1][index2] = StringManager.Instance.SpawnString();
        this.Cstr_ItemXY[index1] = StringManager.Instance.SpawnString();
        this.Cstr_Item_Title[index1] = StringManager.Instance.SpawnString();
        this.Cstr_Item_Time[index1] = StringManager.Instance.SpawnString();
        this.Cstr_Item_ResourcesNum[index1] = StringManager.Instance.SpawnString();
      }
      this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(0);
      this.text_TitleName = this.Tmp.GetComponent<UIText>();
      this.text_TitleName.font = this.TTFont;
      this.text_TitleName.text = this.DM.mStringTable.GetStringByID(6047U);
      this.Cstr_Page.ClearString();
      this.MaxLetterNum = (int) this.DM.GetMailboxSize();
      if (this.DM.OpenMail.Kind == MailType.EMAIL_BATTLE)
      {
        this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
        this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
      }
      if (this.GUIM.IsArabic)
        this.Cstr_Page.AppendFormat("{1}/{0}");
      else
        this.Cstr_Page.AppendFormat("{0}/{1}");
      this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(1);
      this.text_Page = this.Tmp.GetComponent<UIText>();
      this.text_Page.font = this.TTFont;
      this.text_Page.text = this.Cstr_Page.ToString();
      this.Tmp = this.GameT.GetChild(3).GetChild(0);
      this.btn_Delete = this.Tmp.GetComponent<UIButton>();
      this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Delete.m_BtnID1 = 1;
      this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
      this.btn_Delete.transition = (Selectable.Transition) 0;
      this.Tmp = this.GameT.GetChild(3).GetChild(1);
      this.text_LastTitle = this.Tmp.GetComponent<UIText>();
      this.text_LastTitle.font = this.TTFont;
      this.Tmp = this.GameT.GetChild(3).GetChild(2);
      this.text_Time[0] = this.Tmp.GetComponent<UIText>();
      this.text_Time[0].font = this.TTFont;
      this.Tmp = this.GameT.GetChild(3).GetChild(3);
      this.text_Time[1] = this.Tmp.GetComponent<UIText>();
      this.text_Time[1].font = this.TTFont;
      this.SetPageData(true);
      this.m_ScrollPanel = this.GameT.GetChild(1).GetComponent<ScrollPanel>();
      this.Tmp = this.GameT.GetChild(2).GetChild(1);
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
      UIButton component = this.Tmp1.GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID1 = 4;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(1);
      this.tmptext = this.Tmp1.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(1).GetChild(0);
      this.tmptext = this.Tmp1.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.tmptext.text = this.DM.mStringTable.GetStringByID(6048U);
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
      this.tmptext = this.Tmp1.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
      this.tmptext = this.Tmp1.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(1);
      this.tmptext = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      for (int index = 0; index < 5; ++index)
      {
        this.tmpHbtn = this.Tmp1.GetChild(1).GetChild(index).GetComponent<UIHIBtn>();
        this.GUIM.InitianHeroItemImg(((Component) this.tmpHbtn).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
        this.tmpLbtn = this.Tmp1.GetChild(1).GetChild(index + 5).GetComponent<UILEBtn>();
        this.GUIM.InitLordEquipImg(((Component) this.tmpLbtn).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        ((Component) this.tmpLbtn).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
        this.tmptext = this.Tmp1.GetChild(1).GetChild(index + 10).GetComponent<UIText>();
        this.tmptext.font = this.TTFont;
        this.tmpHbtn = this.Tmp1.GetChild(2).GetChild(index).GetComponent<UIHIBtn>();
        this.GUIM.InitianHeroItemImg(((Component) this.tmpHbtn).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0);
        this.tmptext = this.Tmp1.GetChild(2).GetChild(index + 5).GetComponent<UIText>();
        this.tmptext.font = this.TTFont;
        this.tmptext = this.Tmp1.GetChild(2).GetChild(index + 10).GetComponent<UIText>();
        this.tmptext.font = this.TTFont;
        this.tmptext.text = this.DM.mStringTable.GetStringByID(7695U);
      }
      this.tmplist.Add(101f);
      for (int index = 0; index < this.mCollectionMax; ++index)
      {
        this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + index));
        this.tmpHH = 35f;
        this.tmpHH += 87f;
        if (this.tmpCR.Gather.HeroNum > (byte) 0)
          this.tmpHH += 71f;
        this.tmplist.Add(this.tmpHH);
      }
      this.m_ScrollPanel.IntiScrollPanel(437f, 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
      float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
      this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
      this.PreviousT = this.GameT.GetChild(4);
      this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
      this.btn_Previous.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Previous.m_BtnID1 = 2;
      this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
      this.btn_Previous.transition = (Selectable.Transition) 0;
      this.NextT = this.GameT.GetChild(5);
      this.btn_Next = this.NextT.GetComponent<UIButton>();
      this.btn_Next.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Next.m_BtnID1 = 3;
      this.btn_Next.m_EffectType = e_EffectType.e_Scale;
      this.btn_Next.transition = (Selectable.Transition) 0;
      if ((double) this.tempL > 0.0 && (double) this.NextT.localPosition.x + (double) this.tempL > (double) x / 2.0)
        this.tempL = x / 2f - this.NextT.localPosition.x;
      this.MoveTime1 = this.NextT.localPosition.x + this.tempL;
      this.MoveTime2 = this.PreviousT.localPosition.x - this.tempL;
      if (this.GUIM.bOpenOnIPhoneX)
      {
        this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
        this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
      }
      this.Vec3Instance.Set(this.MoveTime1, this.NextT.localPosition.y, this.NextT.localPosition.z);
      this.NextT.localPosition = this.Vec3Instance;
      this.Vec3Instance.Set(this.MoveTime2, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
      this.PreviousT.localPosition = this.Vec3Instance;
      if (this.MaxLetterNum > 1)
      {
        if ((int) this.Report.Index + 1 == 1)
        {
          ((Component) this.btn_Previous).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Next).IsActive())
            ((Component) this.btn_Next).gameObject.SetActive(true);
        }
        if ((int) this.Report.Index + 1 == this.MaxLetterNum)
        {
          ((Component) this.btn_Next).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Previous).IsActive())
            ((Component) this.btn_Previous).gameObject.SetActive(true);
        }
      }
      else
      {
        ((Component) this.btn_Previous).gameObject.SetActive(false);
        ((Component) this.btn_Next).gameObject.SetActive(false);
      }
      this.Tmp = this.GameT.GetChild(6);
      this.tmpImg = this.Tmp.GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close_base");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.mMaT;
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) this.tmpImg).enabled = false;
      this.Tmp = this.GameT.GetChild(6).GetChild(0);
      this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close");
      this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 0;
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    }
    else
      this.door.CloseMenu();
  }

  public override void OnClose()
  {
    if (this.Cstr_Page != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Page);
    if (this.Cstr_LastTitle != null)
      StringManager.Instance.DeSpawnString(this.Cstr_LastTitle);
    for (int index1 = 0; index1 < 6; ++index1)
    {
      if (this.Cstr_ItemXY[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemXY[index1]);
      if (this.Cstr_Item_Title[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Item_Title[index1]);
      if (this.Cstr_Item_Time[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Item_Time[index1]);
      if (this.Cstr_Item_ResourcesNum[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Item_ResourcesNum[index1]);
      for (int index2 = 0; index2 < 10; ++index2)
      {
        if (this.Cstr_Item_Num[index1] != null && this.Cstr_Item_Num[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_Item_Num[index1][index2]);
      }
    }
  }

  public void GetTitleString(int mLv, byte mType, CString CStr)
  {
    CStr.IntToFormat((long) mLv);
    CStr.AppendFormat(this.DM.mStringTable.GetStringByID(5377U));
    switch (mType)
    {
      case 0:
        CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6031U));
        break;
      case 1:
        CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6029U));
        break;
      case 2:
        CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6028U));
        break;
      case 3:
        CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6030U));
        break;
      case 4:
        CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6033U));
        break;
      case 5:
        CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6032U));
        break;
    }
    CStr.AppendFormat("{0}");
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 1:
        if (!this.DM.BattleReportDelete(this.Report.SerialID))
          break;
        this.door.CloseMenu();
        break;
      case 2:
        this.Open_NP_Mail(false);
        break;
      case 3:
        this.Open_NP_Mail(true);
        break;
      case 4:
        this.tmpCR = this.DM.GatherReportGet(sender.m_BtnID2);
        this.door.GoToPointCode(this.tmpCR.Gather.KingdomID, this.tmpCR.Gather.GatherZone, this.tmpCR.Gather.GatherPoint, (byte) 0);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.ItemT[panelObjectIdx] == (Object) null)
    {
      this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
      this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.Itme_PT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
      this.Itme_PT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
      this.btn_ItemXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIButton>();
      this.btn_ItemXY[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.BtnXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<RectTransform>();
      this.ImgXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
      this.TextXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(1).GetComponent<RectTransform>();
      this.text_ItemXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
      this.Img_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<Image>();
      this.text_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.text_Item_Title[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<UIText>();
      this.Title_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<RectTransform>();
      this.text_Item_Time[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(3).GetComponent<UIText>();
      this.ImgBG_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetComponent<RectTransform>();
      this.Img_ItemIcon[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<Image>();
      this.Img_ItemIconRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<RectTransform>();
      this.text_Item_ResourcesNum[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.ImgItems_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<RectTransform>();
      for (int index = 0; index < 5; ++index)
      {
        this.Hbtn_Item[panelObjectIdx][index] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(index).GetComponent<UIHIBtn>();
        this.Lbtn_Item[panelObjectIdx][index] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(index + 5).GetComponent<UILEBtn>();
        this.text_Item_Num[panelObjectIdx][index] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(index + 10).GetComponent<UIText>();
      }
      this.ImgItems_1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(0).GetComponent<RectTransform>();
      this.ImgItems_2_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(1).GetComponent<RectTransform>();
      this.ImgItems_L1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(5).GetComponent<RectTransform>();
      this.ImgItems_L2_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(6).GetComponent<RectTransform>();
      this.textItems_1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(10).GetComponent<RectTransform>();
      this.textItems_2_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(11).GetComponent<RectTransform>();
      this.ImgHeros_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetComponent<RectTransform>();
      for (int index = 0; index < 5; ++index)
      {
        this.Hbtn_Item[panelObjectIdx][index + 5] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(index).GetComponent<UIHIBtn>();
        this.text_Item_Num[panelObjectIdx][index + 5] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(index + 5).GetComponent<UIText>();
        this.text_Item_Num[panelObjectIdx][index + 10] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(index + 10).GetComponent<UIText>();
      }
      this.Hero_1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(0).GetComponent<RectTransform>();
    }
    if (dataIdx == 0)
    {
      this.Itme_PT1[panelObjectIdx].gameObject.SetActive(true);
      this.Itme_PT2[panelObjectIdx].gameObject.SetActive(false);
    }
    else
    {
      this.Itme_PT1[panelObjectIdx].gameObject.SetActive(false);
      this.Itme_PT2[panelObjectIdx].gameObject.SetActive(true);
      this.SetItemData(dataIdx, panelObjectIdx);
    }
  }

  public void SetItemData(int Idx, int ItemIdx)
  {
    this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - Idx);
    if (this.UnRead > Idx - 1)
    {
      ((Component) this.Img_ItemNew[ItemIdx]).gameObject.SetActive(true);
      this.Title_RT[ItemIdx].anchoredPosition = this.text_Item_Title[ItemIdx].ArabicFixPos(new Vector2(104f, this.Title_RT[ItemIdx].anchoredPosition.y));
    }
    else
    {
      ((Component) this.Img_ItemNew[ItemIdx]).gameObject.SetActive(false);
      this.Title_RT[ItemIdx].anchoredPosition = this.text_Item_Title[ItemIdx].ArabicFixPos(new Vector2(22f, this.Title_RT[ItemIdx].anchoredPosition.y));
    }
    this.Cstr_ItemXY[ItemIdx].ClearString();
    this.tmpV2 = Vector2.zero;
    this.tmpV2 = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Gather.GatherZone, this.tmpCR.Gather.GatherPoint));
    this.Cstr_ItemXY[ItemIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4505U));
    this.Cstr_ItemXY[ItemIdx].IntToFormat((long) (int) this.tmpV2.x);
    this.Cstr_ItemXY[ItemIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4506U));
    this.Cstr_ItemXY[ItemIdx].IntToFormat((long) (int) this.tmpV2.y);
    if (this.GUIM.IsArabic)
      this.Cstr_ItemXY[ItemIdx].AppendFormat("{3}{2} {1}{0}");
    else
      this.Cstr_ItemXY[ItemIdx].AppendFormat("{0}{1} {2}{3}");
    this.text_ItemXY[ItemIdx].text = this.Cstr_ItemXY[ItemIdx].ToString();
    this.text_ItemXY[ItemIdx].SetAllDirty();
    this.text_ItemXY[ItemIdx].cachedTextGenerator.Invalidate();
    this.text_ItemXY[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
    this.BtnXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemXY[ItemIdx].preferredWidth, this.BtnXY_ItemRT[ItemIdx].sizeDelta.y);
    this.ImgXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemXY[ItemIdx].preferredWidth, this.ImgXY_ItemRT[ItemIdx].sizeDelta.y);
    this.TextXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemXY[ItemIdx].preferredWidth, this.TextXY_ItemRT[ItemIdx].sizeDelta.y);
    this.btn_ItemXY[ItemIdx].m_BtnID2 = this.mCollectionMax - Idx;
    this.Cstr_Item_Title[ItemIdx].ClearString();
    this.Cstr_Item_Title[ItemIdx].IntToFormat((long) this.tmpCR.Gather.GatherPointLevel);
    this.Cstr_Item_Title[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Gather.GatherPointKind));
    this.Cstr_Item_Title[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(6002U));
    this.text_Item_Title[ItemIdx].text = this.Cstr_Item_Title[ItemIdx].ToString();
    this.text_Item_Title[ItemIdx].SetAllDirty();
    this.text_Item_Title[ItemIdx].cachedTextGenerator.Invalidate();
    this.text_Item_Time[ItemIdx].text = GameConstants.GetDateTime(this.tmpCR.Times).ToString("MM/dd/yy HH:mm:ss");
    this.text_Item_Time[ItemIdx].SetAllDirty();
    this.text_Item_Time[ItemIdx].cachedTextGenerator.Invalidate();
    this.mResourcesKind[Idx - 1] = this.GatherPointKind(this.tmpCR.Gather.GatherPointKind);
    this.Img_ItemIcon[ItemIdx].sprite = this.SArray.m_Sprites[(int) this.mResourcesKind[Idx - 1]];
    this.Img_ItemIcon[ItemIdx].SetNativeSize();
    this.Cstr_Item_ResourcesNum[ItemIdx].ClearString();
    GameConstants.FormatResourceValue(this.Cstr_Item_ResourcesNum[ItemIdx], this.tmpCR.Gather.Resource);
    this.text_Item_ResourcesNum[ItemIdx].text = this.Cstr_Item_ResourcesNum[ItemIdx].ToString();
    this.text_Item_ResourcesNum[ItemIdx].SetAllDirty();
    this.text_Item_ResourcesNum[ItemIdx].cachedTextGenerator.Invalidate();
    float num1 = 0.0f;
    this.mItems[Idx - 1] = this.tmpCR.Gather.ItemLen;
    float num2 = num1 - 87f;
    if (this.tmpCR.Gather.ItemLen > (byte) 0)
    {
      ((Component) this.ImgItems_RT[ItemIdx]).gameObject.SetActive(true);
      if (this.tmpCR.Gather.ItemLen < (byte) 3)
      {
        this.Img_ItemIconRT[ItemIdx].anchoredPosition = new Vector2(300f, this.Img_ItemIconRT[ItemIdx].anchoredPosition.y);
        this.ImgItems_1_RT[ItemIdx].anchoredPosition = new Vector2(389f, this.ImgItems_1_RT[ItemIdx].anchoredPosition.y);
        this.ImgItems_2_RT[ItemIdx].anchoredPosition = new Vector2(518f, this.ImgItems_2_RT[ItemIdx].anchoredPosition.y);
        this.ImgItems_L1_RT[ItemIdx].anchoredPosition = new Vector2(389f, this.ImgItems_L1_RT[ItemIdx].anchoredPosition.y);
        this.ImgItems_L2_RT[ItemIdx].anchoredPosition = new Vector2(518f, this.ImgItems_L2_RT[ItemIdx].anchoredPosition.y);
        this.textItems_1_RT[ItemIdx].anchoredPosition = new Vector2(454f, this.textItems_1_RT[ItemIdx].anchoredPosition.y);
        this.textItems_2_RT[ItemIdx].anchoredPosition = new Vector2(583f, this.textItems_2_RT[ItemIdx].anchoredPosition.y);
      }
      else
      {
        this.ImgItems_1_RT[ItemIdx].anchoredPosition = new Vector2(131f, this.ImgItems_1_RT[ItemIdx].anchoredPosition.y);
        this.ImgItems_2_RT[ItemIdx].anchoredPosition = new Vector2(260f, this.ImgItems_2_RT[ItemIdx].anchoredPosition.y);
        this.ImgItems_L1_RT[ItemIdx].anchoredPosition = new Vector2(131f, this.ImgItems_L1_RT[ItemIdx].anchoredPosition.y);
        this.ImgItems_L2_RT[ItemIdx].anchoredPosition = new Vector2(260f, this.ImgItems_L2_RT[ItemIdx].anchoredPosition.y);
        this.textItems_1_RT[ItemIdx].anchoredPosition = new Vector2(196f, this.textItems_1_RT[ItemIdx].anchoredPosition.y);
        this.textItems_2_RT[ItemIdx].anchoredPosition = new Vector2(325f, this.textItems_2_RT[ItemIdx].anchoredPosition.y);
      }
      this.ImgHeros_RT[ItemIdx].anchoredPosition = new Vector2(this.ImgHeros_RT[ItemIdx].anchoredPosition.x, -71f);
      for (int index = 0; index < (int) this.tmpCR.Gather.ItemLen; ++index)
      {
        ((Component) this.text_Item_Num[ItemIdx][index]).gameObject.SetActive(true);
        this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpCR.Gather.mResourceItem[index].ItemID);
        if (this.GUIM.IsLeadItem(this.tmpEquip.EquipKind))
        {
          this.GUIM.ChangeLordEquipImg(((Component) this.Lbtn_Item[ItemIdx][index]).transform, this.tmpCR.Gather.mResourceItem[index].ItemID, this.tmpCR.Gather.mResourceItem[index].Rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          ((Component) this.Lbtn_Item[ItemIdx][index]).gameObject.SetActive(true);
          ((Component) this.Hbtn_Item[ItemIdx][index]).gameObject.SetActive(false);
        }
        else
        {
          this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Item[ItemIdx][index]).transform, eHeroOrItem.Item, this.tmpCR.Gather.mResourceItem[index].ItemID, (byte) 0, (byte) 0);
          ((Component) this.Lbtn_Item[ItemIdx][index]).gameObject.SetActive(false);
          ((Component) this.Hbtn_Item[ItemIdx][index]).gameObject.SetActive(true);
        }
        this.Cstr_Item_Num[ItemIdx][index].ClearString();
        this.Cstr_Item_Num[ItemIdx][index].IntToFormat((long) this.tmpCR.Gather.mResourceItem[index].Quantity, bNumber: true);
        if (this.GUIM.IsArabic)
          this.Cstr_Item_Num[ItemIdx][index].AppendFormat("{0}x");
        else
          this.Cstr_Item_Num[ItemIdx][index].AppendFormat("x{0}");
        this.text_Item_Num[ItemIdx][index].text = this.Cstr_Item_Num[ItemIdx][index].ToString();
        this.text_Item_Num[ItemIdx][index].SetAllDirty();
        this.text_Item_Num[ItemIdx][index].cachedTextGenerator.Invalidate();
      }
      for (int itemLen = (int) this.tmpCR.Gather.ItemLen; itemLen < 5; ++itemLen)
      {
        ((Component) this.Hbtn_Item[ItemIdx][itemLen]).gameObject.SetActive(false);
        ((Component) this.Lbtn_Item[ItemIdx][itemLen]).gameObject.SetActive(false);
        ((Component) this.text_Item_Num[ItemIdx][itemLen]).gameObject.SetActive(false);
      }
    }
    else
    {
      ((Component) this.ImgItems_RT[ItemIdx]).gameObject.SetActive(false);
      this.Img_ItemIconRT[ItemIdx].anchoredPosition = new Vector2(397f, this.Img_ItemIconRT[ItemIdx].anchoredPosition.y);
    }
    if (this.tmpCR.Gather.HeroNum > (byte) 0)
    {
      num2 -= 71f;
      this.ImgHeros_RT[ItemIdx].anchoredPosition = new Vector2(this.ImgHeros_RT[ItemIdx].anchoredPosition.x, -71f);
      ((Component) this.ImgHeros_RT[ItemIdx]).gameObject.SetActive(true);
      for (int index = 0; index < (int) this.tmpCR.Gather.HeroNum; ++index)
      {
        ((Component) this.Hbtn_Item[ItemIdx][index + 5]).gameObject.SetActive(true);
        ((Component) this.text_Item_Num[ItemIdx][index + 5]).gameObject.SetActive(true);
        ((Component) this.text_Item_Num[ItemIdx][index + 10]).gameObject.SetActive(true);
        this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Item[ItemIdx][index + 5]).transform, eHeroOrItem.Hero, this.tmpCR.Gather.mHero[index].HeroID, this.tmpCR.Gather.mHero[index].Star, (byte) 0);
        this.Cstr_Item_Num[ItemIdx][index + 5].ClearString();
        this.Cstr_Item_Num[ItemIdx][index + 5].IntToFormat((long) this.tmpCR.Gather.mHero[index].Exp, bNumber: true);
        if (this.GUIM.IsArabic)
          this.Cstr_Item_Num[ItemIdx][index + 5].AppendFormat("{0}+");
        else
          this.Cstr_Item_Num[ItemIdx][index + 5].AppendFormat("+{0}");
        this.text_Item_Num[ItemIdx][index + 5].text = this.Cstr_Item_Num[ItemIdx][index + 5].ToString();
        this.text_Item_Num[ItemIdx][index + 5].SetAllDirty();
        this.text_Item_Num[ItemIdx][index + 5].cachedTextGenerator.Invalidate();
      }
      for (int heroNum = (int) this.tmpCR.Gather.HeroNum; heroNum < 5; ++heroNum)
      {
        ((Component) this.Hbtn_Item[ItemIdx][heroNum + 5]).gameObject.SetActive(false);
        ((Component) this.text_Item_Num[ItemIdx][heroNum + 5]).gameObject.SetActive(false);
        ((Component) this.text_Item_Num[ItemIdx][heroNum + 10]).gameObject.SetActive(false);
      }
    }
    else
      ((Component) this.ImgHeros_RT[ItemIdx]).gameObject.SetActive(false);
    this.ImgBG_ItemRT[ItemIdx].sizeDelta = new Vector2(this.ImgBG_ItemRT[ItemIdx].sizeDelta.x, -num2);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void Open_NP_Mail(bool bNext)
  {
    if (!this.DM.MailReportGet(ref this.Favor, bNext) || this.Favor.Type != MailType.EMAIL_BATTLE)
      return;
    this.DM.OpenMail.Serial = this.Favor.Serial;
    this.DM.OpenMail.Type = this.Favor.Type;
    this.DM.OpenMail.Kind = this.Favor.Kind;
    switch (this.Favor.Combat.Type)
    {
      case CombatCollectReport.CCR_BATTLE:
      case CombatCollectReport.CCR_NPCCOMBAT:
        this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
        break;
      case CombatCollectReport.CCR_RESOURCE:
        this.door.OpenMenu(EGUIWindow.UI_Letter_Resources);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
        break;
      case CombatCollectReport.CCR_SCOUT:
        if (this.Favor.Combat.Scout.ScoutLevel != (byte) 0)
          this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
        else
          this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
        break;
      case CombatCollectReport.CCR_RECON:
        this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
        break;
      case CombatCollectReport.CCR_MONSTER:
        if (this.Favor.Combat.Monster.Result < (byte) 2 || this.Favor.Combat.Monster.Result > (byte) 3)
          this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
        else
          this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
        break;
      case CombatCollectReport.CCR_NPCSCOUT:
        this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
        break;
      case CombatCollectReport.CCR_PETREPORT:
        this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void SetPageData(bool bopen = false)
  {
    this.Cstr_LastTitle.ClearString();
    this.Cstr_LastTitle.IntToFormat((long) this.Report.Gather.GatherPointLevel);
    this.Cstr_LastTitle.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Gather.GatherPointKind));
    this.Cstr_LastTitle.AppendFormat(this.DM.mStringTable.GetStringByID(6050U));
    this.text_LastTitle.text = this.Cstr_LastTitle.ToString();
    this.text_LastTitle.SetAllDirty();
    this.text_LastTitle.cachedTextGenerator.Invalidate();
    this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
    this.text_Time[0].SetAllDirty();
    this.text_Time[0].cachedTextGenerator.Invalidate();
    this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
    this.text_Time[1].SetAllDirty();
    this.text_Time[1].cachedTextGenerator.Invalidate();
  }

  public byte GatherPointKind(POINT_KIND mPointkind)
  {
    byte num = 0;
    switch (mPointkind)
    {
      case POINT_KIND.PK_FOOD:
        num = (byte) 0;
        break;
      case POINT_KIND.PK_STONE:
        num = (byte) 2;
        break;
      case POINT_KIND.PK_IRON:
        num = (byte) 3;
        break;
      case POINT_KIND.PK_WOOD:
        num = (byte) 1;
        break;
      case POINT_KIND.PK_GOLD:
        num = (byte) 4;
        break;
      case POINT_KIND.PK_CRYSTAL:
        num = (byte) 5;
        break;
    }
    return num;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1)
      return;
    this.mCollectionMax = this.DM.GetMailboxGatherSize();
    this.tmplist.Clear();
    this.tmplist.Add(101f);
    for (int index = 0; index < this.mCollectionMax; ++index)
    {
      this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + index));
      this.tmpHH = 35f;
      this.tmpHH += 87f;
      if (this.tmpCR.Gather.HeroNum > (byte) 0)
        this.tmpHH += 71f;
      this.tmplist.Add(this.tmpHH);
    }
    this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
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
        if (networkNews != NetworkNews.Refresh_Mailing)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (meg[1] == (byte) 1 && meg[2] == (byte) 1)
        {
          this.Favor.Serial = this.DM.GetMailboxReportSerial(ReportSubSet.REPORTSet_GATHER);
          this.Favor.Type = this.DM.OpenMail.Type;
          this.Favor.Kind = this.DM.OpenMail.Kind;
          if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
          {
            this.Report = this.Favor.Combat;
            if (this.Report.UnSeen > (byte) 0)
              this.DM.BattleReportRead(this.Report.SerialID, false);
            this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
            this.text_Time[0].SetAllDirty();
            this.text_Time[0].cachedTextGenerator.Invalidate();
            this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
            this.text_Time[1].SetAllDirty();
            this.text_Time[1].cachedTextGenerator.Invalidate();
            this.tmplist.Clear();
            this.tmplist.Add(101f);
            this.mCollectionMax = this.DM.GetMailboxGatherSize();
            for (int index = 0; index < this.mCollectionMax; ++index)
            {
              this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + index));
              if (!this.tmpCR.BeRead)
                ++this.UnRead;
              this.tmpHH = 35f;
              this.tmpHH += 87f;
              if (this.tmpCR.Gather.HeroNum > (byte) 0)
                this.tmpHH += 71f;
              this.tmplist.Add(this.tmpHH);
            }
            this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
            this.SetPageData();
          }
          else
          {
            this.door.CloseMenu();
            break;
          }
        }
        this.MaxLetterNum = (int) this.DM.GetMailboxSize();
        if (this.MaxLetterNum > 1)
        {
          if ((int) this.Report.Index + 1 == 1)
            ((Component) this.btn_Previous).gameObject.SetActive(false);
          else
            ((Component) this.btn_Previous).gameObject.SetActive(true);
          if ((int) this.Report.Index + 1 == this.MaxLetterNum)
            ((Component) this.btn_Next).gameObject.SetActive(false);
          else
            ((Component) this.btn_Next).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.btn_Previous).gameObject.SetActive(false);
          ((Component) this.btn_Next).gameObject.SetActive(false);
        }
        this.Cstr_Page.ClearString();
        if (this.DM.OpenMail.Kind == MailType.EMAIL_BATTLE)
        {
          this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
          this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
        }
        if (this.GUIM.IsArabic)
          this.Cstr_Page.AppendFormat("{1}/{0}");
        else
          this.Cstr_Page.AppendFormat("{0}/{1}");
        this.text_Page.text = this.Cstr_Page.ToString();
        this.text_Page.SetAllDirty();
        this.text_Page.cachedTextGenerator.Invalidate();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_TitleName != (Object) null && ((Behaviour) this.text_TitleName).enabled)
    {
      ((Behaviour) this.text_TitleName).enabled = false;
      ((Behaviour) this.text_TitleName).enabled = true;
    }
    if ((Object) this.text_Page != (Object) null && ((Behaviour) this.text_Page).enabled)
    {
      ((Behaviour) this.text_Page).enabled = false;
      ((Behaviour) this.text_Page).enabled = true;
    }
    if ((Object) this.text_LastTitle != (Object) null && ((Behaviour) this.text_LastTitle).enabled)
    {
      ((Behaviour) this.text_LastTitle).enabled = false;
      ((Behaviour) this.text_LastTitle).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Time[index] != (Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 6; ++index1)
    {
      if ((Object) this.text_ItemNew[index1] != (Object) null && ((Behaviour) this.text_ItemNew[index1]).enabled)
      {
        ((Behaviour) this.text_ItemNew[index1]).enabled = false;
        ((Behaviour) this.text_ItemNew[index1]).enabled = true;
      }
      if ((Object) this.text_ItemXY[index1] != (Object) null && ((Behaviour) this.text_ItemXY[index1]).enabled)
      {
        ((Behaviour) this.text_ItemXY[index1]).enabled = false;
        ((Behaviour) this.text_ItemXY[index1]).enabled = true;
      }
      if ((Object) this.text_Item_Title[index1] != (Object) null && ((Behaviour) this.text_Item_Title[index1]).enabled)
      {
        ((Behaviour) this.text_Item_Title[index1]).enabled = false;
        ((Behaviour) this.text_Item_Title[index1]).enabled = true;
      }
      if ((Object) this.text_Item_Time[index1] != (Object) null && ((Behaviour) this.text_Item_Time[index1]).enabled)
      {
        ((Behaviour) this.text_Item_Time[index1]).enabled = false;
        ((Behaviour) this.text_Item_Time[index1]).enabled = true;
      }
      if ((Object) this.text_Item_ResourcesNum[index1] != (Object) null && ((Behaviour) this.text_Item_ResourcesNum[index1]).enabled)
      {
        ((Behaviour) this.text_Item_ResourcesNum[index1]).enabled = false;
        ((Behaviour) this.text_Item_ResourcesNum[index1]).enabled = true;
      }
      for (int index2 = 0; index2 < 15; ++index2)
      {
        if ((Object) this.text_Item_Num[index1][index2] != (Object) null && ((Behaviour) this.text_Item_Num[index1][index2]).enabled)
        {
          ((Behaviour) this.text_Item_Num[index1][index2]).enabled = false;
          ((Behaviour) this.text_Item_Num[index1][index2]).enabled = true;
        }
      }
      for (int index3 = 0; index3 < 10; ++index3)
      {
        if ((Object) this.Hbtn_Item[index1][index3] != (Object) null && ((Behaviour) this.Hbtn_Item[index1][index3]).enabled)
          this.Hbtn_Item[index1][index3].Refresh_FontTexture();
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    this.TmpTime += Time.smoothDeltaTime * 40f;
    if ((double) this.TmpTime >= 40.0)
      this.TmpTime = 0.0f;
    float num = (double) this.TmpTime <= 20.0 ? this.TmpTime : 40f - this.TmpTime;
    if ((double) num < 0.0)
      num = 0.0f;
    if ((Object) this.NextT != (Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
      this.NextT.localPosition = this.Vec3Instance;
    }
    if (!((Object) this.PreviousT != (Object) null))
      return;
    this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
    this.PreviousT.localPosition = this.Vec3Instance;
  }
}
