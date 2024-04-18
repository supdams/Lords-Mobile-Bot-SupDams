// Decompiled with JetBrains decompiler
// Type: TitleManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
internal class TitleManager
{
  private static TitleManager instance;
  public byte WaitTitleList;
  public int[] NowTitleIndex = new int[8]
  {
    -1,
    -1,
    -1,
    -1,
    -1,
    -1,
    -1,
    -1
  };
  public float[] NowTitlePos = new float[8]
  {
    -1f,
    -1f,
    -1f,
    -1f,
    -1f,
    -1f,
    -1f,
    -1f
  };
  public CString OpenTitleName = new CString(14);
  public CString[] RecvTitleNameNoTag;
  public CString[] RecvTitleName;
  public ushort[] RecvTitleIcon;
  public CString OpenTitleNameW = new CString(14);
  public CString[] RecvTitleNameNoTagW;
  public CString[] RecvTitleNameW;
  public ushort[] RecvTitleIconW;
  public ushort[] RecvTitleKingdomW;
  public ushort OpenKingdomID;
  public ushort[] RecvTitleKingdomID;
  public CString[] RecvTitleNameN;
  public CString WKNameNoTag = new CString(14);
  public CString WKName = new CString(25);
  public ushort WKIcon;
  public ushort WKKingdom;
  public ushort NTitleCount;
  public ushort OpenWonderID;
  public CString OpenNobilityTitleName = new CString(14);
  public CString[] RecvNobilityTitleNameNoTag;
  public CString[] RecvNobilityTitleName;
  public ushort[] RecvNobilityKingdomID;
  public ushort[] RecvNobilityTitleIcon;

  private TitleManager()
  {
  }

  public static TitleManager Instance
  {
    get
    {
      if (TitleManager.instance == null)
        TitleManager.instance = new TitleManager();
      return TitleManager.instance;
    }
  }

  ~TitleManager()
  {
  }

  public void KingdomTitle_Error(byte Result)
  {
    switch (Result)
    {
    }
  }

