// Decompiled with JetBrains decompiler
// Type: uTools.uTweenPath
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace uTools
{
  public class uTweenPath : uTweenValue
  {
    public RectTransform target;
    public List<Vector3> paths;
    private int mIndex = -1;
    private int mPathsCount;
    private bool mCache;

    private void Cache()
    {
      this.mCache = true;
      if (this.paths.Count > 1)
        this.mPathsCount = this.paths.Count - 1;
      if ((Object) this.target == (Object) null)
        this.target = this.GetComponent<RectTransform>();
      this.from = 0.0f;
      this.to = (float) this.mPathsCount;
    }

    private void Update()
    {
    }

    protected override void ValueUpdate(float _factor, bool _isFinished)
    {
      if (!this.mCache)
        this.Cache();
      this.pathIndex = Mathf.FloorToInt(_factor);
      Debug.Log((object) this.pathIndex);
    }

    private int pathIndex
    {
      get => this.mIndex;
      set
      {
        if (this.mIndex == value)
          return;
        this.mIndex = value;
        Debug.Log((object) ((Transform) this.target).localPosition);
        uTweenPosition.Begin(((Component) this.target).gameObject, ((Transform) this.target).localPosition, this.paths[this.mIndex], this.duration / (float) this.paths.Count).loopStyle = LoopStyle.Loop;
      }
    }
  }
}
