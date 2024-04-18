// Decompiled with JetBrains decompiler
// Type: Column
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal struct Column
{
  public uint m_StrID;
  public uint m_EffID;
  public long m_Value;
  public bool bFisetColumn;
  public bool bLastColumn;
  public float ColumnWidth;
  public CString m_Str;

  public Column(int i)
  {
    this.m_Value = 0L;
    this.m_StrID = 0U;
    this.m_EffID = 0U;
    this.ColumnWidth = 0.0f;
    this.bFisetColumn = false;
    this.bLastColumn = false;
    this.m_Str = StringManager.Instance.SpawnString(200);
  }
}
