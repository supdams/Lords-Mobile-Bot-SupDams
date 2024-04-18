// Decompiled with JetBrains decompiler
// Type: HeroLeavePrison
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class HeroLeavePrison : SpeedupBase
{
  public HeroLeavePrison(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(298U);
    this.CompleteImmContStr = mStringTable.GetStringByID(212U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(222U);
    this.bFreeSpeedup = false;
    this.bImmediate = false;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = (_UseItemTarget) DataManager.Instance.MarchEventData.Length;
    this.FilterType = (byte) 11;
  }

  public override void SendImmediate()
  {
  }

  public override void SendImmediateFree()
  {
  }
}
