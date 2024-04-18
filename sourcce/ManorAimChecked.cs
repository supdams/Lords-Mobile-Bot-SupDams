// Decompiled with JetBrains decompiler
// Type: ManorAimChecked
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class ManorAimChecked : _ManorAimTypeMission
{
  protected ManorCheck[] ManorBuildData;
  protected ushort KeyBegin = 1;

  protected void Init()
  {
    for (int index = 0; index < this.ManorBuildData.Length; ++index)
    {
      this.ManorBuildData[index].LvCondi = new List<ushort>();
      this.ManorBuildData[index].Priority = new List<ushort>();
    }
  }

  public override void AddData(ushort Priority, ushort Key, ushort Val)
  {
    if ((int) Key < (int) this.KeyBegin || this.ManorBuildData.Length <= (int) Key - (int) this.KeyBegin)
    {
      this.AddDataFail(Priority);
    }
    else
    {
      Key -= this.KeyBegin;
      if (this.ManorBuildData[(int) Key].LvCondi.Count == 0)
      {
        this.ManorBuildData[(int) Key].LvCondi.Add(Val);
        this.ManorBuildData[(int) Key].Priority.Add(Priority);
      }
      else
      {
        List<ushort> lvCondi = this.ManorBuildData[(int) Key].LvCondi;
        List<ushort> priority = this.ManorBuildData[(int) Key].Priority;
        int num1 = lvCondi.BinarySearch(Val);
        lvCondi.Insert(~num1, Val);
        int num2 = priority.BinarySearch(Priority);
        priority.Insert(~num2, Priority);
      }
    }
  }

  public override void AddDataFail(ushort Priority)
  {
  }

  public override void SetCompleteWhileLogin()
  {
  }

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    Key -= this.KeyBegin;
    if (this.ManorBuildData[(int) Key].CondiVal == (int) Val)
      return false;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    int index = this.ManorBuildData[(int) Key].CheckIndex;
    if (this.ManorBuildData[(int) Key].CondiVal < (int) Val)
    {
      for (; index < this.ManorBuildData[(int) Key].LvCondi.Count && (int) this.ManorBuildData[(int) Key].LvCondi[index] <= (int) Val; ++index)
        missionDataManager.AddRewardMission(this.ManorBuildData[(int) Key].Priority[index]);
    }
    else if (this.ManorBuildData[(int) Key].CondiVal > (int) Val)
    {
      if (index <= this.ManorBuildData[(int) Key].LvCondi.Count)
        index = this.ManorBuildData[(int) Key].LvCondi.Count - 1;
      while (index > 0 && (int) this.ManorBuildData[(int) Key].LvCondi[index] >= (int) Val)
        --index;
      if (index < 0)
        index = 0;
    }
    this.ManorBuildData[(int) Key].CondiVal = (int) Val;
    this.ManorBuildData[(int) Key].CheckIndex = index;
    return true;
  }

  public override void UpdateCheckIndex(ushort Key, ushort Val)
  {
    this.ManorBuildData[(int) Key - (int) this.KeyBegin].CondiVal = 0;
    this.ManorBuildData[(int) Key - (int) this.KeyBegin].CheckIndex = 0;
    this.CheckValueChanged(Key, Val);
  }

  public override void Reset()
  {
    for (int index = 0; index < this.ManorBuildData.Length; ++index)
      this.ManorBuildData[index].Reset();
  }

  public override void ClearAll()
  {
    for (int index = 0; index < this.ManorBuildData.Length; ++index)
    {
      this.ManorBuildData[index].Reset();
      this.ManorBuildData[index].LvCondi.Clear();
      this.ManorBuildData[index].Priority.Clear();
    }
  }
}
