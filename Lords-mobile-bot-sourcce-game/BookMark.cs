// Decompiled with JetBrains decompiler
// Type: BookMark
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Text;
using UnityEngine;

#nullable disable
public class BookMark
{
  public const ushort DefaultDataMax = 100;
  public const byte DefaultAllianceDataMax = 20;
  private byte NameSize = 50;
  public long UpdateTime;
  public long UpdateTimeAlliance;
  public BookMarkData[] AllData;
  public BookMarkData[] AllAllianceData;
  public ushort RecvDataCount;
  private CString MessageStr;
  public byte[][] KindDataIDIndex = new byte[4][];
  public byte[] KindDataCount = new byte[3];
  private ushort OverWriteID;
  private byte OverWriteType;
  private string OverWriteName;
  public byte AllianceBookCount;
  public byte[] AllianceIDIndex;
  public byte[] SelectBookMarkIndex = new byte[10];
  public byte SelectCount;

  public BookMark()
  {
    this.AllAllianceData = new BookMarkData[20];
    this.AllianceIDIndex = new byte[20];
    for (byte index = 0; index < (byte) 20; ++index)
      this.AllAllianceData[(int) index] = new BookMarkData((ushort) this.NameSize);
  }

  public void Initial() => this.RecvDataCount = (ushort) 0;

  public byte GetNameSize() => this.NameSize;

  public int GetMapID(ushort ID, BookMark.eBookType bookType = BookMark.eBookType.Role)
  {
    if (ID == (ushort) 0)
      return 0;
    BookMarkData[] bookMarkDataArray = bookType != BookMark.eBookType.Role ? this.AllAllianceData : this.AllData;
    if (bookMarkDataArray[(int) --ID].MapID == 0)
      bookMarkDataArray[(int) ID].MapID = GameConstants.PointCodeToMapID(bookMarkDataArray[(int) ID].KingdomPoint.zoneID, bookMarkDataArray[(int) ID].KingdomPoint.pointID);
    return bookMarkDataArray[(int) ID].MapID;
  }

  public ushort GetKingdomID(ushort ID, BookMark.eBookType bookType = BookMark.eBookType.Role)
  {
    if (ID == (ushort) 0)
      return 0;
    return bookType == BookMark.eBookType.Role ? this.AllData[(int) --ID].KingdomID : this.AllAllianceData[(int) --ID].KingdomID;
  }

  private ushort GetBookMarkID(int MapID, ushort KingdomID, BookMark.eBookType bookType = BookMark.eBookType.Role)
  {
    ushort num;
    byte[] allianceIdIndex;
    BookMarkData[] bookMarkDataArray;
    if (bookType == BookMark.eBookType.Role)
    {
      num = DataManager.Instance.RoleAttr.BookmarkNum;
      allianceIdIndex = this.KindDataIDIndex[3];
      bookMarkDataArray = this.AllData;
    }
    else
    {
      num = (ushort) this.AllianceBookCount;
      allianceIdIndex = this.AllianceIDIndex;
      bookMarkDataArray = this.AllAllianceData;
    }
    for (ushort index = 0; (int) index < (int) num; ++index)
    {
      ushort id = bookMarkDataArray[(int) allianceIdIndex[(int) index]].ID;
      if ((int) bookMarkDataArray[(int) allianceIdIndex[(int) index]].KingdomID == (int) KingdomID && this.GetMapID(id, bookType) == MapID)
        return id;
    }
    return 0;
  }

  public void CheckUpdate(bool LockInput = true)
  {
    if (this.UpdateTime != 0L && DataManager.Instance.RoleAttr.BookmarkTime == this.UpdateTime || this.RecvDataCount != (ushort) 0)
      return;
    this.sendBookMarkInfo(LockInput);
  }

  public void CheckUpdate_Alliance(bool LockInput = true)
  {
    if (DataManager.Instance.RoleAlliance.BookmarkTime == 0L || this.UpdateTimeAlliance != 0L && DataManager.Instance.RoleAlliance.BookmarkTime == this.UpdateTimeAlliance)
      return;
    this.sendBookMarkInfo_Alliance(LockInput);
  }

