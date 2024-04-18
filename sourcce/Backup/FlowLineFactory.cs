// Decompiled with JetBrains decompiler
// Type: FlowLineFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class FlowLineFactory
{
  public const int MAX_FLOWLINE = 512;
  public const float LINE_HEIGHT = 0.4f;
  public const float OPAQUE_SIDE_LEN = 5f;
  public const float UV_PER_UNIT = 0.25f;
  public const float ATK_DISPLAY_LEN = 5f;
  public const float PETSKILL_DISPLAY_LEN = 1f;
  private const float nameOffset = 64f;
  private LineContainer m_LineList = new LineContainer();
  private LineNode WorkingLineHeader;
  private LineNode FreeLineHeader;
  private GameObject m_Parent;
  public AssetBundle m_Bundle;
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
  private MapTileBloodName mapNameController;
  private float CanvasRectTranScale = 1f;
  public CString LastRallyName = new CString(13);
  public List<RallyNode> RallyLineData = new List<RallyNode>();
  public List<FakeRetreat> FakeRetreatList = new List<FakeRetreat>();
  public List<LineNode> LineAutoDelQueue = new List<LineNode>();
  public List<PointModifyNode> PointModifyList = new List<PointModifyNode>();

  public FlowLineFactory(Transform realmGroup, MapTileBloodName Name, float tileBaseScale)
  {
    this.CanvasRectTranScale = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.m_Parent = new GameObject("FlowLineList");
    if ((UnityEngine.Object) realmGroup != (UnityEngine.Object) null)
    {
      this.m_Parent.transform.SetParent(realmGroup);
      this.m_Parent.transform.localPosition = Vector3.forward * 47f;
      this.m_ParentScaleBase = 1f;
    }
    this.ScaleRate = tileBaseScale;
    SheetAnimationUnitGroup.InitResource();
    this.mapNameController = Name;
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

  private void fillLineNode(LineNode node)
  {
    if (node == null)
      return;
    LineNode lineNode = node;
    Color white = Color.white;
    this.m_Color[2] = white;
    this.m_Color[3] = white;
    this.m_Color[4] = white;
    this.m_Color[5] = white;
    lineNode.meshFilter.mesh.colors = this.m_Color;
    lineNode.meshFilter.mesh.triangles = this.m_Triangle;
    lineNode.bFocus = (byte) 1;
  }

  public void easeLineNode(LineNode _lineNode)
  {
    if (_lineNode == null)
      return;
    if (_lineNode.colorIndex == (byte) 1 && this.CheckLineEaseDistance(_lineNode))
    {
      Color white = Color.white with { a = 0.0f };
      this.m_Color[2] = white;
      this.m_Color[3] = white;
      this.m_Color[4] = white;
      this.m_Color[5] = white;
      _lineNode.meshFilter.mesh.colors = this.m_Color;
      _lineNode.meshFilter.mesh.triangles = this.m_EaseTriangle;
    }
    _lineNode.bFocus = (byte) 0;
  }

  public bool CheckRalyNodeAlive(int lineTableID)
  {
    int count = this.RallyLineData.Count;
    ulong serverTime = (ulong) DataManager.Instance.ServerTime;
    for (int index = count - 1; index >= 0; --index)
    {
      if (this.RallyLineData[index].BeginTime - serverTime > 10UL)
        this.RallyLineData.RemoveAt(index);
    }
    MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
    RallyNode rallyNode = new RallyNode();
    rallyNode.BeginTime = mapLine.begin;
    rallyNode.Point.pointID = mapLine.start.pointID;
    rallyNode.Point.zoneID = mapLine.start.zoneID;
    for (int index = 0; index < this.RallyLineData.Count; ++index)
    {
      if (rallyNode == this.RallyLineData[index])
        return true;
    }
    this.RallyLineData.Add(rallyNode);
    return false;
  }

  public LineNode createLine(
    int lineTableID,
    Vector3 from,
    Vector3 to,
    ELineColor color,
    EUnitSide unitSide,
    bool bEase = true,
    bool NeedRenderLine = true,
    EMonsterFace MonsterFace = EMonsterFace.LEFT)
  {
    uint during = DataManager.MapDataController.MapLineTable[lineTableID].during;
    long begin = (long) DataManager.MapDataController.MapLineTable[lineTableID].begin;
    if (during <= 0U)
      return (LineNode) null;
    if ((double) (begin + (long) during) - NetworkManager.ServerTime <= 0.0)
      return (LineNode) null;
    bool flag1 = GameConstants.IsPetSkillLine(lineTableID);
    bool flag2 = false;
    if (during == 5U && DataManager.MapDataController.MapLineTable[lineTableID].EXduring == 5U)
    {
      flag2 = true;
      switch (DataManager.MapDataController.MapLineTable[lineTableID].lineFlag)
      {
        case 12:
        case 26:
          DataManager.MapDataController.MapLineTable[lineTableID].lineFlag = (byte) 26;
          break;
        default:
          DataManager.MapDataController.MapLineTable[lineTableID].lineFlag = (byte) 23;
          break;
      }
    }
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
    byte lineFlag = DataManager.MapDataController.MapLineTable[lineTableID].lineFlag;
    bool flag3 = this.IsYolkDefenseFail(lineTableID);
    if (!flag1 && (lineFlag >= (byte) 23 || flag3))
    {
      if ((double) num1 >= 5.0)
      {
        emarchEventType = (EMarchEventType) lineFlag;
        lineFlag = (byte) this.RetreatToReturn((EMarchEventType) lineFlag);
      }
      else if (lineFlag == (byte) 24 || lineFlag == (byte) 25)
      {
        Side = (byte) 1;
        int mapId = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineTableID].start.pointID);
        int tableId = (int) DataManager.MapDataController.LayoutMapInfo[mapId].tableID;
        if (lineFlag == (byte) 24 && DataManager.MapDataController.IsCityOrCamp((uint) mapId))
        {
          if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[tableId].playerName, DataManager.Instance.RoleAttr.Name) == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[tableId].allianceTag))
            Side = (byte) 0;
        }
        else if (lineFlag == (byte) 25 && DataManager.MapDataController.IsResources((uint) mapId) && (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[tableId].playerName, DataManager.Instance.RoleAttr.Name) == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[tableId].allianceTag)))
          Side = (byte) 0;
      }
    }
    LineNode line = this.GetFreeLine();
    GameObject gameObject1;
    if (line != null)
    {
      this.InsertWorkingList(line);
      gameObject1 = line.gameObject;
      gameObject1.SetActive(true);
      this.setupLineNode(line, dist, bEase, colorIndex);
    }
    else
    {
      if ((UnityEngine.Object) this.m_Bundle == (UnityEngine.Object) null)
        this.m_Bundle = AssetManager.GetAssetBundle("Role/FlowLinePrefab", 0L);
      gameObject1 = UnityEngine.Object.Instantiate(this.m_Bundle.mainAsset) as GameObject;
      gameObject1.transform.parent = this.m_Parent.transform;
      MeshFilter component1 = gameObject1.GetComponent<MeshFilter>();
      Mesh mesh = new Mesh();
      MeshRenderer component2 = gameObject1.GetComponent<MeshRenderer>();
      component2.sharedMaterial.renderQueue = 2650;
      component1.mesh = mesh;
      line = new LineNode();
      line.gameObject = gameObject1;
      line.lineTransform = gameObject1.transform;
      GameObject gameObject2 = new GameObject("movingNode");
      gameObject2.transform.parent = gameObject1.transform;
      gameObject2.transform.Rotate(0.0f, 90f, 0.0f);
      line.movingNode = gameObject2.transform;
      line.meshFilter = component1;
      line.renderer = component2;
      this.setupLineNode(line, dist, bEase, colorIndex);
      this.m_LineList.Insert(gameObject1.GetHashCode(), line);
      this.InsertWorkingList(line);
    }
    float num3 = num1;
    if (flag1)
    {
      --during;
      float num4 = num3 - 1f;
      num3 = (double) num4 >= 0.0 ? num4 : 0.0f;
    }
    else if (lineFlag >= (byte) 23 || emarchEventType >= EMarchEventType.EMET_AttackRetreat || flag3)
    {
      during -= 5U;
      float num5 = num3 - 5f;
      num3 = (double) num5 >= 0.0 ? num5 : 0.0f;
    }
    line.lineTableID = lineTableID;
    line.timeOffset = num3;
    line.inverseMaxTime = during <= 0U ? 0.0f : 1f / (float) during;
    float x = (float) ((double) dist * ((double) line.timeOffset * (double) line.inverseMaxTime) - (double) dist * 0.5);
    line.movingNode.localPosition = new Vector3(x, 0.0f, 0.0f);
    line.speedRate = num2 / 1.75f;
    line.unitSpeedRate = 1f;
    line.AutoDelete = (byte) 0;
    line.IsPetSkillLine = flag1;
    Vector3 from1 = to - from;
    float angle = Vector3.Angle(from1, Vector3.right);
    if ((double) from1.y < 0.0)
      angle = 360f - angle;
    gameObject1.transform.rotation = Quaternion.identity;
    gameObject1.transform.localPosition = from + (to - from) * 0.5f;
    gameObject1.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    gameObject1.transform.localScale = Vector3.one;
    this.recalculateSpeed(line, lineTableID, true);
    if (line != null && (UnityEngine.Object) line.movingNode != (UnityEngine.Object) null)
    {
      if (line.sheetUnit == null)
        line.sheetUnit = (ISheetAnimationUnitGroup) new SheetAnimationUnitGroup();
      SheetAnimationUnitGroup sheetUnit = line.sheetUnit as SheetAnimationUnitGroup;
      sheetUnit.transform.parent = (Transform) null;
      sheetUnit.transform.rotation = Quaternion.identity;
      sheetUnit.transform.parent = line.movingNode;
      sheetUnit.transform.localPosition = Vector3.zero;
      sheetUnit.transform.localScale = Vector3.one;
      sheetUnit.resetScale();
      byte num6 = 0;
      byte num7 = 0;
      if (!flag1 && lineFlag == (byte) 27 && MonsterFace == EMonsterFace.RIGHT)
        num7 |= (byte) 1;
      if (flag1 || (lineFlag != (byte) 26 || !this.CheckRalyNodeAlive(lineTableID)) && !flag3)
      {
        if (!flag1 && lineFlag == (byte) 26)
        {
          Debug.Log((object) this.LastRallyName.ToString());
          num6 = (byte) 1;
        }
        byte setupFlag = (byte) ((int) num7 | (!flag1 ? 0 : 2));
        sheetUnit.setupAnimUnit(Side, lineFlag, angle, setupFlag);
      }
      else
        num6 = (byte) 2;
      line.flag = lineFlag;
      line.angle = angle;
      line.side = Side;
      line.MonsterFace = MonsterFace;
      line.action = ELineAction.NORMAL;
      line.ShakingTimer = new float?();
      line.ShakingFlag = (byte) 0;
      line.renderer.enabled = true;
      if (flag1)
      {
        float num8 = 1f - num1;
        if ((double) num8 >= 0.0)
        {
          line.renderer.enabled = false;
          line.action = ELineAction.ACTION_BEFORE;
          line.timer = num8;
          line.sheetUnit.RecoverUnit();
          num6 = (byte) 2;
        }
        else
          line.timer = -11f;
      }
      else if (lineFlag >= (byte) 23 || flag3)
      {
        float num9 = 5f - num1;
        line.renderer.enabled = false;
        line.action = ELineAction.ACTION_BEFORE;
        line.timer = num9;
      }
      float num10 = this.CanvasRectTranScale * DataManager.MapDataController.zoomSize;
      MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
      if (!flag1 && (lineFlag == (byte) 24 || lineFlag == (byte) 25) && DataManager.MapDataController.ZoneUpdateInfo[(int) mapLine.start.zoneID & 1023].zoneState < (byte) 8)
      {
        int mapId = GameConstants.PointCodeToMapID(mapLine.start.zoneID, mapLine.start.pointID);
        int tableId = (int) DataManager.MapDataController.LayoutMapInfo[mapId].tableID;
        ELineColor textcolor = color;
        switch (colorIndex)
        {
          case 0:
            textcolor = ELineColor.ORANGE;
            break;
          case 3:
            textcolor = ELineColor.RED;
            break;
        }
        if (DataManager.MapDataController.IsResources((uint) mapId))
        {
          if (colorIndex == (byte) 2 || colorIndex == (byte) 1)
          {
            if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[tableId].playerName, DataManager.Instance.RoleAttr.Name) == 0)
              textcolor = ELineColor.DEEPBLUE;
            else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[tableId].allianceTag))
              textcolor = ELineColor.BLUE;
          }
          line.NodeName = DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK || !DataManager.MapDataController.IsEnemy(DataManager.MapDataController.ResourcesPointTable[tableId].kingdomID) ? this.mapNameController.pullLineName(DataManager.MapDataController.ResourcesPointTable[tableId].playerName, DataManager.MapDataController.ResourcesPointTable[tableId].allianceTag, textcolor, new Vector2((float) (int) ((double) line.movingNode.position.x / (double) num10), (float) (int) ((double) line.movingNode.position.y / (double) num10) + 64f), (ushort) 0) : this.mapNameController.pullLineName(DataManager.MapDataController.ResourcesPointTable[tableId].playerName, DataManager.MapDataController.ResourcesPointTable[tableId].allianceTag, textcolor, new Vector2((float) (int) ((double) line.movingNode.position.x / (double) num10), (float) (int) ((double) line.movingNode.position.y / (double) num10) + 64f), DataManager.MapDataController.ResourcesPointTable[tableId].kingdomID);
        }
        else
        {
          if (colorIndex == (byte) 2 || colorIndex == (byte) 1)
          {
            if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[tableId].playerName, DataManager.Instance.RoleAttr.Name) == 0)
              textcolor = ELineColor.DEEPBLUE;
            else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[tableId].allianceTag))
              textcolor = ELineColor.BLUE;
          }
          line.NodeName = DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK || !DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[tableId].kingdomID) ? this.mapNameController.pullLineName(DataManager.MapDataController.PlayerPointTable[tableId].playerName, DataManager.MapDataController.PlayerPointTable[tableId].allianceTag, textcolor, new Vector2((float) (int) ((double) line.movingNode.position.x / (double) num10), (float) (int) ((double) line.movingNode.position.y / (double) num10) + 64f), (ushort) 0) : this.mapNameController.pullLineName(DataManager.MapDataController.PlayerPointTable[tableId].playerName, DataManager.MapDataController.PlayerPointTable[tableId].allianceTag, textcolor, new Vector2((float) (int) ((double) line.movingNode.position.x / (double) num10), (float) (int) ((double) line.movingNode.position.y / (double) num10) + 64f), DataManager.MapDataController.PlayerPointTable[tableId].kingdomID);
        }
        switch (num6)
        {
          case 1:
            if (textcolor == ELineColor.DEEPBLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) != 0)
            {
              line.NodeName.updateName(this.LastRallyName, DataManager.MapDataController.PlayerPointTable[tableId].allianceTag, ELineColor.BLUE);
              break;
            }
            if (textcolor == ELineColor.BLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) == 0)
            {
              line.NodeName.updateName(this.LastRallyName, DataManager.MapDataController.PlayerPointTable[tableId].allianceTag, ELineColor.DEEPBLUE);
              break;
            }
            line.NodeName.updateName(this.LastRallyName, DataManager.MapDataController.PlayerPointTable[tableId].allianceTag, (ushort) 0);
            break;
          case 2:
            line.NodeName.SetActive(false);
            break;
        }
      }
      else
      {
        line.NodeName = DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK || !DataManager.MapDataController.IsEnemy(mapLine.kingdomID) ? this.mapNameController.pullLineName(mapLine.playerName, mapLine.allianceTag, color, new Vector2((float) (int) ((double) line.movingNode.position.x / (double) num10), (float) (int) ((double) line.movingNode.position.y / (double) num10) + 64f), (ushort) 0) : this.mapNameController.pullLineName(mapLine.playerName, mapLine.allianceTag, color, new Vector2((float) (int) ((double) line.movingNode.position.x / (double) num10), (float) (int) ((double) line.movingNode.position.y / (double) num10) + 64f), mapLine.kingdomID);
        switch (num6)
        {
          case 1:
            if (color == ELineColor.DEEPBLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) != 0)
            {
              line.NodeName.updateName(this.LastRallyName, mapLine.allianceTag, ELineColor.BLUE);
              break;
            }
            if (color == ELineColor.BLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) == 0)
            {
              line.NodeName.updateName(this.LastRallyName, mapLine.allianceTag, ELineColor.DEEPBLUE);
              break;
            }
            line.NodeName.updateName(this.LastRallyName, mapLine.allianceTag, (ushort) 0);
            break;
          case 2:
            line.NodeName.SetActive(false);
            break;
        }
      }
    }
    if (((int) DataManager.MapDataController.MapLineTable[lineTableID].baseFlag & 1) != 0)
    {
      EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(DataManager.MapDataController.MapLineTable[lineTableID].emojiID);
      if ((int) recordByKey.EmojiKey == (int) DataManager.MapDataController.MapLineTable[lineTableID].emojiID)
      {
        float num11 = (int) recordByKey.sizeX <= (int) recordByKey.sizeY ? (float) recordByKey.sizeY : (float) recordByKey.sizeX;
        float num12 = ((double) num11 != 0.0 ? num11 * 0.9f + (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebackoffset : 25f) : (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebacksize : 73f)) / (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
        if (line.NodeName.mapEmojiBack == null)
        {
          line.NodeName.mapEmojiBack = GUIManager.Instance.pullEmojiIcon(ushort.MaxValue, (byte) 0, true);
          SheetAnimationUnitGroup sheetUnit = line.sheetUnit as SheetAnimationUnitGroup;
          line.NodeName.mapEmojiBack.EmojiTransform.SetParent(sheetUnit.transform, false);
        }
        line.NodeName.mapEmojiBack.EmojiTransform.localPosition = GameConstants.lineeomjiback;
        line.NodeName.mapEmojiBack.EmojiTransform.localScale = Vector3.one * num12;
        if (line.NodeName.mapEmoji != null)
        {
          GUIManager.Instance.pushEmojiIcon(line.NodeName.mapEmoji);
          line.NodeName.mapEmoji = (EmojiUnit) null;
        }
        line.NodeName.mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, true);
        line.NodeName.mapEmoji.EmojiTransform.localPosition = GameConstants.lineeomji;
        line.NodeName.mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
        SheetAnimationUnitGroup sheetUnit1 = line.sheetUnit as SheetAnimationUnitGroup;
        line.NodeName.mapEmoji.EmojiTransform.SetParent(sheetUnit1.transform, false);
      }
    }
    else if (line.NodeName.mapEmoji != null)
    {
      GUIManager.Instance.pushEmojiIcon(line.NodeName.mapEmoji);
      line.NodeName.mapEmoji = (EmojiUnit) null;
      if (line.NodeName.mapEmojiBack != null)
      {
        GUIManager.Instance.pushEmojiIcon(line.NodeName.mapEmojiBack);
        line.NodeName.mapEmojiBack = (EmojiUnit) null;
      }
    }
    if (line != null && !NeedRenderLine)
    {
      if (line.action == ELineAction.ACTION_BEFORE)
        line.action = ELineAction.ACTION_BEFORE_WITHOUT_LINE;
      line.renderer.enabled = false;
    }
    if (line != null && flag2)
      line.AutoDelete = (byte) 1;
    return line;
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

  public void recalculateSpeed(LineNode node, int lineTableID, bool bResetOffset = false)
  {
    MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
    uint exduring = mapLine.EXduring;
    ulong begin = mapLine.begin;
    uint exbegin = mapLine.EXbegin;
    uint during = mapLine.during;
    if (bResetOffset)
      node.timeOffset = (float) exbegin;
    float num1 = (float) (during - exbegin) / (float) during * node.distance / (float) (during - exduring);
    if (GameConstants.IsPetSkillLine(lineTableID) || mapLine.lineFlag >= (byte) 23 || this.IsYolkDefenseFail(lineTableID))
      node.inverseMaxTime = 1f / (float) mapLine.during;
    double serverTime = NetworkManager.ServerTime;
    ulong num2 = begin + (ulong) exduring;
    double num3 = serverTime - (double) num2;
    float num4 = ((float) exbegin / (float) during * node.distance + (float) num3 * num1) / node.distance * (float) during;
    double num5 = (double) node.distance / (double) during;
    if ((double) node.timeOffset <= (double) num4)
      node.timeOffset = num4;
    double num6 = (double) ((float) (1.0 - (double) node.timeOffset * (double) node.inverseMaxTime) * node.distance) / Math.Max(0.0, (double) (begin + (ulong) during) - serverTime) / num5;
    node.speedRate = (float) (num6 * 0.05 + num5 / 1.75);
    node.unitSpeedRate = (float) num6;
  }

  public bool IsYolkDefenseFail(int lineTableID)
  {
    if (GameConstants.IsPetSkillLine(lineTableID))
      return false;
    MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
    if (mapLine.lineFlag != (byte) 20 || DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) GameConstants.PointCodeToMapID(mapLine.start.zoneID, mapLine.start.pointID)) != POINT_KIND.PK_YOLK)
      return false;
    int count = this.FakeRetreatList.Count;
    for (int index = 0; index < count; ++index)
    {
      if ((int) this.FakeRetreatList[index].point.pointID == (int) mapLine.start.pointID && (int) this.FakeRetreatList[index].point.zoneID == (int) mapLine.start.zoneID)
        return true;
    }
    return false;
  }

  public LineNode GetFreeLine()
  {
    LineNode freeLine = (LineNode) null;
    if (this.FreeLineHeader != null)
    {
      freeLine = this.FreeLineHeader;
      this.FreeLineHeader = freeLine.Next;
    }
    return freeLine;
  }

  public void InsertWorkingList(LineNode node)
  {
    node.Previous = (LineNode) null;
    node.Next = this.WorkingLineHeader;
    if (node.Next != null)
      node.Next.Previous = node;
    this.WorkingLineHeader = node;
    node.NodeState = ELineNodeState.WORKING;
  }

  public LineNode GetNodeByGameObject(GameObject go, bool MoveToFree = false)
  {
    if ((UnityEngine.Object) go == (UnityEngine.Object) null)
      return (LineNode) null;
    LineNode line = (LineNode) null;
    this.m_LineList.TryGetValue(go.GetHashCode(), out line);
    if (line == null || line.NodeState != ELineNodeState.WORKING)
      return (LineNode) null;
    if (MoveToFree)
    {
      if (line.Previous != null)
        line.Previous.Next = line.Next;
      if (line.Next != null)
        line.Next.Previous = line.Previous;
      if (this.WorkingLineHeader == line)
        this.WorkingLineHeader = line.Next;
      line.Previous = (LineNode) null;
      line.Next = this.FreeLineHeader;
      this.FreeLineHeader = line;
      line.NodeState = ELineNodeState.FREE;
    }
    return line;
  }

  public bool recaleSpeed(int lineTableID)
  {
    LineNode nodeByGameObject = this.GetNodeByGameObject(DataManager.MapDataController.MapLineTable[lineTableID].lineObject);
    if (nodeByGameObject == null)
      return false;
    this.recalculateSpeed(nodeByGameObject, lineTableID);
    return true;
  }

  public bool setLineSpeed(GameObject go, float speed)
  {
    LineNode nodeByGameObject = this.GetNodeByGameObject(go);
    if (nodeByGameObject == null)
      return false;
    nodeByGameObject.speedRate = speed;
    return true;
  }

  public bool setLineColor(
    GameObject go,
    ELineColor color,
    EUnitSide unitSide,
    CString player,
    CString tag,
    bool bEase)
  {
    LineNode nodeByGameObject = this.GetNodeByGameObject(go);
    if (nodeByGameObject == null)
      return false;
    nodeByGameObject.colorIndex = (byte) color;
    if (unitSide != (EUnitSide) nodeByGameObject.side && nodeByGameObject.sheetUnit != null)
    {
      nodeByGameObject.side = (byte) unitSide;
      nodeByGameObject.sheetUnit.RecoverUnit();
      byte num = 0;
      if (nodeByGameObject.action == ELineAction.NORMAL)
      {
        int lineFlag = !nodeByGameObject.IsPetSkillLine ? (int) this.RetreatToReturn((EMarchEventType) nodeByGameObject.flag) : (int) nodeByGameObject.flag;
        byte setupFlag = (byte) ((int) num | (!nodeByGameObject.IsPetSkillLine ? 0 : 2));
        nodeByGameObject.sheetUnit.setupAnimUnit(nodeByGameObject.side, (byte) lineFlag, nodeByGameObject.angle, setupFlag);
      }
      else
      {
        byte setupFlag = (byte) ((int) (byte) ((int) num | (!this.CheckForceMirror(nodeByGameObject) ? 0 : 1)) | (!nodeByGameObject.IsPetSkillLine ? 0 : 2));
        nodeByGameObject.sheetUnit.setupAnimUnit(nodeByGameObject.side, nodeByGameObject.flag, nodeByGameObject.angle, setupFlag);
      }
    }
    this.mapNameController.updateLineNameColor(nodeByGameObject.NodeName, color, player, tag);
    LineNode lineNode = (LineNode) null;
    if (GameManager.ActiveGameplay is CHAOS activeGameplay && (UnityEngine.Object) activeGameplay.realmController != (UnityEngine.Object) null && (UnityEngine.Object) activeGameplay.realmController.mapTileController != (UnityEngine.Object) null)
      lineNode = activeGameplay.realmController.mapTileController.selectLineNode;
    if (lineNode != null && lineNode == nodeByGameObject)
      bEase = false;
    if (bEase && !this.CheckLineEaseDistance(nodeByGameObject))
      bEase = false;
    float num1 = !bEase ? 1f : 0.0f;
    Color white = Color.white with { a = num1 };
    this.m_Color[2] = white;
    this.m_Color[3] = white;
    this.m_Color[4] = white;
    this.m_Color[5] = white;
    nodeByGameObject.meshFilter.mesh.colors = this.m_Color;
    nodeByGameObject.meshFilter.mesh.triangles = !bEase ? this.m_Triangle : this.m_EaseTriangle;
    return true;
  }

  public bool CheckLineEaseDistance(LineNode node)
  {
    return node != null && 10.0 <= (double) node.distance;
  }

  public void resetAllLineColor()
  {
    LineNode lineNode = (LineNode) null;
    if (GameManager.ActiveGameplay is CHAOS activeGameplay && (UnityEngine.Object) activeGameplay.realmController != (UnityEngine.Object) null && (UnityEngine.Object) activeGameplay.realmController.mapTileController != (UnityEngine.Object) null)
      lineNode = activeGameplay.realmController.mapTileController.selectLineNode;
    bool bEase = true;
    ELineColor lineColorid = ELineColor.BLUE;
    EUnitSide unitSideid = EUnitSide.BLUE;
    for (LineNode node = this.WorkingLineHeader; node != null; node = node.Next)
    {
      DataManager.checkLineColorID(node.lineTableID, out lineColorid, out unitSideid, out bEase);
      node.colorIndex = (byte) lineColorid;
      if (lineColorid == ELineColor.DEEPBLUE)
        this.mapNameController.updateLineNameColor(node.NodeName, lineColorid, DataManager.MapDataController.MapLineTable[node.lineTableID].playerName, DataManager.MapDataController.MapLineTable[node.lineTableID].allianceTag);
      else
        this.mapNameController.updateLineNameColor(node.NodeName, lineColorid);
      if (lineNode != null && lineNode == node)
        bEase = false;
      if (bEase)
        bEase = this.CheckLineEaseDistance(node);
      float num = !bEase ? 1f : 0.0f;
      Color white = Color.white with { a = num };
      this.m_Color[2] = white;
      this.m_Color[3] = white;
      this.m_Color[4] = white;
      this.m_Color[5] = white;
      node.meshFilter.mesh.colors = this.m_Color;
      node.meshFilter.mesh.triangles = !bEase ? this.m_Triangle : this.m_EaseTriangle;
    }
  }

  public bool setLineEase(GameObject go, bool bEase)
  {
    LineNode nodeByGameObject = this.GetNodeByGameObject(go);
    if (nodeByGameObject == null)
      return false;
    if (bEase && !this.CheckLineEaseDistance(nodeByGameObject))
      bEase = false;
    float num = !bEase ? 1f : 0.0f;
    Color white = Color.white with { a = num };
    this.m_Color[2] = white;
    this.m_Color[3] = white;
    this.m_Color[4] = white;
    this.m_Color[5] = white;
    nodeByGameObject.meshFilter.mesh.colors = this.m_Color;
    nodeByGameObject.meshFilter.mesh.triangles = !bEase ? this.m_Triangle : this.m_EaseTriangle;
    return true;
  }

  public bool removeLine(GameObject go, bool bDeleteAttacher = false)
  {
    if ((UnityEngine.Object) go.GetComponent<MeshFilter>() == (UnityEngine.Object) null)
      return false;
    LineNode nodeByGameObject = this.GetNodeByGameObject(go, true);
    if (nodeByGameObject == null)
      return false;
    go.SetActive(false);
    if (nodeByGameObject.sheetUnit != null)
      nodeByGameObject.sheetUnit.RecoverUnit();
    nodeByGameObject.bFocus = (byte) 0;
    this.mapNameController.pushLineName(ref nodeByGameObject.NodeName);
    if (bDeleteAttacher)
    {
      for (int index = nodeByGameObject.movingNode.childCount - 1; index >= 0; --index)
      {
        Transform child = nodeByGameObject.movingNode.GetChild(index);
        if ((bool) (UnityEngine.Object) child)
          UnityEngine.Object.Destroy((UnityEngine.Object) child.gameObject);
      }
    }
    return true;
  }

  public void Clear()
  {
    for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
    {
      if (lineNode.NodeName != null)
        this.mapNameController.pushLineName(ref lineNode.NodeName);
    }
    this.mapNameController = (MapTileBloodName) null;
    this.ClearLine();
    if ((bool) (UnityEngine.Object) this.m_Parent)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.m_Parent);
    SheetAnimationUnitGroup.FreeResource();
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

  public bool IsHitingMonster(LineNode node)
  {
    return node.flag == (byte) 27 && node.action != ELineAction.NORMAL;
  }

  public bool CheckForceMirror(LineNode node)
  {
    return this.IsHitingMonster(node) && node.MonsterFace == EMonsterFace.RIGHT;
  }

  public void ResetLineState()
  {
    this.RallyLineData.Clear();
    this.FakeRetreatList.Clear();
    this.LineAutoDelQueue.Clear();
    this.PointModifyList.Clear();
  }

  public void AddFakeLine(int idx)
  {
    if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_GatherMarching)
    {
      if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int) DataManager.MapDataController.LayoutMapInfo[GameConstants.PointCodeToMapID(this.FakeRetreatList[idx].point.zoneID, this.FakeRetreatList[idx].point.pointID)].tableID].playerName, this.FakeRetreatList[idx].playerName) == 0)
        return;
    }
    else if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_CampMarching)
    {
      if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[(int) DataManager.MapDataController.LayoutMapInfo[GameConstants.PointCodeToMapID(this.FakeRetreatList[idx].point.zoneID, this.FakeRetreatList[idx].point.pointID)].tableID].playerName, this.FakeRetreatList[idx].playerName) == 0)
        return;
    }
    else if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_HitMonsterMarching)
      return;
    MapManager mapDataController = DataManager.MapDataController;
    int num = mapDataController.MapLineTableIDpool.spawn();
    while (num >= mapDataController.MapLineTable.Count)
      mapDataController.MapLineTable.Add(new MapLine());
    mapDataController.MapLineTable[num].start = this.FakeRetreatList[idx].point;
    mapDataController.MapLineTable[num].end = this.FakeRetreatList[idx].point2;
    mapDataController.MapLineTable[num].begin = (ulong) DataManager.Instance.ServerTime;
    mapDataController.MapLineTable[num].during = 5U;
    mapDataController.MapLineTable[num].EXduring = 5U;
    mapDataController.MapLineTable[num].EXbegin = 0U;
    if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_AttackMarching || this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_CampMarching || this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_GatherMarching)
      mapDataController.MapLineTable[num].lineFlag = (byte) 23;
    else if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_RallyAttack)
      mapDataController.MapLineTable[num].lineFlag = (byte) 26;
    mapDataController.MapLineTable[num].playerName.ClearString();
    mapDataController.MapLineTable[num].playerName.Append(this.FakeRetreatList[idx].playerName);
    mapDataController.MapLineTable[num].allianceTag.ClearString();
    mapDataController.MapLineTable[num].allianceTag.Append(this.FakeRetreatList[idx].allianceTag);
    FakeRetreat fakeRetreat = this.FakeRetreatList[idx] with
    {
      flag = 1
    };
    this.FakeRetreatList[idx] = fakeRetreat;
    mapDataController.addLine(num);
  }

  public void Update(float deltaTime)
  {
    if (this.FakeRetreatList.Count > 0)
    {
      for (int index1 = 0; index1 < this.FakeRetreatList.Count; ++index1)
      {
        if (this.FakeRetreatList[index1].lineFlag == EMarchEventType.EMET_RallyAttack)
        {
          for (int index2 = 0; index2 < this.PointModifyList.Count; ++index2)
          {
            PointCode point = this.FakeRetreatList[index1].point;
            if (this.PointModifyList[index2].Kind == POINT_KIND.PK_YOLK)
              point.zoneID &= (ushort) 1023;
            if ((int) point.pointID == (int) this.PointModifyList[index2].Code.pointID && (int) point.zoneID == (int) this.PointModifyList[index2].Code.zoneID)
            {
              this.AddFakeLine(index1);
              break;
            }
          }
        }
        else
        {
          switch (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) GameConstants.PointCodeToMapID(this.FakeRetreatList[index1].point.zoneID, this.FakeRetreatList[index1].point.pointID)))
          {
            case POINT_KIND.PK_CITY:
              for (int index3 = 0; index3 < this.PointModifyList.Count; ++index3)
              {
                PointCode point = this.FakeRetreatList[index1].point;
                if ((int) point.pointID == (int) this.PointModifyList[index3].Code.pointID && (int) point.zoneID == (int) this.PointModifyList[index3].Code.zoneID)
                {
                  this.AddFakeLine(index1);
                  break;
                }
              }
              continue;
            case POINT_KIND.PK_YOLK:
              if (this.FakeRetreatList[index1].lineFlag == EMarchEventType.EMET_CampMarching)
                continue;
              break;
          }
          this.AddFakeLine(index1);
        }
      }
      this.FakeRetreatList.Clear();
    }
    this.PointModifyList.Clear();
    float num1 = this.CanvasRectTranScale * DataManager.MapDataController.zoomSize;
    LineNode node = this.WorkingLineHeader;
    while (node != null)
    {
      if (node.sheetUnit != null && node.sheetUnit.Update(deltaTime) != 0)
      {
        DataManager.msgBuffer[0] = (byte) 86;
        GameConstants.GetBytes((uint) node.lineTableID, DataManager.msgBuffer, 1);
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      if (node.action == ELineAction.NORMAL)
      {
        float num2 = node.speedRate * deltaTime;
        node.curCoordU -= num2;
        node.maxCoordU -= num2;
        node.sideOffset1 -= num2;
        node.sideOffset2 -= num2;
        float y1 = (float) node.colorIndex * 0.25f;
        float y2 = (float) ((int) node.colorIndex + 1) * 0.25f;
        this.m_Uv[0] = new Vector2(node.curCoordU, y1);
        this.m_Uv[1] = new Vector2(node.curCoordU, y2);
        this.m_Uv[2] = new Vector2(node.sideOffset1, y1);
        this.m_Uv[3] = new Vector2(node.sideOffset1, y2);
        this.m_Uv[4] = new Vector2(node.sideOffset2, y1);
        this.m_Uv[5] = new Vector2(node.sideOffset2, y2);
        this.m_Uv[6] = new Vector2(node.maxCoordU, y1);
        this.m_Uv[7] = new Vector2(node.maxCoordU, y2);
        node.meshFilter.mesh.uv = this.m_Uv;
        if ((UnityEngine.Object) node.gameObject != (UnityEngine.Object) null)
        {
          node.timeOffset += deltaTime * node.unitSpeedRate;
          if ((double) node.timeOffset * (double) node.inverseMaxTime > 1.0)
          {
            if (node.bFocus < (byte) 1)
              node.bFocus = (byte) 2;
            node = node.Next;
            continue;
          }
          float num3 = (float) ((double) node.distance * ((double) node.timeOffset * (double) node.inverseMaxTime) - (double) node.distance * 0.5);
          if (float.IsInfinity(num3) || float.IsNaN(num3))
            num3 = 0.0f;
          node.movingNode.localPosition = new Vector3(num3, 0.0f, 0.0f);
          if (node.bFocus == (byte) 0)
            node.NodeName.updateName(new Vector2((float) (int) ((double) node.movingNode.position.x / (double) num1), (float) (int) ((double) node.movingNode.position.y / (double) num1) + 64f));
        }
      }
      else
      {
        node.timer -= deltaTime;
        if ((double) node.timer <= 0.0)
        {
          if (node.AutoDelete != (byte) 0)
          {
            this.LineAutoDelQueue.Add(node);
            node = node.Next;
            continue;
          }
          ELineAction action = node.action;
          node.action = ELineAction.NORMAL;
          node.sheetUnit.RecoverUnit();
          int flag = (int) this.RetreatToReturn((EMarchEventType) node.flag);
          byte setupFlag = 0;
          if (!node.IsPetSkillLine)
          {
            if (node.flag == (byte) 24 || node.flag == (byte) 25)
            {
              node.side = node.colorIndex == (byte) 2 || node.colorIndex == (byte) 1 ? (byte) 1 : (byte) 0;
              MapLine mapLine = DataManager.MapDataController.MapLineTable[node.lineTableID];
              node.NodeName.updateName(mapLine.playerName, mapLine.allianceTag, (ELineColor) node.colorIndex);
            }
            else if (node.flag == (byte) 27)
            {
              DataManager.msgBuffer[0] = (byte) 91;
              GameConstants.GetBytes((uint) node.lineTableID, DataManager.msgBuffer, 1);
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
            }
            else if (node.flag == (byte) 26 && node.NodeName != null)
              node.NodeName.updateName(DataManager.MapDataController.MapLineTable[node.lineTableID].playerName, DataManager.MapDataController.MapLineTable[node.lineTableID].allianceTag, (ELineColor) node.colorIndex);
          }
          else
          {
            flag = (int) node.flag;
            setupFlag |= (byte) 2;
            if (node.NodeName != null)
              node.NodeName.updateName(DataManager.MapDataController.MapLineTable[node.lineTableID].playerName, DataManager.MapDataController.MapLineTable[node.lineTableID].allianceTag, (ELineColor) node.colorIndex);
          }
          node.sheetUnit.setupAnimUnit(node.side, (byte) flag, node.angle, setupFlag);
          if (action != ELineAction.ACTION_BEFORE_WITHOUT_LINE)
            node.renderer.enabled = true;
          this.recalculateSpeed(node, node.lineTableID, true);
          if ((double) node.timer > -10.0)
          {
            int num4 = -2;
            DataManager.MapDataController.MapLineTable[node.lineTableID].baseFlag &= (byte) num4;
            DataManager.MapDataController.MapLineTable[node.lineTableID].emojiID = (ushort) 0;
            if (GameManager.ActiveGameplay is CHAOS activeGameplay && (UnityEngine.Object) activeGameplay.realmController != (UnityEngine.Object) null)
              activeGameplay.realmController.UpdateLineEmoji(node.lineTableID);
          }
          if (node.IsPetSkillLine && (double) node.timer > -10.0)
          {
            Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
            if (((UnityEngine.Object) menu == (UnityEngine.Object) null || menu.m_eMode == EUIOriginMode.Show) && GameManager.ActiveGameplay is CHAOS activeGameplay && (UnityEngine.Object) activeGameplay.realmController != (UnityEngine.Object) null && (UnityEngine.Object) activeGameplay.realmController.mapTileController != (UnityEngine.Object) null)
            {
              float num5 = GUIManager.Instance.m_UICanvas.renderMode != 1 ? DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale : ((Transform) GUIManager.Instance.pDVMgr.CanvasRT).localScale.x;
              byte lineFlag = DataManager.MapDataController.MapLineTable[node.lineTableID].lineFlag;
              MapDamageEffTb recordByKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey((ushort) lineFlag);
              if ((int) recordByKey.ID == (int) lineFlag)
              {
                float num6 = DataManager.MapDataController.zoomSize * num5;
                Vector2 vector2 = activeGameplay.realmController.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[node.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[node.lineTableID].start.pointID) * num6;
                Vector3 vector3 = new Vector3(vector2.x, vector2.y, 0.0f);
                CString cstring = StringManager.Instance.SpawnString();
                if (recordByKey.SoundPakNO != (ushort) 0)
                {
                  cstring.ClearString();
                  cstring.StringToFormat("Role/");
                  cstring.IntToFormat((long) recordByKey.SoundPakNO, 3);
                  cstring.AppendFormat("{0}{1}");
                  if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.HeroSFX, recordByKey.SoundPakNO))
                    AudioManager.Instance.PlaySFX(recordByKey.FireSound, Position: new Vector3?(vector3));
                }
                else
                  AudioManager.Instance.PlaySFX(recordByKey.FireSound, Position: new Vector3?(vector3));
                if (recordByKey.ParticlePakNO != (ushort) 0)
                {
                  cstring.ClearString();
                  cstring.StringToFormat("Particle/Monster_Effects_");
                  cstring.IntToFormat((long) recordByKey.ParticlePakNO, 3);
                  cstring.AppendFormat("{0}{1}");
                  if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Particle, AssetType.Effects, recordByKey.ParticlePakNO))
                    DataManager.MapDataController.MapWeaponAttack(DataManager.MapDataController.MapLineTable[node.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[node.lineTableID].start.pointID, recordByKey.FireParticle, (float) recordByKey.FireParticleDuring * (1f / 1000f));
                }
                else
                  DataManager.MapDataController.MapWeaponAttack(DataManager.MapDataController.MapLineTable[node.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[node.lineTableID].start.pointID, recordByKey.FireParticle, (float) recordByKey.FireParticleDuring * (1f / 1000f));
                StringManager.Instance.DeSpawnString(cstring);
              }
            }
          }
          node.timer = -11f;
        }
        if (this.IsHitingMonster(node))
        {
          node.movingNode.localPosition = new Vector3(node.distance * -0.5f, 0.0f, 0.0f);
          Vector3 vector3 = node.movingNode.TransformPoint(node.movingNode.localPosition) + (node.MonsterFace != EMonsterFace.LEFT ? this.MONSTER_FACERIGHT_OFFSET : this.MONSTER_FACELEFT_OFFSET);
          node.movingNode.position = vector3;
        }
        if (node.bFocus == (byte) 0)
          node.NodeName.updateName(new Vector2((float) (int) ((double) node.movingNode.position.x / (double) num1), (float) (int) ((double) node.movingNode.position.y / (double) num1) + 64f));
        if (node.ShakingTimer.HasValue)
        {
          if ((double) node.ShakingTimer.Value <= 0.0)
          {
            node.ShakingTimer = new float?();
          }
          else
          {
            LineNode lineNode = node;
            float? shakingTimer = lineNode.ShakingTimer;
            lineNode.ShakingTimer = !shakingTimer.HasValue ? new float?() : new float?(shakingTimer.Value - deltaTime);
            float x;
            if (node.ShakingFlag == (byte) 0)
            {
              node.ShakingFlag = (byte) 1;
              x = node.ShakingTimer.Value * 1f;
            }
            else
            {
              node.ShakingFlag = (byte) 0;
              x = node.ShakingTimer.Value * -1f;
            }
            node.movingNode.localPosition += new Vector3(x, 0.0f, -x);
          }
        }
      }
      node = node.Next;
    }
    if (this.LineAutoDelQueue.Count <= 0)
      return;
    for (int index = 0; index < this.LineAutoDelQueue.Count; ++index)
    {
      if (this.LineAutoDelQueue[index].lineTableID < 1048576)
        DataManager.MapDataController.delLine(this.LineAutoDelQueue[index].lineTableID, (byte) 0);
    }
    this.LineAutoDelQueue.Clear();
  }

  public bool OnClick(Vector2 clickpos, ref LineNode node)
  {
    if (node != null)
      node.bFocus = (byte) 0;
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) clickpos) with
    {
      z = 0.0f
    };
    float num1 = 1f * DataManager.MapDataController.zoomSize;
    float num2 = num1 * 0.5f;
    for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
    {
      Vector3 position = lineNode.movingNode.position;
      if (new Rect(position.x - num2, position.y - num2, num1, num1).Contains(worldPoint))
      {
        node = lineNode;
        this.fillLineNode(node);
        return true;
      }
    }
    if (node != null)
    {
      this.easeLineNode(node);
      node = (LineNode) null;
    }
    return false;
  }

  public bool OnClick(byte groupID, ref LineNode node)
  {
    if (node != null)
      node.bFocus = (byte) 0;
    switch (groupID)
    {
      case 8:
        for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
        {
          if ((int) DataManager.MapDataController.MapLineTable[lineNode.lineTableID].during == (int) DataManager.Instance.beCaptured.TotalTime && DataManager.MapDataController.MapLineTable[lineNode.lineTableID].lineFlag == (byte) 22 && DataManager.CompareStr(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0 && (DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag.Length == 0 && DataManager.Instance.RoleAlliance.Tag.Length == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag)) && GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].end.pointID) == DataManager.Instance.RoleAttr.CapitalPoint)
          {
            node = lineNode;
            this.fillLineNode(node);
            return true;
          }
        }
        break;
      case 9:
        for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
        {
          if (GameConstants.IsPetSkillLine(lineNode.lineTableID) && (int) DataManager.MapDataController.MapLineTable[lineNode.lineTableID].during == (int) PetManager.Instance.m_PetMarchEventData.MarchEventTime.RequireTime && DataManager.CompareStr(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0 && (DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag.Length == 0 && DataManager.Instance.RoleAlliance.Tag.Length == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag)) && GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.pointID) == DataManager.Instance.RoleAttr.CapitalPoint)
          {
            node = lineNode;
            this.fillLineNode(node);
            return true;
          }
        }
        break;
      default:
        byte index1 = 0;
        byte[] numArray1 = new byte[5];
        int[] numArray2 = new int[5];
        for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
        {
          int mapId = GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[(int) groupID].Point.zoneID, DataManager.Instance.MarchEventData[(int) groupID].Point.pointID);
          if ((int) DataManager.MapDataController.MapLineTable[lineNode.lineTableID].during == (int) DataManager.Instance.MarchEventTime[(int) groupID].RequireTime && (EMarchEventType) DataManager.MapDataController.MapLineTable[lineNode.lineTableID].lineFlag == DataManager.Instance.MarchEventData[(int) groupID].Type && (DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag.Length == 0 && DataManager.Instance.RoleAlliance.Tag.Length == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag)) && (DataManager.MapDataController.MapLineTable[lineNode.lineTableID].lineFlag == (byte) 12 || DataManager.CompareStr(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0) && (GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].end.pointID) == mapId || GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.pointID) == mapId))
          {
            byte num1 = 0;
            ulong begin = DataManager.MapDataController.MapLineTable[lineNode.lineTableID].begin;
            ulong num2 = begin;
            bool flag = true;
            for (byte index2 = 0; (int) index2 < (int) DataManager.Instance.MaxMarchEventNum; ++index2)
            {
              if (DataManager.Instance.MarchEventData[(int) index2].Type > EMarchEventType.EMET_RallyStanby)
              {
                ulong beginTime = (ulong) DataManager.Instance.MarchEventTime[(int) index2].BeginTime;
                ulong num3 = begin <= beginTime ? beginTime - begin : begin - beginTime;
                if (flag)
                {
                  num2 = num3;
                  index1 = (byte) 1;
                  numArray1[0] = num1 = index2;
                  flag = false;
                }
                else if (num3 < num2)
                {
                  num2 = num3;
                  index1 = (byte) 1;
                  numArray1[0] = num1 = index2;
                }
                else if ((long) num3 == (long) num2)
                {
                  numArray1[(int) index1] = index2;
                  ++index1;
                }
              }
            }
            if ((int) num1 == (int) groupID)
            {
              node = lineNode;
              this.fillLineNode(node);
              return true;
            }
            if (index1 > (byte) 1)
            {
              for (int index3 = 0; index3 < (int) index1; ++index3)
              {
                if ((int) numArray1[index3] == (int) groupID)
                {
                  node = lineNode;
                  this.fillLineNode(node);
                  return true;
                }
              }
            }
          }
        }
        break;
    }
    if (node != null)
    {
      this.easeLineNode(node);
      node = (LineNode) null;
    }
    return false;
  }

  public bool OnClick(int lineTableID, ref LineNode node)
  {
    if (node != null)
      node.bFocus = (byte) 0;
    for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
    {
      if (lineNode.lineTableID == lineTableID)
      {
        node = lineNode;
        this.fillLineNode(node);
        return true;
      }
    }
    if (node != null)
    {
      this.easeLineNode(node);
      node = (LineNode) null;
    }
    return false;
  }

  public LineNode getLineValue(GameObject go) => this.GetNodeByGameObject(go);

  public void MoveLine(Vector2 moveDelta)
  {
    float num = this.CanvasRectTranScale * DataManager.MapDataController.zoomSize;
    for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
    {
      if (lineNode != null && (UnityEngine.Object) lineNode.gameObject != (UnityEngine.Object) null)
      {
        lineNode.lineTransform.position = new Vector3(lineNode.lineTransform.position.x + moveDelta.x * this.CanvasRectTranScale, lineNode.lineTransform.position.y + moveDelta.y * this.CanvasRectTranScale, lineNode.lineTransform.position.z);
        if (lineNode.bFocus == (byte) 2)
          lineNode.NodeName.updateName(new Vector2((float) (int) ((double) lineNode.movingNode.position.x / (double) num), (float) (int) ((double) lineNode.movingNode.position.y / (double) num) + 64f));
      }
    }
  }

  public void ClearLine()
  {
    for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
    {
      lineNode.Previous = (LineNode) null;
      if ((UnityEngine.Object) lineNode.gameObject != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) lineNode.gameObject);
      if ((UnityEngine.Object) lineNode.movingNode != (UnityEngine.Object) null && (UnityEngine.Object) lineNode.movingNode.gameObject != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) lineNode.movingNode.gameObject);
    }
    for (LineNode lineNode = this.FreeLineHeader; lineNode != null; lineNode = lineNode.Next)
    {
      lineNode.Previous = (LineNode) null;
      if ((UnityEngine.Object) lineNode.gameObject != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) lineNode.gameObject);
      if ((UnityEngine.Object) lineNode.movingNode != (UnityEngine.Object) null && (UnityEngine.Object) lineNode.movingNode.gameObject != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) lineNode.movingNode.gameObject);
    }
    this.m_LineList.Clear();
  }

  public void LineNameTextRebuilt()
  {
    for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
    {
      if (lineNode.NodeName != null)
        lineNode.NodeName.NameTextRebuilt();
    }
  }
}
