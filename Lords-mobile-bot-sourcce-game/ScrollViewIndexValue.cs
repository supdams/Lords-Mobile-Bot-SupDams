// Decompiled with JetBrains decompiler
// Type: ScrollViewIndexValue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct ScrollViewIndexValue
{
  public int headIndex;
  public int endIndex;
  public int NowIndex;
  public int MaxIndex;
  public int MaxSize;

  public void IndexValue()
  {
    this.headIndex = 0;
    this.endIndex = 0;
    this.NowIndex = 1;
    this.MaxIndex = 0;
    this.MaxSize = 0;
  }
}