  public void CheckModify()
  {
    this.sendModifyBookMark(this.OverWriteID, this.OverWriteType, this.OverWriteName);
  }

  private void AddDataIndex(ushort id)
  {
    if (this.KindDataIDIndex[(int) this.AllData[(int) id].Type].Length <= (int) this.KindDataCount[(int) this.AllData[(int) id].Type])
      return;
    this.KindDataIDIndex[(int) this.AllData[(int) id].Type][(int) this.KindDataCount[(int) this.AllData[(int) id].Type]++] = (byte) id;
  }

  private void InsertDataIndex(ushort id)
  {
    if (this.KindDataIDIndex[(int) this.AllData[(int) id].Type].Length <= (int) this.KindDataCount[(int) this.AllData[(int) id].Type])
      return;
    ushort type = (ushort) this.AllData[(int) id].Type;
    bool flag = false;
    for (int sourceIndex = 0; sourceIndex < (int) this.KindDataCount[(int) type]; ++sourceIndex)
    {
      if ((int) this.KindDataIDIndex[(int) type][sourceIndex] > (int) id)
      {
        int length = (int) this.KindDataCount[(int) type] - sourceIndex;
        if (length > 0 && sourceIndex + 1 + length <= 100)
          Array.Copy((Array) this.KindDataIDIndex[(int) type], sourceIndex, (Array) this.KindDataIDIndex[(int) type], sourceIndex + 1, length);
        this.KindDataIDIndex[(int) type][sourceIndex] = (byte) id;
        ++this.KindDataCount[(int) type];
        flag = true;
        break;
      }
    }
    if (flag)
      return;
    this.AddDataIndex(id);
  }

  private void InsertDataIndex_Alliance(ushort id)
  {
    if (this.AllianceIDIndex.Length <= (int) this.AllianceBookCount)
      return;
    bool flag = false;
    for (int sourceIndex = 0; sourceIndex < (int) this.AllianceBookCount; ++sourceIndex)
    {
      if ((int) this.AllianceIDIndex[sourceIndex] > (int) id)
      {
        flag = true;
        int length = (int) this.AllianceBookCount - sourceIndex;
        if (length > 0 && sourceIndex + 1 + length <= 20)
          Array.Copy((Array) this.AllianceIDIndex, sourceIndex, (Array) this.AllianceIDIndex, sourceIndex + 1, length);
        this.AllianceIDIndex[sourceIndex] = (byte) id;
        break;
      }
    }
    if (!flag)
      this.AllianceIDIndex[(int) this.AllianceBookCount] = (byte) id;
    ++this.AllianceBookCount;
  }

  private void RemoveDataIndex(ushort index, BookMark.eBookType bookType = BookMark.eBookType.Role)
  {
    byte allianceBookCount;
    byte[] allianceIdIndex;
    if (bookType == BookMark.eBookType.Role)
    {
      BookMarkData[] allData = this.AllData;
      allianceBookCount = this.KindDataCount[(int) allData[(int) index].Type];
      allianceIdIndex = this.KindDataIDIndex[(int) allData[(int) index].Type];
    }
    else
    {
      BookMarkData[] allAllianceData = this.AllAllianceData;
      allianceBookCount = this.AllianceBookCount;
      allianceIdIndex = this.AllianceIDIndex;
    }
    bool flag = false;
    for (int destinationIndex = 0; destinationIndex < (int) allianceBookCount; ++destinationIndex)
    {
      if ((int) allianceIdIndex[destinationIndex] == (int) index)
      {
        flag = true;
        int length = (int) allianceBookCount - (destinationIndex + 1);
        if (length > 0)
        {
          Array.Copy((Array) allianceIdIndex, destinationIndex + 1, (Array) allianceIdIndex, destinationIndex, length);
          break;
        }
        break;
      }
    }
    if (!flag || allianceBookCount <= (byte) 0)
      return;
    if (bookType == BookMark.eBookType.Role)
      --this.KindDataCount[(int) this.AllData[(int) index].Type];
    else
      --this.AllianceBookCount;
  }

