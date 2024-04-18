// Decompiled with JetBrains decompiler
// Type: ManorCheck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public struct ManorCheck
{
  public List<ushort> Priority;
  public List<ushort> LvCondi;
  public int CheckIndex;
  public int CondiVal;
  public int CondPriority;

  public void Reset()
  {
    this.CheckIndex = 0;
    this.CondiVal = 0;
    this.CondPriority = 0;
  }
}
