// Decompiled with JetBrains decompiler
// Type: sScrollItemData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal struct sScrollItemData
{
  public float Height;
  public eItem Type;
  public ushort StrID;
  public ushort StrID_Value;
  public uint StrNum;
  public int ArmyIdx;
  public uint ArmyNum;

  public sScrollItemData(int len = 0)
  {
    this.Height = 0.0f;
    this.Type = eItem.TitleType;
    this.StrID = (ushort) 0;
    this.StrID_Value = (ushort) 0;
    this.StrNum = 0U;
    this.ArmyIdx = 0;
    this.ArmyNum = 0U;
  }
}
