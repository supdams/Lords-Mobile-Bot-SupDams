// Decompiled with JetBrains decompiler
// Type: ShitfHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
internal class ShitfHelper
{
  private const int MaxItem = 6;
  private float m_Time;
  private ShitfHelper.InitObj[] m_InitObj = new ShitfHelper.InitObj[6];
  private List<ShitfHelper.ShitfItemObj> m_ShiftList = new List<ShitfHelper.ShitfItemObj>();
  private int m_AddItemIdx;

  private void AddShift(RectTransform rect, int beginIdx, int targetIdx, float time = 0.05f)
  {
    ShitfHelper.ShitfItemObj shitfItemObj = new ShitfHelper.ShitfItemObj();
    shitfItemObj.Rect = rect;
    shitfItemObj.bMoving = true;
    shitfItemObj.BeginIdx = beginIdx;
    shitfItemObj.TargetIdx = targetIdx;
    shitfItemObj.MovingTime = time;
    if (this.m_ShiftList == null)
      return;
    this.m_ShiftList.Add(shitfItemObj);
  }

  public void Init(RectTransform[] Rect)
  {
    for (int index = 0; index < this.m_InitObj.Length && index < Rect.Length; ++index)
    {
      this.m_InitObj[index] = new ShitfHelper.InitObj();
      this.m_InitObj[index].Rect = Rect[index];
      this.m_InitObj[index].Postion = this.m_InitObj[index].Rect.anchoredPosition.x;
      this.m_InitObj[index].Idx = index;
      this.m_InitObj[index].Hint1 = ((Transform) Rect[index]).GetChild(0).GetComponent<UIButtonHint>();
      this.m_InitObj[index].Hint2 = ((Transform) Rect[index]).GetChild(1).GetComponent<UIButtonHint>();
    }
  }

  public void Start()
  {
    if (this.m_InitObj == null || this.m_ShiftList.Count != 0)
      return;
    int num = this.m_InitObj.Length - 1;
    for (int index = 0; index < this.m_InitObj.Length; ++index)
    {
      RectTransform rect = this.m_InitObj[index].Rect;
      if (this.m_InitObj[index].Idx < num)
      {
        this.AddShift(rect, this.m_InitObj[index].Idx, ++this.m_InitObj[index].Idx);
      }
      else
      {
        this.AddShift(rect, this.m_InitObj[index].Idx, 0, 0.0f);
        this.m_InitObj[index].Idx = 0;
        this.m_AddItemIdx = index;
      }
    }
    this.m_Time = 0.0f;
  }

  public void Update()
  {
    this.m_Time += Time.deltaTime;
    for (int index = 0; index < this.m_ShiftList.Count; ++index)
    {
      RectTransform rect = this.m_ShiftList[index].Rect;
      int beginIdx = this.m_ShiftList[index].BeginIdx;
      int targetIdx = this.m_ShiftList[index].TargetIdx;
      float x = (double) this.m_ShiftList[index].MovingTime > 0.0 ? Mathf.Lerp(this.m_InitObj[beginIdx].Postion, this.m_InitObj[targetIdx].Postion, this.m_Time / this.m_ShiftList[index].MovingTime) : Mathf.Lerp(this.m_InitObj[beginIdx].Postion, this.m_InitObj[targetIdx].Postion, 1f);
      rect.anchoredPosition = new Vector2(x, rect.anchoredPosition.y);
      if ((double) this.m_Time >= 0.5)
        this.m_ShiftList.RemoveAt(index);
    }
  }

  public int GetAddItemIdx() => this.m_AddItemIdx;

  private struct InitObj
  {
    public RectTransform Rect;
    public float Postion;
    public int Idx;
    public UIButtonHint Hint1;
    public UIButtonHint Hint2;
  }

  private struct ShitfItemObj
  {
    public bool bMoving;
    public RectTransform Rect;
    public int BeginIdx;
    public int TargetIdx;
    public float MovingTime;
  }
}
