﻿// Decompiled with JetBrains decompiler
// Type: SevenZip.Buffer.InBuffer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;

#nullable disable
namespace SevenZip.Buffer
{
  public class InBuffer
  {
    private byte[] m_Buffer;
    private uint m_Pos;
    private uint m_Limit;
    private uint m_BufferSize;
    private Stream m_Stream;
    private bool m_StreamWasExhausted;
    private ulong m_ProcessedSize;

    public InBuffer(uint bufferSize)
    {
      this.m_Buffer = new byte[(IntPtr) bufferSize];
      this.m_BufferSize = bufferSize;
    }

    public void Init(Stream stream)
    {
      this.m_Stream = stream;
      this.m_ProcessedSize = 0UL;
      this.m_Limit = 0U;
      this.m_Pos = 0U;
      this.m_StreamWasExhausted = false;
    }

    public bool ReadBlock()
    {
      if (this.m_StreamWasExhausted)
        return false;
      this.m_ProcessedSize += (ulong) this.m_Pos;
      int num = this.m_Stream.Read(this.m_Buffer, 0, (int) this.m_BufferSize);
      this.m_Pos = 0U;
      this.m_Limit = (uint) num;
      this.m_StreamWasExhausted = num == 0;
      return !this.m_StreamWasExhausted;
    }

    public void ReleaseStream() => this.m_Stream = (Stream) null;

    public bool ReadByte(byte b)
    {
      if (this.m_Pos >= this.m_Limit && !this.ReadBlock())
        return false;
      b = this.m_Buffer[(IntPtr) this.m_Pos++];
      return true;
    }

    public byte ReadByte()
    {
      return this.m_Pos >= this.m_Limit && !this.ReadBlock() ? byte.MaxValue : this.m_Buffer[(IntPtr) this.m_Pos++];
    }

    public ulong GetProcessedSize() => this.m_ProcessedSize + (ulong) this.m_Pos;
  }
}
