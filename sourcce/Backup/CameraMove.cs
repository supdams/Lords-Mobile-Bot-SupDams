// Decompiled with JetBrains decompiler
// Type: CameraMove
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class CameraMove
{
  public Vector3 tmpPos;
  public Vector3 tmpCameraPos;
  public Vector2 m_PointerStartLocalCursor;
  public Vector3 m_ContentStartPosition;
  public Vector3 NextPos;
  public Vector3 TargetPos;
  public Vector3 mPos;
  public Vector3 AnglePos;
  public float mTime;
  public float speed;
  public float speed2;
  public float Distance;
  public float mBegin;
  public float tmp;
  public bool IsEndDrag;
  public bool IsGoNow;
  public bool IsOpenGoNow;
  public CameraState mState;
  public CameraState NextState;
  private Quaternion NextQuaternion;
  private Quaternion tmpQuaternion;
  public byte mLevel;
  public Vector2 pressPosition;
  public Vector2 pressPosition2;
  public Vector2 mPosition;
  public Vector2 mPosition2;
  public Vector3 TmpV3Pos;
  public Vector3 TmpV3Rot;
  private Chapter chapter;
  private float Dis;
  private float Dis2;
  private bool bMove;
  public float Limit;
  public byte IsBackEndDragX;
  public byte IsBackEndDragY;
  public float newVelocity;
  private float tmpTime1;
  private float tmpTime2;

  public CameraMove(CameraState in_cameraState)
  {
    this.CameraInit();
    int AreaLevel = 0;
    if (in_cameraState == CameraState.Area)
    {
      if (DataManager.StageDataController._stageMode == StageMode.Corps)
      {
        AreaLevel = (int) DataManager.StageDataController.StageRecord[2];
        if (DataManager.Instance.lastBattleResult != (short) 1)
          ++AreaLevel;
      }
      else
        AreaLevel = (int) DataManager.StageDataController.currentChapterID;
    }
    this.SetCameraPos(AreaLevel);
  }

  ~CameraMove()
  {
  }

  public void CameraInit()
  {
    Camera.main.fieldOfView = 25f;
    this.mPos = Camera.main.transform.position;
    this.tmpPos = Vector3.zero;
    this.NextPos = Vector3.zero;
    this.TargetPos = Vector3.zero;
    this.AnglePos = Vector3.zero;
    this.pressPosition = Vector2.zero;
    this.pressPosition2 = Vector2.zero;
    this.mTime = 0.0f;
    this.speed = 1f;
    this.mBegin = 0.0f;
    this.tmp = 0.0f;
    this.IsEndDrag = false;
    this.IsGoNow = false;
    this.Limit = DataManager.Instance.WorldCameraLimit;
    this.TmpV3Pos.Set(-11.938f, 181.12f, 204.91f);
    this.TmpV3Rot.Set(45f, 180f, 0.1f);
  }

  public void SetCameraState(CameraState state, byte LeveL = 0, bool GoNow = false)
  {
    if (this.NextState != this.mState)
      return;
    int mLevel = (int) this.mLevel;
    this.mLevel = LeveL;
    if (this.mLevel == (byte) 0)
    {
      if (state == CameraState.World && mLevel != 0)
      {
        this.chapter = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) mLevel);
        this.NextPos = GameConstants.WordToVector3(this.chapter.CameraPos.X, this.chapter.CameraPos.Y, this.chapter.CameraPos.Z);
        this.tmpPos = GameConstants.WordToVector3(this.chapter.CameraRot.X, this.chapter.CameraRot.Y, this.chapter.CameraRot.Z);
        float z = this.NextPos.z + this.TmpV3Pos.y - this.NextPos.y;
        if ((double) z < 110.0 + (double) this.Limit)
          z = 110f + this.Limit;
        else if ((double) z > 280.0 + (double) this.Limit * 0.5)
          z = (float) (280.0 + (double) this.Limit * 0.5);
        this.TmpV3Pos = new Vector3(this.NextPos.x, this.TmpV3Pos.y, z);
      }
      this.NextPos = this.TmpV3Pos;
      this.tmpPos = this.TmpV3Rot;
    }
    else
    {
      this.chapter = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) this.mLevel);
      this.NextPos = GameConstants.WordToVector3(this.chapter.CameraPos.X, this.chapter.CameraPos.Y, this.chapter.CameraPos.Z);
      this.tmpPos = GameConstants.WordToVector3(this.chapter.CameraRot.X, this.chapter.CameraRot.Y, this.chapter.CameraRot.Z);
    }
    this.NextQuaternion.eulerAngles = this.tmpPos;
    this.IsGoNow = GoNow;
    this.mPos = Camera.main.transform.position;
    this.tmpQuaternion = Camera.main.transform.rotation;
    if (this.IsGoNow && DataManager.StageDataController._stageMode == StageMode.Corps && DataManager.StageDataController.isNotFirstInChapter[2] == (byte) 0)
    {
      this.TargetPos = this.NextPos;
      this.IsOpenGoNow = true;
      this.IsGoNow = false;
      float z = this.NextPos.z + Camera.main.transform.position.y - this.NextPos.y;
      if ((double) z < 110.0 + (double) this.Limit)
        z = 110f + this.Limit;
      else if ((double) z > 280.0 + (double) this.Limit * 0.5)
        z = (float) (280.0 + (double) this.Limit * 0.5);
      this.NextPos = new Vector3(this.NextPos.x, Camera.main.transform.position.y, z);
      this.TmpV3Pos = this.NextPos;
      this.NextPos -= this.mPos;
    }
    else if (!this.IsGoNow)
    {
      this.NextPos -= this.mPos;
    }
    else
    {
      this.TargetPos = this.NextPos;
      this.NextPos.Set(this.NextPos.x - this.mPos.x, 0.0f, 0.0f);
      this.mBegin = 0.0f;
      this.Distance = 0.0f;
    }
    this.mTime = 0.0f;
    this.speed = 2f;
    this.speed2 = 0.0f;
    this.NextState = state;
    this.AnglePos = this.NextQuaternion.eulerAngles - this.tmpQuaternion.eulerAngles;
    if (state == this.mState)
      return;
    DataManager.msgBuffer[0] = (byte) 46;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.msgBuffer[0] = (byte) 42;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void CameraMoveTarget(CameraState state, Vector3 TargetPosition)
  {
    if (this.NextState != this.mState)
      return;
    this.mPos = Camera.main.transform.position;
    this.tmpQuaternion = Camera.main.transform.rotation;
    if ((double) TargetPosition.x >= 250.0 - (double) this.Limit * 0.40000000596046448)
      TargetPosition.x = (float) (250.0 - (double) this.Limit * 0.40000000596046448);
    else if ((double) TargetPosition.x <= (double) this.Limit * 0.34999999403953552 - 315.0)
      TargetPosition.x = (float) ((double) this.Limit * 0.34999999403953552 - 315.0);
    float num = TargetPosition.z + (this.mPos.y - TargetPosition.y);
    if ((double) num >= 280.0 + (double) this.Limit * 0.5)
      num = (float) (280.0 + (double) this.Limit * 0.5);
    else if ((double) num <= 110.0 + (double) this.Limit)
      num = 110f + this.Limit;
    this.NextPos.Set(TargetPosition.x - this.mPos.x, 0.0f, num - this.mPos.z);
    this.AnglePos = (Vector3) Vector2.zero;
    this.mTime = 0.0f;
    this.speed = 2f;
    this.speed2 = 0.0f;
    this.NextState = state;
  }

  public void SetCameraPos(int AreaLevel)
  {
    if (AreaLevel == 0)
    {
      this.mState = CameraState.World;
      this.NextState = CameraState.World;
      Camera.main.transform.eulerAngles = this.TmpV3Rot;
      Camera.main.transform.position = this.TmpV3Pos;
    }
    else
    {
      this.mState = CameraState.Area;
      this.NextState = CameraState.Area;
      this.chapter = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) AreaLevel);
      Camera.main.transform.eulerAngles = GameConstants.WordToVector3(this.chapter.CameraRot.X, this.chapter.CameraRot.Y, this.chapter.CameraRot.Z);
      Camera.main.transform.position = GameConstants.WordToVector3(this.chapter.CameraPos.X, this.chapter.CameraPos.Y, this.chapter.CameraPos.Z);
    }
    this.mLevel = (byte) AreaLevel;
  }

  public void SetCamerPos_Out()
  {
    this.mState = CameraState.World;
    this.NextState = CameraState.World;
    Camera.main.transform.localPosition = DataManager.Instance.WorldCameraTransitionsPos;
    Camera.main.transform.eulerAngles = this.TmpV3Rot;
    this.Limit = DataManager.Instance.WorldCameraLimit;
  }

  public void CameraUpdata()
  {
    Transform transform = Camera.main.transform;
    if (this.mState != this.NextState)
    {
      if (this.IsGoNow)
      {
        if ((double) Time.smoothDeltaTime > (double) this.Distance)
          this.Distance = Time.smoothDeltaTime;
        if ((double) this.NextPos.x > 0.0)
          this.mBegin += 100f * this.Distance;
        else
          this.mBegin -= 100f * this.Distance;
        if ((double) Mathf.Abs(this.mBegin) > (double) Mathf.Abs(this.NextPos.x))
        {
          this.mBegin = this.NextPos.x;
          this.mTime = 0.0f;
          this.Distance = 0.0f;
          this.IsGoNow = false;
          this.tmpPos = this.mPos + this.NextPos;
          transform.position = this.tmpPos;
          this.mPos = transform.position;
          this.NextPos = this.TargetPos - this.mPos;
          this.TmpV3Pos = this.mPos;
          DataManager.msgBuffer[0] = (byte) 10;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          return;
        }
        this.tmpPos.Set(this.mPos.x + this.mBegin, this.mPos.y, this.mPos.z);
      }
      else
      {
        this.mTime += Time.smoothDeltaTime;
        if (this.IsOpenGoNow)
        {
          this.speed -= this.Limit / 100f;
          this.tmp = this.mTime * this.speed;
        }
        else
          this.tmp = this.mTime * (this.speed - this.Limit / 100f);
        if ((double) this.tmp > 0.99000000953674316)
        {
          this.tmp = 1f;
          if (this.NextState == CameraState.Area)
          {
            if (this.IsOpenGoNow)
            {
              this.speed = 0.5f;
              this.mTime = 0.0f;
              this.IsOpenGoNow = false;
              this.tmpPos = this.mPos + this.tmp * this.NextPos;
              transform.position = this.tmpPos;
              this.mPos = transform.position;
              this.NextPos = this.TargetPos - this.mPos;
              DataManager.msgBuffer[0] = (byte) 10;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              return;
            }
            this.mState = CameraState.Area;
            DataManager.msgBuffer[0] = (byte) 8;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
          else if (this.NextState == CameraState.World)
          {
            this.mState = CameraState.World;
            DataManager.msgBuffer[0] = (byte) 19;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
          else if (this.mState == CameraState.World)
          {
            this.mState = CameraState.World;
            this.NextState = CameraState.World;
          }
          else
          {
            this.mState = CameraState.Area;
            this.NextState = CameraState.Area;
          }
        }
        if (!this.IsOpenGoNow)
        {
          this.tmpPos = this.tmpQuaternion.eulerAngles + this.tmp * this.AnglePos;
          this.NextQuaternion.eulerAngles = this.tmpPos;
          transform.rotation = this.NextQuaternion;
        }
        this.tmpPos = this.mPos + this.tmp * this.NextPos;
      }
      transform.position = this.tmpPos;
    }
    else
    {
      if (this.mState != CameraState.World)
        return;
      if (this.IsEndDrag)
      {
        if (this.IsBackEndDragX > (byte) 0)
        {
          this.tmpTime1 += Time.smoothDeltaTime;
          this.speed *= Mathf.Pow(0.8f, this.tmpTime1);
          if ((double) Mathf.Abs(this.speed) < 1.0)
          {
            this.speed = 0.0f;
            this.IsBackEndDragX = (byte) 0;
          }
        }
        else
        {
          this.speed *= Mathf.Pow(0.135f, this.mTime);
          if ((double) Mathf.Abs(this.speed) < 1.0)
            this.speed = 0.0f;
        }
        if (this.IsBackEndDragY > (byte) 0)
        {
          this.tmpTime2 += Time.smoothDeltaTime;
          this.speed2 *= Mathf.Pow(0.8f, this.tmpTime2);
          if ((double) Mathf.Abs(this.speed2) < 1.0)
          {
            this.speed2 = 0.0f;
            this.IsBackEndDragY = (byte) 0;
          }
        }
        else
        {
          this.speed2 *= Mathf.Pow(0.135f, this.mTime);
          if ((double) Mathf.Abs(this.speed2) < 1.0)
            this.speed2 = 0.0f;
        }
        if ((double) this.speed != 0.0 || (double) this.speed2 != 0.0)
        {
          this.tmpPos.Set(this.speed * Time.smoothDeltaTime, 0.0f, this.speed2 * Time.smoothDeltaTime);
          transform.position += this.tmpPos;
        }
        else
          this.IsEndDrag = false;
      }
      else if (this.bMove)
      {
        this.speed = Mathf.Lerp(this.speed, (transform.position.x - this.tmpCameraPos.x) / Time.smoothDeltaTime, Time.smoothDeltaTime * 5f);
        this.speed2 = Mathf.Lerp(this.speed2, (transform.position.z - this.tmpCameraPos.z) / Time.smoothDeltaTime, Time.smoothDeltaTime * 5f);
      }
      if (this.IsBackEndDragX > (byte) 0)
      {
        if ((double) transform.position.x >= 265.0 - (double) this.Limit * 0.40000000596046448)
        {
          this.tmpPos.Set((float) (265.0 - (double) this.Limit * 0.40000000596046448), transform.position.y, transform.position.z);
          transform.position = this.tmpPos;
        }
        else if ((double) transform.position.x <= (double) this.Limit * 0.34999999403953552 - 330.0)
        {
          this.tmpPos.Set((float) ((double) this.Limit * 0.34999999403953552 - 330.0), transform.position.y, transform.position.z);
          transform.position = this.tmpPos;
        }
      }
      else if ((double) transform.position.x >= 250.0 - (double) this.Limit * 0.40000000596046448)
      {
        this.tmpPos.Set((float) (250.0 - (double) this.Limit * 0.40000000596046448), transform.position.y, transform.position.z);
        transform.position = this.tmpPos;
      }
      else if ((double) transform.position.x <= (double) this.Limit * 0.34999999403953552 - 315.0)
      {
        this.tmpPos.Set((float) ((double) this.Limit * 0.34999999403953552 - 315.0), transform.position.y, transform.position.z);
        transform.position = this.tmpPos;
      }
      if (this.IsBackEndDragY > (byte) 0)
      {
        if ((double) transform.position.z >= 295.0 + (double) this.Limit * 0.5)
        {
          this.tmpPos.Set(transform.position.x, transform.position.y, (float) (295.0 + (double) this.Limit * 0.5));
          transform.position = this.tmpPos;
        }
        else if ((double) transform.position.z <= 95.0 + (double) this.Limit)
        {
          this.tmpPos.Set(transform.position.x, transform.position.y, 95f + this.Limit);
          transform.position = this.tmpPos;
        }
      }
      else if ((double) transform.position.z >= 280.0 + (double) this.Limit * 0.5)
      {
        this.tmpPos.Set(transform.position.x, transform.position.y, (float) (280.0 + (double) this.Limit * 0.5));
        transform.position = this.tmpPos;
      }
      else if ((double) transform.position.z <= 110.0 + (double) this.Limit)
      {
        this.tmpPos.Set(transform.position.x, transform.position.y, 110f + this.Limit);
        transform.position = this.tmpPos;
      }
      if (!(this.tmpCameraPos != transform.position))
        return;
      this.tmpCameraPos = transform.position;
    }
  }

  public void OnBeginDrag(PointerEventData eventData)
  {
    if (this.NextState != this.mState || this.pressPosition != Vector2.zero && this.pressPosition2 != Vector2.zero && eventData.pointerId > 1)
      return;
    if (this.pressPosition == Vector2.zero)
    {
      this.pressPosition = eventData.pressPosition;
      this.mPosition = eventData.position;
    }
    else if (this.pressPosition != Vector2.zero && this.pressPosition2 == Vector2.zero)
    {
      this.pressPosition2 = eventData.pressPosition;
      this.mPosition2 = eventData.position;
    }
    this.speed = 0.0f;
    this.speed2 = 0.0f;
    this.IsEndDrag = false;
    if (this.mState != CameraState.World || this.mState != this.NextState || !(this.pressPosition2 == Vector2.zero))
      return;
    this.m_ContentStartPosition = Camera.main.transform.position;
    this.m_PointerStartLocalCursor = (Vector2) Camera.main.ScreenToViewportPoint((Vector3) eventData.position);
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (this.pressPosition != Vector2.zero && this.pressPosition2 != Vector2.zero && eventData.pointerId > 1 || this.pressPosition == Vector2.zero)
      return;
    Transform transform = Camera.main.transform;
    if (this.mState != CameraState.World || this.mState != this.NextState)
      return;
    if (this.pressPosition2 == Vector2.zero)
    {
      Vector2 vector2 = (Vector2) Camera.main.ScreenToViewportPoint((Vector3) eventData.position) - this.m_PointerStartLocalCursor;
      if (!this.bMove)
      {
        this.Dis = Vector2.Distance(eventData.position, eventData.pressPosition);
        if ((double) Mathf.Abs(this.Dis) >= 1.0)
          this.bMove = true;
        if (!this.bMove && (double) Mathf.Abs(vector2.x * 100f) < 1.0 && (double) Mathf.Abs(vector2.y * 100f) < 1.0)
          return;
      }
      this.tmpPos.Set(vector2.x * (float) (164.0 - 64.0 * (-(double) this.Limit / 100.0)), 0.0f, vector2.y * (float) (164.0 - 64.0 * (-(double) this.Limit / 100.0)));
      transform.position = this.m_ContentStartPosition + this.tmpPos;
      if ((double) eventData.position.x > (double) eventData.pressPosition.x && 250.0 - (double) this.Limit * 0.40000000596046448 - (double) this.m_ContentStartPosition.x <= 10.0)
        this.IsBackEndDragX = (byte) 1;
      else if ((double) eventData.pressPosition.x > (double) eventData.position.x && (double) this.m_ContentStartPosition.x - ((double) this.Limit * 0.34999999403953552 - 315.0) <= 10.0)
        this.IsBackEndDragX = (byte) 2;
      if ((double) eventData.position.y > (double) eventData.pressPosition.y && 280.0 + (double) this.Limit * 0.5 - (double) this.m_ContentStartPosition.z <= 10.0)
        this.IsBackEndDragY = (byte) 1;
      else if ((double) eventData.pressPosition.y > (double) eventData.position.y && (double) this.m_ContentStartPosition.z - (110.0 + (double) this.Limit) <= 10.0)
        this.IsBackEndDragY = (byte) 2;
      this.mTime = Time.smoothDeltaTime;
      this.mPosition = eventData.position;
    }
    else
    {
      if (!(eventData.pressPosition == this.pressPosition) && !(eventData.pressPosition == this.pressPosition2))
        return;
      this.Dis = Vector2.Distance(this.mPosition, this.mPosition2);
      if (eventData.pressPosition == this.pressPosition)
      {
        this.Dis2 = Vector2.Distance(eventData.position, this.mPosition2);
        this.mPosition = eventData.position;
      }
      else
      {
        this.Dis2 = Vector2.Distance(eventData.position, this.mPosition);
        this.mPosition2 = eventData.position;
      }
      float num = (float) (((double) this.Dis - (double) this.Dis2) * 0.20000000298023224);
      if ((double) this.Limit + (double) num >= 0.0)
      {
        num = 0.0f - this.Limit;
        this.Limit = 0.0f;
      }
      else if ((double) this.Limit + (double) num <= -100.0)
      {
        num = -100f - this.Limit;
        this.Limit = -100f;
      }
      else
        this.Limit += num;
      transform.position += transform.rotation * Vector3.back * num;
    }
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    if (this.pressPosition != Vector2.zero && this.pressPosition2 != Vector2.zero && eventData.pointerId > 1)
      return;
    if (this.mState == CameraState.World && this.mState == this.NextState)
    {
      if (eventData.pressPosition == this.pressPosition && this.pressPosition2 != Vector2.zero)
      {
        this.pressPosition = this.pressPosition2;
        this.pressPosition2 = Vector2.zero;
        this.mPosition = this.mPosition2;
        this.mPosition2 = Vector2.zero;
        this.m_ContentStartPosition = Camera.main.transform.position;
        this.m_PointerStartLocalCursor = (Vector2) Camera.main.ScreenToViewportPoint((Vector3) this.mPosition);
        this.mTime = 0.0f;
        this.speed = 0.0f;
        this.speed2 = 0.0f;
      }
      else if (eventData.pressPosition == this.pressPosition2)
      {
        this.pressPosition2 = Vector2.zero;
        this.mPosition2 = Vector2.zero;
        this.mTime = 0.0f;
        this.speed = 0.0f;
        this.speed2 = 0.0f;
        this.m_ContentStartPosition = Camera.main.transform.position;
        this.m_PointerStartLocalCursor = (Vector2) Camera.main.ScreenToViewportPoint((Vector3) this.mPosition);
      }
      else
      {
        this.pressPosition = Vector2.zero;
        this.mPosition = Vector2.zero;
      }
      this.IsEndDrag = true;
      this.bMove = false;
      this.IsBackEndDragX = (byte) 0;
      this.IsBackEndDragY = (byte) 0;
      this.tmpTime1 = 0.0f;
      this.tmpTime2 = 0.0f;
      Transform transform = Camera.main.transform;
      if (this.mState != CameraState.World)
        return;
      this.mTime = Time.smoothDeltaTime;
      if ((double) transform.position.x >= 250.0 - (double) this.Limit * 0.40000000596046448)
      {
        this.IsBackEndDragX = (byte) 1;
        this.newVelocity = ((float) (250.0 - (double) this.Limit * 0.40000000596046448) - transform.position.x) / this.mTime;
        this.speed = Mathf.Lerp(0.0f, this.newVelocity, this.mTime * 3.5f);
      }
      else if ((double) transform.position.x <= (double) this.Limit * 0.34999999403953552 - 315.0)
      {
        this.IsBackEndDragX = (byte) 2;
        this.newVelocity = ((float) ((double) this.Limit * 0.34999999403953552 - 315.0) - transform.position.x) / this.mTime;
        this.speed = Mathf.Lerp(0.0f, this.newVelocity, this.mTime * 3.5f);
      }
      if ((double) transform.position.z >= 280.0 + (double) this.Limit * 0.5)
      {
        this.IsBackEndDragY = (byte) 1;
        this.newVelocity = ((float) (280.0 + (double) this.Limit * 0.5) - transform.position.z) / this.mTime;
        this.speed2 = Mathf.Lerp(0.0f, this.newVelocity, this.mTime * 3.5f);
      }
      else
      {
        if ((double) transform.position.z > 110.0 + (double) this.Limit)
          return;
        this.IsBackEndDragY = (byte) 2;
        this.newVelocity = (110f + this.Limit - transform.position.z) / this.mTime;
        this.speed2 = Mathf.Lerp(0.0f, this.newVelocity, this.mTime * 3.5f);
      }
    }
    else
    {
      this.pressPosition = Vector2.zero;
      this.pressPosition2 = Vector2.zero;
    }
  }

  public void ReSetPressPosition()
  {
    this.pressPosition = Vector2.zero;
    this.pressPosition2 = Vector2.zero;
  }
}
