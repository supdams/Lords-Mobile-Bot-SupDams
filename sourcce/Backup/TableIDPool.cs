// Decompiled with JetBrains decompiler
// Type: TableIDPool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public sealed class TableIDPool
{
  private bool grewUp;
  private int maxIDTableCount;
  private int nowIDTableCounter;
  private List<int> _tableIDPoolPools;

  public TableIDPool(int MaxIDTableCount, bool bGrewUp = false)
  {
    this.grewUp = bGrewUp;
    this.nowIDTableCounter = 0;
    this.maxIDTableCount = MaxIDTableCount;
    this._tableIDPoolPools = new List<int>(this.maxIDTableCount);
  }

  ~TableIDPool()
  {
    if (this._tableIDPoolPools == null)
      return;
    this._tableIDPoolPools.Clear();
    this._tableIDPoolPools = (List<int>) null;
  }

  public int spawn()
  {
    int num;
    if (this._tableIDPoolPools.Count > 0)
    {
      num = this._tableIDPoolPools[this._tableIDPoolPools.Count - 1];
      this._tableIDPoolPools.RemoveAt(this._tableIDPoolPools.Count - 1);
    }
    else if (this.nowIDTableCounter < this.maxIDTableCount)
      num = this.nowIDTableCounter++;
    else if (this.grewUp)
    {
      this.maxIDTableCount *= 2;
      num = this.nowIDTableCounter++;
    }
    else
      num = this.maxIDTableCount;
    return num;
  }

  public void despawn(int t) => this._tableIDPoolPools.Add(t);

  public void init()
  {
    this.nowIDTableCounter = 0;
    this._tableIDPoolPools.Clear();
  }
}
