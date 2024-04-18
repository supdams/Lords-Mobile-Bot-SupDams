// Decompiled with JetBrains decompiler
// Type: CHashSet`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class CHashSet<TKey>
{
  private int[] m_HashCode;
  private TKey[] m_Key;
  private int m_Count;

  public CHashSet(int capacity, bool bSaveKeyData = true)
  {
    if (capacity <= 0)
      Debug.LogError((object) "CHashSet::Length can't be zero");
    this.m_HashCode = new int[capacity];
    if (bSaveKeyData)
      this.m_Key = new TKey[capacity];
    GameConstants.ArrayFill<int>(this.m_HashCode, -1);
  }

  public int hashFunction(TKey key) => key.GetHashCode() & int.MaxValue;

  public bool Add(TKey key)
  {
    if (this.m_Count == this.m_HashCode.Length)
    {
      Debug.LogError((object) "CHashSet::Insert failed");
      return false;
    }
    int index = this.hashFunction(key) % this.m_HashCode.Length;
    while (this.m_HashCode[index] != -1)
      index = (index + 1) % this.m_HashCode.Length;
    this.m_HashCode[index] = key.GetHashCode();
    if (this.m_Key != null)
      this.m_Key[index] = key;
    ++this.m_Count;
    return true;
  }

  public bool Insert(TKey key) => this.Add(key);

  public bool Find(TKey key) => this.ContainsKey(key);

  public bool ContainsKey(TKey key)
  {
    int index = this.hashFunction(key) % this.m_HashCode.Length;
    int num = index;
    while (this.m_HashCode[index] != -1)
    {
      if (this.m_HashCode[index] == key.GetHashCode())
        return true;
      index = (index + 1) % this.m_HashCode.Length;
      if (num == index)
        return false;
    }
    return false;
  }

  public void Remove(TKey key)
  {
    if (this.m_Count == 0)
      return;
    int index = this.hashFunction(key) % this.m_HashCode.Length;
    int num = index;
    while (this.m_HashCode[index] != -1)
    {
      if (this.m_HashCode[index] == key.GetHashCode())
      {
        this.m_HashCode[index] = -1;
        if (this.m_Key != null)
          this.m_Key[index] = default (TKey);
        --this.m_Count;
        break;
      }
      index = (index + 1) % this.m_HashCode.Length;
      if (num == index)
        break;
    }
  }

  public void Clear()
  {
    GameConstants.ArrayFill<int>(this.m_HashCode, -1);
    if (this.m_Key != null)
      Array.Clear((Array) this.m_Key, 0, this.m_Key.Length);
    this.m_Count = 0;
  }

  public int Count => this.m_Count;

  public TKey[] Keys => this.m_Key;
}
