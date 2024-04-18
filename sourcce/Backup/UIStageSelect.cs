// Decompiled with JetBrains decompiler
// Type: UIStageSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIStageSelect : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  private Transform m_transform;
  private Transform Left_T;
  private Transform Right_T;
  private Transform EliteT;
  private Transform AllianceT;
  private UIText StageName;
  private UIText NormalText;
  private UIText EliteText;
  private UIText AllianceText;
  private UIText chapName;
  public GameObject NormalObj;
  public GameObject EliteObj;
  public GameObject AllianceObj1;
  public GameObject AllianceObj2;
  public GameObject NFlash;
  public GameObject EFlash;
  public GameObject AFlash;
  private DataManager DM;
  private GUIManager GM;
  private CString tmpString;
  private CString tmpString2;
  private Vector3 BtnPos;
  private float MoveX;
  private float LeftPosX;
  private float RightPosX;
  private UIButton m_HelpAlert;
  private RectTransform m_HelpAlertRC;
  private UIText m_HelpAlertext;
  private CString m_HelpAlertStr;
  private GameObject m_HelpAlertImageGO;
  private UIText m_HelpAlertext2;
  private CString m_HelpAlertStr2;
  private CustomImage m_HelpAlertL;
  private CustomImage m_HelpAlertR;
  public UIButton m_ExitBtn;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.m_transform = this.transform;
    Font ttfFont = this.GM.GetTTFFont();
    this.tmpString = StringManager.Instance.SpawnString();
    this.tmpString2 = StringManager.Instance.SpawnString();
    DataManager.StageDataController.ReBackCurrentChapter();
    this.NFlash = this.m_transform.GetChild(1).GetChild(0).gameObject;
    this.NormalText = this.m_transform.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.NormalText.font = ttfFont;
    this.NormalText.text = this.DM.mStringTable.GetStringByID(40U);
    this.EliteT = this.m_transform.GetChild(2);
    this.EFlash = this.EliteT.GetChild(0).gameObject;
    this.EliteText = this.EliteT.GetChild(1).GetComponent<UIText>();
    this.EliteText.font = ttfFont;
    this.EliteText.text = this.DM.mStringTable.GetStringByID(41U);
    this.AllianceT = this.m_transform.GetChild(3);
    this.AFlash = this.AllianceT.GetChild(0).gameObject;
    this.AllianceText = this.AllianceT.GetChild(1).GetComponent<UIText>();
    this.AllianceText.font = ttfFont;
    this.AllianceText.text = this.DM.mStringTable.GetStringByID(42U);
    this.Left_T = this.m_transform.GetChild(4);
    this.Right_T = this.m_transform.GetChild(5);
    this.LeftPosX = this.Left_T.localPosition.x + 20f;
    this.RightPosX = this.Right_T.localPosition.x - 20f;
    this.MoveX = 0.0f;
    this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(3).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_ExitBtn = this.m_transform.GetChild(6).GetChild(0).GetComponent<UIButton>();
    this.m_ExitBtn.m_Handler = (IUIButtonClickHandler) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(6).GetComponent<Image>()).enabled = false;
    this.NormalObj = this.m_transform.GetChild(7).gameObject;
    this.EliteObj = this.m_transform.GetChild(8).gameObject;
    this.AllianceObj1 = this.m_transform.GetChild(0).gameObject;
    this.AllianceObj2 = this.m_transform.GetChild(9).gameObject;
    this.chapName = this.m_transform.GetChild(10).GetComponent<UIText>();
    this.chapName.font = ttfFont;
    this.StageName = this.m_transform.GetChild(11).GetComponent<UIText>();
    this.StageName.font = ttfFont;
    Transform child1 = this.m_transform.GetChild(12);
    this.m_HelpAlert = child1.GetComponent<UIButton>();
    this.m_HelpAlert.m_Handler = (IUIButtonClickHandler) this;
    this.m_HelpAlertImageGO = child1.GetChild(0).gameObject;
    this.m_HelpAlertext2 = child1.GetChild(1).GetComponent<UIText>();
    this.m_HelpAlertext2.font = this.GM.GetTTFFont();
    this.m_HelpAlertStr2 = StringManager.Instance.SpawnString();
    Transform child2 = child1.GetChild(2);
    this.m_HelpAlertRC = child2.GetComponent<RectTransform>();
    this.m_HelpAlertext = child2.GetChild(0).GetComponent<UIText>();
    this.m_HelpAlertext.font = this.GM.GetTTFFont();
    this.m_HelpAlertStr = StringManager.Instance.SpawnString();
    this.m_HelpAlertL = this.m_transform.GetChild(12).GetChild(3).GetComponent<CustomImage>();
    this.m_HelpAlertR = this.m_transform.GetChild(12).GetChild(4).GetComponent<CustomImage>();
    this.m_transform.GetChild(12).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(12).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(12).GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(12).GetChild(3).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(12).GetChild(4).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.IsArabic)
    {
      ((Component) this.m_HelpAlertL).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Component) this.m_HelpAlertR).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    this.CheckHelpAlertState();
    this.CheckLRBtn();
    this.GM.UpdateUI(EGUIWindow.Door, 1, 5);
  }

  public override void OnClose()
  {
    if (this.tmpString != null)
    {
      StringManager.Instance.DeSpawnString(this.tmpString);
      this.tmpString = (CString) null;
    }
    if (this.tmpString2 != null)
    {
      StringManager.Instance.DeSpawnString(this.tmpString2);
      this.tmpString2 = (CString) null;
    }
    if (this.m_HelpAlertStr != null)
    {
      StringManager.Instance.DeSpawnString(this.m_HelpAlertStr);
      this.m_HelpAlertStr = (CString) null;
    }
    if (this.m_HelpAlertStr2 == null)
      return;
    StringManager.Instance.DeSpawnString(this.m_HelpAlertStr2);
    this.m_HelpAlertStr2 = (CString) null;
  }

  public void CheckHelpAlertState()
  {
    if (DataManager.Instance.mHelpDataList.Count > 0)
    {
      this.m_HelpAlertStr.Length = 0;
      this.m_HelpAlertStr.IntToFormat((long) DataManager.Instance.mHelpDataList.Count);
      this.m_HelpAlertStr.AppendFormat("{0}");
      this.m_HelpAlertext.text = this.m_HelpAlertStr.ToString();
      this.m_HelpAlertext.SetAllDirty();
      this.m_HelpAlertext.cachedTextGenerator.Invalidate();
      this.m_HelpAlertext.cachedTextGeneratorForLayout.Invalidate();
      this.m_HelpAlertRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_HelpAlertext.preferredWidth), 51f);
      ((Component) this.m_HelpAlertRC).gameObject.SetActive(true);
      ((Component) this.m_HelpAlert).gameObject.SetActive(true);
      if (DataManager.Instance.AllianceMoneyBonusRate > (ushort) 100)
      {
        Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
        if ((Object) menu != (Object) null)
        {
          int index = (int) DataManager.Instance.AllianceMoneyBonusRate / 100 - 2;
          if (index >= 0 && index < menu.m_HelpAlertSA.m_Sprites.Length)
            this.m_HelpAlertL.sprite = menu.m_HelpAlertSA.GetSprite(index);
          else
            this.m_HelpAlertL.sprite = menu.m_HelpAlertSA.GetSprite(0);
          ((Component) this.m_HelpAlertL).gameObject.SetActive(true);
          ((Component) this.m_HelpAlertR).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.m_HelpAlertL).gameObject.SetActive(false);
          ((Component) this.m_HelpAlertR).gameObject.SetActive(false);
        }
        this.m_HelpAlertImageGO.SetActive(true);
      }
      else
      {
        this.m_HelpAlertImageGO.SetActive(false);
        ((Component) this.m_HelpAlertL).gameObject.SetActive(false);
        ((Component) this.m_HelpAlertR).gameObject.SetActive(false);
      }
    }
    else
      ((Component) this.m_HelpAlert).gameObject.SetActive(false);
  }

  private void CheckLRBtn()
  {
    StageManager stageDataController = DataManager.StageDataController;
    this.StageName.text = this.DM.mStringTable.GetStringByID((uint) stageDataController.ChapterTable.GetRecordByKey((ushort) stageDataController.currentChapterID).ChapterName);
    this.tmpString.Length = 0;
    this.tmpString.IntToFormat((long) stageDataController.currentChapterID);
    this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(56U));
    this.chapName.text = this.tmpString.ToString();
    this.chapName.SetAllDirty();
    this.chapName.cachedTextGenerator.Invalidate();
    if (stageDataController.currentChapterID <= (byte) 1)
      this.Left_T.gameObject.SetActive(false);
    else
      this.Left_T.gameObject.SetActive(true);
    if ((int) stageDataController.currentChapterID < (int) stageDataController.ChapterID || (int) stageDataController.ChapterID < stageDataController.ChapterTable.TableCount && (int) stageDataController.limitRecord[(int) stageDataController._stageMode] == (int) stageDataController.StageRecord[(int) stageDataController._stageMode])
      this.Right_T.gameObject.SetActive(true);
    else
      this.Right_T.gameObject.SetActive(false);
    bool flag1 = (int) stageDataController.StageRecord[0] >= (int) GameConstants.StagePointNum[0] && stageDataController.StageRecord[2] > (ushort) 1;
    if (flag1)
      this.EliteT.gameObject.SetActive(true);
    else
      this.EliteT.gameObject.SetActive(false);
    bool flag2 = (int) stageDataController.StageRecord[1] >= 4 * (int) GameConstants.StagePointNum[1];
    if (flag2)
      this.AllianceT.gameObject.SetActive(true);
    else
      this.AllianceT.gameObject.SetActive(false);
    if (stageDataController._stageMode == StageMode.Lean)
    {
      this.NFlash.SetActive(false);
      this.EFlash.SetActive(true);
      this.AFlash.SetActive(false);
      this.NormalObj.SetActive(false);
      this.EliteObj.SetActive(true);
      this.AllianceObj1.SetActive(false);
      this.AllianceObj2.SetActive(false);
    }
    else if (stageDataController._stageMode == StageMode.Dare)
    {
      this.NFlash.SetActive(false);
      this.EFlash.SetActive(false);
      this.AFlash.SetActive(true);
      this.NormalObj.SetActive(false);
      this.EliteObj.SetActive(false);
      this.AllianceObj1.SetActive(true);
      this.AllianceObj2.SetActive(true);
    }
    else
    {
      if (flag1 || flag2)
        this.NFlash.SetActive(true);
      this.EFlash.SetActive(false);
      this.AFlash.SetActive(false);
      this.NormalObj.SetActive(true);
      this.EliteObj.SetActive(false);
      this.AllianceObj1.SetActive(false);
      this.AllianceObj2.SetActive(false);
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 1)
    {
      this.CheckHelpAlertState();
    }
    else
    {
      this.CheckLRBtn();
      DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
    }
  }

  private void Update()
  {
    if ((Object) this.Left_T == (Object) null)
      return;
    this.MoveX += Time.smoothDeltaTime * 40f;
    if ((double) this.MoveX >= 40.0)
      this.MoveX = 0.0f;
    float num = (double) this.MoveX <= 20.0 ? this.MoveX : 40f - this.MoveX;
    if ((double) num < 0.0)
      num = 0.0f;
    this.BtnPos.Set(this.LeftPosX - num, this.Left_T.localPosition.y, this.Left_T.localPosition.z);
    this.Left_T.localPosition = this.BtnPos;
    this.BtnPos.Set(this.RightPosX + num, this.Right_T.localPosition.y, this.Right_T.localPosition.z);
    this.Right_T.localPosition = this.BtnPos;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    if ((Object) this.StageName != (Object) null && ((Behaviour) this.StageName).enabled)
    {
      ((Behaviour) this.StageName).enabled = false;
      ((Behaviour) this.StageName).enabled = true;
    }
    if ((Object) this.NormalText != (Object) null && ((Behaviour) this.NormalText).enabled)
    {
      ((Behaviour) this.NormalText).enabled = false;
      ((Behaviour) this.NormalText).enabled = true;
    }
    if ((Object) this.EliteText != (Object) null && ((Behaviour) this.EliteText).enabled)
    {
      ((Behaviour) this.EliteText).enabled = false;
      ((Behaviour) this.EliteText).enabled = true;
    }
    if ((Object) this.AllianceText != (Object) null && ((Behaviour) this.AllianceText).enabled)
    {
      ((Behaviour) this.AllianceText).enabled = false;
      ((Behaviour) this.AllianceText).enabled = true;
    }
    if ((Object) this.chapName != (Object) null && ((Behaviour) this.chapName).enabled)
    {
      ((Behaviour) this.chapName).enabled = false;
      ((Behaviour) this.chapName).enabled = true;
    }
    if ((Object) this.m_HelpAlertext != (Object) null && ((Behaviour) this.m_HelpAlertext).enabled)
    {
      ((Behaviour) this.m_HelpAlertext).enabled = false;
      ((Behaviour) this.m_HelpAlertext).enabled = true;
    }
    if (!((Object) this.m_HelpAlertext2 != (Object) null) || !((Behaviour) this.m_HelpAlertext2).enabled)
      return;
    ((Behaviour) this.m_HelpAlertext2).enabled = false;
    ((Behaviour) this.m_HelpAlertext2).enabled = true;
  }

  public void OnButtonClick(UIButton sender)
  {
    StageManager stageDataController = DataManager.StageDataController;
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        if (stageDataController._stageMode == StageMode.Full)
          return;
        this.NFlash.SetActive(true);
        this.EFlash.SetActive(false);
        this.AFlash.SetActive(false);
        this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeStage);
      }
      else if (sender.m_BtnID2 == 2)
      {
        if (stageDataController._stageMode == StageMode.Lean)
          return;
        this.NFlash.SetActive(false);
        this.EFlash.SetActive(true);
        this.AFlash.SetActive(false);
        this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeStage);
      }
      else
      {
        if (sender.m_BtnID2 != 3 || stageDataController._stageMode == StageMode.Dare)
          return;
        this.NFlash.SetActive(false);
        this.EFlash.SetActive(false);
        this.AFlash.SetActive(true);
        this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeStage);
      }
    }
    else if (sender.m_BtnID1 == 2)
    {
      if (sender.m_BtnID2 == 1)
      {
        this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.PrevStage);
      }
      else
      {
        if (sender.m_BtnID2 != 2)
          return;
        if ((int) stageDataController.currentChapterID >= (int) stageDataController.ChapterID && (int) stageDataController.StageRecord[(int) stageDataController._stageMode] >= (int) stageDataController.limitRecord[(int) stageDataController._stageMode])
        {
          if (stageDataController._stageMode == StageMode.Full && (int) stageDataController.StageRecord[0] >= (int) stageDataController.StageRecord[2] * (int) GameConstants.StagePointNum[0])
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(668U), (ushort) byte.MaxValue);
          else if (stageDataController._stageMode == StageMode.Lean && (int) stageDataController.StageRecord[1] * (int) GameConstants.LinePointNum[0] >= (int) stageDataController.StageRecord[0])
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1593U), (ushort) byte.MaxValue);
          else if (stageDataController._stageMode == StageMode.Dare && (int) stageDataController.StageRecord[3] >= (int) (ushort) ((uint) stageDataController.StageRecord[1] / (uint) GameConstants.StagePointNum[1] * (uint) GameConstants.StagePointNum[3]))
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1035U), (ushort) byte.MaxValue);
          else
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8597U), (ushort) byte.MaxValue);
        }
        else
          this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.NextStage);
      }
    }
    else if (sender.m_BtnID1 == 3)
    {
      NewbieManager.CheckRemovePressXFlag();
      DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
      DataManager.msgBuffer[0] = (byte) 4;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else
    {
      if (sender.m_BtnID1 != 23)
        return;
      Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
      if (!((Object) menu != (Object) null))
        return;
      menu.OpenMenu(EGUIWindow.UI_Alliance_HelpSpeedup);
    }
  }

  public override bool OnBackButtonClick()
  {
    DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
    DataManager.msgBuffer[0] = (byte) 4;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }
}
