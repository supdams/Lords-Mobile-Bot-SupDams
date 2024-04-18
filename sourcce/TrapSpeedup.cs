// Decompiled with JetBrains decompiler
// Type: TrapSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class TrapSpeedup : SpeedupBase
{
  public TrapSpeedup(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(297U);
    this.CompleteImmContStr = mStringTable.GetStringByID(210U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(221U);
    this.bFreeSpeedup = false;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.ConstructTrap;
    this.FilterType = (byte) 1;
  }

  public override void SendImmediate() => DataManager.Instance.SendFinishTrapConstrct();

  public override void SendImmediateFree()
  {
  }
}
