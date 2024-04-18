// Decompiled with JetBrains decompiler
// Type: SocialManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal class SocialManager
{
  private const byte MAX_SOCIAL_FRIEND = 100;
  private const int SOCIAL_BINDING_KEY_LEN = 255;
  public byte MaxConcurrentFriend;
  public byte FriendRecommended;
  public string ShareAddress = "http://download-lo-tw.igg.com/android/?";
  public SocialType Kind;
  public byte InviterLen;
  public long InviterIGGId;
  public ushort InviterHead;
  public string InviterName;
  public string BindingName = string.Empty;
  public string BindingKey;
  public BondType BindingType;
  public CString InviterTag;
  public CString SocialName;
  private static SocialManager SM;

  private SocialManager()
  {
    this.SocialName = new CString(42);
    this.InviterTag = new CString(4);
  }

  public bool CanInvite => ((int) DataManager.Instance.RoleAttr.Invitation & 1) > 0;

  public static SocialManager Instance
  {
    get
    {
      if (SocialManager.SM == null)
        SocialManager.SM = new SocialManager();
      return SocialManager.SM;
    }
  }

  public bool CheckBonding(bool CheckFlag = true)
  {
    return (!CheckFlag ? 1 : (!DataManager.Instance.CheckPrizeFlag((byte) 30) ? 1 : 0)) != 0 && IGGGameSDK.Instance.m_IGGLoginType == IGGLoginType.GUEST && !IGGGameSDK.Instance.bBindingGoogle;
  }

  public bool CheckFBMission() => this.CheckShowPrize() || this.CheckShowMission();

  public bool CheckSocialBind()
  {
    if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && DataManager.FBMissionDataManager.GetRewardIndex() == (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
      return true;
    return DataManager.Instance.RoleAttr.Inviter.Invited > (byte) 0 && !DataManager.Instance.CheckPrizeFlag((byte) 30);
  }

  public bool CheckShowPrizeCount()
  {
    if (DataManager.FBMissionDataManager.GetRewardCount() <= (ushort) 0)
      return false;
    return DataManager.Instance.RoleAttr.Inviter.Invited == (byte) 0 || DataManager.Instance.CheckPrizeFlag((byte) 30);
  }

  public bool CheckShowPrize()
  {
    if (DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0)
      return true;
    return GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 2 && DataManager.Instance.RoleAttr.Inviter.Invited > (byte) 0 && !DataManager.Instance.CheckPrizeFlag((byte) 30) && !DataManager.Instance.CheckPrizeFlag((byte) 27) && !DataManager.Instance.CheckPrizeFlag((byte) 29);
  }

  public bool CheckShowMission()
  {
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 4)
      return false;
    return DataManager.FBMissionDataManager.IsInTime() || !DataManager.Instance.CheckPrizeFlag((byte) 27) || !DataManager.Instance.CheckPrizeFlag((byte) 29);
  }

  public bool CanShowInvite()
  {
    return GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 7 && DataManager.Instance.RoleAttr.Invitation > (byte) 0;
  }

  public byte GetFriendNumber() => DataManager.FBMissionDataManager.CurrentFriendNum;

  public byte GetRecommandNumber()
  {
    return this.FriendRecommended > (byte) 10 ? (byte) 10 : this.FriendRecommended;
  }

  public void Recv_RESP_BINDING_PLATFORM(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Mission);
    if (MP.ReadByte() > (byte) 0)
      return;
    DataManager.Instance.RoleAttr.PrizeFlag |= 1073741824U;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0);
  }

  public bool PostShare(SocialType Kind)
  {
    if (!this.CanShowInvite() || this.ShareAddress == null)
      return false;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.Append(this.ShareAddress);
    cstring.IntToFormat(DataManager.Instance.RoleAttr.UserId);
    cstring.IntToFormat((long) Kind);
    cstring.AppendFormat("{0}id={1}&kind={2}");
    return true;
  }

  public void BindingPlatform(byte Type, string Name, string Key)
  {
    GUIManager.Instance.ShowUILock(EUILock.Mission);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BINDING_PLATFORM;
    messagePacket.AddSeqId();
    messagePacket.Add(Type);
    messagePacket.Add(Name, 41);
    messagePacket.Add(Key, (int) byte.MaxValue);
    messagePacket.Send();
  }

  public void BindingPlatform(bool ShowMsg = true)
  {
    if (DataManager.Instance.RoleAttr.Inviter.Invited == (byte) 0 || DataManager.Instance.CheckPrizeFlag((byte) 30) || DataManager.Instance.CheckPrizeFlag((byte) 27) || DataManager.Instance.CheckPrizeFlag((byte) 29))
      return;
    GUIManager.Instance.ShowUILock(EUILock.Mission);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BINDING_PLATFORM;
    messagePacket.AddSeqId();
    messagePacket.Add(this.BindingName, 41);
    messagePacket.Send();
  }
}
