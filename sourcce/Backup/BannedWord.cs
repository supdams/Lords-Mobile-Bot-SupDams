// Decompiled with JetBrains decompiler
// Type: BannedWord
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

#nullable disable
public class BannedWord
{
  public BoyerMooreStringMatcher[] BMStringArray;
  public BoyerMooreStringMatcher[] BMStringArray_Accurate;

  public BannedWord()
  {
    this.LoadBannedWordTable();
    this.LoadBannedWordTable2();
  }

  public unsafe void LoadBannedWordTable()
  {
    int num1 = 0;
    IntPtr num2 = IntPtr.Zero;
    IntPtr zero = IntPtr.Zero;
    int Key = 0;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("Loading/Table", out Key);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    TextAsset textAsset1 = assetBundle.Load(nameof (BannedWord)) as TextAsset;
    TextAsset textAsset2 = assetBundle.Load("BannedWord2") as TextAsset;
    if ((UnityEngine.Object) textAsset1 == (UnityEngine.Object) null || (UnityEngine.Object) textAsset2 == (UnityEngine.Object) null)
      return;
    using (BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(textAsset2.bytes)))
    {
      num1 = binaryReader.ReadInt32();
      num2 = GCHandle.Alloc((object) textAsset2.bytes, GCHandleType.Pinned).AddrOfPinnedObject();
    }
    Stream input = (Stream) new MemoryStream(textAsset1.bytes);
    GCHandle gcHandle;
    using (BinaryReader binaryReader = new BinaryReader(input))
    {
      int num3 = binaryReader.ReadInt32();
      gcHandle = GCHandle.Alloc((object) textAsset1.bytes, GCHandleType.Pinned);
      IntPtr num4 = gcHandle.AddrOfPinnedObject();
      int length = num3 / 8 + 1;
      this.BMStringArray = new BoyerMooreStringMatcher[length];
      int num5 = num1 / 2 + 1;
      for (int index = 1; index < num5; ++index)
      {
        int num6 = 4 + index * 2;
        IntPtr ptr = new IntPtr((void*) ((IntPtr) num2.ToPointer() + num6));
        ushort structure1 = (ushort) Marshal.PtrToStructure(ptr, typeof (ushort));
        if (structure1 > (ushort) 0 && (int) structure1 < length && this.BMStringArray[(int) structure1] == null)
        {
          byte* numPtr = (byte*) ((IntPtr) num4.ToPointer() + (4 + ((int) structure1 - 1) * 8));
          ptr = new IntPtr((void*) numPtr);
          int structure2 = (int) Marshal.PtrToStructure(ptr, typeof (int));
          ptr = new IntPtr((void*) (numPtr + 4));
          ushort structure3 = (ushort) Marshal.PtrToStructure(ptr, typeof (ushort));
          int num7 = 4 + num3 + structure2;
          ptr = new IntPtr((void*) ((IntPtr) num4.ToPointer() + num7));
          this.BMStringArray[(int) structure1] = new BoyerMooreStringMatcher(new string((sbyte*) (void*) ptr, 0, (int) structure3, Encoding.UTF8));
        }
      }
      binaryReader.Close();
    }
    input.Close();
    if (gcHandle.IsAllocated)
      gcHandle.Free();
    AssetManager.UnloadAssetBundle(Key);
  }

  public void UnLoadBannedWordTable()
  {
    if (this.BMStringArray == null)
      return;
    for (int index = 1; index < this.BMStringArray.Length; ++index)
      this.BMStringArray[index].UnLoad();
    this.BMStringArray = (BoyerMooreStringMatcher[]) null;
  }

  public unsafe void LoadBannedWordTable2()
  {
    int num1 = 0;
    IntPtr num2 = IntPtr.Zero;
    IntPtr zero = IntPtr.Zero;
    int Key = 0;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("Loading/Table", out Key);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    TextAsset textAsset1 = assetBundle.Load("AccurateBannedWord") as TextAsset;
    TextAsset textAsset2 = assetBundle.Load("AccurateBannedWord2") as TextAsset;
    if ((UnityEngine.Object) textAsset1 == (UnityEngine.Object) null || (UnityEngine.Object) textAsset2 == (UnityEngine.Object) null)
      return;
    using (BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(textAsset2.bytes)))
    {
      num1 = binaryReader.ReadInt32();
      num2 = GCHandle.Alloc((object) textAsset2.bytes, GCHandleType.Pinned).AddrOfPinnedObject();
    }
    Stream input = (Stream) new MemoryStream(textAsset1.bytes);
    GCHandle gcHandle;
    using (BinaryReader binaryReader = new BinaryReader(input))
    {
      int num3 = binaryReader.ReadInt32();
      gcHandle = GCHandle.Alloc((object) textAsset1.bytes, GCHandleType.Pinned);
      IntPtr num4 = gcHandle.AddrOfPinnedObject();
      int length = num3 / 8 + 1;
      this.BMStringArray_Accurate = new BoyerMooreStringMatcher[length];
      int num5 = num1 / 2 + 1;
      for (int index = 1; index < num5; ++index)
      {
        int num6 = 4 + index * 2;
        IntPtr ptr = new IntPtr((void*) ((IntPtr) num2.ToPointer() + num6));
        ushort structure1 = (ushort) Marshal.PtrToStructure(ptr, typeof (ushort));
        if (structure1 > (ushort) 0 && (int) structure1 < length && this.BMStringArray_Accurate[(int) structure1] == null)
        {
          byte* numPtr = (byte*) ((IntPtr) num4.ToPointer() + (4 + ((int) structure1 - 1) * 8));
          ptr = new IntPtr((void*) numPtr);
          int structure2 = (int) Marshal.PtrToStructure(ptr, typeof (int));
          ptr = new IntPtr((void*) (numPtr + 4));
          ushort structure3 = (ushort) Marshal.PtrToStructure(ptr, typeof (ushort));
          int num7 = 4 + num3 + structure2;
          ptr = new IntPtr((void*) ((IntPtr) num4.ToPointer() + num7));
          this.BMStringArray_Accurate[(int) structure1] = new BoyerMooreStringMatcher(new string((sbyte*) (void*) ptr, 0, (int) structure3, Encoding.UTF8));
        }
      }
      binaryReader.Close();
    }
    input.Close();
    if (gcHandle.IsAllocated)
      gcHandle.Free();
    AssetManager.UnloadAssetBundle(Key);
  }

  public void UnLoadBannedWordTable2()
  {
    if (this.BMStringArray_Accurate == null)
      return;
    for (int index = 1; index < this.BMStringArray_Accurate.Length; ++index)
      this.BMStringArray_Accurate[index].UnLoad();
    this.BMStringArray_Accurate = (BoyerMooreStringMatcher[]) null;
  }

  public void CheckBannedWord(char[] text)
  {
    if (this.BMStringArray != null)
    {
      for (int index = 1; index < this.BMStringArray.Length; ++index)
        this.BMStringArray[index].CheckAndRePlace(text);
    }
    if (this.BMStringArray_Accurate == null)
      return;
    for (int index = 1; index < this.BMStringArray_Accurate.Length; ++index)
      this.BMStringArray_Accurate[index].CheckAndRePlace(text, true);
  }

  public void CheckBannedWord(string text)
  {
    if (this.BMStringArray != null)
    {
      for (int index = 1; index < this.BMStringArray.Length; ++index)
        this.BMStringArray[index].CheckAndRePlace(text);
    }
    if (this.BMStringArray_Accurate == null)
      return;
    for (int index = 1; index < this.BMStringArray_Accurate.Length; ++index)
      this.BMStringArray_Accurate[index].CheckAndRePlace(text, true);
  }

  public bool ChackHasBannedWord(string text)
  {
    if (this.BMStringArray != null)
    {
      for (int index = 1; index < this.BMStringArray.Length; ++index)
      {
        if (this.BMStringArray[index].TryMatch(text))
          return true;
      }
    }
    if (this.BMStringArray_Accurate != null)
    {
      for (int index = 1; index < this.BMStringArray_Accurate.Length; ++index)
      {
        if (this.BMStringArray_Accurate[index].TryMatch(text, true))
          return true;
      }
    }
    return false;
  }
}
