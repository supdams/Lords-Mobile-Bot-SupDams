// Decompiled with JetBrains decompiler
// Type: UIFBWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIFBWindow : 
  GUIWindow,
  IAERunnerEndHandler,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private Transform Tmp;
  private Transform GifeT;
  private Transform FB_T;
  private Transform NPC_T;
  private Transform MissionMap_T;
  private Transform MissionLine_T;
  private Transform Light1_T;
  private Transform Light2_T;
  private RectTransform btn_FB_TagRT;
  private RectTransform ContentRT;
  private FBMissionManager.FBAward Award;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private UIButton btn_EXIT;
  private UIButton btn_I;
  private UIButton btn_FB_Tag;
  private UIButton btnMissionGift;
  private UIButton btnMissionReceive1;
  private UIButton btnMissionReceive2;
  private UIButton btnMissionGiftFinal;
  private UIButton btnFB;
  private UIButton btnReceive;
  private UIButton btnMissionMapinal;
  private UIButton btnInviteGift;
  public UIButton btnInvite;
  private UIButton btnBondGift;
  private Image Img_Head;
  private Image Img_PigHead;
  private Image Img_Headload;
  private Image Img_Headloading;
  private Image Img_Recommend;
  private Image ImgDialogbox1;
  private Image ImgDialogbox2;
  private Image[] ImgDialogbox2_Degree = new Image[2];
  private Image ImgDialogboxEnd;
  private Image ImgFB_Tag_Line;
  private Image ImgMissionGift_Info;
  private Image ImgMissionGiftFinal_Info;
  private Image ImgFBGiftReceive;
  private Image Img_TimeCD;
  private Image Img_TimeOut;
  private Image Img_Castle;
  private Image Img_MissionFinalHeadBG;
  private Image Img_MissionFinalHead;
  private Image Img_MissionFinalTimeCD;
  private Image Img_MissionFinalHeadLoad;
  private Image[] Img_MissionInfo = new Image[10];
  private Image Img_GiftNum;
  private UIText text_Title;
  private UIText[] text_HelpText = new UIText[3];
  private UIText text_HelpTitle;
  private UIText text_Recommend;
  private UIText text_Dialogbox1;
  private UIText[] text_Dialogbox2_Mission = new UIText[4];
  private UIText[] text_Dialogbox2_Degree = new UIText[2];
  private UIText[] text_DialogboxEnd = new UIText[2];
  private UIText text_FB_Name;
  private UIText text_FB_Tag;
  private UIText text_Npc_Name;
  private UIText text_Npc_Tag;
  private UIText text_btnMissionReceive1;
  private UIText text_btnMissionReceive2;
  private UIText text_FB_Gift;
  private UIText text_FB_btnReceive;
  private UIText text_FB_Receive;
  private UIText[] text_Time = new UIText[2];
  private UIText text_TimeOut;
  private UIText text_Invite;
  private UIText[] text_TopInfo = new UIText[2];
  private UIText text_Full;
  private UIText text_MF_TimeCD;
  private UIText text_GiftNum;
  private CString ProFileStr;
  private CString TimeStr;
  private CString NameStr;
  private CString HintStr;
  private CString HelpStr;
  private CString HourStr;
  private CString Goal1Str;
  private CString Goal2Str;
  private CString Node1Str;
  private CString Node2Str;
  private CString FinishStr;
  private UIHIBtn PiggyHead;
  private UIFBHint FBUIHint;
  private UIButtonHint Hint;
  private GameObject Particle;
  private Material m_Mat;
  private Material FrameMaterial;
  private Material IconMaterial;
  private UISpritesArray SArray;
  private ushort Reward;
  private ushort Price;
  private float fPrize;
  private float fFirst;
  private float fTime;
  private float fHide;
  private float fFinal;
  private float fFinish;
  private bool bFinish;
  private bool bMission;
  private bool bRefresh;
  private bool bUpdates;
  private bool bOpenEnd;
  private bool bTimeEnd;
  private bool bGiftEnd;
  private bool bCloseExit;
  private FBMissionManager.FBMissionState[] State = new FBMissionManager.FBMissionState[2];
  private Color mMissionGray = new Color(0.447f, 0.3098f, 0.251f);
  private Color mMissionGreen = new Color(0.0f, 0.6f, 0.267f);
  private Color mDialogSelf = new Color(0.87f, 0.89f, 0.9f);
  private Color mDialogFriend = new Color(0.663f, 0.831f, 0.953f);
  private Vector3 mFriendHead;
  private MissionHeadUnit[] mMissionHead = new MissionHeadUnit[11];
  private MissionHeadUnit[] mFriendsHead = new MissionHeadUnit[11];
  private GameObject[] mPosition = new GameObject[11];
  private GameObject[] mFriends = new GameObject[11];
  private EmojiUnit[] Emoji = new EmojiUnit[13];
  private CString[] Remaining = new CString[10];

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    if ((Object) this.Particle != (Object) null)
    {
      if (this.Particle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
        this.Particle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.Particle = (GameObject) null;
    }
    if ((DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > (byte) 11 || !DataManager.FBMissionDataManager.IsInTime()) && (DataManager.FBMissionDataManager.GetRewardCount() == (ushort) 0 || (int) DataManager.FBMissionDataManager.GetRewardSerial() != (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) && !this.DM.CheckPrizeFlag((byte) 29) && this.DM.CheckPrizeFlag((byte) 27))
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_SET_MISSION_FINISH;
      messagePacket.AddSeqId();
      messagePacket.Send();
      DataManager.Instance.RoleAttr.PrizeFlag |= 536870912U;
      DataManager.FBMissionDataManager.ReSetFB_CDTime();
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
    }
    for (int index = 0; index < this.Emoji.Length; ++index)
    {
      if (this.Emoji[index] != null)
        this.GUIM.pushEmojiIcon(this.Emoji[index]);
    }
    for (int index = 0; index < this.Remaining.Length; ++index)
      StringManager.Instance.DeSpawnString(this.Remaining[index]);
    StringManager.Instance.DeSpawnString(this.NameStr);
    StringManager.Instance.DeSpawnString(this.TimeStr);
    StringManager.Instance.DeSpawnString(this.HintStr);
    StringManager.Instance.DeSpawnString(this.HelpStr);
    StringManager.Instance.DeSpawnString(this.HourStr);
    StringManager.Instance.DeSpawnString(this.Goal1Str);
    StringManager.Instance.DeSpawnString(this.Goal2Str);
    StringManager.Instance.DeSpawnString(this.Node1Str);
    StringManager.Instance.DeSpawnString(this.Node2Str);
    StringManager.Instance.DeSpawnString(this.FinishStr);
    if (this.FBUIHint == null)
      return;
    this.FBUIHint.Destroy();
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void OnAERunnerEnd(int ID1, int ID2)
  {
    if (ID2 <= 0 || ID1 != 0)
      return;
    if ((Object) this.Particle != (Object) null && this.Particle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      this.Particle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
    if (ID2 > 10)
    {
      this.Particle = ParticleManager.Instance.Spawn((ushort) 447, this.MissionMap_T.GetChild(7).gameObject.transform, Vector3.zero, 1f, true);
    }
    else
    {
      this.Particle = ParticleManager.Instance.Spawn((ushort) 447, this.MissionLine_T.GetChild(41 + ID2 - 1).gameObject.transform, Vector3.zero, 1f, true);
      ((Component) this.Img_MissionInfo[ID2 - 1]).transform.GetChild(1).gameObject.SetActive(true);
      this.mPosition[ID2 - 1].transform.GetChild(0).GetComponent<Image>().sprite = this.SArray.GetSprite(((Component) this.mMissionHead[ID2 - 1].BG).gameObject.activeSelf && this.mMissionHead[ID2 - 1].Runner[1] == null || DataManager.FBMissionDataManager.GetFriendCountByProgress((byte) ID2) > (byte) 1 ? 1 : 0);
    }
    this.mMissionHead[ID2 - 1].Runner[0] = (AERunner) null;
    this.Particle.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.Particle.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    GUIManager.Instance.SetLayer(this.Particle, 5);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (((Component) this.text_HelpTitle).gameObject.activeInHierarchy)
        {
          ((Component) this.text_HelpTitle).transform.parent.parent.gameObject.SetActive(false);
          ((Component) this.text_Title).transform.parent.parent.gameObject.SetActive(true);
          this.UpdateTime(this.bOpenEnd);
          break;
        }
        if (!((Object) this.door != (Object) null))
          break;
        DataManager.FBMissionDataManager.m_FBBindEnd = false;
        this.door.CloseMenu();
        break;
      case 1:
        if (!((Component) this.text_Title).gameObject.activeInHierarchy)
          break;
        ((Component) this.text_HelpTitle).transform.parent.parent.gameObject.SetActive(true);
        ((Component) this.text_Title).transform.parent.parent.gameObject.SetActive(false);
        break;
      case 2:
        if (this.ProFileStr == null)
          break;
        this.DM.ShowLordProfile(this.ProFileStr.ToString());
        break;
      case 3:
      case 4:
        if (!((Object) this.door != (Object) null))
          break;
        if (this.Price > (ushort) 0)
        {
          this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) this.Price);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward).FriendPrice);
        break;
      case 5:
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(12163U), (ushort) byte.MaxValue);
        break;
      case 6:
        DataManager.FBMissionDataManager.SendFBGetReward();
        break;
      case 7:
        GUIManager.Instance.OpenMenu(EGUIWindow.UI_Other_Account, bSecWindow: true);
        break;
      case 8:
        DataManager.FBMissionDataManager.SendFBGetReward();
        break;
      case 9:
        FBMissionTbl recordByKey1 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey((ushort) 11);
        if (!((Object) this.door != (Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) recordByKey1.OwnPrice);
        break;
      case 10:
        if (DataManager.Instance.RoleAttr.Invitation == (byte) 0)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(1594U), (ushort) byte.MaxValue);
          break;
        }
        string empty = string.Empty;
        uint ID1 = 12202;
        uint ID2 = 12201;
        string str1 = "http://lordsmobile.igg.com/project/share/?i=" + IGGGameSDK.Instance.Encode(IGGGameSDK.Instance.m_IGGID) + "&language=" + (object) (byte) DataManager.Instance.UserLanguage;
        string str2 = IGGGameSDK.Instance.m_PlatformLoginName != string.Empty || IGGGameSDK.Instance.m_PlatformLoginName != string.Empty ? str1 + "&n=" + IGGGameSDK.Instance.Encode(IGGGameSDK.Instance.m_PlatformLoginName) : str1 + "&n= ";
        IGGSDKPlugin.IntentIM(DataManager.Instance.mStringTable.GetStringByID(ID1), DataManager.Instance.mStringTable.GetStringByID(ID2) + "\n" + str2);
        Debug.Log((object) ("IntentIM = " + str2));
        break;
      case 11:
        FBMissionTbl recordByKey2 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey((ushort) byte.MaxValue);
        if (!((Object) this.door != (Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) recordByKey2.OwnPrice);
        break;
      case 12:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UI_OpenBox, 4, (int) byte.MaxValue);
        break;
    }
  }

  public override bool OnBackButtonClick()
  {
    if ((Object) this.text_HelpTitle != (Object) null && ((Component) this.text_HelpTitle).gameObject.activeInHierarchy)
    {
      ((Component) this.text_HelpTitle).transform.parent.parent.gameObject.SetActive(false);
      ((Component) this.text_Title).transform.parent.parent.gameObject.SetActive(true);
      this.UpdateTime(this.bOpenEnd);
      return true;
    }
    DataManager.FBMissionDataManager.m_FBBindEnd = false;
    return false;
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm2 > (byte) 0)
      this.FBUIHint.ShowFriend(sender.Parm1, sender.transform);
    else
      this.FBUIHint.Show(sender.Parm1, sender.transform);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (this.FBUIHint == null)
      return;
    this.FBUIHint.Hide(sender.transform);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        ((Component) this.btnInviteGift).gameObject.SetActive(((Component) this.btnInvite).gameObject.activeSelf);
        ((Component) this.Img_Castle).gameObject.SetActive(!((Component) this.btnInvite).gameObject.activeSelf);
        if ((DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && DataManager.FBMissionDataManager.GetRewardIndex() == (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || DataManager.Instance.RoleAttr.Inviter.Invited > (byte) 0 && !DataManager.Instance.CheckPrizeFlag((byte) 30) || DataManager.FBMissionDataManager.m_FBBindEnd || !this.MissionLine_T.parent.gameObject.activeSelf) && this.bOpenEnd)
        {
          this.GifeT.gameObject.SetActive(true);
          ((Component) this.ImgDialogbox1).gameObject.SetActive(true);
          this.MissionLine_T.parent.gameObject.SetActive(false);
          ((Component) this.btnFB).gameObject.SetActive(SocialManager.Instance.CheckBonding());
          ((Component) this.btnReceive).gameObject.SetActive((DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && DataManager.FBMissionDataManager.GetRewardIndex() == (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || !this.DM.CheckPrizeFlag((byte) 30)) && !SocialManager.Instance.CheckBonding());
          DataManager.FBMissionDataManager.m_FBBindEnd = !((Component) this.btnReceive).gameObject.activeSelf && !((Component) this.btnFB).gameObject.activeSelf;
          ((Component) this.ImgFBGiftReceive).gameObject.SetActive(DataManager.FBMissionDataManager.m_FBBindEnd);
          ((Component) this.Img_Head).transform.parent.gameObject.SetActive(true);
          if (this.DM.RoleAttr.Inviter.Invited > (byte) 0 && this.DM.RoleAttr.Inviter.Result == (byte) 0)
          {
            if (this.DM.RoleAttr.Inviter.Name.Length > 0)
            {
              GUIManager.Instance.ChangeHeroItemImg(((Component) this.PiggyHead).transform, eHeroOrItem.Hero, this.DM.RoleAttr.Inviter.Head, (byte) 0, (byte) 0);
              ((Component) this.Img_Recommend).gameObject.SetActive(true);
              ((Component) this.Img_Head).gameObject.SetActive(true);
              this.UpdateFriendName();
            }
            else
              DataManager.FBMissionDataManager.SendFriend_SocialInfo((byte) 0);
          }
          else
          {
            this.Img_PigHead.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite((ushort) 1000);
            ((Component) this.Img_Recommend).gameObject.SetActive(false);
            ((Component) this.Img_Head).gameObject.SetActive(true);
            this.UpdateNPCName();
          }
          this.text_Dialogbox1.text = this.DM.mStringTable.GetStringByID(!((Behaviour) this.btnFB).isActiveAndEnabled ? (!((Behaviour) this.btnReceive).isActiveAndEnabled ? 12152U : 12150U) : 12148U);
          ((Graphic) this.text_Dialogbox1).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Dialogbox1).rectTransform.sizeDelta.x, this.text_Dialogbox1.preferredHeight);
          break;
        }
        if (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex < (byte) 1 || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > (byte) 12 || !this.bOpenEnd)
          break;
        if (DataManager.FBMissionDataManager.GetRewardCount() == (ushort) 0 && (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > (byte) 11 || DataManager.FBMissionDataManager.GetRemainTime() == 0U))
        {
          FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = (ushort) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex);
          this.FinishStr.ClearString();
          this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
          this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID(!SocialManager.Instance.CanShowInvite() ? (DataManager.Instance.RoleAttr.Inviter.Invited <= (byte) 0 ? 12186U : 12172U) : 12173U));
          this.text_Dialogbox1.text = this.FinishStr.ToString();
          this.text_Dialogbox1.SetAllDirty();
          this.text_Dialogbox1.cachedTextGenerator.Invalidate();
          this.text_Dialogbox1.cachedTextGeneratorForLayout.Invalidate();
          ((Graphic) this.text_Dialogbox1).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Dialogbox1).rectTransform.sizeDelta.x, this.text_Dialogbox1.preferredHeight);
          GUIManager.Instance.ChangeHeroItemImg(this.MissionMap_T.GetChild(7).GetChild(0).GetChild(0), eHeroOrItem.Hero, this.DM.RoleAttr.Head, (byte) 0, (byte) 0);
          uTweenPosition.Begin(((Component) this.Img_MissionFinalHeadBG).gameObject, ((Component) this.Img_MissionFinalHeadBG).transform.localPosition, ((Component) this.Img_MissionFinalHeadBG).transform.localPosition + new Vector3(0.0f, 300f, 0.0f), 0.5f).easeType = EaseType.easeInExpo;
          ((Component) this.btnMissionGiftFinal).gameObject.SetActive(false);
          ((Component) this.btnMissionReceive1).gameObject.SetActive(false);
          ((Component) this.btnMissionReceive2).gameObject.SetActive(false);
          ((Component) this.btnMissionGift).gameObject.SetActive(false);
          ((Component) this.ImgDialogbox2).gameObject.SetActive(false);
          ((Component) this.ImgDialogbox1).gameObject.SetActive(true);
          if (this.mMissionHead[10].Runner[0] != null)
          {
            this.mMissionHead[10].Runner[0].SetEndRecall((IAERunnerEndHandler) null);
            this.mMissionHead[10].Runner[0].SetTime(10f);
          }
          this.Price = recordByKey.OwnPrice;
          this.fFinal = this.fFirst = 0.0f;
        }
        else if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex >= (byte) 11)
        {
          this.FinishStr.ClearString();
          if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() != (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
          {
            this.Award = DataManager.FBMissionDataManager.GetAwardSocialInfo();
            FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = this.Award.AwardIndex <= (byte) 0 ? (ushort) byte.MaxValue : (ushort) this.Award.AwardIndex);
            int friendIndex = DataManager.FBMissionDataManager.GetFriendIndex(DataManager.FBMissionDataManager.GetRewardSerial());
            if (friendIndex >= 0 && DataManager.FBMissionDataManager.FBFriends[friendIndex].Result == (byte) 0)
            {
              if (this.Award.AwardIndex > (byte) 0)
              {
                this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
                this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID(this.Award.AwardIndex < (byte) 11 ? 12170U : 12171U));
              }
              else
                this.FinishStr.Append(this.DM.mStringTable.GetStringByID(12194U));
            }
            else
            {
              this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(recordByKey.FriendPrice).EquipName));
              this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID(12182U));
            }
            this.Price = (ushort) 0;
          }
          else
          {
            FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = DataManager.FBMissionDataManager.GetRewardCount() <= (ushort) 0 ? (ushort) 11 : DataManager.FBMissionDataManager.GetRewardIndex());
            this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
            this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID(this.Reward < (ushort) 11 ? 12168U : 12169U));
            this.Price = recordByKey.OwnPrice;
          }
          this.text_Dialogbox2_Mission[0].text = this.FinishStr.ToString();
          this.text_Dialogbox2_Mission[0].SetAllDirty();
          this.text_Dialogbox2_Mission[0].cachedTextGenerator.Invalidate();
          this.text_Dialogbox2_Mission[0].cachedTextGeneratorForLayout.Invalidate();
          ((Graphic) this.text_Dialogbox2_Mission[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Dialogbox2_Mission[0]).rectTransform.sizeDelta.x, this.text_Dialogbox2_Mission[0].preferredHeight);
          UIText uiText1 = this.text_Dialogbox2_Mission[1];
          string empty1 = string.Empty;
          this.text_Dialogbox2_Mission[3].text = empty1;
          string str1 = empty1;
          this.text_Dialogbox2_Mission[2].text = str1;
          string str2 = str1;
          uiText1.text = str2;
          UIText uiText2 = this.text_Dialogbox2_Degree[0];
          string empty2 = string.Empty;
          this.text_Dialogbox2_Degree[1].text = empty2;
          string str3 = empty2;
          uiText2.text = str3;
          Image image = this.ImgDialogbox2_Degree[0];
          bool flag = false;
          ((Behaviour) this.ImgDialogbox2_Degree[1]).enabled = flag;
          int num = flag ? 1 : 0;
          ((Behaviour) image).enabled = num != 0;
          ((Component) this.ImgDialogbox2).gameObject.SetActive(true);
          ((Component) this.ImgDialogbox1).gameObject.SetActive(false);
          if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
            this.bGiftEnd = !DataManager.FBMissionDataManager.IsInTime();
          if ((int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo && DataManager.FBMissionDataManager.GetRewardIndex() == (ushort) 11 && arg2 < 10 && this.mMissionHead[10].Runner[0] == null)
          {
            this.mMissionHead[10].Runner[0] = AERunnerSetter.SetFunctionAppear(((Graphic) this.mMissionHead[10].BG).rectTransform, this.mMissionHead[10].HeadImages);
            this.mMissionHead[10].Runner[0].SetEndRecall((IAERunnerEndHandler) this);
            this.mMissionHead[10].Runner[0].mRunner_ID2 = 11;
            this.mMissionHead[10].Runner[0].SetTime(0.0f);
            ((Component) this.mMissionHead[10].BG).transform.localScale = Vector3.forward;
            this.fFirst = 1.16f;
          }
        }
        else
        {
          FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = (ushort) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex);
          UIText uiText = this.text_Dialogbox2_Mission[0];
          string stringById = this.DM.mStringTable.GetStringByID((uint) recordByKey.Name);
          this.text_Dialogbox2_Mission[3].text = stringById;
          string str4 = stringById;
          this.text_Dialogbox2_Mission[2].text = str4;
          string str5 = str4;
          uiText.text = str5;
          float preferredHeight1 = this.text_Dialogbox2_Mission[0].preferredHeight;
          CString hintStr1 = this.HintStr;
          int num1 = 0;
          this.Node2Str.Length = num1;
          int num2 = num1;
          this.Node1Str.Length = num2;
          int num3 = num2;
          hintStr1.Length = num3;
          ((Graphic) this.text_Dialogbox2_Mission[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Dialogbox2_Mission[0]).rectTransform.sizeDelta.x, preferredHeight1);
          DataManager.FBMissionDataManager.GetNarrative(this.HintStr, ref recordByKey, (byte) 0);
          float preferredHeight2 = this.text_Dialogbox2_Mission[2].preferredHeight;
          this.Node1Str.StringToFormat(this.HintStr);
          this.Node1Str.AppendFormat(!this.GUIM.IsArabic ? "> {0}" : "－ {0}");
          this.text_Dialogbox2_Mission[2].text = this.Node1Str.ToString();
          this.text_Dialogbox2_Mission[2].SetAllDirty();
          this.text_Dialogbox2_Mission[2].cachedTextGenerator.Invalidate();
          this.text_Dialogbox2_Mission[2].cachedTextGeneratorForLayout.Invalidate();
          CString hintStr2 = this.HintStr;
          int num4 = 0;
          this.Node2Str.Length = num4;
          int num5 = num4;
          hintStr2.Length = num5;
          DataManager.FBMissionDataManager.GetNarrative(this.HintStr, ref recordByKey, (byte) 1);
          preferredHeight2 = this.text_Dialogbox2_Mission[3].preferredHeight;
          this.Node2Str.StringToFormat(this.HintStr);
          this.Node2Str.AppendFormat(!this.GUIM.IsArabic ? "> {0}" : "－ {0}");
          this.text_Dialogbox2_Mission[3].text = this.Node2Str.ToString();
          this.text_Dialogbox2_Mission[3].SetAllDirty();
          this.text_Dialogbox2_Mission[3].cachedTextGenerator.Invalidate();
          this.text_Dialogbox2_Mission[3].cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.ImgDialogbox2).gameObject.SetActive(true);
          this.Price = recordByKey.OwnPrice;
          this.HintStr.ClearString();
          DataManager.FBMissionDataManager.GetMissionState(ref this.State[0], recordByKey.ID, 0);
          this.HintStr.IntToFormat((long) this.State[0].GoalNum, bNumber: true);
          this.HintStr.IntToFormat((long) this.State[0].GoalNum, bNumber: true);
          this.HintStr.AppendFormat(!this.GUIM.IsArabic ? "{0} / {1}" : "{1} / {0}");
          this.text_Dialogbox2_Degree[0].text = this.HintStr.ToString();
          this.text_Dialogbox2_Degree[0].SetAllDirty();
          this.text_Dialogbox2_Degree[0].cachedTextGenerator.Invalidate();
          this.text_Dialogbox2_Degree[0].cachedTextGeneratorForLayout.Invalidate();
          float preferredWidth1 = this.text_Dialogbox2_Degree[0].preferredWidth;
          this.Goal1Str.ClearString();
          this.Goal1Str.IntToFormat((long) this.State[0].CurNum, bNumber: true);
          this.Goal1Str.IntToFormat((long) this.State[0].GoalNum, bNumber: true);
          this.Goal1Str.AppendFormat(!this.GUIM.IsArabic ? "{0} / {1}" : "{1} / {0}");
          this.text_Dialogbox2_Degree[0].text = this.Goal1Str.ToString();
          this.text_Dialogbox2_Degree[0].SetAllDirty();
          this.text_Dialogbox2_Degree[0].cachedTextGenerator.Invalidate();
          this.text_Dialogbox2_Degree[0].cachedTextGeneratorForLayout.Invalidate();
          GameObject gameObject1 = ((Component) this.text_Dialogbox2_Degree[0]).gameObject;
          bool flag1 = (int) this.State[0].CurNum == (int) this.State[0].GoalNum;
          ((Behaviour) this.ImgDialogbox2_Degree[0]).enabled = flag1;
          int num6 = flag1 ? 0 : (this.State[0].bCount > (byte) 0 ? 1 : 0);
          gameObject1.SetActive(num6 != 0);
          ((Component) this.text_Dialogbox2_Degree[0]).transform.localPosition = new Vector3((float) (0.5 * ((double) preferredWidth1 - (double) this.text_Dialogbox2_Degree[0].preferredWidth) + 370.0 + (!this.GUIM.IsArabic ? 0.0 : (double) ((Graphic) this.text_Dialogbox2_Degree[0]).rectTransform.sizeDelta.x)), ((Component) this.text_Dialogbox2_Degree[0]).transform.localPosition.y, 0.0f);
          DataManager.FBMissionDataManager.GetMissionState(ref this.State[1], recordByKey.ID, 1);
          this.HintStr.ClearString();
          this.HintStr.IntToFormat((long) this.State[1].GoalNum, bNumber: true);
          this.HintStr.IntToFormat((long) this.State[1].GoalNum, bNumber: true);
          this.HintStr.AppendFormat(!this.GUIM.IsArabic ? "{0} / {1}" : "{1} / {0}");
          this.text_Dialogbox2_Degree[1].text = this.HintStr.ToString();
          this.text_Dialogbox2_Degree[1].SetAllDirty();
          this.text_Dialogbox2_Degree[1].cachedTextGenerator.Invalidate();
          this.text_Dialogbox2_Degree[1].cachedTextGeneratorForLayout.Invalidate();
          float preferredWidth2 = this.text_Dialogbox2_Degree[1].preferredWidth;
          this.Goal2Str.ClearString();
          this.Goal2Str.IntToFormat((long) this.State[1].CurNum, bNumber: true);
          this.Goal2Str.IntToFormat((long) this.State[1].GoalNum, bNumber: true);
          this.Goal2Str.AppendFormat(!this.GUIM.IsArabic ? "{0} / {1}" : "{1} / {0}");
          this.text_Dialogbox2_Degree[1].text = this.Goal2Str.ToString();
          this.text_Dialogbox2_Degree[1].SetAllDirty();
          this.text_Dialogbox2_Degree[1].cachedTextGenerator.Invalidate();
          this.text_Dialogbox2_Degree[1].cachedTextGeneratorForLayout.Invalidate();
          GameObject gameObject2 = ((Component) this.text_Dialogbox2_Degree[1]).gameObject;
          bool flag2 = (int) this.State[1].CurNum == (int) this.State[1].GoalNum;
          ((Behaviour) this.ImgDialogbox2_Degree[1]).enabled = flag2;
          int num7 = flag2 ? 0 : (this.State[1].bCount > (byte) 0 ? 1 : 0);
          gameObject2.SetActive(num7 != 0);
          ((Component) this.text_Dialogbox2_Degree[1]).transform.localPosition = new Vector3((float) (0.5 * ((double) preferredWidth2 - (double) this.text_Dialogbox2_Degree[1].preferredWidth) + 370.0 + (!this.GUIM.IsArabic ? 0.0 : (double) ((Graphic) this.text_Dialogbox2_Degree[1]).rectTransform.sizeDelta.x)), ((Component) this.text_Dialogbox2_Degree[1]).transform.localPosition.y, 0.0f);
          this.text_Dialogbox2_Mission[1].text = this.DM.mStringTable.GetStringByID(12167U);
        }
        for (int index = 2; index < this.text_Dialogbox2_Mission.Length; ++index)
        {
          ((Graphic) this.text_Dialogbox2_Mission[index]).rectTransform.sizeDelta = new Vector2(index <= 1 ? 420f : 318f, this.text_Dialogbox2_Mission[index].preferredHeight);
          ((Graphic) this.text_Dialogbox2_Mission[index]).rectTransform.anchoredPosition = ((Graphic) this.text_Dialogbox2_Mission[index - 1]).rectTransform.anchoredPosition - new Vector2(!this.GUIM.IsArabic ? 0.0f : (index != 2 ? 0.0f : 102f), ((Graphic) this.text_Dialogbox2_Mission[index - 1]).rectTransform.sizeDelta.y + 1f);
        }
        for (int index = 0; index < this.text_Dialogbox2_Degree.Length; ++index)
        {
          UIText uiText = this.text_Dialogbox2_Mission[index + 2];
          Color color1 = !((Behaviour) this.ImgDialogbox2_Degree[index]).enabled ? this.mMissionGray : this.mMissionGreen;
          ((Graphic) this.text_Dialogbox2_Degree[index]).color = color1;
          Color color2 = color1;
          ((Graphic) uiText).color = color2;
          ((Graphic) this.text_Dialogbox2_Degree[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_Dialogbox2_Degree[index]).rectTransform.anchoredPosition.x, ((Graphic) this.text_Dialogbox2_Mission[index + 2]).rectTransform.anchoredPosition.y);
          ((Graphic) this.ImgDialogbox2_Degree[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.ImgDialogbox2_Degree[index]).rectTransform.anchoredPosition.x, ((Graphic) this.text_Dialogbox2_Mission[index + 2]).rectTransform.anchoredPosition.y);
        }
        bool flag3 = DataManager.Instance.CheckPrizeFlag((byte) 29);
        if ((double) this.fPrize > 0.0)
          uTweenPosition.Begin(((Component) this.Img_MissionFinalHeadBG).gameObject, ((Component) this.Img_MissionFinalHeadBG).transform.localPosition, ((Component) this.Img_MissionFinalHeadBG).transform.localPosition + new Vector3(0.0f, 300f, 0.0f), 0.5f).easeType = EaseType.easeInExpo;
        this.text_GiftNum.text = DataManager.FBMissionDataManager.GetRewardCount().ToString();
        ((Component) this.Img_GiftNum).gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0);
        ((Graphic) this.Img_GiftNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_GiftNum.preferredWidth), ((Graphic) this.Img_GiftNum).rectTransform.sizeDelta.y);
        ((Component) this.Img_MissionFinalHeadBG).gameObject.SetActive(DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex >= (byte) 11 && (this.bMission || !this.DM.CheckPrizeFlag((byte) 29)) && (double) this.fFinal == 0.0);
        ((Component) this.Img_MissionFinalHeadBG).transform.GetChild(1).gameObject.SetActive(false);
        for (int index = 1; index < this.mMissionHead.Length; ++index)
        {
          if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardIndex() == index && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || (DataManager.FBMissionDataManager.IsInTime() || !flag3 && !this.bGiftEnd) && (int) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == index)
          {
            GUIManager.Instance.ChangeHeroItemImg(this.MissionLine_T.GetChild(41 + index - 1).GetChild(0).GetChild(0), eHeroOrItem.Hero, this.DM.RoleAttr.Head, (byte) 11, (byte) 0);
            if (!this.MissionLine_T.GetChild(41 + index - 1).GetChild(0).gameObject.activeSelf && arg2 < 10 && this.mMissionHead[index - 1].Runner[0] == null)
            {
              if (index == 1)
              {
                this.mMissionHead[index - 1].Runner[0] = AERunnerSetter.SetFunctionFirst(((Graphic) this.mMissionHead[index - 1].BG).rectTransform, this.mMissionHead[index - 1].HeadImages);
                this.fFirst = 0.4f;
              }
              else
              {
                this.mMissionHead[index - 1].Runner[0] = AERunnerSetter.SetFunctionAppear(((Graphic) this.mMissionHead[index - 1].BG).rectTransform, this.mMissionHead[index - 1].HeadImages);
                this.fFirst = 1.1f;
              }
              ((Component) this.mMissionHead[index - 1].BG).transform.localScale = Vector3.forward;
              this.mMissionHead[index - 1].Runner[0].SetEndRecall((IAERunnerEndHandler) this);
              this.mMissionHead[index - 1].Runner[0].mRunner_ID2 = index;
              this.mMissionHead[index - 1].Runner[0].SetTime(0.0f);
            }
            this.MissionLine_T.GetChild(41 + index - 1).GetChild(0).gameObject.SetActive(true);
          }
          else if (this.MissionLine_T.GetChild(41 + index - 1).GetChild(0).gameObject.activeSelf)
          {
            if (this.mMissionHead[index - 1].Runner[1] == null && (DataManager.FBMissionDataManager.IsInTime() || arg2 == 1))
            {
              this.mMissionHead[index - 1].Runner[1] = AERunnerSetter.SetFunctionDisappear(((Graphic) this.mMissionHead[index - 1].BG).rectTransform, this.mMissionHead[index - 1].HeadImages);
              this.mMissionHead[index - 1].Runner[1].mRunner_ID1 = 1;
              this.mMissionHead[index - 1].Runner[1].SetEndRecall((IAERunnerEndHandler) this);
              this.mMissionHead[index - 1].Runner[1].SetTime(0.0f);
              this.fHide = 0.33f;
            }
            this.mMissionHead[index - 1].Runner[0] = (AERunner) null;
          }
          else
            this.MissionLine_T.GetChild(41 + index - 1).GetChild(0).gameObject.SetActive(false);
          ((Component) this.mMissionHead[index - 1].Head).transform.GetChild(1).gameObject.SetActive(false);
          ((Component) this.mMissionHead[index - 1].Time).gameObject.SetActive(false);
        }
        for (int index = 1; index <= this.Img_MissionInfo.Length; ++index)
        {
          if ((DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardIndex() > index && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || (int) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > index) && !flag3)
          {
            if (arg2 == 10)
              ((Component) this.Img_MissionInfo[index - 1]).transform.GetChild(0).gameObject.SetActive(true);
            if (!((Component) this.Img_MissionInfo[index - 1]).transform.GetChild(0).gameObject.activeSelf && (DataManager.FBMissionDataManager.GetRewardCount() == (ushort) 0 || (int) DataManager.FBMissionDataManager.GetRewardSerial() != (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || (int) DataManager.FBMissionDataManager.GetRewardIndex() - 1 == index) && this.mMissionHead[index - 1].Runner[2] == null && arg2 < 10)
            {
              ((Component) this.Img_MissionInfo[index - 1]).transform.GetChild(0).gameObject.SetActive(true);
              this.mMissionHead[index - 1].Runner[2] = AERunnerSetter.SetFunctionTick(((Graphic) this.mMissionHead[index - 1].TickImages[0]).rectTransform, this.mMissionHead[index - 1].TickImages);
              this.mMissionHead[index - 1].Runner[2].SetEndRecall((IAERunnerEndHandler) this);
              this.mMissionHead[index - 1].Runner[2].mRunner_ID1 = 2;
              this.mMissionHead[index - 1].Runner[2].SetTime(0.0f);
            }
          }
          if (index == (int) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex && (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || DataManager.FBMissionDataManager.IsInTime() || this.mMissionHead[index - 1].Runner[1] == null && ((Component) this.mMissionHead[index - 1].BG).gameObject.activeSelf) && this.mMissionHead[index - 1].Runner[0] == null && !flag3)
            ((Component) this.Img_MissionInfo[index - 1]).transform.GetChild(1).gameObject.SetActive(true);
          else
            ((Component) this.Img_MissionInfo[index - 1]).transform.GetChild(1).gameObject.SetActive(false);
        }
        if (!((Component) this.ImgDialogbox1).gameObject.activeSelf)
        {
          ((Component) this.btnMissionGiftFinal).gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardIndex() == (ushort) 11);
          ((Component) this.btnMissionGift).gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardIndex() != (ushort) 11);
          if (((Component) this.Img_MissionFinalHeadBG).gameObject.activeSelf && (double) this.fFinal == 0.0)
          {
            GUIManager.Instance.ChangeHeroItemImg(this.MissionMap_T.GetChild(7).GetChild(0).GetChild(0), eHeroOrItem.Hero, this.DM.RoleAttr.Head, (byte) 11, (byte) 0);
            ((Component) this.Img_MissionFinalHead).transform.GetChild(1).gameObject.SetActive(false);
          }
          ((Component) this.btnMissionReceive1).gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardCount() == (ushort) 0);
          ((Component) this.btnMissionReceive2).gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0);
        }
        if (((Component) this.btnInvite).gameObject.activeSelf)
        {
          this.HintStr.ClearString();
          this.HintStr.IntToFormat((long) SocialManager.Instance.GetFriendNumber());
          this.HintStr.IntToFormat((long) SocialManager.Instance.MaxConcurrentFriend);
          this.HintStr.AppendFormat(this.DM.mStringTable.GetStringByID(12155U));
          this.text_TopInfo[0].text = this.HintStr.ToString();
          this.text_TopInfo[0].SetAllDirty();
          this.text_TopInfo[0].cachedTextGenerator.Invalidate();
          this.text_TopInfo[0].cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.text_TopInfo[0]).gameObject.SetActive(SocialManager.Instance.MaxConcurrentFriend > (byte) 0);
          ((Component) this.text_TopInfo[1]).gameObject.SetActive(SocialManager.Instance.MaxConcurrentFriend > (byte) 0);
          ((Component) this.text_Full).gameObject.SetActive(SocialManager.Instance.MaxConcurrentFriend == (byte) 0);
        }
        else
        {
          ((Component) this.text_TopInfo[0]).gameObject.SetActive(false);
          ((Component) this.text_TopInfo[1]).gameObject.SetActive(false);
          ((Component) this.text_Full).gameObject.SetActive(false);
        }
        ((Graphic) this.ImgDialogbox2).color = DataManager.FBMissionDataManager.GetRewardCount() <= (ushort) 0 || (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo ? this.mDialogSelf : this.mDialogFriend;
        for (int index = 0; index < 10; ++index)
        {
          int friendCountByProgress = (int) DataManager.FBMissionDataManager.GetFriendCountByProgress((byte) (index + 1));
          this.mPosition[index].transform.GetChild(0).gameObject.SetActive(true);
          this.mFriendsHead[index].Show = (float) friendCountByProgress;
          if (arg2 == 10)
            this.mFriendsHead[index].Canvas.alpha = friendCountByProgress <= 0 ? 0.0f : 1f;
          if (friendCountByProgress > 0)
          {
            this.mPosition[index].transform.GetChild(0).GetComponent<Image>().sprite = this.SArray.GetSprite(((Component) this.mMissionHead[index].BG).gameObject.activeSelf && this.mMissionHead[index].Runner[0] == null && this.mMissionHead[index].Runner[1] == null || friendCountByProgress > 1 ? 1 : 0);
            if (this.Emoji[index] != null)
            {
              this.GUIM.pushEmojiIcon(this.Emoji[index]);
              this.Emoji[index] = (EmojiUnit) null;
            }
            if ((this.Emoji[index] = DataManager.FBMissionDataManager.GetFriendEmoji((byte) (index + 1), 0)) != null)
            {
              Rect rect = ((Graphic) this.Emoji[index].EmojiImage).rectTransform.rect;
              float num = 46f / ((double) rect.width >= (double) rect.height ? rect.width : rect.height);
              this.Emoji[index].EmojiTransform.SetParent(this.mPosition[index].transform.GetChild(0), false);
              this.Emoji[index].EmojiTransform.SetSiblingIndex(1);
              this.Emoji[index].EmojiTransform.localPosition = Vector3.zero;
              ((RectTransform) this.Emoji[index].EmojiTransform).anchoredPosition = new Vector2(-5f, 5f);
              this.Emoji[index].EmojiTransform.localScale = new Vector3(num, num, num);
            }
          }
        }
        this.UpdateTime(this.bOpenEnd);
        int friendCountByProgress1 = (int) DataManager.FBMissionDataManager.GetFriendCountByProgress((byte) 11);
        int friendCountByProgress2 = (int) DataManager.FBMissionDataManager.GetFriendCountByProgress((byte) 12);
        this.mFriendsHead[10].Show = (float) (friendCountByProgress1 + friendCountByProgress2);
        this.mFriends[10].transform.GetChild(0).gameObject.SetActive(false);
        this.mFriends[10].transform.gameObject.SetActive(true);
        if (arg2 == 10 || (double) this.mFriendsHead[10].Show == 0.0)
          this.mFriendsHead[10].Canvas.alpha = (double) this.mFriendsHead[10].Show <= 0.0 ? 0.0f : 1f;
        this.mFriends[10].GetComponent<Image>().sprite = this.SArray.GetSprite(friendCountByProgress1 + friendCountByProgress2 + (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex != (byte) 11 ? 0 : 1) <= 1 ? 0 : 1);
        this.mPosition[10].transform.GetChild(0).gameObject.SetActive(false);
        if (this.Emoji[11] != null)
        {
          this.GUIM.pushEmojiIcon(this.Emoji[11]);
          this.Emoji[11] = (EmojiUnit) null;
        }
        if (this.mFriends[10].activeSelf)
        {
          SocialFriend friend;
          DataManager.FBMissionDataManager.GetFriendSocialInfo(friendCountByProgress2 <= 0 ? (byte) 11 : (byte) 12, 0, out friend, false);
          if (friend != null && (this.Emoji[11] = DataManager.FBMissionDataManager.GetFriendEmoji((ushort) friend.IconNo)) != null)
          {
            Rect rect = ((Graphic) this.Emoji[11].EmojiImage).rectTransform.rect;
            float num = 46f / ((double) rect.width >= (double) rect.height ? rect.width : rect.height);
            this.Emoji[11].EmojiTransform.SetParent(this.mFriends[10].transform, false);
            this.Emoji[11].EmojiTransform.localPosition = Vector3.zero;
            ((RectTransform) this.Emoji[11].EmojiTransform).anchoredPosition = new Vector2(-5f, 5f);
            this.Emoji[11].EmojiTransform.localScale = new Vector3(num, num, num);
            this.mFriends[10].GetComponent<UIButtonHint>().Parm1 = (ushort) friend.NodeIndex;
          }
        }
        if (this.DM.RoleAttr.Inviter.Invited > (byte) 0 && this.DM.RoleAttr.Inviter.Result == (byte) 0)
          GUIManager.Instance.ChangeHeroItemImg(((Component) this.PiggyHead).transform, eHeroOrItem.Hero, this.DM.RoleAttr.Inviter.Head, (byte) 0, (byte) 0);
        else
          this.Img_PigHead.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite((ushort) 1000);
        if (this.Emoji[10] != null)
        {
          this.GUIM.pushEmojiIcon(this.Emoji[10]);
          this.Emoji[10] = (EmojiUnit) null;
        }
        if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() != (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
        {
          int friendIndex = DataManager.FBMissionDataManager.GetFriendIndex(DataManager.FBMissionDataManager.GetRewardSerial());
          if (friendIndex >= 0 && DataManager.FBMissionDataManager.FBFriends[friendIndex].Result == (byte) 0)
          {
            if (DataManager.FBMissionDataManager.FBFriends[friendIndex].Name.Length == 0)
              DataManager.FBMissionDataManager.SendFriend_SocialInfo(DataManager.FBMissionDataManager.FBFriends[friendIndex].UserSerialNo);
            if ((this.Emoji[10] = DataManager.FBMissionDataManager.GetFriendEmoji((ushort) DataManager.FBMissionDataManager.FBFriends[friendIndex].IconNo)) != null)
            {
              this.Emoji[10].EmojiTransform.SetParent(((Component) this.Img_Head).transform, false);
              ((RectTransform) this.Emoji[10].EmojiTransform).anchorMax = 0.5f * Vector2.one;
              ((RectTransform) this.Emoji[10].EmojiTransform).anchorMin = 0.5f * Vector2.one;
              ((RectTransform) this.Emoji[10].EmojiTransform).anchoredPosition = Vector2.zero;
            }
            ((Graphic) this.ImgDialogbox2).color = this.mDialogFriend;
            this.UpdateFriendName((byte) friendIndex);
          }
          else
          {
            this.UpdateNPCName();
            ((Graphic) this.ImgDialogbox2).color = this.mDialogSelf;
            this.Img_PigHead.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite((ushort) 1000);
          }
          ((Component) this.Img_Head).gameObject.SetActive(true);
          ((Component) this.Img_Head).transform.GetChild(0).gameObject.SetActive(friendIndex < 0 || DataManager.FBMissionDataManager.FBFriends[friendIndex].Result > (byte) 0);
          ((Component) this.Img_Recommend).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.Img_Head).transform.GetChild(0).gameObject.SetActive(true);
          ((Graphic) this.ImgDialogbox2).color = this.mDialogSelf;
          if (this.DM.RoleAttr.Inviter.Invited > (byte) 0 && this.DM.RoleAttr.Inviter.Result == (byte) 0)
          {
            if (this.DM.RoleAttr.Inviter.Name.Length > 0)
            {
              ((Component) this.Img_Recommend).gameObject.SetActive(true);
              ((Component) this.Img_Head).gameObject.SetActive(true);
              this.UpdateFriendName();
            }
            else
              DataManager.FBMissionDataManager.SendFriend_SocialInfo((byte) 0);
          }
          else
          {
            ((Component) this.Img_Recommend).gameObject.SetActive(false);
            ((Component) this.Img_Head).gameObject.SetActive(true);
            this.UpdateNPCName();
          }
        }
        this.text_Npc_Tag.SetAllDirty();
        this.text_Npc_Tag.cachedTextGenerator.Invalidate();
        this.text_Npc_Tag.cachedTextGeneratorForLayout.Invalidate();
        this.text_Npc_Name.SetAllDirty();
        this.text_Npc_Name.cachedTextGenerator.Invalidate();
        this.text_Npc_Name.cachedTextGeneratorForLayout.Invalidate();
        ((Component) this.Img_Head).transform.parent.gameObject.SetActive(true);
        this.FBUIHint.UpdateData();
        break;
      case 1:
        if ((int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
        {
          this.fPrize = 0.5f;
          break;
        }
        int friendIndex1 = DataManager.FBMissionDataManager.GetFriendIndex(DataManager.FBMissionDataManager.GetRewardSerial());
        if (friendIndex1 < 0)
          break;
        if (this.Emoji[12] != null)
        {
          this.GUIM.pushEmojiIcon(this.Emoji[12]);
          this.Emoji[12] = (EmojiUnit) null;
        }
        if ((this.Emoji[12] = DataManager.FBMissionDataManager.GetFriendEmoji((ushort) DataManager.FBMissionDataManager.FBFriends[friendIndex1].IconNo)) == null)
          break;
        Rect rect1 = ((Graphic) this.Emoji[12].EmojiImage).rectTransform.rect;
        float num8 = 46f / ((double) rect1.width >= (double) rect1.height ? rect1.width : rect1.height);
        this.Emoji[12].EmojiTransform.SetParent(this.mPosition[10].transform, false);
        this.Emoji[12].EmojiTransform.localPosition = Vector3.zero;
        ((RectTransform) this.Emoji[12].EmojiTransform).anchoredPosition = new Vector2(-5f, 5f);
        this.Emoji[12].EmojiTransform.localScale = new Vector3(num8, num8, num8);
        this.mPosition[10].transform.gameObject.SetActive(true);
        uTweenPosition.Begin(this.mPosition[10], this.mFriendHead, this.mFriendHead + new Vector3(0.0f, 300f, 0.0f), 0.5f).easeType = EaseType.easeInExpo;
        this.fFinish = 0.5f;
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if (this.bCloseExit)
      return;
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_FB_Tag != (Object) null && ((Behaviour) this.text_FB_Tag).enabled)
    {
      ((Behaviour) this.text_FB_Tag).enabled = false;
      ((Behaviour) this.text_FB_Tag).enabled = true;
    }
    if ((Object) this.text_FB_Name != (Object) null && ((Behaviour) this.text_FB_Name).enabled)
    {
      ((Behaviour) this.text_FB_Name).enabled = false;
      ((Behaviour) this.text_FB_Name).enabled = true;
    }
    if ((Object) this.text_TimeOut != (Object) null && ((Behaviour) this.text_TimeOut).enabled)
    {
      ((Behaviour) this.text_TimeOut).enabled = false;
      ((Behaviour) this.text_TimeOut).enabled = true;
    }
    if ((Object) this.text_GiftNum != (Object) null && ((Behaviour) this.text_GiftNum).enabled)
    {
      ((Behaviour) this.text_GiftNum).enabled = false;
      ((Behaviour) this.text_GiftNum).enabled = true;
    }
    if ((Object) this.text_Npc_Tag != (Object) null && ((Behaviour) this.text_Npc_Tag).enabled)
    {
      ((Behaviour) this.text_Npc_Tag).enabled = false;
      ((Behaviour) this.text_Npc_Tag).enabled = true;
    }
    if ((Object) this.text_Npc_Name != (Object) null && ((Behaviour) this.text_Npc_Name).enabled)
    {
      ((Behaviour) this.text_Npc_Name).enabled = false;
      ((Behaviour) this.text_Npc_Name).enabled = true;
    }
    if ((Object) this.text_HelpTitle != (Object) null && ((Behaviour) this.text_HelpTitle).enabled)
    {
      ((Behaviour) this.text_HelpTitle).enabled = false;
      ((Behaviour) this.text_HelpTitle).enabled = true;
    }
    if ((Object) this.text_Recommend != (Object) null && ((Behaviour) this.text_Recommend).enabled)
    {
      ((Behaviour) this.text_Recommend).enabled = false;
      ((Behaviour) this.text_Recommend).enabled = true;
    }
    if ((Object) this.text_Dialogbox1 != (Object) null && ((Behaviour) this.text_Dialogbox1).enabled)
    {
      ((Behaviour) this.text_Dialogbox1).enabled = false;
      ((Behaviour) this.text_Dialogbox1).enabled = true;
    }
    if ((Object) this.text_MF_TimeCD != (Object) null && ((Behaviour) this.text_MF_TimeCD).enabled)
    {
      ((Behaviour) this.text_MF_TimeCD).enabled = false;
      ((Behaviour) this.text_MF_TimeCD).enabled = true;
    }
    if ((Object) this.text_Invite != (Object) null && ((Behaviour) this.text_Invite).enabled)
    {
      ((Behaviour) this.text_Invite).enabled = false;
      ((Behaviour) this.text_Invite).enabled = true;
    }
    if ((Object) this.text_Full != (Object) null && ((Behaviour) this.text_Full).enabled)
    {
      ((Behaviour) this.text_Full).enabled = false;
      ((Behaviour) this.text_Full).enabled = true;
    }
    if ((Object) this.text_FB_Gift != (Object) null && ((Behaviour) this.text_FB_Gift).enabled)
    {
      ((Behaviour) this.text_FB_Gift).enabled = false;
      ((Behaviour) this.text_FB_Gift).enabled = true;
    }
    if ((Object) this.text_FB_Receive != (Object) null && ((Behaviour) this.text_FB_Receive).enabled)
    {
      ((Behaviour) this.text_FB_Receive).enabled = false;
      ((Behaviour) this.text_FB_Receive).enabled = true;
    }
    if ((Object) this.text_FB_btnReceive != (Object) null && ((Behaviour) this.text_FB_btnReceive).enabled)
    {
      ((Behaviour) this.text_FB_btnReceive).enabled = false;
      ((Behaviour) this.text_FB_btnReceive).enabled = true;
    }
    if ((Object) this.text_btnMissionReceive1 != (Object) null && ((Behaviour) this.text_btnMissionReceive1).enabled)
    {
      ((Behaviour) this.text_btnMissionReceive1).enabled = false;
      ((Behaviour) this.text_btnMissionReceive1).enabled = true;
    }
    if ((Object) this.text_btnMissionReceive2 != (Object) null && ((Behaviour) this.text_btnMissionReceive2).enabled)
    {
      ((Behaviour) this.text_btnMissionReceive2).enabled = false;
      ((Behaviour) this.text_btnMissionReceive2).enabled = true;
    }
    for (int index = 0; index < 10; ++index)
    {
      if ((Object) this.mMissionHead[index].text_MH_Time != (Object) null && ((Behaviour) this.mMissionHead[index].text_MH_Time).enabled)
      {
        ((Behaviour) this.mMissionHead[index].text_MH_Time).enabled = false;
        ((Behaviour) this.mMissionHead[index].text_MH_Time).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.text_Dialogbox2_Mission[index] != (Object) null && ((Behaviour) this.text_Dialogbox2_Mission[index]).enabled)
      {
        ((Behaviour) this.text_Dialogbox2_Mission[index]).enabled = false;
        ((Behaviour) this.text_Dialogbox2_Mission[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_HelpText[index] != (Object) null && ((Behaviour) this.text_HelpText[index]).enabled)
      {
        ((Behaviour) this.text_HelpText[index]).enabled = false;
        ((Behaviour) this.text_HelpText[index]).enabled = true;
      }
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Time[index] != (Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
      if ((Object) this.text_TopInfo[index] != (Object) null && ((Behaviour) this.text_TopInfo[index]).enabled)
      {
        ((Behaviour) this.text_TopInfo[index]).enabled = false;
        ((Behaviour) this.text_TopInfo[index]).enabled = true;
      }
      if ((Object) this.text_Dialogbox2_Degree[index] != (Object) null && ((Behaviour) this.text_Dialogbox2_Degree[index]).enabled)
      {
        ((Behaviour) this.text_Dialogbox2_Degree[index]).enabled = false;
        ((Behaviour) this.text_Dialogbox2_Degree[index]).enabled = true;
      }
      if ((Object) this.text_DialogboxEnd[index] != (Object) null && ((Behaviour) this.text_DialogboxEnd[index]).enabled)
      {
        ((Behaviour) this.text_DialogboxEnd[index]).enabled = false;
        ((Behaviour) this.text_DialogboxEnd[index]).enabled = true;
      }
    }
    if (this.FBUIHint == null)
      return;
    this.FBUIHint.TextRefresh();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!this.bOpenEnd)
      return;
    if (bOnSecond)
    {
      this.FBUIHint.UpdateTime();
      uint remainTime = DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex <= (byte) 11 ? DataManager.FBMissionDataManager.GetRemainTime() : 0U;
      this.MissionMap_T.GetChild(1).gameObject.SetActive(!this.DM.CheckPrizeFlag((byte) 29) && remainTime == 0U);
      this.MissionMap_T.GetChild(0).gameObject.SetActive(!this.DM.CheckPrizeFlag((byte) 29) && remainTime > 0U);
      for (int index = 0; index < 10; ++index)
      {
        if (DataManager.FBMissionDataManager.GetFriendCountByProgress((byte) (index + 1)) > (byte) 0)
        {
          this.Remaining[index].Length = 0;
          SocialFriend friend;
          DataManager.FBMissionDataManager.GetFriendSocialInfo((byte) (index + 1), 0, out friend, false);
          if (friend != null)
          {
            long sec = friend.MissionTime.BeginTime + (long) friend.MissionTime.RequireTime - DataManager.Instance.ServerTime;
            if ((sec < -5L && friend.TimeRemain || sec <= 0L && this.bUpdates) && friend.MissionTime.BeginTime > 0L && (DataManager.FBMissionDataManager.GetRewardCount() == (ushort) 0 || (int) DataManager.FBMissionDataManager.GetRewardSerial() != (int) friend.UserSerialNo))
            {
              friend.TimeRemain = false;
              this.bRefresh = true;
            }
            if (sec < 0L)
              sec = 0L;
            if (friend.MissionTime.BeginTime != 0L)
            {
              if (sec < 3600L)
                GameConstants.GetTimeString(this.Remaining[index], (uint) sec, hideTimeIfDays: true, showZeroHour: false);
              else if (sec < 259200L)
              {
                this.Remaining[index].IntToFormat(sec >= 86400L ? sec / 86400L : sec / 3600L);
                this.Remaining[index].AppendFormat(sec >= 86400L ? "{0}d" : "{0}h");
              }
            }
            this.mFriendsHead[index].text_MH_Time.text = this.Remaining[index].ToString();
            this.mFriendsHead[index].text_MH_Time.cachedTextGenerator.Invalidate();
            this.mFriendsHead[index].text_MH_Time.SetAllDirty();
            ((Component) this.mFriendsHead[index].Time).gameObject.SetActive(this.Remaining[index].Length > 0);
          }
        }
      }
      if (remainTime > 0U)
      {
        CString timeStr = this.TimeStr;
        int num1 = 0;
        this.HourStr.Length = num1;
        int num2 = num1;
        timeStr.Length = num2;
        GameConstants.GetTimeString(this.TimeStr, remainTime, hideTimeIfDays: true, showZeroHour: false);
        this.text_Time[1].text = this.TimeStr.ToString();
        this.text_Time[1].cachedTextGenerator.Invalidate();
        this.text_Time[1].SetAllDirty();
        for (int index = 1; index < this.mMissionHead.Length; ++index)
        {
          if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardIndex() == index && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || DataManager.FBMissionDataManager.IsInTime() && (int) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == index)
          {
            if (remainTime < 3600U)
              GameConstants.GetTimeString(this.HourStr, remainTime, hideTimeIfDays: true, showZeroHour: false);
            else if (remainTime < 259200U)
            {
              this.HourStr.IntToFormat(remainTime >= 86400U ? (long) (remainTime / 86400U) : (long) (remainTime / 3600U));
              this.HourStr.AppendFormat(remainTime >= 86400U ? "{0}d" : "{0}h");
            }
            ((Component) this.mMissionHead[index - 1].Time).gameObject.SetActive(this.HourStr.Length > 0);
            this.mMissionHead[index - 1].text_MH_Time.text = this.HourStr.ToString();
            this.mMissionHead[index - 1].text_MH_Time.cachedTextGenerator.Invalidate();
            this.mMissionHead[index - 1].text_MH_Time.SetAllDirty();
            break;
          }
        }
      }
      else if (this.TimeStr.Length > 0)
      {
        this.TimeStr.ClearString();
        this.UpdateUI(0, 20);
      }
    }
    for (int index = 0; index < this.mFriendsHead.Length; ++index)
    {
      if ((double) this.mFriendsHead[index].Show > 0.0)
      {
        if ((double) this.mFriendsHead[index].Canvas.alpha < 1.0)
          this.mFriendsHead[index].Canvas.alpha += Time.smoothDeltaTime;
        if ((double) this.mFriendsHead[index].Canvas.alpha > 1.0)
          this.mFriendsHead[index].Canvas.alpha = 1f;
      }
      else
      {
        if ((double) this.mFriendsHead[index].Canvas.alpha > 0.0)
          this.mFriendsHead[index].Canvas.alpha -= Time.smoothDeltaTime;
        if ((double) this.mFriendsHead[index].Canvas.alpha < 0.0)
          this.mFriendsHead[index].Canvas.alpha = 0.0f;
      }
    }
  }

  private void UpdateNPCName()
  {
    this.FB_T.gameObject.SetActive(false);
    this.NPC_T.gameObject.SetActive(true);
    Hero recordByKey = this.DM.HeroTable.GetRecordByKey((ushort) 101);
    this.text_Npc_Tag.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
    this.text_Npc_Name.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.HeroName);
  }

  private void UpdateFriendName(byte idx = 255, bool ShowReward = false)
  {
    this.FB_T.gameObject.SetActive(true);
    this.NPC_T.gameObject.SetActive(false);
    if (idx == byte.MaxValue)
    {
      this.ProFileStr = this.DM.RoleAttr.Inviter.Name;
      GameConstants.FormatRoleName(this.NameStr, this.ProFileStr, this.DM.RoleAttr.Inviter.AllianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      this.text_FB_Name.text = this.DM.RoleAttr.Inviter.SocialName.ToString();
      this.text_FB_Name.SetAllDirty();
      this.text_FB_Name.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.ProFileStr = DataManager.FBMissionDataManager.FBFriends[(int) idx].Name;
      GameConstants.FormatRoleName(this.NameStr, this.ProFileStr, DataManager.FBMissionDataManager.FBFriends[(int) idx].AllianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      this.text_FB_Name.text = DataManager.FBMissionDataManager.FBFriends[(int) idx].SocialName.ToString();
      this.text_FB_Name.SetAllDirty();
      this.text_FB_Name.cachedTextGenerator.Invalidate();
    }
    this.text_FB_Tag.fontSize = 16;
    this.text_FB_Tag.text = this.NameStr.ToString();
    this.text_FB_Tag.SetAllDirty();
    this.text_FB_Tag.cachedTextGenerator.Invalidate();
    this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
    float preferredWidth = this.text_FB_Tag.preferredWidth;
    if ((double) preferredWidth > 160.0)
    {
      for (int index = 1; index <= 2; ++index)
      {
        this.text_FB_Tag.fontSize = 16 - index;
        ((Graphic) this.text_FB_Tag).SetLayoutDirty();
        this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
        preferredWidth = this.text_FB_Tag.preferredWidth;
        if ((double) preferredWidth <= 160.0)
          break;
      }
      for (; (double) preferredWidth > 160.0; preferredWidth = this.text_FB_Tag.preferredWidth)
      {
        this.NameStr.Substring(this.NameStr.ToString(), 0, this.NameStr.Length - 2);
        this.text_FB_Tag.text = this.NameStr.ToString();
        ((Graphic) this.text_FB_Tag).SetLayoutDirty();
        this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
      }
      this.NameStr.Append("...");
      this.text_FB_Tag.text = this.NameStr.ToString();
      this.text_FB_Tag.SetAllDirty();
      this.text_FB_Tag.cachedTextGenerator.Invalidate();
      this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
      preferredWidth = this.text_FB_Tag.preferredWidth;
    }
    ((Graphic) this.text_FB_Tag).rectTransform.sizeDelta = new Vector2(preferredWidth, ((Graphic) this.text_FB_Tag).rectTransform.sizeDelta.y);
    ((Graphic) this.ImgFB_Tag_Line).rectTransform.sizeDelta = new Vector2(preferredWidth, ((Graphic) this.ImgFB_Tag_Line).rectTransform.sizeDelta.y);
    (((Component) this.btn_FB_Tag).transform as RectTransform).sizeDelta = new Vector2(160f, 48f);
  }

  private void Update()
  {
    if (this.bCloseExit)
    {
      if (!(bool) (Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else
    {
      if (!this.bOpenEnd)
        return;
      for (int index1 = 0; index1 < this.mMissionHead.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.mMissionHead[index1].Runner.Length; ++index2)
        {
          if (this.mMissionHead[index1].Runner[index2] != null)
            this.mMissionHead[index1].Runner[index2].Update();
        }
      }
      if (!this.bFinish && (double) this.fPrize > 0.0 && (double) (this.fPrize -= Time.deltaTime) <= 0.0)
      {
        AudioManager.Instance.PlayMP3SFX((ushort) 41011);
        this.bFinish = true;
      }
      if ((double) this.fFinish > 0.0 && (double) (this.fFinish -= Time.deltaTime) <= 0.0)
      {
        AudioManager.Instance.PlayMP3SFX((ushort) 41011);
        this.fFinish = 0.0f;
      }
      if ((double) (this.fTime -= Time.deltaTime) <= 0.0)
      {
        this.bUpdates = true;
        this.fTime = 10f;
      }
      if ((double) this.fHide > 0.0 && (double) (this.fHide -= Time.deltaTime) <= 0.0)
      {
        AudioManager.Instance.PlayUISFX(UIKind.FBHide);
        this.fHide = 0.0f;
      }
      if ((double) this.fFirst > 0.0 && (double) (this.fFirst -= Time.deltaTime) <= 0.0)
      {
        AudioManager.Instance.PlayUISFX(UIKind.FBShow);
        this.fFirst = 0.0f;
      }
      if ((double) this.fFinal > 0.0 && (double) (this.fFinal -= Time.deltaTime) <= 0.0)
      {
        ((Component) this.Img_MissionFinalHeadBG).gameObject.SetActive(true);
        this.fFinal = 0.0f;
      }
      if (!this.bRefresh)
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUESP_SOCIAL_REFRESH;
      messagePacket.AddSeqId();
      messagePacket.Send();
      this.bRefresh = this.bUpdates = false;
    }
  }
}
