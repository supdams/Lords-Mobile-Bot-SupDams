// Decompiled with JetBrains decompiler
// Type: UIAlliance_Info
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Info : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform PageT;
  private Transform BadgeT;
  private Transform[] Pagedata = new Transform[3];
  private Transform[] ItemPT1 = new Transform[6];
  private Transform[] ItemPT2 = new Transform[6];
  private Transform[] ItemPT_W1 = new Transform[6];
  private Transform[] ItemPT_W2 = new Transform[6];
  private Transform ItemT;
  private RectTransform btnHelp_RT;
  private RectTransform mContentRT;
  private RectTransform[] btn_RT = new RectTransform[5];
  private RectTransform[] PageImg_RT = new RectTransform[3];
  private RectTransform[] PageText_RT = new RectTransform[3];
  private RectTransform[] btnApplicationNum_RT = new RectTransform[2];
  private RectTransform[] btnGiftNum_RT = new RectTransform[2];
  private RectTransform[] btnMessageNum_RT = new RectTransform[2];
  private RectTransform[] TranslationRT = new RectTransform[6];
  private RectTransform m_TranslationRT;
  private RectTransform[] btn_ItemRT = new RectTransform[5];
  private UIButton btn_EXIT;
  private UIButton[] btnPage = new UIButton[3];
  private UIButton btn_Letter;
  private UIButton btn_Member;
  private UIButton btn_Application;
  private UIButton btn_Gift;
  private UIButton[] btn_InputField = new UIButton[6];
  private UIButton[][] btn_Fun = new UIButton[6][];
  private UIButton[] btn_Item = new UIButton[6];
  private UIButton[] btn_Translation = new UIButton[6];
  private UIButton m_btn_Translation;
  private UIButton btn_Input_OK;
  private UIButton btn_Input_C;
  private UIButton btn_Input_Edit;
  private UIButton btn_Help;
  private UIButton btn_Transport;
  private UIButton btn_Reinforce;
  private UIButton btn_Cantonment;
  private UIButton[] btn_ItemInput = new UIButton[6];
  private UIButton[] btn_ItemHint = new UIButton[6];
  private UIButtonHint[] mbtnH_Item = new UIButtonHint[6];
  private UIButton btn_KHint;
  private UIButton btn_ActivityGift;
  private Image tmpImg;
  private Image img_InputBG;
  private Image[] img_PageBG = new Image[3];
  private Image[][] img_Wonders = new Image[6][];
  private Image[] img_ItemHint = new Image[6];
  private Image img_KHint;
  private Image[] Img_Translate = new Image[6];
  private Image m_Img_Translate;
  private Image[] img_ActivityGift = new Image[2];
  private UIRunningText img_text;
  private UIText tmptext;
  private UIText text_Title;
  private UIText text_Alliance_K;
  private UIText text_Propaganda;
  private UIText text_AllianceName;
  private UIText text_AllianceChief;
  private UIText text_AllianceStrength;
  private UIText text_AllianceMember;
  private UIText text_InputCheck;
  private UIText[] text_PageNum = new UIText[3];
  private UIText text_btnApplicationNum;
  private UIText[] text_btnGife = new UIText[2];
  private UIText text_Input1;
  private UIText text_Alliance_Money;
  private UIText text_HelpNum;
  private UIText text_MessageNum;
  private UIText[][] text_ItembtnName = new UIText[6][];
  private UIText[] text_tmpStr = new UIText[10];
  private UIText[][] text_ItemName = new UIText[6][];
  private UIText[] text_ItemCDtime = new UIText[6];
  private UIText[] text_Item_K = new UIText[6];
  private UIText[][] text_ItemEffect = new UIText[6][];
  private UIText[] text_Item_Hint = new UIText[6];
  private UIText[] text_tmpItmeStr = new UIText[11];
  private UIText[] text_tmpItmeP2Str = new UIText[15];
  private UIText[] text_Trans = new UIText[6];
  private UIText[] text_Translation = new UIText[6];
  private UIText m_text_Trans;
  private UIText m_text_Translation;
  private UIText m_text_ActivityGiftNum;
  private UIEmojiInput mInput;
  private UIEmojiInput[] mItemInput = new UIEmojiInput[6];
  private CString Cstr_Alliance_K;
  private CString Cstr_AllianceName;
  private CString Cstr_AllianceChief;
  private CString Cstr_AllianceStrength;
  private CString Cstr_AllianceMember;
  private CString Cstr_GifeLV;
  private CString Cstr_Alliance_Money;
  private CString Cstr_Null;
  private CString[] Cstr_Item_K = new CString[6];
  private CString[] Cstr_Item_Time = new CString[6];
  private CString[][] Cstr_ItemEffect = new CString[6][];
  private CString Cstr_Translation;
  private DataManager DM;
  private GUIManager GUIM;
  private UISpritesArray SArray;
  private Font TTFont;
  private Door door;
  private Material FrameMaterial;
  private GameObject go;
  private bool bshowbtn1;
  private bool bcheckInput;
  private int mNowPage = 3;
  private Vector2[] btn_Pos = new Vector2[5];
  private float PageBGTime;
  private UIAlliance_Marshal MarshalInst;
  private ScrollPanel m_ScrollPanel;
  private CScrollRect m_ScrollRect;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];
  private List<float> tmplist = new List<float>();
  private float tmpHeight;
  private bool bShowTranslate;
  private float tmpTransH;
  public int[] mWonderEffect = new int[7];

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    if (this.DM.RoleAlliance.Id == 0U)
    {
      this.door.CloseMenu();
    }
    else
    {
      this.ResetEffectText();
      this.FrameMaterial = this.GUIM.GetFrameMaterial();
      this.Cstr_Alliance_K = StringManager.Instance.SpawnString();
      this.Cstr_AllianceName = StringManager.Instance.SpawnString();
      this.Cstr_AllianceChief = StringManager.Instance.SpawnString();
      this.Cstr_AllianceStrength = StringManager.Instance.SpawnString();
      this.Cstr_AllianceMember = StringManager.Instance.SpawnString();
      this.Cstr_GifeLV = StringManager.Instance.SpawnString();
      this.Cstr_Alliance_Money = StringManager.Instance.SpawnString();
      this.Cstr_Null = StringManager.Instance.SpawnString();
      this.Cstr_Translation = StringManager.Instance.SpawnString(100);
      for (int index1 = 0; index1 < 6; ++index1)
      {
        this.Cstr_Item_K[index1] = StringManager.Instance.SpawnString();
        this.Cstr_Item_Time[index1] = StringManager.Instance.SpawnString();
        this.Cstr_ItemEffect[index1] = new CString[4];
        for (int index2 = 0; index2 < 4; ++index2)
          this.Cstr_ItemEffect[index1][index2] = StringManager.Instance.SpawnString(100);
      }
      for (int index = 0; index < 3; ++index)
      {
        this.Tmp = this.GameT.GetChild(1 + index);
        this.btnPage[index] = this.Tmp.GetComponent<UIButton>();
        this.btnPage[index].m_Handler = (IUIButtonClickHandler) this;
        this.btnPage[index].m_BtnID1 = 1 + index;
        this.Tmp = this.GameT.GetChild(1 + index).GetChild(0);
        this.img_PageBG[index] = this.Tmp.GetComponent<Image>();
        this.Tmp = this.GameT.GetChild(1 + index).GetChild(1);
        this.tmpImg = this.GameT.GetChild(1 + index).GetChild(2).GetComponent<Image>();
        this.PageImg_RT[index] = this.GameT.GetChild(1 + index).GetChild(2).GetComponent<RectTransform>();
        this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
        ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
        this.Tmp = this.GameT.GetChild(1 + index).GetChild(2).GetChild(0);
        this.PageText_RT[index] = this.Tmp.GetComponent<RectTransform>();
        this.text_PageNum[index] = this.Tmp.GetComponent<UIText>();
        this.text_PageNum[index].font = this.TTFont;
        ((Component) this.PageImg_RT[index]).gameObject.SetActive(false);
      }
      int giftNum = (int) this.DM.RoleAlliance.GiftNum;
      long num1 = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
      if (num1 > 0L)
        giftNum += num1 <= 20L ? (int) num1 : 20;
      if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        giftNum += (int) this.DM.RoleAlliance.Applicant;
      if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > (byte) 0)
        giftNum += (int) ActivityGiftManager.Instance.EnableRedPocketNum;
      if (giftNum > 0)
      {
        this.text_PageNum[0].text = giftNum.ToString();
        ((Component) this.PageImg_RT[0]).gameObject.SetActive(true);
        this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
      }
      int num2 = (int) this.DM.ActiveRallyRecNum + (int) this.DM.BeingRallyRecNum;
      if (num2 > 0)
      {
        this.text_PageNum[1].text = num2.ToString();
        this.text_PageNum[1].SetAllDirty();
        this.text_PageNum[1].cachedTextGenerator.Invalidate();
        this.text_PageNum[1].cachedTextGeneratorForLayout.Invalidate();
        ((Component) this.PageImg_RT[1]).gameObject.SetActive(true);
        this.PageImg_RT[1].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[1].preferredWidth), this.PageImg_RT[1].sizeDelta.y);
      }
      if (this.DM.mHelpDataList.Count > 0)
      {
        this.text_PageNum[2].text = this.DM.mHelpDataList.Count.ToString();
        ((Component) this.PageImg_RT[2]).gameObject.SetActive(true);
        this.PageImg_RT[2].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[2].preferredWidth), this.PageImg_RT[2].sizeDelta.y);
      }
      this.PageT = this.GameT.GetChild(4);
      this.Tmp = this.GameT.GetChild(6).GetChild(0);
      this.text_Title = this.Tmp.GetComponent<UIText>();
      this.text_Title.font = this.TTFont;
      this.Tmp1 = this.GameT.GetChild(7);
      this.btn_ActivityGift = this.Tmp1.GetComponent<UIButton>();
      this.GUIM.SetFastivalImage(ActivityGiftManager.Instance.GroupID, (ushort) 4, this.btn_ActivityGift.image);
      this.btn_ActivityGift.image.SetNativeSize();
      this.btn_ActivityGift.image.type = (Image.Type) 0;
      this.btn_ActivityGift.m_Handler = (IUIButtonClickHandler) this;
      this.btn_ActivityGift.m_BtnID1 = 30;
      this.btn_ActivityGift.m_EffectType = e_EffectType.e_Scale;
      this.btn_ActivityGift.transition = (Selectable.Transition) 0;
      this.img_ActivityGift[0] = this.Tmp1.GetChild(0).GetComponent<Image>();
      this.img_ActivityGift[1] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
      ((Component) this.img_ActivityGift[0]).gameObject.SetActive(true);
      ((Component) this.img_ActivityGift[1]).gameObject.SetActive(true);
      ((Graphic) this.img_ActivityGift[0]).rectTransform.anchoredPosition = new Vector2(27f, 7f);
      this.img_ActivityGift[1].sprite = this.door.LoadSprite("UI_main_mess_ex_dark");
      ((MaskableGraphic) this.img_ActivityGift[1]).material = this.door.LoadMaterial();
      this.tmpImg = this.Tmp1.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_mess_ex_light");
      ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
      this.m_text_ActivityGiftNum = this.Tmp1.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.m_text_ActivityGiftNum.font = this.TTFont;
      this.m_text_ActivityGiftNum.text = ActivityGiftManager.Instance.EnableRedPocketNum.ToString();
      this.m_text_ActivityGiftNum.SetAllDirty();
      this.m_text_ActivityGiftNum.cachedTextGenerator.Invalidate();
      ((Graphic) this.img_ActivityGift[0]).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_text_ActivityGiftNum.preferredWidth), ((Graphic) this.img_ActivityGift[0]).rectTransform.sizeDelta.y);
      if (arg1 == 0)
        arg1 = (int) this.DM.mOpenPage;
      if (arg1 >= 0 && arg1 <= 2)
        this.SetPage(arg1);
      this.Tmp = this.GameT.GetChild(5);
      this.img_InputBG = this.Tmp.GetComponent<Image>();
      if (this.GUIM.bOpenOnIPhoneX)
      {
        ((Graphic) this.img_InputBG).rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
        ((Graphic) this.img_InputBG).rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
      }
      this.btn_Input_Edit = this.Tmp.GetChild(0).GetComponent<UIButton>();
      this.btn_Input_Edit.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Input_Edit.m_BtnID1 = 23;
      this.text_InputCheck = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_InputCheck.font = this.TTFont;
      this.text_InputCheck.SetCheckArabic(true);
      this.btn_Input_OK = this.Tmp.GetChild(2).GetComponent<UIButton>();
      this.btn_Input_OK.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Input_OK.m_BtnID1 = 21;
      this.btn_Input_OK.m_EffectType = e_EffectType.e_Scale;
      this.btn_Input_OK.transition = (Selectable.Transition) 0;
      this.text_tmpStr[0] = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[0].font = this.TTFont;
      this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(512U);
      this.btn_Input_C = this.Tmp.GetChild(3).GetComponent<UIButton>();
      this.btn_Input_C.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Input_C.m_BtnID1 = 22;
      this.btn_Input_C.m_EffectType = e_EffectType.e_Scale;
      this.btn_Input_C.transition = (Selectable.Transition) 0;
      this.text_tmpStr[1] = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[1].font = this.TTFont;
      this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(513U);
      this.text_tmpStr[2] = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[2].font = this.TTFont;
      this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(774U);
      this.Tmp = this.GameT.GetChild(6).GetChild(0);
      this.text_Title = this.Tmp.GetComponent<UIText>();
      this.text_Title.font = this.TTFont;
      this.tmpImg = this.GameT.GetChild(8).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) this.tmpImg).enabled = false;
      this.btn_EXIT = this.GameT.GetChild(8).GetChild(0).GetComponent<UIButton>();
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 0;
      this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
      ((MaskableGraphic) this.btn_EXIT.image).material = this.door.LoadMaterial();
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    }
  }

  public void ResetEffectText()
  {
    for (int index = 0; index < 7; ++index)
      this.mWonderEffect[index] = -1;
    for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
    {
      if (this.DM.m_Wonders[index].WonderID >= (byte) 0 && this.DM.m_Wonders[index].WonderID < (byte) 7 && this.mWonderEffect[(int) this.DM.m_Wonders[index].WonderID] == -1)
        this.mWonderEffect[(int) this.DM.m_Wonders[index].WonderID] = (int) (byte) index;
    }
  }

  public void ChangText(string ID)
  {
    this.text_InputCheck.text = ID;
    this.text_InputCheck.SetAllDirty();
    this.text_InputCheck.cachedTextGenerator.Invalidate();
    this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
    this.mInput.text = StringManager.InputTemp;
    this.mInput.text = ID;
    this.OpenInputCheck(true);
    this.bcheckInput = true;
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    if (Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString()) > 480)
      return char.MinValue;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.Append(text);
    cstring.Append(check.ToString());
    this.text_InputCheck.text = cstring.ToString();
    this.text_InputCheck.SetAllDirty();
    this.text_InputCheck.cachedTextGenerator.Invalidate();
    this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
    return (double) this.text_InputCheck.preferredHeight > 156.0 ? char.MinValue : check;
  }

  public override void OnClose()
  {
    if (this.Cstr_Alliance_K != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Alliance_K);
    if (this.Cstr_AllianceName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceName);
    if (this.Cstr_AllianceChief != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceChief);
    if (this.Cstr_AllianceStrength != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceStrength);
    if (this.Cstr_AllianceMember != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceMember);
    if (this.Cstr_GifeLV != null)
      StringManager.Instance.DeSpawnString(this.Cstr_GifeLV);
    if (this.Cstr_Alliance_Money != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Alliance_Money);
    if (this.Cstr_Null != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Null);
    if (this.Cstr_Translation != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Translation);
    for (int index1 = 0; index1 < 6; ++index1)
    {
      if (this.Cstr_Item_K[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Item_K[index1]);
      if (this.Cstr_Item_Time[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Item_Time[index1]);
      if (this.Cstr_ItemEffect[index1] != null)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          if (this.Cstr_ItemEffect[index1][index2] != null)
            StringManager.Instance.DeSpawnString(this.Cstr_ItemEffect[index1][index2]);
        }
      }
    }
    if (this.MarshalInst != null)
      this.MarshalInst.OnClose();
    if (!((Object) this.Pagedata[0] != (Object) null))
      return;
    this.DM.mAllianceInfoScroll_Y = this.mContentRT.anchoredPosition.y;
    this.DM.mAllianceInfoScroll_Idx = this.m_ScrollPanel.GetTopIdx();
    if (!((Object) this.mInput != (Object) null))
      return;
    ((UnityEventBase) this.mInput.onEndEdit).RemoveAllListeners();
  }

  public void SetPage(int nowpage)
  {
    if (nowpage == this.mNowPage)
      return;
    this.mNowPage = nowpage;
    this.DM.mOpenPage = (byte) nowpage;
    if ((Object) this.Pagedata[this.mNowPage] == (Object) null)
      this.LoadPageData();
    for (int index = 0; index < 3; ++index)
    {
      this.btnPage[index].image.sprite = this.SArray.m_Sprites[1];
      if ((bool) (Object) this.Pagedata[index])
        this.Pagedata[index].gameObject.SetActive(false);
      ((Graphic) this.img_PageBG[index]).color = new Color(1f, 1f, 1f, 0.0f);
    }
    ((Graphic) this.img_PageBG[nowpage]).color = new Color(1f, 1f, 1f, 1f);
    if ((bool) (Object) this.Pagedata[nowpage])
      this.Pagedata[nowpage].gameObject.SetActive(true);
    this.text_Title.text = this.mNowPage != 0 ? (this.mNowPage != 1 ? this.DM.mStringTable.GetStringByID(765U) : this.DM.mStringTable.GetStringByID(768U)) : this.DM.mStringTable.GetStringByID(4624U);
    this.CheckGiftBtnShow();
  }

  public void LoadPageData()
  {
    switch (this.mNowPage)
    {
      case 0:
        this.go = (GameObject) Object.Instantiate(this.m_AssetBundle.Load("UIAlliance_Info_P1"));
        this.Pagedata[0] = this.go.GetComponent<Transform>();
        this.Pagedata[0].SetParent(this.PageT, false);
        this.Tmp = this.Pagedata[0].GetChild(0);
        this.BadgeT = this.Tmp.GetChild(2);
        this.GUIM.InitBadgeTotem(this.BadgeT, this.DM.RoleAlliance.Emblem);
        this.Tmp1 = this.Tmp.GetChild(3).GetChild(0);
        this.text_Propaganda = this.Tmp1.GetComponent<UIText>();
        RectTransform component1 = this.Tmp1.GetComponent<RectTransform>();
        this.text_Propaganda.font = this.TTFont;
        this.text_Propaganda.text = this.DM.RoleAlliance.Header;
        this.Tmp1 = this.Tmp.GetChild(3).GetChild(1);
        this.tmptext = this.Tmp1.GetComponent<UIText>();
        RectTransform component2 = this.Tmp1.GetComponent<RectTransform>();
        this.tmptext.font = this.TTFont;
        this.tmptext.text = this.DM.RoleAlliance.Header;
        this.Tmp1 = this.Tmp.GetChild(3);
        this.img_text = this.Tmp1.GetComponent<UIRunningText>();
        this.img_text.tmpLength = !this.GUIM.IsArabic ? 281f : 562f;
        this.img_text.m_RunningText1 = this.text_Propaganda;
        this.img_text.m_RunRT1 = ((Graphic) this.text_Propaganda).rectTransform;
        this.img_text.m_RunningText2 = this.tmptext;
        this.img_text.m_RunRT2 = ((Graphic) this.tmptext).rectTransform;
        if ((double) this.text_Propaganda.preferredWidth > 281.0)
        {
          component1.sizeDelta = new Vector2(this.text_Propaganda.preferredWidth, component1.sizeDelta.y);
          if (this.GUIM.IsArabic)
            this.text_Propaganda.UpdateArabicPos();
          component2.anchoredPosition = new Vector2(this.text_Propaganda.preferredWidth, component2.anchoredPosition.y);
          component2.sizeDelta = new Vector2(this.text_Propaganda.preferredWidth, component2.sizeDelta.y);
          if (this.GUIM.IsArabic)
            this.tmptext.UpdateArabicPos();
          this.img_text.tmpLength = this.text_Propaganda.preferredWidth;
        }
        if (this.DM.RoleAlliance.Header.Length == 0)
          this.img_text.gameObject.SetActive(false);
        else
          this.img_text.gameObject.SetActive(true);
        this.Tmp1 = this.Tmp.GetChild(4).GetChild(0);
        this.text_AllianceChief = this.Tmp1.GetComponent<UIText>();
        this.text_AllianceChief.font = this.TTFont;
        this.Cstr_AllianceChief.ClearString();
        this.Cstr_AllianceChief.StringToFormat(this.DM.RoleAlliance.Leader);
        this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625U));
        this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
        this.Tmp1 = this.Tmp.GetChild(5).GetChild(0);
        this.text_AllianceStrength = this.Tmp1.GetComponent<UIText>();
        this.text_AllianceStrength.font = this.TTFont;
        this.Cstr_AllianceStrength.ClearString();
        this.Cstr_AllianceStrength.uLongToFormat(this.DM.RoleAlliance.Power, bNumber: true);
        this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626U));
        this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
        this.Tmp1 = this.Tmp.GetChild(6).GetChild(0);
        this.text_AllianceMember = this.Tmp1.GetComponent<UIText>();
        this.text_AllianceMember.font = this.TTFont;
        this.Cstr_AllianceMember.ClearString();
        this.Cstr_AllianceMember.IntToFormat((long) this.DM.RoleAlliance.Member);
        this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627U));
        this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
        this.Tmp1 = this.Tmp.GetChild(7);
        this.btn_Letter = this.Tmp1.GetComponent<UIButton>();
        this.btn_Letter.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Letter.m_BtnID1 = 10;
        this.btn_Letter.m_EffectType = e_EffectType.e_Scale;
        this.btn_Letter.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.Tmp.GetChild(7).GetChild(2);
        this.text_tmpStr[3] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[3].font = this.TTFont;
        this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(4637U);
        if ((Object) this.btnMessageNum_RT[0] == (Object) null)
        {
          this.btnMessageNum_RT[0] = this.Tmp.GetChild(7).GetChild(1).GetComponent<RectTransform>();
          this.tmpImg = this.Tmp.GetChild(7).GetChild(1).GetComponent<Image>();
          this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
          ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
          this.btnMessageNum_RT[1] = this.Tmp.GetChild(7).GetChild(1).GetChild(0).GetComponent<RectTransform>();
          this.text_MessageNum = this.Tmp.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>();
          this.text_MessageNum.font = this.TTFont;
        }
        long num = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
        if (num > 0L)
        {
          this.text_MessageNum.text = (num <= 20L ? (long) (int) num : 20L).ToString();
          this.text_MessageNum.SetAllDirty();
          this.text_MessageNum.cachedTextGenerator.Invalidate();
          this.text_MessageNum.cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.btnMessageNum_RT[0]).gameObject.SetActive(true);
          this.btnMessageNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_MessageNum.preferredWidth), this.btnMessageNum_RT[0].sizeDelta.y);
        }
        else
          ((Component) this.btnMessageNum_RT[0]).gameObject.SetActive(false);
        this.Tmp1 = this.Tmp.GetChild(8);
        this.btn_Member = this.Tmp1.GetComponent<UIButton>();
        this.btn_Member.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Member.m_BtnID1 = 5;
        this.btn_Member.m_EffectType = e_EffectType.e_Scale;
        this.btn_Member.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.Tmp.GetChild(8).GetChild(1);
        this.text_tmpStr[4] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[4].font = this.TTFont;
        this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(4629U);
        this.Tmp1 = this.Tmp.GetChild(9);
        this.btn_Application = this.Tmp1.GetComponent<UIButton>();
        this.btn_Application.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Application.m_BtnID1 = 6;
        this.btn_Application.m_EffectType = e_EffectType.e_Scale;
        this.btn_Application.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.Tmp.GetChild(9).GetChild(1);
        this.tmpImg = this.Tmp1.GetComponent<Image>();
        this.btnApplicationNum_RT[0] = this.Tmp1.GetComponent<RectTransform>();
        this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
        ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
        this.btnApplicationNum_RT[1] = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
        this.text_btnApplicationNum = this.Tmp1.GetChild(0).GetComponent<UIText>();
        this.text_btnApplicationNum.font = this.TTFont;
        this.text_btnApplicationNum.text = this.DM.RoleAlliance.Applicant.ToString();
        if (this.DM.RoleAlliance.Applicant > (byte) 0 && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
          this.btnApplicationNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnApplicationNum.preferredWidth), this.btnApplicationNum_RT[0].sizeDelta.y);
        else
          ((Component) this.btnApplicationNum_RT[0]).gameObject.SetActive(false);
        this.Tmp1 = this.Tmp.GetChild(9).GetChild(2);
        this.text_tmpStr[5] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[5].font = this.TTFont;
        this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(4630U);
        this.Tmp1 = this.Tmp.GetChild(10);
        this.btn_Gift = this.Tmp1.GetComponent<UIButton>();
        this.btn_Gift.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Gift.m_BtnID1 = 7;
        this.btn_Gift.m_EffectType = e_EffectType.e_Scale;
        this.btn_Gift.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.Tmp.GetChild(10).GetChild(1);
        this.tmpImg = this.Tmp1.GetComponent<Image>();
        this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
        ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
        this.btnGiftNum_RT[0] = this.Tmp1.GetComponent<RectTransform>();
        this.btnGiftNum_RT[1] = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
        this.text_btnGife[0] = this.Tmp1.GetChild(0).GetComponent<UIText>();
        this.text_btnGife[0].font = this.TTFont;
        this.text_btnGife[0].text = this.DM.RoleAlliance.GiftNum.ToString();
        if (this.DM.RoleAlliance.GiftNum > (ushort) 0)
          this.btnGiftNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnGife[0].preferredWidth), this.btnGiftNum_RT[0].sizeDelta.y);
        else
          ((Component) this.btnGiftNum_RT[0]).gameObject.SetActive(false);
        this.Tmp1 = this.Tmp.GetChild(10).GetChild(2);
        this.text_btnGife[1] = this.Tmp1.GetComponent<UIText>();
        this.text_btnGife[1].font = this.TTFont;
        this.Cstr_GifeLV.ClearString();
        this.Cstr_GifeLV.IntToFormat((long) this.DM.RoleAlliance.GiftLv);
        this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631U));
        this.text_btnGife[1].text = this.Cstr_GifeLV.ToString();
        this.Tmp1 = this.Tmp.GetChild(11);
        this.btn_KHint = this.Tmp1.GetComponent<UIButton>();
        this.btn_KHint.m_Handler = (IUIButtonClickHandler) this;
        this.btn_KHint.m_BtnID1 = 28;
        UIButtonHint uiButtonHint1 = ((Component) this.btn_KHint).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
        uiButtonHint1.m_Handler = (MonoBehaviour) this;
        this.img_KHint = this.Tmp.GetChild(14).GetComponent<Image>();
        uiButtonHint1.ControlFadeOut = ((Component) this.img_KHint).gameObject;
        uiButtonHint1.ScrollID = (byte) 1;
        this.text_tmpItmeStr[9] = this.Tmp.GetChild(14).GetChild(0).GetComponent<UIText>();
        this.text_tmpItmeStr[9].font = this.TTFont;
        this.text_tmpItmeStr[9].text = this.DM.mStringTable.GetStringByID(9549U);
        this.text_tmpItmeStr[9].cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.text_tmpItmeStr[9]).rectTransform.sizeDelta = new Vector2(this.text_tmpItmeStr[9].preferredWidth, ((Graphic) this.text_tmpItmeStr[9]).rectTransform.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_tmpItmeStr[9].UpdateArabicPos();
        this.text_tmpItmeStr[10] = this.Tmp.GetChild(14).GetChild(1).GetComponent<UIText>();
        this.text_tmpItmeStr[10].font = this.TTFont;
        this.text_tmpItmeStr[10].text = this.DM.mStringTable.GetStringByID(9550U);
        this.text_tmpItmeStr[10].cachedTextGeneratorForLayout.Invalidate();
        if ((double) this.text_tmpItmeStr[10].preferredWidth > (double) ((Graphic) this.text_tmpItmeStr[10]).rectTransform.sizeDelta.x)
        {
          ((Graphic) this.img_KHint).rectTransform.sizeDelta = new Vector2(this.text_tmpItmeStr[10].preferredWidth + 12f, ((Graphic) this.img_KHint).rectTransform.sizeDelta.y);
          ((Graphic) this.text_tmpItmeStr[10]).rectTransform.sizeDelta = new Vector2(this.text_tmpItmeStr[10].preferredWidth, ((Graphic) this.text_tmpItmeStr[10]).rectTransform.sizeDelta.y);
          if (this.GUIM.IsArabic)
            this.text_tmpItmeStr[10].UpdateArabicPos();
        }
        this.Tmp1 = this.Tmp.GetChild(12);
        this.text_AllianceName = this.Tmp1.GetComponent<UIText>();
        this.text_AllianceName.font = this.TTFont;
        this.Cstr_AllianceName.ClearString();
        GameConstants.FormatRoleName(this.Cstr_AllianceName, this.DM.RoleAlliance.Name, this.DM.RoleAlliance.Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
        this.Tmp1 = this.Tmp.GetChild(13);
        this.text_Alliance_K = this.Tmp1.GetComponent<UIText>();
        this.text_Alliance_K.font = this.TTFont;
        this.Cstr_Alliance_K.ClearString();
        this.Cstr_Alliance_K.IntToFormat((long) this.DM.RoleAlliance.KingdomID);
        if (this.GUIM.IsArabic)
          this.Cstr_Alliance_K.AppendFormat("{0}#");
        else
          this.Cstr_Alliance_K.AppendFormat("#{0}");
        this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
        this.text_Alliance_K.SetAllDirty();
        this.text_Alliance_K.cachedTextGenerator.Invalidate();
        this.text_Alliance_K.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.text_Alliance_K).rectTransform.sizeDelta = new Vector2(this.text_Alliance_K.preferredWidth + 1f, ((Graphic) this.text_Alliance_K).rectTransform.sizeDelta.y);
        RectTransform component3 = ((Component) this.btn_KHint).gameObject.GetComponent<RectTransform>();
        component3.anchoredPosition = !((Component) this.btn_ActivityGift).gameObject.activeSelf ? new Vector2(144f, component3.anchoredPosition.y) : new Vector2(214f, component3.anchoredPosition.y);
        ((Graphic) this.text_Alliance_K).rectTransform.anchoredPosition = new Vector2(component3.anchoredPosition.x + 50f, ((Graphic) this.text_Alliance_K).rectTransform.anchoredPosition.y);
        component3.sizeDelta = new Vector2((float) (50.0 + (double) this.text_Alliance_K.preferredWidth + 1.0), component3.sizeDelta.y);
        if ((int) this.DM.RoleAlliance.KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          ((Component) this.text_Alliance_K).gameObject.SetActive(true);
          ((Component) this.btn_KHint).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.text_Alliance_K).gameObject.SetActive(false);
          ((Component) this.btn_KHint).gameObject.SetActive(false);
        }
        this.Tmp1 = this.Pagedata[0].GetChild(1);
        this.m_ScrollPanel = this.Tmp1.GetComponent<ScrollPanel>();
        this.Tmp1 = this.Pagedata[0].GetChild(2);
        this.Tmp2 = this.Tmp1.GetChild(0);
        this.text_tmpItmeStr[0] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<UIText>();
        this.text_tmpItmeStr[0].font = this.TTFont;
        this.text_tmpItmeStr[1] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
        this.text_tmpItmeStr[1].font = this.TTFont;
        this.tmpImg = this.Tmp2.GetChild(4).GetChild(0).GetComponent<Image>();
        ((MaskableGraphic) this.tmpImg).material = this.GUIM.m_WonderMaterial;
        RectTransform rectTransform = ((Graphic) this.tmpImg).rectTransform;
        rectTransform.anchorMin = new Vector2(9f / 128f, 9f / 128f);
        rectTransform.anchorMax = new Vector2(119f / 128f, 119f / 128f);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        if (this.GUIM.IsArabic)
          ((Component) this.tmpImg).gameObject.AddComponent<ArabicItemTextureRot>();
        this.tmpImg = this.Tmp2.GetChild(4).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
        ((MaskableGraphic) this.tmpImg).material = this.FrameMaterial;
        RectTransform component4 = ((Component) ((Graphic) this.tmpImg).rectTransform).GetComponent<RectTransform>();
        component4.anchorMin = Vector2.zero;
        component4.anchorMax = new Vector2(1f, 1f);
        component4.offsetMin = Vector2.zero;
        component4.offsetMax = Vector2.zero;
        UIButton component5 = this.Tmp2.GetChild(5).GetComponent<UIButton>();
        component5.m_Handler = (IUIButtonClickHandler) this;
        component5.m_BtnID1 = 25;
        this.text_tmpItmeStr[2] = this.Tmp2.GetChild(6).GetChild(0).GetComponent<UIText>();
        this.text_tmpItmeStr[2].font = this.TTFont;
        for (int index = 0; index < 5; ++index)
        {
          this.text_tmpItmeStr[3 + index] = this.Tmp2.GetChild(7).GetChild(index).GetComponent<UIText>();
          this.text_tmpItmeStr[3 + index].font = this.TTFont;
        }
        UIButton component6 = this.Tmp2.GetChild(8).GetComponent<UIButton>();
        component6.m_Handler = (IUIButtonClickHandler) this;
        component6.m_BtnID1 = 27;
        UIButtonHint uiButtonHint2 = ((Component) component6).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
        uiButtonHint2.m_Handler = (MonoBehaviour) this;
        this.tmpImg = this.Tmp2.GetChild(9).GetComponent<Image>();
        uiButtonHint2.ControlFadeOut = ((Component) this.tmpImg).gameObject;
        this.text_tmpItmeStr[8] = this.Tmp2.GetChild(9).GetChild(0).GetComponent<UIText>();
        this.text_tmpItmeStr[8].font = this.TTFont;
        this.Tmp2 = this.Tmp1.GetChild(1);
        for (int index = 0; index < 5; ++index)
        {
          UIButton component7 = this.Tmp2.GetChild(index).GetComponent<UIButton>();
          this.btn_RT[index] = ((Component) component7).GetComponent<RectTransform>();
          this.btn_Pos[index] = new Vector2(this.btn_RT[index].anchoredPosition.x, this.btn_RT[index].anchoredPosition.y);
          component7.m_Handler = (IUIButtonClickHandler) this;
          component7.m_BtnID1 = index == 2 ? 4 : 8 + index;
          this.text_tmpItmeP2Str[index * 2] = this.Tmp2.GetChild(index).GetChild(1).GetChild(0).GetComponent<UIText>();
          this.text_tmpItmeP2Str[index * 2].font = this.TTFont;
          this.text_tmpItmeP2Str[index * 2 + 1] = this.Tmp2.GetChild(index).GetChild(2).GetComponent<UIText>();
          this.text_tmpItmeP2Str[index * 2 + 1].font = this.TTFont;
          this.tmpImg = this.Tmp2.GetChild(index).GetChild(1).GetComponent<Image>();
          this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
          ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
          ((Component) this.tmpImg).gameObject.SetActive(false);
        }
        this.text_tmpItmeP2Str[10] = this.Tmp2.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
        this.text_tmpItmeP2Str[10].font = this.TTFont;
        this.text_tmpItmeP2Str[1].text = this.DM.mStringTable.GetStringByID(4635U);
        this.text_tmpItmeP2Str[3].text = this.DM.mStringTable.GetStringByID(4636U);
        this.text_tmpItmeP2Str[5].text = this.DM.mStringTable.GetStringByID(4628U);
        this.text_tmpItmeP2Str[7].text = this.DM.mStringTable.GetStringByID(4639U);
        this.text_tmpItmeP2Str[9].text = this.DM.mStringTable.GetStringByID(4640U);
        for (int index = 0; index < 6; ++index)
        {
          this.btn_Fun[index] = new UIButton[5];
          this.text_ItembtnName[index] = new UIText[5];
          this.img_Wonders[index] = new Image[2];
          this.text_ItemName[index] = new UIText[2];
          this.text_ItemEffect[index] = new UIText[4];
        }
        UIEmojiInput component8 = this.Tmp2.GetChild(5).GetChild(0).GetComponent<UIEmojiInput>();
        this.text_tmpItmeP2Str[11] = component8.textComponent;
        this.text_tmpItmeP2Str[11].font = this.TTFont;
        this.text_tmpItmeP2Str[12] = component8.placeholder as UIText;
        this.text_tmpItmeP2Str[12].font = this.TTFont;
        if (this.DM.RoleAlliance.Bullet != null && this.DM.RoleAlliance.Bullet.Length != 0 && (Object) component8 != (Object) null)
          component8.text = this.DM.RoleAlliance.Bullet;
        else if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        {
          this.text_tmpItmeP2Str[12].text = this.DM.mStringTable.GetStringByID(772U);
        }
        else
        {
          this.Cstr_Null.ClearString();
          this.text_tmpItmeP2Str[12].text = this.Cstr_Null.ToString();
          component8.text = this.Cstr_Null.ToString();
        }
        UIButton component9 = this.Tmp2.GetChild(5).GetChild(1).GetComponent<UIButton>();
        component9.m_Handler = (IUIButtonClickHandler) this;
        component9.m_BtnID1 = 24;
        this.text_tmpItmeP2Str[13] = this.Tmp2.GetChild(5).GetChild(2).GetComponent<UIText>();
        this.text_tmpItmeP2Str[13].font = this.TTFont;
        ((Component) this.text_tmpItmeP2Str[13]).gameObject.SetActive(false);
        this.text_tmpItmeP2Str[13].SetCheckArabic(true);
        this.Tmp2.GetChild(5).GetChild(3).gameObject.SetActive(false);
        UIButton component10 = this.Tmp2.GetChild(5).GetChild(3).GetChild(0).GetComponent<UIButton>();
        component10.m_Handler = (IUIButtonClickHandler) this;
        component10.m_BtnID1 = 29;
        component10.m_EffectType = e_EffectType.e_Scale;
        component10.transition = (Selectable.Transition) 0;
        this.text_tmpItmeP2Str[14] = this.Tmp2.GetChild(5).GetChild(3).GetChild(2).GetComponent<UIText>();
        this.text_tmpItmeP2Str[14].font = this.TTFont;
        UIButton component11 = this.Tmp2.GetChild(6).GetComponent<UIButton>();
        component11.m_Handler = (IUIButtonClickHandler) this;
        component11.m_BtnID1 = 17;
        component11.m_EffectType = e_EffectType.e_Scale;
        component11.transition = (Selectable.Transition) 0;
        this.tmpHeight = 166f;
        if (!this.bshowbtn1)
        {
          ((Component) this.btn_RT[0]).gameObject.SetActive(false);
          for (int index = 1; index < 5; ++index)
            this.btn_RT[index].anchoredPosition = new Vector2(this.btn_Pos[index - 1].x, this.btn_Pos[index - 1].y);
          this.tmpHeight += (float) (((double) this.btn_RT[0].sizeDelta.y + 5.0) * 2.0);
        }
        else
          this.tmpHeight += (float) (((double) this.btn_RT[0].sizeDelta.y + 5.0) * 3.0);
        this.tmplist.Clear();
        for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
          this.tmplist.Add(93f);
        if (IGGGameSDK.Instance.GetTranslateStatus() && (double) this.text_tmpItmeP2Str[11].preferredHeight > 120.0)
        {
          this.tmpTransH = this.text_tmpItmeP2Str[11].preferredHeight - 120f;
          this.tmplist.Add(this.tmpHeight + 40f);
          for (int index = 0; index < 5; ++index)
          {
            if (!this.bshowbtn1 && index > 0)
              this.btn_RT[index].anchoredPosition = new Vector2(this.btn_Pos[index - 1].x, this.btn_Pos[index - 1].y - this.tmpTransH);
          }
        }
        else
          this.tmplist.Add(this.tmpHeight);
        this.m_ScrollPanel.IntiScrollPanel(351f, 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
        this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
        this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
        this.m_ScrollPanel.GoTo(this.DM.mAllianceInfoScroll_Idx, this.DM.mAllianceInfoScroll_Y);
        if (this.tmplist.Count <= 1)
          ((Behaviour) this.m_ScrollRect).enabled = false;
        UIButtonHint.scrollRect = this.m_ScrollRect;
        break;
      case 1:
        GameObject gameObject = (GameObject) Object.Instantiate(this.m_AssetBundle.Load("UIAlliance_Marshal"));
        this.MarshalInst = new UIAlliance_Marshal();
        this.Pagedata[this.mNowPage] = gameObject.transform;
        gameObject.transform.SetParent(this.transform.GetChild(4));
        this.MarshalInst.OnOpen(gameObject.transform);
        this.Pagedata[this.mNowPage].localPosition = Vector3.zero;
        this.Pagedata[this.mNowPage].localScale = Vector3.one;
        this.Pagedata[this.mNowPage].localRotation = this.Pagedata[this.mNowPage].localRotation with
        {
          eulerAngles = Vector3.zero
        };
        break;
      case 2:
        this.go = (GameObject) Object.Instantiate(this.m_AssetBundle.Load("UIAlliance_Help"));
        this.Pagedata[this.mNowPage] = this.go.GetComponent<Transform>();
        this.Pagedata[this.mNowPage].SetParent(this.PageT, false);
        this.Tmp = this.Pagedata[this.mNowPage].GetChild(1);
        this.Tmp1 = this.Tmp.GetChild(0);
        this.btn_Help = this.Tmp1.GetComponent<UIButton>();
        this.btn_Help.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Help.m_BtnID1 = 18;
        this.btn_Help.SetButtonEffectType(e_EffectType.e_Scale);
        this.btn_Help.transition = (Selectable.Transition) 0;
        if (this.GUIM.IsArabic)
          this.Tmp.GetChild(0).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
        this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
        this.btnHelp_RT = this.Tmp1.GetComponent<RectTransform>();
        this.tmpImg = this.Tmp1.GetComponent<Image>();
        this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
        ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
        this.Tmp1 = this.Tmp.GetChild(0).GetChild(2).GetChild(0);
        this.text_HelpNum = this.Tmp1.GetComponent<UIText>();
        this.text_HelpNum.font = this.TTFont;
        if (this.DM.mHelpDataList.Count > 0)
        {
          this.text_HelpNum.text = this.DM.mHelpDataList.Count.ToString();
          ((Component) this.btnHelp_RT).gameObject.SetActive(true);
          this.btnHelp_RT.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_HelpNum.preferredWidth), this.btnHelp_RT.sizeDelta.y);
        }
        this.Tmp1 = this.Tmp.GetChild(1);
        this.btn_Transport = this.Tmp1.GetComponent<UIButton>();
        this.btn_Transport.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Transport.m_BtnID1 = 19;
        this.btn_Transport.SetButtonEffectType(e_EffectType.e_Scale);
        this.btn_Transport.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.Tmp.GetChild(2);
        this.btn_Reinforce = this.Tmp1.GetComponent<UIButton>();
        this.btn_Reinforce.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Reinforce.m_BtnID1 = 20;
        this.btn_Reinforce.SetButtonEffectType(e_EffectType.e_Scale);
        this.btn_Reinforce.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.Tmp.GetChild(3);
        this.btn_Cantonment = this.Tmp1.GetComponent<UIButton>();
        this.btn_Cantonment.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Cantonment.m_BtnID1 = 26;
        this.btn_Cantonment.SetButtonEffectType(e_EffectType.e_Scale);
        this.btn_Cantonment.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
        this.text_tmpStr[6] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[6].font = this.TTFont;
        this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(750U);
        this.Tmp1 = this.Tmp.GetChild(1).GetChild(1);
        this.text_tmpStr[7] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[7].font = this.TTFont;
        this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(766U);
        this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
        this.text_tmpStr[8] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[8].font = this.TTFont;
        this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(767U);
        this.Tmp1 = this.Tmp.GetChild(3).GetChild(1);
        this.text_tmpStr[9] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[9].font = this.TTFont;
        this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(9739U);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    this.ItemT = item.GetComponent<Transform>();
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = this.ItemT.GetComponent<ScrollPanelItem>();
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      this.ItemPT1[panelObjectIdx] = this.ItemT.GetChild(0);
      this.text_Item_K[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<UIText>();
      this.img_Wonders[panelObjectIdx][0] = this.ItemPT1[panelObjectIdx].GetChild(2).GetComponent<Image>();
      this.text_ItemCDtime[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<UIText>();
      this.img_Wonders[panelObjectIdx][1] = this.ItemPT1[panelObjectIdx].GetChild(4).GetChild(0).GetComponent<Image>();
      this.btn_Item[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(5).GetComponent<UIButton>();
      this.btn_Item[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.ItemPT_W1[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(6);
      this.text_ItemName[panelObjectIdx][0] = this.ItemPT_W1[panelObjectIdx].GetChild(0).GetComponent<UIText>();
      this.ItemPT_W2[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(7);
      this.text_ItemName[panelObjectIdx][1] = this.ItemPT_W2[panelObjectIdx].GetChild(0).GetComponent<UIText>();
      this.btn_ItemHint[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(8).GetComponent<UIButton>();
      this.btn_ItemHint[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.btn_ItemHint[panelObjectIdx].m_BtnID1 = 27;
      this.btn_ItemHint[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      this.mbtnH_Item[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(8).GetComponent<UIButtonHint>();
      this.mbtnH_Item[panelObjectIdx].m_Handler = (MonoBehaviour) this;
      this.img_ItemHint[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(9).GetComponent<Image>();
      this.mbtnH_Item[panelObjectIdx].ControlFadeOut = ((Component) this.img_ItemHint[panelObjectIdx]).gameObject;
      this.text_Item_Hint[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(9).GetChild(0).GetComponent<UIText>();
      this.text_Item_Hint[panelObjectIdx].alignment = TextAnchor.MiddleLeft;
      for (int index = 0; index < 4; ++index)
        this.text_ItemEffect[panelObjectIdx][index] = this.ItemPT_W2[panelObjectIdx].GetChild(1 + index).GetComponent<UIText>();
      this.ItemPT2[panelObjectIdx] = this.ItemT.GetChild(1);
      for (int index = 0; index < 5; ++index)
      {
        this.btn_Fun[panelObjectIdx][index] = this.ItemPT2[panelObjectIdx].GetChild(index).GetComponent<UIButton>();
        this.btn_Fun[panelObjectIdx][index].m_Handler = (IUIButtonClickHandler) this;
        this.text_ItembtnName[panelObjectIdx][index] = this.ItemPT2[panelObjectIdx].GetChild(index).GetChild(2).GetComponent<UIText>();
      }
      this.mItemInput[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(0).GetComponent<UIEmojiInput>();
      this.btn_ItemInput[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(1).GetComponent<UIButton>();
      this.btn_ItemInput[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.text_Trans[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(2).GetComponent<UIText>();
      this.text_Trans[panelObjectIdx].SetCheckArabic(true);
      this.TranslationRT[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(3).GetComponent<RectTransform>();
      this.btn_Translation[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(3).GetChild(0).GetComponent<UIButton>();
      this.btn_Translation[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.Img_Translate[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(3).GetChild(1).GetComponent<Image>();
      this.text_Translation[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(3).GetChild(2).GetComponent<UIText>();
      this.btn_InputField[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(6).GetComponent<UIButton>();
      this.btn_InputField[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.btn_InputField[panelObjectIdx].m_BtnID2 = panelObjectIdx;
    }
    if (this.tmplist.Count - 1 == dataIdx)
    {
      this.ItemPT1[panelObjectIdx].gameObject.SetActive(false);
      this.ItemPT2[panelObjectIdx].gameObject.SetActive(true);
      this.mInput = this.mItemInput[panelObjectIdx];
      // ISSUE: method pointer
      this.mInput.onEndEdit.AddListener(new UnityAction<string>((object) this, __methodptr(\u003CUpDateRowItem\u003Em__EF)));
      this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
      this.text_Input1 = this.mInput.placeholder as UIText;
      this.text_Input1.font = this.TTFont;
      this.text_Trans[panelObjectIdx].text = this.mInput.text;
      this.text_Alliance_Money = this.ItemPT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.Cstr_Alliance_Money.ClearString();
      this.Cstr_Alliance_Money.IntToFormat((long) this.DM.RoleAlliance.Money, bNumber: true);
      this.Cstr_Alliance_Money.AppendFormat("{0}");
      this.text_Alliance_Money.text = this.Cstr_Alliance_Money.ToString();
      this.text_Alliance_Money.SetAllDirty();
      this.text_Alliance_Money.cachedTextGenerator.Invalidate();
      if (this.DM.RoleAlliance.Bullet != null && !this.bcheckInput)
        this.mInput.text = this.DM.RoleAlliance.Bullet;
      if (this.DM.RoleAlliance.Id != 0U && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
      {
        this.mInput.interactable = true;
        ((Behaviour) this.btn_ItemInput[panelObjectIdx]).enabled = true;
        ((Component) this.btn_InputField[panelObjectIdx]).gameObject.SetActive(true);
      }
      else
      {
        this.mInput.DeactivateInputField();
        if (this.mInput.text == string.Empty)
          this.text_Input1.text = string.Empty;
        this.mInput.interactable = false;
        ((Behaviour) this.btn_ItemInput[panelObjectIdx]).enabled = false;
        ((Component) this.btn_InputField[panelObjectIdx]).gameObject.SetActive(false);
        if ((Object) this.img_InputBG != (Object) null)
        {
          this.OpenInputCheck(false);
          this.bcheckInput = false;
        }
      }
      this.m_TranslationRT = this.TranslationRT[panelObjectIdx];
      this.m_text_Trans = this.text_Trans[panelObjectIdx];
      this.m_btn_Translation = this.btn_Translation[panelObjectIdx];
      this.m_Img_Translate = this.Img_Translate[panelObjectIdx];
      this.m_text_Translation = this.text_Translation[panelObjectIdx];
      if (!IGGGameSDK.Instance.GetTranslateStatus())
        return;
      if (this.bShowTranslate)
      {
        ((Component) this.mInput).gameObject.SetActive(false);
        this.m_text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString();
        this.m_text_Trans.resizeTextForBestFit = true;
        this.m_text_Trans.resizeTextMaxSize = 17;
        ((Component) this.m_text_Trans).gameObject.SetActive(true);
        this.m_text_Trans.cachedTextGeneratorForLayout.Invalidate();
        this.Cstr_Translation.ClearString();
        this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mAA_Info_L));
        this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
        this.m_text_Translation.text = this.Cstr_Translation.ToString();
      }
      else
      {
        ((Component) this.mInput).gameObject.SetActive(true);
        this.m_text_Trans.text = this.mInput.text;
        this.m_text_Trans.resizeTextForBestFit = false;
        this.m_text_Trans.cachedTextGeneratorForLayout.Invalidate();
        ((Component) this.m_text_Trans).gameObject.SetActive(false);
        this.m_text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
      }
      ((Component) this.m_btn_Translation).gameObject.SetActive(true);
      ((Component) this.m_Img_Translate).gameObject.SetActive(false);
      this.m_text_Translation.SetAllDirty();
      this.m_text_Translation.cachedTextGenerator.Invalidate();
      this.m_text_Translation.cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.m_text_Translation.preferredWidth > (double) ((Graphic) this.m_text_Translation).rectTransform.sizeDelta.x)
        ((Graphic) this.m_text_Translation).rectTransform.sizeDelta = new Vector2(this.m_text_Translation.preferredWidth + 2f, ((Graphic) this.m_text_Translation).rectTransform.sizeDelta.y);
      if (this.GUIM.IsArabic)
        this.m_text_Translation.UpdateArabicPos();
      this.m_TranslationRT.anchoredPosition = -0.5 - (double) this.m_text_Trans.preferredHeight <= -157.5 ? new Vector2(this.m_TranslationRT.anchoredPosition.x, -157.5f) : new Vector2(this.m_TranslationRT.anchoredPosition.x, -0.5f - this.m_text_Trans.preferredHeight);
      this.tmpTransH = (double) this.m_text_Trans.preferredHeight <= 120.0 ? 0.0f : 40f;
      for (int index = 0; index < 5; ++index)
      {
        this.btn_ItemRT[index] = ((Component) this.btn_Fun[panelObjectIdx][index]).transform.GetComponent<RectTransform>();
        this.btn_ItemRT[index].anchoredPosition = this.bshowbtn1 || index <= 0 ? new Vector2(this.btn_Pos[index].x, this.btn_Pos[index].y - this.tmpTransH) : new Vector2(this.btn_Pos[index - 1].x, this.btn_Pos[index - 1].y - this.tmpTransH);
      }
      if (this.DM.RoleAlliance.Bullet != null && this.DM.RoleAlliance.Bullet.Length > 0)
        ((Component) this.m_TranslationRT).gameObject.SetActive(true);
      else
        ((Component) this.m_TranslationRT).gameObject.SetActive(false);
    }
    else
    {
      this.ItemPT1[panelObjectIdx].gameObject.SetActive(true);
      this.ItemPT2[panelObjectIdx].gameObject.SetActive(false);
      this.btn_Item[panelObjectIdx].m_BtnID2 = dataIdx;
      this.Cstr_Item_K[panelObjectIdx].ClearString();
      this.Cstr_Item_K[panelObjectIdx].IntToFormat((long) this.DM.m_Wonders[dataIdx].KingdomID);
      if (this.GUIM.IsArabic)
        this.Cstr_Item_K[panelObjectIdx].AppendFormat("{0}#");
      else
        this.Cstr_Item_K[panelObjectIdx].AppendFormat("#{0}");
      this.text_Item_K[panelObjectIdx].text = this.Cstr_Item_K[panelObjectIdx].ToString();
      this.text_Item_K[panelObjectIdx].SetAllDirty();
      this.text_Item_K[panelObjectIdx].cachedTextGenerator.Invalidate();
      if ((int) this.DM.m_Wonders[dataIdx].KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        ((Component) this.text_Item_K[panelObjectIdx]).gameObject.SetActive(true);
      else
        ((Component) this.text_Item_K[panelObjectIdx]).gameObject.SetActive(false);
      this.img_Wonders[panelObjectIdx][1].sprite = this.DM.m_Wonders[dataIdx].WonderID >= (byte) 7 ? this.GUIM.GetWonderSprite((byte) 0, this.DM.m_Wonders[dataIdx].KingdomID, (byte) 0) : this.GUIM.GetWonderSprite(this.DM.m_Wonders[dataIdx].WonderID, this.DM.m_Wonders[dataIdx].KingdomID, (byte) 0);
      if (this.DM.m_Wonders[dataIdx].WonderID == (byte) 0)
      {
        this.ItemPT_W1[panelObjectIdx].gameObject.SetActive(true);
        this.ItemPT_W2[panelObjectIdx].gameObject.SetActive(false);
        this.text_ItemName[panelObjectIdx][0].text = DataManager.MapDataController.GetYolkName((ushort) 0, this.DM.m_Wonders[dataIdx].KingdomID).ToString();
      }
      else
      {
        bool flag = false;
        if (dataIdx != -1 && this.DM.m_Wonders[dataIdx].WonderID >= (byte) 0 && this.DM.m_Wonders[dataIdx].WonderID < (byte) 7 && this.mWonderEffect[(int) this.DM.m_Wonders[dataIdx].WonderID] != -1 && this.mWonderEffect[(int) this.DM.m_Wonders[dataIdx].WonderID] == dataIdx)
          flag = true;
        this.ItemPT_W1[panelObjectIdx].gameObject.SetActive(false);
        this.ItemPT_W2[panelObjectIdx].gameObject.SetActive(true);
        if (this.DM.m_Wonders[dataIdx].WonderID < (byte) 7)
          this.text_ItemName[panelObjectIdx][1].text = DataManager.MapDataController.GetYolkName((ushort) this.DM.m_Wonders[dataIdx].WonderID, this.DM.m_Wonders[dataIdx].KingdomID).ToString();
        this.Cstr_ItemEffect[panelObjectIdx][0].ClearString();
        this.Cstr_ItemEffect[panelObjectIdx][1].ClearString();
        WondersInfoTbl recordByIndex = DataManager.MapDataController.MapWondersInfoTable.GetRecordByIndex((int) this.DM.m_Wonders[dataIdx].WonderID);
        if (flag)
        {
          GameConstants.GetEffectValue(this.Cstr_ItemEffect[panelObjectIdx][0], recordByIndex.Effect[0].Effect, 0U, (byte) 0, 0.0f);
          this.text_ItemEffect[panelObjectIdx][0].text = this.Cstr_ItemEffect[panelObjectIdx][0].ToString();
          this.text_ItemEffect[panelObjectIdx][0].SetAllDirty();
          this.text_ItemEffect[panelObjectIdx][0].cachedTextGenerator.Invalidate();
          this.text_ItemEffect[panelObjectIdx][0].cachedTextGeneratorForLayout.Invalidate();
          GameConstants.GetEffectValue(this.Cstr_ItemEffect[panelObjectIdx][1], recordByIndex.Effect[1].Effect, 0U, (byte) 0, 0.0f);
          this.text_ItemEffect[panelObjectIdx][1].text = this.Cstr_ItemEffect[panelObjectIdx][1].ToString();
          this.text_ItemEffect[panelObjectIdx][1].SetAllDirty();
          this.text_ItemEffect[panelObjectIdx][1].cachedTextGenerator.Invalidate();
          this.text_ItemEffect[panelObjectIdx][1].cachedTextGeneratorForLayout.Invalidate();
        }
        else
        {
          this.text_ItemEffect[panelObjectIdx][0].text = this.DM.mStringTable.GetStringByID(11043U);
          this.text_ItemEffect[panelObjectIdx][0].SetAllDirty();
          this.text_ItemEffect[panelObjectIdx][0].cachedTextGenerator.Invalidate();
          this.text_ItemEffect[panelObjectIdx][0].cachedTextGeneratorForLayout.Invalidate();
        }
        this.Cstr_ItemEffect[panelObjectIdx][2].ClearString();
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(recordByIndex.Effect[0].Effect);
        if (recordByIndex.Effect[0].Value != (ushort) 0 && flag)
        {
          ((Component) this.text_ItemEffect[panelObjectIdx][0]).gameObject.SetActive(true);
          ((Component) this.text_ItemEffect[panelObjectIdx][2]).gameObject.SetActive(true);
          if (recordByKey.ValueID == (ushort) 4378)
          {
            this.Cstr_ItemEffect[panelObjectIdx][2].IntToFormat((long) ((int) recordByIndex.Effect[0].Value / 100));
            if (this.GUIM.IsArabic)
              this.Cstr_ItemEffect[panelObjectIdx][2].AppendFormat("<color=#35F76C>%{0}</color>");
            else
              this.Cstr_ItemEffect[panelObjectIdx][2].AppendFormat("<color=#35F76C>{0}%</color>");
          }
          else
          {
            this.Cstr_ItemEffect[panelObjectIdx][2].IntToFormat((long) recordByIndex.Effect[0].Value);
            this.Cstr_ItemEffect[panelObjectIdx][2].AppendFormat("<color=#35F76C>{0}</color>");
          }
        }
        else
        {
          if (!flag)
            ((Component) this.text_ItemEffect[panelObjectIdx][0]).gameObject.SetActive(true);
          ((Component) this.text_ItemEffect[panelObjectIdx][2]).gameObject.SetActive(false);
        }
        this.text_ItemEffect[panelObjectIdx][2].text = this.Cstr_ItemEffect[panelObjectIdx][2].ToString();
        this.text_ItemEffect[panelObjectIdx][2].SetAllDirty();
        this.text_ItemEffect[panelObjectIdx][2].cachedTextGenerator.Invalidate();
        this.text_ItemEffect[panelObjectIdx][2].cachedTextGeneratorForLayout.Invalidate();
        this.Cstr_ItemEffect[panelObjectIdx][3].ClearString();
        recordByKey = DataManager.Instance.EffectData.GetRecordByKey(recordByIndex.Effect[1].Effect);
        if (recordByIndex.Effect[1].Value != (ushort) 0 && flag)
        {
          ((Component) this.text_ItemEffect[panelObjectIdx][1]).gameObject.SetActive(true);
          ((Component) this.text_ItemEffect[panelObjectIdx][3]).gameObject.SetActive(true);
          if (recordByKey.ValueID == (ushort) 4378)
          {
            this.Cstr_ItemEffect[panelObjectIdx][3].IntToFormat((long) ((int) recordByIndex.Effect[1].Value / 100));
            if (this.GUIM.IsArabic)
              this.Cstr_ItemEffect[panelObjectIdx][3].AppendFormat("<color=#35F76C>%{0}</color>");
            else
              this.Cstr_ItemEffect[panelObjectIdx][3].AppendFormat("<color=#35F76C>{0}%</color>");
          }
          else
          {
            this.Cstr_ItemEffect[panelObjectIdx][3].IntToFormat((long) recordByIndex.Effect[1].Value);
            this.Cstr_ItemEffect[panelObjectIdx][3].AppendFormat("<color=#35F76C>{0}</color>");
          }
        }
        else
        {
          ((Component) this.text_ItemEffect[panelObjectIdx][1]).gameObject.SetActive(false);
          ((Component) this.text_ItemEffect[panelObjectIdx][3]).gameObject.SetActive(false);
        }
        this.text_ItemEffect[panelObjectIdx][3].text = this.Cstr_ItemEffect[panelObjectIdx][3].ToString();
        this.text_ItemEffect[panelObjectIdx][3].SetAllDirty();
        this.text_ItemEffect[panelObjectIdx][3].cachedTextGenerator.Invalidate();
        this.text_ItemEffect[panelObjectIdx][3].cachedTextGeneratorForLayout.Invalidate();
        if (!flag && (double) this.text_ItemEffect[panelObjectIdx][0].preferredWidth >= 370.0)
          ((Graphic) this.text_ItemEffect[panelObjectIdx][0]).rectTransform.sizeDelta = new Vector2(370f, 50f);
        else
          ((Graphic) this.text_ItemEffect[panelObjectIdx][0]).rectTransform.sizeDelta = new Vector2(this.text_ItemEffect[panelObjectIdx][0].preferredWidth, 25f);
        if (this.GUIM.IsArabic)
          this.text_ItemEffect[panelObjectIdx][0].UpdateArabicPos();
        ((Graphic) this.text_ItemEffect[panelObjectIdx][1]).rectTransform.sizeDelta = new Vector2(this.text_ItemEffect[panelObjectIdx][1].preferredWidth, ((Graphic) this.text_ItemEffect[panelObjectIdx][1]).rectTransform.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_ItemEffect[panelObjectIdx][1].UpdateArabicPos();
        ((Graphic) this.text_ItemEffect[panelObjectIdx][2]).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.text_ItemEffect[panelObjectIdx][0]).rectTransform.anchoredPosition.x + (double) ((Graphic) this.text_ItemEffect[panelObjectIdx][0]).rectTransform.sizeDelta.x + 10.0), ((Graphic) this.text_ItemEffect[panelObjectIdx][0]).rectTransform.anchoredPosition.y);
        if (this.GUIM.IsArabic)
          this.text_ItemEffect[panelObjectIdx][2].UpdateArabicPos();
        ((Graphic) this.text_ItemEffect[panelObjectIdx][3]).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.text_ItemEffect[panelObjectIdx][1]).rectTransform.anchoredPosition.x + (double) ((Graphic) this.text_ItemEffect[panelObjectIdx][1]).rectTransform.sizeDelta.x + 10.0), ((Graphic) this.text_ItemEffect[panelObjectIdx][1]).rectTransform.anchoredPosition.y);
        if (this.GUIM.IsArabic)
          this.text_ItemEffect[panelObjectIdx][3].UpdateArabicPos();
      }
      if (this.DM.m_Wonders[dataIdx].OpenState == (byte) 1)
      {
        if (ActivityManager.Instance.IsInKvK((ushort) 0, true))
        {
          this.img_Wonders[panelObjectIdx][0].sprite = this.SArray.m_Sprites[10];
          ((Graphic) this.text_ItemCDtime[panelObjectIdx]).color = new Color(1f, 0.788f, 0.239f);
          this.text_Item_Hint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9902U);
        }
        else
        {
          this.img_Wonders[panelObjectIdx][0].sprite = this.SArray.m_Sprites[9];
          ((Graphic) this.text_ItemCDtime[panelObjectIdx]).color = new Color(1f, 0.2275f, 0.3333f);
          this.text_Item_Hint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9397U);
        }
      }
      else if (this.DM.m_Wonders[dataIdx].OpenState == (byte) 0)
      {
        this.img_Wonders[panelObjectIdx][0].sprite = this.SArray.m_Sprites[8];
        ((Graphic) this.text_ItemCDtime[panelObjectIdx]).color = new Color(0.2078f, 0.9686f, 0.4235f);
        this.text_Item_Hint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9399U);
      }
      this.text_Item_Hint[panelObjectIdx].SetAllDirty();
      this.text_Item_Hint[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.text_Item_Hint[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_Item_Hint[panelObjectIdx].preferredWidth > (double) ((Graphic) this.text_Item_Hint[panelObjectIdx]).rectTransform.sizeDelta.x)
      {
        ((Graphic) this.img_ItemHint[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(this.text_Item_Hint[panelObjectIdx].preferredWidth + 12f, ((Graphic) this.img_ItemHint[panelObjectIdx]).rectTransform.sizeDelta.y);
        ((Graphic) this.text_Item_Hint[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(this.text_Item_Hint[panelObjectIdx].preferredWidth, ((Graphic) this.text_Item_Hint[panelObjectIdx]).rectTransform.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_Item_Hint[panelObjectIdx].UpdateArabicPos();
      }
      if ((double) this.text_Item_Hint[panelObjectIdx].preferredHeight > (double) ((Graphic) this.text_Item_Hint[panelObjectIdx]).rectTransform.sizeDelta.y)
      {
        ((Graphic) this.img_ItemHint[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(((Graphic) this.img_ItemHint[panelObjectIdx]).rectTransform.sizeDelta.x, this.text_Item_Hint[panelObjectIdx].preferredHeight + 16f);
        ((Graphic) this.text_Item_Hint[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Item_Hint[panelObjectIdx]).rectTransform.sizeDelta.x, this.text_Item_Hint[panelObjectIdx].preferredHeight);
      }
      this.Cstr_Item_Time[panelObjectIdx].ClearString();
      long num1 = this.DM.m_Wonders[dataIdx].StateCountDown.BeginTime + (long) this.DM.m_Wonders[dataIdx].StateCountDown.RequireTime - this.DM.ServerTime;
      if (num1 > 0L)
      {
        if (num1 > 86400L)
        {
          this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num1 / 86400L);
          long num2 = num1 % 86400L;
          this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num2 / 3600L, 2);
          long num3 = num2 % 3600L;
          this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num3 / 60L, 2);
          long x = num3 % 60L;
          this.Cstr_Item_Time[panelObjectIdx].IntToFormat(x, 2);
          this.Cstr_Item_Time[panelObjectIdx].AppendFormat("{0}d {1}:{2}:{3}");
        }
        else
        {
          this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num1 / 3600L, 2);
          long num4 = num1 % 3600L;
          this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num4 / 60L, 2);
          long x = num4 % 60L;
          this.Cstr_Item_Time[panelObjectIdx].IntToFormat(x, 2);
          this.Cstr_Item_Time[panelObjectIdx].AppendFormat("{0}:{1}:{2}");
        }
      }
      else if (this.DM.m_Wonders[dataIdx].WonderID != (byte) 0)
      {
        if (this.DM.m_Wonders[dataIdx].OpenState == (byte) 0)
          this.Cstr_Item_Time[panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(9321U));
        else
          this.Cstr_Item_Time[panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(9314U));
      }
      else
        this.Cstr_Item_Time[panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(9320U));
      this.text_ItemCDtime[panelObjectIdx].text = this.Cstr_Item_Time[panelObjectIdx].ToString();
      this.text_ItemCDtime[panelObjectIdx].SetAllDirty();
      this.text_ItemCDtime[panelObjectIdx].cachedTextGenerator.Invalidate();
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if (this.bcheckInput && sender.m_BtnID1 != 23 && sender.m_BtnID1 != 21 && sender.m_BtnID1 != 22)
      return;
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
        this.SetPage(sender.m_BtnID1 - 1);
        break;
      case 4:
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK2)
        {
          this.DM.Letter_ReplyName = this.DM.mStringTable.GetStringByID(4628U);
          this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 3);
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
        break;
      case 5:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_List);
        break;
      case 6:
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        {
          this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 1);
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
        break;
      case 7:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_Gift);
        break;
      case 9:
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, arg2: 3);
        break;
      case 10:
        this.DM.AskMessageBoard(this.DM.RoleAlliance.Id);
        break;
      case 11:
        UILeaderBoard.NewOpen = true;
        this.door.OpenMenu(EGUIWindow.UI_LeaderBoard);
        break;
      case 12:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_Management);
        break;
      case 17:
        if (!((Object) this.mInput != (Object) null) || !((Component) this.mInput).transform.parent.parent.gameObject.activeSelf)
          break;
        if (!((Component) this.mInput).gameObject.activeSelf)
        {
          ((Component) this.m_text_Trans).gameObject.SetActive(false);
          ((Component) this.mInput).gameObject.SetActive(true);
        }
        this.mInput.ActivateInputField();
        this.bcheckInput = true;
        ((Behaviour) this.m_ScrollRect).enabled = false;
        break;
      case 18:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_HelpSpeedup);
        break;
      case 19:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 4);
        break;
      case 20:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 5);
        break;
      case 21:
        if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
        {
          if ((Object) this.img_InputBG != (Object) null)
          {
            this.OpenInputCheck(false);
            this.bcheckInput = false;
          }
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          this.door.CloseMenu();
          break;
        }
        if (this.DM.RoleAlliance.Id != 0U && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4 && GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
        {
          char[] charArray = this.mInput.text.ToCharArray();
          if (this.DM.m_BannedWord != null)
            this.DM.m_BannedWord.CheckBannedWord(charArray);
          byte[] bytes = Encoding.UTF8.GetBytes(charArray);
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_BULLETIN;
          messagePacket.AddSeqId();
          messagePacket.Add((ushort) bytes.Length);
          messagePacket.Add(bytes, len: 900);
          byte data = !ArabicTransfer.Instance.IsArabicStr(this.mInput.text) ? (byte) 1 : (byte) 2;
          messagePacket.Add(data);
          messagePacket.Send();
        }
        this.OpenInputCheck(false);
        this.bcheckInput = false;
        if (this.DM.m_Wonders.Count <= 0)
          break;
        ((Behaviour) this.m_ScrollRect).enabled = true;
        break;
      case 22:
        if (!((Object) this.mInput != (Object) null) || !((Component) this.mInput).transform.parent.parent.gameObject.activeSelf)
          break;
        if (IGGGameSDK.Instance.GetTranslateStatus() && !((Component) this.m_text_Trans).gameObject.activeSelf)
        {
          ((Component) this.m_text_Trans).gameObject.SetActive(true);
          ((Component) this.mInput).gameObject.SetActive(false);
        }
        if (this.DM.RoleAlliance.Bullet != null)
          this.mInput.text = this.DM.RoleAlliance.Bullet;
        this.OpenInputCheck(false);
        this.bcheckInput = false;
        if (this.DM.m_Wonders.Count <= 0)
          break;
        ((Behaviour) this.m_ScrollRect).enabled = true;
        break;
      case 23:
        if (!((Object) this.mInput != (Object) null) || !((Component) this.mInput).transform.parent.parent.gameObject.activeSelf)
          break;
        this.OpenInputCheck(false);
        this.mInput.ActivateInputField();
        ((Behaviour) this.m_ScrollRect).enabled = false;
        break;
      case 24:
        if (!((Object) this.mInput != (Object) null) || !((Component) this.mInput).transform.parent.parent.gameObject.activeSelf)
          break;
        if (!((Component) this.mInput).gameObject.activeSelf)
        {
          ((Component) this.m_text_Trans).gameObject.SetActive(false);
          ((Component) this.mInput).gameObject.SetActive(true);
        }
        this.mInput.ActivateInputField();
        ((Behaviour) this.m_ScrollRect).enabled = false;
        break;
      case 25:
        this.door.GoToWonder(this.DM.m_Wonders[sender.m_BtnID2].KingdomID, this.DM.m_Wonders[sender.m_BtnID2].WonderID);
        break;
      case 26:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 7);
        break;
      case 29:
        if (this.DM.bWaitTranslate_AA)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
          break;
        }
        if (this.DM.bNeedTranslate_AA_Info && !this.DM.bTranslate_AA_Info && !this.DM.bWaitTranslate_AA)
        {
          ((Component) this.m_btn_Translation).gameObject.SetActive(false);
          ((Component) this.m_Img_Translate).gameObject.SetActive(true);
          this.DM.bWaitTranslate_AA = true;
          this.DM.bTransAA = true;
          if (this.DM.RoleAlliance.Bullet == null)
            break;
          IGGSDKPlugin.Translate_AA(this.DM.RoleAlliance.Bullet);
          break;
        }
        if (!this.bShowTranslate)
        {
          this.m_text_Trans.resizeTextForBestFit = true;
          this.m_text_Trans.resizeTextMaxSize = 17;
          this.m_text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString();
          this.Cstr_Translation.ClearString();
          this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mAA_Info_L));
          this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
          this.m_text_Translation.text = this.Cstr_Translation.ToString();
          this.bShowTranslate = true;
        }
        else
        {
          this.m_text_Trans.resizeTextForBestFit = false;
          if (this.DM.RoleAlliance.Bullet != null)
            this.m_text_Trans.text = this.DM.RoleAlliance.Bullet;
          this.m_text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
          this.bShowTranslate = false;
        }
        this.m_text_Trans.SetAllDirty();
        this.m_text_Trans.cachedTextGenerator.Invalidate();
        this.m_text_Trans.cachedTextGeneratorForLayout.Invalidate();
        this.m_text_Translation.SetAllDirty();
        this.m_text_Translation.cachedTextGenerator.Invalidate();
        this.m_text_Translation.cachedTextGeneratorForLayout.Invalidate();
        this.tmpTransH = (double) this.m_text_Trans.preferredHeight <= 120.0 ? 0.0f : this.m_text_Trans.preferredHeight - 120f;
        this.tmplist.Clear();
        for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
          this.tmplist.Add(93f);
        if ((double) this.tmpTransH > 0.0)
          this.tmplist.Add(this.tmpHeight + 40f);
        else
          this.tmplist.Add(this.tmpHeight);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if (this.tmplist.Count <= 1)
          ((Behaviour) this.m_ScrollRect).enabled = false;
        else
          ((Behaviour) this.m_ScrollRect).enabled = true;
        if ((double) this.m_text_Translation.preferredWidth > (double) ((Graphic) this.m_text_Translation).rectTransform.sizeDelta.x)
          ((Graphic) this.m_text_Translation).rectTransform.sizeDelta = new Vector2(this.m_text_Translation.preferredWidth + 2f, ((Graphic) this.m_text_Translation).rectTransform.sizeDelta.y);
        if (!this.GUIM.IsArabic)
          break;
        this.m_text_Translation.UpdateArabicPos();
        break;
      case 30:
        ActivityGiftManager.Instance.mActivityGiftPage = (byte) 0;
        this.door.OpenMenu(EGUIWindow.UI_Alliance_ActivityGift);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch ((GUIAlliance_Info_btn) button.m_BtnID1)
    {
      case GUIAlliance_Info_btn.btn_ItemHint:
        ((Component) this.img_ItemHint[button.m_BtnID2]).gameObject.SetActive(true);
        break;
      case GUIAlliance_Info_btn.btn_KHint:
        ((Component) this.img_KHint).gameObject.SetActive(true);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch ((GUIAlliance_Info_btn) button.m_BtnID1)
    {
      case GUIAlliance_Info_btn.btn_ItemHint:
        ((Component) this.img_ItemHint[button.m_BtnID2]).gameObject.SetActive(false);
        break;
      case GUIAlliance_Info_btn.btn_KHint:
        ((Component) this.img_KHint).gameObject.SetActive(false);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.MarshalInst != null)
      this.MarshalInst.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.OpenInputCheck(false);
          this.bcheckInput = false;
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Info);
          break;
        }
        if (((UIBehaviour) this.img_InputBG).IsActive())
          this.OpenInputCheck(false);
        this.CheckGiftBtnShow();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Alliance)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.OpenInputCheck(false);
          this.bcheckInput = false;
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Info);
          break;
        }
        if (!((Object) this.Pagedata[0] != (Object) null))
          break;
        this.Cstr_AllianceChief.ClearString();
        this.Cstr_AllianceChief.StringToFormat(this.DM.RoleAlliance.Leader);
        this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625U));
        this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
        this.text_AllianceChief.SetAllDirty();
        this.text_AllianceChief.cachedTextGenerator.Invalidate();
        this.Cstr_AllianceStrength.ClearString();
        this.Cstr_AllianceStrength.uLongToFormat(this.DM.RoleAlliance.Power, bNumber: true);
        this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626U));
        this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
        this.text_AllianceStrength.SetAllDirty();
        this.text_AllianceStrength.cachedTextGenerator.Invalidate();
        this.Cstr_AllianceMember.ClearString();
        this.Cstr_AllianceMember.IntToFormat((long) this.DM.RoleAlliance.Member);
        this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627U));
        this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
        this.text_AllianceMember.SetAllDirty();
        this.text_AllianceMember.cachedTextGenerator.Invalidate();
        this.text_btnApplicationNum.text = this.DM.RoleAlliance.Applicant.ToString();
        if (this.DM.RoleAlliance.Applicant > (byte) 0 && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        {
          ((Component) this.btnApplicationNum_RT[0]).gameObject.SetActive(true);
          this.btnApplicationNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnApplicationNum.preferredWidth), this.btnApplicationNum_RT[0].sizeDelta.y);
        }
        else
          ((Component) this.btnApplicationNum_RT[0]).gameObject.SetActive(false);
        this.Cstr_GifeLV.ClearString();
        this.Cstr_GifeLV.IntToFormat((long) this.DM.RoleAlliance.GiftLv);
        this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631U));
        this.text_btnGife[1].text = this.Cstr_GifeLV.ToString();
        this.text_btnGife[1].SetAllDirty();
        this.text_btnGife[1].cachedTextGenerator.Invalidate();
        this.text_btnGife[0].text = this.DM.RoleAlliance.GiftNum.ToString();
        if (this.DM.RoleAlliance.GiftNum > (ushort) 0)
        {
          ((Component) this.btnGiftNum_RT[0]).gameObject.SetActive(true);
          this.btnGiftNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnGife[0].preferredWidth), this.btnGiftNum_RT[0].sizeDelta.y);
        }
        else
          ((Component) this.btnGiftNum_RT[0]).gameObject.SetActive(false);
        long num = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
        if ((Object) this.btnMessageNum_RT[0] != (Object) null)
        {
          if (num > 0L)
          {
            num = num <= 20L ? (long) (int) num : 20L;
            this.text_MessageNum.text = num.ToString();
            this.text_MessageNum.SetAllDirty();
            this.text_MessageNum.cachedTextGenerator.Invalidate();
            this.text_MessageNum.cachedTextGeneratorForLayout.Invalidate();
            ((Component) this.btnMessageNum_RT[0]).gameObject.SetActive(true);
            this.btnMessageNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_MessageNum.preferredWidth), this.btnMessageNum_RT[0].sizeDelta.y);
          }
          else
            ((Component) this.btnMessageNum_RT[0]).gameObject.SetActive(false);
        }
        int giftNum = (int) this.DM.RoleAlliance.GiftNum;
        if (num > 0L)
          giftNum += (int) num;
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
          giftNum += (int) this.DM.RoleAlliance.Applicant;
        if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > (byte) 0)
          giftNum += (int) ActivityGiftManager.Instance.EnableRedPocketNum;
        if (giftNum > 0)
        {
          this.text_PageNum[0].text = giftNum.ToString();
          this.text_PageNum[0].SetAllDirty();
          this.text_PageNum[0].cachedTextGenerator.Invalidate();
          this.text_PageNum[0].cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.PageImg_RT[0]).gameObject.SetActive(true);
          this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
        }
        else
          ((Component) this.PageImg_RT[0]).gameObject.SetActive(false);
        this.Cstr_AllianceName.ClearString();
        GameConstants.FormatRoleName(this.Cstr_AllianceName, this.DM.RoleAlliance.Name, this.DM.RoleAlliance.Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
        this.text_AllianceName.SetAllDirty();
        this.text_AllianceName.cachedTextGenerator.Invalidate();
        this.GUIM.SetBadgeTotemImg(this.BadgeT, this.DM.RoleAlliance.Emblem);
        if ((Object) this.text_Alliance_Money != (Object) null)
        {
          this.Cstr_Alliance_Money.ClearString();
          this.Cstr_Alliance_Money.IntToFormat((long) this.DM.RoleAlliance.Money, bNumber: true);
          this.Cstr_Alliance_Money.AppendFormat("{0}");
          this.text_Alliance_Money.text = this.Cstr_Alliance_Money.ToString();
          this.text_Alliance_Money.SetAllDirty();
          this.text_Alliance_Money.cachedTextGenerator.Invalidate();
        }
        if ((Object) this.text_Alliance_K != (Object) null && (Object) this.btn_KHint != (Object) null && this.Cstr_Alliance_K != null)
        {
          this.Cstr_Alliance_K.ClearString();
          this.Cstr_Alliance_K.IntToFormat((long) this.DM.RoleAlliance.KingdomID);
          if (this.GUIM.IsArabic)
            this.Cstr_Alliance_K.AppendFormat("{0}#");
          else
            this.Cstr_Alliance_K.AppendFormat("#{0}");
          this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
          this.text_Alliance_K.SetAllDirty();
          this.text_Alliance_K.cachedTextGenerator.Invalidate();
          this.text_Alliance_K.cachedTextGeneratorForLayout.Invalidate();
          RectTransform component = ((Component) this.btn_KHint).gameObject.GetComponent<RectTransform>();
          component.anchoredPosition = !((Component) this.btn_ActivityGift).gameObject.activeSelf ? new Vector2(144f, component.anchoredPosition.y) : new Vector2(214f, component.anchoredPosition.y);
          ((Graphic) this.text_Alliance_K).rectTransform.anchoredPosition = new Vector2(component.anchoredPosition.x + 50f, ((Graphic) this.text_Alliance_K).rectTransform.anchoredPosition.y);
          component.sizeDelta = new Vector2((float) (50.0 + (double) this.text_Alliance_K.preferredWidth + 1.0), component.sizeDelta.y);
          if ((int) this.DM.RoleAlliance.KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
          {
            ((Component) this.text_Alliance_K).gameObject.SetActive(true);
            ((Component) this.btn_KHint).gameObject.SetActive(true);
          }
          else
          {
            ((Component) this.text_Alliance_K).gameObject.SetActive(false);
            ((Component) this.btn_KHint).gameObject.SetActive(false);
          }
        }
        if (this.DM.bSetAllianceScroll)
        {
          this.tmplist.Clear();
          for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
            this.tmplist.Add(93f);
          this.ResetEffectText();
          float tmpHeight = this.tmpHeight;
          if (IGGGameSDK.Instance.GetTranslateStatus() && (Object) this.m_TranslationRT != (Object) null && (double) this.m_TranslationRT.anchoredPosition.y < -120.5)
            tmpHeight += 40f;
          this.tmplist.Add(tmpHeight);
          if (this.tmplist.Count <= 1)
          {
            ((Behaviour) this.m_ScrollRect).enabled = false;
            this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
          }
          else
          {
            ((Behaviour) this.m_ScrollRect).enabled = true;
            this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
          }
        }
        this.DM.bSetAllianceScroll = false;
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
    if ((Object) this.text_Propaganda != (Object) null && ((Behaviour) this.text_Propaganda).enabled)
    {
      ((Behaviour) this.text_Propaganda).enabled = false;
      ((Behaviour) this.text_Propaganda).enabled = true;
    }
    if ((Object) this.text_AllianceName != (Object) null && ((Behaviour) this.text_AllianceName).enabled)
    {
      ((Behaviour) this.text_AllianceName).enabled = false;
      ((Behaviour) this.text_AllianceName).enabled = true;
    }
    if ((Object) this.text_AllianceChief != (Object) null && ((Behaviour) this.text_AllianceChief).enabled)
    {
      ((Behaviour) this.text_AllianceChief).enabled = false;
      ((Behaviour) this.text_AllianceChief).enabled = true;
    }
    if ((Object) this.text_AllianceStrength != (Object) null && ((Behaviour) this.text_AllianceStrength).enabled)
    {
      ((Behaviour) this.text_AllianceStrength).enabled = false;
      ((Behaviour) this.text_AllianceStrength).enabled = true;
    }
    if ((Object) this.text_AllianceMember != (Object) null && ((Behaviour) this.text_AllianceMember).enabled)
    {
      ((Behaviour) this.text_AllianceMember).enabled = false;
      ((Behaviour) this.text_AllianceMember).enabled = true;
    }
    if ((Object) this.text_InputCheck != (Object) null && ((Behaviour) this.text_InputCheck).enabled)
    {
      ((Behaviour) this.text_InputCheck).enabled = false;
      ((Behaviour) this.text_InputCheck).enabled = true;
    }
    if ((Object) this.text_btnApplicationNum != (Object) null && ((Behaviour) this.text_btnApplicationNum).enabled)
    {
      ((Behaviour) this.text_btnApplicationNum).enabled = false;
      ((Behaviour) this.text_btnApplicationNum).enabled = true;
    }
    if ((Object) this.text_Input1 != (Object) null && ((Behaviour) this.text_Input1).enabled)
    {
      ((Behaviour) this.text_Input1).enabled = false;
      ((Behaviour) this.text_Input1).enabled = true;
    }
    if ((Object) this.text_Alliance_Money != (Object) null && ((Behaviour) this.text_Alliance_Money).enabled)
    {
      ((Behaviour) this.text_Alliance_Money).enabled = false;
      ((Behaviour) this.text_Alliance_Money).enabled = true;
    }
    if ((Object) this.text_HelpNum != (Object) null && ((Behaviour) this.text_HelpNum).enabled)
    {
      ((Behaviour) this.text_HelpNum).enabled = false;
      ((Behaviour) this.text_HelpNum).enabled = true;
    }
    if ((Object) this.text_MessageNum != (Object) null && ((Behaviour) this.text_MessageNum).enabled)
    {
      ((Behaviour) this.text_MessageNum).enabled = false;
      ((Behaviour) this.text_MessageNum).enabled = true;
    }
    if ((Object) this.img_text != (Object) null)
    {
      if ((Object) this.img_text.m_RunningText1 != (Object) null && ((Behaviour) this.img_text.m_RunningText1).enabled)
      {
        ((Behaviour) this.img_text.m_RunningText1).enabled = false;
        ((Behaviour) this.img_text.m_RunningText1).enabled = true;
      }
      if ((Object) this.img_text.m_RunningText2 != (Object) null && ((Behaviour) this.img_text.m_RunningText2).enabled)
      {
        ((Behaviour) this.img_text.m_RunningText2).enabled = false;
        ((Behaviour) this.img_text.m_RunningText2).enabled = true;
      }
    }
    if ((Object) this.mInput != (Object) null && ((Behaviour) this.mInput.textComponent).enabled)
    {
      ((Behaviour) this.mInput.textComponent).enabled = false;
      ((Behaviour) this.mInput.textComponent).enabled = true;
    }
    if ((Object) this.m_text_ActivityGiftNum != (Object) null && ((Behaviour) this.m_text_ActivityGiftNum).enabled)
    {
      ((Behaviour) this.m_text_ActivityGiftNum).enabled = false;
      ((Behaviour) this.m_text_ActivityGiftNum).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_btnGife[index] != (Object) null && ((Behaviour) this.text_btnGife[index]).enabled)
      {
        ((Behaviour) this.text_btnGife[index]).enabled = false;
        ((Behaviour) this.text_btnGife[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_PageNum[index] != (Object) null && ((Behaviour) this.text_PageNum[index]).enabled)
      {
        ((Behaviour) this.text_PageNum[index]).enabled = false;
        ((Behaviour) this.text_PageNum[index]).enabled = true;
      }
    }
    for (int index = 0; index < 10; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    if ((Object) this.Pagedata[0] != (Object) null)
    {
      for (int index1 = 0; index1 < 6; ++index1)
      {
        if (this.text_ItembtnName[index1] != null)
        {
          for (int index2 = 0; index2 < 5; ++index2)
          {
            if ((Object) this.text_ItembtnName[index1][index2] != (Object) null && ((Behaviour) this.text_ItembtnName[index1][index2]).enabled)
            {
              ((Behaviour) this.text_ItembtnName[index1][index2]).enabled = false;
              ((Behaviour) this.text_ItembtnName[index1][index2]).enabled = true;
            }
          }
        }
      }
    }
    for (int index = 0; index < 11; ++index)
    {
      if ((Object) this.text_tmpItmeStr[index] != (Object) null && ((Behaviour) this.text_tmpItmeStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpItmeStr[index]).enabled = false;
        ((Behaviour) this.text_tmpItmeStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 15; ++index)
    {
      if ((Object) this.text_tmpItmeP2Str[index] != (Object) null && ((Behaviour) this.text_tmpItmeP2Str[index]).enabled)
      {
        ((Behaviour) this.text_tmpItmeP2Str[index]).enabled = false;
        ((Behaviour) this.text_tmpItmeP2Str[index]).enabled = true;
      }
    }
    if ((Object) this.Pagedata[0] != (Object) null)
    {
      if ((Object) this.m_text_Trans != (Object) null && ((Behaviour) this.m_text_Trans).enabled)
      {
        ((Behaviour) this.m_text_Trans).enabled = false;
        ((Behaviour) this.m_text_Trans).enabled = true;
      }
      if ((Object) this.m_text_Translation != (Object) null && ((Behaviour) this.m_text_Translation).enabled)
      {
        ((Behaviour) this.m_text_Translation).enabled = false;
        ((Behaviour) this.m_text_Translation).enabled = true;
      }
      for (int index3 = 0; index3 < 6; ++index3)
      {
        if (this.text_ItemName[index3] != null)
        {
          for (int index4 = 0; index4 < 2; ++index4)
          {
            if ((Object) this.text_ItemName[index3][index4] != (Object) null && ((Behaviour) this.text_ItemName[index3][index4]).enabled)
            {
              ((Behaviour) this.text_ItemName[index3][index4]).enabled = false;
              ((Behaviour) this.text_ItemName[index3][index4]).enabled = true;
            }
          }
        }
        if (this.text_ItemEffect[index3] != null)
        {
          for (int index5 = 0; index5 < 4; ++index5)
          {
            if ((Object) this.text_ItemEffect[index3][index5] != (Object) null && ((Behaviour) this.text_ItemEffect[index3][index5]).enabled)
            {
              ((Behaviour) this.text_ItemEffect[index3][index5]).enabled = false;
              ((Behaviour) this.text_ItemEffect[index3][index5]).enabled = true;
            }
          }
        }
        if ((Object) this.text_Item_Hint[index3] != (Object) null && (Object) this.text_Item_Hint[index3] != (Object) null && ((Behaviour) this.text_Item_Hint[index3]).enabled)
        {
          ((Behaviour) this.text_Item_Hint[index3]).enabled = false;
          ((Behaviour) this.text_Item_Hint[index3]).enabled = true;
        }
        if ((Object) this.text_Trans[index3] != (Object) null && (Object) this.text_Trans[index3] != (Object) null && ((Behaviour) this.text_Trans[index3]).enabled)
        {
          ((Behaviour) this.text_Trans[index3]).enabled = false;
          ((Behaviour) this.text_Trans[index3]).enabled = true;
        }
        if ((Object) this.text_Translation[index3] != (Object) null && (Object) this.text_Translation[index3] != (Object) null && ((Behaviour) this.text_Translation[index3]).enabled)
        {
          ((Behaviour) this.text_Translation[index3]).enabled = false;
          ((Behaviour) this.text_Translation[index3]).enabled = true;
        }
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.text_ItemCDtime[index] != (Object) null && ((Behaviour) this.text_ItemCDtime[index]).enabled)
      {
        ((Behaviour) this.text_ItemCDtime[index]).enabled = false;
        ((Behaviour) this.text_ItemCDtime[index]).enabled = true;
      }
      if ((Object) this.text_Item_K[index] != (Object) null && ((Behaviour) this.text_Item_K[index]).enabled)
      {
        ((Behaviour) this.text_Item_K[index]).enabled = false;
        ((Behaviour) this.text_Item_K[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.OpenInputCheck(false);
        this.bcheckInput = false;
        this.door.CloseMenu();
        break;
      case 1:
        if (!((Object) this.Pagedata[0] != (Object) null))
          break;
        if (this.DM.RoleAlliance.Bullet != null && this.DM.RoleAlliance.Bullet.Length != 0)
        {
          if ((Object) this.mInput != (Object) null)
            this.mInput.text = this.DM.RoleAlliance.Bullet;
          this.text_tmpItmeP2Str[11].text = this.DM.RoleAlliance.Bullet;
        }
        else if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        {
          if ((Object) this.text_Input1 != (Object) null)
            this.text_Input1.text = this.DM.mStringTable.GetStringByID(772U);
        }
        else
        {
          this.Cstr_Null.ClearString();
          if ((Object) this.text_Input1 != (Object) null)
            this.text_Input1.text = this.Cstr_Null.ToString();
          if ((Object) this.mInput != (Object) null)
            this.mInput.text = this.Cstr_Null.ToString();
          this.text_tmpItmeP2Str[11].text = this.Cstr_Null.ToString();
        }
        this.bShowTranslate = false;
        this.text_tmpItmeP2Str[11].SetAllDirty();
        this.text_tmpItmeP2Str[11].cachedTextGenerator.Invalidate();
        this.text_tmpItmeP2Str[11].cachedTextGeneratorForLayout.Invalidate();
        this.tmplist.Clear();
        for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
          this.tmplist.Add(93f);
        this.tmpTransH = 0.0f;
        if (IGGGameSDK.Instance.GetTranslateStatus() && (double) this.text_tmpItmeP2Str[11].preferredHeight > 120.0)
          this.tmplist.Add(this.tmpHeight + 40f);
        else
          this.tmplist.Add(this.tmpHeight);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if (this.tmplist.Count <= 1)
          ((Behaviour) this.m_ScrollRect).enabled = false;
        else
          ((Behaviour) this.m_ScrollRect).enabled = true;
        this.DM.bNeedTranslate_AA_Info = true;
        break;
      case 2:
        if (!((Object) this.mInput != (Object) null) || !((Component) this.mInput).transform.parent.parent.gameObject.activeSelf)
          break;
        if (!((Component) this.mInput).gameObject.activeSelf)
        {
          ((Component) this.m_text_Trans).gameObject.SetActive(false);
          ((Component) this.mInput).gameObject.SetActive(true);
        }
        this.mInput.ActivateInputField();
        break;
      case 3:
        if ((Object) this.Pagedata[2] != (Object) null)
        {
          this.text_HelpNum.text = this.DM.mHelpDataList.Count.ToString();
          this.text_HelpNum.SetAllDirty();
          this.text_HelpNum.cachedTextGenerator.Invalidate();
          this.text_HelpNum.cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.btnHelp_RT).gameObject.SetActive(true);
          this.btnHelp_RT.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_HelpNum.preferredWidth), this.btnHelp_RT.sizeDelta.y);
          if (this.DM.mHelpDataList.Count > 0)
            ((Component) this.btnHelp_RT).gameObject.SetActive(true);
          else
            ((Component) this.btnHelp_RT).gameObject.SetActive(false);
        }
        if (this.DM.mHelpDataList.Count > 0)
        {
          this.text_PageNum[2].text = this.DM.mHelpDataList.Count.ToString();
          this.text_PageNum[2].SetAllDirty();
          this.text_PageNum[2].cachedTextGenerator.Invalidate();
          this.text_PageNum[2].cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.PageImg_RT[2]).gameObject.SetActive(true);
          this.PageImg_RT[2].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[2].preferredWidth), this.PageImg_RT[2].sizeDelta.y);
          break;
        }
        ((Component) this.PageImg_RT[2]).gameObject.SetActive(false);
        break;
      case 4:
        if (this.MarshalInst != null)
          this.MarshalInst.UpdateUI(arg1, arg2);
        uint num1 = this.DM.ActiveRallyRecNum + this.DM.BeingRallyRecNum;
        if (num1 > 0U)
        {
          this.text_PageNum[1].text = num1.ToString();
          this.text_PageNum[1].SetAllDirty();
          this.text_PageNum[1].cachedTextGenerator.Invalidate();
          this.text_PageNum[1].cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.PageImg_RT[1]).gameObject.SetActive(true);
          this.PageImg_RT[1].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[1].preferredWidth), this.PageImg_RT[1].sizeDelta.y);
          break;
        }
        ((Component) this.PageImg_RT[1]).gameObject.SetActive(false);
        break;
      case 5:
        if ((Object) this.Pagedata[0] != (Object) null)
        {
          this.Cstr_GifeLV.ClearString();
          this.Cstr_GifeLV.IntToFormat((long) this.DM.RoleAlliance.GiftLv);
          this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631U));
          this.text_btnGife[1].text = this.Cstr_GifeLV.ToString();
          this.text_btnGife[1].SetAllDirty();
          this.text_btnGife[1].cachedTextGenerator.Invalidate();
          this.text_btnGife[0].text = this.DM.RoleAlliance.GiftNum.ToString();
          if (this.DM.RoleAlliance.GiftNum > (ushort) 0)
          {
            ((Component) this.btnGiftNum_RT[0]).gameObject.SetActive(true);
            this.btnGiftNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnGife[0].preferredWidth), this.btnGiftNum_RT[0].sizeDelta.y);
          }
          else
            ((Component) this.btnGiftNum_RT[0]).gameObject.SetActive(false);
        }
        int giftNum1 = (int) this.DM.RoleAlliance.GiftNum;
        long num2 = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
        if (num2 > 0L)
          giftNum1 += num2 <= 20L ? (int) num2 : 20;
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
          giftNum1 += (int) this.DM.RoleAlliance.Applicant;
        if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > (byte) 0)
          giftNum1 += (int) ActivityGiftManager.Instance.EnableRedPocketNum;
        if (giftNum1 > 0)
        {
          this.text_PageNum[0].text = giftNum1.ToString();
          ((Component) this.PageImg_RT[0]).gameObject.SetActive(true);
          this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
          break;
        }
        ((Component) this.PageImg_RT[0]).gameObject.SetActive(false);
        break;
      case 6:
        if (!((Object) this.Pagedata[0] != (Object) null))
          break;
        this.text_tmpItmeP2Str[11].text = this.DM.RoleAlliance.Bullet == null ? string.Empty : (this.bShowTranslate ? IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString() : this.DM.RoleAlliance.Bullet);
        this.text_tmpItmeP2Str[11].SetAllDirty();
        this.text_tmpItmeP2Str[11].cachedTextGenerator.Invalidate();
        this.text_tmpItmeP2Str[11].cachedTextGeneratorForLayout.Invalidate();
        this.tmplist.Clear();
        for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
          this.tmplist.Add(93f);
        this.tmpTransH = 0.0f;
        this.ResetEffectText();
        if (IGGGameSDK.Instance.GetTranslateStatus() && (double) this.text_tmpItmeP2Str[11].preferredHeight > 120.0)
          this.tmplist.Add(this.tmpHeight + 40f);
        else
          this.tmplist.Add(this.tmpHeight);
        if (this.tmplist.Count <= 1)
        {
          ((Behaviour) this.m_ScrollRect).enabled = false;
          this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        }
        else
        {
          ((Behaviour) this.m_ScrollRect).enabled = true;
          this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        }
        if (!((Object) this.img_InputBG != (Object) null))
          break;
        this.OpenInputCheck(false);
        this.bcheckInput = false;
        break;
      case 7:
        this.bShowTranslate = true;
        this.text_tmpItmeP2Str[11].text = IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString();
        this.text_tmpItmeP2Str[11].SetAllDirty();
        this.text_tmpItmeP2Str[11].cachedTextGenerator.Invalidate();
        this.text_tmpItmeP2Str[11].cachedTextGeneratorForLayout.Invalidate();
        this.tmplist.Clear();
        for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
          this.tmplist.Add(93f);
        this.tmpTransH = 0.0f;
        if ((double) this.text_tmpItmeP2Str[11].preferredHeight > 120.0)
          this.tmplist.Add(this.tmpHeight + 40f);
        else
          this.tmplist.Add(this.tmpHeight);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if (this.tmplist.Count <= 1)
        {
          ((Behaviour) this.m_ScrollRect).enabled = false;
          break;
        }
        ((Behaviour) this.m_ScrollRect).enabled = true;
        break;
      case 8:
        ((Component) this.m_btn_Translation).gameObject.SetActive(true);
        ((Component) this.m_Img_Translate).gameObject.SetActive(false);
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077U), (ushort) byte.MaxValue);
        break;
      case 9:
        this.m_text_ActivityGiftNum.text = ActivityGiftManager.Instance.EnableRedPocketNum.ToString();
        this.m_text_ActivityGiftNum.SetAllDirty();
        this.m_text_ActivityGiftNum.cachedTextGenerator.Invalidate();
        this.m_text_ActivityGiftNum.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.img_ActivityGift[0]).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_text_ActivityGiftNum.preferredWidth), ((Graphic) this.img_ActivityGift[0]).rectTransform.sizeDelta.y);
        this.CheckGiftBtnShow();
        int giftNum2 = (int) this.DM.RoleAlliance.GiftNum;
        long num3 = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
        if (num3 > 0L)
          giftNum2 += num3 <= 20L ? (int) num3 : 20;
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
          giftNum2 += (int) this.DM.RoleAlliance.Applicant;
        if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > (byte) 0)
          giftNum2 += (int) ActivityGiftManager.Instance.EnableRedPocketNum;
        if (giftNum2 > 0)
        {
          this.text_PageNum[0].text = giftNum2.ToString();
          ((Component) this.PageImg_RT[0]).gameObject.SetActive(true);
          this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
          break;
        }
        ((Component) this.PageImg_RT[0]).gameObject.SetActive(false);
        break;
      case 10:
        this.m_text_ActivityGiftNum.text = ActivityGiftManager.Instance.EnableRedPocketNum.ToString();
        this.m_text_ActivityGiftNum.SetAllDirty();
        this.m_text_ActivityGiftNum.cachedTextGenerator.Invalidate();
        this.m_text_ActivityGiftNum.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.img_ActivityGift[0]).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_text_ActivityGiftNum.preferredWidth), ((Graphic) this.img_ActivityGift[0]).rectTransform.sizeDelta.y);
        break;
      case 11:
        this.CheckGiftBtnShow();
        break;
    }
  }

  public void CheckGiftBtnShow()
  {
    if ((Object) this.Pagedata[0] == (Object) null || (Object) this.Pagedata[0] != (Object) null && !this.Pagedata[0].gameObject.activeSelf)
    {
      ((Component) this.btn_ActivityGift).gameObject.SetActive(false);
    }
    else
    {
      if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L || ActivityGiftManager.Instance.EnableRedPocketNum > (byte) 0)
      {
        ((Component) this.btn_ActivityGift).gameObject.SetActive(true);
        this.GUIM.SetFastivalImage(ActivityGiftManager.Instance.GroupID, (ushort) 4, this.btn_ActivityGift.image);
        this.btn_ActivityGift.image.SetNativeSize();
        this.btn_ActivityGift.image.type = (Image.Type) 0;
        if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
        {
          ((Component) this.img_ActivityGift[1]).gameObject.SetActive(true);
          ((Component) this.img_ActivityGift[0]).gameObject.SetActive(true);
          ((Component) this.m_text_ActivityGiftNum).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.img_ActivityGift[1]).gameObject.SetActive(false);
          if (ActivityGiftManager.Instance.EnableRedPocketNum > (byte) 0)
          {
            ((Component) this.m_text_ActivityGiftNum).gameObject.SetActive(true);
            ((Component) this.img_ActivityGift[0]).gameObject.SetActive(true);
          }
          else
            ((Component) this.img_ActivityGift[0]).gameObject.SetActive(false);
        }
      }
      else
        ((Component) this.btn_ActivityGift).gameObject.SetActive(false);
      if (!((Object) this.Pagedata[0] != (Object) null))
        return;
      RectTransform component = ((Component) this.btn_KHint).gameObject.GetComponent<RectTransform>();
      component.anchoredPosition = !((Component) this.btn_ActivityGift).gameObject.activeSelf ? new Vector2(144f, component.anchoredPosition.y) : new Vector2(214f, component.anchoredPosition.y);
      ((Graphic) this.text_Alliance_K).rectTransform.anchoredPosition = new Vector2(component.anchoredPosition.x + 50f, ((Graphic) this.text_Alliance_K).rectTransform.anchoredPosition.y);
      component.sizeDelta = new Vector2((float) (50.0 + (double) this.text_Alliance_K.preferredWidth + 1.0), component.sizeDelta.y);
    }
  }

  public void Update()
  {
    if (this.MarshalInst != null && this.mNowPage == 1)
      this.MarshalInst.Update();
    this.PageBGTime += Time.smoothDeltaTime;
    if ((double) this.PageBGTime >= 0.0 && this.mNowPage < this.img_PageBG.Length && (Object) this.img_PageBG[this.mNowPage] != (Object) null)
    {
      if ((double) this.PageBGTime >= 2.0)
        this.PageBGTime = 0.0f;
      ((Graphic) this.img_PageBG[this.mNowPage]).color = new Color(1f, 1f, 1f, (double) this.PageBGTime <= 1.0 ? this.PageBGTime : 2f - this.PageBGTime);
    }
    if (this.DM.bTranslate_AA_Info)
    {
      this.GUIM.UpdateUI(EGUIWindow.UI_Alliance_Info, 7);
      this.DM.bTranslate_AA_Info = false;
      this.DM.bNeedTranslate_AA_Info = false;
    }
    if (!this.DM.bTranslate_AA_InfoFailed)
      return;
    this.GUIM.UpdateUI(EGUIWindow.UI_Alliance_Info, 8);
    this.DM.bTranslate_AA_InfoFailed = false;
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.ItemPT1[index] != (Object) null && this.ItemPT1[index].gameObject.activeSelf && (Object) this.tmpItem[index] != (Object) null && this.DM.m_Wonders.Count > this.tmpItem[index].m_BtnID1 && this.tmpItem[index].m_BtnID1 >= 0)
      {
        this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].ClearString();
        long num1 = this.DM.m_Wonders[this.tmpItem[index].m_BtnID1].StateCountDown.BeginTime + (long) this.DM.m_Wonders[this.tmpItem[index].m_BtnID1].StateCountDown.RequireTime - this.DM.ServerTime;
        if (num1 > 0L)
        {
          if (num1 > 86400L)
          {
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].IntToFormat(num1 / 86400L);
            long num2 = num1 % 86400L;
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].IntToFormat(num2 / 3600L, 2);
            long num3 = num2 % 3600L;
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].IntToFormat(num3 / 60L, 2);
            long x = num3 % 60L;
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].IntToFormat(x, 2);
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].AppendFormat("{0}d {1}:{2}:{3}");
          }
          else
          {
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].IntToFormat(num1 / 3600L, 2);
            long num4 = num1 % 3600L;
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].IntToFormat(num4 / 60L, 2);
            long x = num4 % 60L;
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].IntToFormat(x, 2);
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].AppendFormat("{0}:{1}:{2}");
          }
        }
        else if (this.DM.m_Wonders[this.tmpItem[index].m_BtnID1].WonderID != (byte) 0)
        {
          if (this.DM.m_Wonders[this.tmpItem[index].m_BtnID1].OpenState == (byte) 0)
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].Append(DataManager.Instance.mStringTable.GetStringByID(9321U));
          else
            this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].Append(DataManager.Instance.mStringTable.GetStringByID(9314U));
        }
        else
          this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].Append(DataManager.Instance.mStringTable.GetStringByID(9320U));
        this.text_ItemCDtime[this.tmpItem[index].m_BtnID2].text = this.Cstr_Item_Time[this.tmpItem[index].m_BtnID2].ToString();
        this.text_ItemCDtime[this.tmpItem[index].m_BtnID2].SetAllDirty();
        this.text_ItemCDtime[this.tmpItem[index].m_BtnID2].cachedTextGenerator.Invalidate();
      }
    }
  }

  public void OpenInputCheck(bool bOpen)
  {
    if (bOpen)
    {
      ((Component) this.img_InputBG).transform.SetParent((Transform) this.GUIM.m_SecWindowLayer, false);
      ((Component) this.img_InputBG).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.img_InputBG).transform.SetParent(this.GameT, false);
      ((Component) this.img_InputBG).transform.SetSiblingIndex(5);
      ((Component) this.img_InputBG).gameObject.SetActive(false);
    }
  }

  public override bool OnBackButtonClick()
  {
    if (((UIBehaviour) this.img_InputBG).IsActive())
    {
      this.OpenInputCheck(false);
      this.bcheckInput = false;
    }
    return false;
  }
}
