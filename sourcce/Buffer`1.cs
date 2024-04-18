// Decompiled with JetBrains decompiler
// Type: Buffer`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public sealed class Buffer<T> where T : struct
{
  private readonly int offset;
  private readonly int count;
  public readonly bool outlaw;
  private T[] Data;

  public Buffer(T[] Data, int off, int len)
  {
    this.Data = Data;
    this.offset = off;
    this.count = len;
  }

  public Buffer(int len)
  {
    this.Data = new T[len];
    this.offset = 0;
    this.count = len;
    this.outlaw = true;
  }

  public int EOB => this.offset + this.count;

  public T this[int index]
  {
    get => index >= 0 && index < this.count ? this.Data[this.offset + index] : default (T);
    set
    {
      if (index < 0 || index >= this.count)
        return;
      this.Data[this.offset + index] = value;
    }
  }

  public T[] GetBuffer() => this.Data;

  public int GetIndex(int idx = 0) => this.offset + (idx >= this.count ? 0 : idx);
}
