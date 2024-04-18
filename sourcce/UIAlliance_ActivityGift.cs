// Decompiled with JetBrains decompiler
// Type: UIAlliance_ActivityGift
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIAlliance_ActivityGift : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const int ScrollItemCount = 6;
  private DataManager DM;
  private GUIManager GUIM;
  private ActivityGiftManager AGM;
  private Transform GameT;
  private Transform Tmp;
  private Transform[] PageT = new Transform[2];
  private bool[] bFindScrollp = new bool[6];
  private ScrollPanel m_ScrollPanel;
  private UnitItem[] tmpItem = new UnitItem[6];
  private bool[] bFindScrollp_Buy = new bool[6];
  private ScrollPanel m_ScrollPanel_Buy;
  private UnitItem_Buy[] tmpItem_Buy = new UnitItem_Buy[6];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private Material m_Mat;
  private UISpritesArray SArray;
  private UIButton btn_EXIT;
  private UIButton btn_MainGift;
  private UIButton btn_I;
  private UIButton[] btnPage = new UIButton[2];
  private UIButton[] btnBuyItem = new UIButton[6];
  private Image tmpImg;
  private Image Img_ActTime;
  private Image Img_MainGifeBG;
  private Image Img_MainGife;
  private Image Img_MainGifeLight;
  private Image Img_MainGifeIcon;
  private Image Img_NoGiftGet;
  private Image Img_NoGiftBuy;
  private Image Img_BG;
  private Image Img_GiftNum;
  private Image Img_MainGiftNum;
  private Image[] Img_PageBG = new Image[2];
  private Image[] Img_PageIcon = new Image[2];
  private UIText text_Info;
  private UIText text_MainGiftGive;
  private UIText text_MainGiftGive_Meber;
  private UIText text_MainGiftReSetTime;
  private UIText text_NoGiftGet;
  private UIText text_NoGiftBuy;
  private UIText text_Title;
  private UIText text_GiftNum;
  private UIText[] text_MainGiftInfo = new UIText[2];
  private UIText[] text_Close = new UIText[3];
  private CString Cstr_CDTime;
  private CString Cstr_ActivityCDTime;
  private CString Cstr_HintNum;
  private CString Cstr_HintTime;
  private CString Cstr_HintRank;
  private CString[] Cstr_GiftNum = new CString[6];
  private CString[] Cstr_GiftCDTime = new CString[6];
  private CString[] Cstr_Price = new CString[6];
  private List<float> tmplist = new List<float>();
  private List<float> tmplist_Buy = new List<float>();
  private List<ushort> GroupID_Data = new List<ushort>();
  private List<ushort> GroupID_Buy_Data = new List<ushort>();
  private bool bThirdParty;
  private byte mPage;
  private byte mPackID = 1;
  private bool NeedUpDate;
  private Color text_Red = new Color(0.6431f, 0.0f, 0.0f);
  private Color text_Green = new Color(0.0f, 0.3686f, 0.0823f);
  private Color text_Gray = new Color(0.584f, 0.584f, 0.584f);
  private Color text_Meber = new Color(1f, 0.9687f, 0.6f);
  private UIButtonHint tmpbtnHint;
  private bool IsActTime = true;
  private CScrollRect m_Mask;
  private uButtonScale uToolMainGift;
  private float tmpSendTime = -1f;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.AGM = ActivityGiftManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.GameT = this.gameObject.transform;
    this.m_Mat = this.door.LoadMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.Cstr_CDTime = StringManager.Instance.SpawnString(200);
    this.Cstr_ActivityCDTime = StringManager.Instance.SpawnString();
    this.Cstr_HintNum = StringManager.Instance.SpawnString(200);
    this.Cstr_HintTime = StringManager.Instance.SpawnString(200);
    this.Cstr_HintRank = StringManager.Instance.SpawnString(200);
    this.Cstr_HintNum.Append(this.DM.mStringTable.GetStringByID(11213U));
    this.Cstr_HintTime.Append(this.DM.mStringTable.GetStringByID(11212U));
    this.Cstr_HintRank.Append(this.DM.mStringTable.GetStringByID(539U));
    for (int index = 0; index < 6; ++index)
    {
      this.Cstr_GiftNum[index] = StringManager.Instance.SpawnString(100);
      this.Cstr_GiftCDTime[index] = StringManager.Instance.SpawnString();
      this.Cstr_Price[index] = StringManager.Instance.SpawnString();
    }
    byte groupId = this.AGM.GroupID;
    ushort num = 0;
    FastivalSpecialData fastivalSpecialData;
    for (int index = 0; index < this.DM.FastivalSpecialDataTable.TableCount; ++index)
    {
      fastivalSpecialData = this.DM.FastivalSpecialDataTable.GetRecordByKey((ushort) (index + 1));
      if ((int) groupId == (int) fastivalSpecialData.GroupID)
      {
        this.GroupID_Data.Add(fastivalSpecialData.ID);
        ++num;
      }
    }
    this.mPackID = groupId;
    for (int index = 0; index < 6; ++index)
    {
      this.bFindScrollp[index] = false;
      this.bFindScrollp_Buy[index] = false;
    }
    this.Img_BG = this.GameT.GetChild(0).GetChild(0).GetComponent<Image>();
    for (int index = 0; index < 2; ++index)
    {
      this.Tmp = this.GameT.GetChild(0).GetChild(1 + index);
      this.btnPage[index] = this.Tmp.GetComponent<UIButton>();
      this.btnPage[index].m_Handler = (IUIButtonClickHandler) this;
      this.btnPage[index].m_BtnID1 = 1 + index;
      this.Tmp = this.GameT.GetChild(0).GetChild(1 + index).GetChild(0);
      this.Img_PageBG[index] = this.Tmp.GetComponent<Image>();
      this.Tmp = this.GameT.GetChild(0).GetChild(1 + index).GetChild(1);
      this.Img_PageIcon[index] = this.Tmp.GetComponent<Image>();
      this.GUIM.SetFastivalImage(this.mPackID, (ushort) 2, this.Img_PageIcon[index]);
      this.Img_PageIcon[index].SetNativeSize();
      this.PageT[index] = this.GameT.GetChild(0).GetChild(3 + index);
    }
    this.Img_GiftNum = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetComponent<Image>();
    this.Img_MainGiftNum = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>();
    this.Img_MainGiftNum.sprite = this.door.LoadSprite("UI_main_mess_ex_dark");
    ((MaskableGraphic) this.Img_MainGiftNum).material = this.door.LoadMaterial();
    this.tmpImg = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_mess_ex_light");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    this.text_GiftNum = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
    this.text_GiftNum.font = this.TTFont;
    this.text_GiftNum.text = this.AGM.EnableRedPocketNum.ToString();
    this.text_GiftNum.SetAllDirty();
    this.text_GiftNum.cachedTextGenerator.Invalidate();
    this.text_GiftNum.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.Img_GiftNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_GiftNum.preferredWidth), ((Graphic) this.Img_GiftNum).rectTransform.sizeDelta.y);
    if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
    {
      ((Component) this.Img_GiftNum).gameObject.SetActive(true);
      ((Component) this.Img_MainGiftNum).gameObject.SetActive(true);
      ((Component) this.text_GiftNum).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.Img_MainGiftNum).gameObject.SetActive(false);
      if (this.AGM.EnableRedPocketNum > (byte) 0)
      {
        ((Component) this.text_GiftNum).gameObject.SetActive(true);
        ((Component) this.Img_GiftNum).gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.text_GiftNum).gameObject.SetActive(false);
        ((Component) this.Img_GiftNum).gameObject.SetActive(false);
      }
    }
    this.btn_I = this.GameT.GetChild(0).GetChild(5).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 7;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    this.Img_ActTime = this.GameT.GetChild(0).GetChild(6).GetComponent<Image>();
    this.text_Close[0] = this.GameT.GetChild(0).GetChild(6).GetChild(0).GetComponent<UIText>();
    this.text_Close[0].font = this.TTFont;
    this.text_Close[0].text = this.DM.mStringTable.GetStringByID(8110U);
    this.text_Close[1] = this.GameT.GetChild(0).GetChild(6).GetChild(1).GetComponent<UIText>();
    this.text_Close[1].font = this.TTFont;
    this.text_Close[2] = this.GameT.GetChild(0).GetChild(6).GetChild(2).GetComponent<UIText>();
    this.text_Close[2].font = this.TTFont;
    this.text_Close[2].text = this.DM.mStringTable.GetStringByID(5042U);
    if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityManager.Instance.ServerEventTime - this.AGM.ActivityGiftBeginTime >= 0L)
    {
      ((Component) this.text_Close[0]).gameObject.SetActive(true);
      ((Component) this.text_Close[1]).gameObject.SetActive(true);
      ((Component) this.text_Close[2]).gameObject.SetActive(false);
      this.Img_ActTime.sprite = this.SArray.m_Sprites[5];
      this.Cstr_ActivityCDTime.ClearString();
      if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 86400L)
      {
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 86400L);
        this.Cstr_ActivityCDTime.AppendFormat("{0}d");
      }
      else if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime >= 0L)
      {
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2);
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2);
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 60L, 2);
        this.Cstr_ActivityCDTime.AppendFormat("{0}:{1}:{2}");
      }
      else
        this.Cstr_ActivityCDTime.AppendFormat("00:00:00");
      this.text_Close[1].text = this.Cstr_ActivityCDTime.ToString();
      this.text_Close[1].SetAllDirty();
      this.text_Close[1].cachedTextGenerator.Invalidate();
    }
    else
    {
      this.IsActTime = false;
      ((Component) this.text_Close[0]).gameObject.SetActive(false);
      ((Component) this.text_Close[1]).gameObject.SetActive(false);
      ((Component) this.text_Close[2]).gameObject.SetActive(true);
      this.Img_ActTime.sprite = this.SArray.m_Sprites[6];
    }
    this.Img_MainGifeBG = this.PageT[0].GetChild(0).GetComponent<Image>();
    this.btn_MainGift = this.PageT[0].GetChild(0).GetChild(0).GetComponent<UIButton>();
    this.btn_MainGift.m_Handler = (IUIButtonClickHandler) this;
    this.btn_MainGift.m_BtnID1 = 3;
    this.btn_MainGift.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_MainGift.transition = (Selectable.Transition) 0;
    this.uToolMainGift = this.PageT[0].GetChild(0).GetChild(0).GetComponent<uButtonScale>();
    this.text_MainGiftGive = this.PageT[0].GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_MainGiftGive.font = this.TTFont;
    this.Img_MainGife = this.PageT[0].GetChild(0).GetChild(1).GetComponent<Image>();
    this.text_MainGiftGive_Meber = this.PageT[0].GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_MainGiftGive_Meber.font = this.TTFont;
    this.Img_MainGifeLight = this.PageT[0].GetChild(0).GetChild(2).GetComponent<Image>();
    this.Img_MainGifeIcon = this.PageT[0].GetChild(0).GetChild(3).GetComponent<Image>();
    this.GUIM.SetFastivalImage(this.mPackID, (ushort) 1, this.Img_MainGifeIcon);
    this.Img_MainGifeIcon.SetNativeSize();
    this.text_MainGiftReSetTime = this.PageT[0].GetChild(0).GetChild(4).GetComponent<UIText>();
    this.text_MainGiftReSetTime.font = this.TTFont;
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.ClearString();
    this.Cstr_CDTime.ClearString();
    if (GameConstants.GetDateTime(this.AGM.ActivityGiftBeginTime).Hour == 0)
      tmpS.IntToFormat(24L, 2);
    else
      tmpS.IntToFormat((long) GameConstants.GetDateTime(this.AGM.ActivityGiftBeginTime).Hour, 2);
    tmpS.IntToFormat((long) GameConstants.GetDateTime(this.AGM.ActivityGiftBeginTime).Minute, 2);
    tmpS.AppendFormat("{0}:{1}");
    this.Cstr_CDTime.StringToFormat(tmpS);
    this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(11200U));
    this.text_MainGiftReSetTime.resizeTextMinSize = 10;
    this.text_MainGiftReSetTime.text = this.Cstr_CDTime.ToString();
    ((Graphic) this.text_MainGiftReSetTime).rectTransform.sizeDelta = new Vector2(411f, ((Graphic) this.text_MainGiftReSetTime).rectTransform.sizeDelta.y);
    this.text_MainGiftReSetTime.SetAllDirty();
    this.text_MainGiftReSetTime.cachedTextGenerator.Invalidate();
    this.text_MainGiftReSetTime.cachedTextGeneratorForLayout.Invalidate();
    this.text_MainGiftInfo[0] = this.PageT[0].GetChild(0).GetChild(5).GetComponent<UIText>();
    this.text_MainGiftInfo[0].font = this.TTFont;
    this.text_MainGiftInfo[1] = this.PageT[0].GetChild(0).GetChild(6).GetComponent<UIText>();
    this.text_MainGiftInfo[1].font = this.TTFont;
    if (this.GroupID_Data.Count > 0)
    {
      this.text_MainGiftInfo[0].text = this.DM.mStringTable.GetStringByID((uint) this.DM.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Data[0]).ItemName);
      this.text_MainGiftInfo[1].text = this.DM.mStringTable.GetStringByID((uint) this.DM.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Data[0]).ItemHint);
    }
    this.MainGiftBtnCheck();
    this.Img_NoGiftGet = this.PageT[0].GetChild(1).GetComponent<Image>();
    this.text_NoGiftGet = this.PageT[0].GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_NoGiftGet.font = this.TTFont;
    this.text_NoGiftGet.text = this.DM.mStringTable.GetStringByID(11203U);
    this.m_ScrollPanel = this.PageT[0].GetChild(2).GetComponent<ScrollPanel>();
    this.m_ScrollPanel.m_ScrollPanelID = 1;
    this.Tmp = this.PageT[0].GetChild(3);
    this.tmpImg = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.tmpImg).material = this.GUIM.m_ItemIconSpriteAsset.GetMaterial();
    this.tmpImg = this.Tmp.GetChild(1).GetChild(1).GetComponent<Image>();
    ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
    UIButton component1 = this.Tmp.GetChild(2).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 4;
    component1.SoundIndex = (byte) 64;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
    UIText component2 = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
    component2.font = this.TTFont;
    component2.text = this.DM.mStringTable.GetStringByID(11189U);
    this.tmpImg = this.Tmp.GetChild(3).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).gameObject.AddComponent<ArabicItemTextureRot>();
    UIText component3 = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
    component3.font = this.TTFont;
    component3.text = this.DM.mStringTable.GetStringByID(7012U);
    this.tmpImg = this.Tmp.GetChild(4).GetComponent<Image>();
    this.GUIM.SetFastivalImage(this.mPackID, (ushort) 3, this.tmpImg);
    this.tmpImg.SetNativeSize();
    this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>().font = this.TTFont;
    this.Tmp.GetChild(5).GetChild(0).GetComponent<UIText>().font = this.TTFont;
    this.tmpImg = this.Tmp.GetChild(6).GetComponent<Image>();
    this.tmpbtnHint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.Parm1 = (ushort) 3;
    this.Tmp.GetChild(6).GetChild(0).GetComponent<UIText>().font = this.TTFont;
    UIText component4 = this.Tmp.GetChild(7).GetComponent<UIText>();
    component4.font = this.TTFont;
    ((Graphic) component4).rectTransform.sizeDelta = new Vector2(240f, ((Graphic) component4).rectTransform.sizeDelta.y);
    this.tmpImg = this.Tmp.GetChild(8).GetComponent<Image>();
    this.tmpbtnHint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.Parm1 = (ushort) 1;
    this.tmpImg = this.Tmp.GetChild(9).GetComponent<Image>();
    this.tmpbtnHint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.Parm1 = (ushort) 2;
    this.AGM.sortData();
    this.tmplist.Clear();
    for (int index = 0; index < this.AGM.mListActGift.Count; ++index)
      this.tmplist.Add(137f);
    this.m_ScrollPanel.IntiScrollPanel(337f, 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
    this.m_Mask = this.m_ScrollPanel.transform.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.m_Mask;
    this.ScrollPanelCheck();
    this.text_Info = this.PageT[1].GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.text_Info.text = this.DM.mStringTable.GetStringByID(11201U);
    this.Img_NoGiftBuy = this.PageT[1].GetChild(1).GetComponent<Image>();
    this.text_NoGiftBuy = this.PageT[1].GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_NoGiftBuy.font = this.TTFont;
    this.text_NoGiftBuy.text = this.DM.mStringTable.GetStringByID(11211U);
    this.m_ScrollPanel_Buy = this.PageT[1].GetChild(2).GetComponent<ScrollPanel>();
    this.m_ScrollPanel_Buy.m_ScrollPanelID = 2;
    this.Tmp = this.PageT[1].GetChild(3);
    UIButton component5 = this.Tmp.GetChild(1).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 5;
    component5.SoundIndex = (byte) 64;
    component5.m_EffectType = e_EffectType.e_Scale;
    component5.transition = (Selectable.Transition) 0;
    this.tmpImg = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.tmpImg).material = this.GUIM.m_ItemIconSpriteAsset.GetMaterial();
    this.tmpImg = this.Tmp.GetChild(1).GetChild(1).GetComponent<Image>();
    ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
    UIButton component6 = this.Tmp.GetChild(2).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 6;
    component6.SoundIndex = (byte) 64;
    component6.m_EffectType = e_EffectType.e_Scale;
    component6.transition = (Selectable.Transition) 0;
    this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>().font = this.TTFont;
    UIText component7 = this.Tmp.GetChild(2).GetChild(1).GetComponent<UIText>();
    component7.font = this.TTFont;
    component7.text = this.DM.mStringTable.GetStringByID(284U);
    this.Tmp.GetChild(2).GetChild(3).GetComponent<UIText>().font = this.TTFont;
    this.Tmp.GetChild(3).GetComponent<UIText>().font = this.TTFont;
    UIText component8 = this.Tmp.GetChild(4).GetComponent<UIText>();
    component8.font = this.TTFont;
    component8.resizeTextMinSize = 10;
    if (this.bThirdParty)
    {
      this.Tmp.GetChild(2).GetChild(0).gameObject.SetActive(false);
      this.Tmp.GetChild(2).GetChild(2).gameObject.SetActive(true);
      this.Tmp.GetChild(2).GetChild(3).gameObject.SetActive(true);
    }
    if (this.GUIM.IsArabic)
    {
      ((Transform) this.Tmp.GetChild(2).GetChild(0).GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
      ((Transform) this.Tmp.GetChild(2).GetChild(3).GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    }
    int tableCount = this.DM.FastivalSpecialDataTable.TableCount;
    for (int Index = 0; Index < tableCount; ++Index)
    {
      fastivalSpecialData = this.DM.FastivalSpecialDataTable.GetRecordByIndex(Index);
      for (int index = 0; index < this.GroupID_Data.Count; ++index)
      {
        if ((int) fastivalSpecialData.ID == (int) this.GroupID_Data[index] && fastivalSpecialData.StoreID > 0U)
        {
          this.tmplist_Buy.Add(120f);
          this.GroupID_Buy_Data.Add(fastivalSpecialData.ID);
          break;
        }
      }
    }
    this.m_ScrollPanel_Buy.IntiScrollPanel(424f, 0.0f, 0.0f, this.tmplist_Buy, 6, (IUpDateScrollPanel) this);
    if (this.tmplist_Buy.Count == 0 || this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime < 0L)
    {
      ((Component) this.Img_NoGiftBuy).gameObject.SetActive(true);
      this.m_ScrollPanel_Buy.gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.Img_NoGiftBuy).gameObject.SetActive(false);
      this.m_ScrollPanel_Buy.gameObject.SetActive(true);
    }
    if (this.tmplist_Buy.Count == 0)
      ((Component) this.btnPage[1]).gameObject.SetActive(false);
    else
      ((Component) this.btnPage[1]).gameObject.SetActive(true);
    this.text_Title = this.GameT.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.tmpImg = this.GameT.GetChild(2).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    this.SetPage(this.AGM.mActivityGiftPage);
  }

  public void ScrollPanelCheck()
  {
    if (this.tmplist.Count == 0)
    {
      ((Component) this.Img_NoGiftGet).gameObject.SetActive(true);
      this.m_ScrollPanel.gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.Img_NoGiftGet).gameObject.SetActive(false);
      this.m_ScrollPanel.gameObject.SetActive(true);
    }
  }

  public void SetPage(byte Idx)
  {
    this.mPage = Idx;
    if (this.mPage == (byte) 0)
    {
      this.text_Title.text = this.DM.mStringTable.GetStringByID(11186U);
      this.PageT[0].gameObject.SetActive(true);
      this.PageT[1].gameObject.SetActive(false);
      ((Graphic) this.Img_PageBG[0]).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.Img_PageBG[1]).color = new Color(1f, 1f, 1f, 0.0f);
      ((Component) this.Img_BG).gameObject.SetActive(true);
      ((Component) this.btn_I).gameObject.SetActive(true);
      this.AGM.sortData();
      this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
      this.m_Mask.StopMovement();
      this.m_ScrollPanel.GoTo(0);
    }
    else
    {
      this.text_Title.text = this.DM.mStringTable.GetStringByID(11216U);
      this.PageT[0].gameObject.SetActive(false);
      this.PageT[1].gameObject.SetActive(true);
      ((Graphic) this.Img_PageBG[0]).color = new Color(1f, 1f, 1f, 0.0f);
      ((Graphic) this.Img_PageBG[1]).color = new Color(1f, 1f, 1f, 1f);
      ((Component) this.Img_BG).gameObject.SetActive(false);
      ((Component) this.btn_I).gameObject.SetActive(false);
    }
  }

  public override void OnClose()
  {
    if (this.Cstr_CDTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
    if (this.Cstr_ActivityCDTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_ActivityCDTime);
    if (this.Cstr_HintNum != null)
      StringManager.Instance.DeSpawnString(this.Cstr_HintNum);
    if (this.Cstr_HintTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_HintTime);
    if (this.Cstr_HintRank != null)
      StringManager.Instance.DeSpawnString(this.Cstr_HintRank);
    for (int index = 0; index < 6; ++index)
    {
      if (this.Cstr_GiftNum[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_GiftNum[index]);
      if (this.Cstr_GiftCDTime[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_GiftCDTime[index]);
      if (this.Cstr_Price[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Price[index]);
    }
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
        if ((int) this.mPage == (int) (byte) (sender.m_BtnID1 - 1))
          break;
        this.SetPage((byte) (sender.m_BtnID1 - 1));
        break;
      case 3:
        if (!this.GUIM.ShowUILock(EUILock.ActGift))
          break;
        this.AGM.AllianceLeaderSendGift();
        break;
      case 4:
        if (sender.m_BtnID2 < 0 || (double) this.tmpSendTime >= 0.0)
          break;
        this.tmpSendTime = 0.0f;
        RectTransform component1 = ((Component) sender).transform.parent.GetComponent<RectTransform>();
        RectTransform component2 = ((Component) sender).transform.parent.parent.GetComponent<RectTransform>();
        RectTransform component3 = ((Component) sender).transform.parent.parent.parent.GetComponent<RectTransform>();
        RectTransform component4 = ((Component) sender).transform.parent.parent.parent.parent.GetComponent<RectTransform>();
        this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + (double) component1.anchoredPosition.x + (double) component2.anchoredPosition.x + (double) component3.anchoredPosition.x - (double) component3.sizeDelta.x / 2.0 + (double) component4.sizeDelta.x + 46.0), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component1.anchoredPosition.y - (double) component2.anchoredPosition.y - (double) component3.anchoredPosition.y - (double) component3.sizeDelta.y / 2.0 - 17.0));
        this.AGM.GetGift(this.AGM.mListActGift[sender.m_BtnID2].serverIndex, this.DM.FastivalSpecialDataTable.GetRecordByKey(this.AGM.mListActGift[sender.m_BtnID2].SN).StoreID);
        break;
      case 5:
        ActivityGiftManager.Instance.mActivityGiftPage = (byte) 1;
        MallManager.Instance.OpenDetail((ushort) sender.m_BtnID2);
        break;
      case 6:
        if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 17)
        {
          this.GUIM.MsgStr.ClearString();
          this.GUIM.MsgStr.Append(this.DM.mStringTable.GetStringByID(11210U));
          GUIManager.Instance.AddHUDMessage(this.GUIM.MsgStr.ToString(), (ushort) byte.MaxValue);
          break;
        }
        if (this.AGM.mListActGift.Count > 9)
        {
          this.GUIM.MsgStr.ClearString();
          this.GUIM.MsgStr.Append(this.DM.mStringTable.GetStringByID(11209U));
          GUIManager.Instance.AddHUDMessage(this.GUIM.MsgStr.ToString(), (ushort) byte.MaxValue);
          break;
        }
        if (sender.m_BtnID2 < 0 || this.GroupID_Buy_Data.Count < 1 || MallManager.Instance.CheckbWaitBuy_RedPocket(true))
          break;
        MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK(ESpcialTreasureType.ESTST_RedPocket, DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Buy_Data[sender.m_BtnID2]).StoreID);
        break;
      case 7:
        this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11186U), this.DM.mStringTable.GetStringByID(11199U), bInfo: true, BackExit: true);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    switch (sender.Parm1)
    {
      case 1:
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.Cstr_HintNum, Vector2.zero);
        break;
      case 2:
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.Cstr_HintTime, Vector2.zero);
        break;
      case 3:
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.Cstr_HintRank, Vector2.zero);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide(true);

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId == 1)
    {
      if (panelObjectIdx >= 6)
        return;
      if (!this.bFindScrollp[panelObjectIdx])
      {
        this.bFindScrollp[panelObjectIdx] = true;
        Transform transform = item.transform;
        this.tmpItem[panelObjectIdx].ItemGO = item;
        this.tmpItem[panelObjectIdx].ScrollItem = transform.GetComponent<ScrollPanelItem>();
        this.tmpItem[panelObjectIdx].ScrollItem.m_BtnID1 = panelObjectIdx;
        this.tmpItem[panelObjectIdx].GiftItem_F = transform.GetChild(1).GetChild(1).GetComponent<Image>();
        this.tmpItem[panelObjectIdx].GiftItem = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        this.tmpItem[panelObjectIdx].ReceiveBtn = transform.GetChild(2).GetComponent<UIButton>();
        this.tmpItem[panelObjectIdx].ReceiveBtn.m_Handler = (IUIButtonClickHandler) this;
        this.tmpItem[panelObjectIdx].ReceiveBtnText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
        this.tmpItem[panelObjectIdx].ReceiveImage = transform.GetChild(3).GetComponent<Image>();
        this.tmpItem[panelObjectIdx].ReceiveImgText = transform.GetChild(3).GetChild(0).GetComponent<UIText>();
        this.tmpItem[panelObjectIdx].NumImage = transform.GetChild(4).GetComponent<Image>();
        this.tmpItem[panelObjectIdx].NumText = transform.GetChild(4).GetChild(0).GetComponent<UIText>();
        this.tmpItem[panelObjectIdx].CDTimeImage = transform.GetChild(5).GetComponent<Image>();
        this.tmpItem[panelObjectIdx].CDTimeText = transform.GetChild(5).GetChild(0).GetComponent<UIText>();
        this.tmpItem[panelObjectIdx].RankImage = transform.GetChild(6).GetComponent<Image>();
        this.tmpbtnHint = ((Component) this.tmpItem[panelObjectIdx].RankImage).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 3;
        this.tmpItem[panelObjectIdx].PlayerNameText = transform.GetChild(6).GetChild(0).GetComponent<UIText>();
        this.tmpItem[panelObjectIdx].GiftNameText = transform.GetChild(7).GetComponent<UIText>();
        this.tmpImg = transform.GetChild(8).GetComponent<Image>();
        this.tmpbtnHint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpImg = transform.GetChild(9).GetComponent<Image>();
        this.tmpbtnHint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 2;
      }
      if (dataIdx < 0 || dataIdx > this.tmplist.Count || dataIdx > this.AGM.mListActGift.Count)
        return;
      FastivalSpecialData recordByKey = DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey(this.AGM.mListActGift[dataIdx].SN);
      this.tmpItem[panelObjectIdx].GiftItem_F.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Item, (byte) recordByKey.FrameColor);
      this.tmpItem[panelObjectIdx].GiftItem.sprite = this.GUIM.m_ItemIconSpriteAsset.LoadSprite(recordByKey.PicNo);
      if (this.AGM.mListActGift[dataIdx].Status == (byte) 0)
      {
        ((Component) this.tmpItem[panelObjectIdx].ReceiveBtn).gameObject.SetActive(true);
        ((Component) this.tmpItem[panelObjectIdx].ReceiveImage).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.tmpItem[panelObjectIdx].ReceiveBtn).gameObject.SetActive(false);
        ((Component) this.tmpItem[panelObjectIdx].ReceiveImage).gameObject.SetActive(true);
      }
      if (this.AGM.mListActGift[dataIdx].Num <= (byte) 5)
        ((Graphic) this.tmpItem[panelObjectIdx].NumText).color = this.text_Red;
      else
        ((Graphic) this.tmpItem[panelObjectIdx].NumText).color = this.text_Green;
      this.Cstr_GiftNum[panelObjectIdx].ClearString();
      this.Cstr_GiftNum[panelObjectIdx].IntToFormat((long) this.AGM.mListActGift[dataIdx].Num, bNumber: true);
      this.Cstr_GiftNum[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11190U));
      this.tmpItem[panelObjectIdx].NumText.text = this.Cstr_GiftNum[panelObjectIdx].ToString();
      this.tmpItem[panelObjectIdx].NumText.SetAllDirty();
      this.tmpItem[panelObjectIdx].NumText.cachedTextGenerator.Invalidate();
      this.Cstr_GiftCDTime[panelObjectIdx].ClearString();
      if (this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime >= 0L)
      {
        this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat((this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2);
        this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat((this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2);
        this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat((this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime) % 60L, 2);
      }
      else
      {
        this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat(0L, 2);
        this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat(0L, 2);
        this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat(0L, 2);
      }
      this.Cstr_GiftCDTime[panelObjectIdx].AppendFormat("{0}:{1}:{2}");
      this.tmpItem[panelObjectIdx].CDTimeText.text = this.Cstr_GiftCDTime[panelObjectIdx].ToString();
      this.tmpItem[panelObjectIdx].CDTimeText.SetAllDirty();
      this.tmpItem[panelObjectIdx].CDTimeText.cachedTextGenerator.Invalidate();
      this.tmpItem[panelObjectIdx].RankImage.sprite = this.SArray.m_Sprites[(int) this.AGM.mListActGift[dataIdx].Rank - 1];
      this.tmpItem[panelObjectIdx].PlayerNameText.text = this.AGM.mListActGift[dataIdx].Name.ToString();
      this.tmpItem[panelObjectIdx].PlayerNameText.SetAllDirty();
      this.tmpItem[panelObjectIdx].PlayerNameText.cachedTextGenerator.Invalidate();
      this.tmpItem[panelObjectIdx].GiftNameText.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.ItemName);
      this.tmpItem[panelObjectIdx].GiftNameText.SetAllDirty();
      this.tmpItem[panelObjectIdx].GiftNameText.cachedTextGenerator.Invalidate();
      this.tmpItem[panelObjectIdx].ReceiveBtn.m_BtnID2 = dataIdx;
      this.tmpItem[panelObjectIdx].DataIndex = (byte) dataIdx;
    }
    else
    {
      if (panelObjectIdx >= 6)
        return;
      if (!this.bFindScrollp_Buy[panelObjectIdx])
      {
        this.bFindScrollp_Buy[panelObjectIdx] = true;
        Transform transform = item.transform;
        this.tmpItem_Buy[panelObjectIdx].ItemGO = item;
        this.tmpItem_Buy[panelObjectIdx].ScrollItem = transform.GetComponent<ScrollPanelItem>();
        this.tmpItem_Buy[panelObjectIdx].ScrollItem.m_BtnID1 = panelObjectIdx;
        this.tmpItem_Buy[panelObjectIdx].BuyItemBtn = transform.GetChild(1).GetComponent<UIButton>();
        this.tmpItem_Buy[panelObjectIdx].BuyItemBtn.m_Handler = (IUIButtonClickHandler) this;
        this.tmpItem_Buy[panelObjectIdx].BuyItemImage = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        this.tmpItem_Buy[panelObjectIdx].BuyItemImage_F = transform.GetChild(1).GetChild(1).GetComponent<Image>();
        this.tmpItem_Buy[panelObjectIdx].BuyBtn = transform.GetChild(2).GetComponent<UIButton>();
        this.tmpItem_Buy[panelObjectIdx].BuyBtn.m_Handler = (IUIButtonClickHandler) this;
        this.tmpItem_Buy[panelObjectIdx].PriceText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
        this.tmpItem_Buy[panelObjectIdx].BuyText = transform.GetChild(2).GetChild(1).GetComponent<UIText>();
        this.tmpItem_Buy[panelObjectIdx].ThirdPartyImage = transform.GetChild(2).GetChild(2).GetComponent<Image>();
        this.tmpItem_Buy[panelObjectIdx].Price_ThirdPartyText = transform.GetChild(2).GetChild(3).GetComponent<UIText>();
        this.tmpItem_Buy[panelObjectIdx].GiftNameText = transform.GetChild(3).GetComponent<UIText>();
        this.tmpItem_Buy[panelObjectIdx].GiftInfoText = transform.GetChild(4).GetComponent<UIText>();
      }
      if (dataIdx < 0 || dataIdx > this.tmplist_Buy.Count)
        return;
      FastivalSpecialData recordByKey = DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Buy_Data[dataIdx]);
      this.tmpItem_Buy[panelObjectIdx].BuyItemImage_F.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Item, (byte) recordByKey.FrameColor);
      this.tmpItem_Buy[panelObjectIdx].BuyItemImage.sprite = this.GUIM.m_ItemIconSpriteAsset.LoadSprite(recordByKey.PicNo);
      uint storeId = recordByKey.StoreID;
      if (this.bThirdParty)
        this.SetPrice(this.tmpItem_Buy[panelObjectIdx].Price_ThirdPartyText, this.Cstr_Price[panelObjectIdx], storeId);
      else
        this.SetPrice(this.tmpItem_Buy[panelObjectIdx].PriceText, this.Cstr_Price[panelObjectIdx], storeId);
      this.tmpItem_Buy[panelObjectIdx].GiftNameText.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.ItemName);
      this.tmpItem_Buy[panelObjectIdx].GiftNameText.SetAllDirty();
      this.tmpItem_Buy[panelObjectIdx].GiftNameText.cachedTextGenerator.Invalidate();
      this.tmpItem_Buy[panelObjectIdx].GiftInfoText.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.ItemHint);
      this.tmpItem_Buy[panelObjectIdx].GiftInfoText.SetAllDirty();
      this.tmpItem_Buy[panelObjectIdx].GiftInfoText.cachedTextGenerator.Invalidate();
      this.tmpItem_Buy[panelObjectIdx].BuyItemBtn.m_BtnID2 = (int) recordByKey.ItemID;
      this.tmpItem_Buy[panelObjectIdx].BuyBtn.m_BtnID2 = dataIdx;
      this.tmpItem_Buy[panelObjectIdx].DataIndex = (byte) dataIdx;
    }
  }

  public void SetPrice(UIText PriceText, CString PriceStr, uint TreasureID)
  {
    if ((Object) PriceText == (Object) null)
      return;
    TreasureID = MallManager.Instance.TreasureIDTransToNew(TreasureID);
    PriceStr.Length = 0;
    string paltformPriceById = MallManager.Instance.GetProductPaltformPriceByID((int) TreasureID);
    string productPriceById = MallManager.Instance.GetProductPriceByID((int) TreasureID);
    if (paltformPriceById != null && paltformPriceById != string.Empty)
    {
      PriceStr.Append(paltformPriceById);
    }
    else
    {
      if (productPriceById == null)
      {
        double f = 0.0;
        this.NeedUpDate = true;
        PriceStr.DoubleToFormat(f, 2);
      }
      else
        PriceStr.StringToFormat(productPriceById);
      string currency = MallManager.Instance.GetCurrency((int) TreasureID);
      if (currency != null)
      {
        PriceStr.StringToFormat(currency);
        if (MallManager.Instance.bChangePosCurrency(currency))
          PriceStr.AppendFormat("{0} {1}");
        else
          PriceStr.AppendFormat("{1} {0}");
      }
      else
        PriceStr.AppendFormat("${0}");
    }
    PriceText.text = PriceStr.ToString();
    PriceText.SetAllDirty();
    PriceText.cachedTextGenerator.Invalidate();
  }

  public void UpDateItemNum(byte Idx)
  {
    for (int index = 0; index < 6; ++index)
    {
      if (this.bFindScrollp[index] && (int) this.tmpItem[index].DataIndex < this.AGM.mListActGift.Count)
      {
        if (this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].Num <= (byte) 5)
          ((Graphic) this.tmpItem[index].NumText).color = this.text_Red;
        else
          ((Graphic) this.tmpItem[index].NumText).color = this.text_Green;
        this.Cstr_GiftNum[index].ClearString();
        this.Cstr_GiftNum[index].IntToFormat((long) this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].Num, bNumber: true);
        this.Cstr_GiftNum[index].AppendFormat(this.DM.mStringTable.GetStringByID(11190U));
        this.tmpItem[index].NumText.text = this.Cstr_GiftNum[index].ToString();
        this.tmpItem[index].NumText.SetAllDirty();
        this.tmpItem[index].NumText.cachedTextGenerator.Invalidate();
      }
    }
  }

  public void UpDateItemStatus(byte Idx)
  {
    for (int index = 0; index < 6; ++index)
    {
      if (this.bFindScrollp[index] && this.tmpItem[index].ItemGO.activeInHierarchy && (int) this.tmpItem[index].DataIndex < this.AGM.mListActGift.Count && (int) Idx == (int) this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].serverIndex)
      {
        if (this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].Status == (byte) 0)
        {
          ((Component) this.tmpItem[index].ReceiveBtn).gameObject.SetActive(true);
          ((Component) this.tmpItem[index].ReceiveImage).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.tmpItem[index].ReceiveBtn).gameObject.SetActive(false);
          ((Component) this.tmpItem[index].ReceiveImage).gameObject.SetActive(true);
        }
      }
    }
  }

  public void UpdateItemPrice()
  {
    uint TreasureID = 0;
    for (int index = 0; index < 6; ++index)
    {
      if (this.bFindScrollp_Buy[index] && this.tmpItem_Buy[index].ItemGO.activeInHierarchy)
      {
        if (this.bThirdParty)
          this.SetPrice(this.tmpItem_Buy[index].PriceText, this.Cstr_Price[index], TreasureID);
        else
          this.SetPrice(this.tmpItem_Buy[index].Price_ThirdPartyText, this.Cstr_Price[index], TreasureID);
      }
    }
  }

  public void MainGiftBtnCheck()
  {
    if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityManager.Instance.ServerEventTime - this.AGM.ActivityGiftBeginTime >= 0L)
    {
      if (this.DM.RoleAlliance.Rank == AllianceRank.RANK5)
      {
        ((Component) this.btn_MainGift).gameObject.SetActive(true);
        ((Component) this.Img_MainGife).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.btn_MainGift).gameObject.SetActive(false);
        ((Component) this.Img_MainGife).gameObject.SetActive(true);
      }
      if ((Object) this.text_MainGiftReSetTime != (Object) null)
        ((Component) this.text_MainGiftReSetTime).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.btn_MainGift).gameObject.SetActive(false);
      ((Component) this.Img_MainGife).gameObject.SetActive(false);
      if ((Object) this.text_MainGiftReSetTime != (Object) null)
        ((Component) this.text_MainGiftReSetTime).gameObject.SetActive(false);
    }
    if (this.AGM.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
    {
      this.text_MainGiftGive.text = this.DM.mStringTable.GetStringByID(11187U);
      this.text_MainGiftGive_Meber.text = this.DM.mStringTable.GetStringByID(11204U);
      ((Graphic) this.text_MainGiftGive).color = Color.white;
      ((Graphic) this.text_MainGiftGive_Meber).color = this.text_Gray;
      this.uToolMainGift.enabled = true;
    }
    else
    {
      this.text_MainGiftGive.text = this.DM.mStringTable.GetStringByID(11188U);
      this.text_MainGiftGive_Meber.text = this.DM.mStringTable.GetStringByID(11188U);
      ((Graphic) this.text_MainGiftGive).color = this.text_Gray;
      ((Graphic) this.text_MainGiftGive_Meber).color = this.text_Meber;
      this.uToolMainGift.enabled = false;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.tmplist.Clear();
        for (int index = 0; index < this.AGM.mListActGift.Count; ++index)
          this.tmplist.Add(137f);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.ScrollPanelCheck();
        break;
      case 2:
        this.UpDateItemNum((byte) arg2);
        break;
      case 3:
        this.UpDateItemStatus((byte) arg2);
        break;
      case 4:
        this.MainGiftBtnCheck();
        if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
        {
          ((Component) this.Img_GiftNum).gameObject.SetActive(true);
          ((Component) this.Img_MainGiftNum).gameObject.SetActive(true);
          ((Component) this.text_GiftNum).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.Img_MainGiftNum).gameObject.SetActive(false);
          if (this.AGM.EnableRedPocketNum > (byte) 0)
          {
            ((Component) this.text_GiftNum).gameObject.SetActive(true);
            ((Component) this.Img_GiftNum).gameObject.SetActive(true);
          }
          else
          {
            ((Component) this.text_GiftNum).gameObject.SetActive(false);
            ((Component) this.Img_GiftNum).gameObject.SetActive(false);
          }
        }
        if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime < 0L)
        {
          ((Component) this.Img_NoGiftBuy).gameObject.SetActive(true);
          this.m_ScrollPanel_Buy.gameObject.SetActive(false);
          this.IsActTime = false;
          ((Component) this.text_Close[0]).gameObject.SetActive(false);
          ((Component) this.text_Close[1]).gameObject.SetActive(false);
          ((Component) this.text_Close[2]).gameObject.SetActive(true);
          this.Img_ActTime.sprite = this.SArray.m_Sprites[6];
        }
        else
        {
          ((Component) this.Img_NoGiftBuy).gameObject.SetActive(false);
          this.m_ScrollPanel_Buy.gameObject.SetActive(true);
          ((Component) this.text_Close[0]).gameObject.SetActive(true);
          ((Component) this.text_Close[1]).gameObject.SetActive(true);
          ((Component) this.text_Close[2]).gameObject.SetActive(false);
          this.Img_ActTime.sprite = this.SArray.m_Sprites[5];
          this.Cstr_ActivityCDTime.ClearString();
          if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 86400L)
          {
            this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 86400L);
            this.Cstr_ActivityCDTime.AppendFormat("{0}d");
          }
          else if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime >= 0L)
          {
            this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2);
            this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2);
            this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 60L, 2);
            this.Cstr_ActivityCDTime.AppendFormat("{0}:{1}:{2}");
          }
          else
            this.Cstr_ActivityCDTime.AppendFormat("00:00:00");
          this.text_Close[1].text = this.Cstr_ActivityCDTime.ToString();
          this.text_Close[1].SetAllDirty();
          this.text_Close[1].cachedTextGenerator.Invalidate();
        }
        if ((int) this.mPackID == (int) this.AGM.GroupID || this.AGM.GroupID == (byte) 0)
          break;
        this.mPackID = this.AGM.GroupID;
        for (int index = 0; index < 2; ++index)
        {
          this.GUIM.SetFastivalImage(this.mPackID, (ushort) 2, this.Img_PageIcon[index]);
          this.Img_PageIcon[index].SetNativeSize();
        }
        this.GUIM.SetFastivalImage(this.mPackID, (ushort) 1, this.Img_MainGifeIcon);
        this.Img_MainGifeIcon.SetNativeSize();
        for (int index = 0; index < 6; ++index)
        {
          if (this.bFindScrollp[index])
          {
            this.GUIM.SetFastivalImage(this.mPackID, (ushort) 3, this.tmpItem[index].NumImage);
            this.tmpItem[index].NumImage.SetNativeSize();
          }
        }
        break;
      case 5:
        this.SetPage((byte) 0);
        this.tmplist.Clear();
        for (int index = 0; index < this.AGM.mListActGift.Count; ++index)
          this.tmplist.Add(137f);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.ScrollPanelCheck();
        break;
      case 6:
        this.text_GiftNum.text = this.AGM.EnableRedPocketNum.ToString();
        this.text_GiftNum.SetAllDirty();
        this.text_GiftNum.cachedTextGenerator.Invalidate();
        this.text_GiftNum.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.Img_GiftNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_GiftNum.preferredWidth), ((Graphic) this.Img_GiftNum).rectTransform.sizeDelta.y);
        if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
        {
          ((Component) this.Img_GiftNum).gameObject.SetActive(true);
          ((Component) this.Img_MainGiftNum).gameObject.SetActive(true);
          ((Component) this.text_GiftNum).gameObject.SetActive(false);
          break;
        }
        ((Component) this.Img_MainGiftNum).gameObject.SetActive(false);
        if (this.AGM.EnableRedPocketNum > (byte) 0)
        {
          ((Component) this.text_GiftNum).gameObject.SetActive(true);
          ((Component) this.Img_GiftNum).gameObject.SetActive(true);
          break;
        }
        ((Component) this.text_GiftNum).gameObject.SetActive(false);
        ((Component) this.Img_GiftNum).gameObject.SetActive(false);
        break;
      case 7:
        if (!((Object) this.m_Mask != (Object) null))
          break;
        this.m_Mask.StopMovement();
        break;
      case 10:
        if (!((Object) this.door != (Object) null) || this.DM.RoleAlliance.Id != 0U)
          break;
        this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_ActivityGift);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_ActivityGift);
          break;
        }
        this.tmplist.Clear();
        for (int index = 0; index < this.AGM.mListActGift.Count; ++index)
          this.tmplist.Add(137f);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.ScrollPanelCheck();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Info != (Object) null && ((Behaviour) this.text_Info).enabled)
    {
      ((Behaviour) this.text_Info).enabled = false;
      ((Behaviour) this.text_Info).enabled = true;
    }
    if ((Object) this.text_MainGiftGive != (Object) null && ((Behaviour) this.text_MainGiftGive).enabled)
    {
      ((Behaviour) this.text_MainGiftGive).enabled = false;
      ((Behaviour) this.text_MainGiftGive).enabled = true;
    }
    if ((Object) this.text_MainGiftReSetTime != (Object) null && ((Behaviour) this.text_MainGiftReSetTime).enabled)
    {
      ((Behaviour) this.text_MainGiftReSetTime).enabled = false;
      ((Behaviour) this.text_MainGiftReSetTime).enabled = true;
    }
    if ((Object) this.text_NoGiftGet != (Object) null && ((Behaviour) this.text_NoGiftGet).enabled)
    {
      ((Behaviour) this.text_NoGiftGet).enabled = false;
      ((Behaviour) this.text_NoGiftGet).enabled = true;
    }
    if ((Object) this.text_NoGiftBuy != (Object) null && ((Behaviour) this.text_NoGiftBuy).enabled)
    {
      ((Behaviour) this.text_NoGiftBuy).enabled = false;
      ((Behaviour) this.text_NoGiftBuy).enabled = true;
    }
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_GiftNum != (Object) null && ((Behaviour) this.text_GiftNum).enabled)
    {
      ((Behaviour) this.text_GiftNum).enabled = false;
      ((Behaviour) this.text_GiftNum).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_MainGiftInfo[index] != (Object) null && ((Behaviour) this.text_MainGiftInfo[index]).enabled)
      {
        ((Behaviour) this.text_MainGiftInfo[index]).enabled = false;
        ((Behaviour) this.text_MainGiftInfo[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_Close[index] != (Object) null && ((Behaviour) this.text_Close[index]).enabled)
      {
        ((Behaviour) this.text_Close[index]).enabled = false;
        ((Behaviour) this.text_Close[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if (this.bFindScrollp[index])
      {
        if ((Object) this.tmpItem[index].ReceiveBtnText != (Object) null && ((Behaviour) this.tmpItem[index].ReceiveBtnText).enabled)
        {
          ((Behaviour) this.tmpItem[index].ReceiveBtnText).enabled = false;
          ((Behaviour) this.tmpItem[index].ReceiveBtnText).enabled = true;
        }
        if ((Object) this.tmpItem[index].ReceiveImgText != (Object) null && ((Behaviour) this.tmpItem[index].ReceiveImgText).enabled)
        {
          ((Behaviour) this.tmpItem[index].ReceiveImgText).enabled = false;
          ((Behaviour) this.tmpItem[index].ReceiveImgText).enabled = true;
        }
        if ((Object) this.tmpItem[index].NumText != (Object) null && ((Behaviour) this.tmpItem[index].NumText).enabled)
        {
          ((Behaviour) this.tmpItem[index].NumText).enabled = false;
          ((Behaviour) this.tmpItem[index].NumText).enabled = true;
        }
        if ((Object) this.tmpItem[index].CDTimeText != (Object) null && ((Behaviour) this.tmpItem[index].CDTimeText).enabled)
        {
          ((Behaviour) this.tmpItem[index].CDTimeText).enabled = false;
          ((Behaviour) this.tmpItem[index].CDTimeText).enabled = true;
        }
        if ((Object) this.tmpItem[index].PlayerNameText != (Object) null && ((Behaviour) this.tmpItem[index].PlayerNameText).enabled)
        {
          ((Behaviour) this.tmpItem[index].PlayerNameText).enabled = false;
          ((Behaviour) this.tmpItem[index].PlayerNameText).enabled = true;
        }
        if ((Object) this.tmpItem[index].GiftNameText != (Object) null && ((Behaviour) this.tmpItem[index].GiftNameText).enabled)
        {
          ((Behaviour) this.tmpItem[index].GiftNameText).enabled = false;
          ((Behaviour) this.tmpItem[index].GiftNameText).enabled = true;
        }
      }
      if (this.bFindScrollp_Buy[index])
      {
        if ((Object) this.tmpItem_Buy[index].PriceText != (Object) null && ((Behaviour) this.tmpItem_Buy[index].PriceText).enabled)
        {
          ((Behaviour) this.tmpItem_Buy[index].PriceText).enabled = false;
          ((Behaviour) this.tmpItem_Buy[index].PriceText).enabled = true;
        }
        if ((Object) this.tmpItem_Buy[index].BuyText != (Object) null && ((Behaviour) this.tmpItem_Buy[index].BuyText).enabled)
        {
          ((Behaviour) this.tmpItem_Buy[index].BuyText).enabled = false;
          ((Behaviour) this.tmpItem_Buy[index].BuyText).enabled = true;
        }
        if ((Object) this.tmpItem_Buy[index].Price_ThirdPartyText != (Object) null && ((Behaviour) this.tmpItem_Buy[index].Price_ThirdPartyText).enabled)
        {
          ((Behaviour) this.tmpItem_Buy[index].Price_ThirdPartyText).enabled = false;
          ((Behaviour) this.tmpItem_Buy[index].Price_ThirdPartyText).enabled = true;
        }
        if ((Object) this.tmpItem_Buy[index].GiftNameText != (Object) null && ((Behaviour) this.tmpItem_Buy[index].GiftNameText).enabled)
        {
          ((Behaviour) this.tmpItem_Buy[index].GiftNameText).enabled = false;
          ((Behaviour) this.tmpItem_Buy[index].GiftNameText).enabled = true;
        }
        if ((Object) this.tmpItem_Buy[index].GiftInfoText != (Object) null && ((Behaviour) this.tmpItem_Buy[index].GiftInfoText).enabled)
        {
          ((Behaviour) this.tmpItem_Buy[index].GiftInfoText).enabled = false;
          ((Behaviour) this.tmpItem_Buy[index].GiftInfoText).enabled = true;
        }
      }
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if ((double) this.tmpSendTime >= 0.0)
    {
      this.tmpSendTime += Time.smoothDeltaTime;
      if ((double) this.tmpSendTime >= 0.30000001192092896)
        this.tmpSendTime = -1f;
    }
    if ((Object) this.Img_MainGifeLight != (Object) null)
      ((Component) this.Img_MainGifeLight).transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if (!bOnSecond)
      return;
    if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
    {
      this.NeedUpDate = false;
      this.UpdateItemPrice();
    }
    if (this.IsActTime && this.AGM.ActivityGiftEndTime <= ActivityManager.Instance.ServerEventTime)
    {
      this.IsActTime = false;
      ((Component) this.text_Close[0]).gameObject.SetActive(false);
      ((Component) this.text_Close[1]).gameObject.SetActive(false);
      ((Component) this.text_Close[2]).gameObject.SetActive(true);
      this.Img_ActTime.sprite = this.SArray.m_Sprites[6];
    }
    if ((Object) this.text_Close[1] != (Object) null && ((Component) this.text_Close[1]).gameObject.activeSelf)
    {
      this.Cstr_ActivityCDTime.ClearString();
      if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 86400L)
      {
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 86400L);
        this.Cstr_ActivityCDTime.AppendFormat("{0}d");
      }
      else if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime >= 0L)
      {
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2);
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2);
        this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 60L, 2);
        this.Cstr_ActivityCDTime.AppendFormat("{0}:{1}:{2}");
      }
      else
        this.Cstr_ActivityCDTime.AppendFormat("00:00:00");
      this.text_Close[1].text = this.Cstr_ActivityCDTime.ToString();
      this.text_Close[1].SetAllDirty();
      this.text_Close[1].cachedTextGenerator.Invalidate();
    }
    for (int index = 0; index < 6; ++index)
    {
      if (this.bFindScrollp[index] && (int) this.tmpItem[index].DataIndex < this.AGM.mListActGift.Count)
      {
        this.Cstr_GiftCDTime[index].ClearString();
        if (this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime >= 0L)
        {
          this.Cstr_GiftCDTime[index].IntToFormat((this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2);
          this.Cstr_GiftCDTime[index].IntToFormat((this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2);
          this.Cstr_GiftCDTime[index].IntToFormat((this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime) % 60L, 2);
          this.Cstr_GiftCDTime[index].AppendFormat("{0}:{1}:{2}");
        }
        else
        {
          this.Cstr_GiftCDTime[index].IntToFormat(0L, 2);
          this.Cstr_GiftCDTime[index].IntToFormat(0L, 2);
          this.Cstr_GiftCDTime[index].IntToFormat(0L, 2);
          this.Cstr_GiftCDTime[index].AppendFormat("{0}:{1}:{2}");
          if (!this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].CDtime)
          {
            this.AGM.SendDataReset(this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].serverIndex);
            this.AGM.mListActGift[(int) this.tmpItem[index].DataIndex].CDtime = true;
          }
        }
        this.tmpItem[index].CDTimeText.text = this.Cstr_GiftCDTime[index].ToString();
        this.tmpItem[index].CDTimeText.SetAllDirty();
        this.tmpItem[index].CDTimeText.cachedTextGenerator.Invalidate();
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
