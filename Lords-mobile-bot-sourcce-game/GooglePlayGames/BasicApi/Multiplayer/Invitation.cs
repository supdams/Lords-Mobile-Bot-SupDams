// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Multiplayer.Invitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace GooglePlayGames.BasicApi.Multiplayer
{
  public class Invitation
  {
    private Invitation.InvType mInvitationType;
    private string mInvitationId;
    private Participant mInviter;
    private int mVariant;

    internal Invitation(
      Invitation.InvType invType,
      string invId,
      Participant inviter,
      int variant)
    {
      this.mInvitationType = invType;
      this.mInvitationId = invId;
      this.mInviter = inviter;
      this.mVariant = variant;
    }

    public Invitation.InvType InvitationType => this.mInvitationType;

    public string InvitationId => this.mInvitationId;

    public Participant Inviter => this.mInviter;

    public int Variant => this.mVariant;

    public override string ToString()
    {
      return string.Format("[Invitation: InvitationType={0}, InvitationId={1}, Inviter={2}, Variant={3}]", (object) this.InvitationType, (object) this.InvitationId, (object) this.Inviter, (object) this.Variant);
    }

    public enum InvType
    {
      RealTime,
      TurnBased,
      Unknown,
    }
  }
}
