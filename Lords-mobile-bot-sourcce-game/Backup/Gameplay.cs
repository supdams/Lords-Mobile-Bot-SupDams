// Decompiled with JetBrains decompiler
// Type: Gameplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public abstract class Gameplay : IObserver
{
  protected Gameplay.UpdateDelegate[][] updateDelegates;

  public Gameplay()
  {
    this.updateDelegates = new Gameplay.UpdateDelegate[2][];
    Array.Clear((Array) this.updateDelegates, 0, this.updateDelegates.Length);
    this.updateDelegates[0] = new Gameplay.UpdateDelegate[4];
    this.updateDelegates[0][0] = new Gameplay.UpdateDelegate(this.UpdateNext);
    this.updateDelegates[0][1] = new Gameplay.UpdateDelegate(this.UpdateLoad);
    this.updateDelegates[0][2] = new Gameplay.UpdateDelegate(this.UpdateReady);
    this.updateDelegates[0][3] = new Gameplay.UpdateDelegate(this.UpdateRun);
    this.updateDelegates[1] = new Gameplay.UpdateDelegate[1];
    this.updateDelegates[1][0] = new Gameplay.UpdateDelegate(this.UpdateNews);
  }

  ~Gameplay() => this.ClearUpdateDelegates();

  public virtual void Renew(byte[] Subject, byte[] meg)
  {
    this.updateDelegates[(int) Subject[0]][(int) Subject[1]](meg);
  }

  protected virtual void ClearUpdateDelegates()
  {
    if (this.updateDelegates == null)
      return;
    for (int index = 0; index < this.updateDelegates.Length; ++index)
    {
      Array.Clear((Array) this.updateDelegates[index], 0, this.updateDelegates[index].Length);
      this.updateDelegates[index] = (Gameplay.UpdateDelegate[]) null;
    }
    this.updateDelegates = (Gameplay.UpdateDelegate[][]) null;
  }

  protected virtual void UpdateNews(byte[] meg)
  {
  }

  protected abstract void UpdateNext(byte[] meg);

  protected abstract void UpdateLoad(byte[] meg);

  protected abstract void UpdateReady(byte[] meg);

  protected abstract void UpdateRun(byte[] meg);

  protected delegate void UpdateDelegate(byte[] meg);
}
