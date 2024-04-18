// Decompiled with JetBrains decompiler
// Type: BattleCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class BattleCamera
{
  private const float maxDis = 12f;
  private const float maxXAngles = 45f;
  private const float minMoveDis = 2f;
  private const float maxMoveDis = 10f;
  private const float minMoveSpeed = 0.1f;
  private const float maxMoveSpeed = 1f;
  private float distance;
  private Vector3 targetPos;
  private Transform CameraTransform;
  private float minDis = 6f;
  public float minXAngles = 33.75f;
  private Hero sHero;
  private DataManager DM;
  private float Weights_Play = 1f;
  private float Weights_Enemy = 0.75f;
  private float Y_Angles = 45f;
  private byte CameraModel;
  private BattleController bc;
  private byte mCount;

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

  public void initCamera(AnimationUnit[] player, int playerCt, AnimationUnit[] enemy, int enemyCt)
  {
    this.distance = 12f;
    this.targetPos = Vector3.zero;
    this.CameraTransform = Camera.main.transform;
    Camera.main.fieldOfView = 60f;
    this.bc = GameManager.ActiveGameplay as BattleController;
    if (this.bc != null)
    {
      this.CameraModel = BattleController.CameraModel;
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
    if (NewbieManager.IsNewbie)
    {
      this.Weights_Enemy = 4f;
      this.minXAngles = 30.75f;
    }
    else if (this.bc.BattleType == EBattleType.PLAYBACK)
    {
      this.Weights_Enemy = 1f;
      this.minXAngles = 30.75f;
      MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GUIManager.Instance.WM_MonsterID);
      if (recordByKey.CameraHeight != (ushort) 0)
        this.minDis = (float) recordByKey.CameraHeight * 0.01f;
    }
    else if (this.bc.IsType(EBattleType.GAMBLE))
    {
      this.Weights_Enemy = 1f;
      this.minXAngles = 30.75f;
      MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID);
      if (recordByKey.CameraHeight != (ushort) 0)
        this.minDis = (float) recordByKey.CameraHeight * 0.01f;
    }
    float x = this.LinearInterpolation(new Vector2(this.minDis, 12f), (Vector2) new Vector3(0.1f, 45f), this.distance);
    this.CameraTransform.rotation = Quaternion.identity with
    {
      eulerAngles = new Vector3(x, this.Y_Angles, 0.0f)
    };
    int num1 = 0;
    this.DM = DataManager.Instance;
    if (player != null)
    {
      int num2 = Mathf.Min(playerCt, 5);
      for (int index = 0; index < num2; ++index)
      {
        if (player[index].gameObject.activeSelf)
        {
          this.targetPos += player[index].transform.position;
          ++num1;
        }
      }
    }
    if (enemy != null)
    {
      for (int index = 0; index < enemyCt; ++index)
      {
        if (enemy[index].gameObject.activeSelf)
        {
          this.targetPos += enemy[index].transform.position;
          ++num1;
        }
      }
    }
    if (num1 <= 0)
      return;
    this.targetPos /= (float) num1;
    this.CameraTransform.position = this.targetPos;
    this.CameraTransform.position += this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin((float) ((double) this.CameraTransform.eulerAngles.x / 180.0 * 3.1415927410125732));
  }

  public void updateCamera(
    AnimationUnit[] player,
    int playerCt,
    AnimationUnit[] enemy,
    int enemyCt)
  {
    if (this.mCount < (byte) 10)
    {
      ++this.mCount;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int b1 = 5;
      int index1 = 0;
      Vector3 zero1 = Vector3.zero;
      Vector3 zero2 = Vector3.zero;
      if (player != null)
      {
        for (num1 = Mathf.Min(playerCt, b1); index1 < num1; ++index1)
        {
          if (player[index1].gameObject.activeSelf)
          {
            zero1 += Camera.main.WorldToScreenPoint(player[index1].transform.position) * this.Weights_Play;
            ++num3;
          }
        }
      }
      if (enemy != null)
      {
        num2 = enemyCt;
        for (int index2 = 0; index2 < num2; ++index2)
        {
          if (enemy[index2].gameObject.activeSelf)
          {
            zero1 += Camera.main.WorldToScreenPoint(enemy[index2].transform.position) * this.Weights_Enemy;
            ++num3;
          }
        }
      }
      if (num3 <= 0)
        return;
      Vector3 b2 = Camera.main.ScreenToWorldPoint(zero1 / (float) num3) - this.targetPos;
      float XValue = Vector3.Distance(Vector3.zero, b2);
      float num4 = this.LinearInterpolation(new Vector2(2f, 10f), (Vector2) new Vector3(1f, 0.1f), XValue) * Time.smoothDeltaTime;
      if ((double) XValue < (double) num4)
      {
        this.targetPos += b2;
      }
      else
      {
        b2.Normalize();
        this.targetPos += b2 * num4;
      }
      this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin((float) ((double) this.CameraTransform.eulerAngles.x / 180.0 * 3.1415927410125732));
      int num5 = num1 - 1;
      int num6 = num2 - 1;
      float num7 = 0.5f;
      float num8 = num7;
      float num9 = 0.5f;
      float num10 = num9;
      Vector3 viewportPoint;
      for (int index3 = num5; index3 > -1; --index3)
      {
        if (player[index3].gameObject.activeSelf)
        {
          this.sHero = this.DM.HeroTable.GetRecordByKey(player[index3].NpcID);
          float num11 = (float) this.sHero.Radius * 0.01f;
          zero2.Set(player[index3].transform.position.x + num11, player[index3].transform.position.y, player[index3].transform.position.z);
          viewportPoint = Camera.main.WorldToViewportPoint(zero2);
          if ((double) viewportPoint.x > (double) num7)
            num7 = viewportPoint.x;
          zero2.Set(player[index3].transform.position.x - num11, player[index3].transform.position.y, player[index3].transform.position.z);
          viewportPoint = Camera.main.WorldToViewportPoint(zero2);
          if ((double) viewportPoint.x < (double) num8)
            num8 = viewportPoint.x;
          viewportPoint = Camera.main.WorldToViewportPoint(player[index3].transform.position);
          if ((double) viewportPoint.y < (double) num9)
            num9 = viewportPoint.y;
          float num12 = (float) this.sHero.Height * 0.01f;
          zero2.Set(player[index3].transform.position.x, player[index3].transform.position.y + num12, player[index3].transform.position.z);
          viewportPoint = Camera.main.WorldToViewportPoint(zero2);
          if ((double) viewportPoint.y > (double) num10)
            num10 = viewportPoint.y;
        }
      }
      for (int index4 = num6; index4 > -1; --index4)
      {
        if (enemy[index4].gameObject.activeSelf)
        {
          this.sHero = this.DM.HeroTable.GetRecordByKey(enemy[index4].NpcID);
          float num13 = (float) this.sHero.Radius * 0.01f;
          zero2.Set(enemy[index4].transform.position.x + num13, enemy[index4].transform.position.y, enemy[index4].transform.position.z);
          viewportPoint = Camera.main.WorldToViewportPoint(zero2);
          if ((double) viewportPoint.x > (double) num7)
            num7 = viewportPoint.x;
          zero2.Set(enemy[index4].transform.position.x - num13, enemy[index4].transform.position.y, enemy[index4].transform.position.z);
          viewportPoint = Camera.main.WorldToViewportPoint(zero2);
          if ((double) viewportPoint.x < (double) num8)
            num8 = viewportPoint.x;
          viewportPoint = Camera.main.WorldToViewportPoint(enemy[index4].transform.position);
          if ((double) viewportPoint.y < (double) num9)
            num9 = viewportPoint.y;
          float num14 = (float) this.sHero.Height * 0.01f;
          zero2.Set(enemy[index4].transform.position.x, enemy[index4].transform.position.y + num14, enemy[index4].transform.position.z);
          viewportPoint = Camera.main.WorldToViewportPoint(zero2);
          if ((double) viewportPoint.y > (double) num10)
            num10 = viewportPoint.y;
        }
      }
      float num15 = Mathf.Abs(0.5f - num8) * 1.3f;
      float num16 = Mathf.Abs(0.5f - num9) * 1.3f;
      float num17 = Mathf.Abs(0.5f - num7) * 1.3f;
      float num18 = Mathf.Abs(0.5f - num10);
      float num19 = num15;
      if ((double) num17 > (double) num19)
        num19 = num17;
      if ((double) num18 > (double) num19)
        num19 = num18;
      if ((double) num16 > (double) num19)
        num19 = num16;
      float num20 = num19 * 2f;
      if ((double) Mathf.Abs(num20 - 1f) <= 0.0099999997764825821)
        return;
      if ((double) this.distance >= (double) this.minDis)
      {
        this.distance += (float) ((double) Time.smoothDeltaTime * 22.0 * ((double) num20 - 1.0));
        if ((double) this.distance < (double) this.minDis)
          this.distance = this.minDis;
        else if ((double) this.distance >= 12.0)
          this.distance = 12f;
      }
      float x = this.LinearInterpolation(new Vector2(this.minDis, 12f), (Vector2) new Vector3(this.minXAngles, 45f), this.distance);
      this.CameraTransform.rotation = Quaternion.identity with
      {
        eulerAngles = new Vector3(x, this.Y_Angles, 0.0f)
      };
      this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin((float) ((double) this.CameraTransform.eulerAngles.x / 180.0 * 3.1415927410125732));
    }
    else
      this.mCount = (byte) 0;
  }
}