  public void RecvBookMarkInfo(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    this.RecvDataCount = MP.ReadUShort();
    ushort num = MP.ReadUShort();
    this.UpdateTime = MP.ReadLong();
    instance.RoleAttr.BookmarkNum = this.RecvDataCount;
    if (this.AllData == null)
    {
      this.AllData = new BookMarkData[100];
      for (int index = 0; index < this.KindDataIDIndex.Length; ++index)
        this.KindDataIDIndex[index] = new byte[100];
      for (byte index = 0; index < (byte) 100; ++index)
        this.AllData[(int) index] = new BookMarkData((ushort) this.NameSize);
      this.MessageStr = new CString(200);
    }
    else
    {
      for (byte index = 0; (int) index < (int) num && this.AllData.Length > (int) index; ++index)
        this.AllData[(int) index].Clear();
      for (int index = 0; index < this.KindDataIDIndex.Length; ++index)
        Array.Clear((Array) this.KindDataIDIndex[index], 0, this.KindDataIDIndex[index].Length);
      Array.Clear((Array) this.KindDataCount, 0, this.KindDataCount.Length);
    }
    instance.RoleAttr.BookmarkLimit = num;
    instance.RoleAttr.BookmarkTime = this.UpdateTime;
    if (instance.RoleAttr.BookmarkNum != (ushort) 0)
      return;
    GUIManager.Instance.HideUILock(EUILock.BookMark);
  }

