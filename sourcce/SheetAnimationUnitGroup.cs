// Decompiled with JetBrains decompiler
// Type: SheetAnimationUnitGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SheetAnimationUnitGroup : ISheetAnimationUnitGroup
{
  private const int MAX_SHEETANIM_UNIT = 18;
  public static Dictionary<uint, Sprite[]> AnimMap = new Dictionary<uint, Sprite[]>();
  public static List<SheetAnimationUnit> m_FreeList = new List<SheetAnimationUnit>(256);
  public static Material sharedMat = (Material) null;
  private static AssetBundle kdab = (AssetBundle) null;
  private SheetAnimationUnit[] animUnit = new SheetAnimationUnit[18];
  private int Count;
  public GameObject gameObject;
  public Transform transform;

  public SheetAnimationUnitGroup()
  {
    this.gameObject = new GameObject("AnimUnitGroup");
    this.transform = this.gameObject.transform;
  }

  public static void InitResource()
  {
    if ((Object) SheetAnimationUnitGroup.kdab != (Object) null)
      return;
    SheetAnimationUnitGroup.kdab = AssetManager.GetAssetBundle("UI/KDUnit", 0L);
    SheetAnimationUnitGroup.sharedMat = SheetAnimationUnitGroup.kdab.Load("KDUnit_m") as Material;
    SheetAnimationUnitGroup.sharedMat.renderQueue = 2660;
    Object[] objectArray = SheetAnimationUnitGroup.kdab.LoadAll(typeof (Sprite));
    uint key = 0;
    int num1 = 0;
    for (int index1 = 0; index1 < objectArray.Length; ++index1)
    {
      uint result = 0;
      uint.TryParse(objectArray[index1].name, out result);
      uint num2 = (uint) ((double) result / 100.0);
      bool flag = index1 == objectArray.Length - 1;
      if (flag || (int) num2 != (int) key)
      {
        int length = !flag ? index1 - num1 : index1 - num1 + 1;
        Sprite[] spriteArray = new Sprite[length];
        for (int index2 = 0; index2 < length; ++index2)
          spriteArray[index2] = (Sprite) objectArray[num1 + index2];
        SheetAnimationUnitGroup.AnimMap.Add(key, spriteArray);
        num1 = index1;
        key = num2;
      }
    }
  }

  public static void FreeResource()
  {
    for (int index = 0; index < SheetAnimationUnitGroup.m_FreeList.Count; ++index)
      Object.Destroy((Object) SheetAnimationUnitGroup.m_FreeList[index].gameObject);
    SheetAnimationUnitGroup.m_FreeList.Clear();
  }

  public override int Update(float deltaTime)
  {
    int num = 0;
    for (int index = 0; index < this.Count; ++index)
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
        sheetAnimationUnit.transform.parent = (Transform) null;
        sheetAnimationUnit.gameObject.SetActive(false);
        SheetAnimationUnitGroup.m_FreeList.Add(sheetAnimationUnit);
      }
    }
  }

  public static Sprite[] GetActionSpriteArray(byte Side, byte lineFlag, float angle)
  {
    bool flag = false;
    byte dir = 0;
    flag = SheetAnimationUnitGroup.getSpriteDirFromAngle(angle, out dir);
    ushort InKey1 = 0;
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
        InKey1 = (ushort) 5;
        break;
      case 7:
        InKey1 = (ushort) 4;
        break;
      case 8:
      case 18:
        InKey1 = (ushort) 30;
        break;
      case 9:
      case 19:
        InKey1 = (ushort) 9;
        Side = (byte) 0;
        break;
      case 12:
        InKey1 = (ushort) 7;
        break;
      case 13:
        InKey1 = (ushort) 1;
        break;
      case 16:
        InKey1 = (ushort) 3;
        break;
      case 21:
        InKey1 = (ushort) 2;
        break;
      case 22:
        InKey1 = (ushort) 10;
        Side = (byte) 0;
        break;
      case 23:
        InKey1 = (ushort) 6;
        flag = false;
        dir = (byte) 0;
        break;
      case 24:
      case 25:
        InKey1 = (ushort) 6;
        flag = false;
        dir = (byte) 0;
        break;
      case 26:
        InKey1 = (ushort) 7;
        flag = false;
        dir = (byte) 0;
        break;
      case 27:
        InKey1 = (ushort) 11;
        flag = false;
        dir = (byte) 0;
        Side = (byte) 0;
        break;
    }
    MarchPaltform recordByKey1 = DataManager.Instance.MarchPaltformTable.GetRecordByKey(InKey1);
    int InKey2 = 0;
    switch (dir)
    {
      case 0:
        InKey2 = (int) recordByKey1.UpStartID;
        break;
      case 1:
        InKey2 = (int) recordByKey1.UpRightStartID;
        break;
      case 2:
        InKey2 = (int) recordByKey1.RightStartID;
        break;
      case 3:
        InKey2 = (int) recordByKey1.DownRightStartID;
        break;
      case 4:
        InKey2 = (int) recordByKey1.DownStartID;
        break;
    }
    MarchOffset recordByKey2 = DataManager.Instance.MarchOffsetTable.GetRecordByKey((ushort) InKey2);
    uint actionId = SheetAnimationUnitGroup.GetActionID(Side, recordByKey2.Kind, dir);
    return SheetAnimationUnitGroup.AnimMap.ContainsKey(actionId) ? SheetAnimationUnitGroup.AnimMap[actionId] : (Sprite[]) null;
  }

  public Color32 GetColorByMapDamageTb(ushort TbID, byte index)
  {
    MapDamageEffTb recordByKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey(TbID);
    return index >= (byte) 3 ? (Color32) Color.white : new Color32(recordByKey.LineStyle[(int) index].R, recordByKey.LineStyle[(int) index].G, recordByKey.LineStyle[(int) index].B, byte.MaxValue);
  }

  public override void setupAnimUnit(byte Side, byte lineFlag, float angle, byte setupFlag = 0)
  {
    this.Count = 0;
    byte dir = 0;
    bool bMirror = SheetAnimationUnitGroup.getSpriteDirFromAngle(angle, out dir);
    ushort InKey = 0;
    bool flag = ((int) setupFlag & 2) != 0;
    if (flag)
    {
      InKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey((ushort) lineFlag).PaltformKey;
    }
    else
    {
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
          InKey = (ushort) 30;
          break;
        case 9:
        case 19:
          InKey = (ushort) 9;
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
          break;
        case 23:
          InKey = (ushort) 6;
          bMirror = false;
          dir = (byte) 0;
          break;
        case 24:
        case 25:
          InKey = (ushort) 6;
          bMirror = false;
          dir = (byte) 0;
          break;
        case 26:
          InKey = (ushort) 7;
          bMirror = false;
          dir = (byte) 0;
          break;
        case 27:
          InKey = (ushort) 11;
          bMirror = false;
          break;
      }
    }
    if (((int) setupFlag & 1) != 0)
      bMirror = true;
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
      float x = (float) ((double) recordByKey2.OffsetX * (1.0 / 1000.0) * (recordByKey2.SignedX != (byte) 0 ? -1.0 : 1.0) * (!bMirror ? 1.0 : -1.0));
      float y = (float) ((double) recordByKey2.OffsetY * (1.0 / 1000.0) * (recordByKey2.SignedY != (byte) 0 ? -1.0 : 1.0));
      if (lineFlag == (byte) 26)
        recordByKey2.Kind = (byte) 5;
      if (flag && (recordByKey2.Kind == (byte) 10 || recordByKey2.Kind == (byte) 11 || recordByKey2.Kind == (byte) 12))
      {
        bMirror = false;
        int index = (int) recordByKey2.Kind - 10;
        Color colorByMapDamageTb = (Color) this.GetColorByMapDamageTb((ushort) lineFlag, (byte) index);
        this.addAnimUnit(Side, recordByKey2.Kind, dir, bMirror, new Vector3(x, y, 0.0f), zOrder, blendColor: new Color?(colorByMapDamageTb), extraRotation: new float?(180f + angle));
      }
      else
        this.addAnimUnit(Side, recordByKey2.Kind, dir, bMirror, new Vector3(x, y, 0.0f), zOrder);
    }
  }

  public void setupLandAnimUnit(byte Side, byte lineFlag, int angle)
  {
    this.Count = 0;
    byte dir = 0;
    angle = (560 - angle) % 360;
    bool spriteDirFromAngle = SheetAnimationUnitGroup.getSpriteDirFromAngle((float) angle, out dir);
    MarchPaltform recordByKey1 = DataManager.Instance.MarchPaltformTable.GetRecordByKey((ushort) lineFlag);
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
    for (int index = 0; index <= num3; ++index)
    {
      MarchOffset recordByKey2 = DataManager.Instance.MarchOffsetTable.GetRecordByKey((ushort) (num1 + index));
      float x = (float) ((double) recordByKey2.OffsetX * (1.0 / 1000.0) * (recordByKey2.SignedX != (byte) 0 ? -1.0 : 1.0) * (!spriteDirFromAngle ? 1.0 : -1.0));
      float y = (float) ((double) recordByKey2.OffsetY * (1.0 / 1000.0) * (recordByKey2.SignedY != (byte) 0 ? -1.0 : 1.0));
      switch (recordByKey2.Kind)
      {
        case 5:
          switch (recordByKey2.AttackerDirection)
          {
            case 0:
              this.addAnimUnit(Side, recordByKey2.Kind, (byte) 0, spriteDirFromAngle, new Vector3(x, y, 0.0f));
              continue;
            case 1:
              this.addAnimUnit((byte) 0, recordByKey2.Kind, (byte) 0, false, new Vector3(x, y, 0.0f));
              continue;
            case 2:
              this.addAnimUnit((byte) 0, recordByKey2.Kind, (byte) 0, true, new Vector3(x, y, 0.0f));
              continue;
            case 3:
              this.addAnimUnit((byte) 0, recordByKey2.Kind, (byte) 0, false, new Vector3(x, y, 0.0f), AttackerDirection: true);
              continue;
            case 4:
              this.addAnimUnit((byte) 0, recordByKey2.Kind, (byte) 0, true, new Vector3(x, y, 0.0f), AttackerDirection: true);
              continue;
            case 5:
              this.addAnimUnit((byte) 1, recordByKey2.Kind, (byte) 0, false, new Vector3(x, y, 0.0f));
              continue;
            case 6:
              this.addAnimUnit((byte) 1, recordByKey2.Kind, (byte) 0, true, new Vector3(x, y, 0.0f));
              continue;
            case 7:
              this.addAnimUnit((byte) 1, recordByKey2.Kind, (byte) 0, false, new Vector3(x, y, 0.0f), AttackerDirection: true);
              continue;
            case 8:
              this.addAnimUnit((byte) 1, recordByKey2.Kind, (byte) 0, true, new Vector3(x, y, 0.0f), AttackerDirection: true);
              continue;
            default:
              continue;
          }
        case 7:
        case 8:
          this.addAnimUnit((byte) 0, recordByKey2.Kind, dir, spriteDirFromAngle, new Vector3(x, y, 0.0f));
          break;
        case 9:
          this.addAnimUnit((byte) 0, recordByKey2.Kind, (byte) 0, spriteDirFromAngle, new Vector3(x, y, 0.0f));
          break;
        default:
          this.addAnimUnit(Side, recordByKey2.Kind, dir, spriteDirFromAngle, new Vector3(x, y, 0.0f));
          break;
      }
    }
  }

  private void addAnimUnit(
    byte Side,
    byte Kind,
    byte dir,
    bool bMirror,
    Vector3 localOffset,
    int zOrder = 0,
    bool AttackerDirection = false,
    Color? blendColor = null,
    float? extraRotation = null)
  {
    uint actionId = SheetAnimationUnitGroup.GetActionID(Side, Kind, dir);
    if (SheetAnimationUnitGroup.m_FreeList.Count == 0)
    {
      this.animUnit[this.Count] = new SheetAnimationUnit(actionId, SheetAnimationUnitGroup.AnimMap, SheetAnimationUnitGroup.sharedMat, bMirror, AttackerDirection: AttackerDirection);
    }
    else
    {
      this.animUnit[this.Count] = SheetAnimationUnitGroup.m_FreeList[SheetAnimationUnitGroup.m_FreeList.Count - 1];
      SheetAnimationUnitGroup.m_FreeList.RemoveAt(SheetAnimationUnitGroup.m_FreeList.Count - 1);
      this.animUnit[this.Count].ResetUnit(actionId, SheetAnimationUnitGroup.AnimMap, bMirror, AttackerDirection: AttackerDirection);
    }
    this.animUnit[this.Count].transform.parent = this.transform;
    localOffset.z = (float) zOrder * -0.01f;
    this.animUnit[this.Count].transform.localPosition = localOffset;
    this.animUnit[this.Count].transform.localScale = Vector3.one;
    this.animUnit[this.Count].kdmr.color = !blendColor.HasValue ? Color.white : blendColor.Value;
    if (extraRotation.HasValue)
      this.animUnit[this.Count].transform.Rotate(0.0f, 0.0f, extraRotation.Value, Space.World);
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

  public void SetColor(Color color)
  {
    for (int index = 0; index < 18; ++index)
    {
      if (this.animUnit[index] != null)
        this.animUnit[index].kdmr.color = color;
    }
  }

  public void SetSortOrder(int sortOrder)
  {
    for (int index = 0; index < 18; ++index)
    {
      if (this.animUnit[index] != null)
        this.animUnit[index].kdmr.sortingOrder = sortOrder + index;
    }
  }

  public static uint GetActionID(byte Side, byte Kind, byte dir)
  {
    uint num1 = Kind == (byte) 5 || Kind == (byte) 9 || Kind == (byte) 10 || Kind == (byte) 11 || Kind == (byte) 12 ? 0U : (uint) dir;
    byte num2 = Kind == (byte) 7 || Kind == (byte) 8 || Kind == (byte) 9 || Kind == (byte) 10 || Kind == (byte) 11 || Kind == (byte) 12 ? (byte) 0 : Side;
    return num1 + (uint) ((int) Kind * 10 + (int) num2 * 1000);
  }
}
