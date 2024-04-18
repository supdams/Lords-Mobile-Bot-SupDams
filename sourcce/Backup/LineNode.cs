// Decompiled with JetBrains decompiler
// Type: LineNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class LineNode
{
  public GameObject gameObject;
  public Transform movingNode;
  public MeshFilter meshFilter;
  public MeshRenderer renderer;
  public float inverseMaxTime;
  public float timeOffset;
  public float distance;
  public float speedRate = 1f;
  public float unitSpeedRate = 1f;
  public float curCoordU;
  public float maxCoordU;
  public float sideLen;
  public float sideOffset1;
  public float sideOffset2;
  public byte colorIndex;
  public ISheetAnimationUnitGroup sheetUnit;
  public ELineAction action;
  public float timer;
  public byte side;
  public byte flag;
  public byte bFocus;
  public float angle;
  public Transform lineTransform;
  public int lineTableID = 1048576;
  public MapTileName NodeName;
  public EMonsterFace MonsterFace;
  public float? ShakingTimer;
  public byte ShakingFlag;
  public byte AutoDelete;
  public bool IsPetSkillLine;
  public ELineNodeState NodeState = ELineNodeState.FREE;
  public LineNode Previous;
  public LineNode Next;

  public void Shake()
  {
    this.ShakingTimer = new float?(0.2f);
    this.ShakingFlag = (byte) 0;
  }
}
