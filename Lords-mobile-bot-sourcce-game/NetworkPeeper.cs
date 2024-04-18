// Decompiled with JetBrains decompiler
// Type: NetworkPeeper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

#nullable disable
public class NetworkPeeper
{
  public static Socket Sucket;
  public static LoginPhase Stage;
  public static System.Collections.Queue SendBuff = new System.Collections.Queue();
  public static byte[] ReadData = new byte[4096];
  public static int parse_pos;
  public static int read_pos;
  public ushort ID;
  public byte Result;
  public int Sequence;
  public float BeatTime;
  public float LinkTime;
  public float ConnectTime;
  private bool LifeProbing;
  private bool LostInSpace;
  public static long ServerTime;

  public bool View(ushort Id, bool Force = false)
  {
    if (NetworkPeeper.Stage >= LoginPhase.LP_Connecting && NetworkPeeper.Stage <= LoginPhase.LP_Logging && !Force)
      return false;
    this.Drop();
    this.ID = Id;
    NetworkPeeper.Stage = LoginPhase.LP_Connecting;
    this.ConnectTime = 15f;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_GUESTLOGIN_REQUESTIPTOP;
    messagePacket.AddSeqId();
    messagePacket.Add(Id);
    messagePacket.Add(NetworkManager.UDID, NetworkManager.UDID.Length);
    return messagePacket.Send();
  }

  protected bool Connect()
  {
    if (this.LostInSpace)
      this.Drop(true);
    else if (this.LifeProbing)
    {
      if (NetworkPeeper.Stage == LoginPhase.LP_Connecting)
      {
        GuestMessagePacket.Sequence = 0;
        NetworkPeeper.Stage = LoginPhase.LP_Connected;
        this.ConnectTime = 15f;
        MessagePacket guestMessagePack = MessagePacket.GetGuestMessagePack();
        guestMessagePack.Protocol = Protocol._MSG_GUESTLOGIN_LOGIN;
        guestMessagePack.Add(NetworkManager.UserID);
        guestMessagePack.Add(NetworkManager.UDID, NetworkManager.UDID.Length);
        guestMessagePack.Send(true);
      }
      return this.LifeProbing = false;
    }
    return true;
  }

  public bool Connecting()
  {
    return NetworkPeeper.Stage > LoginPhase.LP_Disconnect && NetworkPeeper.Stage < LoginPhase.LP_InGame;
  }

  public bool Connected() => NetworkPeeper.Stage == LoginPhase.LP_InGame;

  public void Resume(bool sure = true)
  {
    if (NetworkPeeper.Stage != LoginPhase.LP_Connecting && NetworkPeeper.Stage != LoginPhase.LP_Connected)
      return;
    this.View(this.ID, sure);
  }

  public void Drop(bool Force = false)
  {
    if (NetworkPeeper.Sucket != null)
    {
      NetworkPeeper.Sucket.Close();
      NetworkPeeper.Sucket = (Socket) null;
    }
    NetworkPeeper.SendBuff.Clear();
    NetworkManager.Cleansing();
    NetworkPeeper.Stage = LoginPhase.LP_Disconnect;
    this.LostInSpace = this.LifeProbing = false;
    this.BeatTime = this.LinkTime = this.ConnectTime = (float) (this.Result = (byte) 0);
    if (!Force)
      return;
    GameManager.OnRefresh(NetworkNews.GuestLost);
  }

