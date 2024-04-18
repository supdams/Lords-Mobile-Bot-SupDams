// Decompiled with JetBrains decompiler
// Type: UIDonation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIDonation : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const byte StepCount = 3;
  private const int PCount = 4;
  private const byte FactorCount = 5;
  private Transform m_transform;
  private Transform Main2T;
  private Transform[] mLbtn_ItemT = new Transform[4];
  private DataManager DM;
  private GUIManager GM;
  private ActivityManager AM;
  private Font tmpFont;
  private Door door;
  private UIButton btn_EXIT;
  private UIButton btn_I;
  private UIButton btn_CDTime;
  private UIButton[] btn_Exchange = new UIButton[4];
  private UIButton[] btn_MultipleHint = new UIButton[4];
  private uButtonScale[] btn_Exchange_Scale = new uButtonScale[4];
  private Image TopTriImage;
  private Image Img_Hint;
  private Image[] SliderNormal = new Image[3];
  private Image[] SliderFlash = new Image[3];
  private Image[] Img_MultipleBG = new Image[4];
  private Image[][] Img_Multiple = new Image[4][];
  private Image[] Img_MultipleHint = new Image[4];
  private UIText text_Title;
  private UIText NowScoreText;
  private UIText NextScoreText;
  private UIText text_Hint;
  private UIText text_Time;
  private UIText[] StageScoreText = new UIText[3];
  private UIText[] RBText = new UIText[2];
  private UIText[] text_ItemExchange = new UIText[4];
  private UIText[] text_ItemNum = new UIText[4];
  private UIText[] text_ItemName = new UIText[4];
  private UIText[] text_MultipleHint = new UIText[4];
  private UIText[][] text_AddScore = new UIText[4][];
  private Vector2 TriLastPos = new Vector2(395f, 9f);
  private CString[] StageScore = new CString[3];
  private CString NowScoreStr;
  private CString NextScoreStr;
  private CString Cstr_Time;
  private CString[] Cstr_ItemNum = new CString[4];
  private CString[] Cstr_ItemName = new CString[4];
  private CString[] Cstr_MultipleHint = new CString[4];
  private CString[][] Cstr_AddScore = new CString[4][];
  private GameObject[] PGO = new GameObject[4];
  private UIHIBtn[] btn_Item = new UIHIBtn[4];
  private UILEBtn[] Lbtn_Item = new UILEBtn[4];
  private byte nowStep;
  private ulong nowScore;
  private ulong[] StepScore = new ulong[3];
  private ActivityDataType tmpData;
  private byte mExchange;
  private float[] mBtnCD = new float[4];
  private float[] mValueScale = new float[4];
  private float[] mMultipleScale = new float[4];
  private int[] mShowStatus = new int[4];
  private bool[] bShowChangValue = new bool[4];
  private uint mCountValue;
  private int[] mDonationData = new int[4];
  private byte[] mDonationDataCount = new byte[4];
  private byte[] mDonationMultiple = new byte[4];
  private byte[] mDonation_Index = new byte[50];
  private float mSendCDTime;
  private ulong mAddScore;
  private ulong mDonation_Score;
  private BoardData[] tmpDonationData = new BoardData[4];
  private uint tmpScore1;
  private DonateAmountData[] tmpDonateAmountData = new DonateAmountData[4];
  private ushort[] mDonationItemQty = new ushort[4];
  private ushort mDonation_TCount;
  public float[][] mShowEffectTime = new float[4][];
  private bool bLEItem;
  private Equip tmpEquip;
  private Color mColor_G = new Color(0.078f, 0.973f, 0.333f);
  private Color GreenColor = new Color(0.07843f, 0.9725f, 0.3333f, 1f);
  private Color StageScoreColorY = new Color(1f, 0.945f, 0.203f);
  private bool bEqDataReq;
  private bool bMaterialDataReq;
  private bool bCloseMenu;
  private float tmptestY = 1f;
  private byte[] tmpAddScoreIdx = new byte[4];

  public override void OnOpen(int arg1, int arg2)
  {
    MallManager instance1 = MallManager.Instance;
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.AM = ActivityManager.Instance;
    StringManager instance2 = StringManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    this.door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    Material material = this.door.LoadMaterial();
    if (this.DM.RoleAlliance.Id == 0U || this.AM.AllianceSummonAllianceID == 0U || (int) this.DM.RoleAlliance.Id != (int) this.AM.AllianceSummonAllianceID || this.AM.AllianceSummonData.EventState != EActivityState.EAS_Run)
      this.bCloseMenu = true;
    bool flag = true;
    for (int index = 0; index < 4; ++index)
      this.tmpDonateAmountData[index] = this.DM.DonateAmountTable.GetRecordByKey(this.AM.mAllianceDonationData[index].RequireIdx);
    if (this.AM.bNeedSendUpData && !this.bCloseMenu)
    {
      this.AM.Send_ACTIVITY_AS_DONATE_BOARD();
      this.AM.bNeedSendUpData = false;
    }
    else
    {
      flag = false;
      for (int index = 0; index < 4; ++index)
      {
        this.tmpDonationData[index] = this.AM.mAllianceDonationData[index];
        this.mDonation_TCount += this.tmpDonationData[index].DonateNumber;
        this.mDonationItemQty[index] = this.DM.GetCurItemQuantity(this.tmpDonationData[index].itemID, this.tmpDonationData[index].itemRank);
        this.mDonationMultiple[index] = this.tmpDonationData[index].Multiple;
      }
      if (this.AM.mSendAddCount > (ushort) 0)
        this.GM.ShowUILock(EUILock.UIDonation);
    }
    this.tmpScore1 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) 17, (byte) 1).Score1;
    this.tmpData = this.AM.AllianceSummonData;
    this.NowScoreStr = instance2.SpawnString();
    this.NextScoreStr = instance2.SpawnString();
    this.Cstr_Time = instance2.SpawnString();
    for (int index = 0; index < 4; ++index)
    {
      this.Cstr_ItemNum[index] = instance2.SpawnString();
      this.Cstr_ItemName[index] = instance2.SpawnString(100);
      this.Cstr_MultipleHint[index] = instance2.SpawnString(200);
      this.Cstr_AddScore[index] = new CString[4];
      this.Cstr_AddScore[index][0] = instance2.SpawnString();
      this.Cstr_AddScore[index][1] = instance2.SpawnString();
      this.Cstr_AddScore[index][2] = instance2.SpawnString();
      this.Cstr_AddScore[index][3] = instance2.SpawnString();
    }
    Image component = this.m_transform.GetChild(2).GetComponent<Image>();
    component.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component).material = material;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) component).enabled = false;
    this.btn_EXIT = this.m_transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.btn_I = this.m_transform.GetChild(3).GetComponent<UIButton>();
    ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 1;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    Transform child1 = this.m_transform.GetChild(1);
    this.Main2T = child1.GetChild(0);
    this.text_Title = child1.GetChild(1).GetChild(3).GetComponent<UIText>();
    this.text_Title.font = this.tmpFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(14544U);
    this.Img_Hint = child1.GetChild(2).GetComponent<Image>();
    this.text_Hint = child1.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text_Hint.font = this.tmpFont;
    this.text_Hint.text = this.DM.mStringTable.GetStringByID(14545U);
    this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Hint.preferredHeight > (double) ((Graphic) this.text_Hint).rectTransform.sizeDelta.y)
      ((Graphic) this.Img_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint).rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 10f);
    for (int index = 0; index < 4; ++index)
    {
      this.mShowEffectTime[index] = new float[4];
      this.text_AddScore[index] = new UIText[4];
      Transform child2 = child1.GetChild(3 + index);
      this.text_AddScore[index][0] = child2.GetComponent<UIText>();
      this.text_AddScore[index][0].font = this.tmpFont;
      Transform child3 = child1.GetChild(3 + index + 4);
      this.text_AddScore[index][1] = child3.GetComponent<UIText>();
      this.text_AddScore[index][1].font = this.tmpFont;
      Transform child4 = child1.GetChild(3 + index + 8);
      this.text_AddScore[index][2] = child4.GetComponent<UIText>();
      this.text_AddScore[index][2].font = this.tmpFont;
      Transform child5 = child1.GetChild(3 + index + 12);
      this.text_AddScore[index][3] = child5.GetComponent<UIText>();
      this.text_AddScore[index][3].font = this.tmpFont;
    }
    this.RBText[0] = this.Main2T.GetChild(3).GetComponent<UIText>();
    this.RBText[0].font = this.tmpFont;
    this.RBText[0].text = this.DM.mStringTable.GetStringByID(8116U);
    this.RBText[1] = this.Main2T.GetChild(4).GetComponent<UIText>();
    this.RBText[1].font = this.tmpFont;
    this.RBText[1].text = this.DM.mStringTable.GetStringByID(8117U);
    this.NowScoreText = this.Main2T.GetChild(5).GetComponent<UIText>();
    this.NowScoreText.font = this.tmpFont;
    this.NextScoreText = this.Main2T.GetChild(6).GetComponent<UIText>();
    this.NextScoreText.font = this.tmpFont;
    Transform child6 = this.Main2T.GetChild(2);
    this.SliderNormal[0] = child6.GetChild(2).GetComponent<Image>();
    this.SliderNormal[1] = child6.GetChild(3).GetComponent<Image>();
    this.SliderNormal[2] = child6.GetChild(4).GetComponent<Image>();
    this.SliderFlash[0] = child6.GetChild(5).GetComponent<Image>();
    this.SliderFlash[1] = child6.GetChild(6).GetComponent<Image>();
    this.SliderFlash[2] = child6.GetChild(7).GetComponent<Image>();
    this.TopTriImage = child6.GetChild(11).GetComponent<Image>();
    this.StageScoreText[0] = child6.GetChild(12).GetComponent<UIText>();
    this.StageScoreText[0].font = this.tmpFont;
    this.StageScoreText[1] = child6.GetChild(13).GetComponent<UIText>();
    this.StageScoreText[1].font = this.tmpFont;
    this.StageScoreText[2] = child6.GetChild(14).GetComponent<UIText>();
    this.StageScoreText[2].font = this.tmpFont;
    this.StepScore[0] = (ulong) this.tmpData.RequireScore[0];
    this.StepScore[1] = (ulong) this.tmpData.RequireScore[1];
    this.StepScore[2] = (ulong) this.tmpData.RequireScore[2];
    for (int index = 0; index < 3; ++index)
    {
      this.StageScore[index] = instance2.SpawnString();
      this.StageScore[index].uLongToFormat(this.StepScore[index], bNumber: true);
      this.StageScore[index].AppendFormat("{0}");
      this.StageScoreText[index].text = this.StageScore[index].ToString();
      if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
        ((Graphic) this.StageScoreText[index]).color = this.GreenColor;
    }
    this.AM.mAllianceDonation_Score = (uint) this.AM.AllianceSummonData.EventScore;
    this.mDonation_Score = (ulong) this.AM.mAllianceDonation_Score;
    this.SetStepScore(this.mDonation_Score);
    Transform child7 = this.m_transform.GetChild(0);
    for (int index1 = 0; index1 < 4; ++index1)
    {
      Transform child8 = child7.GetChild(index1);
      this.PGO[index1] = child8.gameObject;
      this.Img_MultipleBG[index1] = child8.GetChild(1).GetComponent<Image>();
      this.btn_Item[index1] = child8.GetChild(2).GetComponent<UIHIBtn>();
      this.GM.InitianHeroItemImg(((Component) this.btn_Item[index1]).transform, eHeroOrItem.Item, this.tmpDonationData[index1].itemID, (byte) 0, this.tmpDonationData[index1].itemRank);
      this.mLbtn_ItemT[index1] = child8.GetChild(3);
      this.mLbtn_ItemT[index1].gameObject.AddComponent<UIButtonHint>();
      UIButtonHint uiButtonHint1 = this.mLbtn_ItemT[index1].gameObject.AddComponent<UIButtonHint>();
      uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint1.m_Handler = (MonoBehaviour) this;
      uiButtonHint1.Parm1 = (ushort) index1;
      this.Lbtn_Item[index1] = child8.GetChild(3).GetChild(0).GetComponent<UILEBtn>();
      ((Component) this.Lbtn_Item[index1]).gameObject.AddComponent<IgnoreRaycast>();
      this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[index1].itemID);
      this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
      this.GM.InitLordEquipImg(((Component) this.Lbtn_Item[index1]).transform, this.tmpDonationData[index1].itemID, this.tmpDonationData[index1].itemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      if (this.bLEItem)
      {
        this.mLbtn_ItemT[index1].gameObject.SetActive(true);
        ((Component) this.btn_Item[index1]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.btn_Item[index1]).gameObject.SetActive(true);
        ((Component) this.btn_Item[index1]).transform.GetComponent<UIButtonHint>().m_Handler = (MonoBehaviour) this;
        ((Component) this.btn_Item[index1]).transform.GetComponent<UIButtonHint>().m_eHint = EUIButtonHint.DownUpHandler;
        ((Component) this.btn_Item[index1]).transform.GetComponent<UIButtonHint>().Parm1 = (ushort) index1;
        this.mLbtn_ItemT[index1].gameObject.SetActive(false);
      }
      this.btn_Exchange[index1] = child8.GetChild(4).GetComponent<UIButton>();
      this.btn_Exchange[index1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Exchange[index1].m_BtnID1 = 3;
      this.btn_Exchange[index1].m_BtnID2 = index1;
      this.btn_Exchange[index1].SetButtonEffectType(e_EffectType.e_Scale);
      this.btn_Exchange[index1].transition = (Selectable.Transition) 0;
      this.btn_Exchange_Scale[index1] = ((Component) this.btn_Exchange[index1]).gameObject.GetComponent<uButtonScale>();
      this.text_ItemExchange[index1] = child8.GetChild(4).GetChild(0).GetComponent<UIText>();
      this.text_ItemExchange[index1].font = this.tmpFont;
      this.text_ItemExchange[index1].text = this.DM.mStringTable.GetStringByID(14546U);
      this.btn_Exchange[index1].m_Text = this.text_ItemExchange[index1];
      this.Img_Multiple[index1] = new Image[3];
      this.Img_Multiple[index1][0] = child8.GetChild(5).GetComponent<Image>();
      this.Img_Multiple[index1][1] = child8.GetChild(5).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) this.Img_Multiple[index1][1]).material = material;
      if (this.GM.IsArabic)
        ((Component) this.Img_Multiple[index1][1]).gameObject.AddComponent<ArabicItemTextureRot>();
      this.Img_Multiple[index1][2] = child8.GetChild(5).GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) this.Img_Multiple[index1][2]).material = material;
      if (this.GM.IsArabic)
        ((Component) this.Img_Multiple[index1][2]).gameObject.AddComponent<ArabicItemTextureRot>();
      if (this.GM.IsArabic)
      {
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
          this.door.SetPointTexture(this.mDonationMultiple[index1], this.Img_Multiple[index1][2]);
        this.Img_Multiple[index1][1].sprite = this.door.LoadSprite("UI_mall_x_001");
      }
      else
      {
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
          this.door.SetPointTexture(this.mDonationMultiple[index1], this.Img_Multiple[index1][1]);
        this.Img_Multiple[index1][2].sprite = this.door.LoadSprite("UI_mall_x_001");
      }
      this.Img_MultipleHint[index1] = child8.GetChild(9).GetComponent<Image>();
      this.text_MultipleHint[index1] = child8.GetChild(9).GetChild(0).GetComponent<UIText>();
      this.text_MultipleHint[index1].font = this.tmpFont;
      this.btn_MultipleHint[index1] = child8.GetChild(6).GetComponent<UIButton>();
      this.btn_MultipleHint[index1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_MultipleHint[index1].m_BtnID1 = 4;
      this.btn_MultipleHint[index1].m_BtnID2 = index1;
      UIButtonHint uiButtonHint2 = ((Component) this.btn_MultipleHint[index1]).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint2.m_Handler = (MonoBehaviour) this;
      uiButtonHint2.ControlFadeOut = ((Component) this.Img_MultipleHint[index1]).gameObject;
      this.text_ItemNum[index1] = child8.GetChild(7).GetComponent<UIText>();
      this.text_ItemNum[index1].font = this.tmpFont;
      this.Cstr_ItemNum[index1].ClearString();
      int index2 = (int) this.tmpDonationData[index1].DonateNumber + this.mDonationData[index1];
      if (index2 >= this.tmpDonateAmountData[index1].DonateAmount.Length)
        index2 = this.tmpDonateAmountData[index1].DonateAmount.Length - 1;
      if ((int) this.mDonationItemQty[index1] < (int) this.tmpDonateAmountData[index1].DonateAmount[index2])
        this.btn_Exchange[index1].ForTextChange(e_BtnType.e_ChangeText);
      else
        this.btn_Exchange[index1].ForTextChange(e_BtnType.e_Normal);
      this.Cstr_ItemNum[index1].IntToFormat((long) this.tmpDonateAmountData[index1].DonateAmount[index2], bNumber: true);
      if (this.GM.IsArabic)
        this.Cstr_ItemNum[index1].AppendFormat("{0}x");
      else
        this.Cstr_ItemNum[index1].AppendFormat("x{0}");
      this.text_ItemNum[index1].text = this.Cstr_ItemNum[index1].ToString();
      this.text_ItemNum[index1].SetAllDirty();
      this.text_ItemNum[index1].cachedTextGenerator.Invalidate();
      this.text_ItemNum[index1].cachedTextGeneratorForLayout.Invalidate();
      ((Graphic) this.text_ItemNum[index1]).rectTransform.anchoredPosition = new Vector2((float) (106.0 + (double) this.text_ItemNum[index1].preferredWidth / 2.0), ((Graphic) this.text_ItemNum[index1]).rectTransform.anchoredPosition.y);
      this.text_ItemName[index1] = child8.GetChild(8).GetComponent<UIText>();
      this.text_ItemName[index1].font = this.tmpFont;
      this.Cstr_ItemName[index1].ClearString();
      this.Cstr_ItemName[index1].IntToFormat((long) this.tmpScore1, bNumber: true);
      this.Cstr_ItemName[index1].AppendFormat(this.DM.mStringTable.GetStringByID(8121U));
      this.text_ItemName[index1].text = this.Cstr_ItemName[index1].ToString();
      this.text_ItemName[index1].SetAllDirty();
      this.text_ItemName[index1].cachedTextGenerator.Invalidate();
      if (!flag)
      {
        this.ChangeMultiple((byte) index1);
        this.PGO[index1].gameObject.SetActive(true);
      }
    }
    this.btn_CDTime = child7.GetChild(4).GetChild(0).GetComponent<UIButton>();
    this.btn_CDTime.m_Handler = (IUIButtonClickHandler) this;
    this.btn_CDTime.m_BtnID1 = 2;
    UIButtonHint uiButtonHint = ((Component) this.btn_CDTime).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    uiButtonHint.ControlFadeOut = ((Component) this.Img_Hint).gameObject;
    this.text_Time = child7.GetChild(4).GetChild(2).GetComponent<UIText>();
    this.text_Time.font = this.tmpFont;
    this.Cstr_Time.ClearString();
    long num1 = this.AM.mAllianceDonation_EndTime - this.DM.ServerTime;
    if (num1 < 0L)
      num1 = 0L;
    this.Cstr_Time.IntToFormat(num1 / 3600L);
    long num2 = num1 % 3600L;
    this.Cstr_Time.IntToFormat(num2 / 60L, 2);
    this.Cstr_Time.IntToFormat(num2 % 60L, 2);
    this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
    this.text_Time.text = this.Cstr_Time.ToString();
    this.text_Time.SetAllDirty();
    this.text_Time.cachedTextGenerator.Invalidate();
    this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void CheckItemQty()
  {
    for (int index1 = 0; index1 < 4; ++index1)
    {
      int index2 = (int) this.tmpDonationData[index1].DonateNumber + this.mDonationData[index1];
      if (index2 >= this.tmpDonateAmountData[index1].DonateAmount.Length)
        index2 = this.tmpDonateAmountData[index1].DonateAmount.Length - 1;
      if ((int) this.mDonationItemQty[index1] < (int) this.tmpDonateAmountData[index1].DonateAmount[index2])
        this.btn_Exchange[index1].ForTextChange(e_BtnType.e_ChangeText);
      else
        this.btn_Exchange[index1].ForTextChange(e_BtnType.e_Normal);
    }
  }

  public void SetDonate(byte mIdx)
  {
    if (mIdx < (byte) 0 || (int) mIdx >= this.mValueScale.Length)
      return;
    this.ChangeMultiple(mIdx, true);
    ++this.mDonationDataCount[(int) mIdx];
    if (!this.bShowChangValue[(int) mIdx] && (double) this.mValueScale[(int) mIdx] > 0.0)
    {
      ++this.mDonationData[(int) mIdx];
      this.Cstr_ItemNum[(int) mIdx].ClearString();
      int index = (int) this.tmpDonationData[(int) mIdx].DonateNumber + this.mDonationData[(int) mIdx];
      if (index >= this.tmpDonateAmountData[(int) mIdx].DonateAmount.Length)
        index = this.tmpDonateAmountData[(int) mIdx].DonateAmount.Length - 1;
      this.Cstr_ItemNum[(int) mIdx].IntToFormat((long) this.tmpDonateAmountData[(int) mIdx].DonateAmount[index], bNumber: true);
      if (this.GM.IsArabic)
      {
        this.Cstr_ItemNum[(int) mIdx].AppendFormat("{0}x");
        ((Transform) ((Graphic) this.text_ItemNum[(int) mIdx]).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      }
      else
      {
        this.Cstr_ItemNum[(int) mIdx].AppendFormat("x{0}");
        ((Transform) ((Graphic) this.text_ItemNum[(int) mIdx]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
      }
      this.text_ItemNum[(int) mIdx].text = this.Cstr_ItemNum[(int) mIdx].ToString();
      this.text_ItemNum[(int) mIdx].SetAllDirty();
      this.text_ItemNum[(int) mIdx].cachedTextGenerator.Invalidate();
      this.text_ItemNum[(int) mIdx].cachedTextGeneratorForLayout.Invalidate();
      ((Graphic) this.text_ItemNum[(int) mIdx]).rectTransform.anchoredPosition = new Vector2((float) (106.0 + (double) this.text_ItemNum[(int) mIdx].preferredWidth / 2.0), ((Graphic) this.text_ItemNum[(int) mIdx]).rectTransform.anchoredPosition.y);
    }
    int index1 = (int) this.tmpDonationData[(int) mIdx].DonateNumber + this.mDonationData[(int) mIdx];
    if (index1 >= this.tmpDonateAmountData[(int) mIdx].DonateAmount.Length)
      index1 = this.tmpDonateAmountData[(int) mIdx].DonateAmount.Length - 1;
    if ((int) this.mDonationItemQty[(int) mIdx] >= (int) this.tmpDonateAmountData[(int) mIdx].DonateAmount[index1])
      this.mDonationItemQty[(int) mIdx] -= this.tmpDonateAmountData[(int) mIdx].DonateAmount[index1];
    else
      this.mDonationItemQty[(int) mIdx] = (ushort) 0;
    if ((int) this.mDonationItemQty[(int) mIdx] < (int) this.tmpDonateAmountData[(int) mIdx].DonateAmount[index1])
      this.btn_Exchange[(int) mIdx].ForTextChange(e_BtnType.e_ChangeText);
    else
      this.btn_Exchange[(int) mIdx].ForTextChange(e_BtnType.e_Normal);
    this.bShowChangValue[(int) mIdx] = false;
    this.mValueScale[(int) mIdx] = 0.2f;
    if ((double) this.mSendCDTime == 0.0)
      this.mSendCDTime = 2f;
    this.mDonation_Index[(IntPtr) this.mCountValue] = (byte) ((uint) mIdx + 1U);
    ++this.mCountValue;
  }

  public void ChangeMultiple(byte mIdx, bool bShow = false)
  {
    this.Cstr_ItemName[(int) mIdx].ClearString();
    if (this.mDonationMultiple[(int) mIdx] > (byte) 1)
    {
      ((Graphic) this.Img_Multiple[(int) mIdx][0]).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.Img_Multiple[(int) mIdx][1]).color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) this.Img_Multiple[(int) mIdx][2]).color = new Color(1f, 1f, 1f, 1f);
      if (this.GM.IsArabic)
        ((Transform) ((Graphic) this.text_ItemName[(int) mIdx]).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      else
        ((Transform) ((Graphic) this.text_ItemName[(int) mIdx]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
      if (bShow)
      {
        this.mMultipleScale[(int) mIdx] = 0.2f;
        this.mShowStatus[(int) mIdx] = 4;
      }
      ((Component) this.Img_MultipleHint[(int) mIdx]).gameObject.SetActive(false);
      ((Component) this.Img_MultipleBG[(int) mIdx]).gameObject.SetActive(true);
      ((Component) this.btn_MultipleHint[(int) mIdx]).gameObject.SetActive(true);
      this.Cstr_MultipleHint[(int) mIdx].ClearString();
      if (this.GM.IsArabic)
      {
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
          this.door.SetPointTexture(this.mDonationMultiple[(int) mIdx], this.Img_Multiple[(int) mIdx][2]);
        this.Img_Multiple[(int) mIdx][1].sprite = this.door.LoadSprite("UI_mall_x_001");
      }
      else
      {
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
          this.door.SetPointTexture(this.mDonationMultiple[(int) mIdx], this.Img_Multiple[(int) mIdx][1]);
        this.Img_Multiple[(int) mIdx][2].sprite = this.door.LoadSprite("UI_mall_x_001");
      }
      this.Cstr_MultipleHint[(int) mIdx].IntToFormat((long) this.mDonationMultiple[(int) mIdx], bNumber: true);
      this.Cstr_MultipleHint[(int) mIdx].AppendFormat(this.DM.mStringTable.GetStringByID(14547U));
      this.text_MultipleHint[(int) mIdx].text = this.Cstr_MultipleHint[(int) mIdx].ToString();
      this.text_MultipleHint[(int) mIdx].SetAllDirty();
      this.text_MultipleHint[(int) mIdx].cachedTextGenerator.Invalidate();
      this.text_MultipleHint[(int) mIdx].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_MultipleHint[(int) mIdx].preferredHeight > 170.0)
        ((Graphic) this.Img_MultipleHint[(int) mIdx]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_MultipleHint[(int) mIdx]).rectTransform.sizeDelta.x, 180f);
      else
        ((Graphic) this.Img_MultipleHint[(int) mIdx]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_MultipleHint[(int) mIdx]).rectTransform.sizeDelta.x, this.text_MultipleHint[(int) mIdx].preferredHeight + 10f);
      ((Component) this.Img_Multiple[(int) mIdx][0]).gameObject.SetActive(true);
      ((Graphic) this.text_ItemName[(int) mIdx]).color = this.mColor_G;
    }
    else
    {
      if (this.GM.IsArabic)
        ((Transform) ((Graphic) this.text_ItemName[(int) mIdx]).rectTransform).localScale = new Vector3(-0.85f, 0.85f, 0.85f);
      else
        ((Transform) ((Graphic) this.text_ItemName[(int) mIdx]).rectTransform).localScale = new Vector3(0.85f, 0.85f, 0.85f);
      ((Graphic) this.text_ItemName[(int) mIdx]).color = Color.white;
      ((Component) this.Img_MultipleBG[(int) mIdx]).gameObject.SetActive(false);
      ((Component) this.btn_MultipleHint[(int) mIdx]).gameObject.SetActive(false);
    }
    this.Cstr_ItemName[(int) mIdx].IntToFormat((long) (this.tmpScore1 * (uint) this.mDonationMultiple[(int) mIdx]), bNumber: true);
    this.Cstr_ItemName[(int) mIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8121U));
    this.text_ItemName[(int) mIdx].text = this.Cstr_ItemName[(int) mIdx].ToString();
    this.text_ItemName[(int) mIdx].SetAllDirty();
    this.text_ItemName[(int) mIdx].cachedTextGenerator.Invalidate();
  }

  public void CheckDonate(int result)
  {
    switch (result)
    {
      case 0:
        this.mDonation_Score = (ulong) this.AM.mAllianceDonation_Score;
        this.SetStepScore(this.mDonation_Score + this.mAddScore);
        if (this.mCountValue != 0U)
          break;
        for (int mIdx = 0; mIdx < 4; ++mIdx)
        {
          this.tmpDonationData[mIdx] = this.AM.mAllianceDonationData[mIdx];
          this.mDonationItemQty[mIdx] = this.DM.GetCurItemQuantity(this.tmpDonationData[mIdx].itemID, this.tmpDonationData[mIdx].itemRank);
          this.mDonationMultiple[mIdx] = this.tmpDonationData[mIdx].Multiple;
          this.ChangeMultiple((byte) mIdx);
          this.mMultipleScale[mIdx] = 0.0f;
          this.mShowStatus[mIdx] = 0;
          if (this.mDonationMultiple[mIdx] == (byte) 1)
          {
            ((Component) this.Img_Multiple[mIdx][0]).gameObject.SetActive(false);
            ((Component) this.Img_MultipleHint[mIdx]).gameObject.SetActive(false);
          }
          this.Cstr_ItemNum[mIdx].ClearString();
          int index = (int) this.tmpDonationData[mIdx].DonateNumber;
          if (index >= this.tmpDonateAmountData[mIdx].DonateAmount.Length)
            index = this.tmpDonateAmountData[mIdx].DonateAmount.Length - 1;
          if ((int) this.mDonationItemQty[mIdx] < (int) this.tmpDonateAmountData[mIdx].DonateAmount[index])
            this.btn_Exchange[mIdx].ForTextChange(e_BtnType.e_ChangeText);
          else
            this.btn_Exchange[mIdx].ForTextChange(e_BtnType.e_Normal);
          this.Cstr_ItemNum[mIdx].IntToFormat((long) this.tmpDonateAmountData[mIdx].DonateAmount[index], bNumber: true);
          if (this.GM.IsArabic)
            this.Cstr_ItemNum[mIdx].AppendFormat("{0}x");
          else
            this.Cstr_ItemNum[mIdx].AppendFormat("x{0}");
          this.text_ItemNum[mIdx].text = this.Cstr_ItemNum[mIdx].ToString();
          this.text_ItemNum[mIdx].SetAllDirty();
          this.text_ItemNum[mIdx].cachedTextGenerator.Invalidate();
          this.text_ItemNum[mIdx].cachedTextGeneratorForLayout.Invalidate();
          ((Graphic) this.text_ItemNum[mIdx]).rectTransform.anchoredPosition = new Vector2((float) (106.0 + (double) this.text_ItemNum[mIdx].preferredWidth / 2.0), ((Graphic) this.text_ItemNum[mIdx]).rectTransform.anchoredPosition.y);
          if (this.GM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemNum[mIdx]).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
          else
            ((Transform) ((Graphic) this.text_ItemNum[mIdx]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
        }
        this.CheckItemQty();
        break;
      case 1:
        this.mDonation_TCount = (ushort) 0;
        for (int mIdx = 0; mIdx < 4; ++mIdx)
        {
          this.tmpDonationData[mIdx] = this.AM.mAllianceDonationData[mIdx];
          this.mDonation_TCount += this.tmpDonationData[mIdx].DonateNumber;
          this.tmpDonateAmountData[mIdx] = this.DM.DonateAmountTable.GetRecordByKey(this.AM.mAllianceDonationData[mIdx].RequireIdx);
          this.mDonationItemQty[mIdx] = this.DM.GetCurItemQuantity(this.tmpDonationData[mIdx].itemID, this.tmpDonationData[mIdx].itemRank);
          this.mDonationDataCount[mIdx] = (byte) 0;
          this.mAddScore = 0UL;
          this.mDonation_Score = (ulong) this.AM.mAllianceDonation_Score;
          this.SetStepScore(this.mDonation_Score);
          this.mDonationMultiple[mIdx] = this.tmpDonationData[mIdx].Multiple;
          this.ChangeMultiple((byte) mIdx);
          this.mMultipleScale[mIdx] = 0.0f;
          this.mShowStatus[mIdx] = 0;
          if (this.mDonationMultiple[mIdx] == (byte) 1)
            ((Component) this.Img_Multiple[mIdx][0]).gameObject.SetActive(false);
          this.mValueScale[mIdx] = 0.0f;
          this.bShowChangValue[mIdx] = true;
          this.Cstr_ItemNum[mIdx].ClearString();
          int index = (int) this.tmpDonationData[mIdx].DonateNumber;
          if (index >= this.tmpDonateAmountData[mIdx].DonateAmount.Length)
            index = this.tmpDonateAmountData[mIdx].DonateAmount.Length - 1;
          if ((int) this.mDonationItemQty[mIdx] < (int) this.tmpDonateAmountData[mIdx].DonateAmount[index])
            this.btn_Exchange[mIdx].ForTextChange(e_BtnType.e_ChangeText);
          else
            this.btn_Exchange[mIdx].ForTextChange(e_BtnType.e_Normal);
          this.Cstr_ItemNum[mIdx].IntToFormat((long) this.tmpDonateAmountData[mIdx].DonateAmount[index], bNumber: true);
          if (this.GM.IsArabic)
            this.Cstr_ItemNum[mIdx].AppendFormat("{0}x");
          else
            this.Cstr_ItemNum[mIdx].AppendFormat("x{0}");
          this.text_ItemNum[mIdx].text = this.Cstr_ItemNum[mIdx].ToString();
          this.text_ItemNum[mIdx].SetAllDirty();
          this.text_ItemNum[mIdx].cachedTextGenerator.Invalidate();
          this.text_ItemNum[mIdx].cachedTextGeneratorForLayout.Invalidate();
          ((Graphic) this.text_ItemNum[mIdx]).rectTransform.anchoredPosition = new Vector2((float) (106.0 + (double) this.text_ItemNum[mIdx].preferredWidth / 2.0), ((Graphic) this.text_ItemNum[mIdx]).rectTransform.anchoredPosition.y);
          if (this.GM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemNum[mIdx]).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
          else
            ((Transform) ((Graphic) this.text_ItemNum[mIdx]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
          ((Component) this.Img_MultipleHint[mIdx]).gameObject.SetActive(false);
        }
        this.mCountValue = 0U;
        Array.Clear((Array) this.mDonation_Index, 0, this.mDonation_Index.Length);
        this.mSendCDTime = 0.0f;
        break;
    }
  }

  private void SetStepScore(ulong Score)
  {
    this.nowScore = Score;
    this.NowScoreStr.Length = 0;
    this.NowScoreStr.uLongToFormat(Score, bNumber: true);
    this.NowScoreStr.AppendFormat("{0}");
    this.NowScoreText.text = this.NowScoreStr.ToString();
    this.NowScoreText.SetAllDirty();
    this.NowScoreText.cachedTextGenerator.Invalidate();
    ulong x = 0;
    this.nowStep = (byte) 0;
    for (int index = 0; index < 3; ++index)
    {
      if (this.nowScore >= this.StepScore[index])
        ++this.nowStep;
    }
    if (this.nowStep < (byte) 3)
    {
      x = this.StepScore[(int) this.nowStep] - Score;
      this.SliderNormal[(int) this.nowStep].fillAmount = this.nowStep != (byte) 0 ? (float) (Score - this.StepScore[(int) this.nowStep - 1]) / (float) (this.StepScore[(int) this.nowStep] - this.StepScore[(int) this.nowStep - 1]) : (float) Score / (float) this.StepScore[(int) this.nowStep];
      RectTransform rectTransform = ((Graphic) this.SliderNormal[(int) this.nowStep]).rectTransform;
      ((Graphic) this.TopTriImage).rectTransform.anchoredPosition = new Vector2((float) ((double) rectTransform.anchoredPosition.x + (double) rectTransform.sizeDelta.x * (double) this.SliderNormal[(int) this.nowStep].fillAmount - 15.0), this.TriLastPos.y);
    }
    else
      ((Graphic) this.TopTriImage).rectTransform.anchoredPosition = this.TriLastPos;
    for (int index = 0; index < (int) this.nowStep; ++index)
    {
      this.SliderNormal[index].fillAmount = 1f;
      ((Component) this.SliderFlash[index]).gameObject.SetActive(true);
      ((Graphic) this.StageScoreText[index]).color = this.StageScoreColorY;
    }
    this.NextScoreStr.Length = 0;
    this.NextScoreStr.uLongToFormat(x, bNumber: true);
    this.NextScoreStr.AppendFormat("{0}");
    this.NextScoreText.text = this.NextScoreStr.ToString();
    this.NextScoreText.SetAllDirty();
    this.NextScoreText.cachedTextGenerator.Invalidate();
  }

  public override void OnClose()
  {
    if (!this.AM.bNeedSendUpData && (double) this.AM.NeedSendUpDataTime < 0.0)
      this.AM.NeedSendUpDataTime = 180f;
    if (this.mCountValue > 0U)
      this.SendDonationValue();
    if (this.NowScoreStr != null)
      StringManager.Instance.DeSpawnString(this.NowScoreStr);
    if (this.NextScoreStr != null)
      StringManager.Instance.DeSpawnString(this.NextScoreStr);
    if (this.Cstr_Time != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Time);
    for (int index = 0; index < 3; ++index)
    {
      if (this.StageScore[index] != null)
        StringManager.Instance.DeSpawnString(this.StageScore[index]);
    }
    for (int index = 0; index < 4; ++index)
    {
      if (this.Cstr_ItemNum[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemNum[index]);
      if (this.Cstr_ItemName[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemName[index]);
      if (this.Cstr_MultipleHint[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_MultipleHint[index]);
      if (this.Cstr_AddScore[index][0] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_AddScore[index][0]);
      if (this.Cstr_AddScore[index][1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_AddScore[index][1]);
      if (this.Cstr_AddScore[index][2] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_AddScore[index][2]);
      if (this.Cstr_AddScore[index][3] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_AddScore[index][3]);
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.btn_Item[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Item[index]).enabled)
        this.btn_Item[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.Lbtn_Item[index] != (UnityEngine.Object) null && ((Behaviour) this.Lbtn_Item[index]).enabled)
        LordEquipData.ResetLordEquipFont(this.Lbtn_Item[index]);
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.Cstr_Time.ClearString();
        long num1 = this.AM.mAllianceDonation_EndTime - this.DM.ServerTime;
        if (num1 < 0L)
          num1 = 0L;
        this.Cstr_Time.IntToFormat(num1 / 3600L);
        long num2 = num1 % 3600L;
        this.Cstr_Time.IntToFormat(num2 / 60L, 2);
        this.Cstr_Time.IntToFormat(num2 % 60L, 2);
        this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
        this.text_Time.text = this.Cstr_Time.ToString();
        this.text_Time.SetAllDirty();
        this.text_Time.cachedTextGenerator.Invalidate();
        bool flag = false;
        if (!this.DM.mLordEquip.LoadLordEquip() && !this.DM.mLordEquip.LoadLEMaterial())
        {
          this.CheckDonate(1);
          flag = true;
        }
        if (!flag)
          break;
        for (int index = 0; index < 4; ++index)
        {
          this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[index].itemID);
          this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
          if (this.bLEItem)
          {
            this.GM.ChangeLordEquipImg(((Component) this.Lbtn_Item[index]).transform, this.tmpDonationData[index].itemID, this.tmpDonationData[index].itemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            this.mLbtn_ItemT[index].gameObject.SetActive(true);
            ((Component) this.btn_Item[index]).gameObject.SetActive(false);
          }
          else
          {
            this.GM.ChangeHeroItemImg(((Component) this.btn_Item[index]).transform, eHeroOrItem.Item, this.tmpDonationData[index].itemID, (byte) 0, this.tmpDonationData[index].itemRank);
            ((Component) this.btn_Item[index]).gameObject.SetActive(true);
            this.mLbtn_ItemT[index].gameObject.SetActive(false);
          }
          this.PGO[index].gameObject.SetActive(true);
        }
        break;
      case 2:
        this.CheckDonate(arg2);
        break;
      case 3:
        if (this.mDonation_Score < (ulong) this.AM.mAllianceDonation_Score)
          this.mDonation_Score = (ulong) this.AM.mAllianceDonation_Score;
        this.SetStepScore(this.mDonation_Score + this.mAddScore);
        break;
      case 4:
        this.AM.Send_ACTIVITY_AS_DONATE_BOARD();
        this.AM.bNeedSendUpData = false;
        this.mCountValue = 0U;
        Array.Clear((Array) this.mDonation_Index, 0, this.mDonation_Index.Length);
        break;
      case 5:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.RoleAlliance.Id == 0U || this.AM.AllianceSummonAllianceID == 0U || (int) this.DM.RoleAlliance.Id != (int) this.AM.AllianceSummonAllianceID || this.AM.AllianceSummonData.EventState != EActivityState.EAS_Run)
        {
          if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
            break;
          this.door.CloseMenu();
          break;
        }
        this.tmpData = this.AM.AllianceSummonData;
        this.StepScore[0] = (ulong) this.tmpData.RequireScore[0];
        this.StepScore[1] = (ulong) this.tmpData.RequireScore[1];
        this.StepScore[2] = (ulong) this.tmpData.RequireScore[2];
        for (int index = 0; index < 3; ++index)
        {
          this.StageScore[index].ClearString();
          this.StageScore[index].uLongToFormat(this.StepScore[index], bNumber: true);
          this.StageScore[index].AppendFormat("{0}");
          this.StageScoreText[index].text = this.StageScore[index].ToString();
          if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
            ((Graphic) this.StageScoreText[index]).color = this.GreenColor;
        }
        this.AM.mAllianceDonation_Score = (uint) this.AM.AllianceSummonData.EventScore;
        this.mDonation_Score = (ulong) this.AM.mAllianceDonation_Score;
        this.SetStepScore(this.mDonation_Score);
        this.AM.Send_ACTIVITY_AS_DONATE_BOARD();
        this.AM.bNeedSendUpData = false;
        if (this.DM.mLordEquip.LoadLordEquip())
          break;
        this.bEqDataReq = true;
        if (!this.DM.mLordEquip.LoadLEMaterial())
        {
          this.bMaterialDataReq = true;
          break;
        }
        if (!this.bEqDataReq || !this.bMaterialDataReq)
          break;
        this.CheckDonate(1);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UIDonation_Info);
        break;
      case 3:
        if (sender.m_BtnType == e_BtnType.e_ChangeText)
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14549U), (ushort) byte.MaxValue);
          break;
        }
        this.mExchange = (byte) sender.m_BtnID2;
        if ((UnityEngine.Object) this.btn_Exchange_Scale[(int) this.mExchange] != (UnityEngine.Object) null && this.btn_Exchange_Scale[(int) this.mExchange].enabled)
        {
          this.mBtnCD[(int) this.mExchange] = 0.2f;
          this.btn_Exchange_Scale[(int) this.mExchange].enabled = false;
        }
        this.mAddScore += (ulong) (this.tmpScore1 * (uint) this.mDonationMultiple[(int) this.mExchange]);
        this.SetStepScore(this.mDonation_Score + this.mAddScore);
        ++this.tmpAddScoreIdx[(int) this.mExchange];
        if (this.tmpAddScoreIdx[(int) this.mExchange] > (byte) 3)
          this.tmpAddScoreIdx[(int) this.mExchange] = (byte) 0;
        this.Cstr_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].ClearString();
        this.Cstr_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].IntToFormat((long) (this.tmpScore1 * (uint) this.mDonationMultiple[(int) this.mExchange]), bNumber: true);
        if (this.GM.IsArabic)
          this.Cstr_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].AppendFormat("{0}+");
        else
          this.Cstr_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].AppendFormat("+{0}");
        this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].text = this.Cstr_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].ToString();
        this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].SetAllDirty();
        this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]].cachedTextGenerator.Invalidate();
        if (this.mExchange < (byte) 2)
          ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform.anchoredPosition.x, 20f);
        else
          ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform.anchoredPosition.x, -168f);
        if (this.mDonationMultiple[(int) this.mExchange] > (byte) 1)
        {
          this.mMultipleScale[(int) this.mExchange] = 0.5f;
          this.mShowStatus[(int) this.mExchange] = 1;
          if (this.GM.IsArabic)
            ((Transform) ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
          else
            ((Transform) ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
          ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).color = this.mColor_G;
          this.tmptestY = 1.2f;
          AudioManager.Instance.PlaySFX((ushort) 3408);
        }
        else
        {
          if (this.GM.IsArabic)
            ((Transform) ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform).localScale = new Vector3(-0.7f, 0.7f, 0.7f);
          else
            ((Transform) ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
          ((Graphic) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).color = this.StageScoreColorY;
          this.tmptestY = 1f;
          AudioManager.Instance.PlayUISFX(UIKind.Gambling_Hit);
        }
        this.mShowEffectTime[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]] = 0.0f;
        ((Component) this.text_AddScore[(int) this.mExchange][(int) this.tmpAddScoreIdx[(int) this.mExchange]]).gameObject.SetActive(true);
        this.mDonationMultiple[(int) this.mExchange] = (byte) 1;
        ushort num1 = GameConstants.RandomValue(this.AM.mAllianceDonation_RandomSeed, this.AM.mAllianceDonation_Gap, this.mDonation_TCount);
        for (int index = 0; index < this.AM.mDonateChanceData.Count; ++index)
        {
          if ((int) num1 <= (int) this.AM.mDonateChanceData[index])
          {
            this.mDonationMultiple[(int) this.mExchange] = (byte) (1 + index);
            break;
          }
        }
        ++this.mDonation_TCount;
        this.SetDonate(this.mExchange);
        float num2 = this.GM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f;
        float num3 = this.GM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f;
        this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[(int) this.mExchange].itemID);
        this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
        float num4 = 0.0f;
        if (this.GM.bOpenOnIPhoneX)
          num4 = this.GM.IPhoneX_DeltaX;
        float num5 = num2 - num4;
        switch (this.mExchange)
        {
          case 0:
            Vector2 mV2_1 = new Vector2(num5 - 344f, num3 - 14f);
            this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num5 + 132f, (float) -((double) num3 - 168.0));
            if (this.bLEItem)
            {
              this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int) this.mExchange].itemRank;
              this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_1, SpeciallyEffect_Kind.Donation_Item_Material, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
              return;
            }
            this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_1, SpeciallyEffect_Kind.Donation_Item, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
            return;
          case 1:
            Vector2 mV2_2 = new Vector2(num5 + 65f, num3 - 14f);
            this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num5 + 132f, (float) -((double) num3 - 168.0));
            if (this.bLEItem)
            {
              this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int) this.mExchange].itemRank;
              this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_2, SpeciallyEffect_Kind.Donation_Item_Material, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
              return;
            }
            this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_2, SpeciallyEffect_Kind.Donation_Item, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
            return;
          case 2:
            Vector2 mV2_3 = new Vector2(num5 - 344f, num3 + 174f);
            this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num5 + 132f, (float) -((double) num3 - 168.0));
            if (this.bLEItem)
            {
              this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int) this.mExchange].itemRank;
              this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_3, SpeciallyEffect_Kind.Donation_Item_Material, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
              return;
            }
            this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_3, SpeciallyEffect_Kind.Donation_Item, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
            return;
          case 3:
            Vector2 mV2_4 = new Vector2(num5 + 65f, num3 + 174f);
            this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num5 + 132f, (float) -((double) num3 - 168.0));
            if (this.bLEItem)
            {
              this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int) this.mExchange].itemRank;
              this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_4, SpeciallyEffect_Kind.Donation_Item_Material, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
              return;
            }
            this.GM.m_SpeciallyEffect.AddIconShow(false, mV2_4, SpeciallyEffect_Kind.Donation_Item, ItemID: this.tmpDonationData[(int) this.mExchange].itemID, EndTime: 2f);
            return;
          default:
            return;
        }
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if ((UnityEngine.Object) button != (UnityEngine.Object) null)
    {
      switch (button.m_BtnID1)
      {
        case 2:
          ((Component) this.Img_Hint).gameObject.SetActive(true);
          break;
        case 4:
          if (button.m_BtnID2 < 0 || button.m_BtnID2 >= this.Img_MultipleHint.Length)
            break;
          ((Component) this.Img_MultipleHint[button.m_BtnID2]).gameObject.SetActive(true);
          break;
      }
    }
    else
    {
      this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[(int) sender.Parm1].itemID);
      this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
      if (this.bLEItem)
        this.GM.m_LordInfo.Show(sender, this.tmpDonationData[(int) sender.Parm1].itemID, this.tmpDonationData[(int) sender.Parm1].itemRank, (int) this.mDonationItemQty[(int) sender.Parm1]);
      else
        this.GM.m_SimpleItemInfo.Show(sender, this.tmpDonationData[(int) sender.Parm1].itemID, (int) this.mDonationItemQty[(int) sender.Parm1]);
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if ((UnityEngine.Object) button != (UnityEngine.Object) null)
    {
      switch (button.m_BtnID1)
      {
        case 2:
          ((Component) this.Img_Hint).gameObject.SetActive(false);
          break;
        case 4:
          if (button.m_BtnID2 < 0 || button.m_BtnID2 >= this.Img_MultipleHint.Length)
            break;
          ((Component) this.Img_MultipleHint[button.m_BtnID2]).gameObject.SetActive(false);
          break;
      }
    }
    else
    {
      this.GM.m_LordInfo.Hide(sender);
      this.GM.m_SimpleItemInfo.Hide(sender);
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (bOnSecond)
    {
      if (this.mCountValue > 0U)
      {
        --this.mSendCDTime;
        if ((double) this.mSendCDTime == 0.0)
          this.SendDonationValue();
      }
      if ((UnityEngine.Object) this.text_Time != (UnityEngine.Object) null)
      {
        this.Cstr_Time.ClearString();
        long num1 = this.AM.mAllianceDonation_EndTime - this.DM.ServerTime;
        if (num1 < 0L)
          num1 = 0L;
        this.Cstr_Time.IntToFormat(num1 / 3600L);
        long num2 = num1 % 3600L;
        this.Cstr_Time.IntToFormat(num2 / 60L, 2);
        this.Cstr_Time.IntToFormat(num2 % 60L, 2);
        this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
        this.text_Time.text = this.Cstr_Time.ToString();
        this.text_Time.SetAllDirty();
        this.text_Time.cachedTextGenerator.Invalidate();
      }
    }
    if (this.bCloseMenu && (UnityEngine.Object) this.door != (UnityEngine.Object) null)
      this.door.CloseMenu();
    for (int index1 = 0; index1 < 4; ++index1)
    {
      if ((double) this.mBtnCD[index1] > 0.0 && (UnityEngine.Object) this.btn_Exchange_Scale[index1] != (UnityEngine.Object) null)
      {
        this.mBtnCD[index1] -= Time.smoothDeltaTime;
        if ((double) this.mBtnCD[index1] < 0.0)
          this.btn_Exchange_Scale[index1].enabled = true;
      }
      if ((double) this.mValueScale[index1] > 0.0 && (UnityEngine.Object) this.text_ItemNum[index1] != (UnityEngine.Object) null)
      {
        this.mValueScale[index1] -= Time.smoothDeltaTime;
        float num;
        if ((double) this.mValueScale[index1] >= 0.10000000149011612)
          num = Mathf.Lerp(1f, 1.5f, (float) ((0.20000000298023224 - (double) this.mValueScale[index1]) * 10.0));
        else if ((double) this.mValueScale[index1] < 0.0)
        {
          this.mValueScale[index1] = 0.0f;
          num = 1f;
        }
        else
        {
          if (!this.bShowChangValue[index1])
          {
            if (this.mDonationData[index1] < (int) this.mDonationDataCount[index1])
              ++this.mDonationData[index1];
            this.Cstr_ItemNum[index1].ClearString();
            int index2 = (int) this.tmpDonationData[index1].DonateNumber + this.mDonationData[index1];
            if (index2 >= this.tmpDonateAmountData[index1].DonateAmount.Length)
              index2 = this.tmpDonateAmountData[index1].DonateAmount.Length - 1;
            this.Cstr_ItemNum[index1].IntToFormat((long) this.tmpDonateAmountData[index1].DonateAmount[index2], bNumber: true);
            if (this.GM.IsArabic)
              this.Cstr_ItemNum[index1].AppendFormat("{0}x");
            else
              this.Cstr_ItemNum[index1].AppendFormat("x{0}");
            this.text_ItemNum[index1].text = this.Cstr_ItemNum[index1].ToString();
            this.text_ItemNum[index1].SetAllDirty();
            this.text_ItemNum[index1].cachedTextGenerator.Invalidate();
            this.text_ItemNum[index1].cachedTextGeneratorForLayout.Invalidate();
            ((Graphic) this.text_ItemNum[index1]).rectTransform.anchoredPosition = new Vector2((float) (106.0 + (double) this.text_ItemNum[index1].preferredWidth / 2.0), ((Graphic) this.text_ItemNum[index1]).rectTransform.anchoredPosition.y);
            this.bShowChangValue[index1] = true;
          }
          num = Mathf.Lerp(1.5f, 1f, (float) ((0.10000000149011612 - (double) this.mValueScale[index1]) * 10.0));
        }
        if (this.GM.IsArabic)
          ((Transform) ((Graphic) this.text_ItemNum[index1]).rectTransform).localScale = new Vector3(-num, num, num);
        else
          ((Transform) ((Graphic) this.text_ItemNum[index1]).rectTransform).localScale = new Vector3(num, num, num);
      }
      if ((double) this.mMultipleScale[index1] > 0.0 && ((Component) this.Img_Multiple[index1][0]).gameObject.activeSelf)
      {
        if (this.mShowStatus[index1] == 1)
        {
          if ((double) this.mMultipleScale[index1] >= 0.40000000596046448)
          {
            this.mMultipleScale[index1] -= Time.smoothDeltaTime;
            float num = Mathf.Lerp(1f, 1.5f, (float) (20.0 * (0.5 - (double) this.mMultipleScale[index1])));
            ((Transform) ((Graphic) this.Img_Multiple[index1][0]).rectTransform).localScale = new Vector3(num, num, num);
          }
          else
            this.mShowStatus[index1] = 2;
        }
        else if (this.mShowStatus[index1] == 2)
        {
          if ((double) this.mMultipleScale[index1] > 0.20000000298023224)
            this.mMultipleScale[index1] -= Time.smoothDeltaTime;
          else
            this.mShowStatus[index1] = 3;
        }
        else if (this.mShowStatus[index1] == 3)
        {
          if ((double) this.mMultipleScale[index1] > 0.0)
          {
            this.mMultipleScale[index1] -= Time.smoothDeltaTime;
            if ((double) this.mMultipleScale[index1] <= 0.0)
            {
              this.mShowStatus[index1] = 0;
              this.mMultipleScale[index1] = 0.0f;
              ((Graphic) this.Img_Multiple[index1][0]).color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) this.Img_Multiple[index1][1]).color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) this.Img_Multiple[index1][2]).color = new Color(1f, 1f, 1f, 1f);
              ((Component) this.Img_Multiple[index1][0]).gameObject.SetActive(false);
              ((Component) this.Img_MultipleHint[index1]).gameObject.SetActive(false);
              ((Transform) ((Graphic) this.Img_Multiple[index1][0]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
              ((Graphic) this.Img_Multiple[index1][0]).color = new Color(1f, 1f, 1f, this.mMultipleScale[index1] * 5f);
              ((Graphic) this.Img_Multiple[index1][1]).color = new Color(1f, 1f, 1f, this.mMultipleScale[index1] * 5f);
              ((Graphic) this.Img_Multiple[index1][2]).color = new Color(1f, 1f, 1f, this.mMultipleScale[index1] * 5f);
            }
          }
        }
        else if (this.mShowStatus[index1] == 4)
        {
          if ((double) this.mMultipleScale[index1] >= 0.10000000149011612)
          {
            this.mMultipleScale[index1] -= Time.smoothDeltaTime;
            float num = Mathf.Lerp(1f, 1.3f, (float) (20.0 * (0.20000000298023224 - (double) this.mMultipleScale[index1])));
            if (this.GM.IsArabic)
              ((Transform) ((Graphic) this.text_ItemName[index1]).rectTransform).localScale = new Vector3(-num, num, num);
            else
              ((Transform) ((Graphic) this.text_ItemName[index1]).rectTransform).localScale = new Vector3(num, num, num);
            ((Transform) ((Graphic) this.Img_Multiple[index1][0]).rectTransform).localScale = new Vector3(num, num, num);
          }
          else
            this.mShowStatus[index1] = 5;
        }
        else if (this.mShowStatus[index1] == 5 && (double) this.mMultipleScale[index1] > 0.0)
        {
          this.mMultipleScale[index1] -= Time.smoothDeltaTime;
          float num;
          if ((double) this.mMultipleScale[index1] <= 0.0)
          {
            this.mShowStatus[index1] = 0;
            this.mMultipleScale[index1] = 0.0f;
            num = 1f;
          }
          else
            num = Mathf.Lerp(1.3f, 1f, (float) (10.0 * (0.10000000149011612 - (double) this.mMultipleScale[index1])));
          if (this.GM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemName[index1]).rectTransform).localScale = new Vector3(-num, num, num);
          else
            ((Transform) ((Graphic) this.text_ItemName[index1]).rectTransform).localScale = new Vector3(num, num, num);
          ((Transform) ((Graphic) this.Img_Multiple[index1][0]).rectTransform).localScale = new Vector3(num, num, num);
        }
      }
      for (int index3 = 0; index3 < 4; ++index3)
      {
        if (this.text_AddScore[index1] != null && (UnityEngine.Object) this.text_AddScore[index1][index3] != (UnityEngine.Object) null && ((UIBehaviour) this.text_AddScore[index1][index3]).IsActive())
        {
          this.mShowEffectTime[index1][index3] += Time.smoothDeltaTime;
          int num = index1 >= 2 ? -168 : 20;
          if ((double) ((Graphic) this.text_AddScore[index1][index3]).rectTransform.anchoredPosition.y >= (double) num + 40.0 * (double) this.tmptestY && (double) ((Graphic) this.text_AddScore[index1][index3]).rectTransform.anchoredPosition.y < (double) num + 70.0 * (double) this.tmptestY)
            ((Graphic) this.text_AddScore[index1][index3]).color = new Color(((Graphic) this.text_AddScore[index1][index3]).color.r, ((Graphic) this.text_AddScore[index1][index3]).color.g, ((Graphic) this.text_AddScore[index1][index3]).color.b, (float) (((double) num + 70.0 * (double) this.tmptestY - (double) ((Graphic) this.text_AddScore[index1][index3]).rectTransform.anchoredPosition.y) / (30.0 * (double) this.tmptestY)));
          else if ((double) ((Graphic) this.text_AddScore[index1][index3]).rectTransform.anchoredPosition.y >= (double) num + 70.0 * (double) this.tmptestY)
            ((Component) this.text_AddScore[index1][index3]).gameObject.SetActive(false);
          ((Graphic) this.text_AddScore[index1][index3]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_AddScore[index1][index3]).rectTransform.anchoredPosition.x, (float) num + this.mShowEffectTime[index1][index3] * (70f * this.tmptestY));
        }
      }
    }
  }

  public void SendDonationValue()
  {
    this.mDonation_Score += this.mAddScore;
    this.mAddScore = 0UL;
    this.mSendCDTime = 0.0f;
    ushort startTotalDonate = 0;
    for (int index = 0; index < 4; ++index)
    {
      startTotalDonate += this.tmpDonationData[index].DonateNumber;
      this.tmpDonationData[index].DonateNumber += (ushort) this.mDonationDataCount[index];
      this.mDonationData[index] = 0;
      this.mDonationDataCount[index] = (byte) 0;
    }
    this.AM.Send_ACTIVITY_AS_DONATE_DATA(startTotalDonate, (byte) this.mCountValue, this.mDonation_Index);
    Array.Clear((Array) this.mDonation_Index, 0, this.mDonation_Index.Length);
    this.mCountValue = 0U;
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.NowScoreText != (UnityEngine.Object) null && ((Behaviour) this.NowScoreText).enabled)
    {
      ((Behaviour) this.NowScoreText).enabled = false;
      ((Behaviour) this.NowScoreText).enabled = true;
    }
    if ((UnityEngine.Object) this.NextScoreText != (UnityEngine.Object) null && ((Behaviour) this.NextScoreText).enabled)
    {
      ((Behaviour) this.NextScoreText).enabled = false;
      ((Behaviour) this.NextScoreText).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Hint != (UnityEngine.Object) null && ((Behaviour) this.text_Hint).enabled)
    {
      ((Behaviour) this.text_Hint).enabled = false;
      ((Behaviour) this.text_Hint).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Time != (UnityEngine.Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_Time).enabled = false;
      ((Behaviour) this.text_Time).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.RBText[index] != (UnityEngine.Object) null && ((Behaviour) this.RBText[index]).enabled)
      {
        ((Behaviour) this.RBText[index]).enabled = false;
        ((Behaviour) this.RBText[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.StageScoreText[index] != (UnityEngine.Object) null && ((Behaviour) this.StageScoreText[index]).enabled)
      {
        ((Behaviour) this.StageScoreText[index]).enabled = false;
        ((Behaviour) this.StageScoreText[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.text_ItemExchange[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemExchange[index]).enabled)
      {
        ((Behaviour) this.text_ItemExchange[index]).enabled = false;
        ((Behaviour) this.text_ItemExchange[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemNum[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemNum[index]).enabled)
      {
        ((Behaviour) this.text_ItemNum[index]).enabled = false;
        ((Behaviour) this.text_ItemNum[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemName[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemName[index]).enabled)
      {
        ((Behaviour) this.text_ItemName[index]).enabled = false;
        ((Behaviour) this.text_ItemName[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_MultipleHint[index] != (UnityEngine.Object) null && ((Behaviour) this.text_MultipleHint[index]).enabled)
      {
        ((Behaviour) this.text_MultipleHint[index]).enabled = false;
        ((Behaviour) this.text_MultipleHint[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_AddScore[index][0] != (UnityEngine.Object) null && ((Behaviour) this.text_AddScore[index][0]).enabled)
      {
        ((Behaviour) this.text_AddScore[index][0]).enabled = false;
        ((Behaviour) this.text_AddScore[index][0]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_AddScore[index][1] != (UnityEngine.Object) null && ((Behaviour) this.text_AddScore[index][1]).enabled)
      {
        ((Behaviour) this.text_AddScore[index][1]).enabled = false;
        ((Behaviour) this.text_AddScore[index][1]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_AddScore[index][2] != (UnityEngine.Object) null && ((Behaviour) this.text_AddScore[index][2]).enabled)
      {
        ((Behaviour) this.text_AddScore[index][2]).enabled = false;
        ((Behaviour) this.text_AddScore[index][2]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_AddScore[index][3] != (UnityEngine.Object) null && ((Behaviour) this.text_AddScore[index][3]).enabled)
      {
        ((Behaviour) this.text_AddScore[index][3]).enabled = false;
        ((Behaviour) this.text_AddScore[index][3]).enabled = true;
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
