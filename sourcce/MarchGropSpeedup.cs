// Decompiled with JetBrains decompiler
// Type: MarchGropSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MarchGropSpeedup : SpeedupBase
{
  public MapLine mapline;
  private MarchGropSpeedup._MarchType MarchType;

  public MarchGropSpeedup(int parm)
  {
    DataManager instance = DataManager.Instance;
    this.MainTitleStr = instance.mStringTable.GetStringByID(298U);
    this.CompleteImmContStr = string.Empty;
    this.CompleteImmBntStr = string.Empty;
    this.bFreeSpeedup = false;
    this.bImmediate = false;
    this.SkipFilterTime = (byte) 1;
    if (((parm & 1073741824) <= 0 ? 0 : 1) == 1)
    {
      uint num = (uint) (parm & -1073741825);
      parm = (int) instance.GetMarchInxByLineTableID(num);
      if (parm != (int) byte.MaxValue)
        parm += 2;
      else
        this.mapline = DataManager.MapDataController.MapLineTable[(int) num];
    }
    if (parm >= 2 && parm <= 9)
    {
      if (instance.MarchEventData[parm - 2].Type == EMarchEventType.EMET_RallyAttack)
      {
        this.MarchType = MarchGropSpeedup._MarchType.RallyAttack;
        this.UseTarget = (_UseItemTarget) (parm - 2);
        this.QueueBar = (byte) (parm - 2 + 22);
        this.Rally = (byte) 2;
        this.FilterType = (byte) 16;
      }
      else
      {
        this.UseTarget = (_UseItemTarget) (parm - 2);
        this.QueueBar = (byte) parm;
        this.FilterType = (byte) 11;
      }
    }
    else if (parm >= 100 && parm < 200)
    {
      this.MarchType = MarchGropSpeedup._MarchType.Rally;
      this.Rally = (byte) 1;
      this.QueueBar = (byte) (parm - 100);
      this.UseTarget = _UseItemTarget.Rally;
      this.FilterType = (byte) 11;
    }
    else
    {
      this.MarchType = MarchGropSpeedup._MarchType.RallyAttack;
      this.Rally = (byte) 2;
      switch (parm)
      {
        case 200:
          this.QueueBar = (byte) 100;
          break;
        case (int) byte.MaxValue:
          this.QueueBar = byte.MaxValue;
          break;
        default:
          this.QueueBar = (byte) (parm - 201 + instance.queueBarData.Length);
          break;
      }
      this.UseTarget = _UseItemTarget.Rally;
      this.FilterType = (byte) 16;
    }
  }

  public override long StartTime
  {
    get
    {
      DataManager instance = DataManager.Instance;
      switch (this.MarchType)
      {
        case MarchGropSpeedup._MarchType.Normal:
          return instance.queueBarData[(int) this.QueueBar].StartTime;
        case MarchGropSpeedup._MarchType.Rally:
          if ((int) this.QueueBar < instance.WarTroop.Count)
            return instance.WarTroop[(int) this.QueueBar].MarchTime.BeginTime;
          break;
        case MarchGropSpeedup._MarchType.RallyAttack:
          if ((int) this.QueueBar < instance.queueBarData.Length)
            return instance.queueBarData[(int) this.QueueBar].StartTime;
          if (this.mapline != null)
            return (long) this.mapline.begin;
          if (this.QueueBar == (byte) 100)
            return instance.WarlobbyDetail.EventTime.BeginTime;
          if ((int) this.QueueBar - instance.queueBarData.Length < instance.WarHall[0].Count)
            return instance.WarHall[0][(int) this.QueueBar - instance.queueBarData.Length].EventTime.BeginTime;
          break;
      }
      return 0;
    }
  }

  public override uint TotalTime
  {
    get
    {
      DataManager instance = DataManager.Instance;
      switch (this.MarchType)
      {
        case MarchGropSpeedup._MarchType.Normal:
          return instance.queueBarData[(int) this.QueueBar].TotalTime;
        case MarchGropSpeedup._MarchType.Rally:
          if ((int) this.QueueBar < instance.WarTroop.Count)
            return instance.WarTroop[(int) this.QueueBar].MarchTime.RequireTime;
          break;
        case MarchGropSpeedup._MarchType.RallyAttack:
          if ((int) this.QueueBar < instance.queueBarData.Length)
            return instance.queueBarData[(int) this.QueueBar].TotalTime;
          if (this.mapline != null)
            return this.mapline.during;
          if (this.QueueBar == (byte) 100)
            return instance.WarlobbyDetail.EventTime.RequireTime;
          if ((int) this.QueueBar - instance.queueBarData.Length < instance.WarHall[0].Count)
            return instance.WarHall[0][(int) this.QueueBar - instance.queueBarData.Length].EventTime.RequireTime;
          break;
      }
      return 0;
    }
  }

  public override CString Name
  {
    get
    {
      DataManager instance = DataManager.Instance;
      if (this.MarchType == MarchGropSpeedup._MarchType.Rally)
      {
        if ((int) this.QueueBar < instance.WarTroop.Count)
          return instance.WarTroop[(int) this.QueueBar].AllyName;
      }
      else if (this.MarchType == MarchGropSpeedup._MarchType.RallyAttack && (int) this.QueueBar >= instance.queueBarData.Length)
      {
        if (this.mapline != null)
          return this.mapline.playerName;
        if (this.QueueBar == (byte) 100)
          return instance.WarlobbyDetail.AllyName;
        if ((int) this.QueueBar - instance.queueBarData.Length < instance.WarHall[0].Count)
          return instance.WarHall[0][(int) this.QueueBar - instance.queueBarData.Length].AllyName;
      }
      return (CString) null;
    }
  }

  public override void SendImmediate()
  {
  }

  public override void SendImmediateFree()
  {
  }

  private enum _MarchType
  {
    Normal,
    Rally,
    RallyAttack,
  }
}
