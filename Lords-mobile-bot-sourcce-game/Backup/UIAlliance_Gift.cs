// Decompiled with JetBrains decompiler
// Type: UIAlliance_Gift
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Gift : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private Transform Tmp;
  private Transform Light_T;
  private RectTransform ImgBar_RT;
  private RectTransform GiftRT;
  private RectTransform Gift_NewRT;
  private RectTransform Gift_NameRT;
  private RectTransform btn_DeleteRT;
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private UIButton btn_EXIT;
  private UIButton btn_I;
  private UIButton btn_Delete;
  private UIButton btn_Hint;
  private UIButton btn_LVHint;
  private UIButton btn_All;
  private UIButton[] btn_Status = new UIButton[6];
  private UIHIBtn[] Hbtn_btnGift = new UIHIBtn[6];
  private UILEBtn[] Lbtn_btnGift = new UILEBtn[6];
  private Image Img_Gift;
  private Image Img_GiftNew;
  private Image Img_KeyBar;
  private Image[] Img_GetStatus = new Image[6];
  private Image[] Img_Clock = new Image[6];
  private Image[] Img_GiftKind = new Image[6];
  private Image[] Img_GiftLight = new Image[6];
  private Image Img_NoGift;
  private Image Img_GiftHint;
  private Image Img_LVHint;
  private UIText text_Lv;
  private UIText text_BarValue;
  private UIText text_GiftMax;
  private UIText text_KeyValue;
  private UIText text_GiftName;
  private UIText text_GiftHint;
  private UIText text_LVHint;
  private UIText[] text_btnStatus = new UIText[6];
  private UIText[] text_ItemGetStatus = new UIText[6];
  private UIText[] text_ItemTime = new UIText[6];
  private UIText[] text_ItemExp = new UIText[6];
  private UIText[] text_ItemNum = new UIText[6];
  private UIText[] text_ItemName = new UIText[6];
  private UIText[] text_tmpStr = new UIText[3];
  private CString Cstr_Lv;
  private CString Cstr_BarValue;
  private CString Cstr_GiftMax;
  private CString Cstr_KeyValue;
  private CString[] Cstr_ItemTime = new CString[6];
  private CString[] Cstr_ItemExp = new CString[6];
  private CString[] Cstr_ItemNum = new CString[6];
  private CString[] Cstr_ItemName = new CString[6];
  private string[] mStatus = new string[5];
  private Material m_Mat;
  private UISpritesArray SArray;
  private List<float> tmplist = new List<float>();
  private Color mColor_G = new Color(0.5412f, 0.839f, 0.3922f);
  private Color mColor_R = new Color(1f, 0.5098f, 0.4784f);
  private Equip tmpEquip;
  private float uiTimeStep;
  private Vector2 bezierCenter = new Vector2(0.0f, 100f);
  private Vector2 bezierCenter2 = new Vector2(0.0f, 100f);
  private Vector2 v2Begin = new Vector2(-263f, -39f);
  private Vector2 v2End;
  private Equip tmpEQ;
  private long tmpValue;
  private bool bShowGetNewGift;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.GameT = this.gameObject.transform;
    this.m_Mat = this.door.LoadMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    for (int index = 0; index < 5; ++index)
      this.mStatus[index] = this.DM.mStringTable.GetStringByID((uint) (ushort) (7009 + index));
    this.Cstr_Lv = StringManager.Instance.SpawnString();
    this.Cstr_BarValue = StringManager.Instance.SpawnString();
    this.Cstr_GiftMax = StringManager.Instance.SpawnString();
    this.Cstr_KeyValue = StringManager.Instance.SpawnString();
    for (int index = 0; index < 6; ++index)
    {
      this.Cstr_ItemTime[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemExp[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemNum[index] = StringManager.Instance.SpawnString(100);
      this.Cstr_ItemName[index] = StringManager.Instance.SpawnString();
    }
    this.Tmp = this.GameT.GetChild(0);
    this.text_tmpStr[0] = this.Tmp.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7001U);
    this.text_Lv = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text_Lv.font = this.TTFont;
    uint x = 0;
    for (int index = 0; index < (int) this.DM.RoleAlliance.GiftLv + 1; ++index)
      x += this.DM.AllianceLvUpData.GetRecordByKey((ushort) (index + 1)).LvExp;
    this.Cstr_Lv.ClearString();
    this.Cstr_Lv.IntToFormat((long) this.DM.RoleAlliance.GiftLv);
    this.Cstr_Lv.AppendFormat(this.DM.mStringTable.GetStringByID(7003U));
    this.text_Lv.text = this.Cstr_Lv.ToString();
    this.text_Lv.SetAllDirty();
    this.text_Lv.cachedTextGenerator.Invalidate();
    this.ImgBar_RT = this.Tmp.GetChild(3).GetChild(0).GetComponent<RectTransform>();
    this.text_BarValue = this.Tmp.GetChild(3).GetChild(1).GetComponent<UIText>();
    this.text_BarValue.font = this.TTFont;
    this.Cstr_BarValue.ClearString();
    if (this.GUIM.IsArabic)
    {
      this.Cstr_BarValue.IntToFormat((long) x, bNumber: true);
      this.Cstr_BarValue.IntToFormat((long) this.DM.RoleAlliance.GiftExp, bNumber: true);
    }
    else
    {
      this.Cstr_BarValue.IntToFormat((long) this.DM.RoleAlliance.GiftExp, bNumber: true);
      this.Cstr_BarValue.IntToFormat((long) x, bNumber: true);
    }
    this.Cstr_BarValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004U));
    this.text_BarValue.text = this.Cstr_BarValue.ToString();
    this.text_BarValue.SetAllDirty();
    this.text_BarValue.cachedTextGenerator.Invalidate();
    this.ImgBar_RT.sizeDelta = new Vector2((float) (422.0 * ((double) this.DM.RoleAlliance.GiftExp / (double) x)), this.ImgBar_RT.sizeDelta.y);
    this.text_GiftMax = this.Tmp.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.text_GiftMax.font = this.TTFont;
    this.Cstr_GiftMax.ClearString();
    this.Cstr_GiftMax.IntToFormat((long) this.DM.mShowListIdx.Count, bNumber: true);
    this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005U));
    this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
    this.text_tmpStr[1] = this.Tmp.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7006U);
    this.Light_T = this.Tmp.GetChild(6);
    this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
    Transform child1 = this.Tmp.GetChild(7);
    this.Img_GiftNew = child1.GetComponent<Image>();
    this.Img_GiftNew.sprite = this.SArray.m_Sprites[(int) this.tmpEQ.Color - 1];
    this.Gift_NewRT = child1.GetComponent<RectTransform>();
    this.text_KeyValue = this.Tmp.GetChild(9).GetChild(0).GetComponent<UIText>();
    this.text_KeyValue.font = this.TTFont;
    this.Cstr_KeyValue.ClearString();
    if (this.GUIM.IsArabic)
    {
      this.Cstr_KeyValue.IntToFormat((long) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue), bNumber: true);
      this.Cstr_KeyValue.IntToFormat((long) this.DM.RoleAlliance.PackPoint, bNumber: true);
    }
    else
    {
      this.Cstr_KeyValue.IntToFormat((long) this.DM.RoleAlliance.PackPoint, bNumber: true);
      this.Cstr_KeyValue.IntToFormat((long) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue), bNumber: true);
    }
    this.Cstr_KeyValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004U));
    this.text_KeyValue.text = this.Cstr_KeyValue.ToString();
    this.text_KeyValue.SetAllDirty();
    this.text_KeyValue.cachedTextGenerator.Invalidate();
    if (this.GUIM.IsArabic)
      this.text_KeyValue.UpdateArabicPos();
    this.Gift_NameRT = this.Tmp.GetChild(8).GetComponent<RectTransform>();
    this.text_GiftName = this.Tmp.GetChild(8).GetChild(0).GetComponent<UIText>();
    this.text_GiftName.font = this.TTFont;
    this.text_GiftName.text = this.DM.mStringTable.GetStringByID((uint) this.tmpEQ.EquipName);
    this.Img_KeyBar = this.Tmp.GetChild(10).GetChild(0).GetComponent<Image>();
    this.Img_KeyBar.fillAmount = (float) this.DM.RoleAlliance.PackPoint / (float) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue);
    this.btn_I = this.Tmp.GetChild(11).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 1;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    Transform child2 = this.Tmp.GetChild(12);
    this.btn_Delete = child2.GetComponent<UIButton>();
    this.btn_DeleteRT = child2.GetComponent<RectTransform>();
    this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Delete.m_BtnID1 = 2;
    this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
    this.btn_Delete.transition = (Selectable.Transition) 0;
    this.btn_All = this.Tmp.GetChild(13).GetComponent<UIButton>();
    this.btn_All.m_Handler = (IUIButtonClickHandler) this;
    this.btn_All.m_BtnID1 = 6;
    this.btn_All.m_EffectType = e_EffectType.e_Scale;
    this.btn_All.transition = (Selectable.Transition) 0;
    if (this.DM.RoleAttr.VIPLevel >= (byte) 12)
    {
      this.btn_DeleteRT.anchoredPosition = new Vector2(this.btn_DeleteRT.anchoredPosition.x - 60f, this.btn_DeleteRT.anchoredPosition.y);
      ((Component) this.btn_All).gameObject.SetActive(true);
    }
    this.Tmp = this.GameT.GetChild(1);
    RectTransform component1 = this.Tmp.GetComponent<RectTransform>();
    this.v2End = new Vector2(component1.anchoredPosition.x, component1.anchoredPosition.y);
    this.m_ScrollPanel = this.Tmp.GetChild(0).GetComponent<ScrollPanel>();
    Transform child3 = this.Tmp.GetChild(1);
    this.Tmp = child3.GetChild(1);
    this.GUIM.InitianHeroItemImg(((Component) this.Tmp.GetComponent<UIHIBtn>()).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0);
    this.Tmp = child3.GetChild(2);
    UILEBtn component2 = this.Tmp.GetComponent<UILEBtn>();
    this.GUIM.InitLordEquipImg(((Component) component2).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    ((Component) component2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
    this.Tmp = child3.GetChild(3);
    UIButton component3 = this.Tmp.GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 3;
    component3.SoundIndex = (byte) 64;
    component3.m_EffectType = e_EffectType.e_Scale;
    component3.transition = (Selectable.Transition) 0;
    this.Tmp = child3.GetChild(3).GetChild(0);
    this.Tmp.GetComponent<UIText>().font = this.TTFont;
    this.Tmp = child3.GetChild(4);
    Image component4 = this.Tmp.GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) component4).transform.localScale = new Vector3(-1f, ((Component) component4).transform.localScale.y, ((Component) component4).transform.localScale.z);
    this.Tmp = child3.GetChild(5).GetChild(0);
    this.Tmp.GetComponent<UIText>().font = this.TTFont;
    this.Tmp = child3.GetChild(6);
    Image component5 = this.Tmp.GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) component5).gameObject.AddComponent<ArabicItemTextureRot>();
    this.Tmp = child3.GetChild(6).GetChild(0);
    this.Tmp.GetComponent<UIText>().font = this.TTFont;
    this.Tmp = child3.GetChild(6).GetChild(1);
    this.Tmp.GetComponent<UIText>().font = this.TTFont;
    this.Tmp = child3.GetChild(7);
    this.Tmp.GetComponent<UIText>().font = this.TTFont;
    this.Tmp = child3.GetChild(8);
    this.Tmp.GetComponent<UIText>().font = this.TTFont;
    this.tmplist.Clear();
    this.m_ScrollPanel.IntiScrollPanel(446f, 5f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
    this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
    this.Tmp = this.GameT.GetChild(2);
    this.Img_Gift = this.Tmp.GetComponent<Image>();
    this.Img_Gift.sprite = this.SArray.m_Sprites[(int) this.tmpEQ.Color - 1];
    this.GiftRT = this.Tmp.GetComponent<RectTransform>();
    this.Tmp = this.GameT.GetChild(3);
    this.Img_NoGift = this.Tmp.GetComponent<Image>();
    this.text_tmpStr[2] = this.Tmp.GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(8408U);
    this.Tmp = this.GameT.GetChild(4);
    this.btn_Hint = this.Tmp.GetComponent<UIButton>();
    this.btn_Hint.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Hint.m_BtnID1 = 4;
    UIButtonHint uiButtonHint1 = ((Component) this.btn_Hint).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    Transform child4 = this.Tmp.GetChild(0);
    this.Img_GiftHint = child4.GetComponent<Image>();
    this.Img_GiftHint.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Img_GiftHint).material = this.door.LoadMaterial();
    this.text_GiftHint = child4.GetChild(0).GetComponent<UIText>();
    this.text_GiftHint.font = this.TTFont;
    this.text_GiftHint.text = this.DM.mStringTable.GetStringByID(8480U);
    this.text_GiftHint.SetAllDirty();
    this.text_GiftHint.cachedTextGenerator.Invalidate();
    this.text_GiftHint.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_GiftHint.preferredHeight > (double) ((Graphic) this.text_GiftHint).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.text_GiftHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_GiftHint).rectTransform.sizeDelta.x, this.text_GiftHint.preferredHeight + 10f);
      ((Graphic) this.Img_GiftHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_GiftHint).rectTransform.sizeDelta.x, this.text_GiftHint.preferredHeight + 20f);
    }
    uiButtonHint1.ControlFadeOut = ((Component) this.Img_GiftHint).gameObject;
    this.Tmp = this.GameT.GetChild(5);
    this.btn_LVHint = this.Tmp.GetComponent<UIButton>();
    this.btn_LVHint.m_Handler = (IUIButtonClickHandler) this;
    this.btn_LVHint.m_BtnID1 = 5;
    UIButtonHint uiButtonHint2 = ((Component) this.btn_LVHint).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    Transform child5 = this.Tmp.GetChild(0);
    this.Img_LVHint = child5.GetComponent<Image>();
    this.Img_LVHint.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Img_LVHint).material = this.door.LoadMaterial();
    this.text_LVHint = child5.GetChild(0).GetComponent<UIText>();
    this.text_LVHint.font = this.TTFont;
    this.text_LVHint.text = this.DM.mStringTable.GetStringByID(8483U);
    this.text_LVHint.SetAllDirty();
    this.text_LVHint.cachedTextGenerator.Invalidate();
    this.text_LVHint.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_LVHint.preferredHeight > (double) ((Graphic) this.text_LVHint).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.text_LVHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_LVHint).rectTransform.sizeDelta.x, this.text_LVHint.preferredHeight + 10f);
      ((Graphic) this.Img_LVHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_LVHint).rectTransform.sizeDelta.x, this.text_LVHint.preferredHeight + 30f);
    }
    uiButtonHint2.ControlFadeOut = ((Component) this.Img_LVHint).gameObject;
    Image component6 = this.GameT.GetChild(6).GetComponent<Image>();
    component6.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component6).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component6).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    this.DM.bCDStart = true;
    if (!this.DM.bSendtoGetGift && this.DM.mShowListIdx.Count == 0 && this.DM.RoleAlliance.GiftNum == (ushort) 0)
    {
      ((Component) this.Img_NoGift).gameObject.SetActive(true);
      this.m_ScrollPanel.gameObject.SetActive(false);
    }
    else if (this.DM.bSendtoGetGift)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_INFO;
      messagePacket.AddSeqId();
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Alliance_Gift);
      this.DM.bSendtoGetGift = false;
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_CHECKEXPIRED;
      messagePacket.AddSeqId();
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Alliance_Gift);
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    if (this.Cstr_Lv != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Lv);
    if (this.Cstr_BarValue != null)
      StringManager.Instance.DeSpawnString(this.Cstr_BarValue);
    if (this.Cstr_GiftMax != null)
      StringManager.Instance.DeSpawnString(this.Cstr_GiftMax);
    if (this.Cstr_KeyValue != null)
      StringManager.Instance.DeSpawnString(this.Cstr_KeyValue);
    for (int index = 0; index < 4; ++index)
    {
      if (this.Cstr_ItemTime[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemTime[index]);
      if (this.Cstr_ItemExp[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemExp[index]);
      if (this.Cstr_ItemNum[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemNum[index]);
      if (this.Cstr_ItemName[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemName[index]);
    }
    this.DM.bCDStart = false;
    if (!this.DM.bGetLeadItem)
      return;
    this.DM.bGetLeadItem = false;
    if (this.DM.mLordEquip == null)
      this.DM.mLordEquip = LordEquipData.Instance();
    this.DM.mLordEquip.Scan_MaterialOrEquipIncreace();
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
        this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(7001U), this.DM.mStringTable.GetStringByID(8407U), bInfo: true, BackExit: true);
        break;
      case 2:
        uint maxValue = uint.MaxValue;
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_DELETEBOX;
        messagePacket1.AddSeqId();
        messagePacket1.Add(maxValue);
        messagePacket1.Send();
        this.GUIM.ShowUILock(EUILock.Alliance_Gift);
        break;
      case 3:
        int btnId1 = ((Component) sender).transform.parent.GetComponent<ScrollPanelItem>().m_BtnID1;
        float num = 0.0f;
        if (this.GUIM.bOpenOnIPhoneX)
          num = this.GUIM.IPhoneX_DeltaX;
        switch (this.DM.mListGift[this.DM.mShowListIdx[btnId1]].Status)
        {
          case 0:
            MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
            messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_OPENBOX;
            messagePacket2.AddSeqId();
            messagePacket2.Add(this.DM.mListGift[this.DM.mShowListIdx[btnId1]].SN);
            messagePacket2.Send();
            this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[btnId1]].BoxItemID);
            RectTransform component1 = ((Component) sender).transform.parent.GetComponent<RectTransform>();
            RectTransform component2 = ((Component) sender).transform.parent.parent.GetComponent<RectTransform>();
            RectTransform component3 = ((Component) sender).transform.parent.parent.parent.parent.GetComponent<RectTransform>();
            this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + (double) component1.anchoredPosition.x + (double) component2.anchoredPosition.x + (double) component3.anchoredPosition.x - (double) component3.sizeDelta.x / 2.0 + 105.0), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component1.anchoredPosition.y - (double) component2.anchoredPosition.y - (double) component3.anchoredPosition.y - (double) component3.sizeDelta.y / 2.0 + 51.0));
            if (this.tmpEquip.PropertiesInfo[2].Propertieskey == (ushort) 2)
            {
              this.GUIM.m_SpeciallyEffect.mUIGiftform = this.GameT.GetChild(0).GetChild(3);
              this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 - 376.0) - num, (float) -((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - 200.0));
              this.GUIM.m_SpeciallyEffect.mAddGiftExp = true;
              return;
            }
            this.GUIM.m_SpeciallyEffect.mUIGiftKeyValueform = (Transform) null;
            this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 - 272.0) - num, (float) -((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 + 157.0));
            this.GUIM.m_SpeciallyEffect.mAddGiftPoint = true;
            return;
          case 1:
          case 2:
            MessagePacket messagePacket3 = new MessagePacket((ushort) 1024);
            messagePacket3.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_DELETEBOX;
            messagePacket3.AddSeqId();
            messagePacket3.Add(this.DM.mListGift[this.DM.mShowListIdx[btnId1]].SN);
            messagePacket3.Send();
            this.GUIM.ShowUILock(EUILock.Alliance_Gift);
            return;
          default:
            return;
        }
      case 6:
        MessagePacket messagePacket4 = new MessagePacket((ushort) 1024);
        messagePacket4.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_OPENALLBOX;
        messagePacket4.AddSeqId();
        messagePacket4.Send();
        this.GUIM.ShowUILock(EUILock.Alliance_Gift);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    switch ((Gift_Item_btn) (sender.m_Button as UIButton).m_BtnID1)
    {
      case Gift_Item_btn.btn_Hint:
        ((Component) this.Img_GiftHint).gameObject.SetActive(true);
        break;
      case Gift_Item_btn.btn_LVHint:
        ((Component) this.Img_LVHint).gameObject.SetActive(true);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    switch ((Gift_Item_btn) (sender.m_Button as UIButton).m_BtnID1)
    {
      case Gift_Item_btn.btn_Hint:
        if (!((UIBehaviour) this.Img_GiftHint).IsActive())
          break;
        ((Component) this.Img_GiftHint).gameObject.SetActive(false);
        break;
      case Gift_Item_btn.btn_LVHint:
        if (!((UIBehaviour) this.Img_LVHint).IsActive())
          break;
        ((Component) this.Img_LVHint).gameObject.SetActive(false);
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.Img_GiftLight[panelObjectIdx] = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
      this.Hbtn_btnGift[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UIHIBtn>();
      this.Lbtn_btnGift[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UILEBtn>();
      this.btn_Status[panelObjectIdx] = item.transform.GetChild(3).GetComponent<UIButton>();
      this.btn_Status[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.text_btnStatus[panelObjectIdx] = item.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
      this.Img_GetStatus[panelObjectIdx] = item.transform.GetChild(4).GetComponent<Image>();
      this.Img_Clock[panelObjectIdx] = item.transform.GetChild(5).GetComponent<Image>();
      this.text_ItemTime[panelObjectIdx] = item.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.Img_GiftKind[panelObjectIdx] = item.transform.GetChild(6).GetComponent<Image>();
      this.text_ItemExp[panelObjectIdx] = item.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
      this.text_ItemNum[panelObjectIdx] = item.transform.GetChild(6).GetChild(1).GetComponent<UIText>();
      this.text_ItemGetStatus[panelObjectIdx] = item.transform.GetChild(7).GetComponent<UIText>();
      this.text_ItemName[panelObjectIdx] = item.transform.GetChild(8).GetComponent<UIText>();
    }
    this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].BoxItemID);
    this.text_ItemName[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName);
    this.Cstr_ItemExp[panelObjectIdx].ClearString();
    this.Cstr_ItemExp[panelObjectIdx].IntToFormat((long) this.tmpEquip.PropertiesInfo[2].PropertiesValue, bNumber: true);
    if (this.GUIM.IsArabic)
      this.Cstr_ItemExp[panelObjectIdx].AppendFormat("{0}+");
    else
      this.Cstr_ItemExp[panelObjectIdx].AppendFormat("+{0}");
    this.text_ItemExp[panelObjectIdx].text = this.Cstr_ItemExp[panelObjectIdx].ToString();
    this.text_ItemExp[panelObjectIdx].SetAllDirty();
    this.text_ItemExp[panelObjectIdx].cachedTextGenerator.Invalidate();
    ((Component) this.Img_GiftLight[panelObjectIdx]).gameObject.SetActive(false);
    bool flag = false;
    if (this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Status == (byte) 2 && this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].RcvTime + 86400L < this.DM.ServerTime)
    {
      ((Component) this.Img_Clock[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.Img_GetStatus[panelObjectIdx]).gameObject.SetActive(true);
      this.Img_GetStatus[panelObjectIdx].sprite = this.SArray.m_Sprites[11];
      ((Component) this.text_ItemGetStatus[panelObjectIdx]).gameObject.SetActive(true);
      this.text_ItemGetStatus[panelObjectIdx].text = this.mStatus[4];
      ((Graphic) this.text_ItemGetStatus[panelObjectIdx]).color = this.mColor_R;
      this.text_btnStatus[panelObjectIdx].text = this.mStatus[1];
      this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[6];
      flag = true;
      this.Img_GiftKind[panelObjectIdx].sprite = this.tmpEquip.PropertiesInfo[2].Propertieskey != (ushort) 1 ? (DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? this.SArray.m_Sprites[9] : this.SArray.m_Sprites[12]) : this.SArray.m_Sprites[8];
    }
    else if (this.tmpEquip.PropertiesInfo[2].Propertieskey == (ushort) 1)
    {
      this.Img_GiftKind[panelObjectIdx].sprite = this.SArray.m_Sprites[8];
      if (this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Status == (byte) 0)
      {
        ((Component) this.Img_Clock[panelObjectIdx]).gameObject.SetActive(true);
        this.text_btnStatus[panelObjectIdx].text = this.mStatus[0];
        this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[5];
        this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_btnGift[panelObjectIdx]).transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].BoxItemID, (byte) 0, (byte) 0);
        ((Component) this.Lbtn_btnGift[panelObjectIdx]).gameObject.SetActive(false);
        ((Component) this.Hbtn_btnGift[panelObjectIdx]).gameObject.SetActive(true);
        ((Component) this.Img_GetStatus[panelObjectIdx]).gameObject.SetActive(false);
        ((Component) this.text_ItemGetStatus[panelObjectIdx]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.Img_Clock[panelObjectIdx]).gameObject.SetActive(false);
        this.text_btnStatus[panelObjectIdx].text = this.mStatus[1];
        this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[6];
        ((Component) this.Img_GetStatus[panelObjectIdx]).gameObject.SetActive(true);
        this.Img_GetStatus[panelObjectIdx].sprite = this.SArray.m_Sprites[10];
        ((Component) this.text_ItemGetStatus[panelObjectIdx]).gameObject.SetActive(true);
        this.text_ItemGetStatus[panelObjectIdx].text = this.mStatus[3];
        ((Graphic) this.text_ItemGetStatus[panelObjectIdx]).color = this.mColor_G;
        flag = true;
      }
    }
    else
    {
      this.Img_GiftKind[panelObjectIdx].sprite = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? this.SArray.m_Sprites[9] : this.SArray.m_Sprites[12];
      if (this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Status == (byte) 0)
      {
        ((Component) this.Img_Clock[panelObjectIdx]).gameObject.SetActive(true);
        this.text_btnStatus[panelObjectIdx].text = this.mStatus[2];
        this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[7];
        ((Component) this.Img_GetStatus[panelObjectIdx]).gameObject.SetActive(false);
        ((Component) this.text_ItemGetStatus[panelObjectIdx]).gameObject.SetActive(false);
        ((Component) this.Img_GiftLight[panelObjectIdx]).gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.Img_Clock[panelObjectIdx]).gameObject.SetActive(false);
        this.text_btnStatus[panelObjectIdx].text = this.mStatus[1];
        this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[6];
        ((Component) this.Img_GetStatus[panelObjectIdx]).gameObject.SetActive(true);
        ((Component) this.text_ItemGetStatus[panelObjectIdx]).gameObject.SetActive(true);
        this.Img_GetStatus[panelObjectIdx].sprite = this.SArray.m_Sprites[10];
        this.text_ItemGetStatus[panelObjectIdx].text = this.mStatus[3];
        ((Graphic) this.text_ItemGetStatus[panelObjectIdx]).color = this.mColor_G;
      }
      flag = true;
    }
    if (flag)
    {
      this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemID);
      ((Component) this.Img_GiftKind[panelObjectIdx]).gameObject.SetActive(true);
      this.Cstr_ItemNum[panelObjectIdx].ClearString();
      this.Cstr_ItemNum[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName));
      this.Cstr_ItemNum[panelObjectIdx].IntToFormat((long) this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.Num, bNumber: true);
      this.Cstr_ItemNum[panelObjectIdx].AppendFormat("{0} x {1}");
      this.text_ItemNum[panelObjectIdx].text = this.Cstr_ItemNum[panelObjectIdx].ToString();
      this.text_ItemNum[panelObjectIdx].SetAllDirty();
      this.text_ItemNum[panelObjectIdx].cachedTextGenerator.Invalidate();
      if (this.GUIM.IsLeadItem(this.tmpEquip.EquipKind))
      {
        this.GUIM.ChangeLordEquipImg(((Component) this.Lbtn_btnGift[panelObjectIdx]).transform, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemID, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        ((Component) this.Lbtn_btnGift[panelObjectIdx]).gameObject.SetActive(true);
        ((Component) this.Hbtn_btnGift[panelObjectIdx]).gameObject.SetActive(false);
      }
      else
      {
        this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_btnGift[panelObjectIdx]).transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemID, (byte) 0, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemRank);
        ((Component) this.Lbtn_btnGift[panelObjectIdx]).gameObject.SetActive(false);
        ((Component) this.Hbtn_btnGift[panelObjectIdx]).gameObject.SetActive(true);
      }
    }
    else
      ((Component) this.Img_GiftKind[panelObjectIdx]).gameObject.SetActive(false);
    if (!((Component) this.Img_Clock[panelObjectIdx]).gameObject.activeSelf)
      return;
    this.tmpValue = this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].RcvTime + 86400L - this.DM.ServerTime;
    this.Cstr_ItemTime[panelObjectIdx].ClearString();
    this.Cstr_ItemTime[panelObjectIdx].IntToFormat(this.tmpValue / 3600L);
    this.tmpValue %= 3600L;
    this.Cstr_ItemTime[panelObjectIdx].IntToFormat(this.tmpValue / 60L, 2);
    this.tmpValue %= 60L;
    this.Cstr_ItemTime[panelObjectIdx].IntToFormat(this.tmpValue, 2);
    this.Cstr_ItemTime[panelObjectIdx].AppendFormat("{0}:{1}:{2}");
    this.text_ItemTime[panelObjectIdx].text = this.Cstr_ItemTime[panelObjectIdx].ToString();
    this.text_ItemTime[panelObjectIdx].SetAllDirty();
    this.text_ItemTime[panelObjectIdx].cachedTextGenerator.Invalidate();
  }

  public void ReSetScrollData(bool bGetNew = false, ushort DeleteIdx = 500)
  {
    this.tmplist.Clear();
    this.DM.mShowListUnOpenIdx = (ushort) 0;
    this.DM.RoleAlliance.GiftNum = (ushort) 0;
    for (int index = 0; index < this.DM.mShowListIdx.Count; ++index)
    {
      if (this.DM.mListGift[this.DM.mShowListIdx[index]].Status == (byte) 0)
      {
        ++this.DM.mShowListUnOpenIdx;
        ++this.DM.RoleAlliance.GiftNum;
      }
      this.tmplist.Add(99f);
    }
    this.DM.mShowListIdx.Sort((IComparer<uint>) this.DM.mSortGift);
    this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
    this.Cstr_GiftMax.ClearString();
    this.Cstr_GiftMax.IntToFormat((long) this.DM.mShowListIdx.Count, bNumber: true);
    this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005U));
    this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
    this.text_GiftMax.SetAllDirty();
    this.text_GiftMax.cachedTextGenerator.Invalidate();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.ReSetScrollData(DeleteIdx: (ushort) 500);
        if (this.DM.mShowListIdx.Count == 0)
        {
          ((Component) this.Img_NoGift).gameObject.SetActive(true);
          this.m_ScrollPanel.gameObject.SetActive(false);
          break;
        }
        this.m_ScrollPanel.gameObject.SetActive(true);
        ((Component) this.Img_NoGift).gameObject.SetActive(false);
        break;
      case 2:
        bool flag1 = false;
        Vector2 zero1 = Vector2.zero;
        for (int index = 0; index < 6; ++index)
        {
          if (this.DM.mShowListIdx.Count > index && (Object) this.tmpItem[index] != (Object) null && this.tmpItem[index].m_BtnID1 != -1 && (int) this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1] == (int) this.DM.mGift_UpdateSN)
          {
            ((Component) this.Img_Clock[index]).gameObject.SetActive(false);
            ((Component) this.Img_GetStatus[index]).gameObject.SetActive(true);
            ((Component) this.text_ItemGetStatus[index]).gameObject.SetActive(true);
            if (this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Status == (byte) 1 && this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime > 0L)
            {
              this.Img_GetStatus[index].sprite = this.SArray.m_Sprites[10];
              this.text_ItemGetStatus[index].text = this.mStatus[3];
              ((Graphic) this.text_ItemGetStatus[index]).color = this.mColor_G;
              flag1 = true;
              if (((UIBehaviour) this.Img_GiftLight[index]).IsActive())
                ((Component) this.Img_GiftLight[index]).gameObject.SetActive(false);
            }
            else
            {
              this.Img_GetStatus[index].sprite = this.SArray.m_Sprites[11];
              this.text_ItemGetStatus[index].text = this.mStatus[4];
              ((Graphic) this.text_ItemGetStatus[index]).color = this.mColor_R;
              if (((UIBehaviour) this.Img_GiftLight[index]).IsActive())
                ((Component) this.Img_GiftLight[index]).gameObject.SetActive(false);
            }
            this.btn_Status[index].image.sprite = this.SArray.m_Sprites[6];
            this.text_btnStatus[index].text = this.mStatus[1];
            this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemID);
            ((Component) this.Img_GiftKind[index]).gameObject.SetActive(true);
            this.Cstr_ItemNum[index].ClearString();
            this.Cstr_ItemNum[index].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName));
            this.Cstr_ItemNum[index].IntToFormat((long) this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.Num, bNumber: true);
            this.Cstr_ItemNum[index].AppendFormat("{0} x {1}");
            this.text_ItemNum[index].text = this.Cstr_ItemNum[index].ToString();
            this.text_ItemNum[index].SetAllDirty();
            this.text_ItemNum[index].cachedTextGenerator.Invalidate();
            bool flag2 = this.GUIM.IsLeadItem(this.tmpEquip.EquipKind);
            if (flag2)
            {
              this.GUIM.ChangeLordEquipImg(((Component) this.Lbtn_btnGift[index]).transform, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemID, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
              ((Component) this.Lbtn_btnGift[index]).gameObject.SetActive(true);
              ((Component) this.Hbtn_btnGift[index]).gameObject.SetActive(false);
            }
            else
            {
              this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_btnGift[index]).transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemID, (byte) 0, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemRank);
              ((Component) this.Lbtn_btnGift[index]).gameObject.SetActive(false);
              ((Component) this.Hbtn_btnGift[index]).gameObject.SetActive(true);
            }
            if (flag1)
            {
              Vector2 mStartV2 = this.GUIM.mStartV2;
              RectTransform component1 = ((Component) this.Hbtn_btnGift[index]).transform.parent.GetComponent<RectTransform>();
              RectTransform component2 = ((Component) this.Hbtn_btnGift[index]).transform.parent.parent.GetComponent<RectTransform>();
              RectTransform component3 = ((Component) this.Hbtn_btnGift[index]).transform.parent.parent.parent.GetComponent<RectTransform>();
              RectTransform component4 = ((Component) this.Hbtn_btnGift[index]).transform.parent.parent.parent.parent.GetComponent<RectTransform>();
              this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + (double) component4.anchoredPosition.x - (double) component3.sizeDelta.x / 2.0 + 12.0 + 35.0), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component4.anchoredPosition.y - (double) component4.sizeDelta.y / 2.0 + (double) component3.anchoredPosition.y - (double) component2.anchoredPosition.y - (double) component1.anchoredPosition.y + 10.0 + 35.0));
              GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = 0U;
              if (this.tmpEquip.EquipKind != (byte) 11)
              {
                if (flag2)
                {
                  this.GUIM.SE_Item_L_Color[0] = this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemRank;
                  this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item_Material, ItemID: this.tmpEquip.EquipKey, EndTime: 2f);
                }
                else
                  this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, ItemID: this.tmpEquip.EquipKey, EndTime: 2f);
              }
              else if (this.tmpEquip.PropertiesInfo[0].Propertieskey < (ushort) 6)
                this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, ItemID: this.tmpEquip.EquipKey, EndTime: 2f);
              else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 6)
              {
                this.GUIM.m_SpeciallyEffect.mDiamondValue = (uint) this.tmpEquip.PropertiesInfo[1].Propertieskey * (uint) this.tmpEquip.PropertiesInfo[1].PropertiesValue;
                this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Diamond, ItemID: (ushort) 0, EndTime: 2f);
              }
              else
                this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.AllianceMoney, ItemID: (ushort) 0, EndTime: 2f);
              this.GUIM.mStartV2 = mStartV2;
              AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
            }
          }
        }
        this.DM.mGift_UpdateSN = 0U;
        this.Cstr_GiftMax.ClearString();
        this.Cstr_GiftMax.IntToFormat((long) this.DM.mShowListIdx.Count, bNumber: true);
        this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005U));
        this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
        this.text_GiftMax.SetAllDirty();
        this.text_GiftMax.cachedTextGenerator.Invalidate();
        break;
      case 3:
        this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
        this.text_GiftName.text = this.DM.mStringTable.GetStringByID((uint) this.tmpEQ.EquipName);
        this.Cstr_KeyValue.ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_KeyValue.IntToFormat((long) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue), bNumber: true);
          this.Cstr_KeyValue.IntToFormat((long) this.DM.RoleAlliance.PackPoint, bNumber: true);
        }
        else
        {
          this.Cstr_KeyValue.IntToFormat((long) this.DM.RoleAlliance.PackPoint, bNumber: true);
          this.Cstr_KeyValue.IntToFormat((long) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue), bNumber: true);
        }
        this.Cstr_KeyValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004U));
        this.text_KeyValue.text = this.Cstr_KeyValue.ToString();
        this.text_KeyValue.SetAllDirty();
        this.text_KeyValue.cachedTextGenerator.Invalidate();
        if (this.GUIM.IsArabic)
          this.text_KeyValue.UpdateArabicPos();
        this.Img_KeyBar.fillAmount = (float) this.DM.RoleAlliance.PackPoint / (float) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue);
        this.uiTimeStep = 0.0f;
        this.bShowGetNewGift = true;
        this.GUIM.m_SpeciallyEffect.mUIGiftKeyValueform = ((Component) this.text_KeyValue).transform;
        this.Light_T.gameObject.SetActive(false);
        ((Component) this.Gift_NewRT).gameObject.SetActive(true);
        this.Img_GiftNew.sprite = this.SArray.m_Sprites[(int) this.tmpEQ.Color - 1];
        break;
      case 4:
        this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
        this.Cstr_KeyValue.ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_KeyValue.IntToFormat((long) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue), bNumber: true);
          this.Cstr_KeyValue.IntToFormat((long) this.DM.RoleAlliance.PackPoint, bNumber: true);
        }
        else
        {
          this.Cstr_KeyValue.IntToFormat((long) this.DM.RoleAlliance.PackPoint, bNumber: true);
          this.Cstr_KeyValue.IntToFormat((long) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue), bNumber: true);
        }
        this.Cstr_KeyValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004U));
        this.text_KeyValue.text = this.Cstr_KeyValue.ToString();
        this.text_KeyValue.SetAllDirty();
        this.text_KeyValue.cachedTextGenerator.Invalidate();
        if (this.GUIM.IsArabic)
          this.text_KeyValue.UpdateArabicPos();
        this.Img_KeyBar.fillAmount = (float) this.DM.RoleAlliance.PackPoint / (float) ((int) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (int) this.tmpEQ.PropertiesInfo[5].PropertiesValue);
        this.GUIM.m_SpeciallyEffect.mUIGiftKeyValueform = ((Component) this.text_KeyValue).transform;
        if (!this.GUIM.m_SpeciallyEffect.mAddGiftPoint)
          break;
        GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Alliance_Gift_Key, ItemID: (ushort) 0, EndTime: 2f);
        break;
      case 5:
        uint x = 0;
        for (int index = 0; index < (int) this.DM.RoleAlliance.GiftLv + 1; ++index)
          x += this.DM.AllianceLvUpData.GetRecordByKey((ushort) (index + 1)).LvExp;
        this.Cstr_Lv.ClearString();
        this.Cstr_Lv.IntToFormat((long) this.DM.RoleAlliance.GiftLv);
        this.Cstr_Lv.AppendFormat(this.DM.mStringTable.GetStringByID(7003U));
        this.text_Lv.text = this.Cstr_Lv.ToString();
        this.text_Lv.SetAllDirty();
        this.text_Lv.cachedTextGenerator.Invalidate();
        this.Cstr_BarValue.ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_BarValue.IntToFormat((long) x, bNumber: true);
          this.Cstr_BarValue.IntToFormat((long) this.DM.RoleAlliance.GiftExp, bNumber: true);
        }
        else
        {
          this.Cstr_BarValue.IntToFormat((long) this.DM.RoleAlliance.GiftExp, bNumber: true);
          this.Cstr_BarValue.IntToFormat((long) x, bNumber: true);
        }
        this.Cstr_BarValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004U));
        this.text_BarValue.text = this.Cstr_BarValue.ToString();
        this.text_BarValue.SetAllDirty();
        this.text_BarValue.cachedTextGenerator.Invalidate();
        this.ImgBar_RT.sizeDelta = new Vector2((float) (422.0 * ((double) this.DM.RoleAlliance.GiftExp / (double) x)), this.ImgBar_RT.sizeDelta.y);
        if (!this.GUIM.m_SpeciallyEffect.mAddGiftExp)
          break;
        GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Alliance_Gift, ItemID: (ushort) 0, EndTime: 2f);
        break;
      case 6:
        this.DM.bSendtoGetGift = false;
        break;
      case 7:
        this.tmplist.Clear();
        this.DM.mShowListUnOpenIdx = (ushort) 0;
        for (int index = 0; index < this.DM.mShowListIdx.Count; ++index)
        {
          if (this.DM.mListGift[this.DM.mShowListIdx[index]].Status == (byte) 0)
            ++this.DM.mShowListUnOpenIdx;
          this.tmplist.Add(99f);
        }
        if (this.DM.mShowListIdx.Count > 6 && arg2 == 1)
          this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        else
          this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        this.Cstr_GiftMax.ClearString();
        this.Cstr_GiftMax.IntToFormat((long) this.DM.mShowListIdx.Count, bNumber: true);
        this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005U));
        this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
        this.text_GiftMax.SetAllDirty();
        this.text_GiftMax.cachedTextGenerator.Invalidate();
        if (this.DM.mShowListIdx.Count == 0)
        {
          ((Component) this.Img_NoGift).gameObject.SetActive(true);
          this.m_ScrollPanel.gameObject.SetActive(false);
          break;
        }
        this.m_ScrollPanel.gameObject.SetActive(true);
        ((Component) this.Img_NoGift).gameObject.SetActive(false);
        break;
      case 8:
        if (this.DM.RoleAttr.VIPLevel < (byte) 12)
          break;
        this.btn_DeleteRT.anchoredPosition = new Vector2(this.btn_DeleteRT.anchoredPosition.x - 60f, this.btn_DeleteRT.anchoredPosition.y);
        ((Component) this.btn_All).gameObject.SetActive(true);
        break;
      case 9:
        Vector2 zero2 = Vector2.zero;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = -1;
        int num5 = 300;
        for (int index = 0; index < 6; ++index)
        {
          if ((Object) this.Img_Clock[index] != (Object) null && ((Component) this.Img_Clock[index]).gameObject.activeSelf)
            ++num2;
          if ((Object) this.tmpItem[index] != (Object) null && ((Component) this.tmpItem[index]).gameObject.activeSelf)
            ++num3;
          if ((Object) this.tmpItem[index] != (Object) null && this.tmpItem[index].m_BtnID1 != -1 && num5 > this.tmpItem[index].m_BtnID1)
          {
            num4 = index;
            num5 = this.tmpItem[index].m_BtnID1;
          }
        }
        for (int index = 0; index < 6; ++index)
        {
          if ((Object) this.Img_Clock[index] != (Object) null && ((Component) this.Img_Clock[index]).gameObject.activeSelf)
          {
            bool flag3 = false;
            if (this.DM.mShowListIdx.Count > index && (Object) this.tmpItem[index] != (Object) null && this.tmpItem[index].m_BtnID1 != -1)
            {
              ((Component) this.Img_Clock[index]).gameObject.SetActive(false);
              ((Component) this.Img_GetStatus[index]).gameObject.SetActive(true);
              ((Component) this.text_ItemGetStatus[index]).gameObject.SetActive(true);
              if (this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Status == (byte) 1 && this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime > 0L)
              {
                this.Img_GetStatus[index].sprite = this.SArray.m_Sprites[10];
                this.text_ItemGetStatus[index].text = this.mStatus[3];
                ((Graphic) this.text_ItemGetStatus[index]).color = this.mColor_G;
                flag3 = true;
                if (((UIBehaviour) this.Img_GiftLight[index]).IsActive())
                  ((Component) this.Img_GiftLight[index]).gameObject.SetActive(false);
              }
              else
              {
                this.Img_GetStatus[index].sprite = this.SArray.m_Sprites[11];
                this.text_ItemGetStatus[index].text = this.mStatus[4];
                ((Graphic) this.text_ItemGetStatus[index]).color = this.mColor_R;
                if (((UIBehaviour) this.Img_GiftLight[index]).IsActive())
                  ((Component) this.Img_GiftLight[index]).gameObject.SetActive(false);
              }
              this.btn_Status[index].image.sprite = this.SArray.m_Sprites[6];
              this.text_btnStatus[index].text = this.mStatus[1];
              this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemID);
              ((Component) this.Img_GiftKind[index]).gameObject.SetActive(true);
              this.Cstr_ItemNum[index].ClearString();
              this.Cstr_ItemNum[index].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName));
              this.Cstr_ItemNum[index].IntToFormat((long) this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.Num, bNumber: true);
              this.Cstr_ItemNum[index].AppendFormat("{0} x {1}");
              this.text_ItemNum[index].text = this.Cstr_ItemNum[index].ToString();
              this.text_ItemNum[index].SetAllDirty();
              this.text_ItemNum[index].cachedTextGenerator.Invalidate();
              bool flag4 = this.GUIM.IsLeadItem(this.tmpEquip.EquipKind);
              if (flag4)
              {
                this.GUIM.ChangeLordEquipImg(((Component) this.Lbtn_btnGift[index]).transform, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemID, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
                ((Component) this.Lbtn_btnGift[index]).gameObject.SetActive(true);
                ((Component) this.Hbtn_btnGift[index]).gameObject.SetActive(false);
              }
              else
              {
                this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_btnGift[index]).transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemID, (byte) 0, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemRank);
                ((Component) this.Lbtn_btnGift[index]).gameObject.SetActive(false);
                ((Component) this.Hbtn_btnGift[index]).gameObject.SetActive(true);
              }
              if ((num2 != 6 || num3 != 6 || num4 != index || !flag3) && flag3 && num1 < 5 && ((Component) this.tmpItem[index]).gameObject.activeSelf)
              {
                ++num1;
                Vector2 mStartV2 = this.GUIM.mStartV2;
                RectTransform component5 = ((Component) this.Hbtn_btnGift[index]).transform.parent.GetComponent<RectTransform>();
                RectTransform component6 = ((Component) this.Hbtn_btnGift[index]).transform.parent.parent.GetComponent<RectTransform>();
                RectTransform component7 = ((Component) this.Hbtn_btnGift[index]).transform.parent.parent.parent.GetComponent<RectTransform>();
                RectTransform component8 = ((Component) this.Hbtn_btnGift[index]).transform.parent.parent.parent.parent.GetComponent<RectTransform>();
                this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + (double) component8.anchoredPosition.x - (double) component7.sizeDelta.x / 2.0 + 12.0 + 35.0), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component8.anchoredPosition.y - (double) component8.sizeDelta.y / 2.0 + (double) component7.anchoredPosition.y - (double) component6.anchoredPosition.y - (double) component5.anchoredPosition.y + 10.0 + 35.0));
                GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = 0U;
                if (this.tmpEquip.EquipKind != (byte) 11)
                {
                  if (flag4)
                  {
                    this.GUIM.SE_Item_L_Color[0] = this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Item.ItemRank;
                    this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item_Material, ItemID: this.tmpEquip.EquipKey, EndTime: 2f);
                  }
                  else
                    this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, ItemID: this.tmpEquip.EquipKey, EndTime: 2f);
                }
                else if (this.tmpEquip.PropertiesInfo[0].Propertieskey < (ushort) 6)
                  this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, ItemID: this.tmpEquip.EquipKey, EndTime: 2f);
                else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 6)
                {
                  this.GUIM.m_SpeciallyEffect.mDiamondValue = (uint) this.tmpEquip.PropertiesInfo[1].Propertieskey * (uint) this.tmpEquip.PropertiesInfo[1].PropertiesValue;
                  this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Diamond, ItemID: (ushort) 0, EndTime: 2f);
                }
                else
                  this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.AllianceMoney, ItemID: (ushort) 0, EndTime: 2f);
                this.GUIM.mStartV2 = mStartV2;
                AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
              }
            }
          }
        }
        this.Cstr_GiftMax.ClearString();
        this.Cstr_GiftMax.IntToFormat((long) this.DM.mShowListIdx.Count, bNumber: true);
        this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005U));
        this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
        this.text_GiftMax.SetAllDirty();
        this.text_GiftMax.cachedTextGenerator.Invalidate();
        break;
      case 10:
        if (!((Object) this.door != (Object) null) || this.DM.RoleAlliance.Id != 0U)
          break;
        this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Gift);
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
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Gift);
          break;
        }
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_INFO;
        messagePacket.AddSeqId();
        messagePacket.Send();
        GUIManager.Instance.ShowUILock(EUILock.Alliance_Gift);
        this.DM.bSendtoGetGift = false;
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Lv != (Object) null && ((Behaviour) this.text_Lv).enabled)
    {
      ((Behaviour) this.text_Lv).enabled = false;
      ((Behaviour) this.text_Lv).enabled = true;
    }
    if ((Object) this.text_BarValue != (Object) null && ((Behaviour) this.text_BarValue).enabled)
    {
      ((Behaviour) this.text_BarValue).enabled = false;
      ((Behaviour) this.text_BarValue).enabled = true;
    }
    if ((Object) this.text_GiftMax != (Object) null && ((Behaviour) this.text_GiftMax).enabled)
    {
      ((Behaviour) this.text_GiftMax).enabled = false;
      ((Behaviour) this.text_GiftMax).enabled = true;
    }
    if ((Object) this.text_KeyValue != (Object) null && ((Behaviour) this.text_KeyValue).enabled)
    {
      ((Behaviour) this.text_KeyValue).enabled = false;
      ((Behaviour) this.text_KeyValue).enabled = true;
    }
    if ((Object) this.text_GiftName != (Object) null && ((Behaviour) this.text_GiftName).enabled)
    {
      ((Behaviour) this.text_GiftName).enabled = false;
      ((Behaviour) this.text_GiftName).enabled = true;
    }
    if ((Object) this.text_GiftHint != (Object) null && ((Behaviour) this.text_GiftHint).enabled)
    {
      ((Behaviour) this.text_GiftHint).enabled = false;
      ((Behaviour) this.text_GiftHint).enabled = true;
    }
    if ((Object) this.text_LVHint != (Object) null && ((Behaviour) this.text_LVHint).enabled)
    {
      ((Behaviour) this.text_LVHint).enabled = false;
      ((Behaviour) this.text_LVHint).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.text_btnStatus[index] != (Object) null && ((Behaviour) this.text_btnStatus[index]).enabled)
      {
        ((Behaviour) this.text_btnStatus[index]).enabled = false;
        ((Behaviour) this.text_btnStatus[index]).enabled = true;
      }
      if ((Object) this.text_ItemGetStatus[index] != (Object) null && ((Behaviour) this.text_ItemGetStatus[index]).enabled)
      {
        ((Behaviour) this.text_ItemGetStatus[index]).enabled = false;
        ((Behaviour) this.text_ItemGetStatus[index]).enabled = true;
      }
      if ((Object) this.text_ItemTime[index] != (Object) null && ((Behaviour) this.text_ItemTime[index]).enabled)
      {
        ((Behaviour) this.text_ItemTime[index]).enabled = false;
        ((Behaviour) this.text_ItemTime[index]).enabled = true;
      }
      if ((Object) this.text_ItemExp[index] != (Object) null && ((Behaviour) this.text_ItemExp[index]).enabled)
      {
        ((Behaviour) this.text_ItemExp[index]).enabled = false;
        ((Behaviour) this.text_ItemExp[index]).enabled = true;
      }
      if ((Object) this.text_ItemNum[index] != (Object) null && ((Behaviour) this.text_ItemNum[index]).enabled)
      {
        ((Behaviour) this.text_ItemNum[index]).enabled = false;
        ((Behaviour) this.text_ItemNum[index]).enabled = true;
      }
      if ((Object) this.text_ItemName[index] != (Object) null && ((Behaviour) this.text_ItemName[index]).enabled)
      {
        ((Behaviour) this.text_ItemName[index]).enabled = false;
        ((Behaviour) this.text_ItemName[index]).enabled = true;
      }
      if ((Object) this.Hbtn_btnGift[index] != (Object) null && ((Behaviour) this.Hbtn_btnGift[index]).enabled)
        this.Hbtn_btnGift[index].Refresh_FontTexture();
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  private void Start()
  {
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    for (int index = 0; index < 6; ++index)
    {
      if (this.DM.mShowListIdx.Count > index && (Object) this.tmpItem[index] != (Object) null && this.tmpItem[index].m_BtnID1 >= 0 && this.tmpItem[index].m_BtnID1 <= this.DM.mShowListIdx.Count && this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].Status == (byte) 0)
      {
        this.tmpValue = this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime;
        this.Cstr_ItemTime[index].ClearString();
        this.Cstr_ItemTime[index].IntToFormat(this.tmpValue / 3600L);
        this.tmpValue %= 3600L;
        this.Cstr_ItemTime[index].IntToFormat(this.tmpValue / 60L, 2);
        this.tmpValue %= 60L;
        this.Cstr_ItemTime[index].IntToFormat(this.tmpValue, 2);
        this.Cstr_ItemTime[index].AppendFormat("{0}:{1}:{2}");
        this.text_ItemTime[index].text = this.Cstr_ItemTime[index].ToString();
        this.text_ItemTime[index].SetAllDirty();
        this.text_ItemTime[index].cachedTextGenerator.Invalidate();
        if (this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime <= 0L)
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_OPENBOX;
          messagePacket.AddSeqId();
          messagePacket.Add(this.DM.mShowListIdx[this.tmpItem[index].m_BtnID1]);
          messagePacket.Send();
          this.GUIM.ShowUILock(EUILock.Alliance_Gift);
        }
      }
    }
  }

  private void Update()
  {
    if ((Object) this.Light_T != (Object) null)
      this.Light_T.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.Img_GiftLight[index] != (Object) null && ((UIBehaviour) this.Img_GiftLight[index]).IsActive())
        ((Component) this.Img_GiftLight[index]).transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    }
    if (!this.bShowGetNewGift)
      return;
    this.GiftRT.anchoredPosition = GameConstants.CubicBezierCurves(this.v2Begin, this.bezierCenter, this.bezierCenter2, this.v2End, 0.5f, this.uiTimeStep);
    ((Transform) this.GiftRT).localScale = new Vector3((float) (1.0 - (double) this.uiTimeStep / 2.0), (float) (1.0 - (double) this.uiTimeStep / 2.0), (float) (1.0 - (double) this.uiTimeStep / 2.0));
    if ((double) this.uiTimeStep > 1.0)
      ((Graphic) this.Img_Gift).color = new Color(1f, 1f, 1f, 2f - this.uiTimeStep);
    if ((double) this.uiTimeStep < 1.7999999523162842)
    {
      ((Transform) this.Gift_NewRT).localScale = new Vector3((float) (0.20000000298023224 + (double) this.uiTimeStep / 2.0), (float) (0.20000000298023224 + (double) this.uiTimeStep / 2.0), (float) (0.20000000298023224 + (double) this.uiTimeStep / 2.0));
      ((Transform) this.Gift_NameRT).localScale = new Vector3((float) (0.20000000298023224 + (double) this.uiTimeStep / 2.0), (float) (0.20000000298023224 + (double) this.uiTimeStep / 2.0), (float) (0.20000000298023224 + (double) this.uiTimeStep / 2.0));
    }
    else
    {
      ((Transform) this.Gift_NewRT).localScale = new Vector3((float) (2.0 - (double) this.uiTimeStep / 2.0), (float) (2.0 - (double) this.uiTimeStep / 2.0), (float) (2.0 - (double) this.uiTimeStep / 2.0));
      ((Transform) this.Gift_NameRT).localScale = new Vector3((float) (2.0 - (double) this.uiTimeStep / 2.0), (float) (2.0 - (double) this.uiTimeStep / 2.0), (float) (2.0 - (double) this.uiTimeStep / 2.0));
    }
    this.uiTimeStep += Time.smoothDeltaTime;
    if ((double) this.uiTimeStep <= 2.0)
      return;
    this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
    ((Transform) this.Gift_NewRT).localScale = new Vector3(1f, 1f, 1f);
    ((Transform) this.Gift_NameRT).localScale = new Vector3(1f, 1f, 1f);
    this.GiftRT.anchoredPosition = this.v2Begin;
    ((Transform) this.GiftRT).localScale = new Vector3(1f, 1f, 1f);
    ((Graphic) this.Img_Gift).color = new Color(1f, 1f, 1f, 1f);
    this.Img_Gift.sprite = this.SArray.m_Sprites[(int) this.tmpEQ.Color - 1];
    this.bShowGetNewGift = false;
    this.Light_T.gameObject.SetActive(true);
    ((Component) this.Gift_NewRT).gameObject.SetActive(false);
    this.uiTimeStep = 0.0f;
  }
}
