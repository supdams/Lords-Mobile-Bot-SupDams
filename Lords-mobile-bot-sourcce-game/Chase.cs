// Decompiled with JetBrains decompiler
// Type: Chase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class Chase
{
  public GameObject SourceObj;
  private Vector3 Target;
  private Vector3[] SamplePoint;
  private Vector3[] SampleControl;
  private Vector3 Offset;
  private float[] SampleTime;
  private byte UsedSampleCount;
  private float TotalTime;
  private float LifeTime;
  public bool bMove;
  private ChaseType Type;
  private float CurveHeight;
  public ushort particleID;

  public Chase()
  {
    this.bMove = false;
    this.Offset = new Vector3(0.0f, 0.0f, 0.0f);
  }

  public void AddParticleChase(
    Vector3 Source,
    Vector3 Target,
    float TotalTime,
    ushort ParticleID,
    float ParticleScale,
    ChaseType CurveType)
  {
    this.Target = Target;
    this.TotalTime = TotalTime;
    this.Type = CurveType;
    this.particleID = ParticleID;
    if (this.particleID < (ushort) 0)
      return;
    this.SourceObj = ParticleManager.Instance.Spawn(this.particleID, (Transform) null, Source, ParticleScale, true, false);
    if ((Object) this.SourceObj == (Object) null)
      return;
    if (this.Type == ChaseType.CurveRandom)
    {
      switch ((byte) Mathf.Max(0.0f, (float) (40.0 * (double) Random.value / 10.0)))
      {
        case 0:
          this.Type = ChaseType.Straight;
          break;
        case 1:
          this.Type = ChaseType.CurveA;
          break;
        case 2:
          this.Type = ChaseType.CurveLeft;
          break;
        default:
          this.Type = ChaseType.CurveRight;
          break;
      }
    }
    if (this.Type == ChaseType.Straight)
      this.initStraight();
    else
      this.initCurve();
  }

  private void initStraight()
  {
    this.UsedSampleCount = (byte) 2;
    this.CreateSamplePoint();
    this.LookTarget(this.Target);
    this.SamplePoint[0] = this.SourceObj.transform.position;
    this.SamplePoint[1] = this.Target + this.Offset;
    this.SampleTime[0] = 0.0f;
    this.SampleTime[1] = this.TotalTime;
    this.LifeTime = 0.0f;
    this.bMove = true;
  }

  private void LookTarget(Vector3 target)
  {
    Vector3 forward = target - this.SourceObj.transform.position;
    if (forward == Vector3.zero)
      return;
    this.SourceObj.transform.rotation = Quaternion.LookRotation(forward);
  }

  private void initCurve()
  {
    this.UsedSampleCount = (byte) 2;
    this.CreateSamplePoint();
    this.SamplePoint[0] = this.SourceObj.transform.position;
    this.SamplePoint[1] = this.Target + this.Offset;
    this.SampleTime[0] = 0.0f;
    this.SampleTime[1] = this.TotalTime;
    this.CurveHeight = this.Type != ChaseType.CurveB ? Vector3.Distance(this.SourceObj.transform.position, this.Target) * 0.25f : Vector3.Distance(this.SourceObj.transform.position, this.Target) * 0.4f;
    this.UpdateSampleControl();
    this.LifeTime = 0.0f;
    this.bMove = true;
    this.LookTarget(this.Target);
  }

  private void UpdateSampleControl()
  {
    if (this.Type == ChaseType.CurveB)
    {
      this.SampleControl[0] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.25f;
      this.SampleControl[1] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.75f;
    }
    else
    {
      this.SampleControl[0] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.25f;
      this.SampleControl[1] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.6f;
    }
    switch (this.Type)
    {
      case ChaseType.CurveA:
      case ChaseType.CurveB:
        this.SampleControl[0].y += this.CurveHeight;
        this.SampleControl[1].y += this.CurveHeight;
        break;
      case ChaseType.CurveLeft:
        this.SampleControl[0].z -= this.CurveHeight;
        this.SampleControl[1].z -= this.CurveHeight;
        break;
      case ChaseType.CurveRight:
        this.SampleControl[0].z += this.CurveHeight;
        this.SampleControl[1].z += this.CurveHeight;
        break;
    }
  }

  private void CreateSamplePoint()
  {
    this.SamplePoint = new Vector3[(int) this.UsedSampleCount];
    this.SampleControl = new Vector3[(int) this.UsedSampleCount];
    this.SampleTime = new float[(int) this.UsedSampleCount];
  }

  public void Update()
  {
    if (!this.bMove)
      return;
    if ((double) this.LifeTime > (double) this.SampleTime[(int) this.UsedSampleCount - 1])
    {
      this.bMove = false;
      this.SourceObj.transform.position = this.SamplePoint[(int) this.UsedSampleCount - 1];
      this.StopParticle();
    }
    else
    {
      this.SamplePoint[(int) this.UsedSampleCount - 1] = this.Target + this.Offset;
      if (this.Type != ChaseType.Straight)
        this.UpdateSampleControl();
      if (this.Type == ChaseType.Straight)
      {
        this.LookTarget(this.SamplePoint[(int) this.UsedSampleCount - 1]);
        float f = this.LifeTime / this.TotalTime;
        if (!float.IsNaN(f))
          this.SourceObj.transform.position = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * f;
        else
          Debug.Log((object) string.Format("NAN:{0}/{1}", (object) this.LifeTime, (object) this.TotalTime));
      }
      else
        this.Evaluate();
      this.LifeTime += Time.deltaTime;
    }
  }

  public void StopParticle()
  {
    if (this.particleID > (ushort) 0)
      ParticleManager.Instance.DeSpawn(this.SourceObj);
    this.particleID = (ushort) 0;
  }

  private void Evaluate()
  {
    int index = 0;
    while (index < (int) this.UsedSampleCount - 1 && (double) this.LifeTime >= (double) this.SampleTime[index + 1])
      ++index;
    if (index >= (int) this.UsedSampleCount - 1)
      return;
    float num1 = this.SampleTime[index];
    float num2 = this.SampleTime[index + 1];
    float num3 = (float) (((double) this.LifeTime - (double) num1) / ((double) num2 - (double) num1));
    Vector3 vector3_1 = this.SamplePoint[index + 1] - 3f * this.SampleControl[2 * index + 1] + 3f * this.SampleControl[2 * index] - this.SamplePoint[index];
    Vector3 vector3_2 = 3f * this.SampleControl[2 * index + 1] - 6f * this.SampleControl[2 * index] + 3f * this.SamplePoint[index];
    Vector3 vector3_3 = 3f * this.SampleControl[2 * index] - 3f * this.SamplePoint[index];
    Vector3 target = this.SamplePoint[0] + num3 * (vector3_3 + num3 * (vector3_2 + num3 * vector3_1));
    this.LookTarget(target);
    this.SourceObj.transform.position = target;
  }
}
