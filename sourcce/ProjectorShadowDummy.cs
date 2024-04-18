// Decompiled with JetBrains decompiler
// Type: ProjectorShadowDummy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ProjectorShadowDummy : MonoBehaviour
{
  public Vector3 _ShadowLocalOffset;
  public float _RotationAngleOffset;
  private Quaternion _AngleOffset;
  private Quaternion _InbetweenRotation;
  private bool _RotationOffsetApplied;

  public void OnPreRender() => this.transform.localPosition = this._ShadowLocalOffset;

  private void OnRenderObject()
  {
    if (!this._RotationOffsetApplied)
      return;
    this.transform.rotation = this._InbetweenRotation;
    this._RotationOffsetApplied = false;
  }
}
