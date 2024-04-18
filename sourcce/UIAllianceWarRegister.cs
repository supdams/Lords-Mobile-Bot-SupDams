// Decompiled with JetBrains decompiler
// Type: UIAllianceWarRegister
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIAllianceWarRegister : 
  GUIWindow,
  IActivityWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private UIAllianceWarRegister._RegisterItem[] RegisterItem;
  private ScrollPanel AllyView;
  private int PagepeItem = 9;
  private List<float> Heights = new List<float>();
  private UIText RegisterText;
  private UIText RankText;
  private UIText MessageText;
  private UIText BackupText;
  private UIText ScrollMsgText;
  private UIText AllyNameText;
  private UIText[] TitleText = new UIText[2];
  private UIText[] ColumnText = new UIText[3];
  private CString AllyNameStr;
  private CString RankStr;
  private CString BackupStr;
  private RectTransform MessageRect;
  private RectTransform BackupItemRect;
  private RectTransform AllyViewContentRect;
  private GameObject RankObj;
  private GameObject EmblemObj;
  private GameObject GiftInCreaseObj;
  private GameObject ArmyHintObj;
  private Transform ElbemTrans;
  private ushort AllianceElbem;
  private UIButton RegisterBtn;
  private UIButton RankBtn;
  public AllianceWarManager AWD = ActivityManager.Instance.AllianceWarMgr;
  private byte RegisterDataCount;
  private byte bColse;
  private int TopIndex = -1;
  public RectTransform tmpRc;
  private uButtonScale RankBtnScale;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    Font ttfFont = instance1.GetTTFFont();
    instance1.UpdateUI(EGUIWindow.Door, 1, 2);
    this.TitleText[0] = this.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.TitleText[1] = this.transform.GetChild(0).GetChild(2).GetComponent<UIText>();
    UIText uiText = this.TitleText[0];
    Font font1 = ttfFont;
    this.TitleText[1].font = font1;
    Font font2 = font1;
    uiText.font = font2;
    this.TitleText[0].text = instance2.mStringTable.GetStringByID(17012U);
    this.TitleText[1].text = instance2.mStringTable.GetStringByID(17005U);
    this.GiftInCreaseObj = this.transform.GetChild(0).GetChild(3).GetChild(0).gameObject;
    RectTransform component = this.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
    component.pivot = new Vector2(0.5f, 0.5f);
    component.anchoredPosition = new Vector2(786.5f, -26f);
    this.RankBtn = this.transform.GetChild(0).GetChild(3).GetComponent<UIButton>();
    this.RankBtn.m_Handler = (IUIButtonClickHandler) this;
    this.RankBtn.m_BtnID1 = 2;
    this.RankBtnScale = ((Component) this.RankBtn).transform.GetComponent<uButtonScale>();
    ((Component) this.RankBtn).gameObject.AddComponent<ArabicItemTextureRot>();
    this.ScrollMsgText = this.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<UIText>();
    this.ScrollMsgText.font = ttfFont;
    this.ScrollMsgText.text = instance2.mStringTable.GetStringByID(17014U);
    for (int index = 0; index < 3; ++index)
    {
      this.transform.GetChild(1).GetChild(3).GetChild(index).GetChild(0).GetComponent<UIText>().font = ttfFont;
      this.ColumnText[index] = this.transform.GetChild(1).GetChild(0).GetChild(index).GetChild(0).GetComponent<UIText>();
      this.ColumnText[index].font = ttfFont;
    }
    this.ColumnText[0].text = instance2.mStringTable.GetStringByID(17013U);
    this.ColumnText[1].text = instance2.mStringTable.GetStringByID(4717U);
    this.ColumnText[2].text = instance2.mStringTable.GetStringByID(1560U);
    this.BackupStr = StringManager.Instance.SpawnString(100);
    this.BackupText = this.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.BackupText.font = ttfFont;
    this.BackupItemRect = this.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
    this.AllyView = this.transform.GetChild(1).GetChild(1).GetComponent<ScrollPanel>();
    this.EmblemObj = this.transform.GetChild(3).GetChild(0).gameObject;
    this.AllyNameStr = StringManager.Instance.SpawnString();
    this.ElbemTrans = this.transform.GetChild(3).GetChild(0).GetChild(0);
    this.AllianceElbem = DataManager.Instance.RoleAlliance.Emblem;
    instance1.InitBadgeTotem(this.ElbemTrans, this.AllianceElbem);
    this.AllyNameText = this.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.AllyNameText.font = ttfFont;
    this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Tag);
    this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Name);
    this.AllyNameStr.AppendFormat("[{0}]{1}");
    this.AllyNameText.text = this.AllyNameStr.ToString();
    this.RankStr = StringManager.Instance.SpawnString();
    this.RankText = this.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.RankText.font = ttfFont;
    this.RankObj = ((Component) this.RankText).gameObject;
    this.MessageText = this.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
    this.MessageText.font = ttfFont;
    this.MessageRect = ((Graphic) this.MessageText).rectTransform;
    this.RegisterText = this.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.RegisterText.font = ttfFont;
    this.RegisterBtn = this.transform.GetChild(3).GetChild(2).GetComponent<UIButton>();
    this.RegisterBtn.m_Handler = (IUIButtonClickHandler) this;
    this.RegisterBtn.m_BtnID1 = 0;
    if (ActivityManager.Instance.AW_PrizeGroupID > (byte) 0)
      this.GiftInCreaseObj.SetActive(true);
    this.ArmyHintObj = this.transform.GetChild(3).GetChild(3).gameObject;
    UIButtonHint uiButtonHint = this.ArmyHintObj.AddComponent<UIButtonHint>();
    uiButtonHint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.Parm1 = (ushort) 17078;
    uiButtonHint.Parm2 = (byte) 3;
    uiButtonHint.ScrollID = (byte) 2;
    this.transform.gameObject.AddComponent<ActivityWindow>().Initial(e_ActivityType.SignUp, (IActivityWindow) this);
    if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
      this.bColse = (byte) 1;
    else if (ActivityManager.Instance.AW_State > EAllianceWarState.EAWS_Prepare)
    {
      if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_Run)
      {
        if (instance2.RoleAlliance.Id > 0U && ActivityManager.Instance.AW_NowAllianceEnterWar > (byte) 0)
          this.bColse = (byte) 2;
      }
      else
        this.bColse = (byte) 2;
    }
    if (this.bColse > (byte) 0)
      return;
    if (DataManager.Instance.RoleAlliance.Id > 0U)
    {
      this.AWD.SendAllianceWarList();
    }
    else
    {
      this.UpdateMessage();
      this.SetNonAllianceState();
    }
  }

  private bool InitialScroll()
  {
    if (this.RegisterItem != null || this.RegisterDataCount == (byte) 0)
      return false;
    ((Component) this.ScrollMsgText).gameObject.SetActive(false);
    this.RegisterItem = new UIAllianceWarRegister._RegisterItem[this.PagepeItem];
    for (byte index = 0; (int) index < (int) this.RegisterDataCount; ++index)
    {
      if ((int) index == (int) this.AWD.GetRegisterMaxCount())
        this.Heights.Add(90f);
      else
        this.Heights.Add(45f);
    }
    this.AllyView.IntiScrollPanel(333f, 0.0f, 0.0f, this.Heights, this.PagepeItem, (IUpDateScrollPanel) this);
    this.AllyViewContentRect = this.AllyView.transform.GetChild(0).GetComponent<RectTransform>();
    UIButtonHint.scrollRect = this.AllyView.transform.GetComponent<CScrollRect>();
    this.AllyView.gameObject.SetActive(true);
    this.UpdateEnrollPower();
    if (this.AWD.MyRank > (byte) 0)
    {
      int num1 = (int) this.AWD.GetRegisterMaxCount();
      if (num1 > (int) this.AWD.GetRegisterCount())
        num1 = (int) this.AWD.GetRegisterCount();
      int num2 = num1 - (int) this.AWD.MyRank;
      if (num2 >= 5)
        this.AllyView.GoTo(num2 - 2);
      else if (num2 < 0 && this.AWD.MyRank > (byte) 3)
        this.AllyView.GoTo((int) this.AWD.MyRank - 3);
      this.CheckWaitItem();
    }
    return true;
  }

  private void UpdateEnrollPower()
  {
    this.BackupStr.ClearString();
    this.BackupStr.IntToFormat((long) this.AWD.GetEnrollPower(), bNumber: true);
    this.BackupStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17015U));
    this.BackupText.text = this.BackupStr.ToString();
    this.BackupText.SetAllDirty();
    this.BackupText.cachedTextGenerator.Invalidate();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bColse <= (byte) 0)
      return;
    if (this.bColse == (byte) 2)
      ActivityManager.Instance.AllianceWarSendReOpenMenu();
    else
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    this.bColse = (byte) 0;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
        {
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
          break;
        }
        ActivityManager.Instance.AllianceWarSendReOpenMenu();
        break;
      case NetworkNews.Refresh:
        if ((int) this.AllianceElbem == (int) DataManager.Instance.RoleAlliance.Emblem)
          break;
        this.AllianceElbem = DataManager.Instance.RoleAlliance.Emblem;
        GUIManager.Instance.SetBadgeTotemImg(this.ElbemTrans, this.AllianceElbem);
        break;
      case NetworkNews.Refresh_Alliance:
        if (DataManager.Instance.RoleAlliance.Id > 0U)
        {
          if (meg[1] == (byte) 3 || meg[1] == (byte) 4)
          {
            this.EmblemObj.SetActive(true);
            this.AllyNameStr.ClearString();
            this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Tag);
            this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Name);
            this.AllyNameStr.AppendFormat("[{0}]{1}");
            this.AllyNameText.text = this.AllyNameStr.ToString();
            this.AllyNameText.SetAllDirty();
            this.AllyNameText.cachedTextGenerator.Invalidate();
            this.UpdateMessage();
            break;
          }
          if (meg[1] != (byte) 7 || (int) this.AllianceElbem == (int) DataManager.Instance.RoleAlliance.Emblem)
            break;
          this.AllianceElbem = DataManager.Instance.RoleAlliance.Emblem;
          GUIManager.Instance.SetBadgeTotemImg(this.ElbemTrans, this.AllianceElbem);
          break;
        }
        this.UpdateMessage();
        this.SetNonAllianceState();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        if (this.RegisterItem != null)
        {
          for (int index = 0; index < this.RegisterItem.Length; ++index)
          {
            if (!((Object) this.RegisterItem[index].transform == (Object) null))
              this.RegisterItem[index].TextureRebuilt();
          }
        }
        for (int index = 0; index < 3; ++index)
        {
          ((Behaviour) this.ColumnText[index]).enabled = false;
          ((Behaviour) this.ColumnText[index]).enabled = true;
        }
        ((Behaviour) this.TitleText[0]).enabled = false;
        ((Behaviour) this.TitleText[0]).enabled = true;
        ((Behaviour) this.TitleText[1]).enabled = false;
        ((Behaviour) this.TitleText[1]).enabled = true;
        ((Behaviour) this.AllyNameText).enabled = false;
        ((Behaviour) this.AllyNameText).enabled = true;
        ((Behaviour) this.RegisterText).enabled = false;
        ((Behaviour) this.RegisterText).enabled = true;
        ((Behaviour) this.RankText).enabled = false;
        ((Behaviour) this.RankText).enabled = true;
        ((Behaviour) this.MessageText).enabled = false;
        ((Behaviour) this.MessageText).enabled = true;
        ((Behaviour) this.BackupText).enabled = false;
        ((Behaviour) this.BackupText).enabled = true;
        ((Behaviour) this.ScrollMsgText).enabled = false;
        ((Behaviour) this.ScrollMsgText).enabled = true;
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    UIAllianceWarRegister.eUpdatteUI eUpdatteUi = (UIAllianceWarRegister.eUpdatteUI) arg1;
    switch (eUpdatteUi)
    {
      case UIAllianceWarRegister.eUpdatteUI.Initial:
        this.RegisterDataCount = (byte) arg2;
        if (!this.InitialScroll())
          this.UpdateAllItem();
        this.UpdateMessage();
        ActivityManager.Instance.UpDateAllianceWarTop();
        return;
      case UIAllianceWarRegister.eUpdatteUI.Data:
        if (DataManager.Instance.RoleAlliance.Id > 0U && (ActivityManager.Instance.AW_State <= EAllianceWarState.EAWS_Prepare || ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_Run && (int) this.AWD.GetRegisterCount() < (int) this.AWD.GetRegisterMaxCount()))
        {
          this.AWD.SendAllianceWarList();
          break;
        }
        break;
    }
    if (this.RegisterItem == null || this.RegisterDataCount == (byte) 0)
      return;
    switch (eUpdatteUi)
    {
      case UIAllianceWarRegister.eUpdatteUI.Item:
        if ((Object) this.AllyView != (Object) null)
        {
          for (int index = 0; index < this.RegisterItem.Length; ++index)
            this.RegisterItem[index].SetData(this.RegisterItem[index].DataIndex);
        }
        this.UpdateEnrollPower();
        this.UpdateRank();
        ActivityManager.Instance.UpDateAllianceWarTop();
        break;
      case UIAllianceWarRegister.eUpdatteUI.Message:
        this.UpdateMessage();
        if (DataManager.Instance.RoleAlliance.Id != 0U)
          break;
        this.SetNonAllianceState();
        break;
      case UIAllianceWarRegister.eUpdatteUI.Hint:
        GUIManager.Instance.m_Arena_Hint.ShowHint((byte) 1, this.tmpRc);
        break;
      case UIAllianceWarRegister.eUpdatteUI.AllianceEnterWar:
        if (ActivityManager.Instance.AW_NowAllianceEnterWar <= (byte) 0)
          break;
        ActivityManager.Instance.AllianceWarSendReOpenMenu();
        break;
    }
  }

  private void SetNonAllianceState()
  {
    if (!this.RankBtn.interactable)
      return;
    this.RankBtn.interactable = false;
    ((Graphic) this.RankBtnScale.transform.GetComponent<Image>()).color = Color.gray;
    this.RankBtnScale.enabled = false;
    this.AllyView.gameObject.SetActive(false);
    this.EmblemObj.SetActive(false);
    ((Component) this.ScrollMsgText).gameObject.SetActive(false);
    ActivityManager.Instance.UpDateAllianceWarTop();
  }

  private void UpdateAllItem()
  {
    if (this.RegisterDataCount == (byte) 0)
      return;
    int topIdx = this.AllyView.GetTopIdx();
    float y = this.AllyViewContentRect.anchoredPosition.y;
    this.Heights.Clear();
    for (byte index = 0; (int) index < (int) this.RegisterDataCount; ++index)
    {
      if ((int) index == (int) this.AWD.GetRegisterMaxCount())
        this.Heights.Add(90f);
      else
        this.Heights.Add(45f);
    }
    this.AllyView.AddNewDataHeight(this.Heights);
    this.AllyView.GoTo(topIdx, y);
    this.UpdateEnrollPower();
    this.CheckWaitItem();
  }

  public override void OnClose()
  {
    if (this.RegisterItem != null)
    {
      for (int index = 0; index < this.RegisterItem.Length; ++index)
      {
        if (!((Object) this.RegisterItem[index].transform == (Object) null))
          this.RegisterItem[index].OnClose();
      }
    }
    StringManager.Instance.DeSpawnString(this.AllyNameStr);
    StringManager.Instance.DeSpawnString(this.RankStr);
    StringManager.Instance.DeSpawnString(this.BackupStr);
  }

  private void UpdateMessage()
  {
    bool flag = false;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MessageRect.sizeDelta = new Vector2(this.MessageRect.sizeDelta.x, 97f);
    this.RegisterBtn.m_BtnID1 = 0;
    this.RegisterText.text = mStringTable.GetStringByID(17005U);
    this.MessageText.text = string.Empty;
    ((Graphic) this.MessageText).color = Color.white;
    if (DataManager.Instance.RoleAlliance.Id == 0U)
    {
      ((Graphic) this.MessageText).color = new Color(1f, 0.2667f, 0.349f);
      this.MessageText.text = mStringTable.GetStringByID(17020U);
    }
    else if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_SignUp)
    {
      if (ActivityManager.Instance.AW_SignUpAllianceID > 0U)
      {
        if (this.AWD.MyRank == (byte) 0)
        {
          ((Graphic) this.MessageText).color = new Color(1f, 0.2667f, 0.349f);
          this.MessageText.text = mStringTable.GetStringByID(17010U);
        }
      }
      else
        flag = true;
    }
    else if ((int) this.AWD.GetRegisterCount() < (int) this.AWD.GetRegisterMaxCount())
    {
      ((Graphic) this.MessageText).color = new Color(1f, 0.2667f, 0.349f);
      this.MessageText.text = mStringTable.GetStringByID(17019U);
    }
    else
    {
      ((Graphic) this.MessageText).color = new Color(0.298f, 0.961f, 0.961f);
      this.MessageText.text = mStringTable.GetStringByID(17031U);
    }
    if (this.AWD.MyRank > (byte) 0 && DataManager.Instance.RoleAlliance.Id > 0U)
    {
      if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_SignUp)
        flag = true;
      this.MessageRect.sizeDelta = new Vector2(this.MessageRect.sizeDelta.x, 67f);
      this.RegisterText.text = mStringTable.GetStringByID(17009U);
    }
    this.UpdateRank();
    ((Component) this.RegisterBtn).gameObject.SetActive(flag);
    this.ArmyHintObj.SetActive(flag);
    if (this.RegisterDataCount != (byte) 0 || DataManager.Instance.RoleAlliance.Id <= 0U)
      return;
    ((Component) this.ScrollMsgText).gameObject.SetActive(true);
  }

  private void UpdateRank()
  {
    if (this.AWD.MyRank == (byte) 0 || DataManager.Instance.RoleAlliance.Id == 0U)
    {
      this.RankText.text = string.Empty;
    }
    else
    {
      this.RankStr.ClearString();
      if ((int) this.AWD.MyRank > (int) this.AWD.GetRegisterMaxCount())
      {
        this.RankStr.IntToFormat((long) ((int) this.AWD.MyRank - (int) this.AWD.GetRegisterMaxCount()));
        this.RankStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17008U));
      }
      else
      {
        if ((int) this.AWD.GetRegisterMaxCount() < (int) this.AWD.GetRegisterCount())
          this.RankStr.IntToFormat((long) ((int) this.AWD.GetRegisterMaxCount() - (int) this.AWD.MyRank + 1));
        else
          this.RankStr.IntToFormat((long) ((int) this.AWD.GetRegisterCount() - (int) this.AWD.MyRank + 1));
        this.RankStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17007U));
      }
      this.RankText.text = this.RankStr.ToString();
      this.RankText.SetAllDirty();
      this.RankText.cachedTextGenerator.Invalidate();
    }
  }

  public virtual void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 3)
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    else if (sender.m_BtnID1 == 0)
    {
      if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 9)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17037U), (ushort) byte.MaxValue);
      else if (this.AWD.MyRank == (byte) 0 && this.AWD.GetRegisterCount() == (byte) 100)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17011U), (ushort) byte.MaxValue);
      else
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Expedition, arg2: 10);
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.RegisterItem[panelObjectIdx].transform == (Object) null)
      this.RegisterItem[panelObjectIdx] = new UIAllianceWarRegister._RegisterItem(item.transform, this.AWD, (IUIButtonDownUpHandler) this);
    if (this.AllyView.GetBeginIdx() != this.TopIndex)
    {
      this.TopIndex = this.AllyView.GetBeginIdx();
      this.CheckWaitItem();
    }
    if (dataIdx == (int) this.AWD.GetRegisterMaxCount())
      this.RegisterItem[panelObjectIdx].SetTitle(this.BackupItemRect);
    this.RegisterItem[panelObjectIdx].SetData(dataIdx);
  }

  private void CheckWaitItem()
  {
    if (this.TopIndex <= (int) this.AWD.GetRegisterMaxCount() && this.TopIndex + this.PagepeItem - 1 >= (int) this.AWD.GetRegisterMaxCount())
      return;
    ((Component) this.BackupItemRect).gameObject.SetActive(false);
  }

  public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm2 == (byte) 3)
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 326.5f, 20, (int) sender.Parm1, 0, new Vector2(0.0f, 0.0f));
    else
      ActivityManager.Instance.AllianceWarMgr.Send_MSG_REQUEST_ALLIANCEWAR_MEMBER_DATA((byte) sender.Parm1);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Hide(true);
    if (GUIManager.Instance.m_Arena_Hint == null)
      return;
    GUIManager.Instance.m_Arena_Hint.Hide();
  }

  public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
  {
    this.UpdateMessage();
  }

  private enum UIControl
  {
    TopPanel,
    AllyPanel,
    Image,
    RegisterPanel,
  }

  private enum TopPanelControl
  {
    BGFrame,
    Title1,
    Title2,
    RankBtn,
  }

  private enum AllyPanelConrol
  {
    Title,
    Scroll,
    BackupItem,
    Item,
  }

  private enum RegisterPanelControl
  {
    Emblem,
    Message,
    Register,
    ArmyHint,
  }

  private enum ClickType
  {
    Register,
    Modify,
    Rank,
    Close,
  }

  private struct _RegisterItem
  {
    public Transform transform;
    private RectTransform TitleRect;
    private RectTransform UnderLineRect;
    private RectTransform HintRangeRect;
    private Image UnderLineImg;
    private UISpritesArray[] BGFrame;
    public int DataIndex;
    private UIText RankText;
    private UIText NameText;
    private UIText PowerText;
    private CString RankStr;
    private CString NameStr;
    private CString PowerStr;
    private AllianceWarManager AWD;
    private int DefNameFontSize;
    private Color OriTextColor;
    private UIButtonHint Hint;

    public _RegisterItem(
      Transform transform,
      AllianceWarManager AWD,
      IUIButtonDownUpHandler handle)
    {
      this.AWD = AWD;
      this.transform = transform;
      this.DataIndex = 0;
      this.UnderLineRect = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
      this.UnderLineImg = ((Component) this.UnderLineRect).GetComponent<Image>();
      this.HintRangeRect = transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
      this.Hint = ((Component) this.HintRangeRect).gameObject.AddComponent<UIButtonHint>();
      this.Hint.m_DownUpHandler = handle;
      this.Hint.m_eHint = EUIButtonHint.CountDown;
      this.Hint.DelayTime = 0.2f;
      this.Hint.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
      this.RankText = transform.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.NameText = transform.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.PowerText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.RankStr = StringManager.Instance.SpawnString();
      this.NameStr = StringManager.Instance.SpawnString();
      this.PowerStr = StringManager.Instance.SpawnString();
      this.TitleRect = (RectTransform) null;
      this.DefNameFontSize = this.NameText.fontSize;
      this.OriTextColor = ((Graphic) this.NameText).color;
      this.BGFrame = new UISpritesArray[3];
      for (int index = 0; index < this.BGFrame.Length; ++index)
        this.BGFrame[index] = transform.GetChild(index).GetComponent<UISpritesArray>();
    }

    public void OnClose()
    {
      StringManager.Instance.DeSpawnString(this.RankStr);
      StringManager.Instance.DeSpawnString(this.NameStr);
      StringManager.Instance.DeSpawnString(this.PowerStr);
    }

    public void TextureRebuilt()
    {
      ((Behaviour) this.RankText).enabled = false;
      ((Behaviour) this.RankText).enabled = true;
      ((Behaviour) this.NameText).enabled = false;
      ((Behaviour) this.NameText).enabled = true;
      ((Behaviour) this.PowerText).enabled = false;
      ((Behaviour) this.PowerText).enabled = true;
    }

    public void SetData(int DataIndex)
    {
      if ((Object) this.transform == (Object) null)
        return;
      this.DataIndex = DataIndex;
      AllianceWarManager._RegisterData dataIndex = this.AWD.GetDataIndex(DataIndex);
      this.AWD.FormatRank(DataIndex, ref this.RankStr);
      this.RankText.text = this.RankStr.ToString();
      this.RankText.SetAllDirty();
      this.RankText.cachedTextGenerator.Invalidate();
      this.NameStr.ClearString();
      this.NameStr.Append(dataIndex.Name);
      this.NameText.fontSize = this.DefNameFontSize;
      this.NameText.text = this.NameStr.ToString();
      this.NameText.SetAllDirty();
      this.NameText.cachedTextGenerator.Invalidate();
      this.NameText.cachedTextGeneratorForLayout.Invalidate();
      this.PowerStr.ClearString();
      this.PowerStr.IntToFormat((long) dataIndex.Power, bNumber: true);
      this.PowerStr.AppendFormat("{0}");
      this.PowerText.text = this.PowerStr.ToString();
      this.PowerText.SetAllDirty();
      this.PowerText.cachedTextGenerator.Invalidate();
      float x;
      for (x = this.NameText.preferredWidth; (double) x > 209.0; x = this.NameText.preferredWidth)
      {
        --this.NameText.fontSize;
        if (this.NameText.fontSize < 8)
        {
          x = 209f;
          break;
        }
        ((Graphic) this.NameText).SetLayoutDirty();
        this.NameText.cachedTextGeneratorForLayout.Invalidate();
      }
      this.UnderLineRect.sizeDelta = new Vector2(x, 3f);
      this.HintRangeRect.sizeDelta = new Vector2(x, 45f);
      if (GUIManager.Instance.IsArabic)
        this.UnderLineRect.anchoredPosition = new Vector2(((Graphic) this.NameText).rectTransform.rect.width - x, this.UnderLineRect.anchoredPosition.y);
      int num = (int) this.AWD.GetRegisterMaxCount();
      if (num > (int) this.AWD.GetRegisterCount())
        num = (int) this.AWD.GetRegisterCount();
      if ((int) this.AWD.GetRegisterMaxCount() > DataIndex)
      {
        UIText rankText = this.RankText;
        Color oriTextColor = this.OriTextColor;
        ((Graphic) this.PowerText).color = oriTextColor;
        Color color1 = oriTextColor;
        ((Graphic) this.NameText).color = color1;
        Color color2 = color1;
        ((Graphic) rankText).color = color2;
        ((Graphic) this.UnderLineImg).color = Color.white;
        this.Hint.Parm1 = (ushort) (num - DataIndex);
      }
      else
      {
        UIText rankText = this.RankText;
        Color color3 = new Color(0.443f, 0.816f, 0.953f);
        ((Graphic) this.UnderLineImg).color = color3;
        Color color4 = color3;
        ((Graphic) this.PowerText).color = color4;
        Color color5 = color4;
        ((Graphic) this.NameText).color = color5;
        Color color6 = color5;
        ((Graphic) rankText).color = color6;
        this.Hint.Parm1 = (ushort) (DataIndex + 1);
      }
      int index1 = 0;
      if ((DataIndex & 1) > 0)
        index1 = 1;
      if (this.AWD.MyRank > (byte) 0)
      {
        if (num > (int) this.AWD.MyRank - 1)
        {
          if (num - DataIndex == (int) this.AWD.MyRank)
            index1 = 2;
        }
        else if (this.AWD.MyRank > (byte) 0 && DataIndex == (int) this.AWD.MyRank - 1)
          index1 = 2;
      }
      for (int index2 = 0; index2 < this.BGFrame.Length; ++index2)
        this.BGFrame[index2].SetSpriteIndex(index1);
    }

    public void SetTitle(RectTransform rect)
    {
      this.TitleRect = rect;
      ((Transform) this.TitleRect).SetParent(this.transform.parent, false);
      RectTransform transform = this.transform as RectTransform;
      this.TitleRect.anchoredPosition = new Vector2(transform.anchoredPosition.x, transform.anchoredPosition.y);
      transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, transform.anchoredPosition.y - 45f);
      ((Component) this.TitleRect).gameObject.SetActive(true);
    }
  }

  public enum eUpdatteUI
  {
    Initial = 1,
    Item = 2,
    Message = 3,
    Hint = 4,
    Data = 5,
    AllianceEnterWar = 6,
  }
}