  public void Enter(MessagePacket MP)
  {
    if (NetworkPeeper.Stage != LoginPhase.LP_Connecting)
    {
      this.LostInSpace = true;
    }
    else
    {
      AddressFamily addressFamily = AddressFamily.Unknown;
      CString CStr = StringManager.Instance.StaticString1024();
      CStr.ClearString();
      string str = MP.ReadString(16, MP.Offset + 4);
      GameConstants.GetHostName(CStr, str, "lm-proxy-");
      IPAddress[] ipAddressArray = (IPAddress[]) null;
      try
      {
        ipAddressArray = Dns.GetHostAddresses(CStr.ToString());
      }
      catch (Exception ex)
      {
        Debug.Log((object) ("[Enter]:" + ex.Message));
      }
      if (ipAddressArray == null)
      {
        ipAddressArray = new IPAddress[1];
        if (IPAddress.TryParse(str, out ipAddressArray[0]))
          addressFamily = ipAddressArray[0].AddressFamily;
      }
      else if (ipAddressArray.Length > 0 && ipAddressArray[0] != null)
        addressFamily = ipAddressArray[0].AddressFamily;
      CStr.ClearString();
      if (addressFamily == AddressFamily.Unknown)
      {
        this.LostInSpace = true;
      }
      else
      {
        this.ConnectTime = 15f;
        NetworkPeeper.Sucket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp)
        {
          Blocking = false,
          SendTimeout = 0,
          ReceiveTimeout = 0
        };
        try
        {
          NetworkPeeper.Sucket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, true);
          NetworkPeeper.Sucket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, (object) NetworkManager.LOL);
        }
        catch
        {
        }
        if (!NetworkPeeper.Sucket.BeginConnect(ipAddressArray[0], MP.ReadInt(), new AsyncCallback(this.ConnectCallback), (object) NetworkPeeper.Sucket).CompletedSynchronously)
          return;
        this.ConnectCallback((IAsyncResult) null);
      }
    }
  }

  public void Login(MessagePacket MP)
  {
    switch (this.Result = MP.ReadByte())
    {
      case 0:
        NetworkPeeper.Stage = LoginPhase.LP_InGame;
        DataManager.MapDataController.FocusKingdomTime = MP.ReadULong();
        DataManager.MapDataController.FocusKingdomPeriod = (KINGDOM_PERIOD) MP.ReadByte();
        if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
          DataManager.MapDataController.OtherKingdomData.kingdomPeriod = DataManager.MapDataController.FocusKingdomPeriod;
        if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
          DataManager.MapDataController.kingdomData.kingdomPeriod = DataManager.MapDataController.FocusKingdomPeriod;
        this.ConnectTime = 0.0f;
        this.HeartBeat(15L);
        GameConstants.GetBytes(NetworkManager.GuestController.ID, DataManager.msgBuffer, 0);
        GameManager.OnGuestLogin();
        break;
      case 1:
        this.Resume();
        break;
      case 5:
        this.Drop();
        GameManager.OnRefresh(NetworkNews.GuestConnectFail);
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101U), DataManager.Instance.mStringTable.GetStringByID(911U));
        break;
      default:
        this.LostInSpace = true;
        break;
    }
  }

  private void ConnectCallback(IAsyncResult ar)
  {
    if (ar == null || NetworkPeeper.Sucket == null || NetworkPeeper.Sucket.Handle.ToInt32() == -1 || (Socket) ar.AsyncState != NetworkPeeper.Sucket)
      return;
    if (((Socket) ar.AsyncState).Connected && NetworkPeeper.Stage != LoginPhase.LP_Logging)
    {
      this.LifeProbing = true;
    }
    else
    {
      if (ar == null)
        return;
      try
      {
        NetworkPeeper.Sucket.EndConnect(ar);
      }
      catch
      {
      }
      this.LostInSpace = true;
    }
  }

  public void MakeBeat(MessagePacket MP, long time = 15)
  {
    NetworkPeeper.ServerTime = MP.ReadLong();
    this.BeatTime = (float) time;
    this.LinkTime = 0.0f;
  }

  public void HeartBeat(long time = 15)
  {
    this.BeatTime = 0.0f;
    this.LinkTime = (float) time;
    MessagePacket guestMessagePack = MessagePacket.GetGuestMessagePack();
    guestMessagePack.Protocol = Protocol._MSG_REQUEST_ACTIVE;
    guestMessagePack.AddSeqId();
    guestMessagePack.Send();
  }

  public static void Cipher(byte[] Codon, int Offset, int Size, int Durex = 0)
  {
    if (NetworkPeeper.Stage < LoginPhase.LP_Role || Durex <= 0)
      return;
    using (MemoryStream memoryStream = new MemoryStream(Codon, Offset, Size >> 3 << 3, false, false))
    {
      using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, NetworkManager.DES, CryptoStreamMode.Read))
        cryptoStream.Read(Codon, Offset, memoryStream.Capacity);
    }
  }

  public void CheckBuffer()
  {
    if (this.LostInSpace || (double) this.ConnectTime > 0.0 && (double) (this.ConnectTime -= NetworkManager.DeltaTime) <= 0.0 || (double) this.LinkTime > 0.0 && (double) (this.LinkTime -= NetworkManager.DeltaTime) <= 0.0)
    {
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101U), DataManager.Instance.mStringTable.GetStringByID(274U) + ":" + (object) this.Result);
      this.Drop(true);
    }
    else
    {
      if (!this.Connect() || NetworkPeeper.Sucket == null || !NetworkPeeper.Sucket.Connected)
        return;
      if ((double) this.BeatTime > 0.0 && (double) (this.BeatTime -= NetworkManager.DeltaTime) <= 0.0)
        this.HeartBeat(15L);
      if (NetworkPeeper.Sucket.Poll(0, SelectMode.SelectWrite) && NetworkPeeper.SendBuff.Count > 0)
        NetworkManager.SendSocket((MessagePacket) NetworkPeeper.SendBuff.Peek());
      while (NetworkPeeper.Sucket != null && NetworkPeeper.Sucket.Poll(0, SelectMode.SelectRead))
      {
        if (NetworkPeeper.read_pos >= 4096)
        {
          if (NetworkPeeper.parse_pos > 0)
            Buffer.BlockCopy((Array) NetworkPeeper.ReadData, NetworkPeeper.parse_pos, (Array) NetworkPeeper.ReadData, 0, NetworkPeeper.read_pos -= NetworkPeeper.parse_pos);
          else
            this.Drop(true);
          NetworkPeeper.parse_pos = 0;
          break;
        }
        int num1 = NetworkPeeper.Sucket.Receive(NetworkPeeper.ReadData, NetworkPeeper.read_pos, NetworkPeeper.ReadData.Length - NetworkPeeper.read_pos, SocketFlags.None, out NetworkManager.SucketError);
        if (num1 == 0)
        {
          this.Drop(true);
          break;
        }
        if (NetworkPeeper.read_pos + num1 > 4096)
          break;
        NetworkPeeper.read_pos += num1;
        while (NetworkPeeper.read_pos - NetworkPeeper.parse_pos >= 4)
        {
          ushort num2 = GameConstants.ConvertBytesToUShort(NetworkPeeper.ReadData, NetworkPeeper.parse_pos);
          if (num2 < (ushort) 4 || num2 > (ushort) 4096)
            NetworkPeeper.parse_pos += 4;
          else if ((int) num2 <= NetworkPeeper.read_pos - NetworkPeeper.parse_pos)
          {
            MessagePacket MP = new MessagePacket(ref NetworkPeeper.ReadData, NetworkPeeper.parse_pos + 4, (int) num2 - 4);
            MP.Protocol = (Protocol) GameConstants.ConvertBytesToUShort(NetworkPeeper.ReadData, NetworkPeeper.parse_pos + 2);
            NetworkManager.Cipher(NetworkPeeper.ReadData, MP.Data.GetIndex(), MP.Length);
            NetworkPeeper.parse_pos += (int) num2;
            DispatchManager.GuestDispatcher(MP);
          }
          else
            break;
        }
        if (NetworkPeeper.parse_pos > 0)
          Buffer.BlockCopy((Array) NetworkPeeper.ReadData, NetworkPeeper.parse_pos, (Array) NetworkPeeper.ReadData, 0, NetworkPeeper.read_pos -= NetworkPeeper.parse_pos);
        NetworkPeeper.parse_pos = 0;
      }
    }
  }
}
