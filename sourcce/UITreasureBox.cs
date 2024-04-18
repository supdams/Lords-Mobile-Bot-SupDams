// Decompiled with JetBrains decompiler
// Type: UITreasureBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UITreasureBox : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform P1_T;
  private Transform P2_T;
  private Transform P3_T;
  private Transform P4_T;
  private Transform P5_T;
  private Transform P6_T;
  private Transform P7_T;
  private Transform P8_T;
  private Transform P9_T;
  private Transform P10_T;
  private Transform LightP1_T;
  private Transform Light1_T;
  private Transform Light2_T;
  private Transform Hero_Pos;
  private Transform Hero_Model;
  private Transform mCount1_T;
  private Transform mCount2_T;
  private RectTransform Info_RT;
  private UIButton btn_EXIT;
  private UIButton btn_OK;
  private UIButton btn_Get;
  private UIButton btn_Score;
  private UIButton btn_GOTOFB;
  private UIButton btn_ArenaReward;
  private UIButton btn_CardReward;
  private UIButton btn_box2Reward;
  private UIHIBtn Hbtn_Item;
  private UIHIBtn Hbtn_Item2;
  private UIHIBtn[] Hbtn_Items = new UIHIBtn[7];
  private Image Img_5X;
  private Image Img_ItemInfo;
  private UIText text_Title;
  private UIText text_Info;
  private UIText text_Time;
  private UIText text_Count;
  private UIText text_Get;
  private UIText[] text_Get2 = new UIText[2];
  private UIText text_HeroName;
  private UIText text_HeroTitle;
  private UIText text_GetType;
  private UIText text_Score;
  private UIText text_ArenaReward;
  private UIText text_ArenaRewardNum;
  private UIText text_ArenaReward_Get;
  private UIText text_ScoreStr;
  private UIText[] text_tmpStr = new UIText[6];
  private UIText[] text_Arena = new UIText[2];
  private UIText[] text_Cards = new UIText[9];
  private UIText[] text_P10Str = new UIText[4];
  private CString Cstr_Time;
  private CString Cstr_Count;
  private CString Cstr_Info;
  private CString Cstr_Info2;
  private CString Cstr_Get;
  private CString[] Cstr_Get2 = new CString[2];
  private CString Cstr_Score;
  private CString[] Cstr_Items = new CString[9];
  private CString Cstr_P10Time;
  private CString Cstr_P10Num;
  private DataManager DM;
  private GUIManager GUIM;
  private MallManager MM;
  private Font TTFont;
  public int mKind;
  public int mGetType;
  private GameObject go2;
  private int AssetKey;
  private float ActionTime;
  private float ActionTimeRandom;
  private float MovingTimer;
  private Hero sHero;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool ABIsDone;
  private string HeroAct;
  private Animation tmpAN;
  public string[] mHeroAct = new string[7];
  private UIButton btn_Indemnify;
  private UIText[] TextIndemnify = new UIText[4];
  private CString[] CStr_Indemnify = new CString[4];
  private string[] ResIcon = new string[4]
  {
    "UI_main_res_food",
    "UI_main_res_stone",
    "UI_main_res_wood",
    "UI_main_res_iron"
  };
  private float[] tmpfValue = new float[3];
  private Door door;
  private UIText BtnName;
  private HelperUIButton OutsideExitBtn;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.MM = MallManager.Instance;
    this.TTFont = this.GUIM.GetTTFFont();
    this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    this.GameT = this.gameObject.transform;
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.GameT.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.GameT.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Cstr_Time = StringManager.Instance.SpawnString();
    this.Cstr_Count = StringManager.Instance.SpawnString(150);
    this.Cstr_Info = StringManager.Instance.SpawnString(100);
    this.Cstr_Info2 = StringManager.Instance.SpawnString();
    this.Cstr_Get = StringManager.Instance.SpawnString();
    this.Cstr_Get2[0] = StringManager.Instance.SpawnString();
    this.Cstr_Get2[1] = StringManager.Instance.SpawnString(150);
    this.Cstr_Score = StringManager.Instance.SpawnString(150);
    for (int index = 0; index < 8; ++index)
      this.Cstr_Items[index] = StringManager.Instance.SpawnString();
    this.Cstr_Items[8] = StringManager.Instance.SpawnString(150);
    this.Cstr_P10Time = StringManager.Instance.SpawnString(150);
    this.Cstr_P10Num = StringManager.Instance.SpawnString();
    this.mKind = arg1;
    this.mGetType = arg2;
    Array.Clear((Array) this.tmpfValue, 0, this.tmpfValue.Length);
    this.P1_T = this.GameT.GetChild(0);
    this.LightP1_T = this.P1_T.GetChild(0);
    this.Tmp = this.P1_T.GetChild(2).GetChild(0);
    this.text_Time = this.Tmp.GetComponent<UIText>();
    this.text_Time.font = this.TTFont;
    this.Tmp = this.P1_T.GetChild(3).GetChild(0);
    this.text_Count = this.Tmp.GetComponent<UIText>();
    this.text_Count.font = this.TTFont;
    this.Tmp = this.P1_T.GetChild(4);
    this.btn_OK = this.Tmp.GetComponent<UIButton>();
    this.btn_OK.m_Handler = (IUIButtonClickHandler) this;
    this.btn_OK.m_BtnID1 = 1;
    this.btn_OK.m_EffectType = e_EffectType.e_Scale;
    this.btn_OK.transition = (Selectable.Transition) 0;
    this.Tmp = this.P1_T.GetChild(4).GetChild(0);
    this.text_tmpStr[0] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7671U);
    this.P2_T = this.GameT.GetChild(1);
    this.Tmp = this.P2_T.GetChild(3);
    this.Hbtn_Item = this.Tmp.GetComponent<UIHIBtn>();
    this.Hbtn_Item.m_Handler = (IUIHIBtnClickHandler) this;
    this.Tmp = this.P2_T.GetChild(4);
    this.btn_Get = this.Tmp.GetComponent<UIButton>();
    this.btn_Get.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Get.m_BtnID1 = 2;
    this.btn_Get.m_EffectType = e_EffectType.e_Scale;
    this.btn_Get.transition = (Selectable.Transition) 0;
    this.Tmp = this.P2_T.GetChild(4).GetChild(0);
    this.text_tmpStr[1] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7693U);
    this.mCount1_T = this.P2_T.GetChild(5);
    this.text_Get2[0] = this.mCount1_T.GetChild(0).GetComponent<UIText>();
    this.text_Get2[0].font = this.TTFont;
    this.text_Get2[1] = this.mCount1_T.GetChild(1).GetComponent<UIText>();
    this.text_Get2[1].font = this.TTFont;
    this.mCount2_T = this.P2_T.GetChild(6);
    this.text_Get = this.mCount2_T.GetChild(0).GetComponent<UIText>();
    this.text_Get.font = this.TTFont;
    this.P3_T = this.GameT.GetChild(2);
    this.P4_T = this.GameT.GetChild(3);
    this.P5_T = this.GameT.GetChild(4);
    this.P6_T = this.GameT.GetChild(5);
    this.P7_T = this.GameT.GetChild(6);
    this.P8_T = this.GameT.GetChild(7);
    this.P9_T = this.GameT.GetChild(8);
    this.P10_T = this.GameT.GetChild(9);
    int index1 = this.GameT.childCount - 1;
    this.Tmp = this.GameT.GetChild(index1).GetChild(0);
    this.Img_5X = this.Tmp.GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_5X).gameObject.AddComponent<ArabicItemTextureRot>();
    this.Tmp = this.GameT.GetChild(index1).GetChild(1);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(index1).GetChild(2);
    this.text_Title = this.Tmp.GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(7669U);
    this.Tmp = this.GameT.GetChild(index1).GetChild(3);
    this.text_Info = this.Tmp.GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.Info_RT = this.Tmp.GetComponent<RectTransform>();
    this.OutsideExitBtn = this.gameObject.AddComponent<HelperUIButton>();
    this.OutsideExitBtn.m_Handler = (IUIButtonClickHandler) this;
    this.OutsideExitBtn.m_BtnID1 = 0;
    this.OutsideExitBtn.enabled = false;
    switch (this.mKind)
    {
      case 0:
        this.OutsideExitBtn.enabled = true;
        this.P1_T.gameObject.SetActive(true);
        this.Cstr_Time.ClearString();
        GameConstants.GetTimeString(this.Cstr_Time, (uint) (this.DM.RoleAttr.NextOnlineGiftOpenTime - this.DM.ServerTime));
        this.text_Time.text = this.Cstr_Time.ToString();
        this.text_Time.SetAllDirty();
        this.text_Time.cachedTextGenerator.Invalidate();
        this.Cstr_Count.ClearString();
        if (this.DM.RoleAttr.OnlineGiftOpenTimes == (byte) 19)
        {
          ((Component) this.Img_5X).gameObject.SetActive(true);
          this.Cstr_Count.Append(this.DM.mStringTable.GetStringByID(8258U));
        }
        else
        {
          this.Cstr_Count.IntToFormat((long) (20 - (int) this.DM.RoleAttr.OnlineGiftOpenTimes), bNumber: true);
          this.Cstr_Count.AppendFormat(this.DM.mStringTable.GetStringByID(7677U));
        }
        this.text_Count.text = this.Cstr_Count.ToString();
        this.text_Count.SetAllDirty();
        this.text_Count.cachedTextGenerator.Invalidate();
        this.text_Info.text = this.DM.mStringTable.GetStringByID(7670U);
        this.text_Info.SetAllDirty();
        this.text_Info.cachedTextGenerator.Invalidate();
        break;
      case 1:
      case 2:
        this.TimeOutSet();
        break;
      case 3:
        this.SetHeroPage((ushort) arg2);
        GUIManager.Instance.LoadLvUpLight(this.transform);
        break;
      case 4:
        this.SetScore();
        break;
      case 5:
        this.SetFB_Reward();
        break;
      case 6:
        ((Component) this.btn_EXIT).gameObject.SetActive(false);
        this.SetHeroPage(true);
        GUIManager.Instance.LoadLvUpLight(this.transform);
        break;
      case 7:
        ((Component) this.btn_EXIT).gameObject.SetActive(false);
        this.SetHeroPage(false);
        GUIManager.Instance.LoadLvUpLight(this.transform);
        break;
      case 8:
        ((Component) this.btn_EXIT).gameObject.SetActive(false);
        this.P1_T.gameObject.SetActive(false);
        this.P2_T.gameObject.SetActive(false);
        this.P3_T.gameObject.SetActive(true);
        this.Light1_T = this.P3_T.GetChild(0);
        this.Light2_T = this.P3_T.GetChild(1);
        this.Tmp = this.P3_T.GetChild(3);
        this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
        this.Hbtn_Item2.m_Handler = (IUIHIBtnClickHandler) this;
        ((Component) this.Hbtn_Item2).gameObject.SetActive(false);
        this.Tmp = this.P3_T.GetChild(4);
        this.Tmp.gameObject.SetActive(true);
        this.Tmp = this.P3_T.GetChild(5);
        this.text_GetType = this.Tmp.GetComponent<UIText>();
        this.text_GetType.font = this.TTFont;
        ((Component) this.text_GetType).gameObject.SetActive(false);
        this.Cstr_Info.ClearString();
        this.text_Title.text = this.DM.mStringTable.GetStringByID(7385U);
        this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID(3393U));
        this.Cstr_Info.AppendFormat("{0}");
        this.text_Info.text = this.Cstr_Info.ToString();
        this.text_Info.SetAllDirty();
        this.text_Info.cachedTextGenerator.Invalidate();
        GUIManager.Instance.LoadLvUpLight(this.transform);
        break;
      case 9:
        this.OutsideExitBtn.enabled = true;
        this.P7_T.gameObject.SetActive(true);
        this.LightP1_T = this.P7_T.GetChild(0);
        this.text_Title.text = this.DM.mStringTable.GetStringByID(9141U);
        this.text_Time = this.P7_T.GetChild(1).GetChild(0).GetComponent<UIText>();
        this.Cstr_Time.ClearString();
        this.text_Time.font = this.TTFont;
        this.Cstr_Time.ClearString();
        DateTime universalTime = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime();
        uint num = 10800U - (universalTime.Hour - 5 >= 0 ? (uint) ((universalTime.Hour - 5) * 3600 + universalTime.Minute * 60 + universalTime.Second) : (uint) ((universalTime.Hour + 19) * 3600 + universalTime.Minute * 60 + universalTime.Second)) % 10800U;
        this.Cstr_Time.IntToFormat((long) (num / 3600U), 2);
        this.Cstr_Time.IntToFormat((long) (num % 3600U / 60U), 2);
        this.Cstr_Time.IntToFormat((long) (num % 60U), 2);
        this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
        this.text_Time.text = this.Cstr_Time.ToString();
        this.text_Time.SetAllDirty();
        this.text_Time.cachedTextGenerator.Invalidate();
        Image component1 = this.P7_T.GetChild(2).GetComponent<Image>();
        this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
        component1.sprite = this.door.LoadSprite("UI_main_money_02");
        ((MaskableGraphic) component1).material = this.door.LoadMaterial();
        this.text_Arena[0] = this.P7_T.GetChild(2).GetChild(0).GetComponent<UIText>();
        this.text_Arena[0].font = this.TTFont;
        this.text_Arena[0].text = this.DM.mStringTable.GetStringByID(9158U);
        if ((double) this.text_Arena[0].preferredWidth > (double) ((Graphic) this.text_Arena[0]).rectTransform.sizeDelta.x)
        {
          if ((double) this.text_Arena[0].preferredWidth <= 230.0)
            ((Graphic) this.text_Arena[0]).rectTransform.sizeDelta = new Vector2(this.text_Arena[0].preferredWidth, ((Graphic) this.text_Arena[0]).rectTransform.sizeDelta.y);
          else
            ((Graphic) this.text_Arena[0]).rectTransform.sizeDelta = new Vector2(230f, ((Graphic) this.text_Arena[0]).rectTransform.sizeDelta.y);
          if ((double) this.text_Arena[0].preferredWidth > 160.0)
            ((Graphic) component1).rectTransform.anchoredPosition = new Vector2(((Graphic) component1).rectTransform.anchoredPosition.x + (float) (((double) this.text_Arena[0].preferredWidth - 100.0) / 2.0), ((Graphic) component1).rectTransform.anchoredPosition.y);
        }
        if (ArenaManager.Instance.CheckArenaClose() > (ushort) 0)
        {
          ((Component) this.text_Time).transform.parent.gameObject.SetActive(false);
          ((Component) this.text_Arena[0]).transform.parent.gameObject.SetActive(false);
        }
        this.text_Arena[1] = this.P7_T.GetChild(2).GetChild(1).GetComponent<UIText>();
        this.text_Arena[1].font = this.TTFont;
        uint nowCrystal = (uint) ArenaManager.Instance.GetNowCrystal();
        this.Cstr_Info.ClearString();
        this.Cstr_Info.IntToFormat((long) nowCrystal, bNumber: true);
        this.Cstr_Info.AppendFormat("{0}");
        this.text_Arena[1].text = this.Cstr_Info.ToString();
        this.btn_ArenaReward = this.P7_T.GetChild(3).GetComponent<UIButton>();
        this.btn_ArenaReward.m_Handler = (IUIButtonClickHandler) this;
        this.btn_ArenaReward.m_BtnID1 = 5;
        this.btn_ArenaReward.m_EffectType = e_EffectType.e_Scale;
        this.btn_ArenaReward.transition = (Selectable.Transition) 0;
        this.text_ArenaReward = this.P7_T.GetChild(3).GetChild(0).GetComponent<UIText>();
        this.text_ArenaReward.font = this.TTFont;
        this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(9143U);
        this.Hbtn_Item2 = this.P7_T.GetChild(4).GetComponent<UIHIBtn>();
        this.Hbtn_Item2.m_Handler = (IUIHIBtnClickHandler) this;
        this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, (ushort) 1224, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
        this.text_ArenaRewardNum = this.P7_T.GetChild(5).GetComponent<UIText>();
        this.text_ArenaRewardNum.font = this.TTFont;
        this.Cstr_Info2.ClearString();
        this.Cstr_Info2.IntToFormat((long) ArenaManager.Instance.m_ArenaCrystalPrize, bNumber: true);
        this.Cstr_Info2.AppendFormat("{0}");
        this.text_ArenaRewardNum.text = this.Cstr_Info2.ToString();
        this.text_ArenaRewardNum.SetAllDirty();
        this.text_ArenaRewardNum.cachedTextGenerator.Invalidate();
        ((Component) this.text_ArenaRewardNum).gameObject.SetActive(true);
        this.text_ArenaReward_Get = this.P7_T.GetChild(6).GetComponent<UIText>();
        this.text_ArenaReward_Get.font = this.TTFont;
        if (ArenaManager.Instance.m_ArenaCrystalPrize > 0U)
        {
          this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(9143U);
          this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9142U);
          ((Component) this.text_ArenaRewardNum).gameObject.SetActive(true);
        }
        else
        {
          this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(7671U);
          this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9164U);
          ((Component) this.text_ArenaRewardNum).gameObject.SetActive(false);
        }
        this.text_ArenaReward.SetAllDirty();
        this.text_ArenaReward.cachedTextGenerator.Invalidate();
        this.text_ArenaReward_Get.SetAllDirty();
        this.text_ArenaReward_Get.cachedTextGenerator.Invalidate();
        break;
      case 10:
        this.OutsideExitBtn.enabled = true;
        this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
        this.RefreshIndemnifyResources();
        for (int index2 = 0; index2 < 4; ++index2)
        {
          Image component2 = this.P8_T.GetChild(1 + index2).GetComponent<Image>();
          this.LoadCustomImage(component2, this.ResIcon[index2], (string) null);
          component2.SetNativeSize();
        }
        this.btn_Indemnify = this.P8_T.GetChild(0).GetComponent<UIButton>();
        this.btn_Indemnify.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Indemnify.m_BtnID1 = 6;
        this.BtnName = this.P8_T.GetChild(0).GetChild(0).GetComponent<UIText>();
        this.BtnName.font = this.TTFont;
        this.BtnName.text = this.DM.mStringTable.GetStringByID(1520U);
        this.text_Title.text = this.DM.mStringTable.GetStringByID(8594U);
        this.P8_T.gameObject.SetActive(true);
        break;
      case 11:
        this.OutsideExitBtn.enabled = true;
        this.btn_CardReward = this.P9_T.GetChild(0).GetComponent<UIButton>();
        this.btn_CardReward.m_Handler = (IUIButtonClickHandler) this;
        this.btn_CardReward.m_BtnID1 = 7;
        this.btn_CardReward.m_EffectType = e_EffectType.e_Scale;
        this.btn_CardReward.transition = (Selectable.Transition) 0;
        this.BtnName = this.P9_T.GetChild(0).GetChild(0).GetComponent<UIText>();
        this.BtnName.font = this.TTFont;
        this.BtnName.text = this.DM.mStringTable.GetStringByID(1520U);
        this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
        Image component3 = this.P9_T.GetChild(1).GetComponent<Image>();
        component3.sprite = this.door.LoadSprite("UI_main_money_02_big");
        ((MaskableGraphic) component3).material = this.door.LoadMaterial();
        component3.SetNativeSize();
        this.text_Cards[0] = this.P9_T.GetChild(1).GetChild(0).GetComponent<UIText>();
        this.text_Cards[0].font = this.TTFont;
        this.Cstr_Items[0].ClearString();
        this.Cstr_Items[0].IntToFormat((long) this.MM.mMonthTreasureCrystal);
        this.Cstr_Items[0].AppendFormat("{0}");
        this.text_Cards[0].text = this.Cstr_Items[0].ToString();
        for (int index3 = 0; index3 < 7; ++index3)
        {
          this.Hbtn_Items[index3] = this.P9_T.GetChild(2 + index3).GetComponent<UIHIBtn>();
          this.Hbtn_Items[index3].m_Handler = (IUIHIBtnClickHandler) this;
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Items[index3]).transform, eHeroOrItem.Item, this.MM.mMonthTreasureItem[index3].ItemID, (byte) 0, this.MM.mMonthTreasureItem[index3].ItemRank);
          this.text_Cards[index3 + 1] = this.P9_T.GetChild(9 + index3).GetComponent<UIText>();
          this.text_Cards[index3 + 1].font = this.TTFont;
          this.Cstr_Items[index3 + 1].ClearString();
          this.Cstr_Items[index3 + 1].IntToFormat((long) this.MM.mMonthTreasureItem[index3].Num);
          if (this.GUIM.IsArabic)
            this.Cstr_Items[index3 + 1].AppendFormat("{0}x");
          else
            this.Cstr_Items[index3 + 1].AppendFormat("x{0}");
          this.text_Cards[index3 + 1].text = this.Cstr_Items[index3 + 1].ToString();
        }
        this.Cstr_Items[8].ClearString();
        this.text_Cards[8] = this.P9_T.GetChild(16).GetComponent<UIText>();
        this.text_Cards[8].font = this.TTFont;
        if (this.MM.BuyMonthTreasureTime != 0L && this.MM.LastGetMonthTreasurePrizeTime == 0L)
          this.Cstr_Items[8].IntToFormat(30L, bNumber: true);
        else
          this.Cstr_Items[8].IntToFormat(29L - (this.MM.LastGetMonthTreasurePrizeTime - this.MM.BuyMonthTreasureTime) / 86400L, bNumber: true);
        this.Cstr_Items[8].AppendFormat(this.DM.mStringTable.GetStringByID(922U));
        this.text_Cards[8].text = this.Cstr_Items[8].ToString();
        this.text_Cards[8].SetAllDirty();
        this.text_Cards[8].cachedTextGenerator.Invalidate();
        this.P9_T.gameObject.SetActive(true);
        this.text_Title.text = this.DM.mStringTable.GetStringByID(921U);
        break;
      case 12:
        this.SetHeroPage();
        ((Component) this.Img_5X).transform.parent.gameObject.SetActive(false);
        break;
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (!(bool) (UnityEngine.Object) this.door)
      return;
    img.sprite = this.door.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = this.door.LoadMaterial();
  }

  public void RefreshIndemnifyResources()
  {
    if (this.mKind != 10)
      return;
    Indemnify instance = Indemnify.Instance;
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.TextIndemnify[index] == (UnityEngine.Object) null)
      {
        this.TextIndemnify[index] = this.P8_T.GetChild(5 + index).GetComponent<UIText>();
        this.TextIndemnify[index].font = this.TTFont;
        this.TextIndemnify[index].resizeTextForBestFit = true;
        this.TextIndemnify[index].resizeTextMaxSize = 24;
      }
      if (this.CStr_Indemnify[index] == null)
        this.CStr_Indemnify[index] = StringManager.Instance.SpawnString();
      if (instance.ResourceCache[index] != 0L)
      {
        this.CStr_Indemnify[index].ClearString();
        this.CStr_Indemnify[index].IntToFormat(instance.ResourceCache[index], bNumber: true);
        this.CStr_Indemnify[index].AppendFormat("{0}");
        this.TextIndemnify[index].text = this.CStr_Indemnify[index].ToString();
      }
      else
        this.TextIndemnify[index].text = "-";
      this.TextIndemnify[index].SetAllDirty();
      this.TextIndemnify[index].cachedTextGenerator.Invalidate();
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.mKind == 0)
    {
      long sec = this.DM.RoleAttr.NextOnlineGiftOpenTime - this.DM.ServerTime;
      if (sec <= 0L)
      {
        this.mKind = 1;
        this.TimeOutSet();
      }
      this.Cstr_Time.ClearString();
      GameConstants.GetTimeString(this.Cstr_Time, (uint) sec);
      this.text_Time.text = this.Cstr_Time.ToString();
      this.text_Time.SetAllDirty();
      this.text_Time.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (this.mKind != 9 || ArenaManager.Instance.bArenaKVK)
        return;
      DateTime universalTime = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime();
      this.Cstr_Time.ClearString();
      uint num = 10800U - (universalTime.Hour - 5 >= 0 ? (uint) ((universalTime.Hour - 5) * 3600 + universalTime.Minute * 60 + universalTime.Second) : (uint) ((universalTime.Hour + 19) * 3600 + universalTime.Minute * 60 + universalTime.Second)) % 10800U;
      this.Cstr_Time.IntToFormat((long) (num / 3600U), 2);
      this.Cstr_Time.IntToFormat((long) (num % 3600U / 60U), 2);
      this.Cstr_Time.IntToFormat((long) (num % 60U), 2);
      this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
      this.text_Time.text = this.Cstr_Time.ToString();
      this.text_Time.SetAllDirty();
      this.text_Time.cachedTextGenerator.Invalidate();
    }
  }

  public void TimeOutSet()
  {
    if (this.mKind == 1)
    {
      this.P1_T.gameObject.SetActive(false);
      this.P2_T.gameObject.SetActive(true);
      this.Cstr_Info.ClearString();
      switch (this.mGetType)
      {
        case 0:
          this.OutsideExitBtn.enabled = true;
          this.DM.TreasureBox_CDTime = 0.0f;
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item).transform, eHeroOrItem.Item, this.DM.EquipTable.GetRecordByKey(this.DM.RoleAttr.OnlineGiftItemID.ItemID).EquipKey, (byte) 0, (byte) 0);
          if (this.DM.RoleAttr.OnlineGiftOpenTimes == (byte) 19)
            ((Component) this.Img_5X).gameObject.SetActive(true);
          this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.DM.RoleAttr.OnlineGiftItemID.ItemID).EquipName));
          this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(7675U));
          if (this.DM.RoleAttr.OnlineGiftItemID.Quantity > (ushort) 1)
          {
            if (this.DM.RoleAttr.OnlineGiftOpenTimes == (byte) 19)
            {
              this.mCount1_T.gameObject.SetActive(false);
              this.mCount2_T.gameObject.SetActive(true);
              this.Cstr_Get.ClearString();
              this.Cstr_Get.IntToFormat((long) this.DM.RoleAttr.OnlineGiftItemID.Quantity, bNumber: true);
              this.Cstr_Get.AppendFormat(this.DM.mStringTable.GetStringByID(7676U));
              this.text_Get.text = this.Cstr_Get.ToString();
              this.text_Get.SetAllDirty();
              this.text_Get.cachedTextGenerator.Invalidate();
            }
            else
            {
              this.mCount1_T.gameObject.SetActive(true);
              this.mCount2_T.gameObject.SetActive(false);
              this.Cstr_Get2[0].ClearString();
              this.Cstr_Get2[0].IntToFormat((long) this.DM.RoleAttr.OnlineGiftItemID.Quantity, bNumber: true);
              this.Cstr_Get2[0].AppendFormat(this.DM.mStringTable.GetStringByID(7676U));
              this.text_Get2[0].text = this.Cstr_Get2[0].ToString();
              this.text_Get2[0].SetAllDirty();
              this.text_Get2[0].cachedTextGenerator.Invalidate();
            }
          }
          if (this.DM.RoleAttr.OnlineGiftOpenTimes != (byte) 19)
          {
            this.Cstr_Get2[1].ClearString();
            this.Cstr_Get2[1].IntToFormat((long) (20 - (int) this.DM.RoleAttr.OnlineGiftOpenTimes), bNumber: true);
            this.Cstr_Get2[1].AppendFormat(this.DM.mStringTable.GetStringByID(7677U));
            this.text_Get2[1].text = this.Cstr_Get2[1].ToString();
            this.text_Get2[1].SetAllDirty();
            this.text_Get2[1].cachedTextGenerator.Invalidate();
            break;
          }
          break;
        case 1:
          this.Cstr_Info.IntToFormat((long) this.DM.m_Maintain);
          this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473U));
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item).transform, eHeroOrItem.Item, (ushort) 1224, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8406U);
          this.mCount1_T.gameObject.SetActive(false);
          this.mCount2_T.gameObject.SetActive(true);
          this.text_Get.text = this.DM.mStringTable.GetStringByID(8472U).ToString();
          this.text_Get.SetAllDirty();
          this.text_Get.cachedTextGenerator.Invalidate();
          break;
        case 2:
          this.Cstr_Info.IntToFormat((long) this.DM.m_UpdateVersion);
          this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473U));
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item).transform, eHeroOrItem.Item, (ushort) 1224, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8406U);
          this.mCount1_T.gameObject.SetActive(false);
          this.mCount2_T.gameObject.SetActive(true);
          this.text_Get.text = this.DM.mStringTable.GetStringByID(8471U).ToString();
          this.text_Get.SetAllDirty();
          this.text_Get.cachedTextGenerator.Invalidate();
          break;
      }
      this.Light1_T = this.P2_T.GetChild(0);
      this.Light2_T = this.P2_T.GetChild(1);
    }
    else if (this.mKind == 2)
    {
      this.P1_T.gameObject.SetActive(false);
      this.P2_T.gameObject.SetActive(false);
      this.P3_T.gameObject.SetActive(true);
      this.Light1_T = this.P3_T.GetChild(0);
      this.Light2_T = this.P3_T.GetChild(1);
      this.Tmp = this.P3_T.GetChild(3);
      this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
      this.Hbtn_Item2.m_Handler = (IUIHIBtnClickHandler) this;
      this.Tmp = this.P3_T.GetChild(5);
      this.text_GetType = this.Tmp.GetComponent<UIText>();
      this.text_GetType.font = this.TTFont;
      this.Cstr_Info.ClearString();
      GUIManager instance = GUIManager.Instance;
      switch (this.mGetType)
      {
        case 0:
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, (ushort) 1228, (byte) 0, (byte) 0);
          this.text_GetType.text = this.DM.mStringTable.GetStringByID(748U);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8406U);
          this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey((ushort) 1228).EquipName));
          this.Cstr_Info.AppendFormat("{0}");
          instance.m_SpeciallyEffect.mDiamondValue = 250U;
          break;
        case 1:
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, (ushort) 1226, (byte) 0, (byte) 0);
          this.text_GetType.text = this.DM.mStringTable.GetStringByID(8419U);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8406U);
          this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey((ushort) 1226).EquipName));
          this.Cstr_Info.AppendFormat("{0}");
          instance.m_SpeciallyEffect.mDiamondValue = 200U;
          break;
        case 2:
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, (ushort) 1226, (byte) 0, (byte) 0);
          this.text_GetType.text = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? this.DM.mStringTable.GetStringByID(7386U) : this.DM.mStringTable.GetStringByID(11175U);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(7385U);
          if ((double) this.text_GetType.preferredWidth > 200.0)
          {
            ((Graphic) this.text_GetType).rectTransform.sizeDelta = new Vector2(340f, ((Graphic) this.text_GetType).rectTransform.sizeDelta.y);
            if ((double) this.text_GetType.preferredWidth > 340.0)
              ((Graphic) this.text_GetType).rectTransform.sizeDelta = new Vector2(340f, this.text_GetType.preferredHeight + 1f);
          }
          this.text_GetType.alignment = TextAnchor.MiddleLeft;
          RectTransform component1 = this.P3_T.GetComponent<RectTransform>();
          component1.sizeDelta = new Vector2(component1.sizeDelta.x, (float) ((double) component1.sizeDelta.y + (double) this.text_GetType.preferredHeight + 1.0 - 33.0));
          this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey((ushort) 1226).EquipName));
          this.Cstr_Info.AppendFormat("{0}");
          instance.m_SpeciallyEffect.mDiamondValue = 200U;
          break;
        case 3:
          this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, (ushort) 1226, (byte) 0, (byte) 0);
          this.text_GetType.text = this.DM.mStringTable.GetStringByID(7388U);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(7385U);
          if ((double) this.text_GetType.preferredWidth > 200.0)
          {
            ((Graphic) this.text_GetType).rectTransform.sizeDelta = new Vector2(340f, ((Graphic) this.text_GetType).rectTransform.sizeDelta.y);
            if ((double) this.text_GetType.preferredWidth > 340.0)
              ((Graphic) this.text_GetType).rectTransform.sizeDelta = new Vector2(340f, this.text_GetType.preferredHeight + 1f);
          }
          this.text_GetType.alignment = TextAnchor.MiddleLeft;
          RectTransform component2 = this.P3_T.GetComponent<RectTransform>();
          component2.sizeDelta = new Vector2(component2.sizeDelta.x, (float) ((double) component2.sizeDelta.y + (double) this.text_GetType.preferredHeight + 1.0 - 33.0));
          this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey((ushort) 1226).EquipName));
          this.Cstr_Info.AppendFormat("{0}");
          instance.m_SpeciallyEffect.mDiamondValue = 200U;
          break;
      }
      int index = 0;
      Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
      instance.SE_Kind[index] = SpeciallyEffect_Kind.Diamond;
      int num = index + 1;
      Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
      instance.mStartV2 = new Vector2(((Component) instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2f, ((Component) instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y / 2f);
      instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID);
    }
    this.text_Info.text = this.Cstr_Info.ToString();
    this.text_Info.SetAllDirty();
    this.text_Info.cachedTextGenerator.Invalidate();
  }

  public void SetHeroPage(ushort HeroID)
  {
    this.GUIM.m_UICanvas.renderMode = (RenderMode) 1;
    this.GUIM.SetCanvasChanged();
    DataManager.msgBuffer[0] = (byte) 84;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    AudioManager.Instance.PlayUISFX(UIKind.CompleteImmediate);
    this.P4_T.gameObject.SetActive(true);
    this.Hero_Pos = this.P4_T.GetChild(0);
    this.text_HeroName = this.P4_T.GetChild(2).GetComponent<UIText>();
    this.text_HeroName.font = this.TTFont;
    this.text_HeroTitle = this.P4_T.GetChild(1).GetComponent<UIText>();
    this.text_HeroTitle.font = this.TTFont;
    this.mHeroAct[0] = "idle";
    this.mHeroAct[1] = "moving";
    this.mHeroAct[2] = "attack";
    this.mHeroAct[3] = "skill_1";
    this.mHeroAct[4] = "skill_2";
    this.mHeroAct[5] = "skill_3";
    this.mHeroAct[6] = "victory";
    this.sHero = this.DM.HeroTable.GetRecordByKey(HeroID);
    this.text_HeroName.text = this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroName);
    this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroTitle);
    this.LoadHero3D();
    this.text_Title.text = this.DM.mStringTable.GetStringByID(6U);
    this.text_Title.fontSize = 50;
    this.text_Title.resizeTextMaxSize = 50;
    RectTransform component = ((Component) this.text_Title).transform.GetComponent<RectTransform>();
    component.sizeDelta = new Vector2(component.sizeDelta.x, 70f);
    this.tmpfValue[0] = (float) this.sHero.Camera_Horizontal;
    this.tmpfValue[1] = (float) this.sHero.CameraScaleRate;
  }

  public void SetHeroPage(bool bFirst)
  {
    this.GUIM.m_UICanvas.renderMode = (RenderMode) 1;
    this.GUIM.SetCanvasChanged();
    this.P4_T.gameObject.SetActive(true);
    this.P4_T.GetChild(3).gameObject.SetActive(false);
    this.P4_T.GetChild(4).gameObject.SetActive(false);
    this.Hero_Pos = this.P4_T.GetChild(0);
    this.text_HeroName = this.P4_T.GetChild(2).GetComponent<UIText>();
    this.text_HeroName.font = this.TTFont;
    this.text_HeroTitle = this.P4_T.GetChild(1).GetComponent<UIText>();
    this.text_HeroTitle.font = this.TTFont;
    this.mHeroAct[0] = "idle";
    this.mHeroAct[1] = "moving";
    this.mHeroAct[2] = "attack";
    this.mHeroAct[3] = "skill_1";
    this.mHeroAct[4] = "skill_2";
    this.mHeroAct[5] = "skill_3";
    this.mHeroAct[6] = "victory";
    if (bFirst)
    {
      this.text_HeroName.text = this.DM.mStringTable.GetStringByID(1601U);
      this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID(1602U);
      this.ActionTime = 0.0f;
      this.ActionTimeRandom = 2f;
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat(1L, 5);
      Name.AppendFormat("Role/hero_{0}");
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if ((UnityEngine.Object) this.AB != (UnityEngine.Object) null)
      {
        this.AR = this.AB.LoadAsync("m", typeof (GameObject));
        this.ABIsDone = false;
        this.tmpfValue[0] = 170f;
        this.tmpfValue[1] = 180f;
      }
    }
    else
    {
      this.text_HeroName.text = this.DM.mStringTable.GetStringByID(1625U);
      this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID(1626U);
      this.ActionTime = 0.0f;
      this.ActionTimeRandom = 2f;
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat(9L, 5);
      Name.AppendFormat("Role/hero_{0}");
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if ((UnityEngine.Object) this.AB != (UnityEngine.Object) null)
      {
        this.AR = this.AB.LoadAsync("m", typeof (GameObject));
        this.ABIsDone = false;
        this.tmpfValue[0] = 175f;
        this.tmpfValue[1] = 180f;
      }
    }
    this.text_Title.text = this.DM.mStringTable.GetStringByID(6U);
    this.text_Title.fontSize = 50;
    this.text_Title.resizeTextMaxSize = 50;
    RectTransform component = ((Component) this.text_Title).transform.GetComponent<RectTransform>();
    component.sizeDelta = new Vector2(component.sizeDelta.x, 70f);
  }

  public void SetHeroPage()
  {
    ((Transform) this.GUIM.m_SimpleItemInfo.m_RectTransform).SetParent((Transform) this.GUIM.m_OtherCanvasTransform, false);
    ((Transform) this.GUIM.HintMaskObj.m_RectTransform).SetParent((Transform) this.GUIM.m_OtherCanvasTransform, false);
    this.GUIM.m_UICanvas.renderMode = (RenderMode) 1;
    this.GUIM.SetCanvasChanged();
    DataManager.msgBuffer[0] = (byte) 84;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.Light1_T = this.P10_T.GetChild(2);
    this.Light2_T = this.P10_T.GetChild(3);
    this.Hbtn_Item2 = this.P10_T.GetChild(4).GetComponent<UIHIBtn>();
    this.Hbtn_Item2.m_Handler = (IUIHIBtnClickHandler) this;
    this.Img_ItemInfo = this.P10_T.GetChild(4).GetChild(0).GetComponent<Image>();
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, this.DM.mDailyGift.ItemData.ItemID, (byte) 0, (byte) 0, bShowText: false);
    ((Component) this.Img_ItemInfo).transform.SetAsLastSibling();
    ((Component) this.Hbtn_Item2).transform.GetComponent<UIButtonHint>().m_eHint = EUIButtonHint.DownUpHandler;
    ((Component) this.Hbtn_Item2).transform.GetComponent<UIButtonHint>().m_Handler = (MonoBehaviour) this;
    if (this.MM.CheckCanOpenDetail(this.DM.mDailyGift.ItemData.ItemID))
    {
      ((Component) this.Hbtn_Item2).transform.GetComponent<UIButtonHint>().enabled = false;
      ((Component) this.Hbtn_Item2).gameObject.GetComponent<uButtonScale>().enabled = true;
      this.Hbtn_Item2.transition = (Selectable.Transition) 0;
      ((Component) this.Img_ItemInfo).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.Hbtn_Item2).transform.GetComponent<UIButtonHint>().enabled = true;
      ((Component) this.Img_ItemInfo).gameObject.SetActive(false);
    }
    this.btn_box2Reward = this.P10_T.GetChild(5).GetComponent<UIButton>();
    this.btn_box2Reward.m_Handler = (IUIButtonClickHandler) this;
    this.btn_box2Reward.m_BtnID1 = 8;
    this.btn_box2Reward.m_EffectType = e_EffectType.e_Scale;
    this.btn_box2Reward.transition = (Selectable.Transition) 0;
    this.BtnName = this.P10_T.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.BtnName.font = this.TTFont;
    this.BtnName.text = this.DM.mStringTable.GetStringByID(1520U);
    this.text_P10Str[0] = this.P10_T.GetChild(6).GetChild(0).GetComponent<UIText>();
    this.text_P10Str[0].font = this.TTFont;
    this.text_P10Str[0].text = this.DM.mStringTable.GetStringByID(8170U);
    this.text_P10Str[1] = this.P10_T.GetChild(7).GetComponent<UIText>();
    this.text_P10Str[1].font = this.TTFont;
    this.Cstr_P10Time.ClearString();
    this.Cstr_P10Time.StringToFormat(this.DM.mStringTable.GetStringByID(8171U));
    this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.BeginTime).ToString("MM/dd/yy HH:mm"));
    this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.EndTime).ToString("MM/dd/yy HH:mm"));
    this.Cstr_P10Time.AppendFormat("{0}\n{1} ~ {2}");
    this.text_P10Str[1].text = this.Cstr_P10Time.ToString();
    this.text_P10Str[1].SetAllDirty();
    this.text_P10Str[1].cachedTextGenerator.Invalidate();
    this.text_P10Str[2] = this.P10_T.GetChild(8).GetComponent<UIText>();
    this.text_P10Str[2].font = this.TTFont;
    this.text_P10Str[2].text = this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.DM.mDailyGift.ItemData.ItemID).EquipName);
    this.text_P10Str[3] = this.P10_T.GetChild(9).GetComponent<UIText>();
    this.text_P10Str[3].font = this.TTFont;
    if (this.DM.mDailyGift.ItemData.Num > (ushort) 1)
    {
      ((Component) this.text_P10Str[3]).gameObject.SetActive(true);
      this.Cstr_P10Num.ClearString();
      this.Cstr_P10Num.IntToFormat((long) this.DM.mDailyGift.ItemData.Num);
      if (this.GUIM.IsArabic)
        this.Cstr_P10Num.AppendFormat("{0}x");
      else
        this.Cstr_P10Num.AppendFormat("x{0}");
      this.text_P10Str[3].text = this.Cstr_P10Num.ToString();
      this.text_P10Str[3].SetAllDirty();
      this.text_P10Str[3].cachedTextGenerator.Invalidate();
    }
    this.Hero_Pos = this.P10_T.GetChild(10);
    this.mHeroAct[0] = "idle";
    this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey);
    if ((UnityEngine.Object) this.AB != (UnityEngine.Object) null)
    {
      this.AR = this.AB.LoadAsync("Priest", typeof (GameObject));
      this.ABIsDone = false;
    }
    this.tmpfValue[0] = 184f;
    this.tmpfValue[1] = 270f;
    this.tmpfValue[2] = -55.7f;
  }

  public void Hero3D_Destroy()
  {
    if ((UnityEngine.Object) this.go2 != (UnityEngine.Object) null)
    {
      this.go2.transform.SetParent(this.Hero_Pos.parent, false);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.go2);
    }
    if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Hero_Model);
    this.Hero_Model = (Transform) null;
    this.go2 = (GameObject) null;
    AssetManager.UnloadAssetBundle(this.AssetKey, false);
  }

  public void LoadHero3D()
  {
    this.ActionTime = 0.0f;
    this.ActionTimeRandom = 2f;
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
    if (!((UnityEngine.Object) this.AB != (UnityEngine.Object) null))
      return;
    this.AR = this.AB.LoadAsync("m", typeof (GameObject));
    this.ABIsDone = false;
  }

  public void HeroActionChang()
  {
    if (!this.ABIsDone || !((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null))
      return;
    this.tmpAN = this.Hero_Model.GetComponent<Animation>();
    this.tmpAN.wrapMode = WrapMode.Loop;
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[2]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[2];
      this.tmpAN[this.mHeroAct[2]].layer = 1;
      this.tmpAN[this.mHeroAct[2]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[3]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[3];
      this.tmpAN[this.mHeroAct[3]].layer = 1;
      this.tmpAN[this.mHeroAct[3]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[4];
      this.tmpAN[this.mHeroAct[4]].layer = 1;
      this.tmpAN[this.mHeroAct[4]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[5]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[5];
      this.tmpAN[this.mHeroAct[5]].layer = 1;
      this.tmpAN[this.mHeroAct[5]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[6]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[6];
      this.tmpAN[this.mHeroAct[6]].layer = 1;
      this.tmpAN[this.mHeroAct[6]].wrapMode = WrapMode.Once;
    }
    int index = UnityEngine.Random.Range(1, 7);
    AnimationClip animationClip = this.tmpAN.GetClip(this.mHeroAct[(int) (byte) index]);
    this.HeroAct = this.mHeroAct[(int) (byte) index];
    if (index == 3 && (UnityEngine.Object) this.tmpAN.GetClip(this.HeroAct + "_ch") != (UnityEngine.Object) null)
      animationClip = (AnimationClip) null;
    if ((UnityEngine.Object) animationClip != (UnityEngine.Object) null)
    {
      this.tmpAN.CrossFade(animationClip.name);
      this.MovingTimer = 0.0f;
      if (index == 1)
        this.MovingTimer = 2f;
    }
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
  }

  public void SetScore()
  {
    this.P5_T.gameObject.SetActive(true);
    this.Light1_T = this.P5_T.GetChild(5);
    this.Light2_T = this.P5_T.GetChild(6);
    this.Tmp = this.P5_T.GetChild(8);
    this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
    this.Hbtn_Item2.m_Handler = (IUIHIBtnClickHandler) this;
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, (ushort) 1226, (byte) 0, (byte) 0);
    for (int index = 0; index < 8; ++index)
    {
      this.Tmp = this.P5_T.GetChild(index);
      this.Tmp.gameObject.SetActive(false);
    }
    ((Component) this.Hbtn_Item2).gameObject.SetActive(false);
    this.Tmp = this.P5_T.GetChild(11);
    this.Tmp.gameObject.SetActive(false);
    this.btn_Score = this.P5_T.GetChild(9).GetComponent<UIButton>();
    this.btn_Score.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Score.m_BtnID1 = 3;
    this.btn_Score.m_EffectType = e_EffectType.e_Scale;
    this.btn_Score.transition = (Selectable.Transition) 0;
    this.text_tmpStr[2] = this.P5_T.GetChild(9).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7400U);
    this.Cstr_Score.ClearString();
    this.text_tmpStr[3] = this.P5_T.GetChild(11).GetComponent<UIText>();
    this.text_tmpStr[3].font = this.TTFont;
    this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey((ushort) 1226).EquipName);
    this.Cstr_Score.StringToFormat(this.DM.mStringTable.GetStringByID(7380U));
    this.Cstr_Score.AppendFormat(this.DM.mStringTable.GetStringByID(7378U));
    this.text_Score = this.P5_T.GetChild(10).GetComponent<UIText>();
    this.text_Score.font = this.TTFont;
    this.text_Score.text = this.Cstr_Score.ToString();
    this.text_Score.SetAllDirty();
    this.text_Score.cachedTextGenerator.Invalidate();
    this.text_Score.cachedTextGeneratorForLayout.Invalidate();
    this.text_Title.text = this.DM.mStringTable.GetStringByID(7395U);
    this.text_Title.SetAllDirty();
    this.text_Title.cachedTextGenerator.Invalidate();
    this.text_ScoreStr = this.P5_T.GetChild(12).GetComponent<UIText>();
    this.text_ScoreStr.font = this.TTFont;
    this.text_ScoreStr.text = this.DM.mStringTable.GetStringByID(9912U);
    bool result1 = false;
    long result2 = 0;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.IntToFormat(NetworkManager.UserID);
    cstring.AppendFormat("{0}_Score_UseID");
    long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result2);
    if (result2 != 0L)
    {
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_Score_bScoreFirst");
      bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result1);
      if (result1)
      {
        byte result3 = 0;
        cstring.ClearString();
        cstring.IntToFormat(result2);
        cstring.AppendFormat("{0}_Score_Count");
        byte.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result3);
        ++result3;
        PlayerPrefs.SetString(cstring.ToString(), result3.ToString());
      }
      else
      {
        bool flag = true;
        cstring.ClearString();
        cstring.IntToFormat(result2);
        cstring.AppendFormat("{0}_Score_bScoreFirst");
        PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
      }
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_Score_CD");
      PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
    }
    else
    {
      PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
      long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result2);
      bool result4 = true;
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_Score_bScoreFirst");
      PlayerPrefs.SetString(cstring.ToString(), result4.ToString());
      bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result4);
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_Score_CD");
      PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
    }
  }

  public void SetFB_Reward()
  {
    this.P6_T.gameObject.SetActive(true);
    this.Light1_T = this.P6_T.GetChild(0);
    this.Light2_T = this.P6_T.GetChild(1);
    this.Tmp = this.P6_T.GetChild(3);
    this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
    this.Hbtn_Item2.m_Handler = (IUIHIBtnClickHandler) this;
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, (ushort) 1226, (byte) 0, (byte) 0);
    this.text_Title.text = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? this.DM.mStringTable.GetStringByID(7382U) : this.DM.mStringTable.GetStringByID(11169U);
    this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey((ushort) 1226).EquipName));
    this.Cstr_Info.AppendFormat("{0}");
    this.text_Info.text = this.Cstr_Info.ToString();
    this.text_Info.SetAllDirty();
    this.text_Info.cachedTextGenerator.Invalidate();
    this.Info_RT.anchoredPosition = new Vector2(this.Info_RT.anchoredPosition.x, this.Info_RT.anchoredPosition.y - 50f);
    this.btn_GOTOFB = this.P6_T.GetChild(4).GetComponent<UIButton>();
    this.btn_GOTOFB.m_Handler = (IUIButtonClickHandler) this;
    this.btn_GOTOFB.m_BtnID1 = 4;
    this.btn_GOTOFB.m_EffectType = e_EffectType.e_Scale;
    this.btn_GOTOFB.transition = (Selectable.Transition) 0;
    this.text_tmpStr[4] = this.P6_T.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[4].font = this.TTFont;
    this.text_tmpStr[4].text = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? this.DM.mStringTable.GetStringByID(7383U) : this.DM.mStringTable.GetStringByID(11171U);
    this.text_tmpStr[5] = this.P6_T.GetChild(5).GetComponent<UIText>();
    this.text_tmpStr[5].font = this.TTFont;
    this.text_tmpStr[5].text = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? this.DM.mStringTable.GetStringByID(7384U) : this.DM.mStringTable.GetStringByID(11170U);
    bool result1 = false;
    long result2 = 0;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.IntToFormat(NetworkManager.UserID);
    cstring.AppendFormat("{0}_FB_UseID");
    long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result2);
    if (result2 != 0L)
    {
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_FB_bScoreFirst");
      bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result1);
      if (result1)
      {
        byte result3 = 0;
        cstring.ClearString();
        cstring.IntToFormat(result2);
        cstring.AppendFormat("{0}_FB_Count");
        byte.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result3);
        ++result3;
        PlayerPrefs.SetString(cstring.ToString(), result3.ToString());
      }
      else
      {
        bool flag = true;
        cstring.ClearString();
        cstring.IntToFormat(result2);
        cstring.AppendFormat("{0}_FB_bScoreFirst");
        PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
      }
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_FB_CD");
      PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
    }
    else
    {
      PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
      long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result2);
      bool result4 = true;
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_FB_bScoreFirst");
      PlayerPrefs.SetString(cstring.ToString(), result4.ToString());
      bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result4);
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_FB_CD");
      PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
    }
  }

  public override void OnClose()
  {
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null && this.door.m_WindowStack.Count == 0)
    {
      DataManager.msgBuffer[0] = (byte) 85;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    if (this.Cstr_Time != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Time);
    if (this.Cstr_Count != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Count);
    if (this.Cstr_Info != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Info);
    if (this.Cstr_Info2 != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Info2);
    if (this.Cstr_Get != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Get);
    if (this.Cstr_Score != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Score);
    if (this.Cstr_P10Time != null)
      StringManager.Instance.DeSpawnString(this.Cstr_P10Time);
    if (this.Cstr_P10Num != null)
      StringManager.Instance.DeSpawnString(this.Cstr_P10Num);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Get2[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Get2[index]);
    }
    for (int index = 0; index < 4; ++index)
    {
      if (this.CStr_Indemnify[index] != null)
        StringManager.Instance.DeSpawnString(this.CStr_Indemnify[index]);
    }
    for (int index = 0; index < 9; ++index)
    {
      if (this.Cstr_Items[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Items[index]);
    }
    this.Hero3D_Destroy();
    if (this.mKind == 3)
      GUIManager.Instance.ReleaseLvUpLight();
    if (this.mKind != 3 || !((UnityEngine.Object) (GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect) != (UnityEngine.Object) null))
      return;
    NewbieManager.CheckTeach(ETeachKind.PRESS_X, bEntry: true);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
      case 1:
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        if (this.mKind == 2 && this.mGetType == 1)
          this.GUIM.OpenMenu(EGUIWindow.UI_Other_Account, bSecWindow: true);
        if (this.mKind == 1 && this.mGetType == 1)
          this.DM.m_MaintainCount = false;
        if (this.mKind != 1 || this.mGetType != 2)
          break;
        this.DM.m_UpdateVersionCount = false;
        break;
      case 2:
        switch (this.mGetType)
        {
          case 0:
            this.DM.SendTreasureBox();
            return;
          case 1:
          case 2:
            this.DM.SendGet_Compensation((byte) (this.mGetType - 1));
            return;
          default:
            return;
        }
      case 3:
        bool flag = true;
        long result = 0;
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.ClearString();
        cstring.IntToFormat(NetworkManager.UserID);
        cstring.AppendFormat("{0}");
        long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result);
        if (result != 0L)
        {
          cstring.ClearString();
          cstring.IntToFormat(result);
          cstring.AppendFormat("{0}_Score_bScoreEnd");
          PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
        }
        IGGSDKPlugin.RateGooglePlayApplication(GameConstants.GlobalEditionClassNames);
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case 4:
        this.GUIM.ShowUILock(EUILock.TreasureBox);
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_FB_FANS_PRIZE;
        messagePacket1.AddSeqId();
        messagePacket1.Send();
        break;
      case 5:
        if (ArenaManager.Instance.m_ArenaCrystalPrize > 0U)
        {
          ArenaManager.Instance.SendArena_Arena_GetPrize();
          break;
        }
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case 6:
        Indemnify.SendRequestIndemnify();
        break;
      case 7:
        if (MallManager.Instance.BuyMonthTreasureTime != 0L)
        {
          MallManager.Instance.Send_Treasure_Get_Monthprize();
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7013U), (ushort) byte.MaxValue);
        break;
      case 8:
        this.GUIM.ShowUILock(EUILock.TreasureBox);
        MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
        messagePacket2.Protocol = Protocol._MSG_REQUEST_ACTIVITY_DAILYGIFT;
        messagePacket2.AddSeqId();
        messagePacket2.Send();
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender) => this.MM.OpenDetail(sender.HIID);

  public void OnButtonDown(UIButtonHint sender)
  {
    this.GUIM.m_SimpleItemInfo.Show(sender, this.DM.mDailyGift.ItemData.ItemID, upsetPoint: new Vector3?((Vector3) new Vector2(-250f, 0.0f)));
  }

  public void OnButtonUp(UIButtonHint sender) => this.GUIM.m_SimpleItemInfo.Hide(sender);

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.gameObject.SetActive(true);
        if (this.mKind != 12)
          break;
        ((Transform) this.GUIM.m_SimpleItemInfo.m_RectTransform).SetParent((Transform) GUIManager.Instance.m_ItemInfoLayer, false);
        ((Transform) this.GUIM.m_SimpleItemInfo.m_RectTransform).SetAsFirstSibling();
        this.GUIM.m_SimpleItemInfo.m_RectTransform.anchoredPosition3D = Vector3.zero;
        ((Transform) this.GUIM.HintMaskObj.m_RectTransform).SetParent((Transform) GUIManager.Instance.m_ItemInfoLayer, false);
        ((Transform) this.GUIM.HintMaskObj.m_RectTransform).SetSiblingIndex(6);
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case NetworkNews.Fallout:
        this.gameObject.SetActive(false);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
      case NetworkNews.Refresh_IndemnifyResources:
        this.RefreshIndemnifyResources();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Info != (UnityEngine.Object) null && ((Behaviour) this.text_Info).enabled)
    {
      ((Behaviour) this.text_Info).enabled = false;
      ((Behaviour) this.text_Info).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Time != (UnityEngine.Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_Time).enabled = false;
      ((Behaviour) this.text_Time).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Count != (UnityEngine.Object) null && ((Behaviour) this.text_Count).enabled)
    {
      ((Behaviour) this.text_Count).enabled = false;
      ((Behaviour) this.text_Count).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Get != (UnityEngine.Object) null && ((Behaviour) this.text_Get).enabled)
    {
      ((Behaviour) this.text_Get).enabled = false;
      ((Behaviour) this.text_Get).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroName != (UnityEngine.Object) null && ((Behaviour) this.text_HeroName).enabled)
    {
      ((Behaviour) this.text_HeroName).enabled = false;
      ((Behaviour) this.text_HeroName).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroTitle != (UnityEngine.Object) null && ((Behaviour) this.text_HeroTitle).enabled)
    {
      ((Behaviour) this.text_HeroTitle).enabled = false;
      ((Behaviour) this.text_HeroTitle).enabled = true;
    }
    if ((UnityEngine.Object) this.text_GetType != (UnityEngine.Object) null && ((Behaviour) this.text_GetType).enabled)
    {
      ((Behaviour) this.text_GetType).enabled = false;
      ((Behaviour) this.text_GetType).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Score != (UnityEngine.Object) null && ((Behaviour) this.text_Score).enabled)
    {
      ((Behaviour) this.text_Score).enabled = false;
      ((Behaviour) this.text_Score).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ScoreStr != (UnityEngine.Object) null && ((Behaviour) this.text_ScoreStr).enabled)
    {
      ((Behaviour) this.text_ScoreStr).enabled = false;
      ((Behaviour) this.text_ScoreStr).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ArenaReward != (UnityEngine.Object) null && ((Behaviour) this.text_ArenaReward).enabled)
    {
      ((Behaviour) this.text_ArenaReward).enabled = false;
      ((Behaviour) this.text_ArenaReward).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ArenaRewardNum != (UnityEngine.Object) null && ((Behaviour) this.text_ArenaRewardNum).enabled)
    {
      ((Behaviour) this.text_ArenaRewardNum).enabled = false;
      ((Behaviour) this.text_ArenaRewardNum).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ArenaReward_Get != (UnityEngine.Object) null && ((Behaviour) this.text_ArenaReward_Get).enabled)
    {
      ((Behaviour) this.text_ArenaReward_Get).enabled = false;
      ((Behaviour) this.text_ArenaReward_Get).enabled = true;
    }
    if ((UnityEngine.Object) this.BtnName != (UnityEngine.Object) null && ((Behaviour) this.BtnName).enabled)
    {
      ((Behaviour) this.BtnName).enabled = false;
      ((Behaviour) this.BtnName).enabled = true;
    }
    if ((UnityEngine.Object) this.Hbtn_Item != (UnityEngine.Object) null && ((Behaviour) this.Hbtn_Item).enabled)
      this.Hbtn_Item.Refresh_FontTexture();
    if ((UnityEngine.Object) this.Hbtn_Item2 != (UnityEngine.Object) null && ((Behaviour) this.Hbtn_Item2).enabled)
      this.Hbtn_Item2.Refresh_FontTexture();
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.text_Get2[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Get2[index]).enabled)
      {
        ((Behaviour) this.text_Get2[index]).enabled = false;
        ((Behaviour) this.text_Get2[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Arena[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Arena[index]).enabled)
      {
        ((Behaviour) this.text_Arena[index]).enabled = false;
        ((Behaviour) this.text_Arena[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((UnityEngine.Object) this.text_tmpStr[index] != (UnityEngine.Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((UnityEngine.Object) this.text_Cards[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Cards[index]).enabled)
      {
        ((Behaviour) this.text_Cards[index]).enabled = false;
        ((Behaviour) this.text_Cards[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.Hbtn_Items[index] != (UnityEngine.Object) null && ((Behaviour) this.Hbtn_Items[index]).enabled)
        this.Hbtn_Items[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.text_P10Str[index] != (UnityEngine.Object) null && ((Behaviour) this.text_P10Str[index]).enabled)
      {
        ((Behaviour) this.text_P10Str[index]).enabled = false;
        ((Behaviour) this.text_P10Str[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        this.GUIM.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 2, 3, openMode: (byte) 0);
        GameManager.OnRefresh();
        break;
      case 2:
        this.Cstr_Info.ClearString();
        this.Cstr_Info.IntToFormat((long) this.DM.m_Maintain);
        this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473U));
        this.text_Info.text = this.Cstr_Info.ToString();
        this.text_Info.SetAllDirty();
        this.text_Info.cachedTextGenerator.Invalidate();
        break;
      case 3:
        this.Cstr_Info.ClearString();
        this.Cstr_Info.IntToFormat((long) this.DM.m_UpdateVersion);
        this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473U));
        this.text_Info.text = this.Cstr_Info.ToString();
        this.text_Info.SetAllDirty();
        this.text_Info.cachedTextGenerator.Invalidate();
        break;
      case 4:
        if (this.mKind != 9)
          break;
        this.Cstr_Info2.ClearString();
        this.Cstr_Info2.IntToFormat((long) ArenaManager.Instance.m_ArenaCrystalPrize, bNumber: true);
        this.Cstr_Info2.AppendFormat("{0}");
        this.text_ArenaRewardNum.text = this.Cstr_Info2.ToString();
        this.text_ArenaRewardNum.SetAllDirty();
        this.text_ArenaRewardNum.cachedTextGenerator.Invalidate();
        if (ArenaManager.Instance.m_ArenaCrystalPrize > 0U)
        {
          this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(9143U);
          this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9142U);
          ((Component) this.text_ArenaRewardNum).gameObject.SetActive(true);
        }
        else
        {
          this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(7671U);
          this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9164U);
          ((Component) this.text_ArenaRewardNum).gameObject.SetActive(false);
        }
        this.text_ArenaReward.SetAllDirty();
        this.text_ArenaReward.cachedTextGenerator.Invalidate();
        this.text_ArenaReward_Get.SetAllDirty();
        this.text_ArenaReward_Get.cachedTextGenerator.Invalidate();
        break;
      case 5:
        if (this.mKind != 9)
          break;
        ushort nowCrystal = ArenaManager.Instance.GetNowCrystal();
        this.Cstr_Info.ClearString();
        this.Cstr_Info.IntToFormat((long) nowCrystal, bNumber: true);
        this.Cstr_Info.AppendFormat("{0}");
        this.text_Arena[1].text = this.Cstr_Info.ToString();
        this.text_Arena[1].SetAllDirty();
        this.text_Arena[1].cachedTextGenerator.Invalidate();
        break;
      case 6:
        if (this.mKind != 11)
          break;
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case 7:
        if (this.mKind != 11 || !this.P9_T.gameObject.activeSelf)
          break;
        this.Cstr_Items[0].ClearString();
        this.Cstr_Items[0].IntToFormat((long) this.MM.mMonthTreasureCrystal);
        this.Cstr_Items[0].AppendFormat("{0}");
        this.text_Cards[0].text = this.Cstr_Items[0].ToString();
        this.text_Cards[0].SetAllDirty();
        this.text_Cards[0].cachedTextGenerator.Invalidate();
        for (int index = 0; index < 7; ++index)
        {
          this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Items[index]).transform, eHeroOrItem.Item, this.MM.mMonthTreasureItem[index].ItemID, (byte) 0, this.MM.mMonthTreasureItem[index].ItemRank);
          this.Cstr_Items[index + 1].ClearString();
          this.Cstr_Items[index + 1].IntToFormat((long) this.MM.mMonthTreasureItem[index].Num);
          if (this.GUIM.IsArabic)
            this.Cstr_Items[index + 1].AppendFormat("{0}x");
          else
            this.Cstr_Items[index + 1].AppendFormat("x{0}");
          this.text_Cards[index + 1].text = this.Cstr_Items[index + 1].ToString();
          this.text_Cards[index + 1].SetAllDirty();
          this.text_Cards[index + 1].cachedTextGenerator.Invalidate();
        }
        this.Cstr_Items[8].ClearString();
        this.text_Cards[8] = this.P9_T.GetChild(16).GetComponent<UIText>();
        this.text_Cards[8].font = this.TTFont;
        if (this.MM.BuyMonthTreasureTime != 0L && this.MM.LastGetMonthTreasurePrizeTime == 0L)
          this.Cstr_Items[8].IntToFormat(30L, bNumber: true);
        else
          this.Cstr_Items[8].IntToFormat(29L - (this.MM.LastGetMonthTreasurePrizeTime - this.MM.BuyMonthTreasureTime) / 86400L, bNumber: true);
        this.Cstr_Items[8].AppendFormat(this.DM.mStringTable.GetStringByID(922U));
        this.text_Cards[8].text = this.Cstr_Items[8].ToString();
        this.text_Cards[8].SetAllDirty();
        this.text_Cards[8].cachedTextGenerator.Invalidate();
        break;
      case 8:
        if (this.mKind != 12 || this.DM.CheckDailyGift())
          break;
        ((Transform) this.GUIM.m_SimpleItemInfo.m_RectTransform).SetParent((Transform) GUIManager.Instance.m_ItemInfoLayer, false);
        ((Transform) this.GUIM.m_SimpleItemInfo.m_RectTransform).SetAsFirstSibling();
        this.GUIM.m_SimpleItemInfo.m_RectTransform.anchoredPosition3D = Vector3.zero;
        ((Transform) this.GUIM.HintMaskObj.m_RectTransform).SetParent((Transform) GUIManager.Instance.m_ItemInfoLayer, false);
        ((Transform) this.GUIM.HintMaskObj.m_RectTransform).SetSiblingIndex(6);
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case 9:
        if (this.mKind != 12)
          break;
        if (!this.DM.CheckDailyGift())
        {
          this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
          this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
          break;
        }
        this.Cstr_P10Time.ClearString();
        this.Cstr_P10Time.StringToFormat(this.DM.mStringTable.GetStringByID(8171U));
        this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.BeginTime).ToString("MM/dd/yy HH:mm"));
        this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.EndTime).ToString("MM/dd/yy HH:mm"));
        this.Cstr_P10Time.AppendFormat("{0}\n{1} ~ {2}");
        this.text_P10Str[1].text = this.Cstr_P10Time.ToString();
        this.text_P10Str[1].SetAllDirty();
        this.text_P10Str[1].cachedTextGenerator.Invalidate();
        this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Item2).transform, eHeroOrItem.Item, this.DM.mDailyGift.ItemData.ItemID, (byte) 0, (byte) 0);
        this.text_P10Str[2].text = this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.DM.mDailyGift.ItemData.ItemID).EquipName);
        this.text_P10Str[2].SetAllDirty();
        this.text_P10Str[2].cachedTextGenerator.Invalidate();
        if (this.DM.mDailyGift.ItemData.Num > (ushort) 1)
        {
          ((Component) this.text_P10Str[3]).gameObject.SetActive(true);
          this.Cstr_P10Num.ClearString();
          this.Cstr_P10Num.IntToFormat((long) this.DM.mDailyGift.ItemData.Num);
          if (this.GUIM.IsArabic)
            this.Cstr_P10Num.AppendFormat("{0}x");
          else
            this.Cstr_P10Num.AppendFormat("x{0}");
          this.text_P10Str[3].text = this.Cstr_P10Num.ToString();
          this.text_P10Str[3].SetAllDirty();
          this.text_P10Str[3].cachedTextGenerator.Invalidate();
          break;
        }
        ((Component) this.text_P10Str[3]).gameObject.SetActive(false);
        break;
    }
  }

  public override bool OnBackButtonClick() => this.mKind == 12;

  private void Start()
  {
  }

  private void Update()
  {
    if ((this.P2_T.gameObject.activeSelf || this.P3_T.gameObject.activeSelf || this.P5_T.gameObject.activeSelf || this.P6_T.gameObject.activeSelf || this.P10_T.gameObject.activeSelf) && (UnityEngine.Object) this.Light1_T != (UnityEngine.Object) null && (UnityEngine.Object) this.Light2_T != (UnityEngine.Object) null)
    {
      this.Light1_T.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      this.Light2_T.Rotate(Vector3.forward * Time.smoothDeltaTime * 50f);
    }
    else if ((UnityEngine.Object) this.LightP1_T != (UnityEngine.Object) null)
      this.LightP1_T.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if (this.mKind == 12 && (UnityEngine.Object) this.P10_T != (UnityEngine.Object) null && !this.P10_T.gameObject.gameObject.activeSelf)
      this.P10_T.gameObject.SetActive(true);
    if (!this.P4_T.gameObject.activeSelf && !this.P10_T.gameObject.activeSelf)
      return;
    if (!this.ABIsDone && this.AR != null && this.AR.isDone)
    {
      this.go2 = (GameObject) UnityEngine.Object.Instantiate(this.AR.asset);
      this.go2.transform.SetParent(this.Hero_Pos, false);
      this.go2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
      {
        eulerAngles = new Vector3(0.0f, this.tmpfValue[0], 0.0f)
      };
      this.go2.transform.localScale = new Vector3(this.tmpfValue[1], this.tmpfValue[1], this.tmpfValue[1]);
      this.go2.transform.localPosition = new Vector3(0.0f, this.tmpfValue[2], 0.0f);
      this.GUIM.SetLayer(this.go2, 5);
      this.Tmp = this.Hero_Pos.GetChild(0);
      this.Hero_Model = this.Tmp.GetComponent<Transform>();
      if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      {
        this.tmpAN = this.Hero_Model.GetComponent<Animation>();
        this.tmpAN.wrapMode = WrapMode.Loop;
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        this.tmpAN.Play(AnimationUnit.ANIM_STRING[0]);
        this.tmpAN.clip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[0]);
        if (this.Hero_Pos.gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
      this.ABIsDone = true;
    }
    if (this.ABIsDone && (UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double) this.ActionTimeRandom < 0.0001)
    {
      this.ActionTimeRandom = (float) UnityEngine.Random.Range(3, 7);
      this.ActionTime = 0.0f;
    }
    if ((double) this.ActionTimeRandom > 0.0001 && this.P4_T.gameObject.activeSelf)
    {
      this.ActionTime += Time.smoothDeltaTime;
      if ((double) this.ActionTime >= (double) this.ActionTimeRandom)
        this.HeroActionChang();
    }
    if (!this.ABIsDone || !((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null) || (double) this.MovingTimer <= 0.0)
      return;
    this.MovingTimer -= Time.deltaTime;
    if ((double) this.MovingTimer > 0.0)
      return;
    this.tmpAN.CrossFade("idle");
    this.HeroAct = "idle";
  }
}
