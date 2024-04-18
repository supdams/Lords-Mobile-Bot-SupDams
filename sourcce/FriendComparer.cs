// Decompiled with JetBrains decompiler
// Type: FriendComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class FriendComparer : IComparer<byte>
{
  public FBMissionManager.FbMissionProgress[] FriendsProgress;

  public int Compare(byte x, byte y)
  {
    --x;
    --y;
    if ((int) this.FriendsProgress[(int) x].NodeIndex > (int) this.FriendsProgress[(int) y].NodeIndex)
      return 1;
    if ((int) this.FriendsProgress[(int) x].NodeIndex < (int) this.FriendsProgress[(int) y].NodeIndex || this.FriendsProgress[(int) x].MissionTime.BeginTime > 0L && this.FriendsProgress[(int) y].MissionTime.BeginTime == 0L)
      return -1;
    if (this.FriendsProgress[(int) x].MissionTime.BeginTime == 0L && this.FriendsProgress[(int) y].MissionTime.BeginTime > 0L)
      return 1;
    if (this.FriendsProgress[(int) x].MissionTime.BeginTime == 0L && this.FriendsProgress[(int) y].MissionTime.BeginTime == 0L)
    {
      if ((int) this.FriendsProgress[(int) x].UserSerialNo > (int) this.FriendsProgress[(int) y].UserSerialNo)
        return 1;
      if ((int) this.FriendsProgress[(int) x].UserSerialNo < (int) this.FriendsProgress[(int) y].UserSerialNo)
        return -1;
    }
    if (this.FriendsProgress[(int) x].MissionTime.BeginTime + (long) this.FriendsProgress[(int) x].MissionTime.RequireTime > this.FriendsProgress[(int) y].MissionTime.BeginTime + (long) this.FriendsProgress[(int) y].MissionTime.RequireTime)
      return 1;
    if (this.FriendsProgress[(int) x].MissionTime.BeginTime + (long) this.FriendsProgress[(int) x].MissionTime.RequireTime < this.FriendsProgress[(int) y].MissionTime.BeginTime + (long) this.FriendsProgress[(int) y].MissionTime.RequireTime)
      return -1;
    if ((int) this.FriendsProgress[(int) x].UserSerialNo > (int) this.FriendsProgress[(int) y].UserSerialNo)
      return 1;
    return (int) this.FriendsProgress[(int) x].UserSerialNo < (int) this.FriendsProgress[(int) y].UserSerialNo ? -1 : 0;
  }
}
