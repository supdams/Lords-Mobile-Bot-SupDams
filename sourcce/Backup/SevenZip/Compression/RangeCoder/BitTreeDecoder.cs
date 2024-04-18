// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.RangeCoder.BitTreeDecoder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
namespace SevenZip.Compression.RangeCoder
{
  internal struct BitTreeDecoder
  {
    private BitDecoder[] Models;
    private int NumBitLevels;

    public BitTreeDecoder(int numBitLevels)
    {
      this.NumBitLevels = numBitLevels;
      this.Models = new BitDecoder[1 << numBitLevels];
    }

    public void Init()
    {
      for (uint index = 1; (long) index < (long) (1 << this.NumBitLevels); ++index)
        this.Models[(IntPtr) index].Init();
    }

    public uint Decode(Decoder rangeDecoder)
    {
      uint index = 1;
      for (int numBitLevels = this.NumBitLevels; numBitLevels > 0; --numBitLevels)
        index = (index << 1) + this.Models[(IntPtr) index].Decode(rangeDecoder);
      return index - (uint) (1 << this.NumBitLevels);
    }

    public uint ReverseDecode(Decoder rangeDecoder)
    {
      uint index1 = 1;
      uint num1 = 0;
      for (int index2 = 0; index2 < this.NumBitLevels; ++index2)
      {
        uint num2 = this.Models[(IntPtr) index1].Decode(rangeDecoder);
        index1 = (index1 << 1) + num2;
        num1 |= num2 << index2;
      }
      return num1;
    }

    public static uint ReverseDecode(
      BitDecoder[] Models,
      uint startIndex,
      Decoder rangeDecoder,
      int NumBitLevels)
    {
      uint num1 = 1;
      uint num2 = 0;
      for (int index = 0; index < NumBitLevels; ++index)
      {
        uint num3 = Models[(IntPtr) (startIndex + num1)].Decode(rangeDecoder);
        num1 = (num1 << 1) + num3;
        num2 |= num3 << index;
      }
      return num2;
    }
  }
}
