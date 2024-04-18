// Decompiled with JetBrains decompiler
// Type: WarlobbyData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class WarlobbyData
{
  public int DataIndex;
  public ushort ListIndex;
  public byte Kind;
  public byte AttackOrDefense;
  public byte DirtyData;
  public TimeEventDataType EventTime;
  public byte PositionInfo;
  public PointCode AllyCapitalPoint;
  public ushort AllyHead;
  public CString AllyName;
  public byte AllyVIP;
  public byte AllyRank;
  public uint AllyCurrTroop;
  public uint AllyMAXTroop;
  public int AllyNameID;
  public ushort AllyHomeKingdom;
  public PointCode EnemyCapitalPoint;
  public ushort EnemyHead;
  public CString EnemyName;
  public byte EnemyVIP;
  public byte EnemyRank;
  public CString EnemyAllianceTag;
  public ushort EnemyHomeKingdom;
  public byte ListDetailRecNum;
  public byte SelfParticipateTroopIndex;
  public byte WonderID;
  public byte UIWonderID;
  public ushort EnemyNPCID;

  public WarlobbyData(int index)
  {
    this.ListIndex = (ushort) index;
    this.AllyName = StringManager.Instance.SpawnString(100);
    this.EnemyName = StringManager.Instance.SpawnString();
    this.EnemyAllianceTag = StringManager.Instance.SpawnString();
  }

  public void Init(MessagePacket MP)
  {
    this.Kind = MP.ReadByte();
    this.EventTime.BeginTime = MP.ReadLong();
    this.EventTime.RequireTime = MP.ReadUInt();
    this.AllyCapitalPoint.zoneID = MP.ReadUShort();
    this.AllyCapitalPoint.pointID = MP.ReadByte();
    this.AllyHead = MP.ReadUShort();
    MP.ReadStringPlus(13, this.AllyName);
    this.AllyNameID = this.AllyName.GetHashCode(false);
    this.AllyVIP = MP.ReadByte();
    this.AllyRank = MP.ReadByte();
    if (this.PositionInfo != (byte) 1)
      this.AllyCurrTroop = MP.ReadUInt();
    this.AllyMAXTroop = MP.ReadUInt();
    this.EnemyCapitalPoint.zoneID = MP.ReadUShort();
    this.EnemyCapitalPoint.pointID = MP.ReadByte();
    this.EnemyHead = MP.ReadUShort();
    MP.ReadStringPlus(13, this.EnemyName);
    this.EnemyVIP = MP.ReadByte();
    this.EnemyRank = MP.ReadByte();
    MP.ReadStringPlus(3, this.EnemyAllianceTag);
    this.EnemyHomeKingdom = MP.ReadUShort();
    this.WonderID = byte.MaxValue;
    this.UIWonderID = byte.MaxValue;
  }

  public void InitWonder(MessagePacket MP)
  {
    this.AllyCapitalPoint.zoneID = MP.ReadUShort();
    this.AllyCapitalPoint.pointID = MP.ReadByte();
    this.AllyHead = MP.ReadUShort();
    MP.ReadStringPlus(13, this.AllyName);
    this.AllyNameID = this.AllyName.GetHashCode(false);
    this.AllyMAXTroop = MP.ReadUInt();
    this.WonderID = MP.ReadByte();
    this.UIWonderID = this.WonderID;
  }

  public void InitWonderAttack(MessagePacket MP)
  {
    this.AllyCapitalPoint.zoneID = MP.ReadUShort();
    this.AllyCapitalPoint.pointID = MP.ReadByte();
    this.AllyHead = MP.ReadUShort();
    MP.ReadStringPlus(13, this.AllyName);
    this.AllyNameID = this.AllyName.GetHashCode(false);
    if (this.PositionInfo != (byte) 1)
      this.AllyCurrTroop = MP.ReadUInt();
    this.AllyMAXTroop = MP.ReadUInt();
    this.WonderID = MP.ReadByte();
    this.UIWonderID = this.WonderID;
    MP.ReadStringPlus(20, this.EnemyName);
    MP.ReadStringPlus(3, this.EnemyAllianceTag);
    this.EnemyHomeKingdom = MP.ReadUShort();
  }

  public void InitWonderDefence(MessagePacket MP)
  {
    this.WonderID = MP.ReadByte();
    this.UIWonderID = this.WonderID;
    if (this.PositionInfo != (byte) 1)
      this.AllyCurrTroop = MP.ReadUInt();
    this.AllyMAXTroop = MP.ReadUInt();
    this.EnemyCapitalPoint.zoneID = MP.ReadUShort();
    this.EnemyCapitalPoint.pointID = MP.ReadByte();
    this.EnemyHead = MP.ReadUShort();
    MP.ReadStringPlus(13, this.EnemyName);
    MP.ReadStringPlus(3, this.EnemyAllianceTag);
    this.EnemyHomeKingdom = MP.ReadUShort();
  }

  public void InitNpc(MessagePacket MP)
  {
    this.Kind = MP.ReadByte();
    this.EventTime.BeginTime = MP.ReadLong();
    this.EventTime.RequireTime = MP.ReadUInt();
    this.AllyCapitalPoint.zoneID = MP.ReadUShort();
    this.AllyCapitalPoint.pointID = MP.ReadByte();
    this.AllyHead = MP.ReadUShort();
    MP.ReadStringPlus(13, this.AllyName);
    this.AllyNameID = this.AllyName.GetHashCode(false);
    this.AllyVIP = MP.ReadByte();
    this.AllyRank = MP.ReadByte();
    if (this.PositionInfo != (byte) 1)
      this.AllyCurrTroop = MP.ReadUInt();
    this.AllyMAXTroop = MP.ReadUInt();
    if (this.PositionInfo != (byte) 1)
      this.AllyHomeKingdom = MP.ReadUShort();
    this.EnemyHead = (ushort) byte.MaxValue;
    this.EnemyCapitalPoint.zoneID = MP.ReadUShort();
    this.EnemyCapitalPoint.pointID = MP.ReadByte();
    this.EnemyVIP = MP.ReadByte();
    this.EnemyNPCID = MP.ReadUShort();
    this.EnemyName.ClearString();
    this.EnemyName.IntToFormat((long) this.EnemyVIP);
    this.EnemyName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
  }

  public void Empty()
  {
    this.EnemyHomeKingdom = (ushort) 0;
    this.AllyHead = (ushort) 0;
    this.EnemyHead = (ushort) 0;
    this.AllyName.ClearString();
    this.EnemyName.ClearString();
    this.EnemyAllianceTag.ClearString();
    this.AllyVIP = this.EnemyVIP = this.AllyRank = this.EnemyRank = (byte) 0;
    this.AllyCurrTroop = this.AllyMAXTroop = 0U;
    this.AllyNameID = 0;
    this.SelfParticipateTroopIndex = byte.MaxValue;
    this.EventTime.BeginTime = 0L;
    this.WonderID = byte.MaxValue;
  }
}
