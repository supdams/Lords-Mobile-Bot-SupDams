// Decompiled with JetBrains decompiler
// Type: LandWalker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class LandWalker
{
  public ushort idx;
  public Vector3 startPos;
  public Vector3 endPos;
  public SheetAnimationUnitGroup movingUnit;
  public float EndFadePoint;
  public float StartFadePoint;
  public float nowTime;
  public float totalTime;
  public short weight;
  public bool changeOrder;
  public bool overTop;

  public LandWalker(Transform transform)
  {
    this.movingUnit = new SheetAnimationUnitGroup();
    this.movingUnit.transform.parent = (Transform) null;
    this.movingUnit.transform.parent = transform;
  }

  public void setUnit(ushort idx, byte block, bool forceFade = false)
  {
    this.idx = idx;
    LandWalkerData recordByIndex = DataManager.Instance.LandWalkerData.GetRecordByIndex((int) idx);
    this.startPos = GameConstants.HalfShortsToVector3(recordByIndex.Data[0], recordByIndex.Data[1], recordByIndex.Data[2]);
    this.endPos = GameConstants.HalfShortsToVector3(recordByIndex.Data[3], recordByIndex.Data[4], recordByIndex.Data[5]);
    this.totalTime = (float) recordByIndex.totalTime;
    this.nowTime = 0.0f;
    this.EndFadePoint = !forceFade ? (float) recordByIndex.fadeEnd / 100f : 0.2f;
    this.StartFadePoint = (float) (100 - (int) recordByIndex.fadeStart) / 100f;
    this.movingUnit.gameObject.transform.localPosition = this.startPos;
    this.movingUnit.gameObject.transform.localScale = new Vector3(6f, 6f, 6f);
    this.movingUnit.gameObject.SetActive(true);
    this.movingUnit.transform.localEulerAngles = Vector3.zero;
    this.movingUnit.setupLandAnimUnit(recordByIndex.GenData[(int) block].isEmemy, recordByIndex.GenData[(int) block].modelID, (int) recordByIndex.direction);
    this.movingUnit.transform.localEulerAngles = new Vector3(45f, 180f, 0.0f);
    switch (recordByIndex.SpriteSort)
    {
      case 0:
        this.movingUnit.SetSortOrder(-30);
        this.changeOrder = false;
        break;
      case 1:
        this.movingUnit.SetSortOrder(-30);
        this.changeOrder = true;
        this.overTop = false;
        break;
      case 2:
        this.movingUnit.SetSortOrder(-60);
        this.changeOrder = true;
        this.overTop = true;
        break;
      case 3:
        this.movingUnit.SetSortOrder(-60);
        this.changeOrder = false;
        break;
    }
    if ((double) this.EndFadePoint == 0.0)
      return;
    this.movingUnit.SetColor(new Color(1f, 1f, 1f, 0.0f));
  }

  public void update(float deltaTime)
  {
    if (this.movingUnit == null)
      return;
    this.movingUnit.Update(deltaTime);
    this.nowTime += deltaTime;
    if ((double) this.nowTime > (double) this.totalTime)
    {
      LandWalkerManager.EndAction(this);
    }
    else
    {
      float t = this.nowTime / this.totalTime;
      this.movingUnit.transform.localPosition = Vector3.Lerp(this.startPos, this.endPos, t);
      if ((double) t < (double) this.EndFadePoint)
        this.movingUnit.SetColor(new Color(1f, 1f, 1f, t / this.EndFadePoint));
      else if ((double) t > (double) this.StartFadePoint)
      {
        this.movingUnit.SetColor(new Color(1f, 1f, 1f, Mathf.InverseLerp(1f, this.StartFadePoint, t)));
      }
      else
      {
        this.movingUnit.SetColor(Color.white);
        if (!this.changeOrder)
          return;
        if (this.overTop)
          this.movingUnit.SetSortOrder(-30);
        else
          this.movingUnit.SetSortOrder(-60);
        this.changeOrder = false;
      }
    }
  }

  public void SetFade()
  {
    this.startPos = this.movingUnit.transform.localPosition;
    this.endPos = this.startPos;
    this.nowTime = 0.0f;
    this.totalTime = 0.8f;
    this.EndFadePoint = 0.0f;
    this.StartFadePoint = 0.0f;
  }

  public void destroy()
  {
  }
}
