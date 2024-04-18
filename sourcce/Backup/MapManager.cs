// Decompiled with JetBrains decompiler
// Type: MapManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

#nullable disable
public class MapManager
{
  private const long CHECK_ZONE_LINE_FACTOR = 10000000000;
  private const int ZoneLineIDTableSize = 32;
  private const float ZoneCheckBottom = 16f;
  private const float ZoneCheckRight = 64f;
  private const byte MaxMapDataSize = 128;
  private const byte MinMapBasePointSize = 39;
  private const byte MinMapLineSize = 49;
  private const byte MinKingdomSize = 40;
  private const byte PointBaseSize = 4;
  private const byte BasePlayerPointSize = 34;
  private const byte ResourcesPointSize = 35;
  private const byte NPCPointSize = 22;
  private const byte YolkPointSize = 39;
  private const byte DOBSPointSize = 1;
  private const byte LineIDSize = 4;
  private const byte LineBaseSize = 52;
  private const byte LineEmojiSize = 3;
  private const byte updateResourcesPointSize = 34;
  private const byte AdvancePlayerPointSize = 44;
  private const byte AdvanceYolkPointSize = 38;
  private const byte YolkStateSize = 13;
  private const byte WoldMapKingdomSize = 40;
  private const byte FlagEmojiIDSize = 3;
  private const byte maxStateCount = 255;
  private const byte maxStateSkillCount = 16;
  public CExternalTableWithWordKey<KingdomMap> KingdomMapTable;
  public byte checkZone;
  public byte zoneIDNum;
  public ushort[] zoneID = new ushort[4];
  public byte UpdateZoneIDNum;
  public ushort[] UpdateZoneID = new ushort[4];
  public ulong[] ZoneUpdateNum = new ulong[4];
  public byte LastZoneIDNum;
  public ushort[] LastZoneID = new ushort[4];
  public byte waitZoneIDNum;
  public ushort[] waitZoneID = new ushort[4];
  public ZoneUpdate[] ZoneUpdateInfo = new ZoneUpdate[1024];
  public MapPoint[] LayoutMapInfo = new MapPoint[262144];
  public byte[] sortRAMReplaceNum = new byte[8];
  public MemSatae[] RAMSataeInfo = new MemSatae[8];
  public byte[] sortROMReplaceNum;
  public MemSatae[] ROMSataeInfo;
  public TableIDPool PlayerPointTableIDpool = new TableIDPool(2048);
  public PlayerPoint[] PlayerPointTable = new PlayerPoint[2048];
  public TableIDPool ResourcesPointTableIDpool = new TableIDPool(2048);
  public ResourcesPoint[] ResourcesPointTable = new ResourcesPoint[2048];
  public TableIDPool NPCPointTableIDpool = new TableIDPool(2048);
  public NPCPoint[] NPCPointTable = new NPCPoint[2048];
  public NPCBase[] NPCNumMap = new NPCBase[5];
  public NPCBase[] OtherNPCNumMap = new NPCBase[5];
  public MapYolk[] YolkPointTable = new MapYolk[40];
  public List<ZoneLine>[] ZoneLineIDTable = new List<ZoneLine>[8];
  public List<ZoneLine>[] TempLineIDTable = new List<ZoneLine>[4];
  public ushort[] TempZoneStateID = new ushort[4];
  public TableIDPool MapLineTableIDpool = new TableIDPool(256, true);
  public List<MapLine> MapLineTable = new List<MapLine>(256);
  public byte reqKingdomIDNum;
  public ushort[] reqKingdomID = new ushort[16];
  public byte lastReqKingdomIDNum;
  public ushort[] lastReqKingdomID = new ushort[16];
  public byte updateKingdomNum;
  public ushort[] updateKingdomID = new ushort[16];
  public KingdomInfo kingdomData;
  public KingdomInfo OtherKingdomData;
  public ushort KVKKingdomID;
  public ushort WARKingdomID;
  public ushort WorldOX;
  public ushort WorldOY;
  public ushort WorldMaxX;
  public ushort WorldMaxY;
  public ushort WorldMinX;
  public ushort WorldMinY;
  public ushort[] KingdomIDposOrder;
  public byte WorldKingdomTableIDcounter;
  public KingdomInfo[] WorldKingdomTable = new KingdomInfo[32];
  public MapKingdom[] TileMapKingdomID;
  public byte[] KingdomOpenFlag;
  public float zoomSize = 0.75f;
  public float wait;
  public int FocusMapID;
  public ushort FocusKingdomID;
  public ulong FocusKingdomTime;
  public KINGDOM_PERIOD FocusKingdomPeriod;
  public byte FocusGroupID = 10;
  public byte isOpenGroundInfo;
  public byte isMarkGroundInfo;
  public byte gotoKingdomState;
  public float ScreenSpaceCameraCanvasrectranScale = 1f;
  public CExternalTableWithWordKey<MapMonster> MapMonsterTable;
  public CExternalTableWithWordKey<MapMonsterPrice> MapMonsterPriceTable;
  public CExternalTableWithWordKey<WondersInfoTbl> MapWondersInfoTable;
  public CExternalTableWithWordKey<MapWeaponDamageRange> MapWeaponDamageRangeTable;
  public ushort gotokingdomID;
  public Vector2 FocusWorldMapPos = -Vector2.one;
  public Vector2 coloneWorldMapPos = Vector2.zero;
  public Vector2 coltwoWorldMapPos = Vector2.zero;
  public float worldZoomSize = 0.75f;
  public int StartID;
  public CExternalTableWithWordKey<EmojiData> EmojiDataTable;
  public CExternalTableWithWordKey<Emote> EmoteTable;
  public CExternalTableWithWordKey<KingdomYolkDeploy> KingdomYolkDeployTable;
  public CExternalTableWithWordKey<YolkDeploy> YolkDeployTable;
  public byte showYolkNum = 7;
  public byte[] showYolkMapYolkID = new byte[40]
  {
    (byte) 0,
    (byte) 1,
    (byte) 2,
    (byte) 3,
    (byte) 4,
    (byte) 5,
    (byte) 6,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0
  };
  private CString[] yolkName;
  private byte[] yolkswitch = new byte[5];
  private byte MapBasePointSize = 39;
  private byte MapLineSize = 49;
  private byte MapKingdomSize = 40;
  private uint stateMapID;
  private byte mapStateKindCount;
  private byte[] stateKinds = new byte[(int) byte.MaxValue];
  private byte[] stateCounts = new byte[(int) byte.MaxValue];
  private ushort[][][] stateSkillIDs = new ushort[(int) byte.MaxValue][][];
  private byte[][][] stateSkillLevels = new byte[(int) byte.MaxValue][][];

  public MapManager()
  {
    this.kingdomData.kingdomID = this.kingdomData.kingKingdomID = this.kingdomData.allianceKingdomID = (ushort) 0;
    this.kingdomData.kingdomFlag = (byte) 0;
    this.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_NONE;
    this.kingdomData.kingName = new CString(13);
    this.kingdomData.allianceTag = new CString(4);
    this.kingdomData.allianceName = new CString(21);
    this.kingdomData.kingdomName = new CString(21);
    this.OtherKingdomData.kingdomID = this.OtherKingdomData.kingKingdomID = this.OtherKingdomData.allianceKingdomID = (ushort) 0;
    this.OtherKingdomData.kingdomFlag = (byte) 0;
    this.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_NONE;
    this.OtherKingdomData.kingName = new CString(13);
    this.OtherKingdomData.allianceTag = new CString(4);
    this.OtherKingdomData.allianceName = new CString(21);
    this.OtherKingdomData.kingdomName = new CString(21);
    for (int index = 0; index < 32; ++index)
    {
      this.WorldKingdomTable[index].kingdomID = this.WorldKingdomTable[index].kingKingdomID = this.WorldKingdomTable[index].allianceKingdomID = (ushort) 0;
      this.WorldKingdomTable[index].kingdomFlag = (byte) 0;
      this.WorldKingdomTable[index].kingdomPeriod = KINGDOM_PERIOD.KP_NONE;
      this.WorldKingdomTable[index].kingName = new CString(13);
      this.WorldKingdomTable[index].allianceTag = new CString(4);
      this.WorldKingdomTable[index].allianceName = new CString(21);
      this.WorldKingdomTable[index].kingdomName = new CString(21);
    }
    if (this.ZoneLineIDTable != null)
    {
      for (int index = 0; index < this.ZoneLineIDTable.Length; ++index)
        this.ZoneLineIDTable[index] = new List<ZoneLine>(32);
    }
    if (this.TempLineIDTable != null)
    {
      for (int index = 0; index < this.TempLineIDTable.Length; ++index)
        this.TempLineIDTable[index] = new List<ZoneLine>(32);
    }
    if (this.MapLineTable != null)
    {
      for (int index = 0; index < 256; ++index)
        this.MapLineTable.Add(new MapLine());
    }
    if (this.PlayerPointTable != null)
    {
      for (int index = 0; index < 2048; ++index)
      {
        this.PlayerPointTable[index].allianceTag = new CString(4);
        this.PlayerPointTable[index].allianceName = new CString(21);
        this.PlayerPointTable[index].playerName = new CString(13);
        this.PlayerPointTable[index].cityAttribute = new byte[6];
      }
    }
    if (this.ResourcesPointTable != null)
    {
      for (int index = 0; index < 2048; ++index)
      {
        this.ResourcesPointTable[index].allianceTag = new CString(4);
        this.ResourcesPointTable[index].playerName = new CString(13);
      }
    }
    if (this.YolkPointTable != null)
    {
      for (int index = 0; index < 40; ++index)
      {
        this.YolkPointTable[index].WonderID = (byte) index;
        this.YolkPointTable[index].WonderAllianceTag = new CString(4);
        this.YolkPointTable[index].OwnerAllianceName = new CString(21);
        this.YolkPointTable[index].WonderLeader = new CString(13);
        this.YolkPointTable[index].OwnerName = new CString(13);
        this.YolkPointTable[index].WonderState = byte.MaxValue;
        this.YolkPointTable[index].AllianceKingdomID = ushort.MaxValue;
      }
    }
    if (this.NPCPointTable != null)
    {
      for (int index = 0; index < 2048; ++index)
        this.NPCPointTable[index].NPCAllianceTag = new CString(21);
    }
    this.zoneID[0] = this.LastZoneID[0] = (ushort) 16384;
    this.waitZoneIDNum = (byte) 0;
    Array.Clear((Array) this.stateKinds, 0, this.stateKinds.Length);
    Array.Clear((Array) this.stateCounts, 0, this.stateCounts.Length);
    Array.Clear((Array) this.stateSkillIDs, 0, this.stateSkillIDs.Length);
    Array.Clear((Array) this.stateSkillLevels, 0, this.stateSkillLevels.Length);
  }

  public void Init() => this.LoadMapInfo();

  public void loginFinish()
  {
  }

  public void LoadTableData()
  {
    this.EmojiDataTable = new CExternalTableWithWordKey<EmojiData>();
    this.EmoteTable = new CExternalTableWithWordKey<Emote>();
    this.YolkDeployTable = new CExternalTableWithWordKey<YolkDeploy>();
    this.KingdomMapTable = new CExternalTableWithWordKey<KingdomMap>();
    this.MapMonsterTable = new CExternalTableWithWordKey<MapMonster>();
    this.MapMonsterPriceTable = new CExternalTableWithWordKey<MapMonsterPrice>();
    this.MapWondersInfoTable = new CExternalTableWithWordKey<WondersInfoTbl>();
    this.KingdomYolkDeployTable = new CExternalTableWithWordKey<KingdomYolkDeploy>();
    this.KingdomMapTable.LoadTable("Kingdom");
    this.KingdomYolkDeployTable.LoadTable("KingdomToWonders");
    this.MapMonsterPriceTable.LoadTable("MonsterTreasure");
    this.MapMonsterTable.LoadTable("Monster");
    this.MapWondersInfoTable.LoadTable("WondersInformation");
    this.EmojiDataTable.LoadTable("EMOJI");
    this.EmoteTable.LoadTable("Emote");
    this.YolkDeployTable.LoadTable("WonderPosition");
    if (this.yolkName != null)
      return;
    this.yolkName = new CString[this.MapWondersInfoTable.TableCount];
    for (int Index = 0; Index < this.yolkName.Length; ++Index)
    {
      this.yolkName[Index] = new CString(32);
      this.yolkName[Index].ClearString();
      this.yolkName[Index].Append(DataManager.Instance.mStringTable.GetStringByID((uint) this.MapWondersInfoTable.GetRecordByIndex(Index).NameID));
    }
  }

  public CString GetYolkName(ushort WonderID, ushort kingdomID = 0)
  {
    if (kingdomID == (ushort) 0)
      kingdomID = this.OtherKingdomData.kingdomID;
    KingdomYolkDeploy recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
    int Index;
    for (Index = 1; Index < this.KingdomYolkDeployTable.TableCount; ++Index)
    {
      recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(Index);
      if ((int) recordByIndex.kingdomID == (int) kingdomID)
        break;
    }
    if (Index >= this.KingdomYolkDeployTable.TableCount)
      recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
    if ((int) WonderID >= recordByIndex.yolkDeployIDs.Length)
      WonderID = (ushort) 0;
    YolkDeploy recordByKey = this.YolkDeployTable.GetRecordByKey(recordByIndex.yolkDeployIDs[(int) WonderID]);
    return (int) recordByKey.YolkNameID <= this.yolkName.Length ? this.yolkName[(int) recordByKey.YolkNameID - 1] : this.yolkName[0];
  }

  public Vector2 GetYolkPos(ushort WonderID, ushort kingdomID = 0)
  {
    if (kingdomID == (ushort) 0)
      kingdomID = this.OtherKingdomData.kingdomID;
    KingdomYolkDeploy recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
    int Index;
    for (Index = 1; Index < this.KingdomYolkDeployTable.TableCount; ++Index)
    {
      recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(Index);
      if ((int) recordByIndex.kingdomID == (int) kingdomID)
        break;
    }
    if (Index >= this.KingdomYolkDeployTable.TableCount)
      recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
    if ((int) WonderID >= recordByIndex.yolkDeployIDs.Length)
      WonderID = (ushort) 0;
    YolkDeploy recordByKey = this.YolkDeployTable.GetRecordByKey(recordByIndex.yolkDeployIDs[(int) WonderID]);
    return new Vector2((float) recordByKey.posX, (float) recordByKey.posY);
  }

  public Vector2 GetYolkPointCode(ushort WonderID, ushort kingdomID = 0)
  {
    Vector2 yolkPos = this.GetYolkPos(WonderID, kingdomID);
    Vector2 in_mapPos1 = yolkPos;
    ++in_mapPos1.x;
    Vector2 pointCode1 = GameConstants.MapPosToPointCode(yolkPos);
    Vector2 pointCode2 = GameConstants.MapPosToPointCode(in_mapPos1);
    if (pointCode1 == pointCode2)
    {
      Vector2 in_mapPos2 = yolkPos;
      ++in_mapPos2.y;
      pointCode1 = GameConstants.MapPosToPointCode(in_mapPos2);
    }
    return pointCode1;
  }

  public uint GetYolkMapID(ushort WonderID, ushort kingdomID = 0)
  {
    Vector2 yolkPointCode = this.GetYolkPointCode(WonderID, kingdomID);
    return (uint) GameConstants.PointCodeToMapID((ushort) yolkPointCode.x, (byte) yolkPointCode.y);
  }

  public bool CheckYolk(ushort WonderID, ushort kingdomID = 0)
  {
    if (this.yolkswitch == null)
      return false;
    ++WonderID;
    ushort index;
    byte bitShift;
    this.GetKingdomOpenIndexShift(WonderID, out index, out bitShift);
    return (int) index < this.yolkswitch.Length && ((int) this.yolkswitch[(int) index] & 1 << (int) bitShift) > 0;
  }

  public void ClearLayoutMapInfoYolkKind()
  {
    for (ushort index = 1; (int) index < (int) this.showYolkNum; ++index)
      this.LayoutMapInfo[(IntPtr) this.GetYolkMapID((ushort) this.showYolkMapYolkID[(int) index], this.FocusKingdomID)].pointKind = (byte) 0;
  }

