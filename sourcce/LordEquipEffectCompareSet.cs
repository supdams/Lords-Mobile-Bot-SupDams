// Decompiled with JetBrains decompiler
// Type: LordEquipEffectCompareSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class LordEquipEffectCompareSet
{
  public ushort EffectID;
  public int EffectValue;
  public bool isEven;
  public byte group;
  public bool isTitel;

  public LordEquipEffectCompareSet(
    ushort EffectID,
    int EffectValue,
    bool isEven,
    byte group = 0,
    bool isTitel = false)
  {
    this.EffectID = EffectID;
    this.EffectValue = EffectValue;
    this.isEven = isEven;
    this.group = group;
    this.isTitel = isTitel;
  }

  public LordEquipEffectCompareSet(LordEquipEffectSet set)
  {
    this.EffectID = set.EffectID;
    this.EffectValue = (int) set.EffectValue;
    this.isEven = true;
  }
}
