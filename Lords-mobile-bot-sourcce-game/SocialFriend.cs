// Decompiled with JetBrains decompiler
// Type: SocialFriend
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class SocialFriend : FBMissionManager.FbMissionProgress
{
  public CString SocialName;
  public byte Invited;
  public byte IconNo;
  public byte Result;
  public ushort Head;
  public bool TimeRemain;
  public CString Name;
  public CString AllianceTag;

  public SocialFriend()
  {
    this.SocialName = new CString(42);
    this.Name = new CString(14);
    this.AllianceTag = new CString(4);
  }

  public void Clear()
  {
    this.IconNo = (byte) 0;
    this.Head = (ushort) 0;
    this.SocialName.ClearString();
    this.Name.ClearString();
    this.AllianceTag.ClearString();
    this.NodeIndex = (byte) 0;
    this.bShowHUD = (byte) 0;
    this.MissionTime.BeginTime = 0L;
  }
}