  public void RequsetYolkswitch()
  {
    MessagePacket messagePacket = (int) this.FocusKingdomID == (int) this.OtherKingdomData.kingdomID ? new MessagePacket((ushort) 1024) : MessagePacket.GetGuestMessagePack();
    messagePacket.Protocol = Protocol._MSG_REQUEST_WONDER_SWITCH;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void UpdateYolkswitch(MessagePacket MP)
  {
    if (this.yolkswitch == null)
      return;
    for (byte index1 = 0; (int) index1 < this.yolkswitch.Length; ++index1)
    {
      byte num = MP.ReadByte();
      this.yolkswitch[(int) index1] ^= num;
      if (this.yolkswitch[(int) index1] != (byte) 0)
      {
        for (byte index2 = 0; index2 < (byte) 8; ++index2)
        {
          if (((int) this.yolkswitch[(int) index1] & 1 << (int) index2) != 0 && ((int) num & 1 << (int) index2) == 0)
          {
            byte WonderID = (byte) ((uint) index1 * 8U + (uint) index2);
            uint yolkMapId = this.GetYolkMapID((ushort) WonderID, this.FocusKingdomID);
            if (WonderID < (byte) 40)
              this.LayoutMapInfo[(IntPtr) yolkMapId].pointKind = (byte) 0;
            this.PointNotifyObserver(yolkMapId);
          }
        }
      }
      this.yolkswitch[(int) index1] = num;
    }
    this.showYolkNum = (byte) 0;
    for (byte WonderID = 0; WonderID < (byte) 40; ++WonderID)
    {
      if (this.CheckYolk((ushort) WonderID, this.FocusKingdomID))
      {
        uint yolkMapId = this.GetYolkMapID((ushort) WonderID, this.FocusKingdomID);
        this.showYolkMapYolkID[(int) this.showYolkNum++] = WonderID;
        this.LayoutMapInfo[(IntPtr) yolkMapId].pointKind = (byte) 11;
        this.LayoutMapInfo[(IntPtr) yolkMapId].tableID = (ushort) WonderID;
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 0);
  }

  public ushort getYolkIDbyMapID(int inMapID, ushort inkingdomID = 0)
  {
    if ((int) inkingdomID == (int) this.FocusKingdomID)
    {
      for (byte index = 0; (int) index < (int) this.showYolkNum; ++index)
      {
        if (inMapID == (int) this.GetYolkMapID((ushort) this.showYolkMapYolkID[(int) index], inkingdomID))
          return (ushort) this.showYolkMapYolkID[(int) index];
      }
    }
    else
    {
      for (ushort WonderID = 0; WonderID < (ushort) 40; ++WonderID)
      {
        if (inMapID == (int) this.GetYolkMapID(WonderID, inkingdomID))
          return WonderID;
      }
    }
    return 40;
  }

  public ushort getYolkIDbyPointCode(ushort inZoneID, byte inPointID, ushort inkingdomID = 0)
  {
    if (inkingdomID == (ushort) 0)
      inkingdomID = this.OtherKingdomData.kingdomID;
    return this.getYolkIDbyMapID(GameConstants.PointCodeToMapID(inZoneID, inPointID), inkingdomID);
  }

  public float CalcDistance(int startmapID, int endmapID, ushort inkingdomID = 0)
  {
    if (inkingdomID == (ushort) 0)
      inkingdomID = this.OtherKingdomData.kingdomID;
    Vector2 mapPosbySpriteId1 = GameConstants.getTileMapPosbySpriteID(startmapID);
    if (this.getYolkIDbyMapID(startmapID, inkingdomID) != (ushort) 40)
      --mapPosbySpriteId1.y;
    Vector2 mapPosbySpriteId2 = GameConstants.getTileMapPosbySpriteID(endmapID);
    if (this.getYolkIDbyMapID(endmapID, inkingdomID) != (ushort) 40)
      --mapPosbySpriteId2.y;
    return GameConstants.FastInvSqrt((mapPosbySpriteId2 - mapPosbySpriteId1).sqrMagnitude);
  }

  public void OutMap()
  {
    this.lastReqKingdomIDNum = (byte) 0;
    if (this.zoneID[0] == (ushort) 16384)
      return;
    if ((int) this.checkZone >> (int) this.zoneIDNum == 1)
    {
      for (byte index = 0; index < (byte) 4; ++index)
        this.LastZoneID[(int) index] = this.zoneID[(int) index];
      this.LastZoneIDNum = this.zoneIDNum;
    }
    this.checkZone = (byte) 2;
    Array.Clear((Array) this.zoneID, 0, 4);
    this.zoneID[0] = (ushort) 16384;
    ulong data = 0;
    this.zoneIDNum = (byte) 1;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_MAPDATA;
    messagePacket.AddSeqId();
    messagePacket.Add(this.zoneIDNum);
    for (int index = 0; index < 4; ++index)
      messagePacket.Add(this.zoneID[index]);
    for (int index = 0; index < 4; ++index)
      messagePacket.Add(data);
    messagePacket.Send();
  }

  public void RequsetAdvanceMapdata(int mapPointID)
  {
    this.stateMapID = (uint) mapPointID;
    this.mapStateKindCount = (byte) 0;
    ushort zoneID = 0;
    byte pointID = 0;
    GameConstants.MapIDToPointCode(mapPointID, out zoneID, out pointID);
    MessagePacket messagePacket = (int) this.FocusKingdomID == (int) this.OtherKingdomData.kingdomID ? new MessagePacket((ushort) 1024) : MessagePacket.GetGuestMessagePack();
    messagePacket.Protocol = Protocol._MSG_REQUEST_MAP_ADVANCE;
    messagePacket.AddSeqId();
    messagePacket.Add(zoneID);
    messagePacket.Add(pointID);
    messagePacket.Send();
  }

  public void RequsetLineInZone(ushort ZoneID)
  {
  }

  public void RequsetLineByID(ushort LineID)
  {
  }

  public void RecvMapInfoPlus(MessagePacket MP)
  {
    MAP_UPDATE_KIND mapUpdateKind = (MAP_UPDATE_KIND) MP.ReadByte();
    ushort num1 = 0;
    while (true)
    {
      switch (mapUpdateKind)
      {
        case MAP_UPDATE_KIND.MAPUPDATE_NONE:
          goto label_472;
        case MAP_UPDATE_KIND.MAPUPDATE_MAX:
        case MAP_UPDATE_KIND.MAPUPDATE_END:
          ushort num2 = MP.ReadUShort();
          byte num3 = (byte) ((uint) num2 >> 12);
          byte num4 = (byte) ((int) num2 >> 6 & 63);
          byte num5 = (byte) ((uint) num2 & 63U);
          if (num3 > (byte) 0 && this.UpdateZoneIDNum != (byte) 0)
          {
            for (int index = 0; index < (int) this.UpdateZoneIDNum; ++index)
              this.ZoneNotifyObserver(this.UpdateZoneID[index]);
            this.UpdateZoneIDNum = (byte) 0;
          }
          for (int index = 0; index < (int) num3; ++index)
          {
            ++this.UpdateZoneIDNum;
            this.UpdateZoneID[index] = num1 = MP.ReadUShort();
            this.ZoneUpdateNum[index] = MP.ReadULong();
            if (this.ZoneUpdateNum[index] == 0UL)
              ++this.ZoneUpdateNum[index];
          }
          if (num3 != (byte) 0)
          {
            this.checkZoneLine(this.UpdateZoneIDNum, this.UpdateZoneID);
            for (int index = 0; index < (int) this.UpdateZoneIDNum; ++index)
            {
              int num6 = (int) this.CheckZoneID(this.UpdateZoneID[index], true);
              this.ZoneUpdateInfo[(int) this.UpdateZoneID[index]].updateNum = this.ZoneUpdateNum[index];
            }
            byte num7 = MP.ReadByte();
            if (num7 > (byte) 39 && num7 <= (byte) 128)
              this.MapBasePointSize = num7;
            byte num8 = MP.ReadByte();
            if (num8 > (byte) 49 && num8 <= (byte) 128)
              this.MapLineSize = num8;
          }
          byte num9 = (byte) ((uint) this.MapBasePointSize - 4U);
          for (int index1 = 0; index1 < (int) num4; ++index1)
          {
            uint mapId = (uint) GameConstants.PointCodeToMapID(MP.ReadUShort(), MP.ReadByte());
            if (this.IsCityOrCamp(mapId))
              this.PlayerPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId].tableID);
            else if (this.IsResources(mapId))
              this.ResourcesPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId].tableID);
            else if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 10)
              this.NPCPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId].tableID);
            this.LayoutMapInfo[(IntPtr) mapId].pointKind = MP.ReadByte();
            if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 12)
            {
              this.LayoutMapInfo[(IntPtr) mapId].tableID = (ushort) MP.ReadByte();
              for (int index2 = (int) num9 - 1; index2 > 0; --index2)
              {
                int num10 = (int) MP.ReadByte();
              }
            }
            else if (this.IsCityOrCamp(mapId))
            {
              ushort index3;
              this.LayoutMapInfo[(IntPtr) mapId].tableID = index3 = (ushort) this.PlayerPointTableIDpool.spawn();
              MP.ReadStringPlus(13, this.PlayerPointTable[(int) index3].playerName);
              MP.ReadStringPlus(3, this.PlayerPointTable[(int) index3].allianceTag);
              this.PlayerPointTable[(int) index3].kingdomID = MP.ReadUShort();
              this.PlayerPointTable[(int) index3].level = MP.ReadByte();
              this.PlayerPointTable[(int) index3].capitalFlag = MP.ReadByte();
              this.PlayerPointTable[(int) index3].kingdomTitle = (KINGDOM_DESIGNATION) MP.ReadByte();
              this.PlayerPointTable[(int) index3].worldTitle = (WORLD_PLAYER_DESIGNATION) MP.ReadByte();
              this.PlayerPointTable[(int) index3].allianceKingdomID = MP.ReadUShort();
              this.PlayerPointTable[(int) index3].cityProperty = (CITY_PROPERTY) MP.ReadByte();
              this.PlayerPointTable[(int) index3].cityOutward = (CITY_OUTWARD) MP.ReadByte();
              this.PlayerPointTable[(int) index3].cityOutwardLevel = MP.ReadByte();
              this.PlayerPointTable[(int) index3].nobilityTitle = MP.ReadByte();
              for (int index4 = 0; index4 < this.PlayerPointTable[(int) index3].cityAttribute.Length; ++index4)
                this.PlayerPointTable[(int) index3].cityAttribute[index4] = MP.ReadByte();
              for (int index5 = (int) num9 - 34 - 3; index5 > 0; --index5)
              {
                int num11 = (int) MP.ReadByte();
              }
              this.PlayerPointTable[(int) index3].baseFlag = MP.ReadByte();
              this.PlayerPointTable[(int) index3].emojiID = MP.ReadUShort();
            }
            else if (this.IsResources(mapId))
            {
              ushort index6;
              this.LayoutMapInfo[(IntPtr) mapId].tableID = index6 = (ushort) this.ResourcesPointTableIDpool.spawn();
              MP.ReadStringPlus(13, this.ResourcesPointTable[(int) index6].playerName);
              MP.ReadStringPlus(3, this.ResourcesPointTable[(int) index6].allianceTag);
              this.ResourcesPointTable[(int) index6].kingdomID = MP.ReadUShort();
              this.ResourcesPointTable[(int) index6].level = MP.ReadByte();
              this.ResourcesPointTable[(int) index6].count = MP.ReadUInt();
              this.ResourcesPointTable[(int) index6].rate = MP.ReadFloat();
              this.ResourcesPointTable[(int) index6].time = MP.ReadULong();
              for (int index7 = (int) num9 - 35 - 3; index7 > 0; --index7)
              {
                int num12 = (int) MP.ReadByte();
              }
              this.ResourcesPointTable[(int) index6].baseFlag = MP.ReadByte();
              this.ResourcesPointTable[(int) index6].emojiID = MP.ReadUShort();
            }
            else if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 10)
            {
              ushort index8;
              this.LayoutMapInfo[(IntPtr) mapId].tableID = index8 = (ushort) this.NPCPointTableIDpool.spawn();
              this.NPCPointTable[(int) index8].level = MP.ReadByte();
              this.NPCPointTable[(int) index8].NPCNum = MP.ReadUShort();
              if (this.NPCPointTable[(int) index8].NPCNum < (ushort) 2 || (int) this.NPCPointTable[(int) index8].NPCNum >= this.MapMonsterTable.TableCount)
                this.NPCPointTable[(int) index8].NPCNum = (ushort) 2;
              this.NPCPointTable[(int) index8].Key = MP.ReadUInt();
              this.NPCPointTable[(int) index8].Blood = MP.ReadFloat();
              MP.ReadStringPlus(3, this.NPCPointTable[(int) index8].NPCAllianceTag);
              this.NPCPointTable[(int) index8].endTime = MP.ReadULong();
              for (int index9 = (int) num9 - 22 - 3; index9 > 0; --index9)
              {
                int num13 = (int) MP.ReadByte();
              }
              this.NPCPointTable[(int) index8].baseFlag = MP.ReadByte();
              this.NPCPointTable[(int) index8].emojiID = MP.ReadUShort();
            }
            else if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 11)
            {
              ushort WonderID;
              this.LayoutMapInfo[(IntPtr) mapId].tableID = WonderID = (ushort) MP.ReadByte();
              this.YolkPointTable[(int) WonderID].WonderID = (byte) WonderID;
              this.YolkPointTable[(int) WonderID].WonderState = MP.ReadByte();
              this.YolkPointTable[(int) WonderID].StateBegin = MP.ReadULong();
              this.YolkPointTable[(int) WonderID].StateDuring = MP.ReadUInt();
              this.YolkPointTable[(int) WonderID].OwnerEmblem = MP.ReadUShort();
              MP.ReadStringPlus(13, this.YolkPointTable[(int) WonderID].WonderLeader);
              MP.ReadStringPlus(3, this.YolkPointTable[(int) WonderID].WonderAllianceTag);
              this.YolkPointTable[(int) WonderID].LeaderKingdomID = MP.ReadUShort();
              this.YolkPointTable[(int) WonderID].WonderFlag = MP.ReadByte();
              this.YolkPointTable[(int) WonderID].AllianceKingdomID = MP.ReadUShort();
              this.YolkPointTable[(int) WonderID].LeaderHomeKingdomID = MP.ReadUShort();
              for (int index10 = (int) num9 - 39 - 3; index10 > 0; --index10)
              {
                int num14 = (int) MP.ReadByte();
              }
              this.YolkPointTable[(int) WonderID].baseFlag = MP.ReadByte();
              this.YolkPointTable[(int) WonderID].emojiID = MP.ReadUShort();
              if (!this.CheckYolk(WonderID, this.FocusKingdomID))
              {
                this.LayoutMapInfo[(IntPtr) mapId].pointKind = (byte) 0;
              }
              else
              {
                DataManager.msgBuffer[0] = (byte) 94;
                GameConstants.GetBytes(WonderID, DataManager.msgBuffer, 1);
                GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              }
            }
            else
            {
              for (int index11 = (int) num9; index11 > 0; --index11)
              {
                int num15 = (int) MP.ReadByte();
              }
            }
          }
          for (int index12 = 0; index12 < (int) num5; ++index12)
          {
            uint lineID = MP.ReadUInt();
            int lineTableId = this.getLineTableID(lineID);
            if (lineTableId == 1048576)
            {
              int num16 = this.MapLineTableIDpool.spawn();
              while (num16 >= this.MapLineTable.Count)
                this.MapLineTable.Add(new MapLine());
              this.MapLineTable[num16].lineID = lineID;
              MP.ReadStringPlus(13, this.MapLineTable[num16].playerName);
              MP.ReadStringPlus(3, this.MapLineTable[num16].allianceTag);
              this.MapLineTable[num16].kingdomID = MP.ReadUShort();
              this.MapLineTable[num16].start.zoneID = MP.ReadUShort();
              this.MapLineTable[num16].start.pointID = MP.ReadByte();
              this.MapLineTable[num16].end.zoneID = MP.ReadUShort();
              this.MapLineTable[num16].end.pointID = MP.ReadByte();
              this.MapLineTable[num16].begin = MP.ReadULong();
              this.MapLineTable[num16].during = MP.ReadUInt();
              this.MapLineTable[num16].EXbegin = MP.ReadUInt();
              this.MapLineTable[num16].EXduring = MP.ReadUInt();
              this.MapLineTable[num16].lineFlag = MP.ReadByte();
              this.MapLineTable[num16].baseFlag = MP.ReadByte();
              this.MapLineTable[num16].emojiID = MP.ReadUShort();
              if ((int) this.MapLineTable[num16].start.zoneID == (int) this.MapLineTable[num16].end.zoneID && (int) this.MapLineTable[num16].start.pointID == (int) this.MapLineTable[num16].end.pointID || this.MapLineTable[num16].playerName[0] == char.MinValue)
              {
                this.MapLineTableIDpool.despawn(num16);
                this.MapLineTable[num16].MapLineInit();
              }
              else
                this.addLine(num16);
            }
            else
            {
              this.MapLineTable[lineTableId].lineID = lineID;
              MP.ReadStringPlus(13, this.MapLineTable[lineTableId].playerName);
              MP.ReadStringPlus(3, this.MapLineTable[lineTableId].allianceTag);
              this.MapLineTable[lineTableId].kingdomID = MP.ReadUShort();
              this.MapLineTable[lineTableId].start.zoneID = MP.ReadUShort();
              this.MapLineTable[lineTableId].start.pointID = MP.ReadByte();
              this.MapLineTable[lineTableId].end.zoneID = MP.ReadUShort();
              this.MapLineTable[lineTableId].end.pointID = MP.ReadByte();
              this.MapLineTable[lineTableId].begin = MP.ReadULong();
              this.MapLineTable[lineTableId].during = MP.ReadUInt();
              this.MapLineTable[lineTableId].EXbegin = MP.ReadUInt();
              this.MapLineTable[lineTableId].EXduring = MP.ReadUInt();
              this.MapLineTable[lineTableId].lineFlag = MP.ReadByte();
              byte num17 = MP.ReadByte();
              ushort num18 = MP.ReadUShort();
              if ((UnityEngine.Object) this.MapLineTable[lineTableId].lineObject != (UnityEngine.Object) null)
              {
                if (((int) this.MapLineTable[lineTableId].baseFlag & 1) != ((int) num17 & 1) || (int) num18 != (int) this.MapLineTable[lineTableId].emojiID)
                {
                  this.MapLineTable[lineTableId].baseFlag = num17;
                  this.MapLineTable[lineTableId].emojiID = num18;
                  this.LineNotifyObserver((byte) 61, lineTableId, (byte) 1);
                }
                if (((int) this.MapLineTable[lineTableId].baseFlag & 2) != ((int) num17 & 2))
                {
                  this.MapLineTable[lineTableId].baseFlag = num17;
                  this.MapLineTable[lineTableId].emojiID = num18;
                  this.LineNotifyObserver((byte) 62, lineTableId, (byte) 1);
                }
              }
              else
              {
                this.MapLineTable[lineTableId].baseFlag = num17;
                this.MapLineTable[lineTableId].emojiID = num18;
              }
              double num19 = Math.Round(640000000000.0);
              for (int index13 = 0; index13 < (int) this.UpdateZoneIDNum; ++index13)
              {
                if (lineTableId != this.getLineTableID(this.UpdateZoneID[index13], lineID))
                {
                  bool flag = (int) this.MapLineTable[lineTableId].start.zoneID == (int) this.UpdateZoneID[index13] || (int) this.MapLineTable[lineTableId].end.zoneID == (int) this.UpdateZoneID[index13];
                  if (!flag)
                  {
                    Vector2 mapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(this.UpdateZoneID[index13], (byte) 0);
                    mapPosbyPointCode.x *= 2f;
                    if ((double) mapPosbyPointCode.x < (double) this.MapLineTable[lineTableId].zoneMax.x && (double) mapPosbyPointCode.x >= (double) this.MapLineTable[lineTableId].zoneMin.x && (double) mapPosbyPointCode.y < (double) this.MapLineTable[lineTableId].zoneMax.y && (double) mapPosbyPointCode.y >= (double) this.MapLineTable[lineTableId].zoneMin.y)
                    {
                      if (this.MapLineTable[lineTableId].XIntercept < 0.0)
                      {
                        if (this.MapLineTable[lineTableId].Slope == 0.0)
                        {
                          flag = this.MapLineTable[lineTableId].YIntercept >= (double) mapPosbyPointCode.y && this.MapLineTable[lineTableId].YIntercept < (double) mapPosbyPointCode.y + 16.0;
                        }
                        else
                        {
                          double num20 = Math.Round((this.MapLineTable[lineTableId].Slope * (double) mapPosbyPointCode.x + this.MapLineTable[lineTableId].YIntercept) * 10000000000.0);
                          double num21 = Math.Round((this.MapLineTable[lineTableId].Slope * ((double) mapPosbyPointCode.x + 64.0) + this.MapLineTable[lineTableId].YIntercept) * 10000000000.0);
                          double num22 = Math.Round(((double) mapPosbyPointCode.y - this.MapLineTable[lineTableId].YIntercept) / this.MapLineTable[lineTableId].Slope * 10000000000.0);
                          double num23 = Math.Round(((double) mapPosbyPointCode.y + 16.0 - this.MapLineTable[lineTableId].YIntercept) / this.MapLineTable[lineTableId].Slope * 10000000000.0);
                          double num24 = Math.Round((double) mapPosbyPointCode.y * 10000000000.0);
                          double num25 = Math.Round((double) mapPosbyPointCode.x * 10000000000.0);
                          double num26 = Math.Round(160000000000.0);
                          flag = num20 >= num24 && num20 < num24 + num26 || num21 > num24 && num21 < num24 + num26 || num22 >= num25 && num22 < num25 + num19 || num23 > num25 && num23 < num25 + num19 || num21 == num24 && num21 + num26 == num20 && num23 == num25 && num23 + num19 == num22;
                        }
                      }
                      else
                        flag = this.MapLineTable[lineTableId].XIntercept >= (double) mapPosbyPointCode.x && this.MapLineTable[lineTableId].XIntercept < (double) mapPosbyPointCode.x + 64.0;
                    }
                  }
                  if (flag)
                  {
                    int zoneState = (int) this.ZoneUpdateInfo[(int) this.UpdateZoneID[index13]].zoneState;
                    if (this.MapLineTable[lineTableId].ZoneIDTable[zoneState] == 1048576)
                    {
                      this.MapLineTable[lineTableId].ZoneIDTable[zoneState] = this.ZoneLineIDTable[zoneState].Count;
                      ++this.MapLineTable[lineTableId].zoneNum;
                      ZoneLine zoneLine;
                      zoneLine.lineID = this.MapLineTable[lineTableId].lineID;
                      zoneLine.lineTableID = (ushort) lineTableId;
                      this.ZoneLineIDTable[zoneState].Add(zoneLine);
                    }
                  }
                }
              }
            }
            for (int index14 = (int) this.MapLineSize - 52; index14 > 0; --index14)
            {
              int num27 = (int) MP.ReadByte();
            }
          }
          if (mapUpdateKind == MAP_UPDATE_KIND.MAPUPDATE_END)
          {
            for (int index = 0; index < (int) this.UpdateZoneIDNum; ++index)
              this.ZoneNotifyObserver(this.UpdateZoneID[index]);
            this.UpdateZoneIDNum = (byte) 0;
            break;
          }
          break;
        case MAP_UPDATE_KIND.MAPUPDATE_ZONE_NONE:
          int num28 = (int) this.CheckZoneID(MP.ReadUShort());
          break;
        case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM:
          byte num29 = MP.ReadByte();
          if ((int) num29 > (int) this.MapKingdomSize && num29 <= (byte) 128)
            this.MapKingdomSize = num29;
          this.updateKingdomNum = MP.ReadByte();
          int num30 = 16 - (int) this.updateKingdomNum;
          ulong num31 = 0;
          int num32 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
          for (int index15 = 0; index15 < (int) this.updateKingdomNum; ++index15)
          {
            num31 = MP.ReadULong();
            this.updateKingdomID[index15] = MP.ReadUShort();
            KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(this.updateKingdomID[index15]);
            int index16 = (int) recordByKey.worldPosX - (int) this.WorldMinX + ((int) recordByKey.worldPosY - (int) this.WorldMinY) * num32;
            int kingdomtableid = (int) this.TileMapKingdomID[index16].tableID;
            if ((int) this.TileMapKingdomID[index16].KingdomID != (int) this.WorldKingdomTable[kingdomtableid].kingdomID)
            {
              kingdomtableid = (int) this.WorldKingdomTableIDcounter++;
              this.WorldKingdomTableIDcounter &= (byte) 31;
            }
            this.TileMapKingdomID[index16].tableID = (byte) kingdomtableid;
            this.WorldKingdomTable[kingdomtableid].kingdomID = this.updateKingdomID[index15];
            this.WorldKingdomTable[kingdomtableid].kingdomFlag = MP.ReadByte();
            this.WorldKingdomTable[kingdomtableid].kingdomPeriod = (KINGDOM_PERIOD) MP.ReadByte();
            this.WorldKingdomTable[kingdomtableid].kingName.ClearString();
            MP.ReadStringPlus(13, this.WorldKingdomTable[kingdomtableid].kingName);
            this.WorldKingdomTable[kingdomtableid].allianceTag.ClearString();
            MP.ReadStringPlus(3, this.WorldKingdomTable[kingdomtableid].allianceTag);
            this.WorldKingdomTable[kingdomtableid].allianceName.ClearString();
            MP.ReadStringPlus(20, this.WorldKingdomTable[kingdomtableid].allianceName);
            this.GetKingdomName(this.WorldKingdomTable[kingdomtableid].kingdomID, ref this.WorldKingdomTable[kingdomtableid].kingdomName);
            for (int index17 = (int) num29 - 40; index17 > 0; --index17)
            {
              int num33 = (int) MP.ReadByte();
            }
            this.KingdomNotifyObserver((byte) kingdomtableid, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM);
          }
          if ((int) this.updateKingdomNum <= (int) this.reqKingdomIDNum)
          {
            int index18 = 0;
            int index19;
            for (index19 = 0; index18 < (int) this.reqKingdomIDNum && index19 < (int) this.updateKingdomNum; ++index18)
            {
              if ((int) this.reqKingdomID[index18] == (int) this.updateKingdomID[index19])
                ++index19;
            }
            if (index19 == (int) this.updateKingdomNum)
            {
              DataManager.msgBuffer[0] = (byte) 107;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              this.wait = 0.0f;
            }
          }
          if ((double) this.wait != 0.0)
          {
            DataManager.msgBuffer[0] = (byte) 107;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
            this.wait = 0.0f;
            break;
          }
          break;
        default:
          ulong num34 = MP.ReadULong();
          switch (mapUpdateKind)
          {
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_ADD:
              short num35 = MP.ReadShort();
              ushort index20 = MP.ReadUShort();
              int num36 = (int) this.CheckZoneID(index20);
              byte pointID1 = MP.ReadByte();
              uint num37 = 0;
              short num38 = (short) ((int) num35 - 3);
              this.ZoneUpdateInfo[(int) index20].updateNum = num34;
              if (this.ZoneUpdateInfo[(int) index20].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index20].zoneState].zoneID == (int) index20)
              {
                bool flag = true;
                byte num39 = MP.ReadByte();
                short num40 = (short) ((int) num38 - 1);
                uint mapId = (uint) GameConstants.PointCodeToMapID(index20, pointID1);
                if (this.IsCityOrCamp(mapId))
                  this.PlayerPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId].tableID);
                else if (this.IsResources(mapId))
                  this.ResourcesPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId].tableID);
                else if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 10)
                {
                  ushort tableId = this.LayoutMapInfo[(IntPtr) mapId].tableID;
                  num37 = this.NPCPointTable[(int) tableId].NPCAllianceTag == null || this.NPCPointTable[(int) tableId].NPCAllianceTag[0] == char.MinValue ? this.NPCPointTable[(int) tableId].Key - 1U : this.NPCPointTable[(int) tableId].Key;
                  this.NPCPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId].tableID);
                }
                this.LayoutMapInfo[(IntPtr) mapId].pointKind = num39;
                if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 12)
                {
                  this.LayoutMapInfo[(IntPtr) mapId].tableID = (ushort) MP.ReadByte();
                  for (int index21 = (int) num40 - 1; index21 > 0; --index21)
                  {
                    int num41 = (int) MP.ReadByte();
                  }
                }
                else if (this.IsCityOrCamp(mapId))
                {
                  ushort index22;
                  this.LayoutMapInfo[(IntPtr) mapId].tableID = index22 = (ushort) this.PlayerPointTableIDpool.spawn();
                  MP.ReadStringPlus(13, this.PlayerPointTable[(int) index22].playerName);
                  MP.ReadStringPlus(3, this.PlayerPointTable[(int) index22].allianceTag);
                  this.PlayerPointTable[(int) index22].kingdomID = MP.ReadUShort();
                  this.PlayerPointTable[(int) index22].level = MP.ReadByte();
                  this.PlayerPointTable[(int) index22].capitalFlag = MP.ReadByte();
                  this.PlayerPointTable[(int) index22].kingdomTitle = (KINGDOM_DESIGNATION) MP.ReadByte();
                  this.PlayerPointTable[(int) index22].worldTitle = (WORLD_PLAYER_DESIGNATION) MP.ReadByte();
                  this.PlayerPointTable[(int) index22].allianceKingdomID = MP.ReadUShort();
                  this.PlayerPointTable[(int) index22].cityProperty = (CITY_PROPERTY) MP.ReadByte();
                  this.PlayerPointTable[(int) index22].cityOutward = (CITY_OUTWARD) MP.ReadByte();
                  this.PlayerPointTable[(int) index22].cityOutwardLevel = MP.ReadByte();
                  this.PlayerPointTable[(int) index22].nobilityTitle = MP.ReadByte();
                  for (int index23 = 0; index23 < this.PlayerPointTable[(int) index22].cityAttribute.Length; ++index23)
                    this.PlayerPointTable[(int) index22].cityAttribute[index23] = MP.ReadByte();
                  for (int index24 = (int) num40 - 34 - 3; index24 > 0; --index24)
                  {
                    int num42 = (int) MP.ReadByte();
                  }
                  this.PlayerPointTable[(int) index22].baseFlag = MP.ReadByte();
                  this.PlayerPointTable[(int) index22].emojiID = MP.ReadUShort();
                }
                else if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 10)
                {
                  ushort index25;
                  this.LayoutMapInfo[(IntPtr) mapId].tableID = index25 = (ushort) this.NPCPointTableIDpool.spawn();
                  this.NPCPointTable[(int) index25].level = MP.ReadByte();
                  this.NPCPointTable[(int) index25].NPCNum = MP.ReadUShort();
                  if (this.NPCPointTable[(int) index25].NPCNum < (ushort) 2 || (int) this.NPCPointTable[(int) index25].NPCNum >= this.MapMonsterTable.TableCount)
                    this.NPCPointTable[(int) index25].NPCNum = (ushort) 2;
                  this.NPCPointTable[(int) index25].Key = MP.ReadUInt();
                  this.NPCPointTable[(int) index25].Blood = MP.ReadFloat();
                  MP.ReadStringPlus(3, this.NPCPointTable[(int) index25].NPCAllianceTag);
                  this.NPCPointTable[(int) index25].endTime = MP.ReadULong();
                  for (int index26 = (int) num40 - 22 - 3; index26 > 0; --index26)
                  {
                    int num43 = (int) MP.ReadByte();
                  }
                  this.NPCPointTable[(int) index25].baseFlag = MP.ReadByte();
                  this.NPCPointTable[(int) index25].emojiID = MP.ReadUShort();
                  flag = false;
                  if (this.NPCPointTable[(int) index25].NPCAllianceTag != null && this.NPCPointTable[(int) index25].NPCAllianceTag[0] != char.MinValue)
                    flag = (int) num37 == (int) this.NPCPointTable[(int) index25].Key;
                }
                else if (this.LayoutMapInfo[(IntPtr) mapId].pointKind == (byte) 11)
                {
                  ushort WonderID;
                  this.LayoutMapInfo[(IntPtr) mapId].tableID = WonderID = (ushort) MP.ReadByte();
                  this.YolkPointTable[(int) WonderID].WonderID = (byte) WonderID;
                  this.YolkPointTable[(int) WonderID].WonderState = MP.ReadByte();
                  this.YolkPointTable[(int) WonderID].StateBegin = MP.ReadULong();
                  this.YolkPointTable[(int) WonderID].StateDuring = MP.ReadUInt();
                  this.YolkPointTable[(int) WonderID].OwnerEmblem = MP.ReadUShort();
                  MP.ReadStringPlus(13, this.YolkPointTable[(int) WonderID].WonderLeader);
                  MP.ReadStringPlus(3, this.YolkPointTable[(int) WonderID].WonderAllianceTag);
                  this.YolkPointTable[(int) WonderID].LeaderKingdomID = MP.ReadUShort();
                  this.YolkPointTable[(int) WonderID].WonderFlag = MP.ReadByte();
                  this.YolkPointTable[(int) WonderID].AllianceKingdomID = MP.ReadUShort();
                  this.YolkPointTable[(int) WonderID].LeaderHomeKingdomID = MP.ReadUShort();
                  for (int index27 = (int) num40 - 39 - 3; index27 > 0; --index27)
                  {
                    int num44 = (int) MP.ReadByte();
                  }
                  this.YolkPointTable[(int) WonderID].baseFlag = MP.ReadByte();
                  this.YolkPointTable[(int) WonderID].emojiID = MP.ReadUShort();
                  if (!this.CheckYolk(WonderID, this.FocusKingdomID))
                  {
                    this.LayoutMapInfo[(IntPtr) mapId].pointKind = (byte) 0;
                  }
                  else
                  {
                    DataManager.msgBuffer[0] = (byte) 94;
                    GameConstants.GetBytes(WonderID, DataManager.msgBuffer, 1);
                    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                  }
                }
                else if (this.IsResources(mapId))
                {
                  ushort index28;
                  this.LayoutMapInfo[(IntPtr) mapId].tableID = index28 = (ushort) this.ResourcesPointTableIDpool.spawn();
                  MP.ReadStringPlus(13, this.ResourcesPointTable[(int) index28].playerName);
                  MP.ReadStringPlus(3, this.ResourcesPointTable[(int) index28].allianceTag);
                  this.ResourcesPointTable[(int) index28].kingdomID = MP.ReadUShort();
                  this.ResourcesPointTable[(int) index28].level = MP.ReadByte();
                  this.ResourcesPointTable[(int) index28].count = MP.ReadUInt();
                  this.ResourcesPointTable[(int) index28].rate = MP.ReadFloat();
                  this.ResourcesPointTable[(int) index28].time = MP.ReadULong();
                  for (int index29 = (int) num40 - 35 - 3; index29 > 0; --index29)
                  {
                    int num45 = (int) MP.ReadByte();
                  }
                  this.ResourcesPointTable[(int) index28].baseFlag = MP.ReadByte();
                  this.ResourcesPointTable[(int) index28].emojiID = MP.ReadUShort();
                }
                else
                {
                  for (int index30 = (int) num40; index30 > 0; --index30)
                  {
                    int num46 = (int) MP.ReadByte();
                  }
                }
                if (flag)
                {
                  this.PointNotifyObserver(mapId);
                  break;
                }
                DataManager.msgBuffer[0] = (byte) 87;
                GameConstants.GetBytes(mapId, DataManager.msgBuffer, 1);
                GameConstants.GetBytes(-2f, DataManager.msgBuffer, 5);
                GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                break;
              }
              for (int index31 = (int) num38; index31 > 0; --index31)
              {
                int num47 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_DEL:
              ushort index32 = MP.ReadUShort();
              int num48 = (int) this.CheckZoneID(index32);
              byte pointID2 = MP.ReadByte();
              if ((int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index32].zoneState].zoneID == (int) index32)
                this.ZoneUpdateInfo[(int) index32].updateNum = num34;
              uint mapId1 = (uint) GameConstants.PointCodeToMapID(index32, pointID2);
              if (this.LayoutMapInfo[(IntPtr) mapId1].pointKind > (byte) 0)
              {
                bool flag = true;
                if (this.IsCityOrCamp(mapId1))
                  this.PlayerPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId1].tableID);
                else if (this.IsResources(mapId1))
                  this.ResourcesPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId1].tableID);
                else if (this.LayoutMapInfo[(IntPtr) mapId1].pointKind == (byte) 10)
                {
                  if (!(GameManager.ActiveGameplay is CHAOS))
                  {
                    this.NPCPointTableIDpool.despawn((int) this.LayoutMapInfo[(IntPtr) mapId1].tableID);
                  }
                  else
                  {
                    flag = false;
                    DataManager.msgBuffer[0] = (byte) 87;
                    GameConstants.GetBytes(mapId1, DataManager.msgBuffer, 1);
                    GameConstants.GetBytes(-1f, DataManager.msgBuffer, 5);
                    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                  }
                }
                if (flag)
                {
                  this.LayoutMapInfo[(IntPtr) mapId1].pointKind = (byte) 0;
                  this.PointNotifyObserver(mapId1);
                  break;
                }
                break;
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_RESOURCE:
              short num49 = MP.ReadShort();
              ushort index33 = MP.ReadUShort();
              int num50 = (int) this.CheckZoneID(index33);
              this.ZoneUpdateInfo[(int) index33].updateNum = num34;
              byte pointID3 = MP.ReadByte();
              short num51 = (short) ((int) num49 - 3);
              uint mapId2 = (uint) GameConstants.PointCodeToMapID(index33, pointID3);
              if (this.IsResources(mapId2) && this.ZoneUpdateInfo[(int) index33].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index33].zoneState].zoneID == (int) index33)
              {
                ushort tableId = this.LayoutMapInfo[(IntPtr) mapId2].tableID;
                MP.ReadStringPlus(13, this.ResourcesPointTable[(int) tableId].playerName);
                MP.ReadStringPlus(3, this.ResourcesPointTable[(int) tableId].allianceTag);
                this.ResourcesPointTable[(int) tableId].kingdomID = MP.ReadUShort();
                this.ResourcesPointTable[(int) tableId].count = MP.ReadUInt();
                this.ResourcesPointTable[(int) tableId].rate = MP.ReadFloat();
                this.ResourcesPointTable[(int) tableId].time = MP.ReadULong();
                for (int index34 = (int) num51 - 34; index34 > 0; --index34)
                {
                  int num52 = (int) MP.ReadByte();
                }
                this.PointNotifyObserver(mapId2);
                break;
              }
              for (int index35 = (int) num51; index35 > 0; --index35)
              {
                int num53 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_RESOURCE_OWNER_NAME:
              ushort index36 = MP.ReadUShort();
              int num54 = (int) this.CheckZoneID(index36);
              this.ZoneUpdateInfo[(int) index36].updateNum = num34;
              byte pointID4 = MP.ReadByte();
              uint mapId3 = (uint) GameConstants.PointCodeToMapID(index36, pointID4);
              if (this.IsResources(mapId3) && this.ZoneUpdateInfo[(int) index36].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index36].zoneState].zoneID == (int) index36)
              {
                MP.ReadStringPlus(13, this.ResourcesPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId3].tableID].playerName);
                this.PointNotifyObserver(mapId3);
                break;
              }
              for (int index37 = 0; index37 < 13; ++index37)
              {
                int num55 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_RESOURCE_OWNER_TAG:
              ushort index38 = MP.ReadUShort();
              int num56 = (int) this.CheckZoneID(index38);
              this.ZoneUpdateInfo[(int) index38].updateNum = num34;
              byte pointID5 = MP.ReadByte();
              uint mapId4 = (uint) GameConstants.PointCodeToMapID(index38, pointID5);
              if (this.IsResources(mapId4) && this.ZoneUpdateInfo[(int) index38].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index38].zoneState].zoneID == (int) index38)
              {
                MP.ReadStringPlus(3, this.ResourcesPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId4].tableID].allianceTag);
                this.ZoneNotifyObserver((ushort) 1024);
                break;
              }
              for (int index39 = 0; index39 < 3; ++index39)
              {
                int num57 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_NAME:
              ushort index40 = MP.ReadUShort();
              int num58 = (int) this.CheckZoneID(index40);
              this.ZoneUpdateInfo[(int) index40].updateNum = num34;
              byte pointID6 = MP.ReadByte();
              uint mapId5 = (uint) GameConstants.PointCodeToMapID(index40, pointID6);
              if (this.IsCityOrCamp(mapId5) && this.ZoneUpdateInfo[(int) index40].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index40].zoneState].zoneID == (int) index40)
              {
                MP.ReadStringPlus(13, this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId5].tableID].playerName);
                this.PointNotifyObserver(mapId5);
                break;
              }
              for (int index41 = 0; index41 < 13; ++index41)
              {
                int num59 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_TAG:
              ushort index42 = MP.ReadUShort();
              int num60 = (int) this.CheckZoneID(index42);
              this.ZoneUpdateInfo[(int) index42].updateNum = num34;
              byte pointID7 = MP.ReadByte();
              uint mapId6 = (uint) GameConstants.PointCodeToMapID(index42, pointID7);
              if (this.IsCityOrCamp(mapId6) && this.ZoneUpdateInfo[(int) index42].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index42].zoneState].zoneID == (int) index42)
              {
                MP.ReadStringPlus(3, this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId6].tableID].allianceTag);
                if ((long) mapId6 == (long) DataManager.Instance.RoleAttr.CapitalPoint)
                {
                  DataManager.Instance.RoleAlliance.Tag.ClearString();
                  DataManager.Instance.RoleAlliance.Tag.Append(this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId6].tableID].allianceTag);
                  if (DataManager.Instance.RoleAlliance.Tag.Length == 0)
                  {
                    DataManager.Instance.RoleAlliance.Id = 0U;
                    DataManager.Instance.RoleAlliance.KingdomID = (ushort) 0;
                  }
                }
                this.ZoneNotifyObserver((ushort) 1024);
                break;
              }
              for (int index43 = 0; index43 < 3; ++index43)
              {
                int num61 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_LEVEL:
              ushort index44 = MP.ReadUShort();
              int num62 = (int) this.CheckZoneID(index44);
              this.ZoneUpdateInfo[(int) index44].updateNum = num34;
              byte pointID8 = MP.ReadByte();
              uint mapId7 = (uint) GameConstants.PointCodeToMapID(index44, pointID8);
              if (this.IsCityOrCamp(mapId7) && this.ZoneUpdateInfo[(int) index44].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index44].zoneState].zoneID == (int) index44)
              {
                this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId7].tableID].level = MP.ReadByte();
                this.PointNotifyObserver(mapId7);
                break;
              }
              int num63 = (int) MP.ReadByte();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_CAPITALFLAG:
              ushort index45 = MP.ReadUShort();
              int num64 = (int) this.CheckZoneID(index45);
              this.ZoneUpdateInfo[(int) index45].updateNum = num34;
              byte pointID9 = MP.ReadByte();
              uint mapId8 = (uint) GameConstants.PointCodeToMapID(index45, pointID9);
              if (this.IsCityOrCamp(mapId8) && this.ZoneUpdateInfo[(int) index45].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index45].zoneState].zoneID == (int) index45)
              {
                this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId8].tableID].capitalFlag = MP.ReadByte();
                this.PointNotifyObserver(mapId8);
                break;
              }
              int num65 = (int) MP.ReadByte();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_KTITLE:
              ushort index46 = MP.ReadUShort();
              int num66 = (int) this.CheckZoneID(index46);
              this.ZoneUpdateInfo[(int) index46].updateNum = num34;
              byte pointID10 = MP.ReadByte();
              uint mapId9 = (uint) GameConstants.PointCodeToMapID(index46, pointID10);
              if (this.IsCityOrCamp(mapId9) && this.ZoneUpdateInfo[(int) index46].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index46].zoneState].zoneID == (int) index46)
              {
                this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId9].tableID].kingdomTitle = (KINGDOM_DESIGNATION) MP.ReadByte();
                this.PointNotifyObserver(mapId9);
                break;
              }
              int num67 = (int) MP.ReadByte();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_WTITLE:
              ushort index47 = MP.ReadUShort();
              int num68 = (int) this.CheckZoneID(index47);
              this.ZoneUpdateInfo[(int) index47].updateNum = num34;
              byte pointID11 = MP.ReadByte();
              uint mapId10 = (uint) GameConstants.PointCodeToMapID(index47, pointID11);
              if (this.IsCityOrCamp(mapId10) && this.ZoneUpdateInfo[(int) index47].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index47].zoneState].zoneID == (int) index47)
              {
                this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId10].tableID].worldTitle = (WORLD_PLAYER_DESIGNATION) MP.ReadByte();
                this.PointNotifyObserver(mapId10);
                break;
              }
              int num69 = (int) MP.ReadByte();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_ADVANCE:
              short num70 = MP.ReadShort();
              ushort zoneID = MP.ReadUShort();
              this.ZoneUpdateInfo[(int) zoneID].updateNum = num34;
              byte pointID12 = MP.ReadByte();
              short num71 = (short) ((int) num70 - 3);
              uint mapId11 = (uint) GameConstants.PointCodeToMapID(zoneID, pointID12);
              if (this.IsCityOrCamp(mapId11) && this.ZoneUpdateInfo[(int) zoneID].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) zoneID].zoneState].zoneID == (int) zoneID)
              {
                int tableId = (int) this.LayoutMapInfo[(IntPtr) mapId11].tableID;
                MP.ReadStringPlus(20, this.PlayerPointTable[tableId].allianceName);
                this.PlayerPointTable[tableId].VIP = MP.ReadByte();
                this.PlayerPointTable[tableId].allianceRank = MP.ReadByte();
                this.PlayerPointTable[tableId].portraitID = MP.ReadUShort();
                this.PlayerPointTable[tableId].bounty = MP.ReadUInt();
                this.PlayerPointTable[tableId].power = MP.ReadULong();
                this.PlayerPointTable[tableId].kill = MP.ReadULong();
                for (int index48 = (int) num71 - 44; index48 > 0; --index48)
                {
                  int num72 = (int) MP.ReadByte();
                }
                DataManager.msgBuffer[0] = (byte) 79;
                GameConstants.GetBytes(mapId11, DataManager.msgBuffer, 1);
                GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                break;
              }
              if (this.LayoutMapInfo[(IntPtr) mapId11].pointKind == (byte) 11 && this.ZoneUpdateInfo[(int) zoneID].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) zoneID].zoneState].zoneID == (int) zoneID)
              {
                int tableId = (int) this.LayoutMapInfo[(IntPtr) mapId11].tableID;
                MP.ReadStringPlus(20, this.YolkPointTable[tableId].OwnerAllianceName);
                this.YolkPointTable[tableId].LeaderHead = MP.ReadUShort();
                this.YolkPointTable[tableId].LeaderPos.zoneID = MP.ReadUShort();
                this.YolkPointTable[tableId].LeaderPos.pointID = MP.ReadByte();
                MP.ReadStringPlus(13, this.YolkPointTable[tableId].OwnerName);
                for (int index49 = (int) num71 - 38; index49 > 0; --index49)
                {
                  int num73 = (int) MP.ReadByte();
                }
                DataManager.msgBuffer[0] = (byte) 79;
                GameConstants.GetBytes(mapId11, DataManager.msgBuffer, 1);
                GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                break;
              }
              for (int index50 = (int) num71; index50 > 0; --index50)
              {
                int num74 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_NPC_BLOOD:
              ushort index51 = MP.ReadUShort();
              int num75 = (int) this.CheckZoneID(index51);
              this.ZoneUpdateInfo[(int) index51].updateNum = num34;
              byte pointID13 = MP.ReadByte();
              uint mapId12 = (uint) GameConstants.PointCodeToMapID(index51, pointID13);
              if (this.LayoutMapInfo[(IntPtr) mapId12].pointKind == (byte) 10 && this.ZoneUpdateInfo[(int) index51].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index51].zoneState].zoneID == (int) index51)
              {
                float num76 = MP.ReadFloat();
                if (!(GameManager.ActiveGameplay is CHAOS))
                {
                  this.NPCPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId12].tableID].Blood = num76;
                  break;
                }
                DataManager.msgBuffer[0] = (byte) 87;
                GameConstants.GetBytes(mapId12, DataManager.msgBuffer, 1);
                GameConstants.GetBytes(num76, DataManager.msgBuffer, 5);
                GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                break;
              }
              double num77 = (double) MP.ReadFloat();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_LINE_ADD:
              short num78 = MP.ReadShort();
              ushort index52 = MP.ReadUShort();
              short num79 = (short) ((int) num78 - 2);
              int num80 = (int) this.CheckZoneID(index52);
              this.ZoneUpdateInfo[(int) index52].updateNum = num34;
              uint lineID1 = MP.ReadUInt();
              int lineTableId1 = this.getLineTableID(index52, lineID1);
              if (lineTableId1 == 1048576)
              {
                int num81 = this.MapLineTableIDpool.spawn();
                while (num81 >= this.MapLineTable.Count)
                  this.MapLineTable.Add(new MapLine());
                this.MapLineTable[num81].lineID = lineID1;
                MP.ReadStringPlus(13, this.MapLineTable[num81].playerName);
                MP.ReadStringPlus(3, this.MapLineTable[num81].allianceTag);
                this.MapLineTable[num81].kingdomID = MP.ReadUShort();
                this.MapLineTable[num81].start.zoneID = MP.ReadUShort();
                this.MapLineTable[num81].start.pointID = MP.ReadByte();
                this.MapLineTable[num81].end.zoneID = MP.ReadUShort();
                this.MapLineTable[num81].end.pointID = MP.ReadByte();
                this.MapLineTable[num81].begin = MP.ReadULong();
                this.MapLineTable[num81].during = MP.ReadUInt();
                this.MapLineTable[num81].EXbegin = MP.ReadUInt();
                this.MapLineTable[num81].EXduring = MP.ReadUInt();
                this.MapLineTable[num81].lineFlag = MP.ReadByte();
                this.MapLineTable[num81].baseFlag = MP.ReadByte();
                this.MapLineTable[num81].emojiID = MP.ReadUShort();
                this.addLine(num81);
              }
              else
              {
                this.MapLineTable[lineTableId1].lineID = lineID1;
                MP.ReadStringPlus(13, this.MapLineTable[lineTableId1].playerName);
                MP.ReadStringPlus(3, this.MapLineTable[lineTableId1].allianceTag);
                this.MapLineTable[lineTableId1].kingdomID = MP.ReadUShort();
                this.MapLineTable[lineTableId1].start.zoneID = MP.ReadUShort();
                this.MapLineTable[lineTableId1].start.pointID = MP.ReadByte();
                this.MapLineTable[lineTableId1].end.zoneID = MP.ReadUShort();
                this.MapLineTable[lineTableId1].end.pointID = MP.ReadByte();
                this.MapLineTable[lineTableId1].begin = MP.ReadULong();
                this.MapLineTable[lineTableId1].during = MP.ReadUInt();
                this.MapLineTable[lineTableId1].EXbegin = MP.ReadUInt();
                this.MapLineTable[lineTableId1].EXduring = MP.ReadUInt();
                this.MapLineTable[lineTableId1].lineFlag = MP.ReadByte();
                byte num82 = MP.ReadByte();
                ushort num83 = MP.ReadUShort();
                if ((UnityEngine.Object) this.MapLineTable[lineTableId1].lineObject == (UnityEngine.Object) null)
                {
                  this.LineNotifyObserver((byte) 56, lineTableId1, (byte) 1);
                }
                else
                {
                  if (((int) this.MapLineTable[lineTableId1].baseFlag & 1) != ((int) num82 & 1) || (int) num83 != (int) this.MapLineTable[lineTableId1].emojiID)
                  {
                    this.MapLineTable[lineTableId1].baseFlag = num82;
                    this.MapLineTable[lineTableId1].emojiID = num83;
                    this.LineNotifyObserver((byte) 61, lineTableId1, (byte) 1);
                  }
                  if (((int) this.MapLineTable[lineTableId1].baseFlag & 2) != ((int) num82 & 2))
                  {
                    this.MapLineTable[lineTableId1].baseFlag = num82;
                    this.LineNotifyObserver((byte) 62, lineTableId1, (byte) 1);
                  }
                }
              }
              for (int index53 = (int) num79 - 52; index53 > 0; --index53)
              {
                int num84 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_LINE_DEL:
              ushort index54 = MP.ReadUShort();
              int num85 = (int) this.CheckZoneID(index54);
              this.ZoneUpdateInfo[(int) index54].updateNum = num34;
              uint lineID2 = MP.ReadUInt();
              int lineTableId2 = this.getLineTableID(index54, lineID2);
              if (lineTableId2 < 1048576 && (int) lineID2 == (int) this.MapLineTable[lineTableId2].lineID)
              {
                this.delLine(lineTableId2, (byte) 1);
                break;
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_LINE_OWNER_NAME:
              ushort index55 = MP.ReadUShort();
              int num86 = (int) this.CheckZoneID(index55);
              this.ZoneUpdateInfo[(int) index55].updateNum = num34;
              uint lineID3 = MP.ReadUInt();
              int lineTableId3 = this.getLineTableID(index55, lineID3);
              if (lineTableId3 < 1048576 && (int) lineID3 == (int) this.MapLineTable[lineTableId3].lineID && (UnityEngine.Object) this.MapLineTable[lineTableId3].lineObject != (UnityEngine.Object) null)
              {
                MP.ReadStringPlus(13, this.MapLineTable[lineTableId3].playerName);
                this.LineNotifyObserver((byte) 57, lineTableId3, (byte) 1);
                break;
              }
              for (int index56 = 0; index56 < 13; ++index56)
              {
                int num87 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_LINE_OWNER_TAG:
              ushort index57 = MP.ReadUShort();
              int num88 = (int) this.CheckZoneID(index57);
              this.ZoneUpdateInfo[(int) index57].updateNum = num34;
              uint lineID4 = MP.ReadUInt();
              int lineTableId4 = this.getLineTableID(index57, lineID4);
              if (lineTableId4 < 1048576 && (int) lineID4 == (int) this.MapLineTable[lineTableId4].lineID && (UnityEngine.Object) this.MapLineTable[lineTableId4].lineObject != (UnityEngine.Object) null)
              {
                MP.ReadStringPlus(3, this.MapLineTable[lineTableId4].allianceTag);
                this.LineNotifyObserver((byte) 58, lineTableId4, (byte) 1);
                break;
              }
              for (int index58 = 0; index58 < 3; ++index58)
              {
                int num89 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_LINE_BEGIN:
              ushort index59 = MP.ReadUShort();
              int num90 = (int) this.CheckZoneID(index59);
              this.ZoneUpdateInfo[(int) index59].updateNum = num34;
              uint lineID5 = MP.ReadUInt();
              int lineTableId5 = this.getLineTableID(index59, lineID5);
              if (lineTableId5 < 1048576 && (int) lineID5 == (int) this.MapLineTable[lineTableId5].lineID && (UnityEngine.Object) this.MapLineTable[lineTableId5].lineObject != (UnityEngine.Object) null)
              {
                this.MapLineTable[lineTableId5].begin = MP.ReadULong();
                this.MapLineTable[lineTableId5].EXbegin = MP.ReadUInt();
                this.MapLineTable[lineTableId5].EXduring = MP.ReadUInt();
                this.LineNotifyObserver((byte) 60, lineTableId5, (byte) 1);
                break;
              }
              long num91 = (long) MP.ReadULong();
              long num92 = (long) MP.ReadULong();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG:
              ushort InKey1 = MP.ReadUShort();
              KingdomMap recordByKey1 = this.KingdomMapTable.GetRecordByKey(InKey1);
              int num93 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
              int index60 = (int) recordByKey1.worldPosX - (int) this.WorldMinX + ((int) recordByKey1.worldPosY - (int) this.WorldMinY) * num93;
              byte tableId1 = this.TileMapKingdomID[index60].tableID;
              if ((int) this.TileMapKingdomID[index60].KingdomID == (int) InKey1 && (int) this.WorldKingdomTable[(int) tableId1].kingdomID == (int) InKey1)
              {
                byte num94 = (byte) ((uint) this.WorldKingdomTable[(int) tableId1].kingdomFlag >> 3);
                this.WorldKingdomTable[(int) tableId1].kingdomFlag = MP.ReadByte();
                if (num94 > (byte) 0 && (int) this.WorldKingdomTable[(int) tableId1].kingdomFlag >> 3 == 0 && DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 1)
                  DataManager.Instance.RoleAttr.WorldTitle_Personal = (ushort) 0;
                this.KingdomNotifyObserver(tableId1, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG);
                break;
              }
              int num95 = (int) MP.ReadByte();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD:
              ushort InKey2 = MP.ReadUShort();
              KingdomMap recordByKey2 = this.KingdomMapTable.GetRecordByKey(InKey2);
              int num96 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
              int index61 = (int) recordByKey2.worldPosX - (int) this.WorldMinX + ((int) recordByKey2.worldPosY - (int) this.WorldMinY) * num96;
              byte tableId2 = this.TileMapKingdomID[index61].tableID;
              if ((int) this.TileMapKingdomID[index61].KingdomID == (int) InKey2 && (int) this.WorldKingdomTable[(int) tableId2].kingdomID == (int) InKey2)
              {
                this.WorldKingdomTable[(int) tableId2].kingdomPeriod = (KINGDOM_PERIOD) MP.ReadByte();
                this.KingdomNotifyObserver(tableId2, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD);
                break;
              }
              int num97 = (int) MP.ReadByte();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE:
              ushort InKey3 = MP.ReadUShort();
              KingdomMap recordByKey3 = this.KingdomMapTable.GetRecordByKey(InKey3);
              int num98 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
              int index62 = (int) recordByKey3.worldPosX - (int) this.WorldMinX + ((int) recordByKey3.worldPosY - (int) this.WorldMinY) * num98;
              byte tableId3 = this.TileMapKingdomID[index62].tableID;
              if ((int) this.TileMapKingdomID[index62].KingdomID == (int) InKey3 && (int) this.WorldKingdomTable[(int) tableId3].kingdomID == (int) InKey3)
              {
                this.WorldKingdomTable[(int) tableId3].kingName.ClearString();
                MP.ReadStringPlus(13, this.WorldKingdomTable[(int) tableId3].kingName);
                this.WorldKingdomTable[(int) tableId3].allianceTag.ClearString();
                MP.ReadStringPlus(3, this.WorldKingdomTable[(int) tableId3].allianceTag);
                this.WorldKingdomTable[(int) tableId3].allianceName.ClearString();
                MP.ReadStringPlus(20, this.WorldKingdomTable[(int) tableId3].allianceName);
                this.KingdomNotifyObserver(tableId3, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE);
                break;
              }
              int num99 = 36;
              for (byte index63 = 0; (int) index63 < num99; ++index63)
              {
                int num100 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_STATE:
              ushort index64 = MP.ReadUShort();
              int num101 = (int) this.CheckZoneID(index64);
              this.ZoneUpdateInfo[(int) index64].updateNum = num34;
              byte pointID14 = MP.ReadByte();
              uint mapId13 = (uint) GameConstants.PointCodeToMapID(index64, pointID14);
              if (this.ZoneUpdateInfo[(int) index64].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index64].zoneState].zoneID == (int) index64)
              {
                ushort tableId4 = this.LayoutMapInfo[(IntPtr) mapId13].tableID;
                if ((int) tableId4 < this.YolkPointTable.Length)
                {
                  byte wonderState = this.YolkPointTable[(int) tableId4].WonderState;
                  this.YolkPointTable[(int) tableId4].WonderState = MP.ReadByte();
                  this.YolkPointTable[(int) tableId4].StateBegin = MP.ReadULong();
                  this.YolkPointTable[(int) tableId4].StateDuring = MP.ReadUInt();
                  if (this.YolkPointTable[(int) tableId4].WonderState == (byte) 2 || wonderState == (byte) 0 && this.YolkPointTable[(int) tableId4].WonderState == (byte) 1)
                  {
                    this.YolkPointTable[(int) tableId4].WonderAllianceTag.ClearString();
                    this.YolkPointTable[(int) tableId4].OwnerEmblem = ushort.MaxValue;
                    this.YolkPointTable[(int) tableId4].OwnerAllianceName.ClearString();
                    this.YolkPointTable[(int) tableId4].WonderLeader.ClearString();
                    this.YolkPointTable[(int) tableId4].LeaderKingdomID = this.YolkPointTable[(int) tableId4].AllianceKingdomID = this.YolkPointTable[(int) tableId4].LeaderHomeKingdomID = (ushort) 0;
                    this.YolkPointTable[(int) tableId4].LeaderPos.zoneID = (ushort) 0;
                    this.YolkPointTable[(int) tableId4].LeaderPos.pointID = (byte) 0;
                    this.YolkPointTable[(int) tableId4].LeaderHead = (ushort) 0;
                    this.YolkPointTable[(int) tableId4].OwnerName.ClearString();
                    DataManager.msgBuffer[0] = (byte) 94;
                    GameConstants.GetBytes(tableId4, DataManager.msgBuffer, 1);
                    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                  }
                  else if (this.YolkPointTable[(int) tableId4].WonderState == (byte) 0)
                  {
                    DataManager.msgBuffer[0] = (byte) 95;
                    GameConstants.GetBytes(tableId4, DataManager.msgBuffer, 1);
                    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                  }
                  this.PointNotifyObserver(mapId13);
                }
                else
                {
                  for (int index65 = 13; index65 > 0; --index65)
                  {
                    int num102 = (int) MP.ReadByte();
                  }
                }
              }
              else
              {
                for (int index66 = 13; index66 > 0; --index66)
                {
                  int num103 = (int) MP.ReadByte();
                }
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_EMBLEM:
              ushort index67 = MP.ReadUShort();
              int num104 = (int) this.CheckZoneID(index67);
              this.ZoneUpdateInfo[(int) index67].updateNum = num34;
              byte pointID15 = MP.ReadByte();
              uint mapId14 = (uint) GameConstants.PointCodeToMapID(index67, pointID15);
              if (this.ZoneUpdateInfo[(int) index67].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index67].zoneState].zoneID == (int) index67)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId14].tableID < this.YolkPointTable.Length)
                {
                  this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId14].tableID].OwnerEmblem = MP.ReadUShort();
                  this.PointNotifyObserver(mapId14);
                }
                else
                {
                  int num105 = (int) MP.ReadUShort();
                }
              }
              else
              {
                int num106 = (int) MP.ReadUShort();
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_NAME:
              ushort index68 = MP.ReadUShort();
              int num107 = (int) this.CheckZoneID(index68);
              this.ZoneUpdateInfo[(int) index68].updateNum = num34;
              byte pointID16 = MP.ReadByte();
              uint mapId15 = (uint) GameConstants.PointCodeToMapID(index68, pointID16);
              if (this.ZoneUpdateInfo[(int) index68].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index68].zoneState].zoneID == (int) index68)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId15].tableID < this.YolkPointTable.Length)
                {
                  MP.ReadStringPlus(13, this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId15].tableID].WonderLeader);
                  this.PointNotifyObserver(mapId15);
                }
                else
                {
                  for (int index69 = 0; index69 < 13; ++index69)
                  {
                    int num108 = (int) MP.ReadByte();
                  }
                }
              }
              else
              {
                for (int index70 = 0; index70 < 13; ++index70)
                {
                  int num109 = (int) MP.ReadByte();
                }
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE_TAG:
              ushort index71 = MP.ReadUShort();
              int num110 = (int) this.CheckZoneID(index71);
              this.ZoneUpdateInfo[(int) index71].updateNum = num34;
              byte pointID17 = MP.ReadByte();
              uint mapId16 = (uint) GameConstants.PointCodeToMapID(index71, pointID17);
              if (this.ZoneUpdateInfo[(int) index71].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index71].zoneState].zoneID == (int) index71)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId16].tableID < this.YolkPointTable.Length)
                {
                  MP.ReadStringPlus(3, this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].WonderAllianceTag);
                  if (this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].WonderAllianceTag[0] == char.MinValue)
                  {
                    this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].WonderAllianceTag.ClearString();
                    this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].OwnerEmblem = ushort.MaxValue;
                    this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].OwnerAllianceName.ClearString();
                    if (this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].LeaderKingdomID == (ushort) 0)
                    {
                      this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].WonderLeader.ClearString();
                      this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].LeaderKingdomID = (ushort) 0;
                      this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].LeaderPos.zoneID = (ushort) 0;
                      this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].LeaderPos.pointID = (byte) 0;
                      this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].LeaderHead = (ushort) 0;
                      this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId16].tableID].OwnerName.ClearString();
                    }
                  }
                  this.PointNotifyObserver(mapId16);
                }
                else
                {
                  for (int index72 = 0; index72 < 3; ++index72)
                  {
                    int num111 = (int) MP.ReadByte();
                  }
                }
              }
              else
              {
                for (int index73 = 0; index73 < 3; ++index73)
                {
                  int num112 = (int) MP.ReadByte();
                }
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_POS:
              ushort index74 = MP.ReadUShort();
              int num113 = (int) this.CheckZoneID(index74);
              this.ZoneUpdateInfo[(int) index74].updateNum = num34;
              byte pointID18 = MP.ReadByte();
              uint mapId17 = (uint) GameConstants.PointCodeToMapID(index74, pointID18);
              if (this.ZoneUpdateInfo[(int) index74].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index74].zoneState].zoneID == (int) index74)
              {
                ushort tableId5 = this.LayoutMapInfo[(IntPtr) mapId17].tableID;
                if ((int) tableId5 < this.YolkPointTable.Length)
                {
                  this.YolkPointTable[(int) tableId5].LeaderKingdomID = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId5].LeaderPos.zoneID = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId5].LeaderPos.pointID = MP.ReadByte();
                  this.YolkPointTable[(int) tableId5].LeaderHomeKingdomID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId17);
                }
                else
                {
                  MP.ReadInt();
                  int num114 = (int) MP.ReadByte();
                  int num115 = (int) MP.ReadUShort();
                }
              }
              else
              {
                MP.ReadInt();
                int num116 = (int) MP.ReadByte();
                int num117 = (int) MP.ReadUShort();
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE_NAME:
              ushort index75 = MP.ReadUShort();
              int num118 = (int) this.CheckZoneID(index75);
              this.ZoneUpdateInfo[(int) index75].updateNum = num34;
              byte pointID19 = MP.ReadByte();
              uint mapId18 = (uint) GameConstants.PointCodeToMapID(index75, pointID19);
              if (this.ZoneUpdateInfo[(int) index75].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index75].zoneState].zoneID == (int) index75)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId18].tableID < this.YolkPointTable.Length)
                {
                  MP.ReadStringPlus(20, this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId18].tableID].OwnerAllianceName);
                  this.PointNotifyObserver(mapId18);
                }
                else
                {
                  for (int index76 = 0; index76 < 20; ++index76)
                  {
                    int num119 = (int) MP.ReadByte();
                  }
                }
              }
              else
              {
                for (int index77 = 0; index77 < 20; ++index77)
                {
                  int num120 = (int) MP.ReadByte();
                }
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_HEAD:
              ushort index78 = MP.ReadUShort();
              int num121 = (int) this.CheckZoneID(index78);
              this.ZoneUpdateInfo[(int) index78].updateNum = num34;
              byte pointID20 = MP.ReadByte();
              uint mapId19 = (uint) GameConstants.PointCodeToMapID(index78, pointID20);
              if (this.ZoneUpdateInfo[(int) index78].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index78].zoneState].zoneID == (int) index78)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId19].tableID < this.YolkPointTable.Length)
                {
                  this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId19].tableID].LeaderHead = MP.ReadUShort();
                  this.PointNotifyObserver(mapId19);
                }
                else
                {
                  int num122 = (int) MP.ReadUShort();
                }
              }
              else
              {
                int num123 = (int) MP.ReadUShort();
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER:
              ushort index79 = MP.ReadUShort();
              int num124 = (int) this.CheckZoneID(index79);
              this.ZoneUpdateInfo[(int) index79].updateNum = num34;
              byte pointID21 = MP.ReadByte();
              uint mapId20 = (uint) GameConstants.PointCodeToMapID(index79, pointID21);
              if (this.ZoneUpdateInfo[(int) index79].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index79].zoneState].zoneID == (int) index79)
              {
                ushort tableId6 = this.LayoutMapInfo[(IntPtr) mapId20].tableID;
                if ((int) tableId6 < this.YolkPointTable.Length)
                {
                  MP.ReadStringPlus(13, this.YolkPointTable[(int) tableId6].WonderLeader);
                  this.YolkPointTable[(int) tableId6].LeaderHead = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId6].LeaderKingdomID = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId6].LeaderPos.zoneID = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId6].LeaderPos.pointID = MP.ReadByte();
                  this.YolkPointTable[(int) tableId6].LeaderHomeKingdomID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId20);
                }
                else
                {
                  for (int index80 = 0; index80 < 13; ++index80)
                  {
                    int num125 = (int) MP.ReadByte();
                  }
                  int num126 = (int) MP.ReadUShort();
                  int num127 = (int) MP.ReadUShort();
                  int num128 = (int) MP.ReadUShort();
                  int num129 = (int) MP.ReadByte();
                  int num130 = (int) MP.ReadUShort();
                }
              }
              else
              {
                for (int index81 = 0; index81 < 13; ++index81)
                {
                  int num131 = (int) MP.ReadByte();
                }
                int num132 = (int) MP.ReadUShort();
                int num133 = (int) MP.ReadUShort();
                int num134 = (int) MP.ReadUShort();
                int num135 = (int) MP.ReadByte();
                int num136 = (int) MP.ReadUShort();
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_OWNER:
              ushort index82 = MP.ReadUShort();
              int num137 = (int) this.CheckZoneID(index82);
              this.ZoneUpdateInfo[(int) index82].updateNum = num34;
              byte pointID22 = MP.ReadByte();
              uint mapId21 = (uint) GameConstants.PointCodeToMapID(index82, pointID22);
              if (this.ZoneUpdateInfo[(int) index82].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index82].zoneState].zoneID == (int) index82)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId21].tableID < this.YolkPointTable.Length)
                {
                  MP.ReadStringPlus(13, this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId21].tableID].OwnerName);
                  MP.ReadStringPlus(3, this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId21].tableID].WonderAllianceTag);
                  MP.ReadStringPlus(20, this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId21].tableID].OwnerAllianceName);
                  this.PointNotifyObserver(mapId21);
                }
                else
                {
                  for (int index83 = 0; index83 < 13; ++index83)
                  {
                    int num138 = (int) MP.ReadByte();
                  }
                  for (int index84 = 0; index84 < 3; ++index84)
                  {
                    int num139 = (int) MP.ReadByte();
                  }
                  for (int index85 = 0; index85 < 20; ++index85)
                  {
                    int num140 = (int) MP.ReadByte();
                  }
                }
              }
              else
              {
                for (int index86 = 0; index86 < 13; ++index86)
                {
                  int num141 = (int) MP.ReadByte();
                }
                for (int index87 = 0; index87 < 3; ++index87)
                {
                  int num142 = (int) MP.ReadByte();
                }
                for (int index88 = 0; index88 < 20; ++index88)
                {
                  int num143 = (int) MP.ReadByte();
                }
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE:
              ushort index89 = MP.ReadUShort();
              int num144 = (int) this.CheckZoneID(index89);
              this.ZoneUpdateInfo[(int) index89].updateNum = num34;
              byte pointID23 = MP.ReadByte();
              uint mapId22 = (uint) GameConstants.PointCodeToMapID(index89, pointID23);
              if (this.ZoneUpdateInfo[(int) index89].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index89].zoneState].zoneID == (int) index89)
              {
                ushort tableId7 = this.LayoutMapInfo[(IntPtr) mapId22].tableID;
                if ((int) tableId7 < this.YolkPointTable.Length)
                {
                  this.YolkPointTable[(int) tableId7].StateBegin = MP.ReadULong();
                  this.YolkPointTable[(int) tableId7].StateDuring = MP.ReadUInt();
                  this.YolkPointTable[(int) tableId7].OwnerEmblem = MP.ReadUShort();
                  MP.ReadStringPlus(13, this.YolkPointTable[(int) tableId7].WonderLeader);
                  this.YolkPointTable[(int) tableId7].LeaderHead = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId7].LeaderKingdomID = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId7].LeaderPos.zoneID = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId7].LeaderPos.pointID = MP.ReadByte();
                  this.YolkPointTable[(int) tableId7].LeaderHomeKingdomID = MP.ReadUShort();
                  this.YolkPointTable[(int) tableId7].AllianceKingdomID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId22);
                  DataManager.msgBuffer[0] = this.YolkPointTable[(int) tableId7].StateBegin <= 0UL ? (byte) 95 : (byte) 94;
                  GameConstants.GetBytes(tableId7, DataManager.msgBuffer, 1);
                  GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                }
                else
                {
                  for (int index90 = 0; index90 < 13; ++index90)
                  {
                    int num145 = (int) MP.ReadByte();
                  }
                  long num146 = (long) MP.ReadULong();
                  long num147 = (long) MP.ReadULong();
                  int num148 = (int) MP.ReadUInt();
                  int num149 = (int) MP.ReadByte();
                  int num150 = (int) MP.ReadUShort();
                  int num151 = (int) MP.ReadUShort();
                }
              }
              else
              {
                for (int index91 = 0; index91 < 13; ++index91)
                {
                  int num152 = (int) MP.ReadByte();
                }
                long num153 = (long) MP.ReadULong();
                long num154 = (long) MP.ReadULong();
                int num155 = (int) MP.ReadUInt();
                int num156 = (int) MP.ReadByte();
                int num157 = (int) MP.ReadUShort();
                int num158 = (int) MP.ReadUShort();
              }
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int) mapUpdateKind);
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_FLAG:
              ushort index92 = MP.ReadUShort();
              int num159 = (int) this.CheckZoneID(index92);
              this.ZoneUpdateInfo[(int) index92].updateNum = num34;
              byte pointID24 = MP.ReadByte();
              uint mapId23 = (uint) GameConstants.PointCodeToMapID(index92, pointID24);
              if (this.ZoneUpdateInfo[(int) index92].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index92].zoneState].zoneID == (int) index92)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId23].tableID < this.YolkPointTable.Length)
                {
                  this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId23].tableID].WonderFlag = MP.ReadByte();
                  this.PointNotifyObserver(mapId23);
                  break;
                }
                int num160 = (int) MP.ReadByte();
                break;
              }
              int num161 = (int) MP.ReadByte();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE_KINGDOM:
              ushort index93 = MP.ReadUShort();
              int num162 = (int) this.CheckZoneID(index93);
              this.ZoneUpdateInfo[(int) index93].updateNum = num34;
              byte pointID25 = MP.ReadByte();
              uint mapId24 = (uint) GameConstants.PointCodeToMapID(index93, pointID25);
              if (this.ZoneUpdateInfo[(int) index93].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index93].zoneState].zoneID == (int) index93)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId24].tableID < this.YolkPointTable.Length)
                {
                  this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId24].tableID].AllianceKingdomID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId24);
                  break;
                }
                int num163 = (int) MP.ReadUShort();
                break;
              }
              int num164 = (int) MP.ReadUShort();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME:
              ushort InKey4 = MP.ReadUShort();
              KingdomMap recordByKey4 = this.KingdomMapTable.GetRecordByKey(InKey4);
              int num165 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
              int index94 = (int) recordByKey4.worldPosX - (int) this.WorldMinX + ((int) recordByKey4.worldPosY - (int) this.WorldMinY) * num165;
              byte tableId8 = this.TileMapKingdomID[index94].tableID;
              if ((int) this.TileMapKingdomID[index94].KingdomID == (int) InKey4 && (int) this.WorldKingdomTable[(int) tableId8].kingdomID == (int) InKey4)
              {
                this.WorldKingdomTable[(int) tableId8].kingdomTime = MP.ReadULong();
                this.KingdomNotifyObserver(tableId8, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME);
                break;
              }
              long num166 = (long) MP.ReadULong();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID:
              ushort InKey5 = MP.ReadUShort();
              KingdomMap recordByKey5 = this.KingdomMapTable.GetRecordByKey(InKey5);
              int num167 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
              int index95 = (int) recordByKey5.worldPosX - (int) this.WorldMinX + ((int) recordByKey5.worldPosY - (int) this.WorldMinY) * num167;
              byte tableId9 = this.TileMapKingdomID[index95].tableID;
              if ((int) this.TileMapKingdomID[index95].KingdomID == (int) InKey5 && (int) this.WorldKingdomTable[(int) tableId9].kingdomID == (int) InKey5)
              {
                this.WorldKingdomTable[(int) tableId9].allianceKingdomID = MP.ReadUShort();
                this.WorldKingdomTable[(int) tableId9].kingKingdomID = MP.ReadUShort();
                this.KingdomNotifyObserver(tableId9, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID);
                break;
              }
              int num168 = (int) MP.ReadUInt();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_ALLIANCE_KINGDOM:
              ushort index96 = MP.ReadUShort();
              int num169 = (int) this.CheckZoneID(index96);
              this.ZoneUpdateInfo[(int) index96].updateNum = num34;
              byte pointID26 = MP.ReadByte();
              uint mapId25 = (uint) GameConstants.PointCodeToMapID(index96, pointID26);
              if (this.IsCityOrCamp(mapId25) && this.ZoneUpdateInfo[(int) index96].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index96].zoneState].zoneID == (int) index96)
              {
                this.PlayerPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId25].tableID].allianceKingdomID = MP.ReadUShort();
                this.PointNotifyObserver(mapId25);
                break;
              }
              int num170 = (int) MP.ReadUShort();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_HOME_KINGDOM:
              ushort index97 = MP.ReadUShort();
              int num171 = (int) this.CheckZoneID(index97);
              this.ZoneUpdateInfo[(int) index97].updateNum = num34;
              byte pointID27 = MP.ReadByte();
              uint mapId26 = (uint) GameConstants.PointCodeToMapID(index97, pointID27);
              if (this.ZoneUpdateInfo[(int) index97].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index97].zoneState].zoneID == (int) index97)
              {
                if ((int) this.LayoutMapInfo[(IntPtr) mapId26].tableID < this.YolkPointTable.Length)
                {
                  this.YolkPointTable[(int) this.LayoutMapInfo[(IntPtr) mapId26].tableID].LeaderHomeKingdomID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId26);
                  break;
                }
                int num172 = (int) MP.ReadUShort();
                break;
              }
              int num173 = (int) MP.ReadUShort();
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_LINE_EMOJI:
              short num174 = MP.ReadShort();
              ushort index98 = MP.ReadUShort();
              int num175 = (int) this.CheckZoneID(index98);
              this.ZoneUpdateInfo[(int) index98].updateNum = num34;
              uint lineID6 = MP.ReadUInt();
              short num176 = (short) ((int) num174 - 6);
              int lineTableId6 = this.getLineTableID(index98, lineID6);
              if (lineTableId6 < 1048576 && (int) lineID6 == (int) this.MapLineTable[lineTableId6].lineID && (UnityEngine.Object) this.MapLineTable[lineTableId6].lineObject != (UnityEngine.Object) null)
              {
                this.MapLineTable[lineTableId6].baseFlag = MP.ReadByte();
                this.MapLineTable[lineTableId6].emojiID = MP.ReadUShort();
                this.LineNotifyObserver((byte) 61, lineTableId6, (byte) 1);
              }
              else
              {
                int num177 = (int) MP.ReadByte();
                int num178 = (int) MP.ReadUShort();
              }
              for (int index99 = (int) num176 - 3; index99 > 0; --index99)
              {
                int num179 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_EMOJI:
              short num180 = MP.ReadShort();
              ushort index100 = MP.ReadUShort();
              int num181 = (int) this.CheckZoneID(index100);
              this.ZoneUpdateInfo[(int) index100].updateNum = num34;
              byte pointID28 = MP.ReadByte();
              short num182 = (short) ((int) num180 - 3);
              if (this.ZoneUpdateInfo[(int) index100].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index100].zoneState].zoneID == (int) index100)
              {
                uint mapId27 = (uint) GameConstants.PointCodeToMapID(index100, pointID28);
                ushort tableId10 = this.LayoutMapInfo[(IntPtr) mapId27].tableID;
                if (this.IsCityOrCamp(mapId27))
                {
                  this.PlayerPointTable[(int) tableId10].baseFlag = MP.ReadByte();
                  this.PlayerPointTable[(int) tableId10].emojiID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId27);
                  break;
                }
                if (this.IsResources(mapId27))
                {
                  this.ResourcesPointTable[(int) tableId10].baseFlag = MP.ReadByte();
                  this.ResourcesPointTable[(int) tableId10].emojiID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId27);
                  break;
                }
                if (this.LayoutMapInfo[(IntPtr) mapId27].pointKind == (byte) 11)
                {
                  this.YolkPointTable[(int) tableId10].baseFlag = MP.ReadByte();
                  this.YolkPointTable[(int) tableId10].emojiID = MP.ReadUShort();
                  this.PointNotifyObserver(mapId27);
                  break;
                }
                for (int index101 = (int) num182; index101 > 0; --index101)
                {
                  int num183 = (int) MP.ReadByte();
                }
                break;
              }
              for (int index102 = (int) num182; index102 > 0; --index102)
              {
                int num184 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_NPC_TAG:
              short num185 = MP.ReadShort();
              ushort index103 = MP.ReadUShort();
              int num186 = (int) this.CheckZoneID(index103);
              this.ZoneUpdateInfo[(int) index103].updateNum = num34;
              byte pointID29 = MP.ReadByte();
              short num187 = (short) ((int) num185 - 3);
              if (this.ZoneUpdateInfo[(int) index103].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index103].zoneState].zoneID == (int) index103)
              {
                uint mapId28 = (uint) GameConstants.PointCodeToMapID(index103, pointID29);
                ushort tableId11 = this.LayoutMapInfo[(IntPtr) mapId28].tableID;
                if (this.LayoutMapInfo[(IntPtr) mapId28].pointKind == (byte) 10)
                {
                  MP.ReadStringPlus(3, this.NPCPointTable[(int) tableId11].NPCAllianceTag);
                  this.PointNotifyObserver(mapId28);
                  break;
                }
                for (int index104 = (int) num187; index104 > 0; --index104)
                {
                  int num188 = (int) MP.ReadByte();
                }
                break;
              }
              for (int index105 = (int) num187; index105 > 0; --index105)
              {
                int num189 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_OUTWARD:
              short num190 = MP.ReadShort();
              ushort index106 = MP.ReadUShort();
              int num191 = (int) this.CheckZoneID(index106);
              this.ZoneUpdateInfo[(int) index106].updateNum = num34;
              byte pointID30 = MP.ReadByte();
              short num192 = (short) ((int) num190 - 3);
              if (this.ZoneUpdateInfo[(int) index106].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index106].zoneState].zoneID == (int) index106)
              {
                uint mapId29 = (uint) GameConstants.PointCodeToMapID(index106, pointID30);
                ushort tableId12 = this.LayoutMapInfo[(IntPtr) mapId29].tableID;
                if (this.IsCityOrCamp(mapId29))
                {
                  this.PlayerPointTable[(int) tableId12].cityOutward = (CITY_OUTWARD) MP.ReadByte();
                  this.PlayerPointTable[(int) tableId12].cityOutwardLevel = MP.ReadByte();
                  this.PointNotifyObserver(mapId29);
                  break;
                }
                for (int index107 = (int) num192; index107 > 0; --index107)
                {
                  int num193 = (int) MP.ReadByte();
                }
                break;
              }
              for (int index108 = (int) num192; index108 > 0; --index108)
              {
                int num194 = (int) MP.ReadByte();
              }
              break;
            case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_OUTWARD_LEVEL:
              short num195 = MP.ReadShort();
              ushort index109 = MP.ReadUShort();
              int num196 = (int) this.CheckZoneID(index109);
              this.ZoneUpdateInfo[(int) index109].updateNum = num34;
              byte pointID31 = MP.ReadByte();
              short num197 = (short) ((int) num195 - 3);
              if (this.ZoneUpdateInfo[(int) index109].zoneState < (byte) 8 && (int) this.RAMSataeInfo[(int) this.ZoneUpdateInfo[(int) index109].zoneState].zoneID == (int) index109)
              {
                uint mapId30 = (uint) GameConstants.PointCodeToMapID(index109, pointID31);
                ushort tableId13 = this.LayoutMapInfo[(IntPtr) mapId30].tableID;
                if (this.IsCityOrCamp(mapId30))
                {
                  this.PlayerPointTable[(int) tableId13].cityOutwardLevel = MP.ReadByte();
                  this.PointNotifyObserver(mapId30);
                  break;
                }
                for (int index110 = (int) num197; index110 > 0; --index110)
                {
                  int num198 = (int) MP.ReadByte();
                }
                break;
              }
              for (int index111 = (int) num197; index111 > 0; --index111)
              {
                int num199 = (int) MP.ReadByte();
              }
              break;
            default:
              for (int index112 = (int) MP.ReadShort(); index112 > 0; --index112)
              {
                int num200 = (int) MP.ReadByte();
              }
              break;
          }
          break;
      }
      mapUpdateKind = (MAP_UPDATE_KIND) MP.ReadByte();
    }
