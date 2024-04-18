// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.LZMA.Decoder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace SevenZip.Compression.LZMA
{
  public class Decoder : ICoder, ISetDecoderProperties
  {
    private OutWindow m_OutWindow = new OutWindow();
    private SevenZip.Compression.RangeCoder.Decoder m_RangeDecoder = new SevenZip.Compression.RangeCoder.Decoder();
    private BitDecoder[] m_IsMatchDecoders = new BitDecoder[new IntPtr(192)];
    private BitDecoder[] m_IsRepDecoders = new BitDecoder[new IntPtr(12)];
    private BitDecoder[] m_IsRepG0Decoders = new BitDecoder[new IntPtr(12)];
    private BitDecoder[] m_IsRepG1Decoders = new BitDecoder[new IntPtr(12)];
    private BitDecoder[] m_IsRepG2Decoders = new BitDecoder[new IntPtr(12)];
    private BitDecoder[] m_IsRep0LongDecoders = new BitDecoder[new IntPtr(192)];
    private BitTreeDecoder[] m_PosSlotDecoder = new BitTreeDecoder[new IntPtr(4)];
    private BitDecoder[] m_PosDecoders = new BitDecoder[new IntPtr(114)];
    private BitTreeDecoder m_PosAlignDecoder = new BitTreeDecoder(4);
    private Decoder.LenDecoder m_LenDecoder = new Decoder.LenDecoder();
    private Decoder.LenDecoder m_RepLenDecoder = new Decoder.LenDecoder();
    private Decoder.LiteralDecoder m_LiteralDecoder = new Decoder.LiteralDecoder();
    private uint m_DictionarySize;
    private uint m_DictionarySizeCheck;
    private uint m_PosStateMask;
    private bool _solid;

    public Decoder()
    {
      this.m_DictionarySize = uint.MaxValue;
      for (int index = 0; index < 4; ++index)
        this.m_PosSlotDecoder[index] = new BitTreeDecoder(6);
    }

    private void SetDictionarySize(uint dictionarySize)
    {
      if ((int) this.m_DictionarySize == (int) dictionarySize)
        return;
      this.m_DictionarySize = dictionarySize;
      this.m_DictionarySizeCheck = Math.Max(this.m_DictionarySize, 1U);
      this.m_OutWindow.Create(Math.Max(this.m_DictionarySizeCheck, 4096U));
    }

    private void SetLiteralProperties(int lp, int lc)
    {
      if (lp > 8)
        throw new InvalidParamException();
      if (lc > 8)
        throw new InvalidParamException();
      this.m_LiteralDecoder.Create(lp, lc);
    }

    private void SetPosBitsProperties(int pb)
    {
      if (pb > 4)
        throw new InvalidParamException();
      uint numPosStates = (uint) (1 << pb);
      this.m_LenDecoder.Create(numPosStates);
      this.m_RepLenDecoder.Create(numPosStates);
      this.m_PosStateMask = numPosStates - 1U;
    }

    private void Init(Stream inStream, Stream outStream)
    {
      this.m_RangeDecoder.Init(inStream);
      this.m_OutWindow.Init(outStream, this._solid);
      for (uint index1 = 0; index1 < 12U; ++index1)
      {
        for (uint index2 = 0; index2 <= this.m_PosStateMask; ++index2)
        {
          uint index3 = (index1 << 4) + index2;
          this.m_IsMatchDecoders[(IntPtr) index3].Init();
          this.m_IsRep0LongDecoders[(IntPtr) index3].Init();
        }
        this.m_IsRepDecoders[(IntPtr) index1].Init();
        this.m_IsRepG0Decoders[(IntPtr) index1].Init();
        this.m_IsRepG1Decoders[(IntPtr) index1].Init();
        this.m_IsRepG2Decoders[(IntPtr) index1].Init();
      }
      this.m_LiteralDecoder.Init();
      for (uint index = 0; index < 4U; ++index)
        this.m_PosSlotDecoder[(IntPtr) index].Init();
      for (uint index = 0; index < 114U; ++index)
        this.m_PosDecoders[(IntPtr) index].Init();
      this.m_LenDecoder.Init();
      this.m_RepLenDecoder.Init();
      this.m_PosAlignDecoder.Init();
    }

    public void Code(
      Stream inStream,
      Stream outStream,
      long inSize,
      long outSize,
      ICodeProgress progress)
    {
    }

    [DebuggerHidden]
    public IEnumerator Decode(
      Stream inStream,
      Stream outStream,
      long inSize,
      long outSize,
      uint roundSize,
      ICodeProgress progress)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Decoder.\u003CDecode\u003Ec__Iterator3()
      {
        inStream = inStream,
        outStream = outStream,
        outSize = outSize,
        roundSize = roundSize,
        progress = progress,
        \u003C\u0024\u003EinStream = inStream,
        \u003C\u0024\u003EoutStream = outStream,
        \u003C\u0024\u003EoutSize = outSize,
        \u003C\u0024\u003EroundSize = roundSize,
        \u003C\u0024\u003Eprogress = progress,
        \u003C\u003Ef__this = this
      };
    }

    public void SetDecoderProperties(byte[] properties)
    {
      if (properties.Length < 5)
        throw new InvalidParamException();
      int lc = (int) properties[0] % 9;
      int num = (int) properties[0] / 9;
      int lp = num % 5;
      int pb = num / 5;
      if (pb > 4)
        throw new InvalidParamException();
      uint dictionarySize = 0;
      for (int index = 0; index < 4; ++index)
        dictionarySize += (uint) properties[1 + index] << index * 8;
      this.SetDictionarySize(dictionarySize);
      this.SetLiteralProperties(lp, lc);
      this.SetPosBitsProperties(pb);
    }

    public bool Train(Stream stream)
    {
      this._solid = true;
      return this.m_OutWindow.Train(stream);
    }

    private class LenDecoder
    {
      private BitDecoder m_Choice = new BitDecoder();
      private BitDecoder m_Choice2 = new BitDecoder();
      private BitTreeDecoder[] m_LowCoder = new BitTreeDecoder[new IntPtr(16)];
      private BitTreeDecoder[] m_MidCoder = new BitTreeDecoder[new IntPtr(16)];
      private BitTreeDecoder m_HighCoder = new BitTreeDecoder(8);
      private uint m_NumPosStates;

      public void Create(uint numPosStates)
      {
        for (uint numPosStates1 = this.m_NumPosStates; numPosStates1 < numPosStates; ++numPosStates1)
        {
          this.m_LowCoder[(IntPtr) numPosStates1] = new BitTreeDecoder(3);
          this.m_MidCoder[(IntPtr) numPosStates1] = new BitTreeDecoder(3);
        }
        this.m_NumPosStates = numPosStates;
      }

      public void Init()
      {
        this.m_Choice.Init();
        for (uint index = 0; index < this.m_NumPosStates; ++index)
        {
          this.m_LowCoder[(IntPtr) index].Init();
          this.m_MidCoder[(IntPtr) index].Init();
        }
        this.m_Choice2.Init();
        this.m_HighCoder.Init();
      }

      public uint Decode(SevenZip.Compression.RangeCoder.Decoder rangeDecoder, uint posState)
      {
        if (this.m_Choice.Decode(rangeDecoder) == 0U)
          return this.m_LowCoder[(IntPtr) posState].Decode(rangeDecoder);
        uint num = 8;
        return this.m_Choice2.Decode(rangeDecoder) != 0U ? num + 8U + this.m_HighCoder.Decode(rangeDecoder) : num + this.m_MidCoder[(IntPtr) posState].Decode(rangeDecoder);
      }
    }

    private class LiteralDecoder
    {
      private Decoder.LiteralDecoder.Decoder2[] m_Coders;
      private int m_NumPrevBits;
      private int m_NumPosBits;
      private uint m_PosMask;

      public void Create(int numPosBits, int numPrevBits)
      {
        if (this.m_Coders != null && this.m_NumPrevBits == numPrevBits && this.m_NumPosBits == numPosBits)
          return;
        this.m_NumPosBits = numPosBits;
        this.m_PosMask = (uint) ((1 << numPosBits) - 1);
        this.m_NumPrevBits = numPrevBits;
        uint length = (uint) (1 << this.m_NumPrevBits + this.m_NumPosBits);
        this.m_Coders = new Decoder.LiteralDecoder.Decoder2[(IntPtr) length];
        for (uint index = 0; index < length; ++index)
          this.m_Coders[(IntPtr) index].Create();
      }

      public void Init()
      {
        uint num = (uint) (1 << this.m_NumPrevBits + this.m_NumPosBits);
        for (uint index = 0; index < num; ++index)
          this.m_Coders[(IntPtr) index].Init();
      }

      private uint GetState(uint pos, byte prevByte)
      {
        return (uint) ((((int) pos & (int) this.m_PosMask) << this.m_NumPrevBits) + ((int) prevByte >> 8 - this.m_NumPrevBits));
      }

      public byte DecodeNormal(SevenZip.Compression.RangeCoder.Decoder rangeDecoder, uint pos, byte prevByte)
      {
        return this.m_Coders[(IntPtr) this.GetState(pos, prevByte)].DecodeNormal(rangeDecoder);
      }

      public byte DecodeWithMatchByte(
        SevenZip.Compression.RangeCoder.Decoder rangeDecoder,
        uint pos,
        byte prevByte,
        byte matchByte)
      {
        return this.m_Coders[(IntPtr) this.GetState(pos, prevByte)].DecodeWithMatchByte(rangeDecoder, matchByte);
      }

      private struct Decoder2
      {
        private BitDecoder[] m_Decoders;

        public void Create() => this.m_Decoders = new BitDecoder[768];

        public void Init()
        {
          for (int index = 0; index < 768; ++index)
            this.m_Decoders[index].Init();
        }

        public byte DecodeNormal(SevenZip.Compression.RangeCoder.Decoder rangeDecoder)
        {
          uint index = 1;
          do
          {
            index = index << 1 | this.m_Decoders[(IntPtr) index].Decode(rangeDecoder);
          }
          while (index < 256U);
          return (byte) index;
        }

        public byte DecodeWithMatchByte(SevenZip.Compression.RangeCoder.Decoder rangeDecoder, byte matchByte)
        {
          uint index = 1;
          do
          {
            uint num1 = (uint) ((int) matchByte >> 7 & 1);
            matchByte <<= 1;
            uint num2 = this.m_Decoders[(IntPtr) ((uint) (1 + (int) num1 << 8) + index)].Decode(rangeDecoder);
            index = index << 1 | num2;
            if ((int) num1 != (int) num2)
            {
              while (index < 256U)
                index = index << 1 | this.m_Decoders[(IntPtr) index].Decode(rangeDecoder);
              break;
            }
          }
          while (index < 256U);
          return (byte) index;
        }
      }
    }
  }
}
