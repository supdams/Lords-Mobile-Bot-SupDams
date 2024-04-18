// Decompiled with JetBrains decompiler
// Type: NWComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class NWComparer : IComparer<byte>
{
  public int Compare(byte x, byte y)
  {
    ActivityManager instance = ActivityManager.Instance;
    NobilityGroupDataType nobilityGroupDataType1 = instance.NobilityActivityData.NobilityGroupData[(int) x];
    NobilityGroupDataType nobilityGroupDataType2 = instance.NobilityActivityData.NobilityGroupData[(int) y];
    if (nobilityGroupDataType1.EventState != EActivityState.EAS_ReplayRanking && nobilityGroupDataType2.EventState == EActivityState.EAS_ReplayRanking)
      return -1;
    if (nobilityGroupDataType1.EventState == EActivityState.EAS_ReplayRanking && nobilityGroupDataType2.EventState != EActivityState.EAS_ReplayRanking)
      return 1;
    if (nobilityGroupDataType1.EventBeginTime < nobilityGroupDataType2.EventBeginTime)
      return -1;
    return nobilityGroupDataType1.EventBeginTime > nobilityGroupDataType2.EventBeginTime ? 1 : 0;
  }
}
