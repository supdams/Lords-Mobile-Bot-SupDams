// Decompiled with JetBrains decompiler
// Type: FBFriendHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FBFriendHint : IUIButtonClickHandler
{
  public GameObject gameobject;
  private _UIFBSelf UISelf;
  private _UIFBFriends UIFriends;
  public float Height;
  public float Width;
  public byte FriendCount;
  public byte Progress;

  public FBFriendHint(Transform transform, Font font, Transform blockTrans)
  {
    this.gameobject = transform.gameObject;
    this.UISelf = new _UIFBSelf(transform.GetChild(0), font);
    this.UIFriends = new _UIFBFriends(transform.GetChild(1), font, (IUIButtonClickHandler) this, blockTrans);
  }

  void IUIButtonClickHandler.OnButtonClick(UIButton sender)
  {
    Debug.Log((object) nameof (IUIButtonClickHandler\u002EOnButtonClick));
    SocialFriend friend;
    DataManager.FBMissionDataManager.GetFriendSocialInfo((byte) sender.m_BtnID1, sender.m_BtnID2, out friend);
    if (friend == null)
      return;
    DataManager.Instance.ShowLordProfile(friend.Name.ToString());
  }

  public void Show(ushort ID)
  {
    this.gameobject.SetActive(true);
    this.Progress = (byte) ID;
    this.FriendCount = DataManager.FBMissionDataManager.GetFriendCountByProgress(this.Progress);
    Debug.Log((object) ("count = " + (object) this.FriendCount));
    if (this.FriendCount > (byte) 0)
    {
      if (!DataManager.FBMissionDataManager.IsInTime() || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == (byte) 12 || (int) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex != (int) this.Progress)
      {
        this.UISelf.Hide();
        this.UIFriends.Show(this.Progress, this.FriendCount);
        this.UIFriends.Top = 0.0f;
        this.Height = this.UIFriends.Height;
        this.Width = this.UIFriends.Width;
      }
      else
      {
        this.UISelf.Top = -15f;
        this.UISelf.Height = 79f;
        this.UISelf.Show(_UIFBSelf._Style.Wide);
        this.UIFriends.Show(this.Progress, this.FriendCount);
        this.UIFriends.Top = -79f;
        this.Height = this.UIFriends.Height + 79f;
        this.Width = this.UIFriends.Width;
      }
    }
    else if ((int) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex != (int) this.Progress)
    {
      this.UISelf.Hide();
      this.UIFriends.Hide();
      this.Height = -1f;
    }
    else
    {
      this.UISelf.Top = 0.0f;
      this.UISelf.Height = 100f;
      this.UISelf.Show(_UIFBSelf._Style.Narrow);
      this.UIFriends.Hide();
      this.Height = this.UISelf.Height;
      this.Width = this.UISelf.Width;
    }
  }

  private void SetStyle(FBFriendHint._Style style)
  {
    if (style != FBFriendHint._Style.Own)
      return;
    this.Height = this.UISelf.Height;
  }

  public void Hide() => this.gameobject.SetActive(false);

  public void TextRefresh()
  {
    this.UISelf.TextRefresh();
    this.UIFriends.TextRefresh();
  }

  public void Destroy() => this.UIFriends.Destroy();

  public void UpdateData()
  {
    if (!this.gameobject.activeSelf)
      return;
    byte friendCountByProgress = DataManager.FBMissionDataManager.GetFriendCountByProgress(this.Progress);
    if (DataManager.FBMissionDataManager.UpdateFriendSerialNo == byte.MaxValue || (int) this.FriendCount != (int) friendCountByProgress)
    {
      this.Show((ushort) this.Progress);
      if (friendCountByProgress == (byte) 0 && (int) DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == (int) this.Progress && !DataManager.FBMissionDataManager.IsInTime())
      {
        this.Hide();
        this.Height = -1f;
      }
      DataManager.FBMissionDataManager.UpdateFriendSerialNo = byte.MaxValue;
    }
    else
      this.UIFriends.UpdateData();
  }

  public void UpdateTime() => this.UIFriends.UpdateTime();

  private enum UIControl
  {
    Self,
    Friends,
  }

  private enum _Style
  {
    Own,
    Friend,
    Both,
  }
}
