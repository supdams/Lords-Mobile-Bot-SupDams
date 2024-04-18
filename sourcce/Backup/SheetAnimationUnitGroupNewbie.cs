// Decompiled with JetBrains decompiler
// Type: SheetAnimationUnitGroupNewbie
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SheetAnimationUnitGroupNewbie : ISheetAnimationUnitGroup
{
  private const int MAX_SHEETANIM_UNIT = 18;
  public static Dictionary<uint, Sprite[]> AnimMap = new Dictionary<uint, Sprite[]>();
  public static List<SheetAnimationUnit> m_FreeList = new List<SheetAnimationUnit>(256);
  private static Material sharedMat = (Material) null;
  private SheetAnimationUnit[] animUnit = new SheetAnimationUnit[18];
  private int Count;
  public GameObject gameObject;
  public Transform transform;

  public SheetAnimationUnitGroupNewbie()
  {
    this.gameObject = new GameObject("AnimUnitGroupNewbie");
    this.transform = this.gameObject.transform;
  }

  public static void InitResource()
  {
    SheetAnimationUnitGroupNewbie.sharedMat = new Material(SheetAnimationUnitGroup.sharedMat);
    SheetAnimationUnitGroupNewbie.sharedMat.renderQueue = 3010;
    SheetAnimationUnitGroupNewbie.AnimMap = SheetAnimationUnitGroup.AnimMap;
  }

  public static void FreeResource()
  {
    for (int index = 0; index < SheetAnimationUnitGroupNewbie.m_FreeList.Count; ++index)
      Object.Destroy((Object) SheetAnimationUnitGroupNewbie.m_FreeList[index].gameObject);
    SheetAnimationUnitGroupNewbie.m_FreeList.Clear();
  }

  public override int Update(float deltaTime)
  {
    int num = 0;
    for (int index = 0; index < 18; ++index)
    {
      if (this.animUnit[index] != null)
        num += this.animUnit[index].Update(deltaTime);
    }
    return num;
  }

  public override void RecoverUnit()
  {
    for (int index = 0; index < this.Count; ++index)
    {
      if (this.animUnit[index] != null)
      {
        SheetAnimationUnit sheetAnimationUnit = this.animUnit[index];
        this.animUnit[index] = (SheetAnimationUnit) null;
        if ((Object) sheetAnimationUnit.transform != (Object) null)
          sheetAnimationUnit.transform.parent = (Transform) null;
        if ((Object) sheetAnimationUnit.gameObject != (Object) null)
          sheetAnimationUnit.gameObject.SetActive(false);
        SheetAnimationUnitGroupNewbie.m_FreeList.Add(sheetAnimationUnit);
      }
    }
  }

  public override void setupAnimUnit(byte Side, byte lineFlag, float angle, byte setupFlag = 0)
  {
    this.Count = 0;
    byte dir = 0;
    bool flag = SheetAnimationUnitGroupNewbie.getSpriteDirFromAngle(angle, out dir);
    ushort InKey = 0;
    switch (lineFlag)
    {
      case 5:
      case 6:
      case 10:
      case 11:
      case 14:
      case 15:
      case 17:
      case 20:
        InKey = (ushort) 5;
        break;
      case 7:
        InKey = (ushort) 4;
        break;
      case 8:
      case 18:
        InKey = (ushort) 8;
        break;
      case 9:
      case 19:
        InKey = (ushort) 9;
        Side = (byte) 0;
        break;
      case 12:
        InKey = (ushort) 7;
        break;
      case 13:
        InKey = (ushort) 1;
        break;
      case 16:
        InKey = (ushort) 3;
        break;
      case 21:
        InKey = (ushort) 2;
        break;
      case 22:
        InKey = (ushort) 10;
        Side = (byte) 0;
        break;
      case 23:
      case 26:
        InKey = (ushort) 6;
        flag = false;
        dir = (byte) 0;
        break;
      case 24:
      case 25:
        InKey = (ushort) 6;
        flag = false;
        dir = (byte) 0;
        break;
      case 27:
        InKey = (ushort) 11;
        flag = false;
        dir = (byte) 0;
        Side = (byte) 0;
        break;
    }
    if (((int) setupFlag & 1) != 0)
      flag = true;
    MarchPaltform recordByKey1 = DataManager.Instance.MarchPaltformTable.GetRecordByKey(InKey);
    int num1 = 0;
    int num2 = 0;
    switch (dir)
    {
      case 0:
        num1 = (int) recordByKey1.UpStartID;
        num2 = (int) recordByKey1.UpEndID;
        break;
      case 1:
        num1 = (int) recordByKey1.UpRightStartID;
        num2 = (int) recordByKey1.UpRightEndID;
        break;
      case 2:
        num1 = (int) recordByKey1.RightStartID;
        num2 = (int) recordByKey1.RightEndID;
        break;
      case 3:
        num1 = (int) recordByKey1.DownRightStartID;
        num2 = (int) recordByKey1.DownRightEndID;
        break;
      case 4:
        num1 = (int) recordByKey1.DownStartID;
        num2 = (int) recordByKey1.DownEndID;
        break;
    }
    int num3 = num2 - num1;
    for (int zOrder = 0; zOrder <= num3; ++zOrder)
    {
      MarchOffset recordByKey2 = DataManager.Instance.MarchOffsetTable.GetRecordByKey((ushort) (num1 + zOrder));
      float x = (float) ((double) recordByKey2.OffsetX * (1.0 / 1000.0) * (recordByKey2.SignedX != (byte) 0 ? -1.0 : 1.0) * (!flag ? 1.0 : -1.0));
      float y = (float) ((double) recordByKey2.OffsetY * (1.0 / 1000.0) * (recordByKey2.SignedY != (byte) 0 ? -1.0 : 1.0));
      bool bMirror = flag;
      if (GUIManager.Instance.IsArabic)
      {
        bMirror = !bMirror;
        if (lineFlag == (byte) 0)
          bMirror = !bMirror;
      }
      this.addAnimUnit(Side, recordByKey2.Kind, dir, bMirror, new Vector3(x, y, 0.0f), zOrder);
    }
  }

  private void addAnimUnit(
    byte Side,
    byte Kind,
    byte dir,
    bool bMirror,
    Vector3 localOffset,
    int zOrder = 0,
    bool AttackerDirection = false)
  {
    uint actionId = SheetAnimationUnitGroup.GetActionID(Side, Kind, dir);
    if (SheetAnimationUnitGroupNewbie.m_FreeList.Count == 0)
    {
      this.animUnit[this.Count] = new SheetAnimationUnit(actionId, SheetAnimationUnitGroupNewbie.AnimMap, SheetAnimationUnitGroupNewbie.sharedMat, bMirror, AttackerDirection: AttackerDirection);
    }
    else
    {
      this.animUnit[this.Count] = SheetAnimationUnitGroupNewbie.m_FreeList[SheetAnimationUnitGroupNewbie.m_FreeList.Count - 1];
      SheetAnimationUnitGroupNewbie.m_FreeList.RemoveAt(SheetAnimationUnitGroupNewbie.m_FreeList.Count - 1);
      this.animUnit[this.Count].ResetUnit(actionId, SheetAnimationUnitGroupNewbie.AnimMap, bMirror, AttackerDirection: AttackerDirection);
    }
    this.animUnit[this.Count].transform.parent = this.transform;
    localOffset.z = (float) zOrder * -0.01f;
    this.animUnit[this.Count].transform.localPosition = localOffset;
    this.animUnit[this.Count].transform.localScale = Vector3.one;
    ++this.Count;
  }

  public static bool getSpriteDirFromAngle(float angle, out byte dir)
  {
    bool spriteDirFromAngle = false;
    if ((double) angle > 67.5 && (double) angle <= 112.5)
      dir = (byte) 0;
    else if ((double) angle > 112.5 && (double) angle <= 157.5)
    {
      dir = (byte) 1;
      spriteDirFromAngle = true;
    }
    else if ((double) angle > 157.5 && (double) angle <= 202.5)
    {
      dir = (byte) 2;
      spriteDirFromAngle = true;
    }
    else if ((double) angle > 202.5 && (double) angle <= 247.5)
    {
      dir = (byte) 3;
      spriteDirFromAngle = true;
    }
    else
      dir = (double) angle <= 247.5 || (double) angle > 292.5 ? ((double) angle <= 292.5 || (double) angle > 337.5 ? ((double) angle > 337.5 || (double) angle <= 22.5 ? (byte) 2 : (byte) 1) : (byte) 3) : (byte) 4;
    return spriteDirFromAngle;
  }

  public void resetScale() => this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
}
