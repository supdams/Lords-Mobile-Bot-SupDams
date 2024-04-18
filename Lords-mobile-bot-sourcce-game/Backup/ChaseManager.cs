// Decompiled with JetBrains decompiler
// Type: ChaseManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ChaseManager
{
  private Chase[] UsedChaseArray;
  private ushort ChasePoolCont = 50;
  private ushort ChaseIndex;
  private static ChaseManager instance;
  private bool StopAllChase;
  public ObjectPool<Chase> ChasePool;
  private ushort SelChaseIdx;

  private ChaseManager()
  {
    this.ChasePool = new ObjectPool<Chase>(new Chase(), (int) this.ChasePoolCont);
    this.UsedChaseArray = new Chase[(int) this.ChasePoolCont];
    this.Initial();
  }

  private void Initial()
  {
    this.ChaseIndex = (ushort) 0;
    this.StopAllChase = false;
  }

  public static ChaseManager Instance
  {
    get
    {
      if (ChaseManager.instance == null)
        ChaseManager.instance = new ChaseManager();
      return ChaseManager.instance;
    }
  }

  public void AddChase(
    Vector3 Source,
    Transform Target,
    float TotalTime,
    ushort ParticleID,
    float ParticleScale,
    ChaseType CurveType = ChaseType.Straight)
  {
    if (!this.GetEmptyObjectIdx())
      return;
    this.UsedChaseArray[(int) this.SelChaseIdx] = this.ChasePool.spawn();
    if (this.UsedChaseArray[(int) this.SelChaseIdx] != null)
      this.UsedChaseArray[(int) this.SelChaseIdx].AddParticleChase(Source, Target.position, TotalTime, ParticleID, ParticleScale, CurveType);
    if (!((Object) this.UsedChaseArray[(int) this.SelChaseIdx].SourceObj == (Object) null))
      return;
    this.ChasePool.despawn(this.UsedChaseArray[(int) this.SelChaseIdx]);
    this.UsedChaseArray[(int) this.SelChaseIdx] = (Chase) null;
  }

  public void AddChase(
    Vector3 Source,
    Vector3 Target,
    float TotalTime,
    ushort ParticleID,
    float ParticleScale,
    ChaseType CurveType = ChaseType.Straight)
  {
    if (!this.GetEmptyObjectIdx())
      return;
    this.UsedChaseArray[(int) this.SelChaseIdx] = this.ChasePool.spawn();
    if (this.UsedChaseArray[(int) this.SelChaseIdx] != null)
      this.UsedChaseArray[(int) this.SelChaseIdx].AddParticleChase(Source, Target, TotalTime, ParticleID, ParticleScale, CurveType);
    if (!((Object) this.UsedChaseArray[(int) this.SelChaseIdx].SourceObj == (Object) null))
      return;
    this.ChasePool.despawn(this.UsedChaseArray[(int) this.SelChaseIdx]);
    this.UsedChaseArray[(int) this.SelChaseIdx] = (Chase) null;
  }

  private bool GetEmptyObjectIdx()
  {
    for (int index = 0; index < (int) this.ChasePoolCont; ++index)
    {
      if (this.UsedChaseArray[(int) this.ChaseIndex] == null)
      {
        this.SelChaseIdx = this.ChaseIndex;
        ++this.ChaseIndex;
        if ((int) this.ChaseIndex >= (int) this.ChasePoolCont)
          this.ChaseIndex = (ushort) 0;
        return true;
      }
    }
    return false;
  }

  public void Clear()
  {
    for (int index = 0; index < (int) this.ChasePoolCont; ++index)
    {
      if (this.UsedChaseArray[index] != null)
      {
        this.UsedChaseArray[index].StopParticle();
        this.ChasePool.despawn(this.UsedChaseArray[index]);
        this.UsedChaseArray[index] = (Chase) null;
      }
    }
  }

  public void Update()
  {
    if (this.StopAllChase)
      return;
    for (int index = 0; index < (int) this.ChasePoolCont; ++index)
    {
      if (this.UsedChaseArray[index] != null)
      {
        if (this.UsedChaseArray[index].bMove)
        {
          this.UsedChaseArray[index].Update();
        }
        else
        {
          this.ChasePool.despawn(this.UsedChaseArray[index]);
          this.UsedChaseArray[index] = (Chase) null;
        }
      }
    }
  }

  public void DestroyAll()
  {
    for (int index = 0; index < (int) this.ChasePoolCont; ++index)
      this.UsedChaseArray[index] = (Chase) null;
    ChaseManager.instance = (ChaseManager) null;
  }

  public void SetStopAllParticleChase(bool Stop)
  {
    this.StopAllChase = Stop;
    for (int index = 0; index < (int) this.ChasePoolCont; ++index)
    {
      if (this.UsedChaseArray[index] != null)
        ParticleManager.Instance.Pause(this.UsedChaseArray[index].SourceObj, Stop);
    }
  }
}
