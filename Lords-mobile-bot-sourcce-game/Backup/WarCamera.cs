// Decompiled with JetBrains decompiler
// Type: WarCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class WarCamera
{
  private const float minDis = 35f;
  private const float maxDis = 55f;
  private const float minXAngles = 33.75f;
  private const float maxXAngles = 40f;
  private const float minMoveDis = 2f;
  private const float maxMoveDis = 10f;
  private const float minMoveSpeed = 0.1f;
  private const float maxMoveSpeed = 10f;
  private float distance;
  private Vector3 targetPos;
  private Transform CameraTransform;
  private float Weights_Play = 1f;
  private float Weights_Enemy = 0.8f;
  private float Y_Angles = 45f;
  private float FinISHINGMoveSpeed = 1f;
  private byte CameraModel;
  private Vector3 ViewportBoundPoint = Vector3.zero;
  private WarManager WM;
  private bool bFINISHING;
  public bool bIgnoreCatapults = true;
  public bool bShaking;
  public float ShakingTimer;
  private Vector3 CoordModeCamPos = new Vector3(54.83f, 66.55f, -31.93f);
  private Vector3 CoordModeCamLookAt = new Vector3(54.83f, 0.0f, 6.5f);
  private Vector3 Coord_CamEndPos = Vector3.zero;
  private Vector2 ScreenSize = Vector2.zero;
  private float BeginDist;
  public bool bCoordCamMode;
  public int CoordCamStatus;
  private byte mCount;

  public bool Shake
  {
    set
    {
      this.bShaking = value;
      if (!value)
        return;
      this.ShakingTimer = 0.2f;
    }
  }

  public bool CoordCamMode
  {
    get => this.bCoordCamMode;
    set
    {
      if (value && !this.bCoordCamMode)
        this.CoordCamStatus = 0;
      this.bCoordCamMode = value;
    }
  }

  private float LinearInterpolation(
    Vector2 XInterval,
    Vector2 YInterval,
    float XValue,
    bool bLimit = true)
  {
    if (bLimit)
    {
      if ((double) XInterval.x < (double) XInterval.y)
      {
        if ((double) XValue > (double) XInterval.y)
          return YInterval.y;
        if ((double) XValue < (double) XInterval.x)
          return YInterval.x;
      }
      else
      {
        if ((double) XValue > (double) XInterval.x)
          return YInterval.x;
        if ((double) XValue < (double) XInterval.y)
          return YInterval.y;
      }
    }
    return YInterval.x + (float) (((double) XValue - (double) XInterval.x) * ((double) YInterval.y - (double) YInterval.x) / ((double) XInterval.y - (double) XInterval.x));
  }

  public void initCamera(ArmyGroup[] player, int playerCt, ArmyGroup[] enemy, int enemyCt)
  {
    this.distance = 55f;
    this.targetPos = Vector3.zero;
    this.CameraTransform = Camera.main.transform;
    Camera.main.fieldOfView = 60f;
    this.WM = GameManager.ActiveGameplay as WarManager;
    if (this.WM != null)
    {
      this.CameraModel = this.WM.CameraModel;
      if (this.CameraModel == (byte) 0)
      {
        this.Weights_Play = 1f;
        this.Weights_Enemy = 1f;
        this.Y_Angles = 45f;
      }
      else
      {
        this.Weights_Play = 1f;
        this.Weights_Enemy = 1f;
        this.Y_Angles = 315f;
      }
    }
    this.CameraTransform.rotation = Quaternion.identity with
    {
      eulerAngles = new Vector3(55f, this.Y_Angles, 0.0f)
    };
    if (this.bFINISHING)
    {
      this.targetPos = this.ViewportBoundPoint;
      this.CameraTransform.position = this.targetPos;
      this.CameraTransform.position += this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin((float) ((double) this.CameraTransform.eulerAngles.x / 180.0 * 3.1415927410125732));
    }
    else
    {
      int num1 = 0;
      if (player != null)
      {
        int num2 = playerCt;
        for (int index = 0; index < num2; ++index)
        {
          if (player[index].groupRoot.gameObject.activeSelf && player[index].CurHP != 0 && (player[index].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
          {
            this.targetPos += player[index].groupRoot.position;
            ++num1;
          }
        }
      }
      if (enemy != null)
      {
        for (int index = 0; index < enemyCt; ++index)
        {
          if (enemy[index].groupRoot.gameObject.activeSelf && enemy[index].CurHP != 0 && (enemy[index].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
          {
            this.targetPos += enemy[index].groupRoot.position;
            ++num1;
          }
        }
      }
      if (num1 > 0)
      {
        this.targetPos /= (float) num1;
        this.CameraTransform.position = this.targetPos;
        this.CameraTransform.position += this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin((float) ((double) this.CameraTransform.eulerAngles.x / 180.0 * 3.1415927410125732));
      }
      this.ScreenSize = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
    }
  }

  public void updateCamera(ArmyGroup[] player, int playerCt, ArmyGroup[] enemy, int enemyCt)
  {
    if (this.bCoordCamMode)
      this.updateCameraCoordTestMode(player, playerCt, enemy, enemyCt);
    else if (this.mCount < (byte) 2)
    {
      ++this.mCount;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int index1 = 0;
      Vector3 zero = Vector3.zero;
      if (player != null)
      {
        for (num1 = playerCt; index1 < num1; ++index1)
        {
          if (player[index1].groupRoot.gameObject.activeSelf && player[index1].CurHP != 0 && (player[index1].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
          {
            zero += Camera.main.WorldToScreenPoint(player[index1].groupRoot.position) * this.Weights_Play;
            ++num3;
          }
        }
      }
      if (enemy != null)
      {
        num2 = enemyCt;
        for (int index2 = 0; index2 < num2; ++index2)
        {
          if (enemy[index2].groupRoot.gameObject.activeSelf && enemy[index2].CurHP != 0 && (enemy[index2].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
          {
            zero += Camera.main.WorldToScreenPoint(enemy[index2].groupRoot.position) * this.Weights_Enemy;
            ++num3;
          }
        }
      }
      if (num3 > 0)
      {
        Vector3 position = zero / (float) num3;
        Vector3 b = !this.bFINISHING ? Camera.main.ScreenToWorldPoint(position) - this.targetPos : this.ViewportBoundPoint - this.targetPos;
        float XValue = Vector2.Distance(Vector2.zero, (Vector2) b);
        float num4 = this.LinearInterpolation(new Vector2(2f, 10f), new Vector2(0.1f, 10f), XValue);
        float num5 = (double) num4 > 0.10000000149011612 ? num4 : 0.0f;
        if (this.bFINISHING)
          num5 *= this.FinISHINGMoveSpeed;
        float num6 = num5 * Time.smoothDeltaTime;
        if ((double) XValue < (double) num6)
        {
          this.targetPos += b;
        }
        else
        {
          b.Normalize();
          this.targetPos += b * num6;
        }
        this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / (float) Math.Sin((double) this.CameraTransform.eulerAngles.x * (Math.PI / 180.0));
        if (this.bFINISHING)
        {
          if ((double) this.distance > 35.0)
          {
            this.distance += (float) ((double) Time.smoothDeltaTime * 22.0 * -1.0);
            if ((double) this.distance < 35.0)
              this.distance = 35f;
          }
          this.CameraTransform.rotation = Quaternion.identity with
          {
            eulerAngles = new Vector3(55f, this.Y_Angles, 0.0f)
          };
          this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / (float) Math.Sin((double) this.CameraTransform.eulerAngles.x * (Math.PI / 180.0));
          return;
        }
        int num7 = num1 - 1;
        int num8 = num2 - 1;
        float num9 = 0.5f;
        float num10 = num9;
        float num11 = 0.5f;
        float num12 = num11;
        Vector3 viewportPoint;
        for (int index3 = num7; index3 > -1; --index3)
        {
          if (player[index3].groupRoot.gameObject.activeSelf && (player[index3].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
          {
            viewportPoint = Camera.main.WorldToViewportPoint(player[index3].groupRoot.position);
            if ((double) viewportPoint.x > (double) num9)
              num9 = viewportPoint.x;
            if ((double) viewportPoint.x < (double) num10)
              num10 = viewportPoint.x;
            if ((double) viewportPoint.y < (double) num11)
              num11 = viewportPoint.y;
            if ((double) viewportPoint.y > (double) num12)
              num12 = viewportPoint.y;
          }
        }
        for (int index4 = num8; index4 > -1; --index4)
        {
          if (enemy[index4].groupRoot.gameObject.activeSelf && (enemy[index4].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
          {
            viewportPoint = Camera.main.WorldToViewportPoint(enemy[index4].groupRoot.position);
            if ((double) viewportPoint.x > (double) num9)
              num9 = viewportPoint.x;
            if ((double) viewportPoint.x < (double) num10)
              num10 = viewportPoint.x;
            if ((double) viewportPoint.y < (double) num11)
              num11 = viewportPoint.y;
            if ((double) viewportPoint.y > (double) num12)
              num12 = viewportPoint.y;
          }
        }
        float num13 = Math.Abs(0.5f - num10);
        float num14 = Math.Abs(0.5f - num11);
        float num15 = Math.Abs(0.5f - num9);
        float num16 = Math.Abs(0.5f - num12);
        float num17 = num13;
        if ((double) num15 > (double) num17)
          num17 = num15;
        if ((double) num16 > (double) num17)
          num17 = num16;
        if ((double) num14 > (double) num17)
          num17 = num14;
        float num18 = num17 * 2f;
        if ((double) Math.Abs(num18 - 1f) > 0.0099999997764825821)
        {
          if ((double) this.distance >= 35.0)
          {
            this.distance += (float) ((double) Time.smoothDeltaTime * 22.0 * ((double) num18 - 1.0));
            if ((double) this.distance < 35.0)
              this.distance = 35f;
          }
          this.CameraTransform.rotation = Quaternion.identity with
          {
            eulerAngles = new Vector3(55f, this.Y_Angles, 0.0f)
          };
          this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / (float) Math.Sin((double) this.CameraTransform.eulerAngles.x * (Math.PI / 180.0));
        }
      }
      if (!this.bShaking)
        return;
      this.ShakingTimer -= Time.deltaTime;
      if ((double) this.ShakingTimer <= 0.0)
      {
        this.bShaking = false;
      }
      else
      {
        float num19 = Mathf.PerlinNoise(Time.time * 100f, 0.0f) * 2f;
        float num20 = Mathf.PerlinNoise(0.0f, Time.time * 100f) * 2f;
        this.CameraTransform.position += this.CameraTransform.rotation * new Vector3(0.0f, 1f - num19, 0.0f);
      }
    }
    else
      this.mCount = (byte) 0;
  }

  public void SetTargetPosition(Vector3 mTargetposition, bool bFinished = true, float fSpeed = 1)
  {
    this.bFINISHING = bFinished;
    this.ViewportBoundPoint = mTargetposition;
    this.FinISHINGMoveSpeed = fSpeed;
  }

  public void updateCameraCoordTestMode(
    ArmyGroup[] player,
    int playerCt,
    ArmyGroup[] enemy,
    int enemyCt)
  {
    if (this.CoordCamStatus == 0)
    {
      this.CameraTransform.position = Vector3.MoveTowards(this.CameraTransform.position, this.CoordModeCamPos, Time.deltaTime * 40f);
      this.CameraTransform.LookAt(this.CoordModeCamLookAt);
      if ((double) Vector3.Distance(this.CameraTransform.position, this.CoordModeCamPos) > 9.9999997473787516E-05)
        return;
      this.CoordCamStatus = 1;
      this.Coord_CamEndPos = this.CameraTransform.position + this.CameraTransform.forward * 100f;
      this.BeginDist = Vector3.Distance(this.CameraTransform.position, this.Coord_CamEndPos);
    }
    else
    {
      int index1 = 0;
      RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
      bool flag = true;
      if (player != null)
      {
        for (int index2 = playerCt; index1 < index2; ++index1)
        {
          if (player[index1].groupRoot.gameObject.activeSelf && player[index1].CurHP != 0 && player[index1].GroupKind != EGroupKind.Catapults)
          {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(player[index1].groupRoot.position);
            if ((double) screenPoint.x < 60.0 || (double) screenPoint.x > (double) this.ScreenSize.x - 60.0 || (double) screenPoint.y < 0.0 || (double) screenPoint.y > (double) this.ScreenSize.y)
              flag = false;
          }
        }
      }
      if (enemy != null)
      {
        int num = enemyCt;
        for (int index3 = 0; index3 < num; ++index3)
        {
          if (enemy[index3].groupRoot.gameObject.activeSelf && enemy[index3].CurHP != 0 && enemy[index3].GroupKind != EGroupKind.Catapults)
          {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(enemy[index3].groupRoot.position);
            if ((double) screenPoint.x < 60.0 || (double) screenPoint.x > (double) this.ScreenSize.x - 60.0 || (double) screenPoint.y < 0.0 || (double) screenPoint.y > (double) this.ScreenSize.y)
              flag = false;
          }
        }
      }
      if (!flag)
        return;
      this.CameraTransform.position = Vector3.MoveTowards(this.CameraTransform.position, this.Coord_CamEndPos, Time.deltaTime * (float) ((double) Vector3.Distance(this.CameraTransform.position, this.Coord_CamEndPos) / (double) this.BeginDist * 10.0));
    }
  }

  public float GetDistForScreenSize(Vector3 ViewportPoint)
  {
    RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
    return Mathf.Min(Mathf.Max((float) (56.0 + (1.7777777910232544 - (double) canvasRt.sizeDelta.x / (double) canvasRt.sizeDelta.y) * 2.2500002384185791 * 14.0), 56f), 70f);
  }
}
