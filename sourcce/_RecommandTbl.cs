// Decompiled with JetBrains decompiler
// Type: _RecommandTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct _RecommandTbl
{
  public ushort[] RecommandID;
  public byte[] Achievement;
  public ushort MinIndex;
  public ushort SaveIndex;

  public void CheckMin(ushort Min)
  {
    if ((int) this.MinIndex >= (int) Min)
      return;
    this.MinIndex = Min;
    this.SaveIndex = this.MinIndex;
  }

  public void Reset() => this.SaveIndex = (ushort) 1;
}
