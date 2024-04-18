// Decompiled with JetBrains decompiler
// Type: StringTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

#nullable disable
public class StringTable
{
  public string[] StringTableData;
  public int RecordAmount;
  public int MaxKey;
  protected IntPtr BytesIntPtr_Key;
  protected IntPtr BytesIntPtr;

  public StringTable()
  {
    this.BytesIntPtr_Key = IntPtr.Zero;
    this.BytesIntPtr = IntPtr.Zero;
  }

  ~StringTable()
  {
    this.ClearStringTable();
    if (this.BytesIntPtr_Key != IntPtr.Zero)
    {
      GCHandle gcHandle = GCHandle.FromIntPtr(this.BytesIntPtr_Key);
      if (gcHandle.IsAllocated)
        gcHandle.Free();
    }
    if (!(this.BytesIntPtr != IntPtr.Zero))
      return;
    GCHandle gcHandle1 = GCHandle.FromIntPtr(this.BytesIntPtr);
    if (!gcHandle1.IsAllocated)
      return;
    gcHandle1.Free();
  }

  public unsafe bool LoadStringTable(string Table = "Loading/String", bool Seek = false)
  {
    bool flag = false;
    int Key = 0;
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Table, out Key, Seek);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return flag;
    TextAsset textAsset1 = assetBundle.Load(nameof (StringTable)) as TextAsset;
    TextAsset textAsset2 = assetBundle.Load("StringTable2") as TextAsset;
    if ((UnityEngine.Object) textAsset1 == (UnityEngine.Object) null || (UnityEngine.Object) textAsset2 == (UnityEngine.Object) null)
      return flag;
    this.RecordAmount = 0;
    using (BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(textAsset2.bytes)))
    {
      this.RecordAmount = binaryReader.ReadInt32();
      this.BytesIntPtr_Key = GCHandle.Alloc((object) textAsset2.bytes, GCHandleType.Pinned).AddrOfPinnedObject();
    }
    Stream input = (Stream) new MemoryStream(textAsset1.bytes);
    GCHandle gcHandle;
    using (BinaryReader binaryReader = new BinaryReader(input))
    {
      this.MaxKey = binaryReader.ReadInt32();
      gcHandle = GCHandle.Alloc((object) textAsset1.bytes, GCHandleType.Pinned);
      this.BytesIntPtr = gcHandle.AddrOfPinnedObject();
      int length = this.MaxKey / 8 + 1;
      this.StringTableData = new string[length];
      int num1 = this.RecordAmount / 2;
      for (int index = 1; index < num1; ++index)
      {
        int num2 = 4 + index * 2;
        IntPtr ptr = new IntPtr((void*) ((IntPtr) this.BytesIntPtr_Key.ToPointer() + num2));
        ushort structure1 = (ushort) Marshal.PtrToStructure(ptr, typeof (ushort));
        if (structure1 > (ushort) 0 && (int) structure1 < length && this.StringTableData[(int) structure1] == null)
        {
          byte* numPtr = (byte*) ((IntPtr) this.BytesIntPtr.ToPointer() + (4 + ((int) structure1 - 1) * 8));
          ptr = new IntPtr((void*) numPtr);
          int structure2 = (int) Marshal.PtrToStructure(ptr, typeof (int));
          ptr = new IntPtr((void*) (numPtr + 4));
          ushort structure3 = (ushort) Marshal.PtrToStructure(ptr, typeof (ushort));
          int num3 = 4 + this.MaxKey + structure2;
          ptr = new IntPtr((void*) ((IntPtr) this.BytesIntPtr.ToPointer() + num3));
          this.StringTableData[(int) structure1] = new string((sbyte*) (void*) ptr, 0, (int) structure3, Encoding.UTF8);
        }
      }
      binaryReader.Close();
    }
    input.Close();
    if (gcHandle.IsAllocated)
      gcHandle.Free();
    AssetManager.UnloadAssetBundle(Key);
    return true;
  }

  public unsafe string GetStringByID(uint ID)
  {
    int num1 = 4;
    if (ID <= 0U || (long) ID >= (long) (this.RecordAmount / 2))
      return string.Empty;
    int num2 = num1 + (int) ID * 2;
    ushort structure = (ushort) Marshal.PtrToStructure(new IntPtr((void*) ((IntPtr) this.BytesIntPtr_Key.ToPointer() + num2)), typeof (ushort));
    return (int) structure > this.StringTableData.Length ? this.StringTableData[0] : this.StringTableData[(int) structure];
  }

  public void ClearStringTable()
  {
    if (this.StringTableData != null)
      Array.Clear((Array) this.StringTableData, 0, this.StringTableData.Length);
    this.StringTableData = (string[]) null;
  }
}
