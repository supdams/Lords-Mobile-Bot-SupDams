// Decompiled with JetBrains decompiler
// Type: FlyingObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FlyingObject
{
  private const byte UsedSampleCount = 2;
  private const float InverseHeroScaleBase = 0.333333343f;
  public GameObject SourceObj;
  private Vector3 Target;
  private Transform ScaleRoot;
  private Vector3[] SamplePoint;
  private Vector3[] SampleControl;
  private Vector3 Offset;
  private float[] SampleTime;
  private float TotalTime;
  private float LifeTime;
  private float ShiftStep;
  public bool bMove;
  private float CurveHeight;
  public float specialDelay;
  private ChaseType Type;
  public FOKind foKind;

  public FlyingObject()
  {
    this.bMove = false;
    this.Offset = new Vector3(0.0f, 1f, 0.0f);
    this.CreateSamplePoint();
  }

  public Vector3 EndPoint => this.Target + this.Offset;

  public void AddFlyingObject(
    Vector3 Source,
    Transform Target,
    float TotalTime,
    Vector3 offset,
    Transform scaleRoot,
    ChaseType CurveType)
  {
    this.Target = Target.position;
    this.Type = CurveType;
    this.TotalTime = TotalTime;
    this.Offset = offset;
    this.specialDelay = 0.0f;
    this.ScaleRoot = scaleRoot;
    if ((Object) this.ScaleRoot != (Object) null)
    {
      MeshRenderer component = this.SourceObj.GetComponent<MeshRenderer>();
      if ((Object) component != (Object) null)
        component.sharedMaterial = SheetAnimInfo.Instance.nonBatching_sharedMat;
    }
    this.SourceObj.transform.position = Source;
    if (this.Type == ChaseType.Straight)
      this.initStraight();
    else
      this.initCurve();
  }

  private void EndingCheck()
  {
    if (!((Object) this.ScaleRoot != (Object) null))
      return;
    MeshRenderer component = this.SourceObj.GetComponent<MeshRenderer>();
    if ((Object) component != (Object) null)
      component.sharedMaterial = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
    this.ScaleRoot = (Transform) null;
  }

  private void LookTarget(Vector3 Target)
  {
    Vector3 forward = Target - this.SourceObj.transform.position;
    if (forward == Vector3.zero)
      return;
    this.SourceObj.transform.rotation = Quaternion.LookRotation(forward);
  }

  private void initCurve()
  {
    this.SamplePoint[0] = this.SourceObj.transform.position;
    this.SamplePoint[1] = this.Target + this.Offset;
    this.SampleTime[0] = 0.0f;
    this.SampleTime[1] = this.TotalTime;
    float num = Random.Range(0.3f, 0.5f);
    this.CurveHeight = Vector3.Distance(this.SourceObj.transform.position, this.Target) * num;
    this.UpdateSampleControl();
    this.LifeTime = 0.0f;
    this.ShiftStep = 0.0f;
    this.bMove = true;
    this.LookTarget(this.Target);
  }

  private void initStraight()
  {
    this.LookTarget(this.Target);
    this.SamplePoint[0] = this.SourceObj.transform.position;
    this.SamplePoint[1] = this.Target + this.Offset;
    this.SampleTime[0] = 0.0f;
    this.SampleTime[1] = this.TotalTime;
    this.LifeTime = 0.0f;
    this.bMove = true;
  }

  private void UpdateSampleControl()
  {
    Vector3 vector3 = this.SamplePoint[1] - this.SamplePoint[0];
    this.SampleControl[0] = this.SamplePoint[0] + vector3 * 0.25f;
    this.SampleControl[1] = this.SamplePoint[0] + vector3 * 0.6f;
    this.SampleControl[0].y += this.CurveHeight;
    this.SampleControl[1].y += this.CurveHeight;
  }

  private void CreateSamplePoint()
  {
    this.SamplePoint = new Vector3[2];
    this.SampleControl = new Vector3[2];
    this.SampleTime = new float[2];
  }

  public void Destroy()
  {
    if (!((Object) this.SourceObj != (Object) null))
      return;
    Object.Destroy((Object) this.SourceObj);
    this.SourceObj = (GameObject) null;
  }

  public void Update(float deltaTime)
  {
    if (!this.bMove)
      return;
    if ((double) this.LifeTime > (double) this.SampleTime[1])
    {
      this.bMove = false;
      this.SourceObj.transform.position = this.SamplePoint[1];
    }
    else
    {
      this.SamplePoint[1] = this.Target + this.Offset;
      if (this.Type == ChaseType.Straight)
      {
        this.LookTarget(this.SamplePoint[1]);
        if ((double) Mathf.Abs(this.TotalTime) >= 1.0 / 1000.0)
          this.SourceObj.transform.position = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * (this.LifeTime / this.TotalTime);
      }
      else
      {
        this.UpdateSampleControl();
        this.Evaluate(deltaTime);
      }
      if ((Object) this.ScaleRoot != (Object) null)
        this.SourceObj.transform.localScale = this.ScaleRoot.localScale * 0.333333343f;
      float num = this.EaseOutIn(this.LifeTime, 1.1f, 0.9f, this.TotalTime);
      this.ShiftStep += deltaTime * num;
      this.LifeTime += deltaTime;
    }
  }

  private void Evaluate(float deltaTime)
  {
    float num1 = this.SampleTime[0];
    float num2 = this.SampleTime[1];
    float num3 = (float) (((double) this.ShiftStep - (double) num1) / ((double) num2 - (double) num1));
    Vector3 vector3_1 = this.SamplePoint[1] - (this.SampleControl[1] - this.SampleControl[0]) * 3f - this.SamplePoint[0];
    Vector3 vector3_2 = 3f * (this.SampleControl[1] + this.SamplePoint[0]) - 6f * this.SampleControl[0];
    Vector3 vector3_3 = (this.SampleControl[0] - this.SamplePoint[0]) * 3f;
    Vector3 Target = this.SamplePoint[0] + num3 * (vector3_3 + num3 * (vector3_2 + num3 * vector3_1));
    if (this.foKind == FOKind.Stone || this.foKind == FOKind.FireStone)
      this.SourceObj.transform.Rotate(Vector3.left, 720f * deltaTime, Space.Self);
    else if (this.foKind != FOKind.LightBall)
      this.LookTarget(Target);
    this.SourceObj.transform.position = Target;
  }

  private float EaseOutIn(float time, float from, float to, float duration)
  {
    float num = duration * 0.5f;
    return (double) time < (double) num ? Mathf.SmoothStep(from, to, time / num) : Mathf.SmoothStep(to, from, (time - num) / num);
  }
}
