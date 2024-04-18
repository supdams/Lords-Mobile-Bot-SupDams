// Decompiled with JetBrains decompiler
// Type: HeroConditionComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class HeroConditionComparer : IComparer<uint>
{
  public int Compare(uint x, uint y)
  {
    bool flag1 = false;
    bool flag2 = false;
    LevelEX bycurrentPointId = DataManager.StageDataController.GetLevelEXBycurrentPointID((ushort) 0);
    StageConditionData stageConditionData = DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) != StageMode.Lean ? DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(bycurrentPointId.NodusTwoID) : DataManager.StageDataController.StageConditionDataTable.GetRecordByKey((ushort) ((int) bycurrentPointId.NodusOneID + (int) DataManager.StageDataController.currentNodus - 1));
    for (int index = 0; index < stageConditionData.ConditionArray.Length; ++index)
    {
      if (stageConditionData.ConditionArray[index].ConditionID == (byte) 3)
      {
        if ((int) stageConditionData.ConditionArray[index].FactorA == (int) x)
          flag1 = true;
        if ((int) stageConditionData.ConditionArray[index].FactorA == (int) y)
          flag2 = true;
      }
    }
    int num1;
    if (flag1)
      num1 = !flag2 ? -1 : (x <= y ? 1 : -1);
    else if (flag2)
    {
      num1 = 1;
    }
    else
    {
      byte num2 = 0;
      byte num3 = 0;
      byte num4 = 0;
      for (int index = 0; index < stageConditionData.ConditionArray.Length; ++index)
      {
        if (stageConditionData.ConditionArray[index].ConditionID == (byte) 1)
        {
          if (stageConditionData.ConditionArray[index].FactorA == (ushort) 0 && !ArenaManager.Instance.CheckHeroAstrology((ushort) x, stageConditionData.ConditionArray[index].FactorB) || stageConditionData.ConditionArray[index].FactorA == (ushort) 1 && ArenaManager.Instance.CheckHeroAstrology((ushort) x, stageConditionData.ConditionArray[index].FactorB))
            ++num2;
          if (stageConditionData.ConditionArray[index].FactorA == (ushort) 0 && !ArenaManager.Instance.CheckHeroAstrology((ushort) y, stageConditionData.ConditionArray[index].FactorB) || stageConditionData.ConditionArray[index].FactorA == (ushort) 1 && ArenaManager.Instance.CheckHeroAstrology((ushort) y, stageConditionData.ConditionArray[index].FactorB))
            ++num3;
          ++num4;
        }
      }
      num1 = num4 == (byte) 0 ? (x <= y ? 1 : -1) : ((int) num4 != (int) num2 ? ((int) num4 != (int) num3 ? (x <= y ? 1 : -1) : 1) : ((int) num4 != (int) num3 ? -1 : (x <= y ? 1 : -1)));
    }
    return num1;
  }
}
