// Decompiled with JetBrains decompiler
// Type: FlowLineFactoryNewbie
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class FlowLineFactoryNewbie
{
  public const int MAX_FLOWLINE = 512;
  public const float LINE_HEIGHT = 0.4f;
  public const float OPAQUE_SIDE_LEN = 5f;
  public const float UV_PER_UNIT = 0.25f;
  public const float ATK_DISPLAY_LEN = 5f;
  public LineNode workingLine;
  private GameObject m_Parent;
  private AssetBundle m_Bundle;
  private Vector3[] m_Vertices = new Vector3[8];
  private Vector2[] m_Uv = new Vector2[8];
  private Color[] m_Color = new Color[8];
  private readonly Vector3 MONSTER_FACELEFT_OFFSET = new Vector3(-0.621f, -0.076f, 0.0f);
  private readonly Vector3 MONSTER_FACERIGHT_OFFSET = new Vector3(0.621f, -0.076f, 0.0f);
  private readonly int[] m_Triangle = new int[6]
  {
    0,
    1,
    6,
    7,
    6,
    1
  };
  private readonly int[] m_EaseTriangle = new int[12]
  {
    0,
    1,
    2,
    3,
    2,
    1,
    5,
    6,
    4,
    7,
    6,
    5
  };
  private float m_ParentScaleBase = 1f;
  private float m_ScaleRate = 1f;
  private float CanvasRectTranScale = 1f;

  public FlowLineFactoryNewbie(Transform realmGroup, float tileBaseScale)
  {
    this.CanvasRectTranScale = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.m_Parent = new GameObject("FlowLineList_Newbie");
    if ((UnityEngine.Object) realmGroup != (UnityEngine.Object) null)
    {
      this.m_Parent.transform.SetParent(realmGroup);
      this.m_Parent.transform.localPosition = Vector3.zero;
      this.m_ParentScaleBase = 1f;
    }
    this.ScaleRate = tileBaseScale;
    SheetAnimationUnitGroupNewbie.InitResource();
  }

  public float ScaleRate
  {
    get => this.m_ScaleRate;
    set
    {
      this.m_ScaleRate = value;
      float num = this.m_ParentScaleBase * this.m_ScaleRate;
      this.m_Parent.transform.localScale = new Vector3(num, num, num);
    }
  }

  public LineNode createLine(
    MapLine mapLine,
    Vector3 from,
    Vector3 to,
    ELineColor color,
    EUnitSide unitSide,
    bool bEase = true,
    bool NeedRenderLine = true,
    EMonsterFace MonsterFace = EMonsterFace.LEFT,
    byte bLoop = 0)
  {
    if (!(GameManager.ActiveGameplay is CHAOS activeGameplay) || (UnityEngine.Object) activeGameplay.realmController == (UnityEngine.Object) null || activeGameplay.realmController.mapLineController == null)
      return (LineNode) null;
    if ((UnityEngine.Object) activeGameplay.realmController.mapLineController.m_Bundle == (UnityEngine.Object) null)
      activeGameplay.realmController.mapLineController.m_Bundle = AssetManager.GetAssetBundle("Role/FlowLinePrefab", 0L);
    uint during = mapLine.during;
    long begin = (long) mapLine.begin;
    if (during <= 0U)
      return (LineNode) null;
    if ((int) (begin + (long) during - DataManager.Instance.ServerTime) <= 0)
      return (LineNode) null;
    byte Side = (byte) unitSide;
    byte colorIndex = (byte) color;
    from = this.m_Parent.transform.InverseTransformPoint(from);
    from.z = 0.0f;
    to = this.m_Parent.transform.InverseTransformPoint(to);
    to.z = 0.0f;
    float num1 = (float) Math.Min(Math.Max(DataManager.Instance.ServerTime - begin, 0L), (long) during);
    float dist = Vector3.Distance(from, to);
    float num2 = (float) ((double) dist / (double) during * 2.0);
    EMarchEventType emarchEventType = EMarchEventType.EMET_Camp;
    byte lineFlag = mapLine.lineFlag;
    if (lineFlag >= (byte) 23)
    {
      if ((double) num1 >= 5.0)
      {
        emarchEventType = (EMarchEventType) lineFlag;
        lineFlag = (byte) this.RetreatToReturn((EMarchEventType) lineFlag);
      }
      else if (lineFlag == (byte) 24 || lineFlag == (byte) 25)
        Side = colorIndex != (byte) 3 ? (byte) 0 : (byte) 1;
    }
    LineNode node = (LineNode) null;
    GameObject gameObject1;
    if (this.workingLine != null)
    {
      gameObject1 = this.workingLine.gameObject;
      gameObject1.SetActive(true);
      this.setupLineNode(node, dist, bEase, colorIndex);
    }
    else
    {
      if ((UnityEngine.Object) this.m_Bundle == (UnityEngine.Object) null)
        this.m_Bundle = activeGameplay.realmController.mapLineController.m_Bundle;
      gameObject1 = UnityEngine.Object.Instantiate(this.m_Bundle.mainAsset) as GameObject;
      gameObject1.transform.parent = this.m_Parent.transform;
      MeshFilter component1 = gameObject1.GetComponent<MeshFilter>();
      Mesh mesh = new Mesh();
      MeshRenderer component2 = gameObject1.GetComponent<MeshRenderer>();
      component2.material.renderQueue = 3001;
      component1.mesh = mesh;
      node = new LineNode();
      node.gameObject = gameObject1;
      node.lineTransform = gameObject1.transform;
      GameObject gameObject2 = new GameObject("movingNode");
      gameObject2.transform.parent = gameObject1.transform;
      gameObject2.transform.Rotate(0.0f, 90f, 0.0f);
      node.movingNode = gameObject2.transform;
      node.meshFilter = component1;
      node.renderer = component2;
      this.setupLineNode(node, dist, bEase, colorIndex);
      this.workingLine = node;
    }
    float num3 = num1;
    if (lineFlag >= (byte) 23 || emarchEventType >= EMarchEventType.EMET_AttackRetreat)
    {
      during -= 5U;
      float num4 = num3 - 5f;
      num3 = (double) num4 >= 0.0 ? num4 : 0.0f;
    }
    node.lineTableID = (int) mapLine.lineID;
    node.timeOffset = num3;
    node.inverseMaxTime = during <= 0U ? 0.0f : 1f / (float) during;
    float x = (float) ((double) dist * ((double) node.timeOffset * (double) node.inverseMaxTime) - (double) dist * 0.5);
    node.movingNode.localPosition = new Vector3(x, 0.0f, 0.0f);
    node.speedRate = num2 / 1.75f;
    node.unitSpeedRate = 1f;
    node.bFocus = bLoop;
    Vector3 from1 = to - from;
    float angle = Vector3.Angle(from1, Vector3.right);
    if ((double) from1.y < 0.0)
      angle = 360f - angle;
    gameObject1.transform.rotation = Quaternion.identity;
    gameObject1.transform.localPosition = from + (to - from) * 0.5f;
    gameObject1.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    gameObject1.transform.localScale = Vector3.one;
    this.recalculateSpeed(node, mapLine, true);
    if (node != null && (UnityEngine.Object) node.movingNode != (UnityEngine.Object) null)
    {
      if (node.sheetUnit == null)
        node.sheetUnit = (ISheetAnimationUnitGroup) new SheetAnimationUnitGroupNewbie();
      SheetAnimationUnitGroupNewbie sheetUnit = node.sheetUnit as SheetAnimationUnitGroupNewbie;
      sheetUnit.transform.parent = (Transform) null;
      sheetUnit.transform.rotation = Quaternion.identity;
      sheetUnit.transform.parent = node.movingNode;
      sheetUnit.transform.localPosition = Vector3.zero;
      byte setupFlag = 0;
      if (lineFlag == (byte) 27 && MonsterFace == EMonsterFace.RIGHT)
        setupFlag |= (byte) 1;
      sheetUnit.setupAnimUnit(Side, lineFlag, angle, setupFlag);
      sheetUnit.resetScale();
      node.flag = lineFlag;
      node.angle = angle;
      node.side = Side;
      node.MonsterFace = MonsterFace;
      if (lineFlag >= (byte) 23)
      {
        float num5 = 5f - num1;
        node.renderer.enabled = false;
        node.action = ELineAction.ACTION_BEFORE;
        node.timer = num5;
      }
    }
    if (node != null && !NeedRenderLine)
    {
      if (node.action == ELineAction.ACTION_BEFORE)
        node.action = ELineAction.ACTION_BEFORE_WITHOUT_LINE;
      node.renderer.enabled = false;
    }
    return node;
  }

  private void setupLineNode(LineNode node, float dist, bool bEase, byte colorIndex)
  {
    Mesh mesh = node.meshFilter.mesh;
    float y1 = 0.2f;
    float x1 = dist * 0.5f;
    float num1 = 5f;
    if (10.0 > (double) dist)
    {
      num1 = 0.0f;
      bEase = false;
    }
    this.m_Vertices[0] = new Vector3(-x1, -y1, 0.0f);
    this.m_Vertices[1] = new Vector3(-x1, y1, 0.0f);
    this.m_Vertices[2] = new Vector3(-x1 + num1, -y1, 0.0f);
    this.m_Vertices[3] = new Vector3(-x1 + num1, y1, 0.0f);
    this.m_Vertices[4] = new Vector3(x1 - num1, -y1, 0.0f);
    this.m_Vertices[5] = new Vector3(x1 - num1, y1, 0.0f);
    this.m_Vertices[6] = new Vector3(x1, -y1, 0.0f);
    this.m_Vertices[7] = new Vector3(x1, y1, 0.0f);
    float x2 = (float) ((double) dist / 0.40000000596046448 * 0.25);
    float x3 = num1 / dist * x2;
    float x4 = (dist - num1) / dist * x2;
    float y2 = (float) colorIndex * 0.25f;
    float y3 = (float) ((int) colorIndex + 1) * 0.25f;
    this.m_Uv[0] = new Vector2(0.0f, y2);
    this.m_Uv[1] = new Vector2(0.0f, y3);
    this.m_Uv[2] = new Vector2(x3, y2);
    this.m_Uv[3] = new Vector2(x3, y3);
    this.m_Uv[4] = new Vector2(x4, y2);
    this.m_Uv[5] = new Vector2(x4, y3);
    this.m_Uv[6] = new Vector2(x2, y2);
    this.m_Uv[7] = new Vector2(x2, y3);
    Color white = Color.white;
    float num2 = !bEase ? 1f : 0.0f;
    white.a = 1f;
    Color color = white with { a = num2 };
    this.m_Color[0] = white;
    this.m_Color[1] = white;
    this.m_Color[2] = color;
    this.m_Color[3] = color;
    this.m_Color[4] = color;
    this.m_Color[5] = color;
    this.m_Color[6] = white;
    this.m_Color[7] = white;
    mesh.vertices = this.m_Vertices;
    mesh.uv = this.m_Uv;
    mesh.colors = this.m_Color;
    mesh.triangles = !bEase ? this.m_Triangle : this.m_EaseTriangle;
    mesh.RecalculateBounds();
    node.distance = dist;
    node.curCoordU = 0.0f;
    node.maxCoordU = x2;
    node.sideLen = num1;
    node.sideOffset1 = x3;
    node.sideOffset2 = x4;
    node.colorIndex = colorIndex;
  }

  public void recalculateSpeed(LineNode node, MapLine _ml, bool bResetOffset = false)
  {
    MapLine mapLine = _ml;
    uint exduring = mapLine.EXduring;
    ulong begin = mapLine.begin;
    uint exbegin = mapLine.EXbegin;
    uint during = mapLine.during;
    if (bResetOffset)
      node.timeOffset = (float) exbegin;
    float num1 = (float) (during - exbegin) / (float) during * node.distance;
    uint num2 = during - exduring;
    float num3 = num1 / (float) num2;
    if ((double) num3 >= 0.5 && during > 1U && num2 > 2U)
    {
      --during;
      num3 = (float) (during - exbegin) / (float) during * node.distance / (float) (during - exduring);
    }
    if (mapLine.lineFlag >= (byte) 23)
      node.inverseMaxTime = 1f / (float) mapLine.during;
    ulong serverTime = (ulong) DataManager.Instance.ServerTime;
    ulong num4 = begin + (ulong) exduring;
    long num5 = (long) serverTime - (long) num4;
    float num6 = ((float) exbegin / (float) during * node.distance + (float) num5 * num3) / node.distance * (float) during;
    float num7 = node.distance / (float) during;
    if ((double) node.timeOffset <= (double) num6)
    {
      node.timeOffset = num6;
      float num8 = num3 / num7;
      node.speedRate = (float) ((double) num8 * 0.05000000074505806 + (double) num7 / 1.75);
      node.unitSpeedRate = num8;
    }
    else
    {
      float num9 = (float) (1.0 - (double) node.timeOffset * (double) node.inverseMaxTime) * node.distance / (float) Mathf.Max(0, (int) ((long) begin + (long) during - (long) serverTime)) / num7;
      node.speedRate = (float) ((double) num9 * 0.05000000074505806 + (double) num7 / 1.75);
      node.unitSpeedRate = num9;
    }
  }

  public void Clear()
  {
    this.ClearLine();
    if ((bool) (UnityEngine.Object) this.m_Parent)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.m_Parent);
    SheetAnimationUnitGroupNewbie.FreeResource();
    if (!(bool) (UnityEngine.Object) this.m_Bundle)
      return;
    this.m_Bundle.Unload(true);
  }

  public EMarchEventType RetreatToReturn(EMarchEventType type)
  {
    switch (type)
    {
      case EMarchEventType.EMET_AttackRetreat:
        return EMarchEventType.EMET_AttackReturn;
      case EMarchEventType.EMET_CampRetreat:
        return EMarchEventType.EMET_CampReturn;
      case EMarchEventType.EMET_GatherRetreat:
        return EMarchEventType.EMET_GatherReturn;
      case EMarchEventType.EMET_RallyRetreat:
        return EMarchEventType.EMET_RallyReturn;
      case EMarchEventType.EMET_HitMonsterRetreat:
        return EMarchEventType.EMET_HitMonsterReturn;
      default:
        return type;
    }
  }

  public void MoveUnitToEndPoint(EMarchEventType type)
  {
    LineNode workingLine = this.workingLine;
    if (workingLine == null)
      return;
    float x = workingLine.distance - workingLine.distance * 0.5f;
    workingLine.movingNode.localPosition = new Vector3(x, 0.0f, 0.0f);
    workingLine.sheetUnit.RecoverUnit();
    workingLine.sheetUnit.setupAnimUnit(workingLine.side, (byte) type, workingLine.angle, (byte) 0);
    if (type != EMarchEventType.EMET_HitMonsterRetreat)
      return;
    NewbieManager.SetupFakeMonster(1, workingLine);
  }

  public void Update(float deltaTime)
  {
    LineNode workingLine = this.workingLine;
    if (workingLine == null)
      return;
    if (workingLine.sheetUnit != null && workingLine.sheetUnit.Update(deltaTime) != 0)
      NewbieManager.SetupFakeMonster(0);
    if (workingLine.flag != (byte) 5 && workingLine.flag != (byte) 9)
    {
      float num = workingLine.speedRate * deltaTime;
      workingLine.curCoordU -= num;
      workingLine.maxCoordU -= num;
      workingLine.sideOffset1 -= num;
      workingLine.sideOffset2 -= num;
      float y1 = (float) workingLine.colorIndex * 0.25f;
      float y2 = (float) ((int) workingLine.colorIndex + 1) * 0.25f;
      this.m_Uv[0] = new Vector2(workingLine.curCoordU, y1);
      this.m_Uv[1] = new Vector2(workingLine.curCoordU, y2);
      this.m_Uv[2] = new Vector2(workingLine.sideOffset1, y1);
      this.m_Uv[3] = new Vector2(workingLine.sideOffset1, y2);
      this.m_Uv[4] = new Vector2(workingLine.sideOffset2, y1);
      this.m_Uv[5] = new Vector2(workingLine.sideOffset2, y2);
      this.m_Uv[6] = new Vector2(workingLine.maxCoordU, y1);
      this.m_Uv[7] = new Vector2(workingLine.maxCoordU, y2);
      workingLine.meshFilter.mesh.uv = this.m_Uv;
      if (!((UnityEngine.Object) workingLine.gameObject != (UnityEngine.Object) null))
        return;
      workingLine.timeOffset += deltaTime * workingLine.unitSpeedRate;
      if ((double) workingLine.timeOffset * (double) workingLine.inverseMaxTime > 1.0)
      {
        if (workingLine.bFocus == (byte) 0)
          return;
        workingLine.timeOffset = 0.0f;
      }
      float x = (float) ((double) workingLine.distance * ((double) workingLine.timeOffset * (double) workingLine.inverseMaxTime) - (double) workingLine.distance * 0.5);
      workingLine.movingNode.localPosition = new Vector3(x, 0.0f, 0.0f);
    }
    else
    {
      if (!workingLine.ShakingTimer.HasValue)
        return;
      float x1 = workingLine.distance - workingLine.distance * 0.5f;
      workingLine.movingNode.localPosition = new Vector3(x1, 0.0f, 0.0f);
      if ((double) workingLine.ShakingTimer.Value <= 0.0)
      {
        workingLine.ShakingTimer = new float?();
      }
      else
      {
        LineNode lineNode = workingLine;
        float? shakingTimer = lineNode.ShakingTimer;
        lineNode.ShakingTimer = !shakingTimer.HasValue ? new float?() : new float?(shakingTimer.Value - deltaTime);
        float x2;
        if (workingLine.ShakingFlag == (byte) 0)
        {
          workingLine.ShakingFlag = (byte) 1;
          x2 = workingLine.ShakingTimer.Value * 0.375f;
        }
        else
        {
          workingLine.ShakingFlag = (byte) 0;
          x2 = workingLine.ShakingTimer.Value * -0.375f;
        }
        workingLine.movingNode.localPosition += new Vector3(x2, -x2, 0.0f);
      }
    }
  }

  public void ClearLine()
  {
    if (this.workingLine == null)
      return;
    if (this.workingLine.sheetUnit != null)
      this.workingLine.sheetUnit.RecoverUnit();
    if ((UnityEngine.Object) this.workingLine.movingNode != (UnityEngine.Object) null && (UnityEngine.Object) this.workingLine.movingNode.gameObject != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.workingLine.movingNode.gameObject);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.workingLine.gameObject);
    this.workingLine = (LineNode) null;
  }
}
