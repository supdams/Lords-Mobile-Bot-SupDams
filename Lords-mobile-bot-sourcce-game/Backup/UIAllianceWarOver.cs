// Decompiled with JetBrains decompiler
// Type: UIAllianceWarOver
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAllianceWarOver : GUIWindow, IActivityWindow, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private ActivityManager ActM;
  private Transform GameT;
  private Transform Tmp1;
  private Transform BadgeT;
  private Door door;
  private Font TTFont;
  private UIButton btn_Rewards;
  private UIText text_Title;
  private UIText text_Rank;
  private UIText text_AllianceTag;
  private UIText text_Over;
  private UIText text_Schedule;
  private CString Cstr_Rank;
  private CString Cstr_AllianceTag;
  private byte bClose;
  private GameObject GiftInCreaseObj;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.Cstr_Rank = StringManager.Instance.SpawnString(200);
    this.Cstr_AllianceTag = StringManager.Instance.SpawnString();
    this.Tmp1 = this.GameT.GetChild(0).GetChild(0);
    this.btn_Rewards = this.Tmp1.GetChild(0).GetComponent<UIButton>();
    this.btn_Rewards.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Rewards.m_BtnID1 = 0;
    this.btn_Rewards.m_EffectType = e_EffectType.e_Scale;
    this.btn_Rewards.transition = (Selectable.Transition) 0;
    if (this.GUIM.IsArabic)
      ((Component) this.btn_Rewards).gameObject.AddComponent<ArabicItemTextureRot>();
    this.GiftInCreaseObj = this.Tmp1.GetChild(0).GetChild(0).gameObject;
    if (ActivityManager.Instance.AW_PrizeGroupID > (byte) 0)
      this.GiftInCreaseObj.SetActive(true);
    this.text_Title = this.Tmp1.GetChild(1).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(14631U);
    this.BadgeT = this.GameT.GetChild(0).GetChild(2);
    this.Tmp1 = this.GameT.GetChild(0);
    this.text_Rank = this.Tmp1.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_Rank.font = this.TTFont;
    this.Cstr_Rank.ClearString();
    this.Cstr_Rank.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (14635U + (uint) ActivityManager.Instance.AllianceWarMgr.MyFinalGame)));
    this.text_Rank.text = this.Cstr_Rank.ToString();
    this.text_Rank.SetAllDirty();
    this.text_Rank.cachedTextGenerator.Invalidate();
    this.text_AllianceTag = this.Tmp1.GetChild(4).GetComponent<UIText>();
    this.text_AllianceTag.font = this.TTFont;
    this.Cstr_AllianceTag.ClearString();
    this.GUIM.FormatRoleNameForChat(this.Cstr_AllianceTag, (CString) null, this.DM.RoleAlliance.Tag, (ushort) 0);
    this.text_AllianceTag.text = this.Cstr_AllianceTag.ToString();
    this.text_AllianceTag.SetAllDirty();
    this.text_AllianceTag.cachedTextGenerator.Invalidate();
    this.text_Over = this.Tmp1.GetChild(5).GetComponent<UIText>();
    this.text_Over.font = this.TTFont;
    this.text_Over.text = this.DM.mStringTable.GetStringByID(14633U);
    this.text_Schedule = this.Tmp1.GetChild(6).GetComponent<UIText>();
    this.text_Schedule.font = this.TTFont;
    this.text_Schedule.text = this.DM.mStringTable.GetStringByID(14625U);
    this.GUIM.InitBadgeTotem(this.BadgeT, this.DM.RoleAlliance.Emblem);
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    this.GameT.gameObject.AddComponent<ActivityWindow>().Initial(e_ActivityType.RunFail, (IActivityWindow) this);
    if (this.DM.RoleAlliance.Id == 0U || ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
    {
      this.bClose = (byte) 1;
    }
    else
    {
      if (ActivityManager.Instance.AW_State < EAllianceWarState.EAWS_Replay)
        return;
      this.bClose = (byte) 2;
    }
  }

  public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
  {
  }

  public override void OnClose()
  {
    if (this.Cstr_Rank != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Rank);
    if (this.Cstr_AllianceTag == null)
      return;
    StringManager.Instance.DeSpawnString(this.Cstr_AllianceTag);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 0)
      return;
    ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bClose <= (byte) 0)
      return;
    if (this.bClose == (byte) 2)
      ActivityManager.Instance.AllianceWarSendReOpenMenu();
    else
      this.door.CloseMenu();
    this.bClose = (byte) 0;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UI_AllianceWarOver);
          break;
        }
        if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_None)
          break;
        this.door.CloseMenu();
        break;
      case NetworkNews.Refresh_Alliance:
        if (this.DM.RoleAlliance.Id != 0U)
          break;
        this.door.CloseMenu_Alliance(EGUIWindow.UI_AllianceWarOver);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
      case NetworkNews.Refresh_RecvAllianceInfo:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UI_AllianceWarOver);
          break;
        }
        if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
        {
          this.door.CloseMenu();
          break;
        }
        ActivityManager.Instance.AllianceWarSendReOpenMenu();
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
    if ((Object) this.text_Rank != (Object) null && ((Behaviour) this.text_Rank).enabled)
    {
      ((Behaviour) this.text_Rank).enabled = false;
      ((Behaviour) this.text_Rank).enabled = true;
    }
    if ((Object) this.text_AllianceTag != (Object) null && ((Behaviour) this.text_AllianceTag).enabled)
    {
      ((Behaviour) this.text_AllianceTag).enabled = false;
      ((Behaviour) this.text_AllianceTag).enabled = true;
    }
    if ((Object) this.text_Over != (Object) null && ((Behaviour) this.text_Over).enabled)
    {
      ((Behaviour) this.text_Over).enabled = false;
      ((Behaviour) this.text_Over).enabled = true;
    }
    if (!((Object) this.text_Schedule != (Object) null) || !((Behaviour) this.text_Schedule).enabled)
      return;
    ((Behaviour) this.text_Schedule).enabled = false;
    ((Behaviour) this.text_Schedule).enabled = true;
  }
}