  public void WNTitle_Error(byte Result, bool bRemove = false)
  {
    switch (Result)
    {
      case 1:
      case 2:
      case 3:
      case 5:
      case 6:
        CString cstring = StringManager.Instance.StaticString1024();
        if (bRemove)
        {
          cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010U));
          cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5349U));
        }
        else
          cstring.Append(DataManager.Instance.mStringTable.GetStringByID(11045U));
        GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
        break;
      case 4:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(11039U), (ushort) byte.MaxValue);
        break;
    }
  }

  public void NobilityTitle_Error(byte Result)
  {
    switch (Result)
    {
    }
  }

  public void InitialTitleName(byte Count)
  {
    if (this.RecvTitleName != null)
      return;
    this.RecvTitleNameNoTag = new CString[(int) Count];
    this.RecvTitleName = new CString[(int) Count];
    this.RecvTitleIcon = new ushort[(int) Count];
    for (int index = 0; index < (int) Count; ++index)
    {
      this.RecvTitleIcon[index] = (ushort) 0;
      this.RecvTitleName[index] = new CString(20);
      this.RecvTitleNameNoTag[index] = new CString(14);
    }
  }

  public void Send_KingdomTitle_Change(ushort TitleID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM_TITLE_CHANGE;
    messagePacket.AddSeqId();
    messagePacket.Add(this.OpenTitleName.ToString(), 13);
    messagePacket.Add(TitleID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_KingdomTitle_Change(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      ushort num1 = MP.ReadUShort();
      if (num1 != (ushort) 0)
      {
        int index = (int) num1 - 1;
        if (index < this.RecvTitleIcon.Length)
        {
          this.RecvTitleIcon[index] = (ushort) 0;
          this.RecvTitleName[index].Length = 0;
          this.RecvTitleNameNoTag[index].Length = 0;
        }
      }
      ushort num2 = MP.ReadUShort();
      if (num2 != (ushort) 0)
      {
        int index = (int) num2 - 1;
        if (index < this.RecvTitleIcon.Length)
        {
          CString cstring = StringManager.Instance.StaticString1024();
          this.RecvTitleNameNoTag[index].Length = 0;
          this.RecvTitleIcon[index] = MP.ReadUShort();
          MP.ReadStringPlus(13, this.RecvTitleNameNoTag[index]);
          MP.ReadStringPlus(3, cstring);
          this.RecvTitleName[index].Length = 0;
          if (this.RecvTitleIcon[index] != (ushort) 0)
          {
            if (instance.IsArabic)
              this.RecvTitleName[index].Append(this.RecvTitleNameNoTag[index]);
            if (cstring.Length != 0)
            {
              this.RecvTitleName[index].StringToFormat(cstring);
              this.RecvTitleName[index].AppendFormat("[{0}]");
            }
            if (!instance.IsArabic)
              this.RecvTitleName[index].Append(this.RecvTitleNameNoTag[index]);
          }
          if (DataManager.CompareStr(this.RecvTitleNameNoTag[index], DataManager.Instance.mLordProfile.PlayerName) == 0)
            DataManager.Instance.mLordProfile.Title = num2;
        }
      }
      instance.UpdateUI(EGUIWindow.UI_Title, 0);
      CString cstring1 = StringManager.Instance.StaticString1024();
      cstring1.Append(DataManager.Instance.mStringTable.GetStringByID(11046U));
      instance.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(11045U));
      instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      this.KingdomTitle_Error(Result);
    }
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_KingdomTitle_ChangeByOthers(MessagePacket MP)
  {
    if (this.RecvTitleName == null)
      return;
    GUIManager instance = GUIManager.Instance;
    if (MP.ReadByte() != (byte) 0)
      return;
    ushort num1 = MP.ReadUShort();
    if (num1 != (ushort) 0)
    {
      int index = (int) num1 - 1;
      if (index < this.RecvTitleIcon.Length)
      {
        this.RecvTitleIcon[index] = (ushort) 0;
        this.RecvTitleName[index].Length = 0;
        this.RecvTitleNameNoTag[index].Length = 0;
      }
    }
    ushort num2 = MP.ReadUShort();
    if (num2 != (ushort) 0)
    {
      int index = (int) num2 - 1;
      if (index < this.RecvTitleIcon.Length)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        this.RecvTitleNameNoTag[index].Length = 0;
        this.RecvTitleIcon[index] = MP.ReadUShort();
        MP.ReadStringPlus(13, this.RecvTitleNameNoTag[index]);
        MP.ReadStringPlus(3, cstring);
        this.RecvTitleName[index].Length = 0;
        if (this.RecvTitleIcon[index] != (ushort) 0)
        {
          if (instance.IsArabic)
            this.RecvTitleName[index].Append(this.RecvTitleNameNoTag[index]);
          if (cstring.Length != 0)
          {
            this.RecvTitleName[index].StringToFormat(cstring);
            this.RecvTitleName[index].AppendFormat("[{0}]");
          }
          if (!instance.IsArabic)
            this.RecvTitleName[index].Append(this.RecvTitleNameNoTag[index]);
        }
        if (DataManager.CompareStr(this.RecvTitleNameNoTag[index], DataManager.Instance.mLordProfile.PlayerName) == 0)
          DataManager.Instance.mLordProfile.Title = num2;
      }
    }
    instance.UpdateUI(EGUIWindow.UI_Title, 1);
  }

  public void Send_KingdomTitle_Remove(ushort TitleID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM_TITLE_REMOVE;
    messagePacket.AddSeqId();
    messagePacket.Add(TitleID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_KingdomTitle_Remove(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      ushort num = MP.ReadUShort();
      if (num != (ushort) 0)
      {
        int index = (int) num - 1;
        if (index < this.RecvTitleIcon.Length)
        {
          this.RecvTitleIcon[index] = (ushort) 0;
          this.RecvTitleName[index].Length = 0;
          this.RecvTitleNameNoTag[index].Length = 0;
        }
        instance.UpdateUI(EGUIWindow.UI_Title, 0);
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010U));
        cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5348U));
        instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      }
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010U));
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5349U));
      instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      this.KingdomTitle_Error(Result);
    }
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_KingdomTitle_RemoveByOthers(MessagePacket MP)
  {
    if (this.RecvTitleName == null)
      return;
    GUIManager instance = GUIManager.Instance;
    if (MP.ReadByte() != (byte) 0)
      return;
    ushort num = MP.ReadUShort();
    if (num == (ushort) 0)
      return;
    int index = (int) num - 1;
    if (index < this.RecvTitleIcon.Length)
    {
      this.RecvTitleIcon[index] = (ushort) 0;
      this.RecvTitleName[index].Length = 0;
      this.RecvTitleNameNoTag[index].Length = 0;
    }
    instance.UpdateUI(EGUIWindow.UI_Title, 1);
  }

  public void Send_KingdomTitle_List_King()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_HOMEKINGDOM_TITLE_LIST;
    messagePacket.AddSeqId();
    messagePacket.Add(DataManager.Instance.RoleAttr.Name.ToString(), 13);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Send_KingdomTitle_List()
  {
    MessagePacket messagePacket = DataManager.MapDataController.FocusKingdomID == (ushort) 0 || (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID ? new MessagePacket((ushort) 1024) : MessagePacket.GetGuestMessagePack();
    messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM_TITLE_LIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_KingdomTitle_List(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      byte Count = MP.ReadByte();
      this.InitialTitleName(Count);
      for (int index = 0; index < (int) Count && index < this.RecvTitleName.Length; ++index)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        this.RecvTitleNameNoTag[index].Length = 0;
        this.RecvTitleIcon[index] = MP.ReadUShort();
        MP.ReadStringPlus(13, this.RecvTitleNameNoTag[index]);
        MP.ReadStringPlus(3, cstring);
        this.RecvTitleName[index].Length = 0;
        if (this.RecvTitleIcon[index] != (ushort) 0)
        {
          if (instance.IsArabic)
            this.RecvTitleName[index].Append(this.RecvTitleNameNoTag[index]);
          if (cstring.Length != 0)
          {
            this.RecvTitleName[index].StringToFormat(cstring);
            this.RecvTitleName[index].AppendFormat("[{0}]");
          }
          if (!instance.IsArabic)
            this.RecvTitleName[index].Append(this.RecvTitleNameNoTag[index]);
        }
      }
      Door menu = instance.FindMenu(EGUIWindow.Door) as Door;
      if ((bool) (Object) menu && !menu.OpenMenu(EGUIWindow.UI_Title, (int) this.WaitTitleList))
        instance.UpdateUI(EGUIWindow.UI_Title, 0);
      this.WaitTitleList = (byte) 0;
    }
    else
      this.KingdomTitle_Error(Result);
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_KingdomTitle_Get(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    instance.RoleAttr.KingdomTitle = MP.ReadUShort();
    if (instance.RoleAttr.KingdomTitle > (ushort) 1)
    {
      TitleData recordByKey = instance.TitleData.GetRecordByKey(instance.RoleAttr.KingdomTitle);
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
      cstring.AppendFormat(instance.mStringTable.GetStringByID(9368U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
    if (DataManager.MapDataController.IsKingdomChief())
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Title, 4);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 1);
  }

  public void OpenTitleList()
  {
    this.WaitTitleList = (byte) 1;
    this.Send_KingdomTitle_List();
  }

  public void OpenTitleSet(CString OpenName)
  {
    this.WaitTitleList = (byte) 2;
    this.OpenTitleName.Length = 0;
    this.OpenTitleName.Append(OpenName);
    if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) DataManager.MapDataController.FocusKingdomID)
      this.Send_KingdomTitle_List_King();
    else
      this.Send_KingdomTitle_List();
  }

  public void InitialTitleNameW(byte Count)
  {
    if (this.RecvTitleNameW != null)
      return;
    this.RecvTitleNameNoTagW = new CString[(int) Count];
    this.RecvTitleNameW = new CString[(int) Count];
    this.RecvTitleIconW = new ushort[(int) Count];
    this.RecvTitleKingdomW = new ushort[(int) Count];
    for (int index = 0; index < (int) Count; ++index)
    {
      this.RecvTitleKingdomW[index] = (ushort) 0;
      this.RecvTitleIconW[index] = (ushort) 0;
      this.RecvTitleNameW[index] = new CString(25);
      this.RecvTitleNameNoTagW[index] = new CString(14);
    }
  }

  public void Send_WorldTitle_Change(ushort TitleID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_WORLD_TITLE_CHANGE;
    messagePacket.AddSeqId();
    messagePacket.Add(this.OpenTitleNameW.ToString(), 13);
    messagePacket.Add(TitleID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_WorldTitle_Change(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      ushort num1 = MP.ReadUShort();
      if (num1 != (ushort) 0)
      {
        int index = (int) num1 - 1;
        if (index < this.RecvTitleIconW.Length)
        {
          this.RecvTitleIconW[index] = (ushort) 0;
          this.RecvTitleKingdomW[index] = (ushort) 0;
          this.RecvTitleNameW[index].Length = 0;
          this.RecvTitleNameNoTagW[index].Length = 0;
        }
      }
      ushort num2 = MP.ReadUShort();
      if (num2 != (ushort) 0)
      {
        int index = (int) num2 - 1;
        if (index < this.RecvTitleIconW.Length)
        {
          CString cstring = StringManager.Instance.StaticString1024();
          this.RecvTitleNameNoTagW[index].Length = 0;
          this.RecvTitleIconW[index] = MP.ReadUShort();
          this.RecvTitleKingdomW[index] = MP.ReadUShort();
          MP.ReadStringPlus(13, this.RecvTitleNameNoTagW[index]);
          MP.ReadStringPlus(3, cstring);
          this.RecvTitleNameW[index].Length = 0;
          if (this.RecvTitleIconW[index] != (ushort) 0)
          {
            ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
            GameConstants.FormatRoleName(this.RecvTitleNameW[index], this.RecvTitleNameNoTagW[index], cstring, bCheckedNickname: (byte) 0, KingdomID: (int) kingdomId == (int) this.RecvTitleKingdomW[index] ? (ushort) 0 : this.RecvTitleKingdomW[index]);
          }
        }
      }
      instance.UpdateUI(EGUIWindow.UI_Title, 0);
      CString cstring1 = StringManager.Instance.StaticString1024();
      cstring1.Append(DataManager.Instance.mStringTable.GetStringByID(11046U));
      instance.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
    }
    else
      this.WNTitle_Error(Result);
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_WorldTitle_ChangeByOthers(MessagePacket MP)
  {
    if (this.RecvTitleNameW == null)
      return;
    GUIManager instance = GUIManager.Instance;
    if (MP.ReadByte() != (byte) 0)
      return;
    ushort num1 = MP.ReadUShort();
    if (num1 != (ushort) 0)
    {
      int index = (int) num1 - 1;
      if (index < this.RecvTitleIconW.Length)
      {
        this.RecvTitleIconW[index] = (ushort) 0;
        this.RecvTitleKingdomW[index] = (ushort) 0;
        this.RecvTitleNameW[index].Length = 0;
        this.RecvTitleNameNoTagW[index].Length = 0;
      }
    }
    ushort num2 = MP.ReadUShort();
    if (num2 != (ushort) 0)
    {
      int index = (int) num2 - 1;
      if (index < this.RecvTitleIconW.Length)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        this.RecvTitleNameNoTagW[index].Length = 0;
        this.RecvTitleIconW[index] = MP.ReadUShort();
        this.RecvTitleKingdomW[index] = MP.ReadUShort();
        MP.ReadStringPlus(13, this.RecvTitleNameNoTagW[index]);
        MP.ReadStringPlus(3, cstring);
        this.RecvTitleNameW[index].Length = 0;
        if (this.RecvTitleIconW[index] != (ushort) 0)
        {
          ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
          GameConstants.FormatRoleName(this.RecvTitleNameW[index], this.RecvTitleNameNoTagW[index], cstring, bCheckedNickname: (byte) 0, KingdomID: (int) kingdomId == (int) this.RecvTitleKingdomW[index] ? (ushort) 0 : this.RecvTitleKingdomW[index]);
        }
      }
    }
    instance.UpdateUI(EGUIWindow.UI_Title, 2);
  }

  public void Send_WorldTitle_Remove(ushort TitleID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_WORLD_TITLE_REMOVE;
    messagePacket.AddSeqId();
    messagePacket.Add(TitleID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_WorldTitle_Remove(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      ushort num = MP.ReadUShort();
      if (num != (ushort) 0)
      {
        int index = (int) num - 1;
        if (index < this.RecvTitleIconW.Length)
        {
          this.RecvTitleIconW[index] = (ushort) 0;
          this.RecvTitleNameW[index].Length = 0;
          this.RecvTitleNameNoTagW[index].Length = 0;
        }
        instance.UpdateUI(EGUIWindow.UI_Title, 0);
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010U));
        cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5348U));
        instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      }
    }
    else
      this.WNTitle_Error(Result, true);
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_WorldTitle_RemoveByOthers(MessagePacket MP)
  {
    if (this.RecvTitleNameW == null)
      return;
    GUIManager instance = GUIManager.Instance;
    if (MP.ReadByte() != (byte) 0)
      return;
    ushort num = MP.ReadUShort();
    if (num == (ushort) 0)
      return;
    int index = (int) num - 1;
    if (index < this.RecvTitleIconW.Length)
    {
      this.RecvTitleIconW[index] = (ushort) 0;
      this.RecvTitleNameW[index].Length = 0;
      this.RecvTitleNameNoTagW[index].Length = 0;
    }
    instance.UpdateUI(EGUIWindow.UI_Title, 2);
  }

  public void Send_WorldTitle_List()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_WORLD_TITLE_LIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_WorldTitle_List(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      byte Count = MP.ReadByte();
      this.InitialTitleNameW(Count);
      for (int index = 0; index < (int) Count && index < this.RecvTitleNameW.Length; ++index)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        this.RecvTitleNameNoTagW[index].Length = 0;
        this.RecvTitleIconW[index] = MP.ReadUShort();
        this.RecvTitleKingdomW[index] = MP.ReadUShort();
        MP.ReadStringPlus(13, this.RecvTitleNameNoTagW[index]);
        MP.ReadStringPlus(3, cstring);
        this.RecvTitleNameW[index].Length = 0;
        if (this.RecvTitleIconW[index] != (ushort) 0)
        {
          ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
          GameConstants.FormatRoleName(this.RecvTitleNameW[index], this.RecvTitleNameNoTagW[index], cstring, bCheckedNickname: (byte) 0, KingdomID: (int) kingdomId == (int) this.RecvTitleKingdomW[index] ? (ushort) 0 : this.RecvTitleKingdomW[index]);
        }
      }
      Door menu = instance.FindMenu(EGUIWindow.Door) as Door;
      if ((bool) (Object) menu && !menu.OpenMenu(EGUIWindow.UI_Title, (int) this.WaitTitleList))
        instance.UpdateUI(EGUIWindow.UI_Title, 0);
      this.WaitTitleList = (byte) 0;
    }
    else
      this.WNTitle_Error(Result);
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_WorldTitle_Get(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    instance.RoleAttr.WorldTitle_Personal = MP.ReadUShort();
    if (instance.RoleAttr.WorldTitle_Personal > (ushort) 1)
    {
      TitleData recordByKey = instance.TitleDataW.GetRecordByKey(instance.RoleAttr.WorldTitle_Personal);
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
      cstring.AppendFormat(instance.mStringTable.GetStringByID(9368U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
    if (DataManager.MapDataController.IsWorldChief())
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Title, 4);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 1);
  }

  public void OpenTitleListW(CString OpenName = null)
  {
    if (OpenName == null)
    {
      this.WaitTitleList = (byte) 3;
    }
    else
    {
      this.WaitTitleList = (byte) 4;
      this.OpenTitleNameW.Length = 0;
      this.OpenTitleNameW.Append(OpenName);
    }
    this.Send_WorldTitle_List();
  }

  public void InitialTitleNameN(byte Count)
  {
    if (this.RecvTitleKingdomID != null)
      return;
    this.RecvTitleKingdomID = new ushort[(int) Count];
    this.RecvTitleNameN = new CString[(int) Count];
    for (int index = 0; index < (int) Count; ++index)
    {
      this.RecvTitleKingdomID[index] = (ushort) 0;
      this.RecvTitleNameN[index] = new CString(25);
    }
  }

  public void Send_NationalTitle_Change(ushort KingdomID, ushort TitleID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NATIONAL_TITLE_CHANGE;
    messagePacket.AddSeqId();
    messagePacket.Add(KingdomID);
    messagePacket.Add(TitleID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_NationalTitle_Change(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      ushort num = MP.ReadUShort();
      if (num != (ushort) 0)
      {
        int index = (int) num - 1;
        if (index < this.RecvTitleKingdomID.Length)
        {
          CString str = StringManager.Instance.StaticString1024();
          this.RecvTitleKingdomID[index] = MP.ReadUShort();
          this.RecvTitleNameN[index].Length = 0;
          if (this.RecvTitleKingdomID[index] != (ushort) 0)
          {
            DataManager.MapDataController.GetKingdomName(this.RecvTitleKingdomID[index], ref str);
            this.RecvTitleNameN[index].IntToFormat((long) this.RecvTitleKingdomID[index]);
            this.RecvTitleNameN[index].StringToFormat(str);
            this.RecvTitleNameN[index].AppendFormat("#{0} {1}");
          }
        }
      }
      instance.UpdateUI(EGUIWindow.UI_Title, 0);
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(11046U));
      instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      ++this.NTitleCount;
      if (!this.CheckGivetNTile() && DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 1)
      {
        DataManager.msgBuffer[0] = (byte) 120;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
    }
    else
      this.WNTitle_Error(Result);
    instance.HideUILock(EUILock.Title);
  }

  public void Send_NationalTitle_List()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NATIONAL_TITLE_LIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_NationalTitle_List(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      CString cstring = StringManager.Instance.StaticString1024();
      this.WKNameNoTag.Length = 0;
      this.WKName.Length = 0;
      this.WKIcon = MP.ReadUShort();
      this.WKKingdom = MP.ReadUShort();
      MP.ReadStringPlus(13, this.WKNameNoTag);
      MP.ReadStringPlus(3, cstring);
      if (this.WKIcon != (ushort) 0)
      {
        ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
        GameConstants.FormatRoleName(this.WKName, this.WKNameNoTag, cstring, bCheckedNickname: (byte) 0, KingdomID: (int) kingdomId == (int) this.WKKingdom ? (ushort) 0 : this.WKKingdom);
      }
      byte Count = MP.ReadByte();
      this.InitialTitleNameN(Count);
      for (int index = 0; index < (int) Count && index < this.RecvTitleKingdomID.Length; ++index)
      {
        CString str = StringManager.Instance.StaticString1024();
        this.RecvTitleKingdomID[index] = MP.ReadUShort();
        this.RecvTitleNameN[index].Length = 0;
        if (this.RecvTitleKingdomID[index] != (ushort) 0)
        {
          DataManager.MapDataController.GetKingdomName(this.RecvTitleKingdomID[index], ref str);
          this.RecvTitleNameN[index].IntToFormat((long) this.RecvTitleKingdomID[index]);
          this.RecvTitleNameN[index].StringToFormat(str);
          this.RecvTitleNameN[index].AppendFormat("#{0} {1}");
        }
      }
      Door menu = instance.FindMenu(EGUIWindow.Door) as Door;
      if ((bool) (Object) menu && !menu.OpenMenu(EGUIWindow.UI_Title, (int) this.WaitTitleList))
        instance.UpdateUI(EGUIWindow.UI_Title, 0);
      this.WaitTitleList = (byte) 0;
    }
    else
      this.WNTitle_Error(Result);
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_NationalTitle_Get(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    instance.RoleAttr.WorldTitle_Country = MP.ReadUShort();
    if (instance.RoleAttr.WorldTitle_Country > (ushort) 0)
    {
      TitleData recordByKey = instance.TitleDataN.GetRecordByKey(instance.RoleAttr.WorldTitle_Country);
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
      cstring.AppendFormat(instance.mStringTable.GetStringByID(11015U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
    DataManager.Instance.UpdateItemBuffIcon();
    GameManager.OnRefresh(NetworkNews.Refresh_BuffList);
  }

  public void Recv_NationalTitle_Count(MessagePacket MP) => this.NTitleCount = MP.ReadUShort();

  public void OpenTitleListN(ushort KingdomID = 0)
  {
    if (KingdomID == (ushort) 0)
    {
      this.WaitTitleList = (byte) 5;
    }
    else
    {
      this.WaitTitleList = (byte) 6;
      this.OpenKingdomID = KingdomID;
    }
    this.Send_NationalTitle_List();
  }

  public bool CheckGivetNTile()
  {
    return (int) this.NTitleCount < DataManager.Instance.TitleDataN.TableCount;
  }

  public void InitialNobilityTitleName(byte Count)
  {
    if (this.RecvNobilityTitleName != null)
      return;
    this.RecvNobilityTitleNameNoTag = new CString[(int) Count];
    this.RecvNobilityTitleName = new CString[(int) Count];
    this.RecvNobilityKingdomID = new ushort[(int) Count];
    this.RecvNobilityTitleIcon = new ushort[(int) Count];
    for (int index = 0; index < (int) Count; ++index)
    {
      this.RecvNobilityTitleIcon[index] = (ushort) 0;
      this.RecvNobilityKingdomID[index] = (ushort) 0;
      this.RecvNobilityTitleName[index] = new CString(20);
      this.RecvNobilityTitleNameNoTag[index] = new CString(14);
    }
  }

  public void Send_NobilityTitle_Change(ushort TitleID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_CHANGE;
    messagePacket.AddSeqId();
    messagePacket.Add(this.OpenNobilityTitleName.ToString(), 13);
    messagePacket.Add(TitleID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_NobilityTitle_Change(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      ushort num1 = MP.ReadUShort();
      if (num1 != (ushort) 0)
      {
        int index = (int) num1 - 1;
        if (index < this.RecvNobilityTitleIcon.Length)
        {
          this.RecvNobilityTitleIcon[index] = (ushort) 0;
          this.RecvNobilityTitleName[index].Length = 0;
          this.RecvNobilityTitleNameNoTag[index].Length = 0;
        }
      }
      ushort num2 = MP.ReadUShort();
      if (num2 != (ushort) 0)
      {
        int index = (int) num2 - 1;
        if (index < this.RecvNobilityTitleIcon.Length)
        {
          CString cstring = StringManager.Instance.StaticString1024();
          this.RecvNobilityTitleNameNoTag[index].Length = 0;
          this.RecvNobilityTitleIcon[index] = MP.ReadUShort();
          this.RecvNobilityKingdomID[index] = MP.ReadUShort();
          MP.ReadStringPlus(13, this.RecvNobilityTitleNameNoTag[index]);
          MP.ReadStringPlus(3, cstring);
          this.RecvNobilityTitleName[index].Length = 0;
          if (this.RecvNobilityTitleIcon[index] != (ushort) 0)
          {
            ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
            GameConstants.FormatRoleName(this.RecvNobilityTitleName[index], this.RecvNobilityTitleNameNoTag[index], cstring, bCheckedNickname: (byte) 0, KingdomID: (int) kingdomId == (int) this.RecvNobilityKingdomID[index] ? (ushort) 0 : this.RecvNobilityKingdomID[index]);
          }
          if (DataManager.CompareStr(this.RecvNobilityTitleNameNoTag[index], DataManager.Instance.mLordProfile.PlayerName) == 0)
            DataManager.Instance.mLordProfile.NobilityTitle = num2;
        }
      }
      instance.UpdateUI(EGUIWindow.UI_Title, 0);
      CString cstring1 = StringManager.Instance.StaticString1024();
      cstring1.Append(DataManager.Instance.mStringTable.GetStringByID(11046U));
      instance.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(11045U));
      instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      this.NobilityTitle_Error(Result);
    }
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_NobilityTitle_ChangeByOthers(MessagePacket MP)
  {
    if (this.RecvNobilityTitleName == null)
      return;
    GUIManager instance = GUIManager.Instance;
    if (MP.ReadByte() != (byte) 0)
      return;
    ushort num1 = MP.ReadUShort();
    if (num1 != (ushort) 0)
    {
      int index = (int) num1 - 1;
      if (index < this.RecvNobilityTitleIcon.Length)
      {
        this.RecvNobilityTitleIcon[index] = (ushort) 0;
        this.RecvNobilityTitleName[index].Length = 0;
        this.RecvNobilityTitleNameNoTag[index].Length = 0;
      }
    }
    ushort num2 = MP.ReadUShort();
    if (num2 != (ushort) 0)
    {
      int index = (int) num2 - 1;
      if (index < this.RecvNobilityTitleIcon.Length)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        this.RecvNobilityTitleNameNoTag[index].Length = 0;
        this.RecvNobilityTitleIcon[index] = MP.ReadUShort();
        this.RecvNobilityKingdomID[index] = MP.ReadUShort();
        MP.ReadStringPlus(13, this.RecvNobilityTitleNameNoTag[index]);
        MP.ReadStringPlus(3, cstring);
        this.RecvNobilityTitleName[index].Length = 0;
        if (this.RecvNobilityTitleIcon[index] != (ushort) 0)
        {
          ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
          GameConstants.FormatRoleName(this.RecvNobilityTitleName[index], this.RecvNobilityTitleNameNoTag[index], cstring, bCheckedNickname: (byte) 0, KingdomID: (int) kingdomId == (int) this.RecvNobilityKingdomID[index] ? (ushort) 0 : this.RecvNobilityKingdomID[index]);
        }
        if (DataManager.CompareStr(this.RecvNobilityTitleNameNoTag[index], DataManager.Instance.mLordProfile.PlayerName) == 0)
          DataManager.Instance.mLordProfile.NobilityTitle = num2;
      }
    }
    instance.UpdateUI(EGUIWindow.UI_Title, 3);
  }

  public void Send_NobilityTitle_Remove(ushort TitleID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_REMOVE;
    messagePacket.AddSeqId();
    messagePacket.Add(TitleID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_NobilityTitle_Remove(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      ushort num = MP.ReadUShort();
      if (num != (ushort) 0)
      {
        int index = (int) num - 1;
        if (index < this.RecvNobilityTitleIcon.Length)
        {
          this.RecvNobilityTitleIcon[index] = (ushort) 0;
          this.RecvNobilityKingdomID[index] = (ushort) 0;
          this.RecvNobilityTitleName[index].Length = 0;
          this.RecvNobilityTitleNameNoTag[index].Length = 0;
        }
        instance.UpdateUI(EGUIWindow.UI_Title, 0);
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010U));
        cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5348U));
        instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      }
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010U));
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5349U));
      instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      this.NobilityTitle_Error(Result);
    }
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_NobilityTitle_RemoveByOthers(MessagePacket MP)
  {
    if (this.RecvNobilityTitleName == null)
      return;
    GUIManager instance = GUIManager.Instance;
    if (MP.ReadByte() != (byte) 0)
      return;
    ushort num = MP.ReadUShort();
    if (num == (ushort) 0)
      return;
    int index = (int) num - 1;
    if (index < this.RecvNobilityTitleIcon.Length)
    {
      this.RecvNobilityTitleIcon[index] = (ushort) 0;
      this.RecvNobilityKingdomID[index] = (ushort) 0;
      this.RecvNobilityTitleName[index].Length = 0;
      this.RecvNobilityTitleNameNoTag[index].Length = 0;
    }
    instance.UpdateUI(EGUIWindow.UI_Title, 3);
  }

  public void Send_NobilityTitle_List_King(ushort WonderID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_LIST_BY_GROUP;
    messagePacket.AddSeqId();
    messagePacket.Add(WonderID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Send_NobilityTitle_List()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_LIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Title);
  }

  public void Recv_NobilityTitle_List(MessagePacket MP)
  {
    GUIManager instance = GUIManager.Instance;
    byte Result = MP.ReadByte();
    if (Result == (byte) 0)
    {
      byte Count = MP.ReadByte();
      this.InitialNobilityTitleName(Count);
      for (int index = 0; index < (int) Count && index < this.RecvNobilityTitleName.Length; ++index)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        this.RecvNobilityTitleNameNoTag[index].Length = 0;
        this.RecvNobilityTitleIcon[index] = MP.ReadUShort();
        this.RecvNobilityKingdomID[index] = MP.ReadUShort();
        MP.ReadStringPlus(13, this.RecvNobilityTitleNameNoTag[index]);
        MP.ReadStringPlus(3, cstring);
        this.RecvNobilityTitleName[index].Length = 0;
        if (this.RecvNobilityTitleIcon[index] != (ushort) 0)
        {
          ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
          GameConstants.FormatRoleName(this.RecvNobilityTitleName[index], this.RecvNobilityTitleNameNoTag[index], cstring, bCheckedNickname: (byte) 0, KingdomID: (int) kingdomId == (int) this.RecvNobilityKingdomID[index] ? (ushort) 0 : this.RecvNobilityKingdomID[index]);
        }
      }
      Door menu = instance.FindMenu(EGUIWindow.Door) as Door;
      if ((bool) (Object) menu && !menu.OpenMenu(EGUIWindow.UI_Title, (int) this.WaitTitleList))
        instance.UpdateUI(EGUIWindow.UI_Title, 0);
      this.WaitTitleList = (byte) 0;
    }
    else
      this.NobilityTitle_Error(Result);
    instance.HideUILock(EUILock.Title);
  }

  public void Recv_NobilityTitle_Get(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    instance.RoleAttr.NobilityTitle = MP.ReadUShort();
    if (instance.RoleAttr.NobilityTitle > (ushort) 1)
    {
      TitleData recordByKey = instance.TitleDataF.GetRecordByKey(instance.RoleAttr.NobilityTitle);
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
      cstring.AppendFormat(instance.mStringTable.GetStringByID(9368U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
    if (DataManager.MapDataController.IsNobilityChief())
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Title, 4);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 1);
  }

  public void OpenNobilityTitleList(ushort WonderID)
  {
    this.WaitTitleList = (byte) 7;
    this.OpenWonderID = WonderID;
    this.Send_NobilityTitle_List_King(WonderID);
  }

  public void OpenNobilityTitleSet(CString OpenName)
  {
    this.WaitTitleList = (byte) 8;
    this.OpenNobilityTitleName.Length = 0;
    this.OpenNobilityTitleName.Append(OpenName);
    if (ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.OtherKingdomData.kingdomID))
      this.Send_NobilityTitle_List();
    else
      this.Send_NobilityTitle_List_King((ushort) ActivityManager.Instance.FederalActKingdomWonderID);
  }
}
