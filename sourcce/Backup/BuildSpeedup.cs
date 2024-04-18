// Decompiled with JetBrains decompiler
// Type: BuildSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class BuildSpeedup : SpeedupBase
{
  public BuildSpeedup(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(288U);
    if (GUIManager.Instance.BuildingData.QueueBuildType == (byte) 1)
    {
      this.CompleteImmBntStr = mStringTable.GetStringByID(214U);
      this.bFreeSpeedup = true;
    }
    else
    {
      this.CompleteImmBntStr = mStringTable.GetStringByID(218U);
      this.bFreeSpeedup = false;
    }
    this.CompleteImmContStr = mStringTable.GetStringByID(201U);
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.Building;
    this.FilterType = (byte) 1;
    this.FilterType2 = byte.MaxValue;
  }

  public override void SendImmediate()
  {
    if (GUIManager.Instance.BuildingData.QueueBuildType == (byte) 1)
      GUIManager.Instance.BuildingData.sendBuildFinish();
    else
      GUIManager.Instance.BuildingData.sendBuildDismantleFinish();
  }

  public override void SendImmediateFree()
  {
    GUIManager.Instance.BuildingData.sendBuildCompleteFree();
  }
}
