// Decompiled with JetBrains decompiler
// Type: _TechKindComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class _TechKindComparer : IComparer<byte>
{
  public int Compare(byte x, byte y)
  {
    DataManager instance = DataManager.Instance;
    TechKindTbl recordByIndex1 = instance.TechKindData.GetRecordByIndex((int) x);
    TechKindTbl recordByIndex2 = instance.TechKindData.GetRecordByIndex((int) y);
    if ((int) recordByIndex1.Priority < (int) recordByIndex2.Priority)
      return -1;
    return (int) recordByIndex1.Priority > (int) recordByIndex2.Priority ? 1 : 0;
  }
}
