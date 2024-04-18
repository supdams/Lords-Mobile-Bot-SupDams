// Decompiled with JetBrains decompiler
// Type: StageAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class StageAimMission : ManorAimNow
{
  public override void AddData(ushort Priority, ushort Key, ushort Val)
  {
    Val = Key;
    Key = (ushort) 0;
    List<ushort> lvCondi = this.ManorBuildData[(int) Key].LvCondi;
    List<ushort> priority = this.ManorBuildData[(int) Key].Priority;
    int num1 = lvCondi.BinarySearch(Val);
    if (num1 >= 0)
      Debug.Log((object) ("ID = " + (object) num1 + "Priority = " + (object) Priority));
    lvCondi.Insert(~num1, Val);
    int num2 = priority.BinarySearch(Priority);
    priority.Insert(~num2, Priority);
  }
}
