// Decompiled with JetBrains decompiler
// Type: InfoItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal class InfoItem
{
  public byte m_Type;
  public bool bHaveLvColumn;
  public int m_ColumNum;
  public float m_Height;
  public float m_Width;
  public int m_DataIdx;
  public Column[] m_Column;

  public InfoItem()
  {
    this.m_Column = new Column[6];
    for (int index = 0; index < this.m_Column.Length; ++index)
      this.m_Column[index] = new Column(0);
  }
}
