// Decompiled with JetBrains decompiler
// Type: _TroopStatistic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public struct _TroopStatistic
{
  private uint[][] TroopData;
  private byte bUpdate;

  public _TroopStatistic(byte bInit = 1)
  {
    this.TroopData = new uint[4][];
    for (int index = 0; index < this.TroopData.Length; ++index)
      this.TroopData[index] = new uint[4];
    this.bUpdate = (byte) 1;
  }

  public uint[][] GetTroop()
  {
    if (this.bUpdate == (byte) 1)
    {
      this.Clear();
      DataManager instance = DataManager.Instance;
      int count = instance.WarTroop.Count;
      for (int index1 = 0; index1 < count; ++index1)
      {
        for (int index2 = 0; index2 < 16; ++index2)
          this.TroopData[index2 >> 2][index2 & 3] += instance.WarTroop[index1].TroopData[index2 >> 2][index2 & 3];
      }
      this.bUpdate = (byte) 0;
    }
    return this.TroopData;
  }

  public void UpdateTroop() => this.bUpdate = (byte) 1;

  public void Clear()
  {
    for (int index = 0; index < this.TroopData.Length; ++index)
      Array.Clear((Array) this.TroopData[index], 0, this.TroopData[index].Length);
  }
}
