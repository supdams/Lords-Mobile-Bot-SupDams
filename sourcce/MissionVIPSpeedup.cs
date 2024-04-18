// Decompiled with JetBrains decompiler
// Type: MissionVIPSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MissionVIPSpeedup : SpeedupBase
{
  public MissionVIPSpeedup(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(294U);
    this.CompleteImmContStr = mStringTable.GetStringByID(207U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(218U);
    this.bFreeSpeedup = false;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.VIPMission;
    this.FilterType = (byte) 1;
  }

  public override void SendImmediate() => DataManager.MissionDataManager.sendVipMissionImmed();

  public override void SendImmediateFree()
  {
  }
}
