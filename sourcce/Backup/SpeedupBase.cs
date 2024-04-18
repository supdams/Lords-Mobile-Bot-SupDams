// Decompiled with JetBrains decompiler
// Type: SpeedupBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public abstract class SpeedupBase
{
  public string MainTitleStr;
  public string CompleteImmContStr;
  public string CompleteImmBntStr;
  public bool bFreeSpeedup;
  public bool bImmediate;
  public byte QueueBar;
  public byte Rally;
  public byte FilterType;
  public byte SkipFilterTime;
  public byte FilterType2;
  public _UseItemTarget UseTarget;
  protected List<ushort> CustomList;

  public virtual long StartTime => 0;

  public virtual uint TotalTime => 0;

  public virtual CString Name => (CString) null;

  public abstract void SendImmediate();

  public abstract void SendImmediateFree();

  public virtual void CustomSort(List<ushort> Data, int BagCount)
  {
  }
}
