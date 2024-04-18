// Decompiled with JetBrains decompiler
// Type: UIFormationSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIFormationSelect : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  private Transform AGS_Form;
  private UISpritesArray AGS_ConformBtn_SA;
  private Door door;
  private UIButton[] CoordBtn = new UIButton[6];
  private Image[] CoordBtnImage = new Image[6];
  private Image[] CoordIconImage = new Image[6];
  private Image[] CoordIconImage2 = new Image[6];
  private UIText[] CoordBtnText = new UIText[6];
  private GameObject[] CoordBtnUseIcon = new GameObject[6];
  private GameObject[] CoordBtnLockIcon = new GameObject[6];
  private GameObject[] CoordBtnLight = new GameObject[6];
  private UIButton ConfirmBtn;
  private Image ConfirmBtnImage;
  private UIText ConfirmBtnText;
  private RectTransform BGScene;
  private RectTransform[] SoliderIcon = new RectTransform[16];
  public static byte NowArmyCoordIndex;
  public static byte ArmyCoordIndexCache;
  private UIText Label;
  private UIText Hint;
  private RectTransform HintTrans;
  private readonly ushort[] CoordTechID = new ushort[6]
  {
    (ushort) 0,
    (ushort) 136,
    (ushort) 137,
    (ushort) 138,
    (ushort) 139,
    (ushort) 140
  };
  private readonly Color32 DisableColor = new Color32((byte) 124, (byte) 124, (byte) 124, byte.MaxValue);
  private readonly Color32 NormalColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
  private readonly ushort[] LeftCoordToRightSoldier = new ushort[6]
  {
    (ushort) 1,
    (ushort) 2,
    (ushort) 0,
    (ushort) 1,
    (ushort) 2,
    (ushort) 0
  };
  private readonly byte[] IndexToSoldierKind = new byte[16]
  {
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 2,
    (byte) 2,
    (byte) 2,
    (byte) 2,
    (byte) 3,
    (byte) 3,
    (byte) 3,
    (byte) 3
  };

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.alignment = TextAnchor.MiddleCenter;
    component1.text = DataManager.Instance.mStringTable.GetStringByID(9784U);
    this.BGScene = this.AGS_Form.GetChild(1) as RectTransform;
    Image component2 = this.AGS_Form.GetChild(4).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    ((Behaviour) component2).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3).material = this.door.LoadMaterial();
    UIButton component4 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 8;
    UIButton component5 = this.AGS_Form.GetChild(5).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 10;
    ((Component) component5).gameObject.AddComponent<ArabicItemTextureRot>();
    for (int index = 0; index < 6; ++index)
    {
      Transform child = this.AGS_Form.GetChild(7).GetChild(index);
      UIButton component6 = child.GetComponent<UIButton>();
      component6.m_Handler = (IUIButtonClickHandler) this;
      component6.m_BtnID1 = 1 + index;
      this.CoordBtn[index] = component6;
      this.CoordBtnImage[index] = child.GetComponent<Image>();
      this.CoordBtnUseIcon[index] = child.GetChild(3).gameObject;
      this.CoordBtnLockIcon[index] = child.GetChild(4).gameObject;
      this.CoordBtnLight[index] = child.GetChild(5).gameObject;
      this.CoordIconImage[index] = child.GetChild(0).GetComponent<Image>();
      this.CoordIconImage2[index] = child.GetChild(1).GetComponent<Image>();
      this.CoordBtnUseIcon[index].SetActive(false);
      this.CoordBtnLockIcon[index].SetActive(false);
      this.CoordBtnLight[index].SetActive(false);
      UIText component7 = child.GetChild(2).GetComponent<UIText>();
      component7.font = ttfFont;
      component7.text = string.Empty;
      this.CoordBtnText[index] = component7;
    }
    UIButton component8 = this.AGS_Form.GetChild(8).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 7;
    this.ConfirmBtn = component8;
    this.ConfirmBtnImage = this.AGS_Form.GetChild(8).GetComponent<Image>();
    this.AGS_ConformBtn_SA = this.AGS_Form.GetChild(8).GetComponent<UISpritesArray>();
    UIText component9 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIText>();
    component9.font = ttfFont;
    component9.text = DataManager.Instance.mStringTable.GetStringByID(924U);
    this.ConfirmBtnText = component9;
    UIButton component10 = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
    component10.m_Handler = (IUIButtonClickHandler) this;
    component10.m_BtnID1 = 9;
    UIText component11 = this.AGS_Form.GetChild(10).GetComponent<UIText>();
    component11.font = ttfFont;
    component11.text = DataManager.Instance.mStringTable.GetStringByID(9786U);
    Image component12 = this.AGS_Form.GetChild(12).GetComponent<Image>();
    UIText component13 = ((Component) component12).transform.GetChild(0).GetComponent<UIText>();
    component13.font = ttfFont;
    component13.text = string.Empty;
    this.Hint = component13;
    this.HintTrans = ((Graphic) component12).rectTransform;
    ((Component) this.HintTrans).gameObject.SetActive(false);
    UIText component14 = ((Component) this.AGS_Form.GetChild(11).GetComponent<Image>()).transform.GetChild(0).GetComponent<UIText>();
    component14.font = ttfFont;
    component14.text = string.Empty;
    this.Label = component14;
    for (int index = 0; index < 16; ++index)
    {
      Transform child = this.AGS_Form.GetChild(6).GetChild(index);
      this.SoliderIcon[index] = child as RectTransform;
      UIButtonHint uiButtonHint = child.gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.Parm1 = (ushort) index;
      uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint.m_Handler = (MonoBehaviour) this;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    UIFormationSelect.NowArmyCoordIndex = UIFormationSelect.ArmyCoordIndexCache;
    this.RefreshButtonStatus();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh_Technology:
        this.UpdateUI(2, 0);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void RefreshButtonFocus()
  {
    for (int index = 0; index < 6; ++index)
    {
      if ((int) UIFormationSelect.NowArmyCoordIndex == index)
      {
        this.CoordBtnLight[index].SetActive(true);
        if (this.CoordBtnUseIcon[index].activeSelf)
          this.SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus.Used);
        else if (this.CoordBtnLockIcon[index].activeSelf)
          this.SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus.GoToCollege);
        else
          this.SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus.Setup);
      }
      else
        this.CoordBtnLight[index].SetActive(false);
    }
    this.SetupSoliderIcon();
    this.Label.text = DataManager.Instance.mStringTable.GetStringByID(9778U + (uint) UIFormationSelect.NowArmyCoordIndex);
  }

  public void RefreshButtonStatus()
  {
    for (int index = 0; index < 6; ++index)
    {
      if (index != 0)
      {
        if (DataManager.Instance.GetTechLevel(this.CoordTechID[index]) == (byte) 0)
        {
          ((Graphic) this.CoordBtnText[index]).color = (Color) this.DisableColor;
          ((Graphic) this.CoordBtnImage[index]).color = (Color) this.DisableColor;
          ((Graphic) this.CoordIconImage[index]).color = (Color) this.DisableColor;
          ((Graphic) this.CoordIconImage2[index]).color = (Color) this.DisableColor;
          this.CoordBtnLockIcon[index].SetActive(true);
        }
        else
        {
          ((Graphic) this.CoordBtnText[index]).color = (Color) this.NormalColor;
          ((Graphic) this.CoordBtnImage[index]).color = (Color) this.NormalColor;
          ((Graphic) this.CoordIconImage[index]).color = (Color) this.NormalColor;
          ((Graphic) this.CoordIconImage2[index]).color = (Color) this.NormalColor;
          this.CoordBtnLockIcon[index].SetActive(false);
        }
      }
      if ((int) DataManager.Instance.RoleAttr.NowArmyCoordIndex == index)
        this.CoordBtnUseIcon[index].SetActive(true);
      else
        this.CoordBtnUseIcon[index].SetActive(false);
    }
    this.RefreshButtonFocus();
  }

  public void SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus status)
  {
    if (status == UIFormationSelect.ECoordConfirmBtnStatus.Setup)
    {
      this.ConfirmBtnImage.sprite = this.AGS_ConformBtn_SA.GetSprite(0);
      this.ConfirmBtnText.text = DataManager.Instance.mStringTable.GetStringByID(924U);
      ((Graphic) this.ConfirmBtnText).color = (Color) new Color32(byte.MaxValue, (byte) 247, (byte) 153, byte.MaxValue);
      this.ConfirmBtn.interactable = true;
      this.ConfirmBtn.m_BtnID2 = (int) status;
      ((Graphic) this.ConfirmBtnImage).color = (Color) this.NormalColor;
    }
    if (status == UIFormationSelect.ECoordConfirmBtnStatus.GoToCollege)
    {
      this.ConfirmBtnImage.sprite = this.AGS_ConformBtn_SA.GetSprite(1);
      this.ConfirmBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3776U);
      ((Graphic) this.ConfirmBtnText).color = Color.white;
      this.ConfirmBtn.interactable = true;
      this.ConfirmBtn.m_BtnID2 = (int) status;
      ((Graphic) this.ConfirmBtnImage).color = (Color) this.NormalColor;
    }
    if (status != UIFormationSelect.ECoordConfirmBtnStatus.Used)
      return;
    this.ConfirmBtnImage.sprite = this.AGS_ConformBtn_SA.GetSprite(1);
    this.ConfirmBtnText.text = DataManager.Instance.mStringTable.GetStringByID(7444U);
    ((Graphic) this.ConfirmBtnText).color = new Color(0.898f, 0.0f, 0.31f);
    this.ConfirmBtn.interactable = false;
    this.ConfirmBtn.m_BtnID2 = (int) status;
    ((Graphic) this.ConfirmBtnImage).color = (Color) this.DisableColor;
  }

  public void ExeConfirmButtonEvent(UIFormationSelect.ECoordConfirmBtnStatus status)
  {
    if (status == UIFormationSelect.ECoordConfirmBtnStatus.Setup)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_COORD_CHANGE;
      messagePacket.Add(UIFormationSelect.NowArmyCoordIndex);
      messagePacket.Send();
    }
    else
    {
      if (status != UIFormationSelect.ECoordConfirmBtnStatus.GoToCollege)
        return;
      GUIManager.Instance.OpenTechTree(this.CoordTechID[(int) UIFormationSelect.NowArmyCoordIndex], true);
    }
  }

  public void SetupSoliderIcon()
  {
    Vector2 vector2_1 = new Vector2(-248f, -164f);
    for (int index = 0; index < 16; ++index)
    {
      CoordData recordByIndex = DataManager.Instance.CoordTable.GetRecordByIndex((int) UIFormationSelect.NowArmyCoordIndex * 16 + index);
      Vector2 vector2_2 = new Vector2((float) recordByIndex.AtkX * 0.1f, (float) recordByIndex.AtkY * 0.1f);
      this.SoliderIcon[index].anchoredPosition = vector2_1 + vector2_2;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
        UIFormationSelect.NowArmyCoordIndex = (byte) (sender.m_BtnID1 - 1);
        this.RefreshButtonStatus();
        break;
      case 7:
        this.ExeConfirmButtonEvent((UIFormationSelect.ECoordConfirmBtnStatus) sender.m_BtnID2);
        break;
      case 8:
        this.door.CloseMenu();
        break;
      case 9:
        AudioManager.Instance.PlaySFX((ushort) 40029);
        if (!WarManager.CheckVersion())
          break;
        this.SetupWarDefault();
        GUIManager.Instance.bClearWindowStack = false;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar_CoordTest);
        FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_LINEUP_DRILL);
        break;
      case 10:
        GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(9129U), DataManager.Instance.mStringTable.GetStringByID(9787U), bInfo: true, BackExit: true);
        break;
    }
  }

  public void SetupWarDefault()
  {
    WarManager.CoordSimuIndex_Left = (ushort) UIFormationSelect.NowArmyCoordIndex;
    WarManager.TroopKindSimuIndex_Right = this.LeftCoordToRightSoldier[(int) UIFormationSelect.NowArmyCoordIndex];
    UIFormationSelect.ArmyCoordIndexCache = UIFormationSelect.NowArmyCoordIndex;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(927U), (ushort) byte.MaxValue);
        this.door.CloseMenu();
        break;
      case 2:
        this.RefreshButtonStatus();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    for (int index = 0; index < 6; ++index)
    {
      UIText component2 = this.AGS_Form.GetChild(7).GetChild(index).GetChild(2).GetComponent<UIText>();
      if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
      {
        ((Behaviour) component2).enabled = false;
        ((Behaviour) component2).enabled = true;
      }
    }
    UIText component3 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(10).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    if (!((Object) this.Label != (Object) null) || !((Behaviour) this.Label).enabled)
      return;
    ((Behaviour) this.Label).enabled = false;
    ((Behaviour) this.Label).enabled = true;
  }

  public static void RecvFormation(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte num = MP.ReadByte();
    if (num < (byte) 0 || num >= (byte) 6)
      return;
    DataManager.Instance.RoleAttr.NowArmyCoordIndex = num;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_FormationSelect, 1);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 >= (ushort) 16)
      return;
    ((Component) this.HintTrans).gameObject.SetActive(true);
    this.Hint.text = DataManager.Instance.mStringTable.GetStringByID(3841U + (uint) this.IndexToSoldierKind[(int) sender.Parm1]);
    this.HintTrans.sizeDelta = new Vector2(1920f, 1920f);
    this.HintTrans.sizeDelta = new Vector2(this.Hint.preferredWidth + 35f, this.Hint.preferredHeight + 31f);
    this.Hint.UpdateArabicPos();
    this.HintTrans.anchoredPosition = ((RectTransform) sender.transform).anchoredPosition + new Vector2(0.0f, 110f);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.HintTrans).gameObject.SetActive(false);
  }

  private enum e_AGS_UI_FormationSelect
  {
    BGFrame,
    BGFrame2,
    BGLine,
    BGFrameTitle,
    exitImage,
    Infobtn,
    TroopIcons,
    FormationSelet,
    ConformBtn,
    PlayBtn,
    PlayText,
    Label,
    Hint,
  }

  private enum e_AGS_BGFrameTitle
  {
    Text,
  }

  private enum e_AGS_exitImage
  {
    exitUIButton,
  }

  private enum e_AGS_ConformBtn
  {
    UIText,
  }

  private enum e_UIFSButtonID
  {
    Default,
    CoordBtn1,
    CoordBtn2,
    CoordBtn3,
    CoordBtn4,
    CoordBtn5,
    CoordBtn6,
    ConfirmBtn,
    ExitBtn,
    PlayBtn,
    InfoBtn,
  }

  private enum ECoordBtnChild
  {
    CoordIcon,
    CoordIcon2,
    NameText,
    UseIcon,
    LockIcon,
    Light,
  }

  public enum ECoordConfirmBtnStatus
  {
    Setup,
    Used,
    GoToCollege,
  }
}
