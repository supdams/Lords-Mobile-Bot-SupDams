// Decompiled with JetBrains decompiler
// Type: BuildDataComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class BuildDataComparer : IComparer<ushort>
{
  public int Compare(ushort x, ushort y)
  {
    RoleBuildingData[] allBuildsData = GUIManager.Instance.BuildingData.AllBuildsData;
    if (allBuildsData[(int) x].Level > (byte) 0 && allBuildsData[(int) y].Level == (byte) 0)
      return -1;
    if (allBuildsData[(int) x].Level == (byte) 0 && allBuildsData[(int) y].Level > (byte) 0)
      return 1;
    if (allBuildsData[(int) x].Level == (byte) 0 && allBuildsData[(int) y].Level == (byte) 0)
      return 0;
    if ((int) allBuildsData[(int) x].BuildID > (int) allBuildsData[(int) y].BuildID)
      return -1;
    if ((int) allBuildsData[(int) x].BuildID < (int) allBuildsData[(int) y].BuildID)
      return 1;
    if ((int) allBuildsData[(int) x].Level > (int) allBuildsData[(int) y].Level)
      return -1;
    return (int) allBuildsData[(int) x].Level < (int) allBuildsData[(int) y].Level ? 1 : 0;
  }
}
