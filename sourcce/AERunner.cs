// Decompiled with JetBrains decompiler
// Type: AERunner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class AERunner
{
  private RectTransform ObjectRTF;
  public Vector2 CenterPivot;
  private bool Active;
  public AERunner.AEType[] ActiveKind;
  public float[] PositionKey;
  public Vector2[] PositionValue;
  public float[] ScaleKey;
  public Vector2[] ScaleValue;
  public float[] RotationKey;
  public float[] RotationValue;
  public float[] AlphaKey;
  public float[] AlphaValue;
  private int PositionStage;
  private int ScaleStage;
  private int RotationStage;
  private int AlphaStage;
  public Image[] AlphaApplyImages;
  private float AnimationTime;
  private IAERunnerEndHandler _EndHandler;
  private float LastKey;
  public int mRunner_ID1;
  public int mRunner_ID2;

  public AERunner(RectTransform ActiveObject)
  {
    this.ObjectRTF = ActiveObject;
    this.SetTime(0.0f, false);
  }

  public void SetTime(float toTime = 0, bool StartNow = true)
  {
    this.PositionStage = 1;
    this.ScaleStage = 1;
    this.RotationStage = 1;
    this.AlphaStage = 1;
    this.AnimationTime = toTime;
    this.Active = StartNow;
  }

  public void Pause(bool UnPause = false) => this.Active = UnPause;

  public void Update()
  {
    if (!this.Active)
      return;
    this.UpdateDeltaTime();
    this.UpdateAnimationUnit();
  }

  public void SetEndRecall(IAERunnerEndHandler iEndHandler) => this._EndHandler = iEndHandler;

  public void UpdateDeltaTime()
  {
    this.AnimationTime += Time.deltaTime;
    if ((double) this.AnimationTime < (double) this.LastKey)
      return;
    this.Active = false;
    if (this._EndHandler == null)
      return;
    this._EndHandler.OnAERunnerEnd(this.mRunner_ID1, this.mRunner_ID2);
  }

  public void CheckLastKey()
  {
    this.LastKey = 0.0f;
    for (int index = 0; index < this.ActiveKind.Length; ++index)
    {
      switch (this.ActiveKind[index])
      {
        case AERunner.AEType.position:
          if ((double) this.PositionKey[this.PositionKey.Length - 1] > (double) this.LastKey)
          {
            this.LastKey = this.PositionKey[this.PositionKey.Length - 1];
            break;
          }
          break;
        case AERunner.AEType.scale:
          if ((double) this.ScaleKey[this.ScaleKey.Length - 1] > (double) this.LastKey)
          {
            this.LastKey = this.ScaleKey[this.ScaleKey.Length - 1];
            break;
          }
          break;
        case AERunner.AEType.rotation:
          if ((double) this.RotationKey[this.RotationKey.Length - 1] > (double) this.LastKey)
          {
            this.LastKey = this.RotationKey[this.RotationKey.Length - 1];
            break;
          }
          break;
        case AERunner.AEType.alpha:
          if ((double) this.AlphaKey[this.AlphaKey.Length - 1] > (double) this.LastKey)
          {
            this.LastKey = this.AlphaKey[this.AlphaKey.Length - 1];
            break;
          }
          break;
      }
    }
  }

  public void UpdateAnimationUnit()
  {
    for (int index = 0; index < this.ActiveKind.Length; ++index)
    {
      switch (this.ActiveKind[index])
      {
        case AERunner.AEType.position:
          this.UpdatePosition();
          break;
        case AERunner.AEType.scale:
          this.UpdateScale();
          break;
        case AERunner.AEType.rotation:
          this.UpdateRotation();
          break;
        case AERunner.AEType.alpha:
          this.UpdateAlpha();
          break;
      }
    }
  }

  private void UpdatePosition()
  {
    if (this.PositionKey.Length <= this.PositionStage)
      return;
    while (this.PositionKey.Length > this.PositionStage && (double) this.AnimationTime > (double) this.PositionKey[this.PositionStage])
      ++this.PositionStage;
    if (this.PositionKey.Length == this.PositionStage)
      this.ObjectRTF.anchoredPosition = this.PositionValue[this.PositionStage - 1] + this.CenterPivot;
    else
      this.ObjectRTF.anchoredPosition = Vector2.Lerp(this.PositionValue[this.PositionStage - 1], this.PositionValue[this.PositionStage], Mathf.InverseLerp(this.PositionKey[this.PositionStage - 1], this.PositionKey[this.PositionStage], this.AnimationTime)) + this.CenterPivot;
  }

  private void UpdateRotation()
  {
    if (this.RotationKey.Length <= this.RotationStage)
      return;
    while (this.RotationKey.Length > this.RotationStage && (double) this.AnimationTime > (double) this.RotationKey[this.RotationStage])
      ++this.RotationStage;
    if (this.RotationKey.Length == this.RotationStage)
      ((Transform) this.ObjectRTF).localEulerAngles = new Vector3(0.0f, 0.0f, this.RotationValue[this.RotationStage - 1]);
    else
      ((Transform) this.ObjectRTF).localEulerAngles = new Vector3(0.0f, 0.0f, Mathf.Lerp(this.RotationValue[this.RotationStage - 1], this.RotationValue[this.RotationStage], Mathf.InverseLerp(this.RotationKey[this.RotationStage - 1], this.RotationKey[this.RotationStage], this.AnimationTime)));
  }

  private void UpdateScale()
  {
    if (this.ScaleKey.Length <= this.ScaleStage)
      return;
    while (this.ScaleKey.Length > this.ScaleStage && (double) this.AnimationTime > (double) this.ScaleKey[this.ScaleStage])
      ++this.ScaleStage;
    if (this.ScaleKey.Length == this.ScaleStage)
      ((Transform) this.ObjectRTF).localScale = new Vector3(this.ScaleValue[this.ScaleStage - 1].x, this.ScaleValue[this.ScaleStage - 1].y, 1f);
    else
      ((Transform) this.ObjectRTF).localScale = Vector3.Lerp((Vector3) this.ScaleValue[this.ScaleStage - 1], (Vector3) this.ScaleValue[this.ScaleStage], Mathf.InverseLerp(this.ScaleKey[this.ScaleStage - 1], this.ScaleKey[this.ScaleStage], this.AnimationTime));
  }

  private void UpdateAlpha()
  {
    if (this.AlphaKey.Length <= this.AlphaStage)
      return;
    while (this.AlphaKey.Length > this.AlphaStage && (double) this.AnimationTime > (double) this.AlphaKey[this.AlphaStage])
      ++this.AlphaStage;
    if (this.AlphaKey.Length == this.AlphaStage)
      this.SetAlphaArray(new Color(1f, 1f, 1f, this.AlphaValue[this.AlphaStage - 1]));
    else
      this.SetAlphaArray(new Color(1f, 1f, 1f, Mathf.Lerp(this.AlphaValue[this.AlphaStage - 1], this.AlphaValue[this.AlphaStage], Mathf.InverseLerp(this.AlphaKey[this.AlphaStage - 1], this.AlphaKey[this.AlphaStage], this.AnimationTime)) / 100f));
  }

  private void SetAlphaArray(Color color)
  {
    if (this.AlphaApplyImages == null)
      return;
    for (int index = 0; index < this.AlphaApplyImages.Length; ++index)
      ((Graphic) this.AlphaApplyImages[index]).color = color;
  }

  public enum AEType : byte
  {
    position,
    scale,
    rotation,
    alpha,
  }
}
