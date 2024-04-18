// Decompiled with JetBrains decompiler
// Type: PetDataComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class PetDataComparer : IComparer<byte>
{
  public int Compare(byte x, byte y)
  {
    PetData petData1 = PetManager.Instance.GetPetData((int) x);
    PetData petData2 = PetManager.Instance.GetPetData((int) y);
    if (petData1 != null && petData2 == null)
      return -1;
    if (petData1 == null && petData2 != null)
      return 1;
    if (petData1 == null && petData2 == null)
      return 0;
    if ((int) petData1.Enhance > (int) petData2.Enhance)
      return -1;
    if ((int) petData1.Enhance < (int) petData2.Enhance)
      return 1;
    if ((int) petData1.Level > (int) petData2.Level)
      return -1;
    if ((int) petData1.Level < (int) petData2.Level)
      return 1;
    if ((int) petData1.Rare > (int) petData2.Rare)
      return -1;
    if ((int) petData1.Rare < (int) petData2.Rare)
      return 1;
    if ((int) petData1.ID > (int) petData2.ID)
      return -1;
    return (int) petData1.ID < (int) petData2.ID ? 1 : 0;
  }
}
