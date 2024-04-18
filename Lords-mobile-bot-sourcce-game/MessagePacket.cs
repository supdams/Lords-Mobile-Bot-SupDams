// Decompiled with JetBrains decompiler
// Type: MessagePacket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MessagePacket
{
  public int Offset;
  private int length;
  protected byte Channel;
  private readonly int Delimiter;
  private readonly int MaxSize;
  private static int Sequence;
  public Buffer<byte> Data;
  public Protocol Protocol;

  public MessagePacket(ushort Max = 1024)
  {
    this.Data = NetworkManager.RetrieveSize((int) Max);
    this.Delimiter = this.Data.GetIndex();
    this.MaxSize = (int) Max;
    this.length = 4;
  }

  public MessagePacket(ref byte[] Read, int off, int len)
  {
    this.Data = new Buffer<byte>(Read, off, len);
    this.Delimiter = off;
    this.length = len;
  }

  public MessagePacket(Buffer<byte> Buff) => this.Data = Buff;

  public int Length => this.length;

  public static void Clear() => MessagePacket.Sequence = 0;

  public virtual void AddSeqId()
  {
    if (!NetworkManager.Connected())
      return;
    this.Add(++MessagePacket.Sequence);
  }

  public void Add(byte data)
  {
    this.Data[this.length] = data;
    ++this.length;
  }

  public void Add(ushort data) => this.Add((short) data);

  public unsafe void Add(short data)
  {
    byte* numPtr = &this.Data.GetBuffer()[this.Delimiter + this.length];
    *(short*) numPtr = data;
    numPtr = (byte*) null;
    this.length += 2;
  }

  public void Add(uint data) => this.Add((int) data);

  public unsafe void Add(int data)
  {
    byte* numPtr = &this.Data.GetBuffer()[this.Delimiter + this.length];
    *(int*) numPtr = data;
    numPtr = (byte*) null;
    this.length += 4;
  }

  public void Add(ulong data) => this.Add((long) data);

  public unsafe void Add(long data)
  {
    if (this.length + 8 > this.MaxSize)
      return;
    byte* numPtr = &this.Data.GetBuffer()[this.Delimiter + this.length];
    *(long*) numPtr = data;
    numPtr = (byte*) null;
    this.length += 8;
  }

  public void Add(float data) => this.Add(^(int&) ref data);

  public unsafe void Add(string data, int size)
  {
    if (data != null && this.Length + size <= this.MaxSize)
    {
      int bytesUsed = data.IndexOf(char.MinValue);
      string str = data;
      char* chars = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
      byte* bytes = &this.Data.GetBuffer()[this.Delimiter + this.length];
      Encoding.UTF8.GetEncoder().Convert(chars, bytesUsed < 0 ? data.Length : bytesUsed, bytes, size, true, out int _, out bytesUsed, out bool _);
      bytes = (byte*) null;
      str = (string) null;
      Array.Clear((Array) this.Data.GetBuffer(), this.Data.GetIndex(this.length + bytesUsed), size - bytesUsed);
    }
    this.length += size;
  }

  public void Add(byte[] data, int startIdx = 0, int len = 0)
  {
    if (data.Length < len && this.Length + len <= this.MaxSize)
      Array.Clear((Array) this.Data.GetBuffer(), this.Data.GetIndex(this.length + data.Length), len - data.Length);
    if ((len > 0 && startIdx <= data.Length - Math.Min(len, data.Length) || (len = Buffer.ByteLength((Array) data)) > 0 && startIdx == 0) && startIdx >= 0 && this.Length + len <= this.MaxSize)
      Buffer.BlockCopy((Array) data, startIdx, (Array) this.Data.GetBuffer(), this.Data.GetIndex(this.length), Math.Min(len, data.Length));
    this.length += len;
  }

  public byte ReadByte(int iCount = -1)
  {
    byte num = this.Data[iCount >= 0 ? iCount : this.Offset];
    if (iCount < 0)
      ++this.Offset;
    return num;
  }

  public ushort ReadUShort(int iCount = -1)
  {
    ushort num = (iCount >= 0 ? iCount : this.Offset) + this.Delimiter > this.Data.EOB - 2 ? (ushort) 0 : GameConstants.ConvertBytesToUShort(this.Data.GetBuffer(), this.Data.GetIndex(iCount >= 0 ? iCount : this.Offset));
    if (iCount < 0)
      this.Offset += 2;
    return num;
  }

  public short ReadShort(int iCount = -1) => (short) this.ReadUShort(iCount);

  public int ReadInt(int iCount = -1)
  {
    int num1 = 0;
    int num2 = 4;
    if (iCount < 0)
    {
      if (this.length - this.Offset >= num2)
        num1 = GameConstants.ConvertBytesToInt(this.Data.GetBuffer(), this.Delimiter + this.Offset);
      this.Offset += num2;
    }
    else if (this.length - iCount >= num2)
      num1 = GameConstants.ConvertBytesToInt(this.Data.GetBuffer(), this.Delimiter + iCount);
    return num1;
  }

  public uint ReadUInt(int iCount = -1)
  {
    uint num1 = 0;
    int num2 = 4;
    if (iCount < 0)
    {
      if (this.length - this.Offset >= num2)
        num1 = GameConstants.ConvertBytesToUInt(this.Data.GetBuffer(), this.Delimiter + this.Offset);
      this.Offset += num2;
    }
    else if (this.length - iCount >= num2)
      num1 = GameConstants.ConvertBytesToUInt(this.Data.GetBuffer(), this.Delimiter + iCount);
    return num1;
  }

  public long ReadLong(int iCount = -1) => (long) this.ReadULong(iCount);

  public ulong ReadULong(int iCount = -1)
  {
    ulong num1 = 0;
    int num2 = 8;
    if (iCount < 0)
    {
      if (this.length - this.Offset >= num2)
        num1 = BitConverter.ToUInt64(this.Data.GetBuffer(), this.Delimiter + this.Offset);
      this.Offset += num2;
    }
    else if (this.length - iCount >= num2)
      num1 = BitConverter.ToUInt64(this.Data.GetBuffer(), this.Delimiter + iCount);
    return num1;
  }

  public float ReadFloat(int iCount = -1)
  {
    int num = this.ReadInt(iCount);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    return ^(float&) ref num;
  }

  public double ReadDouble(int iCount = -1)
  {
    long num = this.ReadLong(iCount);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    return ^(double&) ref num;
  }

  public DateTime ReadTime(int iCount = -1)
  {
    return DateTime.FromBinary(this.ReadLong(iCount) * 10000000L + 621355968000000000L).ToLocalTime();
  }

  public unsafe string ReadString(int VSize, int iCount = -1)
  {
    string empty = string.Empty;
    int count = 0;
    if (VSize <= 0 || this.length <= (iCount >= 0 ? iCount : this.Offset))
      return empty;
    byte* numPtr = &this.Data.GetBuffer()[this.Delimiter + (iCount >= 0 ? iCount : this.Offset)];
    while (count < VSize && numPtr[count] != (byte) 0)
      ++count;
    numPtr = (byte*) null;
    if (iCount < 0 && this.length - this.Offset >= count || iCount >= 0 && this.length - iCount >= count)
      empty = Encoding.UTF8.GetString(this.Data.GetBuffer(), this.Delimiter + (iCount >= 0 ? iCount : this.Offset), count);
    if (iCount < 0)
      this.Offset += VSize;
    return empty;
  }

  public unsafe void ReadStringPlus(int VSize, CString outString, int iCount = -1)
  {
    if (VSize <= 0 || this.length <= (iCount >= 0 ? iCount : this.Offset))
      return;
    int index1 = 0;
    int index2 = this.Delimiter + (iCount >= 0 ? iCount : this.Offset);
    byte* numPtr = &this.Data.GetBuffer()[index2];
    while (index1 < VSize && numPtr[index1] != (byte) 0)
      ++index1;
    numPtr = (byte*) null;
    if (iCount < 0 && this.length - this.Offset >= index1 || this.length - iCount >= index1)
    {
      string str = outString.ToString();
      char* chars = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
      byte* bytes = &this.Data.GetBuffer()[index2];
      int charCount = Encoding.UTF8.GetCharCount(this.Data.GetBuffer(), index2, index1);
      if (charCount < outString.MaxLength)
      {
        Encoding.UTF8.GetChars(bytes, index1, chars, charCount);
        outString.Length = charCount;
        chars[charCount] = char.MinValue;
      }
      bytes = (byte*) null;
      str = (string) null;
    }
    if (iCount >= 0)
      return;
    this.Offset += VSize;
  }

  public void ReadBlock(byte[] Out, int startIdx, int size, int iCount = -1)
  {
    if (Out != null && Out.Length - startIdx >= size)
      Buffer.BlockCopy((Array) this.Data.GetBuffer(), this.Data.GetIndex(iCount >= 0 ? iCount : this.Offset), (Array) Out, startIdx, Math.Min(size, Math.Max(this.Length - (iCount >= 0 ? iCount : this.Offset), 0)));
    if (iCount >= 0)
      return;
    this.Offset += size;
  }

  public bool Send(bool Force = false)
  {
    if (this.Channel > (byte) 0)
    {
      if (NetworkManager.GuestController.Connected() || Force)
      {
        GameConstants.GetBytes((ushort) this.length, this.Data.GetBuffer(), this.Data.GetIndex());
        GameConstants.GetBytes((ushort) this.Protocol, this.Data.GetBuffer(), this.Data.GetIndex(2));
        NetworkPeeper.Cipher(this.Data.GetBuffer(), this.Data.GetIndex(4), this.Length - 4, this.MaxSize);
        NetworkPeeper.SendBuff.Enqueue((object) this);
        return true;
      }
      if (!this.Data.outlaw && this.Data.EOB == NetworkManager.write_pos)
        NetworkManager.write_pos -= this.MaxSize;
      return false;
    }
    if (NetworkManager.Connected() || Force)
    {
      GameConstants.GetBytes((ushort) this.length, this.Data.GetBuffer(), this.Data.GetIndex());
      GameConstants.GetBytes((ushort) this.Protocol, this.Data.GetBuffer(), this.Data.GetIndex(2));
      NetworkManager.Cipher(this.Data.GetBuffer(), this.Data.GetIndex(4), this.Length - 4, this.MaxSize);
      NetworkManager.Send(this);
      return true;
    }
    if (!this.Data.outlaw && this.Data.EOB == NetworkManager.write_pos)
      NetworkManager.write_pos -= this.MaxSize;
    return false;
  }

  public static MessagePacket GetGuestMessagePack()
  {
    return (MessagePacket) new GuestMessagePacket((byte) 1);
  }
}
