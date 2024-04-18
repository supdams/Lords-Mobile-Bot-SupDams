// Decompiled with JetBrains decompiler
// Type: HeroStarupSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class HeroStarupSpeedup : SpeedupBase
{
  public HeroStarupSpeedup(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(226U);
    this.CompleteImmContStr = mStringTable.GetStringByID(213U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(223U);
    this.bFreeSpeedup = true;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.HeroStarup;
    this.FilterType = (byte) 1;
  }

  public override void SendImmediate() => DataManager.Instance.SendHeroStarUp_Instant();

  public override void SendImmediateFree() => DataManager.Instance.SendHeroStarUp_Free();
}
