// Decompiled with JetBrains decompiler
// Type: WoodRun
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class WoodRun : TrapBehavior
{
  private const byte MAX_STEPINDEX = 3;
  private readonly Vector3[] woodSamplePoint = new Vector3[4]
  {
    new Vector3(-4.5f, -5f, 0.0f),
    new Vector3(-4f, 0.0f, 0.0f),
    new Vector3(-2f, 0.0f, 0.0f),
    new Vector3(-2f, 0.0f, 0.0f)
  };
  private float[] SampleTime = new float[5]
  {
    0.0f,
    0.4f,
    0.8f,
    0.5f,
    0.5f
  };
  private float[] RotateSpeed = new float[4]
  {
    960f,
    360f,
    240f,
    200f
  };
  private WoodRun.WoodNode[] woodController;
  private byte UnitCount;

  public WoodRun(Vector3[] defaultPos, byte unitCount)
  {
    this.oriPos = defaultPos;
    this.UnitCount = unitCount;
    this.woodController = new WoodRun.WoodNode[(int) unitCount];
    if (unitCount == (byte) 3)
      this.hitParticleID = (ushort) 2011;
    else
      this.hitParticleID = (ushort) 2013;
  }

  private void UpdateSampleControl(ref WoodRun.WoodNode woodNode)
  {
    Vector3 vector3 = woodNode.SamplePoint2 - woodNode.SamplePoint1;
    woodNode.SampleControl1 = woodNode.SamplePoint1 + vector3 * 0.25f;
    woodNode.SampleControl2 = woodNode.SamplePoint1 + vector3 * 0.6f;
    woodNode.SampleControl1.y += woodNode.CurveHeight;
    woodNode.SampleControl2.y += woodNode.CurveHeight;
  }

  private Vector3 Evaluate(float deltaTime, ref WoodRun.WoodNode woodNode)
  {
    float num1 = this.SampleTime[0];
    float num2 = this.SampleTime[(int) woodNode.sampleStep + 1];
    float num3 = (float) (((double) woodNode.timeStep - (double) num1) / ((double) num2 - (double) num1));
    Vector3 vector3_1 = woodNode.SamplePoint2 - (woodNode.SampleControl2 - woodNode.SampleControl1) * 3f - woodNode.SamplePoint1;
    Vector3 vector3_2 = 3f * (woodNode.SampleControl2 + woodNode.SamplePoint1) - 6f * woodNode.SampleControl1;
    Vector3 vector3_3 = (woodNode.SampleControl1 - woodNode.SamplePoint1) * 3f;
    return woodNode.SamplePoint1 + num3 * (vector3_3 + num3 * (vector3_2 + num3 * vector3_1));
  }

  private void InitNode(ref WoodRun.WoodNode woodNode, Transform wood)
  {
    woodNode.activeState = (byte) 1;
    woodNode.timeStep = 0.0f;
    woodNode.sampleStep = (byte) 0;
    woodNode.SamplePoint1 = wood.localPosition;
    woodNode.SamplePoint2 = wood.localPosition + this.woodSamplePoint[0];
    woodNode.CurveHeight = Vector3.Distance(woodNode.SamplePoint1, woodNode.SamplePoint2) * 0.4f;
  }

  private bool UpdateNode(float deltaTime, ref WoodRun.WoodNode woodNode, Transform wood)
  {
    if (woodNode.activeState == (byte) 0)
      return false;
    if (woodNode.activeState == (byte) 5)
    {
      wood.Rotate(Vector3.right, 64f * deltaTime, Space.Self);
      Vector3 position = wood.position;
      position.y -= deltaTime * 7f;
      position.x -= deltaTime * 2f;
      wood.position = position;
      if ((double) position.y <= -1.0)
        wood.gameObject.SetActive(false);
      return true;
    }
    if ((double) woodNode.timeStep > (double) this.SampleTime[(int) woodNode.sampleStep + 1])
    {
      if (woodNode.sampleStep == (byte) 0)
      {
        Vector3 position = wood.position;
        this.checkHitParticle(ref position);
      }
      if (woodNode.sampleStep < (byte) 3)
      {
        woodNode.timeStep = 0.0f;
        ++woodNode.sampleStep;
        wood.localPosition = woodNode.SamplePoint2;
        woodNode.SamplePoint1 = wood.localPosition;
        woodNode.SamplePoint2 += this.woodSamplePoint[(int) woodNode.sampleStep];
        woodNode.CurveHeight = woodNode.sampleStep < (byte) 3 ? Vector3.Distance(woodNode.SamplePoint1, woodNode.SamplePoint2) * 0.4f : 0.0f;
      }
      else
      {
        woodNode.activeState = (byte) 5;
        return false;
      }
    }
    this.UpdateSampleControl(ref woodNode);
    wood.localPosition = this.Evaluate(deltaTime, ref woodNode);
    woodNode.timeStep += deltaTime;
    return true;
  }

  public override void Update(Transform[] suprs, float deltaTime)
  {
    if (this.trapState == (byte) 0)
      return;
    if (this.trapState == (byte) 1)
    {
      for (int index = 0; index < (int) this.UnitCount; ++index)
      {
        suprs[index].localPosition = this.oriPos[index];
        if (suprs[index].gameObject.activeSelf)
          suprs[index].gameObject.SetActive(false);
        this.woodController[index] = new WoodRun.WoodNode();
        this.InitNode(ref this.woodController[index], suprs[index]);
        this.woodController[index].delay = Random.Range(0.0f, 0.5f);
      }
      this.targetPosCache.Clear();
      this.trapState = (byte) 2;
    }
    else
    {
      if (this.trapState != (byte) 2)
        return;
      byte num = 0;
      for (int index = 0; index < (int) this.UnitCount; ++index)
      {
        if (this.woodController[index].activeState == (byte) 1)
        {
          this.woodController[index].timeStep += deltaTime;
          if ((double) this.woodController[index].timeStep >= (double) this.woodController[index].delay)
          {
            suprs[index].gameObject.SetActive(true);
            this.woodController[index].timeStep = 0.0f;
            this.woodController[index].activeState = (byte) 2;
          }
        }
        else if (this.UpdateNode(deltaTime, ref this.woodController[index], suprs[index]))
          suprs[index].Rotate(Vector3.right, this.RotateSpeed[(int) this.woodController[index].sampleStep] * deltaTime, Space.Self);
        else
          ++num;
      }
      if ((int) num != (int) this.UnitCount)
        return;
      this.trapState = (byte) 0;
    }
  }

  public struct WoodNode
  {
    public byte activeState;
    public float timeStep;
    public float CurveHeight;
    public Vector3 SamplePoint1;
    public Vector3 SamplePoint2;
    public Vector3 SampleControl1;
    public Vector3 SampleControl2;
    public byte sampleStep;
    public float delay;
  }
}
