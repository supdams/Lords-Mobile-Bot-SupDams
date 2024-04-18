// Decompiled with JetBrains decompiler
// Type: ObjectPool`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public sealed class ObjectPool<T> where T : class, new()
{
  public int instancesToPreallocate = 5;
  private int _spawnedInstanceCount;
  private T[] _gameObjectPool;

  public ObjectPool(T t, int initialCapacity, bool bPrefab = false)
  {
    this.instancesToPreallocate = initialCapacity;
    this._gameObjectPool = new T[this.instancesToPreallocate];
    this.allocateGameObjects(t, bPrefab);
  }

  ~ObjectPool()
  {
    if (this._gameObjectPool == null)
      return;
    for (int index = 0; index < this.instancesToPreallocate; ++index)
      this._gameObjectPool[index] = (T) null;
    this._gameObjectPool = (T[]) null;
  }

  public T spawn() => this.pop();

  public void despawn(T t)
  {
    GameObject gameObject = (object) t as GameObject;
    if ((Object) gameObject != (Object) null)
      gameObject.SetActive(false);
    this._gameObjectPool[this.instancesToPreallocate - this._spawnedInstanceCount] = t;
    --this._spawnedInstanceCount;
  }

  private void allocateGameObjects(T t, bool bPrefab)
  {
    int index = 0;
    GameObject original = (object) t as GameObject;
    if ((Object) original != (Object) null)
    {
      if (!bPrefab)
        this._gameObjectPool[index++] = t;
      original.transform.parent = (Transform) null;
      original.SetActive(false);
      for (; index < this.instancesToPreallocate; ++index)
      {
        GameObject gameObject = Object.Instantiate((Object) original) as GameObject;
        if ((Object) gameObject != (Object) null)
        {
          gameObject.name = original.name;
          gameObject.transform.parent = (Transform) null;
          gameObject.SetActive(false);
        }
        this._gameObjectPool[index] = (object) gameObject as T;
      }
    }
    else
    {
      for (; index < this.instancesToPreallocate; ++index)
      {
        T obj = new T();
        this._gameObjectPool[index] = obj;
      }
    }
  }

  private T pop()
  {
    if (this._spawnedInstanceCount >= this.instancesToPreallocate)
      return (T) null;
    ++this._spawnedInstanceCount;
    T obj = this._gameObjectPool[this.instancesToPreallocate - this._spawnedInstanceCount];
    this._gameObjectPool[this.instancesToPreallocate - this._spawnedInstanceCount] = (T) null;
    return obj;
  }
}
