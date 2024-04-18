// Decompiled with JetBrains decompiler
// Type: AllianceMemberComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class AllianceMemberComparer : IComparer<AllianceMemberClientDataType>
{
  public int Compare(AllianceMemberClientDataType x, AllianceMemberClientDataType y)
  {
    if (x.Rank > y.Rank)
      return -1;
    return x.Rank == y.Rank ? string.Compare(x.Name, y.Name, true) : 1;
  }
}
