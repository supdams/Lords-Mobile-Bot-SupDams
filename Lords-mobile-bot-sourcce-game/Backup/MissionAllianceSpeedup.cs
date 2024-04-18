// Decompiled with JetBrains decompiler
// Type: MissionAllianceSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MissionAllianceSpeedup : SpeedupBase
{
  public MissionAllianceSpeedup(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(293U);
    this.CompleteImmContStr = mStringTable.GetStringByID(206U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(218U);
    this.bFreeSpeedup = false;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.AllianceMission;
    this.FilterType = (byte) 1;
  }

  public override void SendImmediate()
  {
    if (DataManager.MissionDataManager.TimerMissionData[1].ProcessIdx == byte.MaxValue || !GUIManager.Instance.ShowUILock(EUILock.Mission))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_BOOST;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) 2);
    messagePacket.Add((byte) ((uint) DataManager.MissionDataManager.TimerMissionData[1].ProcessIdx + 1U));
    messagePacket.Send();
  }

  public override void SendImmediateFree()
  {
  }
}
