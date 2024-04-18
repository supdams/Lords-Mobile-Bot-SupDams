// Decompiled with JetBrains decompiler
// Type: ItemBuffComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class ItemBuffComparer : IComparer<byte>
{
  public int Compare(byte x, byte y)
  {
    ItemBuff recordByIndex1 = DataManager.Instance.ItemBuffTable.GetRecordByIndex((int) x);
    ItemBuff recordByIndex2 = DataManager.Instance.ItemBuffTable.GetRecordByIndex((int) y);
    return (int) recordByIndex2.BuffKind != (int) recordByIndex1.BuffKind && (recordByIndex2.BuffKind == (byte) 1 || recordByIndex2.BuffKind == (byte) 3 && recordByIndex1.BuffKind != (byte) 1 || recordByIndex2.BuffKind == (byte) 4 && recordByIndex1.BuffKind != (byte) 1 && recordByIndex1.BuffKind != (byte) 3) ? 1 : -1;
  }
}
