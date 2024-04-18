// Decompiled with JetBrains decompiler
// Type: UITreasureBox_FB
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITreasureBox_FB : GUIWindow, IUIButtonClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private UIButton btn_EXIT;
  private UIButton btn_FBInvite;
  private HelperUIButton OutsideExitBtn;
  private UIText text_Title;
  private UIText text_Info;
  private UIText text_Invite;
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.TTFont = this.GUIM.GetTTFFont();
    this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    this.GameT = this.gameObject.transform;
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.GameT.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.GameT.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Tmp = this.GameT.GetChild(0).GetChild(0);
    this.btn_FBInvite = this.Tmp.GetComponent<UIButton>();
    this.btn_FBInvite.m_Handler = (IUIButtonClickHandler) this;
    this.btn_FBInvite.m_BtnID1 = 1;
    this.btn_FBInvite.m_EffectType = e_EffectType.e_Scale;
    this.btn_FBInvite.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(0).GetChild(0).GetChild(0);
    this.text_Invite = this.Tmp.GetComponent<UIText>();
    this.text_Invite.font = this.TTFont;
    this.text_Invite.text = this.DM.mStringTable.GetStringByID(14650U);
    this.Tmp = this.GameT.GetChild(0).GetChild(3);
    this.text_Info = this.Tmp.GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.text_Info.text = this.DM.mStringTable.GetStringByID(14649U);
    this.Tmp = this.GameT.GetChild(1).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(1).GetChild(1);
    this.text_Title = this.Tmp.GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(14648U);
    this.OutsideExitBtn = this.gameObject.AddComponent<HelperUIButton>();
    this.OutsideExitBtn.m_Handler = (IUIButtonClickHandler) this;
    this.OutsideExitBtn.m_BtnID1 = 0;
  }

  public override void OnClose()
  {
    if (!DataManager.FBMissionDataManager.bFB_CDTime)
      return;
    DataManager.FBMissionDataManager.bFB_btnShow = false;
    DataManager.FBMissionDataManager.ReSetFB_CDTime();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((GUITreasureBox_FB_btn) sender.m_BtnID1)
    {
      case GUITreasureBox_FB_btn.btn_EXIT:
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox_FB);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case GUITreasureBox_FB_btn.btn_FBInvite:
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox_FB);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        Door menu = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        DataManager.FBMissionDataManager.m_FBBindEnd = false;
        if (DataManager.FBMissionDataManager.GetRemainTime() == 0U)
          DataManager.FBMissionDataManager.ReSetFB_CDTime();
        menu.OpenMenu(EGUIWindow.UI_MissionFB, bCameraMode: true);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
        this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
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
    if ((Object) this.text_Info != (Object) null && ((Behaviour) this.text_Info).enabled)
    {
      ((Behaviour) this.text_Info).enabled = false;
      ((Behaviour) this.text_Info).enabled = true;
    }
    if (!((Object) this.text_Invite != (Object) null) || !((Behaviour) this.text_Invite).enabled)
      return;
    ((Behaviour) this.text_Invite).enabled = false;
    ((Behaviour) this.text_Invite).enabled = true;
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
