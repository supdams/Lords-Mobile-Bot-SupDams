// Decompiled with JetBrains decompiler
// Type: PetIdleComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class PetIdleComparer : IComparer<byte>
{
  public int MyCompare(int value1, int value2)
  {
    if (value1 > value2)
      return -1;
    return value1 < value2 ? 1 : 0;
  }

  public int Compare(byte x, byte y)
  {
    PetData petData1 = PetManager.Instance.GetPetData((int) x);
    PetData petData2 = PetManager.Instance.GetPetData((int) y);
    if (petData1 == null || petData2 == null)
      return 0;
    int num;
    if (!petData1.IsFullSkillLevel() && !petData2.IsFullSkillLevel())
    {
      num = (int) petData1.Enhance != (int) petData2.Enhance ? this.MyCompare((int) petData1.Enhance, (int) petData2.Enhance) : ((int) petData1.Level != (int) petData2.Level ? this.MyCompare((int) petData1.Level, (int) petData2.Level) : ((int) petData1.Rare != (int) petData2.Rare ? this.MyCompare((int) petData1.Rare, (int) petData2.Rare) : this.MyCompare((int) petData1.ID, (int) petData2.ID)));
    }
    else
    {
      if (!petData1.IsFullSkillLevel() && petData2.IsFullSkillLevel())
        return -1;
      if (petData1.IsFullSkillLevel() && !petData2.IsFullSkillLevel())
        return 1;
      num = this.MyCompare((int) petData1.ID, (int) petData2.ID);
    }
    return num;
  }
}
