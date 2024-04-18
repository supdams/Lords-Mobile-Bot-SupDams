// Decompiled with JetBrains decompiler
// Type: ForgingSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class ForgingSpeedup : SpeedupBase
{
  public ForgingSpeedup(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(7501U);
    this.CompleteImmContStr = mStringTable.GetStringByID(7503U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(7502U);
    this.bFreeSpeedup = false;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.SunLordequip;
    this.FilterType = (byte) 1;
  }

  public override void SendImmediate() => LordEquipData.QuickCombineinForge();

  public override void SendImmediateFree()
  {
  }
}
