// Decompiled with JetBrains decompiler
// Type: RallyNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public struct RallyNode : IEquatable<RallyNode>
{
  public ulong BeginTime;
  public PointCode Point;

  public bool Equals(RallyNode other) => object.Equals((object) other, (object) this);

  public override bool Equals(object obj)
  {
    if (obj == null || (object) this.GetType() != (object) obj.GetType())
      return false;
    RallyNode rallyNode = (RallyNode) obj;
    return (long) this.BeginTime == (long) rallyNode.BeginTime && (int) this.Point.pointID == (int) rallyNode.Point.pointID && (int) this.Point.zoneID == (int) rallyNode.Point.zoneID;
  }

  public override int GetHashCode()
  {
    return (this.BeginTime + (ulong) this.Point.pointID + (ulong) this.Point.zoneID).GetHashCode();
  }

  public static bool operator ==(RallyNode c1, RallyNode c2) => c1.Equals(c2);

  public static bool operator !=(RallyNode c1, RallyNode c2) => !c1.Equals(c2);
}