label_472:
    DataManager.msgBuffer[0] = (byte) 70;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void RecvMapMonsterAttack(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    DataManager instance = DataManager.Instance;
    switch (num)
    {
      case 0:
        byte groupID = MP.ReadByte();
        if (groupID < (byte) 8)
        {
          instance.MarchEventData[(int) groupID].Type = EMarchEventType.EMET_HitMonsterMarching;
          instance.MarchEventData[(int) groupID].Point.zoneID = MP.ReadUShort();
          instance.MarchEventData[(int) groupID].Point.pointID = MP.ReadByte();
          instance.MarchEventTime[(int) groupID].BeginTime = MP.ReadLong();
          instance.MarchEventTime[(int) groupID].RequireTime = MP.ReadUInt();
          instance.RoleAttr.recvMonsterPoint = MP.ReadUInt();
          for (int index1 = 0; index1 < 5; ++index1)
          {
            ushort index2 = MP.ReadUShort();
            instance.MarchEventData[(int) groupID].HeroID[index1] = index2;
            instance.TempFightHeroID[(int) index2] = (byte) 1;
          }
          instance.MarchEventData[(int) groupID].PointKind = POINT_KIND.PK_NPC;
          for (int index = 0; index < instance.MarchEventData[(int) groupID].TroopData.Length; ++index)
            Array.Clear((Array) instance.MarchEventData[(int) groupID].TroopData[index], instance.MarchEventData[(int) groupID].TroopData[index].Length, 0);
          instance.RoleAttr.LastMonsterPointRecoverTime = instance.MarchEventTime[(int) groupID].BeginTime;
          instance.UpdateMonsterPoint();
          instance.SetFightHeroData();
          instance.SetQueueBarData((EQueueBarIndex) (2 + (int) groupID), true, instance.MarchEventTime[(int) groupID].BeginTime, instance.MarchEventTime[(int) groupID].RequireTime);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 4, 1);
          instance.CheckTroolCount();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).GoToGroup((int) groupID, (byte) 0);
          GameManager.OnRefresh(NetworkNews.Refresh_Hero);
          break;
        }
        break;
      case 1:
        GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8342U), (ushort) byte.MaxValue);
        goto default;
      case 2:
        GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8341U), (ushort) byte.MaxValue);
        goto default;
      case 4:
        GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(663U), (ushort) byte.MaxValue);
        goto default;
      case 5:
        GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8343U), (ushort) byte.MaxValue);
        goto default;
      case 6:
        GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8344U), (ushort) byte.MaxValue);
        goto default;
      default:
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 4, 1);
        break;
    }
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
    GUIManager.Instance.HideUILock(EUILock.Battle);
  }

  public void RecvMonsterReturn(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    byte index1 = MP.ReadByte();
    if (index1 >= (byte) 8)
      return;
    instance.MarchEventData[(int) index1].Type = (EMarchEventType) MP.ReadByte();
    instance.MarchEventTime[(int) index1].BeginTime = MP.ReadLong();
    instance.MarchEventTime[(int) index1].RequireTime = MP.ReadUInt();
    for (int index2 = 0; index2 < 5; ++index2)
      instance.MarchEventData[(int) index1].HeroID[index2] = MP.ReadUShort();
    instance.MarchEventData[(int) index1].PointKind = POINT_KIND.PK_NONE;
    for (int index3 = 0; index3 < instance.MarchEventData[(int) index1].TroopData.Length; ++index3)
      Array.Clear((Array) instance.MarchEventData[(int) index1].TroopData[index3], instance.MarchEventData[(int) index1].TroopData[index3].Length, 0);
    byte num1 = MP.ReadByte();
    for (byte index4 = 0; (int) index4 < (int) num1; ++index4)
    {
      ushort ItemID = MP.ReadUShort();
      ushort num2 = MP.ReadUShort();
      byte Rare = MP.ReadByte();
      ushort Quantity = (ushort) ((uint) num2 + (uint) instance.GetCurItemQuantity(ItemID, Rare));
      instance.SetCurItemQuantity(ItemID, Quantity, Rare, 0L);
      if (Rare > (byte) 0)
        instance.ReflashMaterialItem = (byte) 1;
    }
    instance.UpdateLoadItemNotify();
    instance.SetQueueBarData((EQueueBarIndex) (2 + (int) index1), true, instance.MarchEventTime[(int) index1].BeginTime, instance.MarchEventTime[(int) index1].RequireTime);
    instance.CheckTroolCount();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
  }

  public void RecvMonsterHome(MessagePacket MP)
  {
    byte index1 = MP.ReadByte();
    DataManager instance = DataManager.Instance;
    for (int index2 = 0; index2 < 5; ++index2)
    {
      ushort index3 = instance.MarchEventData[(int) index1].HeroID[index2];
      instance.TempFightHeroID[(int) index3] = (byte) 0;
    }
    Array.Clear((Array) instance.MarchEventData[(int) index1].HeroID, 0, instance.MarchEventData[(int) index1].HeroID.Length);
    instance.SetFightHeroData();
    GameManager.OnRefresh(NetworkNews.Refresh_Hero);
    DataManager.Instance.MarchEventData[(int) index1].Type = EMarchEventType.EMET_Standby;
    DataManager.Instance.SetQueueBarData((EQueueBarIndex) (2 + (int) index1), false, 0L, 0U);
    DataManager.Instance.CheckTroolCount();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
  }

  public void RecvMapMonsterInfo(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    instance.RoleAttr.LastHitMonsterTime = MP.ReadLong();
    instance.RoleAttr.LastHitMonsterSerialNO = MP.ReadUInt();
    instance.RoleAttr.DamageRateForMonster = MP.ReadByte();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MapMonster, 0);
  }

  public ushort GetMonsterType(ushort MonsterID)
  {
    ActivityManager instance = ActivityManager.Instance;
    for (int index = 0; index < (int) instance.MonsterCount; ++index)
    {
      if ((int) instance.Monster[index] == (int) MonsterID)
        return instance.MonsterType[index];
    }
    return 0;
  }

  public void SaveMapInfo()
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.StringToFormat(Application.persistentDataPath);
    cstring.AppendFormat("{0}/~HKMA.tmp");
    using (FileStream output = new FileStream(cstring.ToString(), FileMode.OpenOrCreate, FileAccess.Write))
    {
      using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
      {
        binaryWriter.Write(this.OtherKingdomData.kingdomID);
        for (byte index = 0; index < (byte) 8; ++index)
        {
          ushort zoneID = this.RAMSataeInfo[(int) index].zoneID;
          binaryWriter.Write(zoneID);
          ulong updateNum = this.ZoneUpdateInfo[(int) zoneID].updateNum;
          binaryWriter.Write(updateNum);
          if (this.ZoneUpdateInfo[(int) zoneID].updateNum != 0UL)
          {
            for (int pointID = 0; pointID < 256; ++pointID)
            {
              int mapId = GameConstants.PointCodeToMapID(zoneID, (byte) pointID);
              POINT_KIND mapInfoPointKind = this.GetLayoutMapInfoPointKind((uint) mapId);
              binaryWriter.Write((byte) mapInfoPointKind);
              if (mapInfoPointKind > POINT_KIND.PK_NONE)
              {
                zoneID = this.LayoutMapInfo[mapId].tableID;
                if (mapInfoPointKind < POINT_KIND.PK_CITY)
                {
                  binaryWriter.Write(this.ResourcesPointTable[(int) zoneID].playerName.ToString());
                  if (this.ResourcesPointTable[(int) zoneID].playerName.Length != 0)
                  {
                    binaryWriter.Write(this.ResourcesPointTable[(int) zoneID].allianceTag.ToString());
                    binaryWriter.Write(this.ResourcesPointTable[(int) zoneID].kingdomID);
                    binaryWriter.Write(this.ResourcesPointTable[(int) zoneID].rate);
                    binaryWriter.Write(this.ResourcesPointTable[(int) zoneID].time);
                  }
                  binaryWriter.Write(this.ResourcesPointTable[(int) zoneID].level);
                  binaryWriter.Write(this.ResourcesPointTable[(int) zoneID].count);
                  binaryWriter.Flush();
                }
                else if (mapInfoPointKind < POINT_KIND.PK_NPC)
                {
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].playerName.ToString());
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].allianceTag.ToString());
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].kingdomID);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].level);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].capitalFlag);
                  binaryWriter.Write((byte) this.PlayerPointTable[(int) zoneID].kingdomTitle);
                  binaryWriter.Write((byte) this.PlayerPointTable[(int) zoneID].worldTitle);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].VIP);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].allianceRank);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].portraitID);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].bounty);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].power);
                  binaryWriter.Write(this.PlayerPointTable[(int) zoneID].kill);
                  binaryWriter.Flush();
                }
                else if (mapInfoPointKind == POINT_KIND.PK_NPC)
                {
                  binaryWriter.Write(this.NPCPointTable[(int) zoneID].level);
                  binaryWriter.Write(this.NPCPointTable[(int) zoneID].NPCNum);
                  binaryWriter.Write(this.NPCPointTable[(int) zoneID].Key);
                  binaryWriter.Write(this.NPCPointTable[(int) zoneID].Blood);
                  binaryWriter.Flush();
                }
              }
            }
          }
        }
        binaryWriter.Close();
      }
      output.Close();
    }
  }

  public void LoadMapInfo()
  {
    this.wait = 0.0f;
    this.checkZone = this.zoneIDNum = this.UpdateZoneIDNum = this.LastZoneIDNum = this.waitZoneIDNum = this.gotoKingdomState = (byte) 0;
    this.zoneID[0] = this.LastZoneID[0] = (ushort) 16384;
    Array.Clear((Array) this.ZoneUpdateInfo, 0, 1024);
    Array.Clear((Array) this.LayoutMapInfo, 0, 262144);
    for (ushort index = 1; (int) index < this.yolkswitch.Length; ++index)
      this.yolkswitch[(int) index] = (byte) 0;
    this.yolkswitch[0] = (byte) 127;
    for (byte index = 0; index < (byte) 8; ++index)
    {
      this.RAMSataeInfo[(int) index].sortID = this.sortRAMReplaceNum[(int) index] = index;
      this.RAMSataeInfo[(int) index].replaceNum = 0U;
      this.RAMSataeInfo[(int) index].zoneID = (ushort) 1024;
    }
    if (this.ROMSataeInfo != null)
    {
      for (byte index = 0; index < (byte) 120; ++index)
      {
        this.ROMSataeInfo[(int) index].sortID = this.sortROMReplaceNum[(int) index] = index;
        this.ROMSataeInfo[(int) index].replaceNum = 0U;
      }
      CString cstring1 = StringManager.Instance.StaticString1024();
      cstring1.StringToFormat(Application.persistentDataPath);
      cstring1.AppendFormat("{0}/~HKMA.tmp");
      if (File.Exists(cstring1.ToString()))
      {
        using (FileStream input = new FileStream(cstring1.ToString(), FileMode.Open))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) input))
          {
            if ((int) binaryReader.ReadUInt16() == (int) this.OtherKingdomData.kingdomID)
            {
              for (byte index1 = 0; index1 < (byte) 8; ++index1)
              {
                ushort zoneID = binaryReader.ReadUInt16();
                this.ZoneUpdateInfo[(int) zoneID].updateNum = binaryReader.ReadUInt64();
                if (this.ZoneUpdateInfo[(int) zoneID].updateNum != 0UL)
                {
                  this.ZoneUpdateInfo[(int) zoneID].zoneState = index1;
                  this.RAMSataeInfo[(int) index1].zoneID = zoneID;
                  this.RAMSataeInfo[(int) index1].replaceNum = 1U;
                  this.sortMaxRAM(index1);
                  for (int pointID = 0; pointID < 256; ++pointID)
                  {
                    int mapId = GameConstants.PointCodeToMapID(zoneID, (byte) pointID);
                    this.LayoutMapInfo[mapId].pointKind = binaryReader.ReadByte();
                    if (this.LayoutMapInfo[mapId].pointKind > (byte) 0)
                    {
                      if (this.LayoutMapInfo[mapId].pointKind < (byte) 8)
                      {
                        ushort index2 = this.LayoutMapInfo[mapId].tableID = (ushort) this.ResourcesPointTableIDpool.spawn();
                        DataManager.DataBuffer[0] = binaryReader.ReadByte();
                        if (DataManager.DataBuffer[0] != (byte) 0)
                        {
                          for (int index3 = 1; index3 < 13; ++index3)
                            DataManager.DataBuffer[index3] = binaryReader.ReadByte();
                          this.ResourcesPointTable[(int) index2].playerName.ClearString();
                          this.ResourcesPointTable[(int) index2].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
                          DataManager.DataBuffer[0] = binaryReader.ReadByte();
                          if (DataManager.DataBuffer[0] != (byte) 0)
                          {
                            for (int index4 = 1; index4 < 3; ++index4)
                              DataManager.DataBuffer[index4] = binaryReader.ReadByte();
                            this.ResourcesPointTable[(int) index2].allianceTag.ClearString();
                            this.ResourcesPointTable[(int) index2].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
                          }
                          this.ResourcesPointTable[(int) index2].kingdomID = binaryReader.ReadUInt16();
                          for (int index5 = 0; index5 < 4; ++index5)
                            DataManager.DataBuffer[index5] = binaryReader.ReadByte();
                          this.ResourcesPointTable[(int) index2].rate = GameConstants.ConvertBytesToFloat(DataManager.DataBuffer, 0);
                          this.ResourcesPointTable[(int) index2].time = binaryReader.ReadUInt64();
                        }
                        else
                          this.ResourcesPointTable[(int) index2].allianceTag.ClearString();
                        this.ResourcesPointTable[(int) index2].level = binaryReader.ReadByte();
                        this.ResourcesPointTable[(int) index2].count = binaryReader.ReadUInt32();
                      }
                      else if (this.LayoutMapInfo[mapId].pointKind < (byte) 10)
                      {
                        ushort index6 = this.LayoutMapInfo[mapId].tableID = (ushort) this.PlayerPointTableIDpool.spawn();
                        for (int index7 = 0; index7 < 13; ++index7)
                          DataManager.DataBuffer[index7] = binaryReader.ReadByte();
                        this.PlayerPointTable[(int) index6].playerName.ClearString();
                        this.PlayerPointTable[(int) index6].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
                        DataManager.DataBuffer[0] = binaryReader.ReadByte();
                        if (DataManager.DataBuffer[0] != (byte) 0)
                        {
                          for (int index8 = 1; index8 < 3; ++index8)
                            DataManager.DataBuffer[index8] = binaryReader.ReadByte();
                          this.PlayerPointTable[(int) index6].allianceTag.ClearString();
                          this.PlayerPointTable[(int) index6].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
                        }
                        this.PlayerPointTable[(int) index6].kingdomID = binaryReader.ReadUInt16();
                        this.PlayerPointTable[(int) index6].level = binaryReader.ReadByte();
                        this.PlayerPointTable[(int) index6].capitalFlag = binaryReader.ReadByte();
                        this.PlayerPointTable[(int) index6].kingdomTitle = (KINGDOM_DESIGNATION) binaryReader.ReadByte();
                        this.PlayerPointTable[(int) index6].worldTitle = (WORLD_PLAYER_DESIGNATION) binaryReader.ReadByte();
                        this.PlayerPointTable[(int) index6].VIP = binaryReader.ReadByte();
                        this.PlayerPointTable[(int) index6].allianceRank = binaryReader.ReadByte();
                        this.PlayerPointTable[(int) index6].portraitID = binaryReader.ReadUInt16();
                        this.PlayerPointTable[(int) index6].bounty = binaryReader.ReadUInt32();
                        this.PlayerPointTable[(int) index6].power = binaryReader.ReadUInt64();
                        this.PlayerPointTable[(int) index6].kill = binaryReader.ReadUInt64();
                      }
                      else if (this.LayoutMapInfo[mapId].pointKind == (byte) 10)
                      {
                        ushort index9 = this.LayoutMapInfo[mapId].tableID = (ushort) this.NPCPointTableIDpool.spawn();
                        this.NPCPointTable[(int) index9].level = binaryReader.ReadByte();
                        this.NPCPointTable[(int) index9].NPCNum = binaryReader.ReadUInt16();
                        this.NPCPointTable[(int) index9].Key = binaryReader.ReadUInt32();
                        this.NPCPointTable[(int) index9].Blood = (float) binaryReader.ReadUInt32();
                      }
                    }
                  }
                }
                else
                  break;
              }
            }
            binaryReader.Close();
          }
          input.Close();
        }
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.StringToFormat(Application.persistentDataPath);
        cstring2.AppendFormat("{0}/~HKMO.tmp");
        if (File.Exists(cstring2.ToString()))
        {
          using (FileStream input = new FileStream(cstring2.ToString(), FileMode.Open))
          {
            using (BinaryReader binaryReader = new BinaryReader((Stream) input))
            {
              if ((int) binaryReader.ReadUInt16() == (int) this.OtherKingdomData.kingdomID)
              {
                for (int index10 = 0; index10 < 120; ++index10)
                {
                  ushort index11 = binaryReader.ReadUInt16();
                  this.ZoneUpdateInfo[(int) index11].updateNum = binaryReader.ReadUInt64();
                  if (this.ZoneUpdateInfo[(int) index11].updateNum != 0UL)
                  {
                    this.ZoneUpdateInfo[(int) index11].zoneState = (byte) (index10 + 8);
                    this.ROMSataeInfo[index10].zoneID = index11;
                    this.ROMSataeInfo[index10].replaceNum = 1U;
                    this.sortMaxROM((byte) index10);
                  }
                }
              }
              binaryReader.Close();
            }
            input.Close();
          }
        }
      }
    }
    this.PlayerPointTableIDpool.init();
    this.ResourcesPointTableIDpool.init();
    this.NPCPointTableIDpool.init();
    Array.Clear((Array) this.NPCNumMap, 0, 5);
    Array.Clear((Array) this.OtherNPCNumMap, 0, 5);
    this.delAllLine();
    this.MapLineTableIDpool.init();
    this.WorldKingdomTableIDcounter = this.reqKingdomIDNum = this.lastReqKingdomIDNum = this.updateKingdomNum = (byte) 0;
    Array.Clear((Array) this.reqKingdomID, 0, 16);
    Array.Clear((Array) this.lastReqKingdomID, 0, 16);
    Array.Clear((Array) this.updateKingdomID, 0, 16);
    if (this.KingdomIDposOrder != null)
      Array.Clear((Array) this.KingdomIDposOrder, 0, this.KingdomIDposOrder.Length);
    if (this.TileMapKingdomID == null)
      return;
    Array.Clear((Array) this.TileMapKingdomID, 0, this.TileMapKingdomID.Length);
  }

  public void moveRAMtoROM(ushort newZoneID)
  {
    byte index1 = this.sortRAMReplaceNum[0];
    int num1 = 62;
    if (this.ROMSataeInfo == null)
    {
      ushort zoneId = this.RAMSataeInfo[(int) index1].zoneID;
      this.RAMSataeInfo[(int) index1].zoneID = newZoneID;
      this.RAMSataeInfo[(int) index1].replaceNum = this.RAMSataeInfo[(int) this.sortRAMReplaceNum[7]].replaceNum + 1U;
      this.ZoneUpdateInfo[(int) newZoneID].zoneState = index1;
      this.sortMaxRAM(index1);
      if (zoneId >= (ushort) 1024)
        return;
      this.ZoneUpdateInfo[(int) zoneId].updateNum = 0UL;
      this.freeZonePoint(zoneId);
    }
    else
    {
      byte index2 = this.sortROMReplaceNum[0];
      if (this.ROMSataeInfo[(int) index2].replaceNum != 0U)
      {
        this.ZoneUpdateInfo[(int) this.ROMSataeInfo[(int) index2].zoneID].updateNum = 0UL;
        ushort zoneID1 = this.ROMSataeInfo[(int) index2].zoneID = this.RAMSataeInfo[(int) index1].zoneID;
        this.ROMSataeInfo[(int) index2].replaceNum = this.RAMSataeInfo[(int) index1].replaceNum;
        this.sortMaxROM(index2);
        this.ZoneUpdateInfo[(int) zoneID1].zoneState = (byte) ((uint) index2 + 120U);
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.StringToFormat(Application.persistentDataPath);
        cstring.AppendFormat("{0}/~HKMO.tmp");
        if (File.Exists(cstring.ToString()))
        {
          using (FileStream output = new FileStream(cstring.ToString(), FileMode.Open, FileAccess.Write))
          {
            using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
            {
              binaryWriter.Seek(4 + 12 * (int) index2, SeekOrigin.Current);
              ushort zoneID2;
              ulong num2;
              if (this.ROMSataeInfo[(int) index2].replaceNum == 0U)
              {
                zoneID2 = (ushort) 0;
                num2 = 0UL;
              }
              else
              {
                zoneID2 = this.ROMSataeInfo[(int) index2].zoneID;
                num2 = this.ZoneUpdateInfo[(int) zoneID2].updateNum;
              }
              binaryWriter.Write(zoneID2);
              binaryWriter.Write(num2);
              binaryWriter.Seek(1444 + (int) index2 * 256 * num1, SeekOrigin.Begin);
              for (int pointID = 0; pointID < 256; ++pointID)
              {
                int mapId = GameConstants.PointCodeToMapID(zoneID2, (byte) pointID);
                POINT_KIND mapInfoPointKind = this.GetLayoutMapInfoPointKind((uint) mapId);
                binaryWriter.Write((byte) mapInfoPointKind);
                if (mapInfoPointKind > POINT_KIND.PK_NONE)
                {
                  ushort tableId = this.LayoutMapInfo[mapId].tableID;
                  if (mapInfoPointKind < POINT_KIND.PK_CITY)
                  {
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].playerName.ToString());
                    binaryWriter.Seek(13 - this.ResourcesPointTable[(int) tableId].playerName.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].allianceTag.ToString());
                    binaryWriter.Seek(3 - this.ResourcesPointTable[(int) tableId].allianceTag.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].kingdomID);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].rate);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].time);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].level);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].count);
                    binaryWriter.Flush();
                    binaryWriter.Seek(7, SeekOrigin.Current);
                    this.ResourcesPointTableIDpool.despawn((int) tableId);
                  }
                  else if (mapInfoPointKind < POINT_KIND.PK_NPC)
                  {
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].playerName.ToString());
                    binaryWriter.Seek(13 - this.PlayerPointTable[(int) tableId].playerName.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].allianceTag.ToString());
                    binaryWriter.Seek(13 - this.PlayerPointTable[(int) tableId].allianceTag.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].kingdomID);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].level);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].capitalFlag);
                    binaryWriter.Write((byte) this.PlayerPointTable[(int) tableId].kingdomTitle);
                    binaryWriter.Write((byte) this.PlayerPointTable[(int) tableId].worldTitle);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].VIP);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].allianceRank);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].portraitID);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].bounty);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].power);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].kill);
                    binaryWriter.Flush();
                    this.PlayerPointTableIDpool.despawn((int) tableId);
                  }
                  else if (mapInfoPointKind == POINT_KIND.PK_NPC)
                  {
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].level);
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].NPCNum);
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].Key);
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].Blood);
                    binaryWriter.Flush();
                    this.NPCPointTableIDpool.despawn((int) tableId);
                  }
                  this.LayoutMapInfo[mapId].pointKind = (byte) 0;
                }
                else
                  binaryWriter.Seek(num1 - 1, SeekOrigin.Current);
              }
              binaryWriter.Close();
            }
            output.Close();
          }
        }
        else
        {
          using (FileStream output = new FileStream(cstring.ToString(), FileMode.CreateNew, FileAccess.Write))
          {
            using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
            {
              binaryWriter.Write(this.OtherKingdomData.kingdomID);
              for (int index3 = 0; index3 < 120; ++index3)
              {
                ulong num3;
                if (this.ROMSataeInfo[index3].replaceNum == 0U)
                {
                  zoneID1 = (ushort) 0;
                  num3 = 0UL;
                }
                else
                {
                  zoneID1 = this.ROMSataeInfo[index3].zoneID;
                  num3 = this.ZoneUpdateInfo[(int) zoneID1].updateNum;
                }
                binaryWriter.Write(zoneID1);
                binaryWriter.Write(num3);
              }
              binaryWriter.Seek((int) index2 * 256 * num1, SeekOrigin.Current);
              for (int pointID = 0; pointID < 256; ++pointID)
              {
                int mapId = GameConstants.PointCodeToMapID(zoneID1, (byte) pointID);
                POINT_KIND mapInfoPointKind = this.GetLayoutMapInfoPointKind((uint) mapId);
                binaryWriter.Write((byte) mapInfoPointKind);
                if (mapInfoPointKind > POINT_KIND.PK_NONE)
                {
                  ushort tableId = this.LayoutMapInfo[mapId].tableID;
                  if (mapInfoPointKind < POINT_KIND.PK_CITY)
                  {
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].playerName.ToString());
                    binaryWriter.Seek(13 - this.ResourcesPointTable[(int) tableId].playerName.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].allianceTag.ToString());
                    binaryWriter.Seek(3 - this.ResourcesPointTable[(int) tableId].allianceTag.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].kingdomID);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].rate);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].time);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].level);
                    binaryWriter.Write(this.ResourcesPointTable[(int) tableId].count);
                    binaryWriter.Flush();
                    binaryWriter.Seek(7, SeekOrigin.Current);
                    this.ResourcesPointTableIDpool.despawn((int) tableId);
                  }
                  else if (mapInfoPointKind < POINT_KIND.PK_NPC)
                  {
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].playerName.ToString());
                    binaryWriter.Seek(13 - this.PlayerPointTable[(int) tableId].playerName.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].allianceTag.ToString());
                    binaryWriter.Seek(13 - this.PlayerPointTable[(int) tableId].allianceTag.Length, SeekOrigin.Current);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].kingdomID);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].level);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].capitalFlag);
                    binaryWriter.Write((byte) this.PlayerPointTable[(int) tableId].kingdomTitle);
                    binaryWriter.Write((byte) this.PlayerPointTable[(int) tableId].worldTitle);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].VIP);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].allianceRank);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].portraitID);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].bounty);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].power);
                    binaryWriter.Write(this.PlayerPointTable[(int) tableId].kill);
                    binaryWriter.Flush();
                    this.PlayerPointTableIDpool.despawn((int) tableId);
                  }
                  else if (mapInfoPointKind == POINT_KIND.PK_NPC)
                  {
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].level);
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].NPCNum);
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].Key);
                    binaryWriter.Write(this.NPCPointTable[(int) tableId].Blood);
                    binaryWriter.Flush();
                    this.NPCPointTableIDpool.despawn((int) tableId);
                  }
                  this.LayoutMapInfo[mapId].pointKind = (byte) 0;
                }
                else
                  binaryWriter.Seek(num1 - 1, SeekOrigin.Current);
              }
              binaryWriter.Close();
            }
            output.Close();
          }
        }
      }
      this.ZoneUpdateInfo[(int) newZoneID].zoneState = index1;
      this.RAMSataeInfo[(int) index1].zoneID = newZoneID;
    }
  }

  public void switchRAMtoROM(byte ROMID, bool bClear)
  {
    byte index1 = this.sortRAMReplaceNum[0];
    if (this.RAMSataeInfo[(int) index1].replaceNum == 0U)
      return;
    ushort zoneId1 = this.RAMSataeInfo[(int) index1].zoneID;
    ushort zoneId2 = this.ROMSataeInfo[(int) ROMID].zoneID;
    int num1 = 62;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.StringToFormat(Application.persistentDataPath);
    cstring.AppendFormat("{0}/~HKMO.tmp");
    using (FileStream fileStream = new FileStream(cstring.ToString(), FileMode.Open, FileAccess.ReadWrite))
    {
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      fileStream.Seek((long) (4 + 12 * (int) ROMID), SeekOrigin.Current);
      ulong updateNum = this.ZoneUpdateInfo[(int) zoneId1].updateNum;
      binaryWriter.Write(zoneId1);
      binaryWriter.Write(updateNum);
      binaryWriter.Flush();
      fileStream.Seek((long) (1444 + (int) ROMID * 256 * num1), SeekOrigin.Begin);
      for (int pointID = 0; pointID < 256; ++pointID)
      {
        if (bClear)
        {
          int mapId = GameConstants.PointCodeToMapID(zoneId2, (byte) pointID);
          this.LayoutMapInfo[mapId].pointKind = binaryReader.ReadByte();
          if (this.LayoutMapInfo[mapId].pointKind > (byte) 0)
          {
            if (this.LayoutMapInfo[mapId].pointKind < (byte) 8)
            {
              for (int index2 = 0; index2 < 13; ++index2)
                DataManager.DataBuffer[index2] = binaryReader.ReadByte();
              ushort index3 = this.LayoutMapInfo[mapId].tableID = (ushort) this.ResourcesPointTableIDpool.spawn();
              this.ResourcesPointTable[(int) index3].playerName.ClearString();
              this.ResourcesPointTable[(int) index3].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
              for (int index4 = 0; index4 < 3; ++index4)
                DataManager.DataBuffer[index4] = binaryReader.ReadByte();
              this.ResourcesPointTable[(int) index3].allianceTag.ClearString();
              this.ResourcesPointTable[(int) index3].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
              this.ResourcesPointTable[(int) index3].kingdomID = binaryReader.ReadUInt16();
              for (int index5 = 0; index5 < 4; ++index5)
                DataManager.DataBuffer[index5] = binaryReader.ReadByte();
              this.ResourcesPointTable[(int) index3].rate = GameConstants.ConvertBytesToFloat(DataManager.DataBuffer, 0);
              this.ResourcesPointTable[(int) index3].time = binaryReader.ReadUInt64();
              this.ResourcesPointTable[(int) index3].level = binaryReader.ReadByte();
              this.ResourcesPointTable[(int) index3].count = binaryReader.ReadUInt32();
              fileStream.Seek(-55L, SeekOrigin.Current);
            }
            else if (this.LayoutMapInfo[mapId].pointKind < (byte) 10)
            {
              for (int index6 = 0; index6 < 13; ++index6)
                DataManager.DataBuffer[index6] = binaryReader.ReadByte();
              ushort index7 = this.LayoutMapInfo[mapId].tableID = (ushort) this.PlayerPointTableIDpool.spawn();
              this.PlayerPointTable[(int) index7].playerName.ClearString();
              this.PlayerPointTable[(int) index7].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
              DataManager.DataBuffer[0] = binaryReader.ReadByte();
              if (DataManager.DataBuffer[0] != (byte) 0)
              {
                for (int index8 = 1; index8 < 3; ++index8)
                  DataManager.DataBuffer[index8] = binaryReader.ReadByte();
                this.PlayerPointTable[(int) index7].allianceTag.ClearString();
                this.PlayerPointTable[(int) index7].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
              }
              this.PlayerPointTable[(int) index7].kingdomID = binaryReader.ReadUInt16();
              this.PlayerPointTable[(int) index7].level = binaryReader.ReadByte();
              this.PlayerPointTable[(int) index7].capitalFlag = binaryReader.ReadByte();
              this.PlayerPointTable[(int) index7].kingdomTitle = (KINGDOM_DESIGNATION) binaryReader.ReadByte();
              this.PlayerPointTable[(int) index7].worldTitle = (WORLD_PLAYER_DESIGNATION) binaryReader.ReadByte();
              this.PlayerPointTable[(int) index7].VIP = binaryReader.ReadByte();
              this.PlayerPointTable[(int) index7].allianceRank = binaryReader.ReadByte();
              this.PlayerPointTable[(int) index7].portraitID = binaryReader.ReadUInt16();
              this.PlayerPointTable[(int) index7].bounty = binaryReader.ReadUInt32();
              this.PlayerPointTable[(int) index7].power = binaryReader.ReadUInt64();
              this.PlayerPointTable[(int) index7].kill = binaryReader.ReadUInt64();
              fileStream.Seek((long) (-num1 - 1), SeekOrigin.Current);
            }
            else if (this.LayoutMapInfo[mapId].pointKind == (byte) 10)
            {
              ushort index9 = this.LayoutMapInfo[mapId].tableID = (ushort) this.NPCPointTableIDpool.spawn();
              this.NPCPointTable[(int) index9].level = binaryReader.ReadByte();
              this.NPCPointTable[(int) index9].NPCNum = binaryReader.ReadUInt16();
              this.NPCPointTable[(int) index9].Key = binaryReader.ReadUInt32();
              this.NPCPointTable[(int) index9].Blood = (float) binaryReader.ReadUInt32();
              fileStream.Seek((long) (-num1 - 1), SeekOrigin.Current);
            }
          }
          else
            fileStream.Seek(-1L, SeekOrigin.Current);
        }
        int mapId1 = GameConstants.PointCodeToMapID(zoneId1, (byte) pointID);
        POINT_KIND mapInfoPointKind = this.GetLayoutMapInfoPointKind((uint) mapId1);
        binaryWriter.Write((byte) mapInfoPointKind);
        if (mapInfoPointKind > POINT_KIND.PK_NONE)
        {
          ushort tableId = this.LayoutMapInfo[mapId1].tableID;
          if (mapInfoPointKind < POINT_KIND.PK_CITY)
          {
            binaryWriter.Write(this.ResourcesPointTable[(int) tableId].playerName.ToString());
            fileStream.Seek((long) (13 - this.ResourcesPointTable[(int) tableId].playerName.Length), SeekOrigin.Current);
            binaryWriter.Write(this.ResourcesPointTable[(int) tableId].allianceTag.ToString());
            fileStream.Seek((long) (3 - this.ResourcesPointTable[(int) tableId].allianceTag.Length), SeekOrigin.Current);
            binaryWriter.Write(this.ResourcesPointTable[(int) tableId].kingdomID);
            binaryWriter.Write(this.ResourcesPointTable[(int) tableId].rate);
            binaryWriter.Write(this.ResourcesPointTable[(int) tableId].time);
            binaryWriter.Write(this.ResourcesPointTable[(int) tableId].level);
            binaryWriter.Write(this.ResourcesPointTable[(int) tableId].count);
            binaryWriter.Flush();
            fileStream.Seek(7L, SeekOrigin.Current);
            this.ResourcesPointTableIDpool.despawn((int) tableId);
          }
          else if (mapInfoPointKind < POINT_KIND.PK_NPC)
          {
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].playerName.ToString());
            fileStream.Seek((long) (13 - this.PlayerPointTable[(int) tableId].playerName.Length), SeekOrigin.Current);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].allianceTag.ToString());
            fileStream.Seek((long) (13 - this.PlayerPointTable[(int) tableId].allianceTag.Length), SeekOrigin.Current);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].kingdomID);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].level);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].capitalFlag);
            binaryWriter.Write((byte) this.PlayerPointTable[(int) tableId].kingdomTitle);
            binaryWriter.Write((byte) this.PlayerPointTable[(int) tableId].worldTitle);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].VIP);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].allianceRank);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].portraitID);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].bounty);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].power);
            binaryWriter.Write(this.PlayerPointTable[(int) tableId].kill);
            binaryWriter.Flush();
            this.PlayerPointTableIDpool.despawn((int) tableId);
          }
          else if (mapInfoPointKind == POINT_KIND.PK_NPC)
          {
            binaryWriter.Write(this.NPCPointTable[(int) tableId].level);
            binaryWriter.Write(this.NPCPointTable[(int) tableId].NPCNum);
            binaryWriter.Write(this.NPCPointTable[(int) tableId].Key);
            binaryWriter.Write(this.NPCPointTable[(int) tableId].Blood);
            binaryWriter.Flush();
            this.NPCPointTableIDpool.despawn((int) tableId);
          }
          this.LayoutMapInfo[mapId1].pointKind = (byte) 0;
        }
        else
          fileStream.Seek((long) (num1 - 1), SeekOrigin.Current);
      }
      binaryReader.Close();
      binaryWriter.Close();
      fileStream.Close();
    }
    ulong num2 = (ulong) (this.ROMSataeInfo[(int) ROMID].replaceNum + 1U);
    this.ROMSataeInfo[(int) ROMID].replaceNum = this.RAMSataeInfo[(int) index1].replaceNum;
    this.sortMaxROM(ROMID);
    this.ROMSataeInfo[(int) ROMID].zoneID = zoneId1;
    this.ZoneUpdateInfo[(int) zoneId1].zoneState = (byte) ((uint) ROMID + 8U);
    this.RAMSataeInfo[(int) index1].replaceNum = (uint) num2;
    this.sortMaxRAM(index1);
    this.RAMSataeInfo[(int) index1].zoneID = zoneId2;
    this.ZoneUpdateInfo[(int) zoneId2].zoneState = index1;
  }

  public void sortMaxRAM(byte index)
  {
    for (byte index1 = (byte) ((uint) this.RAMSataeInfo[(int) index].sortID + 1U); index1 < (byte) 8 && this.RAMSataeInfo[(int) index].replaceNum > this.RAMSataeInfo[(int) this.sortRAMReplaceNum[(int) index1]].replaceNum; this.sortRAMReplaceNum[(int) index1++] = index)
    {
      this.RAMSataeInfo[(int) this.sortRAMReplaceNum[(int) index1]].sortID = this.RAMSataeInfo[(int) index].sortID;
      this.sortRAMReplaceNum[(int) this.RAMSataeInfo[(int) index].sortID] = this.sortRAMReplaceNum[(int) index1];
      this.RAMSataeInfo[(int) index].sortID = index1;
    }
  }

  public void sortMaxROM(byte index)
  {
    for (byte index1 = (byte) ((uint) this.ROMSataeInfo[(int) index].sortID + 1U); index1 < (byte) 120 && this.ROMSataeInfo[(int) index].replaceNum > this.ROMSataeInfo[(int) this.sortROMReplaceNum[(int) index1]].replaceNum; this.sortROMReplaceNum[(int) index1++] = index)
    {
      this.ROMSataeInfo[(int) this.sortROMReplaceNum[(int) index1]].sortID = this.ROMSataeInfo[(int) index].sortID;
      this.sortROMReplaceNum[(int) this.ROMSataeInfo[(int) index].sortID] = this.sortROMReplaceNum[(int) index1];
      this.ROMSataeInfo[(int) index].sortID = index1;
    }
  }

  public void setLastZoneInfo(byte nowZoneIDNum, ushort[] nowZoneID, bool renew)
  {
    if (this.zoneIDNum == (byte) 0 || (int) this.checkZone >> (int) this.zoneIDNum == 1)
    {
      for (byte index = 0; index < (byte) 4; ++index)
      {
        this.LastZoneID[(int) index] = this.zoneID[(int) index];
        this.zoneID[(int) index] = nowZoneID[(int) index];
      }
      this.LastZoneIDNum = this.zoneIDNum;
      this.zoneIDNum = nowZoneIDNum;
      this.sendRequestMapdataMsg(renew);
    }
    else
    {
      if (nowZoneIDNum <= (byte) 0 || nowZoneIDNum >= (byte) 4)
        return;
      for (byte index = 0; index < (byte) 4; ++index)
        this.waitZoneID[(int) index] = nowZoneID[(int) index];
      this.waitZoneIDNum = nowZoneIDNum;
    }
  }

  public void sendRequestMapdataMsg(bool renew)
  {
    this.checkZone = this.zoneID[0] != (ushort) 16384 ? (byte) 0 : (byte) 2;
    DataManager.msgBuffer[0] = (byte) 68;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    MessagePacket messagePacket = (int) this.FocusKingdomID == (int) this.OtherKingdomData.kingdomID ? new MessagePacket((ushort) 1024) : MessagePacket.GetGuestMessagePack();
    messagePacket.Protocol = Protocol._MSG_REQUEST_MAPDATA;
    messagePacket.AddSeqId();
    messagePacket.Add(this.zoneIDNum);
    for (int index = 0; index < 4; ++index)
      messagePacket.Add(this.zoneID[index]);
    if (renew)
    {
      for (int index = 0; index < 4; ++index)
        messagePacket.Add(0UL);
    }
    else
    {
      for (int index = 0; index < 4; ++index)
        messagePacket.Add(this.ZoneUpdateInfo[(int) this.zoneID[index]].updateNum);
    }
    messagePacket.Send();
    this.wait = 1.5f;
  }

  public void sendRequestKingdomMsg()
  {
    DataManager.msgBuffer[0] = (byte) 106;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.lastReqKingdomIDNum = this.reqKingdomIDNum;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM;
    messagePacket.AddSeqId();
    messagePacket.Add(this.reqKingdomIDNum);
    for (int index = 0; index < 16; ++index)
    {
      messagePacket.Add(this.reqKingdomID[index]);
      this.lastReqKingdomID[index] = this.reqKingdomID[index];
    }
    for (int index = 0; index < 16; ++index)
      messagePacket.Add(0UL);
    messagePacket.Send();
    this.wait = 1.5f;
  }

  public void delAllLine()
  {
    for (int index = 0; index < this.MapLineTable.Count; ++index)
    {
      if (this.MapLineTable[index].lineID < 1048576U)
        this.delLine(index, (byte) 0);
    }
    DataManager.msgBuffer[0] = (byte) 92;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void updateCapitalPoint(
    ushort newZoneID,
    byte newPointID,
    ushort newKingdomID,
    bool gotoCapitalPoint = false)
  {
    bool flag = (int) this.OtherKingdomData.kingdomID == (int) newKingdomID;
    this.updateMyKingdom(newKingdomID, this.kingdomData.kingdomID);
    if (newZoneID >= (ushort) 1024)
      return;
    DataManager.Instance.RoleAttr.CapitalPoint = GameConstants.PointCodeToMapID(newZoneID, newPointID);
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && menu.GetTerrain(newKingdomID, (uint) DataManager.Instance.RoleAttr.CapitalPoint) == MAP_TERRAIN_KIND.MTK_FOREST)
      DataManager.Instance.CancelShieldItemBuff();
    if (!gotoCapitalPoint)
      return;
    DataManager.msgBuffer[0] = (byte) 83;
    DataManager.msgBuffer[1] = !flag ? (byte) 0 : (byte) 1;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.msgBuffer[0] = (byte) 120;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public bool IsResources(uint layoutMapInfoID)
  {
    POINT_KIND mapInfoPointKind = this.GetLayoutMapInfoPointKind(layoutMapInfoID);
    return mapInfoPointKind > POINT_KIND.PK_NONE && mapInfoPointKind < POINT_KIND.PK_CITY;
  }

  public bool IsCityOrCamp(uint layoutMapInfoID)
  {
    POINT_KIND mapInfoPointKind = this.GetLayoutMapInfoPointKind(layoutMapInfoID);
    return mapInfoPointKind == POINT_KIND.PK_CAMP || mapInfoPointKind == POINT_KIND.PK_CITY;
  }

  public POINT_KIND GetLayoutMapInfoPointKind(uint layoutMapInfoID)
  {
    return (POINT_KIND) this.LayoutMapInfo[(IntPtr) layoutMapInfoID].pointKind;
  }

  public void GetKingdomName(ushort kindomID, ref CString str)
  {
    str.ClearString();
    KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(kindomID);
    if (recordByKey.kingdomName == null)
      return;
    for (int index = 0; index < recordByKey.kingdomName.Length; ++index)
      str.Append(recordByKey.kingdomName[index]);
  }

  public void UpdateWaitZone()
  {
    if ((double) this.wait == 0.0)
      return;
    this.wait -= Time.deltaTime;
    if ((double) this.wait >= 0.0)
      return;
    this.wait = 0.0f;
    if (this.zoneIDNum > (byte) 0 && (int) this.checkZone >> (int) this.zoneIDNum != 1)
    {
      this.sendRequestMapdataMsg(false);
    }
    else
    {
      if (this.waitZoneIDNum > (byte) 0 && this.waitZoneIDNum < (byte) 4)
        this.setLastZoneInfo(this.waitZoneIDNum, this.waitZoneID, false);
      this.waitZoneIDNum = (byte) 0;
    }
  }

  public void UpdateWaitKingdom()
  {
    if ((double) this.wait == 0.0)
      return;
    this.wait -= Time.deltaTime;
    if ((double) this.wait >= 0.0)
      return;
    this.wait = 0.0f;
    this.sendRequestKingdomMsg();
  }

  public void RequestKingdomData(int minX, int minY, int maxX, int maxY)
  {
    this.reqKingdomIDNum = (byte) 0;
    int num1 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
    for (int index1 = minX; index1 <= maxX; ++index1)
    {
      for (int index2 = minY; index2 <= maxY; ++index2)
      {
        int index3 = index1 + index2 * num1;
        if (this.TileMapKingdomID[index3].KingdomID > (ushort) 0 && this.CheckKingdomOpen(this.TileMapKingdomID[index3].KingdomID))
          this.pushReqKingdomID(this.reqKingdomIDNum++, this.TileMapKingdomID[index3].KingdomID);
      }
    }
    if ((int) this.reqKingdomIDNum == (int) this.lastReqKingdomIDNum)
    {
      int index = 0;
      while (index < (int) this.reqKingdomIDNum && (int) this.reqKingdomID[index] == (int) this.lastReqKingdomID[index])
        ++index;
      if (index == (int) this.reqKingdomIDNum)
        return;
    }
    else if ((int) this.reqKingdomIDNum < (int) this.lastReqKingdomIDNum)
    {
      int index4 = 0;
      int num2 = 0;
      int index5 = 0;
      while (index5 < (int) this.lastReqKingdomIDNum && index4 < (int) this.reqKingdomIDNum)
      {
        if ((int) this.reqKingdomID[index4] == (int) this.lastReqKingdomID[index5])
        {
          ++index4;
          ++index5;
          ++num2;
        }
        else if ((int) this.lastReqKingdomID[index5] > (int) this.reqKingdomID[index4])
          ++index4;
        else
          ++index5;
      }
      if (num2 == (int) this.reqKingdomIDNum)
        return;
    }
    this.sendRequestKingdomMsg();
  }

  public void updateMyKingdom(ushort nowKingdomID, ushort homeKingdomID)
  {
    if ((int) this.kingdomData.kingdomID != (int) homeKingdomID)
    {
      this.kingdomData.kingdomID = homeKingdomID;
      if ((int) this.kingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
        this.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
      else if (this.kingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
        this.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
      this.GetKingdomName(this.kingdomData.kingdomID, ref this.kingdomData.kingdomName);
    }
    if ((int) this.OtherKingdomData.kingdomID == (int) nowKingdomID)
      return;
    this.OtherKingdomData.kingdomID = nowKingdomID;
    if ((int) this.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
      this.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
    else if (this.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
      this.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
    this.GetKingdomName(this.OtherKingdomData.kingdomID, ref this.OtherKingdomData.kingdomName);
    LeaderBoardManager.Instance.TotalClear();
    if ((int) this.OtherKingdomData.kingdomID != (int) this.kingdomData.kingdomID && !ActivityManager.Instance.IsKOWRunning())
      this.KVKKingdomID = nowKingdomID;
    if (this.FocusKingdomID != (ushort) 0)
      return;
    this.FocusKingdomID = this.OtherKingdomData.kingdomID;
    this.FocusKingdomPeriod = this.OtherKingdomData.kingdomPeriod;
  }

  public bool CheckKingdomID(ushort kingdomID)
  {
    return this.CheckKingdomOpen(kingdomID) && (int) this.KingdomMapTable.GetRecordByKey(kingdomID).KingdomMapKey == (int) kingdomID;
  }

  public uint CheckWonderMapID(uint inMapID, ushort kingdomID)
  {
    Vector2 zero = Vector2.zero;
    if ((int) kingdomID == (int) this.FocusKingdomID)
    {
      for (ushort index = 0; (int) index < (int) this.showYolkNum; ++index)
      {
        Vector2 yolkPos = this.GetYolkPos((ushort) this.showYolkMapYolkID[(int) index], kingdomID);
        ++yolkPos.y;
        uint mapId = (uint) GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y);
        if ((int) mapId == (int) inMapID || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 1, (int) yolkPos.y - 1) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 1, (int) yolkPos.y - 1) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 2, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 2, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 1, (int) yolkPos.y - 3) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 1, (int) yolkPos.y - 3) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y - 4))
          return mapId;
      }
    }
    else
    {
      Vector2 yolkPos;
      Vector2 vector2 = yolkPos = this.GetYolkPos((ushort) 0, kingdomID);
      ++yolkPos.y;
      uint mapId1 = (uint) GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y);
      if ((int) mapId1 == (int) inMapID || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 1, (int) yolkPos.y - 1) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 1, (int) yolkPos.y - 1) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 2, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 2, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 1, (int) yolkPos.y - 3) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 1, (int) yolkPos.y - 3) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y - 4))
        return mapId1;
      for (ushort WonderID = 1; WonderID < (ushort) 40; ++WonderID)
      {
        yolkPos = this.GetYolkPos(WonderID, kingdomID);
        if (!(vector2 == yolkPos))
        {
          ++yolkPos.y;
          uint mapId2 = (uint) GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y);
          if ((int) mapId2 == (int) inMapID || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 1, (int) yolkPos.y - 1) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 1, (int) yolkPos.y - 1) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 2, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 2, (int) yolkPos.y - 2) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x + 1, (int) yolkPos.y - 3) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x - 1, (int) yolkPos.y - 3) || (int) inMapID == GameConstants.TileMapPosToMapID((int) yolkPos.x, (int) yolkPos.y - 4))
            return mapId2;
        }
        else
          break;
      }
    }
    return 40;
  }

  public void ClearAll()
  {
    this.delAllLine();
    this.zoneIDNum = (byte) 0;
    for (byte index = 0; (int) index < this.RAMSataeInfo.Length; ++index)
    {
      if (this.RAMSataeInfo[(int) index].zoneID < (ushort) 1024)
      {
        this.freeZonePoint(this.RAMSataeInfo[(int) index].zoneID);
        this.ZoneUpdateInfo[(int) this.RAMSataeInfo[(int) index].zoneID].updateNum = 0UL;
      }
      this.RAMSataeInfo[(int) index].sortID = this.sortRAMReplaceNum[(int) index] = index;
      this.RAMSataeInfo[(int) index].replaceNum = 0U;
      this.RAMSataeInfo[(int) index].zoneID = (ushort) 1024;
    }
    Array.Clear((Array) this.ZoneUpdateInfo, 0, 1024);
  }

  public MAP_TERRAIN_KIND GetTerrain(byte mapinfoID)
  {
    if (mapinfoID < (byte) 35)
      return MAP_TERRAIN_KIND.MTK_PRAIRIE;
    if (mapinfoID < (byte) 69)
      return MAP_TERRAIN_KIND.MTK_LAVA;
    if (mapinfoID < (byte) 99)
      return MAP_TERRAIN_KIND.MTK_FROZEN;
    return mapinfoID < (byte) 113 ? MAP_TERRAIN_KIND.MTK_FOREST : MAP_TERRAIN_KIND.MTK_NONE;
  }

  public float CheckLenght(Vector2 point)
  {
    point -= GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
    return (double) point.sqrMagnitude < 179776.0 ? point.magnitude : 0.0f;
  }

  public bool CheckKingdomOpen(ushort check_kingdomID)
  {
    if (this.KingdomOpenFlag == null || check_kingdomID == (ushort) 0)
      return false;
    ushort index;
    byte bitShift;
    this.GetKingdomOpenIndexShift(check_kingdomID, out index, out bitShift);
    return (int) index < this.KingdomOpenFlag.Length && ((int) this.KingdomOpenFlag[(int) index] & 1 << (int) bitShift) > 0;
  }

  public void UpdateKingdomInWorld()
  {
    if (this.KingdomOpenFlag == null)
      return;
    ushort length = 0;
    for (int index1 = this.KingdomOpenFlag.Length - 1; index1 > -1; --index1)
    {
      for (int index2 = 7; index2 > -1; --index2)
      {
        if (((int) this.KingdomOpenFlag[index1] & 1 << index2) > 0)
        {
          length = (ushort) ((index1 << 3) + index2 + 1);
          break;
        }
      }
      if (length != (ushort) 0)
        break;
    }
    if ((int) length > this.KingdomMapTable.TableCount)
      length = (ushort) this.KingdomMapTable.TableCount;
    if (length == (ushort) 0)
      return;
    this.KingdomIDposOrder = new ushort[(int) length];
    Array.Clear((Array) this.KingdomIDposOrder, 0, this.KingdomIDposOrder.Length);
    KingdomMap recordByIndex = this.KingdomMapTable.GetRecordByIndex(0);
    this.WorldOX = this.WorldMaxX = this.WorldMinX = recordByIndex.worldPosX;
    this.WorldOY = this.WorldMaxY = this.WorldMinY = recordByIndex.worldPosY;
    this.KingdomIDposOrder[0] = recordByIndex.KingdomMapKey;
    for (int Index = 1; Index < this.KingdomIDposOrder.Length; ++Index)
    {
      recordByIndex = this.KingdomMapTable.GetRecordByIndex(Index);
      if ((int) recordByIndex.worldPosX > (int) this.WorldMaxX)
        this.WorldMaxX = recordByIndex.worldPosX;
      if ((int) recordByIndex.worldPosX < (int) this.WorldMinX)
        this.WorldMinX = recordByIndex.worldPosX;
      if ((int) recordByIndex.worldPosY > (int) this.WorldMaxY)
        this.WorldMaxY = recordByIndex.worldPosY;
      if ((int) recordByIndex.worldPosY < (int) this.WorldMinY)
        this.WorldMinY = recordByIndex.worldPosY;
      this.KingdomIDposOrder[Index] = recordByIndex.KingdomMapKey;
      for (int index = Index - 1; index > -1; --index)
      {
        KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(this.KingdomIDposOrder[index]);
        if ((int) recordByIndex.worldPosX == (int) recordByKey.worldPosX)
        {
          if ((int) recordByIndex.worldPosY < (int) recordByKey.worldPosY)
          {
            this.KingdomIDposOrder[index + 1] = recordByKey.KingdomMapKey;
            this.KingdomIDposOrder[index] = recordByIndex.KingdomMapKey;
          }
          else
            break;
        }
        else if ((int) recordByIndex.worldPosX < (int) recordByKey.worldPosX)
        {
          this.KingdomIDposOrder[index + 1] = recordByKey.KingdomMapKey;
          this.KingdomIDposOrder[index] = recordByIndex.KingdomMapKey;
        }
        else
          break;
      }
    }
    int num1 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
    int num2 = 10 - (num1 + 8);
    int num3 = (int) this.WorldMinX - (int) this.WorldOX & 1;
    if ((num1 & 1) == 1)
    {
      int num4;
      if (num2 > 0)
      {
        num4 = (int) ((double) (10 - num1) * 0.5);
      }
      else
      {
        int num5 = num1 + 8;
        num4 = (int) ((double) (num5 + (num5 & 1) - num1) * 0.5);
      }
      this.WorldMaxX += (ushort) num4;
      this.WorldMinX -= (ushort) num4;
      if (num3 == 1)
      {
        if ((num4 & 1) == 1)
          ++this.WorldMaxX;
        else
          --this.WorldMinX;
      }
      else if ((num4 & 1) == 0)
        ++this.WorldMaxX;
      else
        --this.WorldMinX;
    }
    else
    {
      int num6 = num2 <= 0 ? 4 : (int) ((double) (10 - num1) * 0.5);
      this.WorldMaxX += (ushort) num6;
      this.WorldMinX -= (ushort) num6;
      if (num3 == 1)
      {
        if ((num6 & 1) == 0)
        {
          ++this.WorldMaxX;
          --this.WorldMinX;
        }
      }
      else if ((num6 & 1) == 1)
      {
        ++this.WorldMaxX;
        --this.WorldMinX;
      }
    }
    int num7 = (int) this.WorldMaxY - (int) this.WorldMinY + 1;
    int num8 = 16 - (num7 + 8);
    int num9 = (int) this.WorldMinY - (int) this.WorldOY & 1;
    if ((num7 & 1) == 1)
    {
      int num10;
      if (num8 > 0)
      {
        num10 = (int) ((double) (16 - num7) * 0.5);
      }
      else
      {
        int num11 = num7 + 8;
        num10 = (int) ((double) (num11 + (num11 & 1) - num7) * 0.5);
      }
      this.WorldMaxY += (ushort) num10;
      this.WorldMinY -= (ushort) num10;
      if (num9 == 1)
      {
        if ((num10 & 1) == 1)
          ++this.WorldMaxY;
        else
          --this.WorldMinY;
      }
      else if ((num10 & 1) == 0)
        ++this.WorldMaxY;
      else
        --this.WorldMinY;
    }
    else
    {
      int num12 = num8 <= 0 ? 4 : (int) ((double) (16 - num7) * 0.5);
      this.WorldMaxY += (ushort) num12;
      this.WorldMinY -= (ushort) num12;
      if (num9 == 1)
      {
        if ((num12 & 1) == 0)
        {
          ++this.WorldMaxY;
          --this.WorldMinY;
        }
      }
      else if ((num12 & 1) == 1)
      {
        ++this.WorldMaxY;
        --this.WorldMinY;
      }
    }
    int num13 = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
    int num14 = (int) this.WorldMaxY - (int) this.WorldMinY + 1;
    bool flag = false;
    if (this.TileMapKingdomID == null)
      this.TileMapKingdomID = new MapKingdom[num13 * num14];
    else if (this.TileMapKingdomID.Length != num13 * num14)
    {
      flag = true;
      this.TileMapKingdomID = new MapKingdom[num13 * num14];
    }
    Array.Clear((Array) this.TileMapKingdomID, 0, this.TileMapKingdomID.Length);
    for (int Index = 0; Index < this.KingdomIDposOrder.Length; ++Index)
    {
      if (this.CheckKingdomOpen((ushort) (Index + 1)))
      {
        recordByIndex = this.KingdomMapTable.GetRecordByIndex(Index);
        int index3 = (int) recordByIndex.worldPosX - (int) this.WorldMinX + ((int) recordByIndex.worldPosY - (int) this.WorldMinY) * num13;
        this.TileMapKingdomID[index3].KingdomID = recordByIndex.KingdomMapKey;
        if (flag)
        {
          byte index4 = (byte) ((uint) (byte) ((uint) this.WorldKingdomTableIDcounter - 1U) & 31U);
          for (byte index5 = 0; (int) index5 < this.WorldKingdomTable.Length; ++index5)
          {
            if ((int) this.WorldKingdomTable[(int) index4].kingdomID == (int) this.TileMapKingdomID[index3].KingdomID)
            {
              this.TileMapKingdomID[index3].tableID = index4;
              break;
            }
            index4 = (byte) ((uint) (byte) ((uint) index4 - 1U) & 31U);
          }
        }
      }
    }
  }

  public void INIT_OPENKINGDOMINFO(MessagePacket MP)
  {
    for (int index = 0; index < DataManager.DataBuffer.Length; ++index)
      DataManager.DataBuffer[index] = MP.ReadByte();
    for (int index = 0; index < 38 - DataManager.msgBuffer.Length; ++index)
      DataManager.msgBuffer[index] = MP.ReadByte();
    byte length1 = MP.ReadByte();
    if (length1 < (byte) 38)
      length1 = (byte) 38;
    if (this.KingdomOpenFlag == null)
    {
      this.KingdomOpenFlag = new byte[(int) length1];
      for (int index = 0; index < DataManager.DataBuffer.Length; ++index)
        this.KingdomOpenFlag[index] = DataManager.DataBuffer[index];
      for (int length2 = DataManager.DataBuffer.Length; length2 < 38; ++length2)
        this.KingdomOpenFlag[length2] = DataManager.msgBuffer[length2 - DataManager.DataBuffer.Length];
      for (int index = 38; index < this.KingdomOpenFlag.Length; ++index)
        this.KingdomOpenFlag[index] = MP.ReadByte();
      this.UpdateKingdomInWorld();
    }
    else
    {
      bool flag = false;
      if (this.KingdomOpenFlag.Length != (int) length1)
      {
        flag = true;
        this.KingdomOpenFlag = new byte[(int) length1];
        for (int index = 0; index < DataManager.DataBuffer.Length; ++index)
          this.KingdomOpenFlag[index] = DataManager.DataBuffer[index];
        for (int length3 = DataManager.DataBuffer.Length; length3 < 38; ++length3)
          this.KingdomOpenFlag[length3] = DataManager.msgBuffer[length3 - DataManager.DataBuffer.Length];
        for (int index = 38; index < this.KingdomOpenFlag.Length; ++index)
          this.KingdomOpenFlag[index] = MP.ReadByte();
      }
      else
      {
        for (int index = 0; index < DataManager.DataBuffer.Length; ++index)
        {
          if ((int) this.KingdomOpenFlag[index] != (int) DataManager.DataBuffer[index])
          {
            flag = true;
            this.KingdomOpenFlag[index] = DataManager.DataBuffer[index];
          }
        }
        for (int length4 = DataManager.DataBuffer.Length; length4 < 38; ++length4)
        {
          if ((int) this.KingdomOpenFlag[length4] != (int) DataManager.msgBuffer[length4 - DataManager.DataBuffer.Length])
          {
            flag = true;
            this.KingdomOpenFlag[length4] = DataManager.msgBuffer[length4 - DataManager.DataBuffer.Length];
          }
        }
        for (int index = 38; index < this.KingdomOpenFlag.Length; ++index)
        {
          byte num = MP.ReadByte();
          if ((int) num != (int) this.KingdomOpenFlag[index])
          {
            flag = true;
            this.KingdomOpenFlag[index] = num;
          }
        }
      }
      if (!flag)
        return;
      this.UpdateKingdomInWorld();
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMapMode != EUIOriginMapMode.WorldMap)
        return;
      this.gotoKingdomState = byte.MaxValue;
      this.gotokingdomID = this.OtherKingdomData.kingdomID;
      this.FocusWorldMapPos = -Vector2.one;
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
    }
  }

  public void UPDATE_OPENKINGDOMINFO(MessagePacket MP)
  {
    if (this.KingdomOpenFlag == null)
      return;
    ushort kingdomID = MP.ReadUShort();
    if (kingdomID == (ushort) 0)
      return;
    ushort index;
    byte bitShift;
    this.GetKingdomOpenIndexShift(kingdomID, out index, out bitShift);
    if ((int) index >= this.KingdomOpenFlag.Length)
      return;
    this.KingdomOpenFlag[(int) index] |= (byte) (1U << (int) bitShift);
    this.UpdateKingdomInWorld();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMapMode != EUIOriginMapMode.WorldMap)
      return;
    this.gotoKingdomState = byte.MaxValue;
    this.gotokingdomID = this.OtherKingdomData.kingdomID;
    this.FocusWorldMapPos = -Vector2.one;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
  }

  public void MY_KINGDOMINFO(MessagePacket MP)
  {
    MAP_KINGDOMINFO_KIND mapKingdominfoKind = (MAP_KINGDOMINFO_KIND) MP.ReadByte();
    for (; mapKingdominfoKind != MAP_KINGDOMINFO_KIND.MAPKINFO_NONE; mapKingdominfoKind = (MAP_KINGDOMINFO_KIND) MP.ReadByte())
    {
      ushort num1 = MP.ReadUShort();
      if (mapKingdominfoKind == MAP_KINGDOMINFO_KIND.MAPKINFO_KINGDOMTIME)
      {
        ushort num2 = MP.ReadUShort();
        ulong num3 = MP.ReadULong();
        if ((int) num2 == (int) this.kingdomData.kingdomID)
          this.kingdomData.kingdomTime = num3;
        if ((int) num2 == (int) this.OtherKingdomData.kingdomID)
          this.OtherKingdomData.kingdomTime = num3;
        byte index1 = (byte) ((uint) (byte) ((uint) this.WorldKingdomTableIDcounter - 1U) & 31U);
        for (byte index2 = 0; (int) index2 < this.WorldKingdomTable.Length; ++index2)
        {
          if ((int) this.WorldKingdomTable[(int) index1].kingdomID == (int) num2)
          {
            this.WorldKingdomTable[(int) index1].kingdomTime = num3;
            break;
          }
          index1 = (byte) ((uint) (byte) ((uint) index1 - 1U) & 31U);
        }
      }
      else
      {
        for (ushort index = 0; (int) index < (int) num1; ++index)
        {
          int num4 = (int) MP.ReadByte();
        }
      }
    }
  }

  public void addLine(int mapLineTableID)
  {
    if (((int) this.MapLineTable[mapLineTableID].start.zoneID & 1023) == (int) this.MapLineTable[mapLineTableID].end.zoneID)
    {
      int zoneState = (int) this.ZoneUpdateInfo[(int) this.MapLineTable[mapLineTableID].start.zoneID & 1023].zoneState;
      this.MapLineTable[mapLineTableID].ZoneIDTable[zoneState] = this.ZoneLineIDTable[zoneState].Count;
      this.MapLineTable[mapLineTableID].zoneNum = (ushort) 1;
      ZoneLine zoneLine;
      zoneLine.lineID = this.MapLineTable[mapLineTableID].lineID;
      zoneLine.lineTableID = (ushort) mapLineTableID;
      this.ZoneLineIDTable[zoneState].Add(zoneLine);
    }
    else
    {
      double num1 = Math.Round(640000000000.0);
      Vector2 vector2_1 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].start.zoneID, (byte) 0);
      Vector2 vector2_2 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].end.zoneID, (byte) 0);
      this.MapLineTable[mapLineTableID].zoneMin.x = (double) vector2_1.x >= (double) vector2_2.x ? vector2_2.x * 2f : vector2_1.x * 2f;
      this.MapLineTable[mapLineTableID].zoneMin.y = (double) vector2_1.y >= (double) vector2_2.y ? vector2_2.y : vector2_1.y;
      vector2_1 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].start.zoneID, byte.MaxValue) + Vector2.one;
      vector2_2 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].end.zoneID, byte.MaxValue) + Vector2.one;
      this.MapLineTable[mapLineTableID].zoneMax.x = (double) vector2_1.x >= (double) vector2_2.x ? vector2_1.x * 2f : vector2_2.x * 2f;
      this.MapLineTable[mapLineTableID].zoneMax.y = (double) vector2_1.y >= (double) vector2_2.y ? vector2_1.y : vector2_2.y;
      vector2_1 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].start.zoneID, this.MapLineTable[mapLineTableID].start.pointID);
      vector2_1.x *= 2f;
      vector2_2 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].end.zoneID, this.MapLineTable[mapLineTableID].end.pointID);
      vector2_2.x *= 2f;
      double num2 = (double) vector2_2.x - (double) vector2_1.x;
      if (num2 == 0.0)
      {
        this.MapLineTable[mapLineTableID].XIntercept = (double) vector2_1.x;
      }
      else
      {
        this.MapLineTable[mapLineTableID].XIntercept = -1.0;
        this.MapLineTable[mapLineTableID].Slope = ((double) vector2_2.y - (double) vector2_1.y) / num2;
        this.MapLineTable[mapLineTableID].YIntercept = (double) vector2_1.y - this.MapLineTable[mapLineTableID].Slope * (double) vector2_1.x;
      }
      for (int index = 0; index < this.RAMSataeInfo.Length; ++index)
      {
        if (this.RAMSataeInfo[index].zoneID != (ushort) 1024)
        {
          bool flag = (int) this.MapLineTable[mapLineTableID].start.zoneID == (int) this.RAMSataeInfo[index].zoneID || (int) this.MapLineTable[mapLineTableID].end.zoneID == (int) this.RAMSataeInfo[index].zoneID;
          if (!flag)
          {
            vector2_1 = GameConstants.getTileMapPosbyPointCode(this.RAMSataeInfo[index].zoneID, (byte) 0);
            vector2_1.x *= 2f;
            if ((double) vector2_1.x < (double) this.MapLineTable[mapLineTableID].zoneMax.x && (double) vector2_1.x >= (double) this.MapLineTable[mapLineTableID].zoneMin.x && (double) vector2_1.y < (double) this.MapLineTable[mapLineTableID].zoneMax.y && (double) vector2_1.y >= (double) this.MapLineTable[mapLineTableID].zoneMin.y)
            {
              if (this.MapLineTable[mapLineTableID].XIntercept < 0.0)
              {
                if (this.MapLineTable[mapLineTableID].Slope == 0.0)
                {
                  flag = this.MapLineTable[mapLineTableID].YIntercept >= (double) vector2_1.y && this.MapLineTable[mapLineTableID].YIntercept < (double) vector2_1.y + 16.0;
                }
                else
                {
                  double num3 = Math.Round((this.MapLineTable[mapLineTableID].Slope * (double) vector2_1.x + this.MapLineTable[mapLineTableID].YIntercept) * 10000000000.0);
                  double num4 = Math.Round((this.MapLineTable[mapLineTableID].Slope * ((double) vector2_1.x + 64.0) + this.MapLineTable[mapLineTableID].YIntercept) * 10000000000.0);
                  double num5 = Math.Round(((double) vector2_1.y - this.MapLineTable[mapLineTableID].YIntercept) / this.MapLineTable[mapLineTableID].Slope * 10000000000.0);
                  double num6 = Math.Round(((double) vector2_1.y + 16.0 - this.MapLineTable[mapLineTableID].YIntercept) / this.MapLineTable[mapLineTableID].Slope * 10000000000.0);
                  double num7 = Math.Round((double) vector2_1.y * 10000000000.0);
                  double num8 = Math.Round((double) vector2_1.x * 10000000000.0);
                  double num9 = Math.Round(160000000000.0);
                  flag = num3 >= num7 && num3 < num7 + num9 || num4 > num7 && num4 < num7 + num9 || num5 >= num8 && num5 < num8 + num1 || num6 > num8 && num6 < num8 + num1 || num4 == num7 && num4 + num9 == num3 && num6 == num8 && num6 + num1 == num5;
                }
              }
              else
                flag = this.MapLineTable[mapLineTableID].XIntercept >= (double) vector2_1.x && this.MapLineTable[mapLineTableID].XIntercept < (double) vector2_1.x + 64.0;
            }
          }
          if (flag)
          {
            int zoneState = (int) this.ZoneUpdateInfo[(int) this.RAMSataeInfo[index].zoneID].zoneState;
            this.MapLineTable[mapLineTableID].ZoneIDTable[zoneState] = this.ZoneLineIDTable[zoneState].Count;
            ++this.MapLineTable[mapLineTableID].zoneNum;
            ZoneLine zoneLine;
            zoneLine.lineID = this.MapLineTable[mapLineTableID].lineID;
            zoneLine.lineTableID = (ushort) mapLineTableID;
            this.ZoneLineIDTable[zoneState].Add(zoneLine);
          }
        }
      }
    }
    this.LineNotifyObserver((byte) 56, mapLineTableID, (byte) 1);
  }

  public void delLine(int mapLineTableID, byte Send = 1)
  {
    for (int index1 = 0; index1 < this.MapLineTable[mapLineTableID].ZoneIDTable.Length; ++index1)
    {
      if (this.MapLineTable[mapLineTableID].ZoneIDTable[index1] != 1048576)
      {
        for (int index2 = this.ZoneLineIDTable[index1].Count - 1; index2 > this.MapLineTable[mapLineTableID].ZoneIDTable[index1]; --index2)
          --this.MapLineTable[(int) this.ZoneLineIDTable[index1][index2].lineTableID].ZoneIDTable[index1];
        this.ZoneLineIDTable[index1].RemoveAt(this.MapLineTable[mapLineTableID].ZoneIDTable[index1]);
        this.MapLineTable[mapLineTableID].ZoneIDTable[index1] = 1048576;
        this.LineDelZone(mapLineTableID, Send);
      }
    }
  }

  public bool IsWorldKing() => DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 1;

  public bool IsWorldChief() => DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 14;

  public bool IsKing() => DataManager.Instance.RoleAttr.KingdomTitle == (ushort) 1;

  public bool IsKingdomChief() => DataManager.Instance.RoleAttr.KingdomTitle == (ushort) 20;

  public bool IsNobilityKing() => DataManager.Instance.RoleAttr.NobilityTitle == (ushort) 1;

  public bool IsNobilityChief() => DataManager.Instance.RoleAttr.NobilityTitle == (ushort) 14;

  public bool IsFocusKing(ushort LeaderHomeKingdomID)
  {
    return (int) LeaderHomeKingdomID == (int) this.FocusKingdomID;
  }

  public bool IsFocusWorldWar()
  {
    return (this.FocusKingdomID <= (ushort) 0 || (int) this.OtherKingdomData.kingdomID == (int) this.FocusKingdomID ? (int) this.OtherKingdomData.kingdomID : (int) this.FocusKingdomID) == (int) ActivityManager.Instance.KOWKingdomID;
  }

  public bool IsPeaceState(bool bShowMsg = false, byte wonderID = 0)
  {
    if (((int) wonderID >= this.YolkPointTable.Length ? this.YolkPointTable[0] : this.YolkPointTable[(int) wonderID]).WonderState == (byte) 0)
      return true;
    if (bShowMsg)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9719U), (ushort) byte.MaxValue);
    return false;
  }

  public bool IsInMyKingdom(bool bShowMsg = false)
  {
    if (this.FocusKingdomID == (ushort) 0 || (int) this.kingdomData.kingdomID == (int) this.FocusKingdomID)
      return true;
    if (bShowMsg)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7744U), (ushort) byte.MaxValue);
    return false;
  }

  public bool IsInMyAllianceKingdom(bool bShowMsg = false)
  {
    if (this.FocusKingdomID == (ushort) 0 || (int) this.kingdomData.kingdomID == (int) this.FocusKingdomID)
      return true;
    if (bShowMsg)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7744U), (ushort) byte.MaxValue);
    return false;
  }

  public bool CheckKingFunction(eKingFunction func)
  {
    DataManager instance = DataManager.Instance;
    if (func != eKingFunction.eTitle && !this.IsPeaceState(true, (byte) 0))
      return false;
    if (!this.IsKing())
    {
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(1460U), (ushort) byte.MaxValue);
      return false;
    }
    if (func != eKingFunction.eTitle && this.FocusKingdomID != (ushort) 0 && (int) this.kingdomData.kingdomID != (int) this.FocusKingdomID)
    {
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(9720U), (ushort) byte.MaxValue);
      return false;
    }
    if (func == eKingFunction.eAmnesty && this.FocusKingdomID != (ushort) 0 && (int) this.kingdomData.kingdomID != (int) this.FocusKingdomID)
    {
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7744U), (ushort) byte.MaxValue);
      return false;
    }
    if (func != eKingFunction.eReward && func != eKingFunction.eStrengthen || this.FocusKingdomID == (ushort) 0 || (int) this.OtherKingdomData.kingdomID == (int) this.FocusKingdomID)
      return true;
    GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7744U), (ushort) byte.MaxValue);
    return false;
  }

  public bool CheckWorldKingFunction(eWorldKingFunction func)
  {
    if (func != eWorldKingFunction.ePersionalTitle && func != eWorldKingFunction.eWorldTitle && !this.IsPeaceState(true, (byte) 0))
      return false;
    if (!this.IsWorldKing())
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5791U), (ushort) byte.MaxValue);
      return false;
    }
    if (func != eWorldKingFunction.eReward || DataManager.Instance.RoleAlliance.Id != 0U)
      return true;
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(689U), (ushort) byte.MaxValue);
    return false;
  }

  public bool CheckNobilityFunction(eNobilityFunction func, byte wonderID)
  {
    if (func != eNobilityFunction.eTitle && !this.IsPeaceState(true, wonderID))
      return false;
    if (func != eNobilityFunction.eReward || DataManager.Instance.RoleAlliance.Id != 0U)
      return true;
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(689U), (ushort) byte.MaxValue);
    return false;
  }

  public ulong GetKingdomTime(ushort kingdomID)
  {
    if (!this.CheckKingdomOpen(kingdomID))
      return 0;
    if ((int) kingdomID == (int) this.kingdomData.kingdomID)
      return this.kingdomData.kingdomTime;
    if ((int) kingdomID == (int) this.OtherKingdomData.kingdomID)
      return this.OtherKingdomData.kingdomTime;
    KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(kingdomID);
    int num = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
    int index = (int) recordByKey.worldPosX - (int) this.WorldMinX + ((int) recordByKey.worldPosY - (int) this.WorldMinY) * num;
    byte tableId = this.TileMapKingdomID[index].tableID;
    if ((int) this.TileMapKingdomID[index].KingdomID == (int) kingdomID && (int) this.WorldKingdomTable[(int) tableId].kingdomID == (int) kingdomID)
      return this.WorldKingdomTable[(int) tableId].kingdomTime;
    return this.FocusKingdomTime != 0UL ? this.FocusKingdomTime : 0UL;
  }

  public bool GetWorldKingdomTableID(ushort kingdomID, out byte kingdomTableID)
  {
    kingdomTableID = (byte) 32;
    KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(kingdomID);
    int num = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
    int index = (int) recordByKey.worldPosX - (int) this.WorldMinX + ((int) recordByKey.worldPosY - (int) this.WorldMinY) * num;
    if (index < this.TileMapKingdomID.Length)
    {
      byte tableId = this.TileMapKingdomID[index].tableID;
      if ((int) this.TileMapKingdomID[index].KingdomID == (int) kingdomID && (int) tableId < this.WorldKingdomTable.Length && (int) this.WorldKingdomTable[(int) tableId].kingdomID == (int) kingdomID)
        kingdomTableID = tableId;
    }
    return kingdomTableID != (byte) 32;
  }

  public bool IsEnemy(ushort kingdomID)
  {
    byte kingdomTableID = 0;
    KINGDOM_PERIOD kingdomPeriod;
    if ((int) kingdomID == (int) this.OtherKingdomData.kingdomID)
      kingdomPeriod = this.OtherKingdomData.kingdomPeriod;
    else if ((int) this.FocusKingdomID == (int) kingdomID)
      kingdomPeriod = this.FocusKingdomPeriod;
    else if (this.GetWorldKingdomTableID(kingdomID, out kingdomTableID))
    {
      kingdomPeriod = this.WorldKingdomTable[(int) kingdomTableID].kingdomPeriod;
    }
    else
    {
      if (this.FocusKingdomPeriod != KINGDOM_PERIOD.KP_KVK || (int) kingdomID == (int) this.kingdomData.kingdomID)
        return false;
      return !ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.CheckIsMatchKingdom(kingdomID);
    }
    if (kingdomPeriod != KINGDOM_PERIOD.KP_KVK || (int) kingdomID == (int) this.kingdomData.kingdomID)
      return false;
    return !ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.CheckIsMatchKingdom(kingdomID);
  }

  public void UpdateKingdomPeriod(KINGDOM_PERIOD in_Period = KINGDOM_PERIOD.KP_KVK)
  {
    byte kingdomtableid = (byte) ((uint) (byte) ((uint) this.WorldKingdomTableIDcounter - 1U) & 31U);
    switch (in_Period)
    {
      case KINGDOM_PERIOD.KP_INFIGHTING:
        for (byte index = 0; (int) index < this.WorldKingdomTable.Length; ++index)
        {
          if (this.WorldKingdomTable[(int) kingdomtableid].kingdomID != (ushort) 0)
          {
            KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(this.WorldKingdomTable[(int) kingdomtableid].kingdomID);
            int num = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
            if ((int) this.TileMapKingdomID[(int) recordByKey.worldPosX - (int) this.WorldMinX + ((int) recordByKey.worldPosY - (int) this.WorldMinY) * num].tableID == (int) kingdomtableid && this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR && this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod != in_Period)
            {
              this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod = in_Period;
              this.KingdomNotifyObserver(kingdomtableid, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD);
            }
          }
          kingdomtableid = (byte) ((uint) (byte) ((uint) kingdomtableid - 1U) & 31U);
        }
        break;
      case KINGDOM_PERIOD.KP_KVK:
        for (byte index = 0; (int) index < this.WorldKingdomTable.Length; ++index)
        {
          if (this.WorldKingdomTable[(int) kingdomtableid].kingdomID != (ushort) 0)
          {
            KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(this.WorldKingdomTable[(int) kingdomtableid].kingdomID);
            int num = (int) this.WorldMaxX - (int) this.WorldMinX + 1;
            if ((int) this.TileMapKingdomID[(int) recordByKey.worldPosX - (int) this.WorldMinX + ((int) recordByKey.worldPosY - (int) this.WorldMinY) * num].tableID == (int) kingdomtableid && this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR && (long) this.WorldKingdomTable[(int) kingdomtableid].kingdomTime + 7776000L <= DataManager.Instance.ServerTime && this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod != in_Period)
            {
              this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod = in_Period;
              this.KingdomNotifyObserver(kingdomtableid, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD);
            }
          }
          kingdomtableid = (byte) ((uint) (byte) ((uint) kingdomtableid - 1U) & 31U);
        }
        break;
    }
  }

  public void KingdomNotifyObserver(byte kingdomtableid, MAP_UPDATE_KIND updatekind)
  {
    if ((int) this.WorldKingdomTable[(int) kingdomtableid].kingdomID == (int) this.kingdomData.kingdomID)
    {
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID)
      {
        this.kingdomData.allianceKingdomID = this.WorldKingdomTable[(int) kingdomtableid].allianceKingdomID;
        this.kingdomData.kingKingdomID = this.WorldKingdomTable[(int) kingdomtableid].kingKingdomID;
      }
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME)
        this.kingdomData.kingdomTime = this.WorldKingdomTable[(int) kingdomtableid].kingdomTime;
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG)
        this.kingdomData.kingdomFlag = this.WorldKingdomTable[(int) kingdomtableid].kingdomFlag;
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD)
        this.kingdomData.kingdomPeriod = this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod;
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE)
      {
        this.kingdomData.kingName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].kingdomName.Length; ++index)
          this.kingdomData.kingName.Append(this.WorldKingdomTable[(int) kingdomtableid].kingdomName[index]);
        this.kingdomData.allianceTag.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceTag.Length; ++index)
          this.kingdomData.allianceTag.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceTag[index]);
        this.kingdomData.allianceName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceName.Length; ++index)
          this.kingdomData.allianceName.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceName[index]);
      }
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM)
      {
        this.kingdomData.kingdomFlag = this.WorldKingdomTable[(int) kingdomtableid].kingdomFlag;
        this.kingdomData.kingdomPeriod = this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod;
        this.kingdomData.kingName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].kingdomName.Length; ++index)
          this.kingdomData.kingName.Append(this.WorldKingdomTable[(int) kingdomtableid].kingdomName[index]);
        this.kingdomData.allianceTag.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceTag.Length; ++index)
          this.kingdomData.allianceTag.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceTag[index]);
        this.kingdomData.allianceName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceName.Length; ++index)
          this.kingdomData.allianceName.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceName[index]);
      }
    }
    else if (this.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_NONE && (int) this.OtherKingdomData.kingdomID == (int) this.WorldKingdomTable[(int) kingdomtableid].kingdomID)
    {
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID)
      {
        this.OtherKingdomData.allianceKingdomID = this.WorldKingdomTable[(int) kingdomtableid].allianceKingdomID;
        this.OtherKingdomData.kingKingdomID = this.WorldKingdomTable[(int) kingdomtableid].kingKingdomID;
      }
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME)
        this.OtherKingdomData.kingdomTime = this.WorldKingdomTable[(int) kingdomtableid].kingdomTime;
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG)
        this.OtherKingdomData.kingdomFlag = this.WorldKingdomTable[(int) kingdomtableid].kingdomFlag;
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD)
        this.OtherKingdomData.kingdomPeriod = this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod;
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE)
      {
        this.OtherKingdomData.kingName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].kingdomName.Length; ++index)
          this.OtherKingdomData.kingName.Append(this.WorldKingdomTable[(int) kingdomtableid].kingdomName[index]);
        this.OtherKingdomData.allianceTag.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceTag.Length; ++index)
          this.OtherKingdomData.allianceTag.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceTag[index]);
        this.OtherKingdomData.allianceName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceName.Length; ++index)
          this.OtherKingdomData.allianceName.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceName[index]);
      }
      if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM)
      {
        this.OtherKingdomData.kingdomFlag = this.WorldKingdomTable[(int) kingdomtableid].kingdomFlag;
        this.OtherKingdomData.kingdomPeriod = this.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod;
        this.OtherKingdomData.kingName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].kingdomName.Length; ++index)
          this.OtherKingdomData.kingName.Append(this.WorldKingdomTable[(int) kingdomtableid].kingdomName[index]);
        this.OtherKingdomData.allianceTag.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceTag.Length; ++index)
          this.OtherKingdomData.allianceTag.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceTag[index]);
        this.OtherKingdomData.allianceName.ClearString();
        for (int index = 0; index < this.WorldKingdomTable[(int) kingdomtableid].allianceName.Length; ++index)
          this.OtherKingdomData.allianceName.Append(this.WorldKingdomTable[(int) kingdomtableid].allianceName[index]);
      }
    }
    DataManager.msgBuffer[0] = (byte) 105;
    GameConstants.GetBytes((ushort) kingdomtableid, DataManager.msgBuffer, 1);
    GameConstants.GetBytes((ushort) updatekind, DataManager.msgBuffer, 2);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public bool ShowDamageRange(ushort zoneID, byte pointID, ushort damageRangeID = 1)
  {
    DataManager.msgBuffer[0] = (byte) 98;
    GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
    DataManager.msgBuffer[3] = pointID;
    GameConstants.GetBytes(damageRangeID, DataManager.msgBuffer, 4);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public bool HideDamageRange()
  {
    DataManager.msgBuffer[0] = (byte) 99;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public bool UseMapWeapon(ushort MapWeaponID, ushort MapSkillID)
  {
    DataManager.msgBuffer[0] = (byte) 100;
    GameConstants.GetBytes(MapWeaponID, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(MapSkillID, DataManager.msgBuffer, 3);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public bool StopMapWeapon()
  {
    DataManager.msgBuffer[0] = (byte) 101;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public void SendUseMapWeapon() => UIPetSkill.onFinish();

  public bool MapWeaponAttack(ushort zoneID, byte pointID, ushort effectID, float effectTime)
  {
    DataManager.msgBuffer[0] = (byte) 102;
    GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
    GameConstants.GetBytes((ushort) pointID, DataManager.msgBuffer, 3);
    GameConstants.GetBytes(effectID, DataManager.msgBuffer, 4);
    GameConstants.GetBytes(effectTime, DataManager.msgBuffer, 6);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public bool MapWeaponDefense(ushort zoneID, byte pointID, ushort effectID, float effectTime)
  {
    DataManager.msgBuffer[0] = (byte) 103;
    GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
    GameConstants.GetBytes((ushort) pointID, DataManager.msgBuffer, 3);
    GameConstants.GetBytes(effectID, DataManager.msgBuffer, 4);
    GameConstants.GetBytes(effectTime, DataManager.msgBuffer, 6);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public byte StateKindCount => this.mapStateKindCount;

  public byte getStateKind(byte index)
  {
    return (int) index >= (int) this.mapStateKindCount ? (byte) 0 : this.stateKinds[(int) index];
  }

  public byte getStateIndexByKind(byte kind)
  {
    for (byte stateIndexByKind = 0; (int) stateIndexByKind < (int) this.mapStateKindCount; ++stateIndexByKind)
    {
      if ((int) this.stateKinds[(int) stateIndexByKind] == (int) kind)
        return stateIndexByKind;
    }
    return byte.MaxValue;
  }

  public byte getStateCountByIndex(byte index)
  {
    return (int) index >= (int) this.mapStateKindCount ? (byte) 0 : this.stateCounts[(int) index];
  }

  public byte getStateCountByKind(byte kind)
  {
    return this.getStateCountByIndex(this.getStateIndexByKind(kind));
  }

  public ushort getStateSkillIDByIndex(byte kind, byte index)
  {
    byte stateCountByKind = this.getStateCountByKind(kind);
    byte stateIndexByKind = this.getStateIndexByKind(kind);
    if (stateCountByKind < (byte) 1 || (int) index >= (int) stateCountByKind || stateIndexByKind >= byte.MaxValue || this.stateSkillIDs[(int) stateIndexByKind] == null)
      return 0;
    byte index1 = (byte) ((uint) index / 16U);
    if (this.stateSkillIDs[(int) stateIndexByKind][(int) index1] == null)
      return 0;
    byte index2 = (byte) ((uint) index % 16U);
    return this.stateSkillIDs[(int) stateIndexByKind][(int) index1][(int) index2];
  }

  public byte getStateSkillLevelByIndex(byte kind, byte index)
  {
    byte stateCountByKind = this.getStateCountByKind(kind);
    byte stateIndexByKind = this.getStateIndexByKind(kind);
    if (stateCountByKind < (byte) 1 || (int) index >= (int) stateCountByKind || stateIndexByKind >= byte.MaxValue || this.stateSkillIDs[(int) stateIndexByKind] == null)
      return 0;
    byte index1 = (byte) ((uint) index / 16U);
    if (this.stateSkillLevels[(int) stateIndexByKind][(int) index1] == null)
      return 0;
    byte index2 = (byte) ((uint) index % 16U);
    return this.stateSkillLevels[(int) stateIndexByKind][(int) index1][(int) index2];
  }

  public void RESP_PETSKILL_STATE(MessagePacket MP)
  {
    if ((int) this.stateMapID != GameConstants.PointCodeToMapID(MP.ReadUShort(), MP.ReadByte()))
      return;
    byte num = MP.ReadByte();
    int mapStateKindCount = (int) this.mapStateKindCount;
    this.mapStateKindCount += MP.ReadByte();
    if (num != (byte) 0 && num != (byte) 1)
      return;
    for (; mapStateKindCount < (int) this.mapStateKindCount; ++mapStateKindCount)
    {
      if (this.stateSkillIDs[mapStateKindCount] == null)
        this.stateSkillIDs[mapStateKindCount] = new ushort[16][];
      if (this.stateSkillLevels[mapStateKindCount] == null)
        this.stateSkillLevels[mapStateKindCount] = new byte[16][];
      this.stateKinds[mapStateKindCount] = MP.ReadByte();
      this.stateCounts[mapStateKindCount] = MP.ReadByte();
      for (int index1 = 0; index1 < (int) this.stateCounts[mapStateKindCount]; ++index1)
      {
        byte index2 = (byte) (index1 / 16);
        if (this.stateSkillIDs[mapStateKindCount][(int) index2] == null)
          this.stateSkillIDs[mapStateKindCount][(int) index2] = new ushort[16];
        if (this.stateSkillLevels[mapStateKindCount][(int) index2] == null)
          this.stateSkillLevels[mapStateKindCount][(int) index2] = new byte[16];
        byte index3 = (byte) (index1 % 16);
        this.stateSkillIDs[mapStateKindCount][(int) index2][(int) index3] = MP.ReadUShort();
        this.stateSkillLevels[mapStateKindCount][(int) index2][(int) index3] = MP.ReadByte();
      }
    }
    if (num != (byte) 0)
      return;
    DataManager.msgBuffer[0] = (byte) 80;
    GameConstants.GetBytes(this.stateMapID, DataManager.msgBuffer, 1);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  private void freeZonePoint(ushort freeZoneID)
  {
    for (int pointID = 0; pointID < 256; ++pointID)
    {
      int mapId = GameConstants.PointCodeToMapID(freeZoneID, (byte) pointID);
      ushort tableId = this.LayoutMapInfo[mapId].tableID;
      POINT_KIND mapInfoPointKind = this.GetLayoutMapInfoPointKind((uint) mapId);
      if (mapInfoPointKind > POINT_KIND.PK_NONE)
      {
        if (mapInfoPointKind < POINT_KIND.PK_CITY)
          this.ResourcesPointTableIDpool.despawn((int) tableId);
        else if (mapInfoPointKind < POINT_KIND.PK_NPC)
          this.PlayerPointTableIDpool.despawn((int) tableId);
        else if (mapInfoPointKind == POINT_KIND.PK_NPC)
          this.NPCPointTableIDpool.despawn((int) tableId);
        if (mapInfoPointKind != POINT_KIND.PK_YOLK)
          this.LayoutMapInfo[mapId].pointKind = (byte) 0;
      }
    }
  }

  private void checkZoneLine(byte nowZoneIDNum, ushort[] nowZoneID)
  {
    Vector2 zero = Vector2.zero;
    double num1 = Math.Round(640000000000.0);
    byte index1 = 0;
    byte index2 = 0;
    for (byte index3 = 0; (int) index3 < (int) nowZoneIDNum; ++index3)
    {
      if (this.ZoneUpdateInfo[(int) nowZoneID[(int) index3]].updateNum == 0UL)
      {
        if (this.LastZoneID[0] != (ushort) 16384)
        {
          Vector2 mapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(nowZoneID[(int) index3], (byte) 0);
          mapPosbyPointCode.x *= 2f;
          for (byte index4 = 0; (int) index4 < (int) this.LastZoneIDNum; ++index4)
          {
            if (this.ZoneUpdateInfo[(int) this.LastZoneID[(int) index4]].updateNum != 0UL)
            {
              List<ZoneLine> zoneLineList = this.ZoneLineIDTable[(int) this.ZoneUpdateInfo[(int) this.LastZoneID[(int) index4]].zoneState];
              for (int index5 = zoneLineList.Count - 1; index5 > -1; --index5)
              {
                int lineTableId = (int) zoneLineList[index5].lineTableID;
                bool flag = (int) this.MapLineTable[lineTableId].start.zoneID == (int) nowZoneID[(int) index3] || (int) this.MapLineTable[lineTableId].end.zoneID == (int) nowZoneID[(int) index3];
                if (!flag && lineTableId < this.MapLineTable.Count && (int) zoneLineList[index5].lineID == (int) this.MapLineTable[lineTableId].lineID && (int) this.MapLineTable[lineTableId].start.zoneID != (int) this.MapLineTable[lineTableId].end.zoneID && (double) this.MapLineTable[lineTableId].zoneMax.x > (double) mapPosbyPointCode.x && (double) this.MapLineTable[lineTableId].zoneMin.x <= (double) mapPosbyPointCode.x && (double) this.MapLineTable[lineTableId].zoneMax.y > (double) mapPosbyPointCode.y && (double) this.MapLineTable[lineTableId].zoneMin.y <= (double) mapPosbyPointCode.y)
                {
                  if (this.MapLineTable[lineTableId].XIntercept < 0.0)
                  {
                    if (this.MapLineTable[lineTableId].Slope == 0.0)
                    {
                      flag = this.MapLineTable[lineTableId].YIntercept >= (double) mapPosbyPointCode.y && this.MapLineTable[lineTableId].YIntercept < (double) mapPosbyPointCode.y + 16.0;
                    }
                    else
                    {
                      double num2 = Math.Round((this.MapLineTable[lineTableId].Slope * (double) mapPosbyPointCode.x + this.MapLineTable[lineTableId].YIntercept) * 10000000000.0);
                      double num3 = Math.Round((this.MapLineTable[lineTableId].Slope * ((double) mapPosbyPointCode.x + 64.0) + this.MapLineTable[lineTableId].YIntercept) * 10000000000.0);
                      double num4 = Math.Round(((double) mapPosbyPointCode.y - this.MapLineTable[lineTableId].YIntercept) / this.MapLineTable[lineTableId].Slope * 10000000000.0);
                      double num5 = Math.Round(((double) mapPosbyPointCode.y + 16.0 - this.MapLineTable[lineTableId].YIntercept) / this.MapLineTable[lineTableId].Slope * 10000000000.0);
                      double num6 = Math.Round((double) mapPosbyPointCode.y * 10000000000.0);
                      double num7 = Math.Round((double) mapPosbyPointCode.x * 10000000000.0);
                      double num8 = Math.Round(160000000000.0);
                      flag = num2 >= num6 && num2 < num6 + num8 || num3 > num6 && num3 < num6 + num8 || num4 >= num7 && num4 < num7 + num1 || num5 > num7 && num5 < num7 + num1 || num3 == num6 && num3 + num8 == num2 && num5 == num7 && num5 + num1 == num4;
                    }
                  }
                  else
                    flag = this.MapLineTable[lineTableId].XIntercept >= (double) mapPosbyPointCode.x && this.MapLineTable[lineTableId].XIntercept < (double) mapPosbyPointCode.x + 64.0;
                }
                if (flag)
                {
                  ZoneLine zoneLine = zoneLineList[index5];
                  for (int index6 = 0; index6 < this.TempLineIDTable[(int) index1].Count; ++index6)
                  {
                    if ((int) this.TempLineIDTable[(int) index1][index6].lineTableID == (int) zoneLine.lineTableID)
                    {
                      flag = false;
                      break;
                    }
                  }
                  if (flag)
                  {
                    byte index7 = this.sortRAMReplaceNum[(int) index2];
                    if ((int) index7 >= this.MapLineTable[lineTableId].ZoneIDTable.Length || this.MapLineTable[lineTableId].ZoneIDTable[(int) index7] == 1048576)
                      ++this.MapLineTable[lineTableId].zoneNum;
                    else if (this.ZoneLineIDTable[(int) index7].Count > this.MapLineTable[lineTableId].ZoneIDTable[(int) index7])
                    {
                      for (int index8 = this.ZoneLineIDTable[(int) index7].Count - 1; index8 > this.MapLineTable[lineTableId].ZoneIDTable[(int) index7]; --index8)
                        --this.MapLineTable[(int) this.ZoneLineIDTable[(int) index7][index8].lineTableID].ZoneIDTable[(int) index7];
                      this.ZoneLineIDTable[(int) index7].RemoveAt(this.MapLineTable[lineTableId].ZoneIDTable[(int) index7]);
                    }
                    else
                      continue;
                    this.MapLineTable[lineTableId].ZoneIDTable[(int) index7] = this.TempLineIDTable[(int) index1].Count;
                    this.TempLineIDTable[(int) index1].Add(zoneLine);
                  }
                }
              }
            }
          }
        }
        ushort[] tempZoneStateId = this.TempZoneStateID;
        int index9 = (int) index1;
        byte[] sortRamReplaceNum = this.sortRAMReplaceNum;
        int index10 = index2++;
        int num9;
        byte index11 = (byte) (num9 = (int) sortRamReplaceNum[index10]);
        tempZoneStateId[index9] = (ushort) num9;
        List<ZoneLine> zoneLineList1 = this.ZoneLineIDTable[(int) index11];
        this.ZoneLineIDTable[(int) index11] = this.TempLineIDTable[(int) index1];
        this.TempLineIDTable[(int) index1++] = zoneLineList1;
      }
    }
    for (int index12 = 0; index12 < (int) index1; ++index12)
    {
      for (int index13 = this.TempLineIDTable[index12].Count - 1; index13 > -1; --index13)
      {
        int lineTableId = (int) this.TempLineIDTable[index12][index13].lineTableID;
        if ((int) this.TempLineIDTable[index12][index13].lineID == (int) this.MapLineTable[lineTableId].lineID)
        {
          this.MapLineTable[lineTableId].ZoneIDTable[(int) this.TempZoneStateID[index12]] = 1048576;
          this.LineDelZone(lineTableId, byte.MaxValue);
        }
      }
      this.TempLineIDTable[index12].Clear();
    }
  }

  private void finishMapLoading()
  {
    if ((int) this.checkZone != (1 << (int) this.zoneIDNum) - 1)
      return;
    ++this.checkZone;
    this.wait = 0.0f;
    if (this.waitZoneIDNum > (byte) 0)
    {
      if (this.waitZoneIDNum < (byte) 4)
        this.setLastZoneInfo(this.waitZoneIDNum, this.waitZoneID, false);
      this.waitZoneIDNum = (byte) 0;
    }
    else
    {
      DataManager.msgBuffer[0] = (byte) 69;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      this.wait = 0.0f;
    }
  }

  private void LineDelZone(int mapLineTableID, byte Send = 1)
  {
    --this.MapLineTable[mapLineTableID].zoneNum;
    if (this.MapLineTable[mapLineTableID].zoneNum != (ushort) 0)
      return;
    this.LineNotifyObserver((byte) 55, mapLineTableID, Send);
    this.MapLineTableIDpool.despawn(mapLineTableID);
    this.MapLineTable[mapLineTableID].MapLineInit();
  }

  private int getLineTableID(ushort zoneID, uint lineID)
  {
    if (this.ZoneUpdateInfo[(int) zoneID].updateNum != 0UL)
    {
      int zoneState = (int) this.ZoneUpdateInfo[(int) zoneID].zoneState;
      for (int index = 0; index < this.ZoneLineIDTable[zoneState].Count; ++index)
      {
        if ((int) this.ZoneLineIDTable[zoneState][index].lineID == (int) lineID)
          return (int) this.ZoneLineIDTable[zoneState][index].lineTableID;
      }
    }
    return 1048576;
  }

  private int getLineTableID(uint lineID)
  {
    for (int index = 0; index < this.MapLineTable.Count; ++index)
    {
      if ((int) this.MapLineTable[index].lineID == (int) lineID)
        return index;
    }
    return 1048576;
  }

  private MapManager.MAP_ZONE_STATE CheckZoneID(ushort ZoneID, bool bClear = false)
  {
    if (ZoneID >= (ushort) 1024)
      return MapManager.MAP_ZONE_STATE.MAPZONESTATE_RAM;
    if ((int) this.checkZone >> (int) this.zoneIDNum == 1)
    {
      if (this.UpdateZoneIDNum != (byte) 0)
      {
        for (int index = 0; index < (int) this.UpdateZoneIDNum; ++index)
          this.ZoneNotifyObserver(this.UpdateZoneID[index]);
        this.UpdateZoneIDNum = (byte) 0;
      }
      return MapManager.MAP_ZONE_STATE.MAPZONESTATE_NONE;
    }
    for (byte index1 = 0; (int) index1 < (int) this.zoneIDNum; ++index1)
    {
      if (((int) this.checkZone & 1 << (int) index1) == 0 && (int) this.zoneID[(int) index1] == (int) ZoneID)
      {
        this.checkZone |= (byte) (1U << (int) index1);
        if (this.ZoneUpdateInfo[(int) ZoneID].updateNum == 0UL)
        {
          this.moveRAMtoROM(ZoneID);
          this.finishMapLoading();
          return MapManager.MAP_ZONE_STATE.MAPZONESTATE_NONE;
        }
        if (this.ZoneUpdateInfo[(int) ZoneID].zoneState < (byte) 8)
        {
          byte zoneState = this.ZoneUpdateInfo[(int) ZoneID].zoneState;
          this.RAMSataeInfo[(int) zoneState].replaceNum = this.RAMSataeInfo[(int) this.sortRAMReplaceNum[7]].replaceNum + 1U;
          this.sortMaxRAM(zoneState);
          if (bClear)
            this.freeZonePoint(ZoneID);
          this.finishMapLoading();
          if (this.LastZoneID[0] == (ushort) 16384)
          {
            this.ZoneNotifyObserver(ZoneID);
          }
          else
          {
            byte index2 = 0;
            while ((int) index2 < (int) this.LastZoneIDNum && (int) this.LastZoneID[(int) index2] != (int) ZoneID)
              ++index2;
            if ((int) index2 == (int) this.LastZoneIDNum)
              this.CheckZoneLine(ZoneID);
          }
          return MapManager.MAP_ZONE_STATE.MAPZONESTATE_RAM;
        }
        this.switchRAMtoROM((byte) ((uint) this.ZoneUpdateInfo[(int) ZoneID].zoneState - 120U), bClear);
        this.RequsetLineInZone(ZoneID);
        this.finishMapLoading();
        return MapManager.MAP_ZONE_STATE.MAPZONESTATE_ROM;
      }
    }
    return MapManager.MAP_ZONE_STATE.MAPZONESTATE_RAM;
  }

  private void LineNotifyObserver(byte news, int maplinetableID, byte Send = 1)
  {
    DataManager.msgBuffer[0] = news;
    GameConstants.GetBytes((uint) maplinetableID, DataManager.msgBuffer, 1);
    DataManager.msgBuffer[5] = Send;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  private void CheckZoneLine(ushort zoneID)
  {
    if (zoneID >= (ushort) 1024)
      return;
    List<ZoneLine> zoneLineList = this.ZoneLineIDTable[(int) this.ZoneUpdateInfo[(int) zoneID].zoneState];
    for (int index = zoneLineList.Count - 1; index > -1; --index)
    {
      int lineTableId = (int) zoneLineList[index].lineTableID;
      if ((UnityEngine.Object) this.MapLineTable[lineTableId].lineObject == (UnityEngine.Object) null)
        this.LineNotifyObserver((byte) 56, lineTableId, (byte) 1);
    }
  }

  private void ZoneNotifyObserver(ushort zoneID)
  {
    this.CheckZoneLine(zoneID);
    DataManager.msgBuffer[0] = (byte) 52;
    GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  private void PointNotifyObserver(uint mapID)
  {
    DataManager.msgBuffer[0] = (byte) 54;
    GameConstants.GetBytes(mapID, DataManager.msgBuffer, 1);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  private void pushReqKingdomID(byte in_reqKingdomTableID, ushort in_reqKingdomID)
  {
    this.reqKingdomID[(int) in_reqKingdomTableID] = in_reqKingdomID;
    for (; in_reqKingdomTableID > (byte) 0 && (int) this.reqKingdomID[(int) in_reqKingdomTableID] < (int) this.reqKingdomID[(int) in_reqKingdomTableID - 1]; this.reqKingdomID[(int) --in_reqKingdomTableID] = in_reqKingdomID)
    {
      in_reqKingdomID = this.reqKingdomID[(int) in_reqKingdomTableID];
      this.reqKingdomID[(int) in_reqKingdomTableID] = this.reqKingdomID[(int) in_reqKingdomTableID - 1];
    }
  }

  private void GetKingdomOpenIndexShift(ushort kingdomID, out ushort index, out byte bitShift)
  {
    --kingdomID;
    index = (ushort) ((uint) kingdomID >> 3);
    bitShift = (byte) ((uint) kingdomID & 7U);
  }

  private enum MAP_ZONE_STATE : byte
  {
    MAPZONESTATE_NONE,
    MAPZONESTATE_RAM,
    MAPZONESTATE_ROM,
    MAPZONESTATE_MAX,
  }
}
