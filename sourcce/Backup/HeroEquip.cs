// Decompiled with JetBrains decompiler
// Type: HeroEquip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal struct HeroEquip
{
  public bool[] IsEquip;
  public bool[] IsFindItemComposite;
  public ushort[] EquipItemID;
  public ushort[] EquipNeedLv;

  public HeroEquip(int len = 6)
  {
    this.IsEquip = new bool[6];
    this.IsFindItemComposite = new bool[6];
    this.EquipItemID = new ushort[6];
    this.EquipNeedLv = new ushort[6];
  }
}
