// Decompiled with JetBrains decompiler
// Type: FixTrapSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class FixTrapSpeedup : SpeedupBase
{
  public FixTrapSpeedup(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(224U);
    this.CompleteImmContStr = mStringTable.GetStringByID(211U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(216U);
    this.bFreeSpeedup = false;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.RepaireTrap;
    this.FilterType = (byte) 1;
  }

  public override void SendImmediate() => DataManager.Instance.SendFinishPairTrap();

  public override void SendImmediateFree()
  {
  }
}