  public void RecvBookMarkList(MessagePacket MP)
  {
    ushort num1 = MP.ReadUShort();
    this.NameSize = MP.ReadByte();
    if ((int) this.RecvDataCount > (int) num1)
      this.RecvDataCount -= num1;
    else
      this.RecvDataCount = (ushort) 0;
    for (ushort index = 0; (int) index < (int) num1; ++index)
    {
      ushort num2 = (ushort) Mathf.Clamp((int) MP.ReadUShort(), 1, this.AllData.Length);
      ref BookMarkData local = ref this.AllData[(int) num2 - 1];
      int num3 = (int) num2;
      ushort id = (ushort) (num3 - 1);
      local.ID = (ushort) num3;
      this.AllData[(int) id].Type = MP.ReadByte();
      if (this.AllData[(int) id].Type > (byte) 2)
        this.AllData[(int) id].Type = (byte) 0;
      this.AllData[(int) id].KingdomID = MP.ReadUShort();
      this.AllData[(int) id].KingdomPoint.zoneID = MP.ReadUShort();
      this.AllData[(int) id].KingdomPoint.pointID = MP.ReadByte();
      MP.ReadStringPlus((int) this.NameSize, this.AllData[(int) id].Name);
      this.AddDataIndex(id);
      if ((int) index + (int) this.RecvDataCount < this.KindDataIDIndex[3].Length)
        this.KindDataIDIndex[3][(int) index + (int) this.RecvDataCount] = (byte) id;
    }
    if (this.RecvDataCount != (ushort) 0)
      return;
    GUIManager.Instance.HideUILock(EUILock.BookMark);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0);
  }

  public void RecvBookMarkList_Alliance(MessagePacket MP)
  {
    if (MP.ReadByte() > (byte) 0 || MP.ReadByte() > (byte) 0)
      return;
    byte num = MP.ReadByte();
    this.UpdateTimeAlliance = MP.ReadLong();
    this.AllianceBookCount = (byte) 0;
    Array.Clear((Array) this.AllianceIDIndex, 0, this.AllianceIDIndex.Length);
    for (byte index = 0; (int) index < (int) num && this.AllAllianceData.Length > (int) index; ++index)
    {
      byte VSize = MP.ReadByte();
      this.AllAllianceData[(int) index].KingdomID = MP.ReadUShort();
      this.AllAllianceData[(int) index].KingdomPoint.zoneID = MP.ReadUShort();
      this.AllAllianceData[(int) index].KingdomPoint.pointID = MP.ReadByte();
      this.AllAllianceData[(int) index].MapID = 0;
      this.AllAllianceData[(int) index].Type = (byte) 3;
      if (VSize > (byte) 0)
      {
        MP.ReadStringPlus((int) VSize, this.AllAllianceData[(int) index].Name);
        this.AllAllianceData[(int) index].ID = (ushort) (byte) ((uint) index + 1U);
        this.AllianceIDIndex[(int) this.AllianceBookCount] = index;
        ++this.AllianceBookCount;
      }
      else
        this.AllAllianceData[(int) index].ID = (ushort) 0;
    }
    DataManager.Instance.RoleAlliance.BookmarkTime = this.UpdateTimeAlliance;
    GUIManager.Instance.HideUILock(EUILock.BookMark);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0);
  }

  public void RecvBookMarkAdd(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.BookMark);
    DataManager instance = DataManager.Instance;
    ushort num1 = MP.ReadUShort();
    if (num1 == (ushort) 0)
      return;
    this.UpdateTime = MP.ReadLong();
    ushort num2 = MP.ReadUShort();
    if (num2 == (ushort) 0 || (int) num2 > this.AllData.Length)
      return;
    ref BookMarkData local = ref this.AllData[(int) num2 - 1];
    int num3 = (int) num2;
    ushort id = (ushort) (num3 - 1);
    local.ID = (ushort) num3;
    this.AllData[(int) id].Type = MP.ReadByte();
    if (this.AllData[(int) id].Type > (byte) 2)
      this.AllData[(int) id].Type = (byte) 0;
    this.AllData[(int) id].KingdomID = MP.ReadUShort();
    this.AllData[(int) id].KingdomPoint.zoneID = MP.ReadUShort();
    this.AllData[(int) id].KingdomPoint.pointID = MP.ReadByte();
    this.AllData[(int) id].MapID = 0;
    MP.ReadStringPlus((int) this.NameSize, this.AllData[(int) id].Name);
    DataManager.Instance.RoleAttr.BookmarkTime = this.UpdateTime;
    this.InsertDataIndex(id);
    if (this.KindDataIDIndex[3].Length >= (int) num1)
    {
      if (num1 < (ushort) 2)
        this.KindDataIDIndex[3][(int) num1 - 1] = (byte) id;
      if ((int) this.KindDataIDIndex[3][0] < (int) id)
      {
        for (int index = (int) instance.RoleAttr.BookmarkNum - 1; index >= 0; --index)
        {
          if ((int) this.KindDataIDIndex[3][index] < (int) id)
          {
            int sourceIndex = index + 1;
            int length = (int) instance.RoleAttr.BookmarkNum - sourceIndex;
            if (length > 0 && sourceIndex + 1 + length <= 100)
              Array.Copy((Array) this.KindDataIDIndex[3], sourceIndex, (Array) this.KindDataIDIndex[3], sourceIndex + 1, length);
            this.KindDataIDIndex[3][sourceIndex] = (byte) id;
            break;
          }
        }
      }
      else if ((int) this.KindDataIDIndex[3][0] > (int) id)
      {
        Array.Copy((Array) this.KindDataIDIndex[3], 0, (Array) this.KindDataIDIndex[3], 1, (int) instance.RoleAttr.BookmarkNum);
        this.KindDataIDIndex[3][0] = (byte) id;
      }
    }
    instance.RoleAttr.BookmarkNum = num1;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0);
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(786U), (ushort) byte.MaxValue);
  }

  public void RecvBookMarkAddModify_Alliance(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.BookMark);
    DataManager instance = DataManager.Instance;
    byte num1 = MP.ReadByte();
    switch (num1)
    {
      case 0:
      case 1:
        byte id = MP.ReadByte();
        byte num2 = MP.ReadByte();
        bool flag = true;
        if (num2 > (byte) 0)
        {
          if (num2 != (byte) 1)
            break;
          GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        if ((int) id >= this.AllAllianceData.Length)
          break;
        if (num1 == (byte) 0 && this.AllAllianceData[(int) id].ID > (ushort) 0)
          flag = false;
        this.UpdateTimeAlliance = MP.ReadLong();
        instance.RoleAlliance.BookmarkTime = this.UpdateTimeAlliance;
        byte VSize = MP.ReadByte();
        this.AllAllianceData[(int) id].ID = (ushort) (byte) ((uint) id + 1U);
        this.AllAllianceData[(int) id].Type = (byte) 3;
        this.AllAllianceData[(int) id].KingdomID = MP.ReadUShort();
        this.AllAllianceData[(int) id].KingdomPoint.zoneID = MP.ReadUShort();
        this.AllAllianceData[(int) id].KingdomPoint.pointID = MP.ReadByte();
        this.AllAllianceData[(int) id].MapID = 0;
        MP.ReadStringPlus((int) VSize, this.AllAllianceData[(int) id].Name);
        if (num1 == (byte) 0 && flag)
        {
          this.InsertDataIndex_Alliance((ushort) id);
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12631U), (ushort) byte.MaxValue);
          break;
        }
        if (this.OverWriteID == (ushort) 0)
        {
          if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_BookMark) == (UnityEngine.Object) null)
            (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BookMark, 655360 | (int) this.AllAllianceData[(int) id].Type + 1, this.GetMapID(this.AllAllianceData[(int) id].ID, BookMark.eBookType.Alliance));
          else
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 655360 | (int) this.AllAllianceData[(int) id].Type + 1, this.GetMapID(this.AllAllianceData[(int) id].ID, BookMark.eBookType.Alliance));
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12638U), (ushort) byte.MaxValue);
        }
        else
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12637U), (ushort) byte.MaxValue);
        this.OverWriteID = (ushort) 0;
        break;
    }
  }

  public void RecvBookMarkDel(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    GUIManager.Instance.HideUILock(EUILock.BookMark);
    ushort num1 = MP.ReadUShort();
    if (num1 == (ushort) 0 || (int) num1 > this.AllData.Length)
      return;
    ushort index;
    this.AllData[(int) (index = (ushort) ((uint) num1 - 1U))].ID = (ushort) 0;
    ushort num2 = MP.ReadUShort();
    this.UpdateTime = MP.ReadLong();
    this.RemoveDataIndex(index);
    for (ushort destinationIndex = 0; (int) destinationIndex < (int) instance.RoleAttr.BookmarkNum && (int) destinationIndex < this.KindDataIDIndex[3].Length; ++destinationIndex)
    {
      if ((int) this.KindDataIDIndex[3][(int) destinationIndex] == (int) index)
      {
        int length = (int) instance.RoleAttr.BookmarkNum - ((int) destinationIndex + 1);
        if (length > 0)
        {
          Array.Copy((Array) this.KindDataIDIndex[3], (int) destinationIndex + 1, (Array) this.KindDataIDIndex[3], (int) destinationIndex, length);
          break;
        }
        break;
      }
    }
    instance.RoleAttr.BookmarkNum = num2;
    instance.RoleAttr.BookmarkTime = this.UpdateTime;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0);
  }

  public void RecvBookMarkDel_Alliance(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    GUIManager.Instance.HideUILock(EUILock.BookMark);
    if (MP.ReadByte() > (byte) 0)
      return;
    byte index = MP.ReadByte();
    byte num = MP.ReadByte();
    if (num > (byte) 0)
    {
      if (num != (byte) 1)
        return;
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
    }
    else
    {
      if ((int) index >= this.AllAllianceData.Length || this.AllAllianceData[(int) index].ID == (ushort) 0)
        return;
      this.AllAllianceData[(int) index].ID = (ushort) 0;
      this.RemoveDataIndex((ushort) index, BookMark.eBookType.Alliance);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0);
    }
  }

  public void RecvBookMarkModify(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.BookMark);
    if (MP.ReadUShort() == (ushort) 0)
      return;
    this.UpdateTime = MP.ReadLong();
    ushort num1 = MP.ReadUShort();
    if (num1 == (ushort) 0 || (int) num1 > this.AllData.Length)
      return;
    ref BookMarkData local = ref this.AllData[(int) num1 - 1];
    int num2 = (int) num1;
    ushort index = (ushort) (num2 - 1);
    local.ID = (ushort) num2;
    byte num3 = MP.ReadByte();
    if (num3 > (byte) 2)
      num3 = (byte) 0;
    if ((int) num3 != (int) this.AllData[(int) index].Type)
    {
      this.RemoveDataIndex(index);
      this.AllData[(int) index].Type = num3;
      this.InsertDataIndex(index);
    }
    MP.ReadStringPlus((int) this.NameSize, this.AllData[(int) index].Name);
    DataManager.Instance.RoleAttr.BookmarkTime = this.UpdateTime;
    if (this.OverWriteID == (ushort) 0)
    {
      if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_BookMark) == (UnityEngine.Object) null)
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BookMark, 589824 | (int) this.AllData[(int) index].Type + 1, this.GetMapID(this.AllData[(int) index].ID));
      else
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 589824 | (int) this.AllData[(int) index].Type + 1, this.GetMapID(this.AllData[(int) index].ID));
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(787U), (ushort) byte.MaxValue);
    }
    else
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12629U), (ushort) byte.MaxValue);
    this.OverWriteID = (ushort) 0;
  }

  public void sendBookMarkInfo(bool LockInput)
  {
    if (LockInput && !GUIManager.Instance.ShowUILock(EUILock.BookMark))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BOOKMARKINFO;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void sendBookMarkInfo_Alliance(bool LockInput)
  {
    if (LockInput && !GUIManager.Instance.ShowUILock(EUILock.BookMark))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_BOOKMARKINFO;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void sendAddBookMark(string Name, byte Type, ushort KingdomID, int MapPointID)
  {
    if (Type == (byte) 3)
    {
      this.sendAddBookMark_Alliance(Name, KingdomID, MapPointID);
    }
    else
    {
      StringTable mStringTable = DataManager.Instance.mStringTable;
      DataManager instance = DataManager.Instance;
      if (this.UpdateTime == 0L || instance.RoleAttr.BookmarkTime != this.UpdateTime || this.RecvDataCount > (ushort) 0)
      {
        GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
      }
      else
      {
        ushort bookMarkId = this.GetBookMarkID(MapPointID, KingdomID);
        if (bookMarkId > (ushort) 0)
        {
          int num = (int) bookMarkId;
          ushort index = (ushort) (num - 1);
          this.OverWriteID = (ushort) num;
          this.OverWriteType = Type;
          this.OverWriteName = Name;
          this.MessageStr.ClearString();
          this.MessageStr.StringToFormat(this.AllData[(int) index].Name);
          this.MessageStr.AppendFormat(mStringTable.GetStringByID(4598U));
          GUIManager.Instance.OpenOKCancelBox(5, mStringTable.GetStringByID(4518U), this.MessageStr.ToString(), YesText: mStringTable.GetStringByID(4599U));
        }
        else if ((int) instance.RoleAttr.BookmarkNum == (int) instance.RoleAttr.BookmarkLimit)
        {
          GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(614U), mStringTable.GetStringByID(642U), mStringTable.GetStringByID(3U));
        }
        else
        {
          if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
            return;
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBOOKMARK;
          PointCode pointCode;
          GameConstants.MapIDToPointCode(MapPointID, out pointCode.zoneID, out pointCode.pointID);
          CString cstring = StringManager.Instance.StaticString1024();
          cstring.Append(Name);
          messagePacket.AddSeqId();
          messagePacket.Add(this.GetEmptyID());
          messagePacket.Add(Type);
          messagePacket.Add(KingdomID);
          messagePacket.Add(pointCode.zoneID);
          messagePacket.Add(pointCode.pointID);
          messagePacket.Add(Encoding.UTF8.GetBytes(cstring.ToString()), len: (int) this.NameSize);
          messagePacket.Send();
        }
      }
    }
  }

  private void sendAddBookMark_Alliance(string Name, ushort KingdomID, int MapPointID)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    DataManager instance = DataManager.Instance;
    if (instance.RoleAlliance.Id == 0U || instance.RoleAlliance.Rank < AllianceRank.RANK4)
    {
      GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
    }
    else
    {
      ushort bookMarkId = this.GetBookMarkID(MapPointID, KingdomID, BookMark.eBookType.Alliance);
      if (bookMarkId > (ushort) 0)
      {
        int num = (int) bookMarkId;
        ushort index = (ushort) (num - 1);
        this.OverWriteID = (ushort) num;
        this.OverWriteType = (byte) 3;
        this.OverWriteName = Name;
        this.MessageStr.ClearString();
        this.MessageStr.StringToFormat(this.AllAllianceData[(int) index].Name);
        this.MessageStr.AppendFormat(mStringTable.GetStringByID(12633U));
        GUIManager.Instance.OpenOKCancelBox(5, mStringTable.GetStringByID(12632U), this.MessageStr.ToString(), YesText: mStringTable.GetStringByID(4599U));
      }
      else if (this.AllianceBookCount == (byte) 20)
      {
        GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(4826U), mStringTable.GetStringByID(12634U));
      }
      else
      {
        if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
          return;
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFYBOOKMARK;
        PointCode pointCode;
        GameConstants.MapIDToPointCode(MapPointID, out pointCode.zoneID, out pointCode.pointID);
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.Append(Name);
        cstring.SetLength(cstring.Length);
        byte[] bytes = Encoding.UTF8.GetBytes(cstring.ToString());
        byte num = (byte) Math.Min(bytes.Length, (int) this.NameSize);
        cstring.SetLength(cstring.MaxLength);
        messagePacket.AddSeqId();
        messagePacket.Add((byte) 0);
        messagePacket.Add((byte) ((uint) this.GetEmptyID(BookMark.eBookType.Alliance) - 1U));
        messagePacket.Add(num);
        messagePacket.Add(KingdomID);
        messagePacket.Add(pointCode.zoneID);
        messagePacket.Add(pointCode.pointID);
        messagePacket.Add(bytes, len: (int) num);
        messagePacket.Send();
      }
    }
  }

  public ushort GetEmptyID(BookMark.eBookType bookType = BookMark.eBookType.Role)
  {
    ushort num1;
    BookMarkData[] bookMarkDataArray;
    if (bookType == BookMark.eBookType.Role)
    {
      num1 = DataManager.Instance.RoleAttr.BookmarkLimit;
      bookMarkDataArray = this.AllData;
    }
    else
    {
      num1 = (ushort) 20;
      bookMarkDataArray = this.AllAllianceData;
    }
    for (byte index = 0; (int) index < (int) num1 && bookMarkDataArray.Length > (int) index; ++index)
    {
      if (bookMarkDataArray[(int) index].ID == (ushort) 0)
      {
        byte num2;
        return (ushort) (num2 = (byte) ((uint) index + 1U));
      }
    }
    return 1;
  }

  public void sendDelBookMark(ushort ID)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_DELBOOKMARK;
    messagePacket.AddSeqId();
    messagePacket.Add(ID);
    messagePacket.Send();
  }

  public void sendDelBookMark_Alliance(byte ID)
  {
    if (DataManager.Instance.RoleAlliance.Id == 0U || DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
    }
    else
    {
      if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_REMOVEBOOKMARK;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 0);
      messagePacket.Add(--ID);
      messagePacket.Send();
    }
  }

  public void sendModifyBookMark(ushort ID, byte Type, string Name)
  {
    if (Type == (byte) 3)
    {
      this.sendModifyBookMark_Alliance((byte) ID, Name);
    }
    else
    {
      if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_MODIFYBOOKMARK;
      messagePacket.AddSeqId();
      messagePacket.Add(ID);
      messagePacket.Add(Type);
      messagePacket.Add(Encoding.UTF8.GetBytes(Name), len: (int) this.NameSize);
      messagePacket.Send();
    }
  }

  private void sendModifyBookMark_Alliance(byte ID, string Name)
  {
    if (DataManager.Instance.RoleAlliance.Id == 0U || DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
    }
    else
    {
      if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFYBOOKMARK;
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.Append(Name);
      cstring.SetLength(cstring.Length);
      byte[] bytes = Encoding.UTF8.GetBytes(cstring.ToString());
      byte num = (byte) Math.Min(bytes.Length, (int) this.NameSize);
      cstring.SetLength(cstring.MaxLength);
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 1);
      messagePacket.Add(--ID);
      messagePacket.Add(num);
      messagePacket.Add(this.AllAllianceData[(int) ID].KingdomID);
      messagePacket.Add(this.AllAllianceData[(int) ID].KingdomPoint.zoneID);
      messagePacket.Add(this.AllAllianceData[(int) ID].KingdomPoint.pointID);
      messagePacket.Add(bytes, len: (int) num);
      messagePacket.Send();
    }
  }

  public enum eBookType
  {
    Role,
    Alliance,
  }
}
