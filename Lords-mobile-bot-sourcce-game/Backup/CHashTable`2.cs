// Decompiled with JetBrains decompiler
// Type: CHashTable`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class CHashTable<TKey, TValue> where TKey : IComparable
{
  private int[] m_HashCode;
  private TKey[] m_Key;
  private TValue[] m_Data;
  private int m_Count;

  public CHashTable(int capacity, bool bSaveKeyData = true)
  {
    if (capacity <= 0)
      Debug.LogError((object) "CHashTable::Length can't be zero");
    this.m_HashCode = new int[capacity];
    this.m_Key = new TKey[capacity];
    this.m_Data = new TValue[capacity];
    GameConstants.ArrayFill<int>(this.m_HashCode, -1);
  }

  public int hashFunction(TKey key) => key.GetHashCode() & int.MaxValue;

  public bool Add(TKey key, TValue val)
  {
    if (this.m_HashCode.Length == 0)
      return false;
    int index = this.hashFunction(key) % this.m_HashCode.Length;
    int num1 = index;
    int num2 = -1;
    bool flag = false;
    while (this.m_Key[index].CompareTo((object) key) != 0 || this.m_HashCode[index] == -1)
    {
      if (this.m_HashCode[index] == -1 && num2 == -1)
        num2 = index;
      index = (index + 1) % this.m_HashCode.Length;
      if (num1 == index)
      {
        flag = true;
        break;
      }
    }
    if (flag)
    {
      if (this.m_Count == this.m_HashCode.Length)
      {
        Debug.LogError((object) "CHashTable::Insert failed");
        return false;
      }
      index = num2;
      ++this.m_Count;
    }
    this.m_HashCode[index] = key.GetHashCode();
    this.m_Key[index] = key;
    this.m_Data[index] = val;
    return true;
  }

  public bool Insert(TKey key, TValue val) => this.Add(key, val);

  public TValue Find(TKey key)
  {
    if (this.m_HashCode.Length == 0)
      return default (TValue);
    int index = this.hashFunction(key) % this.m_HashCode.Length;
    int num = index;
    while (this.m_Key[index].CompareTo((object) key) != 0 || this.m_HashCode[index] == -1)
    {
      index = (index + 1) % this.m_HashCode.Length;
      if (num == index)
        return default (TValue);
    }
    return this.m_Data[index];
  }

  public bool ContainsKey(TKey key)
  {
    if (this.m_HashCode.Length == 0)
      return false;
    int index = this.hashFunction(key) % this.m_HashCode.Length;
    int num = index;
    while (this.m_Key[index].CompareTo((object) key) != 0 || this.m_HashCode[index] == -1)
    {
      index = (index + 1) % this.m_HashCode.Length;
      if (num == index)
        return false;
    }
    return true;
  }

  public void Remove(TKey key)
  {
    if (this.m_Count == 0)
      return;
    int index = this.hashFunction(key) % this.m_HashCode.Length;
    int num = index;
    while (this.m_Key[index].CompareTo((object) key) != 0 || this.m_HashCode[index] == -1)
    {
      index = (index + 1) % this.m_HashCode.Length;
      if (num == index)
        return;
    }
    this.m_HashCode[index] = -1;
    this.m_Key[index] = default (TKey);
    this.m_Data[index] = default (TValue);
    --this.m_Count;
  }

  public void Clear()
  {
    GameConstants.ArrayFill<int>(this.m_HashCode, -1);
    if (this.m_Key != null)
      Array.Clear((Array) this.m_Key, 0, this.m_Key.Length);
    Array.Clear((Array) this.m_Data, 0, this.m_Data.Length);
    this.m_Count = 0;
  }

  public TValue this[TKey key]
  {
    get => this.Find(key);
    set => this.Add(key, value);
  }

  public int Count => this.m_Count;

  public int Length => this.m_HashCode.Length;

  public TValue[] Values => this.m_Data;

  public TKey[] Keys => this.m_Key;
}
