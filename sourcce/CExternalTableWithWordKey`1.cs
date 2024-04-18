// Decompiled with JetBrains decompiler
// Type: CExternalTableWithWordKey`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
public class CExternalTableWithWordKey<R> where R : struct
{
  protected ushort MaxKey;
  protected int RecordAmount;
  protected IntPtr KeyMapIndex;
  protected IntPtr BytesIntPtr;

  public CExternalTableWithWordKey()
  {
    this.MaxKey = (ushort) 0;
    this.KeyMapIndex = IntPtr.Zero;
    this.BytesIntPtr = IntPtr.Zero;
  }

  ~CExternalTableWithWordKey()
  {
    if (this.KeyMapIndex != IntPtr.Zero)
    {
      GCHandle gcHandle = GCHandle.FromIntPtr(this.KeyMapIndex);
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

  public bool LoadTable(string in_DataName)
  {
    if (!DataManager.Instance.bLoadingTableSuccess)
      return false;
    bool flag = false;
    if (in_DataName.Length == 0)
    {
      DataManager.Instance.bLoadingTableSuccess = false;
      return flag;
    }
    AssetBundle tableAb = DataManager.Instance.GetTableAB();
    if ((UnityEngine.Object) tableAb == (UnityEngine.Object) null)
    {
      DataManager.Instance.bLoadingTableSuccess = false;
      return flag;
    }
    TextAsset textAsset = tableAb.Load(in_DataName) as TextAsset;
    if ((UnityEngine.Object) textAsset == (UnityEngine.Object) null)
    {
      DataManager.Instance.bLoadingTableSuccess = false;
      return flag;
    }
    Stream input = (Stream) new MemoryStream(textAsset.bytes);
    if (input.Length <= 4L)
    {
      DataManager.Instance.bLoadingTableSuccess = false;
      return flag;
    }
    GCHandle gcHandle = GCHandle.Alloc((object) textAsset.bytes, GCHandleType.Pinned);
    this.BytesIntPtr = gcHandle.AddrOfPinnedObject();
    int num1 = (int) input.Length - 4;
    int num2 = Marshal.SizeOf(typeof (R));
    if (num1 < num2 || num1 % num2 != 0)
    {
      if (gcHandle.IsAllocated)
      {
        gcHandle.Free();
        this.BytesIntPtr = IntPtr.Zero;
      }
      input.Close();
      Resources.UnloadUnusedAssets();
      DataManager.Instance.bLoadingTableSuccess = false;
      return flag;
    }
    this.RecordAmount = num1 / num2;
    using (BinaryReader binaryReader = new BinaryReader(input))
    {
      int num3 = (int) binaryReader.ReadUInt16();
      ushort num4 = binaryReader.ReadUInt16();
      if (this.RecordAmount > (int) num4)
        this.RecordAmount = (int) num4;
      int startIdx1 = 4 + (this.RecordAmount - 1) * num2;
      this.MaxKey = GameConstants.ConvertBytesToUShort(textAsset.bytes, startIdx1);
      ++this.MaxKey;
      ushort[] numArray = new ushort[(int) this.MaxKey];
      Array.Clear((Array) numArray, 0, (int) this.MaxKey);
      int startIdx2 = 4;
      for (ushort index = 0; (int) index < this.RecordAmount; ++index)
      {
        numArray[(int) GameConstants.ConvertBytesToUShort(textAsset.bytes, startIdx2)] = index;
        startIdx2 += num2;
      }
      gcHandle = GCHandle.Alloc((object) numArray, GCHandleType.Pinned);
      this.KeyMapIndex = gcHandle.AddrOfPinnedObject();
      binaryReader.Close();
    }
    input.Close();
    return true;
  }

  public unsafe R GetRecordByKey(ushort InKey)
  {
    int Index = 0;
    if ((int) InKey < (int) this.MaxKey)
      Index = (int) *(ushort*) ((IntPtr) this.KeyMapIndex.ToPointer() + (int) InKey * 2);
    return this.GetRecordByIndex(Index);
  }

  public unsafe ushort GetIndexByKey(ushort InKey)
  {
    int indexByKey = 0;
    if ((int) InKey < (int) this.MaxKey)
      indexByKey = (int) *(ushort*) ((IntPtr) this.KeyMapIndex.ToPointer() + (int) InKey * 2);
    return (ushort) indexByKey;
  }

  public unsafe R GetRecordByIndex(int Index)
  {
    if (this.RecordAmount == 0)
      return default (R);
    int num = 4;
    if (Index >= 0 && Index < this.RecordAmount)
      num += Index * Marshal.SizeOf(typeof (R));
    return (R) Marshal.PtrToStructure(new IntPtr((void*) ((IntPtr) this.BytesIntPtr.ToPointer() + num)), typeof (R));
  }

  public int TableCount => this.RecordAmount;

  public ushort MapCount => this.MaxKey;

  public unsafe IntPtr TablePtr => new IntPtr((void*) ((IntPtr) this.BytesIntPtr.ToPointer() + 4));

  public IntPtr MapPtr => this.KeyMapIndex;
}
