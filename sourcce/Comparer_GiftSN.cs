// Decompiled with JetBrains decompiler
// Type: Comparer_GiftSN
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class Comparer_GiftSN : IComparer<AllianceBoxDataType>
{
  public int Compare(AllianceBoxDataType x, AllianceBoxDataType y) => x.SN < y.SN ? -1 : 1;
}
