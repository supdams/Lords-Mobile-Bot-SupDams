// Decompiled with JetBrains decompiler
// Type: uTools.uTweenValue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace uTools
{
  public class uTweenValue : uTweener
  {
    public float from;
    public float to;
    private float mValue;

    public float value
    {
      get => this.mValue;
      set => this.mValue = value;
    }

    protected virtual void ValueUpdate(float value, bool isFinished)
    {
    }

    protected override void OnUpdate(float factor, bool isFinished)
    {
      this.value = this.from + factor * (this.to - this.from);
      this.ValueUpdate(this.value, isFinished);
    }
  }
}
