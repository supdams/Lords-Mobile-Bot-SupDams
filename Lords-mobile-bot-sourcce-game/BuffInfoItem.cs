// Decompiled with JetBrains decompiler
// Type: BuffInfoItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal struct BuffInfoItem
{
  public byte m_Type;
  public int m_ColumNum;
  public float m_Height;
  public float m_Width;
  public int m_DataIdx;
  public BuffInfoItemColumn[] m_Column;
  public GATTR_ENUM m_EffectType;
  public uint m_EffectValue;
  public int m_StrIdx;

  public void Init()
  {
    this.m_Type = (byte) 0;
    this.m_ColumNum = 2;
    this.m_Height = 0.0f;
    this.m_Width = 0.0f;
    this.m_DataIdx = 0;
    this.m_EffectType = GATTR_ENUM.EGE_DESHIELD_ATK;
    this.m_EffectValue = 0U;
    this.m_StrIdx = 0;
    this.m_Column = new BuffInfoItemColumn[2];
  }
}
