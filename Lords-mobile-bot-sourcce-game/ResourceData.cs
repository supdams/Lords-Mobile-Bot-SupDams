// Decompiled with JetBrains decompiler
// Type: ResourceData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public class ResourceData
{
  private const double UpdateTimer = 1.0;
  public double CurrentStock;
  public uint Capacity;
  private long Speed;
  private double SpeedInSec;
  private double UpdateTime;
  private ResourceType Type;

  public ResourceData(ResourceType Type) => this.Type = Type;

  public uint Stock
  {
    get => (uint) this.CurrentStock;
    set
    {
      this.CurrentStock = (double) value;
      GUIManager.Instance.BuildingData.UpdateLevelupResource();
    }
  }

  public void SetResource(uint Val, long Speed)
  {
    this.CurrentStock = (double) Val;
    this.Speed = Speed;
    this.SpeedInSec = (double) Speed / 3600.0;
    this.UpdateTime = 1.0;
    GUIManager.Instance.BuildingData.UpdateLevelupResource();
  }

  public byte Update(float delta)
  {
    if (this.Speed == 0L || this.Speed > 0L && this.CurrentStock >= (double) this.Capacity || this.Speed < 0L && this.CurrentStock <= 0.0)
      return 0;
    this.UpdateTime -= (double) delta;
    if (this.UpdateTime <= 0.0)
    {
      int currentStock = (int) this.CurrentStock;
      this.CurrentStock = this.SpeedInSec <= 0.0 ? Math.Max(this.CurrentStock + this.SpeedInSec, 0.0) : Math.Min(this.CurrentStock + this.SpeedInSec, (double) this.Capacity);
      ++this.UpdateTime;
      if (Math.Abs((int) this.CurrentStock - currentStock) > 0)
        return 1;
    }
    return 0;
  }

  public void UpdateCapacity()
  {
    GATTR_ENUM Type1 = GATTR_ENUM.EGA_FOOD_CAPACITY;
    GATTR_ENUM Type2 = GATTR_ENUM.EGE_FOOD_CAPACITY_PERCENT;
    this.Capacity = 15000U;
    switch (this.Type)
    {
      case ResourceType.Grain:
        Type1 = GATTR_ENUM.EGA_FOOD_CAPACITY;
        Type2 = GATTR_ENUM.EGE_FOOD_CAPACITY_PERCENT;
        break;
      case ResourceType.Rock:
        Type1 = GATTR_ENUM.EGA_ROCK_CAPACITY;
        Type2 = GATTR_ENUM.EGE_ROCK_CAPACITY_PERCENT;
        break;
      case ResourceType.Wood:
        Type1 = GATTR_ENUM.EGA_WOOD_CAPACITY;
        Type2 = GATTR_ENUM.EGE_WOOD_CAPACITY_PERCENT;
        break;
      case ResourceType.Steel:
        Type1 = GATTR_ENUM.EGA_STEEL_CAPACITY;
        Type2 = GATTR_ENUM.EGE_STEEL_CAPACITY_PERCENT;
        break;
      case ResourceType.Money:
        Type1 = GATTR_ENUM.EGA_MONEY_CAPACITY;
        Type2 = GATTR_ENUM.EGE_MONEY_CAPACITY_PERCENT;
        break;
    }
    this.Capacity += DataManager.Instance.AttribVal.GetEffectBaseVal(Type1);
    this.Capacity += (uint) ((ulong) this.Capacity * (ulong) DataManager.Instance.AttribVal.GetEffectBaseVal(Type2) / 10000UL);
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
  }

  public long GetSpeed() => this.Speed;
}
