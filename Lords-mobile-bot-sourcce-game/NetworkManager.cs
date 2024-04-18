// Decompiled with JetBrains decompiler
// Type: NetworkManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

#nullable disable
public class NetworkManager : IDisposable
{
  public const int Ivanhole = 5999;
  public const int VALIDATECODE = 25;
  public const byte TTL = 15;
  public const ushort SOCKET_BUFFER = 4096;
  protected string[] BlackHawkDown = new string[8]
  {
    "GameServer Down",
    "ProxyServer Down",
    "ProxyServer Drop",
    "KingdomServer Down",
    "DbServer Down",
    "Network Down",
    "Server Drop",
    "Servo Error"
  };
  public static string Ivan = GameConstants.IPMan[0];
  public static byte[] SessionKey;
  public static ICryptoTransform DES;
  private static NetworkPeeper guest = (NetworkPeeper) null;
  private static NetworkManager instance = (NetworkManager) null;
  public static string UserName;
  public static string UserPass;
  public static string AccountName;
  public static string AccountPass;
  public static string UDID;
  public static double ServerTime;
  public static float PickupTime;
  public static float SynchTime;
  public static float DeltaTime;
  public static float RealTime;
  public float BeatTime;
  public float LinkTime;
  public float LockTime;
  public float RetryTime;
  public float ReloadTime;
  public float FrozenTime;
  public float CheckTime;
  public float UpdateTime;
  public float RequestTime;
  public float ConnectTime;
  private bool ReplyConnect;
  public bool Refurbishment;
  private static Socket socket;
  private bool disposed;
  private static LoginPhase Stage;
  public static LoginPhase LastStage;
  private static UpdateController Updater;
  public static System.Collections.Queue SendBuff = new System.Collections.Queue();
  public static System.Collections.Queue RecvBuff = new System.Collections.Queue();
  public static bool Sending = false;
  public static bool Receive = false;
  public static bool Recving = false;
  public static List<MessageBuff> SendList = new List<MessageBuff>(1);
  public static byte[] ReadData = new byte[4096];
  public static byte[] SendData = new byte[4096];
  public static int read_pos;
  public static int parse_pos;
  public static int write_pos;
  private static long JudgmentDay;
  private static bool Armageddon;
  private static bool Bizarre;
  private static bool DieHard;
  private static bool Ragnarok;
  private static bool Godspeed;
  private static bool Inception;
  private static bool Connecting;
  private static bool CallOfDirty;
  private static bool RestInPiss = false;
  private static bool LostInSpace;
  private static bool MatrixReboot;
  private static bool MatrixReloaded;
  private static string ServerIP;
  private static int ServerPort;
  public static byte ServerNum;
  public static string[] RoyalHost;
  public static byte[] Veronica = new byte[25];
  public static uint Version;
  public static long UserID;
  public static long LogID;
  public static long PlayerID;
  public static uint ServerID;
  public static int Sequence;
  public static string IP;
  public static IPEndPoint EndPoint;
  public static SocketError SucketError;
  public static LingerOption LOL = new LingerOption(false, 0);
  public static SocketAsyncEventArgs SendSAEA = new SocketAsyncEventArgs();
  public static DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();
  public static AddressFamily nowAddressFamily = AddressFamily.InterNetwork;
  public static bool AutoLogin;

  private NetworkManager()
  {
    NetworkManager.Crypto.BlockSize = 64;
    NetworkManager.Crypto.FeedbackSize = 8;
    NetworkManager.Crypto.Mode = CipherMode.ECB;
    NetworkManager.Crypto.Padding = PaddingMode.None;
    NetworkManager.DES = NetworkManager.Crypto.CreateEncryptor(Encoding.ASCII.GetBytes("L*#)@!&8"), Encoding.UTF8.GetBytes("JeffHappy"));
    NetworkManager.SessionKey = new byte[128];
  }

  static NetworkManager()
  {
    NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999);
    NetworkManager.SendList.Add(new MessageBuff(4096));
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  private void Dispose(bool disposing)
  {
    if (this.disposed)
      return;
    if (NetworkManager.socket != null)
    {
      if (NetworkManager.socket.Connected)
        NetworkManager.socket.Shutdown(SocketShutdown.Both);
      NetworkManager.socket.Close();
      NetworkManager.socket = (Socket) null;
    }
    this.disposed = true;
  }

  public static NetworkPeeper GuestController
  {
    get
    {
      if (NetworkManager.guest == null)
        NetworkManager.guest = new NetworkPeeper();
      return NetworkManager.guest;
    }
  }

  public static NetworkManager Instance
  {
    get
    {
      if (NetworkManager.instance == null)
        NetworkManager.instance = new NetworkManager();
      return NetworkManager.instance;
    }
  }

  public static void Destroy()
  {
    if (NetworkManager.Instance != null)
      NetworkManager.Instance.Dispose();
    DownloadController.Reset();
  }

  public static DateTime GetDateTime(long Time)
  {
    return DateTime.FromBinary(Time * 10000000L + 621355968000000000L).ToLocalTime();
  }

  public static void EnterTheMatrix(string IP, int Port, bool blinklogin = true)
  {
    if (Port == 5999 && GameConstants.IPMan.Length > 1)
      IP = GameConstants.IPMan[UnityEngine.Random.Range(0, GameConstants.IPMan.Length)];
    CString CStr = StringManager.Instance.StaticString1024();
    CStr.ClearString();
    GameConstants.GetHostName(CStr, IP, !blinklogin ? "lm-proxy-" : "lm-login-");
    NetworkManager.ServerIP = IP;
    IPAddress[] ipAddressArray1 = (IPAddress[]) null;
    try
    {
      ipAddressArray1 = Dns.GetHostAddresses(CStr.ToString());
    }
    catch (Exception ex)
    {
      Debug.Log((object) ("[EnterTheMatrix]:" + ex.Message));
    }
    NetworkManager.SendSAEA.RemoteEndPoint = (System.Net.EndPoint) null;
    if (ipAddressArray1 == null)
    {
      IPAddress[] ipAddressArray2 = new IPAddress[1];
      if (IPAddress.TryParse(IP, out ipAddressArray2[0]))
      {
        NetworkManager.ServerIP = ipAddressArray2[0].ToString();
        NetworkManager.nowAddressFamily = ipAddressArray2[0].AddressFamily;
        NetworkManager.SendSAEA.RemoteEndPoint = (System.Net.EndPoint) new IPEndPoint(ipAddressArray2[0], Port);
      }
    }
    else if (ipAddressArray1.Length > 0 && ipAddressArray1[0] != null)
    {
      NetworkManager.ServerIP = ipAddressArray1[0].ToString();
      NetworkManager.nowAddressFamily = ipAddressArray1[0].AddressFamily;
      NetworkManager.SendSAEA.RemoteEndPoint = (System.Net.EndPoint) new IPEndPoint(ipAddressArray1[0], Port);
    }
    NetworkManager.MatrixReloaded = NetworkManager.Armageddon = false;
    CStr.ClearString();
  }

  public static bool Miss() => true;

  public static bool LetmeIn()
  {
    if (NetworkManager.LogID > 0L)
    {
      if (NetworkManager.UDID != string.Empty)
        UpdateController.OnIGGLogin();
      else
        NetworkManager.Instance.SetStage(LoginPhase.LP_Connecting, NetworkManager.LogID);
      return false;
    }
    if (NetworkManager.AutoLogin)
      UpdateController.OnIGGLogin();
    return true;
  }

  public static void LetmeOut(long Please = 0)
  {
    NetworkManager.Instance.SetStage(LoginPhase.LP_Fallout, Please);
  }

  public static void LogmeIn(string IGG, string Asskey)
  {
    NetworkManager.Godspeed = true;
    NetworkManager.UserPass = IGG;
    if ((NetworkManager.LastStage == LoginPhase.LP_Retry || NetworkManager.LastStage == LoginPhase.LP_IGG) && !NetworkManager.OnRecover() || !NetworkManager.Connecting && NetworkManager.OnRecover() || NetworkManager.Stage != LoginPhase.LP_Disconnect && NetworkManager.Stage != LoginPhase.LP_Fail && NetworkManager.Stage != LoginPhase.LP_OffGrid)
      return;
    if (Asskey != null && long.TryParse(IGG, out NetworkManager.LogID) && (NetworkManager.UDID = Asskey).Length >= 0)
      NetworkManager.Instance.SetStage(LoginPhase.LP_Connecting, NetworkManager.LogID);
    else
      UpdateController.OnIGGLogin(IGGLoginCode.None);
  }

  public static void LetmeIn(string Why, byte Not = 0)
  {
    GameManager.OnRefresh(NetworkNews.Fallout);
    GUIManager.Instance.HideUILock(EUILock.All);
    GUIManager.Instance.CloseOKCancelBox();
    NetworkManager.Connecting = false;
    if (NetworkManager.OnRecover())
    {
      NetworkManager.LastStage = LoginPhase.LP_Retry;
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101U), Not <= (byte) 0 ? Why : UpdateController.MessageReturner, 2, DataManager.Instance.mStringTable.GetStringByID(103U), bCloseIDSet: true);
    }
    else
    {
      NetworkManager.LastStage = LoginPhase.LP_IGG;
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101U), Not <= (byte) 0 ? Why : UpdateController.MessageReturner, 2, !NetworkManager.RestInPiss ? (NetworkManager.Stage != LoginPhase.LP_EpicFail ? (string) null : DataManager.Instance.mStringTable.GetStringByID(103U)) : DataManager.Instance.mStringTable.GetStringByID(10062U), bCloseIDSet: true);
    }
  }

  public static void Resume(bool Resume)
  {
    if ((NetworkManager.RestInPiss || !Resume && (NetworkManager.LastStage == LoginPhase.LP_IGG || NetworkManager.LastStage == LoginPhase.LP_Retry)) && !NetworkManager.CallOfDirty || (!Resume || GameManager.ActiveGameplay is UpdateController) && NetworkManager.CallOfDirty)
      Application.Quit();
    else if (NetworkManager.Stage == LoginPhase.LP_EpicFail)
    {
      NetworkManager.LastStage = LoginPhase.LP_Pending;
      DataManager.msgBuffer[0] = (byte) 1;
      DataManager.msgBuffer[1] = (byte) 28;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else if (UpdateController.WebClient.FileError)
      UpdateController.OnIGGLogin();
    else if (UpdateController.WebClient.FileLength > 0L)
      UpdateController.WebClient.Processed = true;
    else if (Resume && !NetworkManager.CallOfDirty)
      NetworkManager.MatrixReloaded = true;
    else
      NetworkManager.MatrixReboot = true;
  }

  public static void LockMe(bool On = true)
  {
    GUIManager.Instance.HideUILock(EUILock.Network);
    if (!On)
      return;
    GUIManager.Instance.ShowUILock(EUILock.Network);
  }

  public static void Freeze(bool Frosty)
  {
    if (NetworkManager.Stage == LoginPhase.LP_Auto && Frosty)
      return;
    NetworkManager.Instance.FrozenTime = !Frosty ? 0.0f : 15f;
  }

  public static void MakeBeat(long time = 15)
  {
    NetworkManager.ServerTime = (double) DataManager.Instance.ServerTime;
    NetworkManager.PickupTime = Time.realtimeSinceStartup;
    NetworkManager.instance.BeatTime = (float) time;
    NetworkManager.Instance.LinkTime = 0.0f;
  }

  public static void HeartBeat()
  {
    NetworkManager.instance.BeatTime = 0.0f;
    NetworkManager.instance.LinkTime = 10f;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public static void TimeOut()
  {
    if (NetworkManager.LastStage == LoginPhase.LP_Retry || NetworkManager.LastStage == LoginPhase.LP_IGG)
      return;
    NetworkManager.MatrixReloaded = true;
  }

  public static Buffer<byte> RetrieveSize(int len)
  {
    if (len > 4096 - NetworkManager.write_pos)
      return new Buffer<byte>(len);
    Buffer<byte> buffer = new Buffer<byte>(NetworkManager.SendData, NetworkManager.write_pos, len);
    NetworkManager.write_pos += len;
    return buffer;
  }

  public static bool OnReady()
  {
    return NetworkManager.nowAddressFamily == AddressFamily.InterNetworkV6 || Application.internetReachability != NetworkReachability.NotReachable;
  }

  public static bool Connected() => NetworkManager.Stage == LoginPhase.LP_InGame;

  public static void Send(MessagePacket MP) => NetworkManager.SendBuff.Enqueue((object) MP);

  public static void Cipher(byte[] Codon, int Offset, int Size, int Durex = 0)
  {
    if (NetworkManager.Stage < LoginPhase.LP_Role || Durex <= 0)
      return;
    using (MemoryStream memoryStream = new MemoryStream(Codon, Offset, Size >> 3 << 3, false, false))
    {
      using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, NetworkManager.DES, CryptoStreamMode.Read))
        cryptoStream.Read(Codon, Offset, memoryStream.Capacity);
    }
  }

  public static void Reload(bool isPause = true)
  {
    if (NetworkManager.LastStage == LoginPhase.LP_Retry || NetworkManager.LastStage == LoginPhase.LP_IGG || NetworkManager.Stage <= LoginPhase.LP_Disconnect || NetworkManager.Connecting || (double) NetworkManager.Instance.ConnectTime != 0.0 || IGGGameSDK.Instance.NotConnect)
      return;
    NetworkManager.MatrixReloaded = true;
  }

  public static bool OnContinue() => NetworkManager.DieHard || NetworkManager.OnRecover();

  public static bool OnRecover()
  {
    return (NetworkManager.LastStage == LoginPhase.LP_InGame || NetworkManager.LastStage == LoginPhase.LP_Role || NetworkManager.LastStage == LoginPhase.LP_Retry) && !NetworkManager.CallOfDirty;
  }

  public static void OnDrop() => NetworkManager.Instance.SetStage(LoginPhase.LP_OffGrid, 0L);

  public static void Messenger(long Id, byte type = 0)
  {
    NetworkManager.Messenger(DataManager.Instance.mStringTable.GetStringByID((uint) Id), type);
  }

  public static void Messenger(string Msg, byte type = 0)
  {
    GUIManager.Instance.AddHUDMessage(Msg, (ushort) type);
  }

  public static void Login(MessagePacket Mp)
  {
    NetworkManager.ServerPort = Mp.ReadInt();
    NetworkManager.UserID = Mp.ReadLong();
    NetworkManager.ServerIP = Mp.ReadString(16);
    NetworkManager.Disconnect();
    NetworkManager.EnterTheMatrix(NetworkManager.ServerIP, NetworkManager.ServerPort, false);
    NetworkManager.Instance.SetStage(LoginPhase.LP_Logging, 0L);
  }

  public void SetStage(LoginPhase Phase, long Kind = 0, bool Force = false)
  {
    if (NetworkManager.Stage == Phase && Phase != LoginPhase.LP_Updating || Phase == LoginPhase.LP_ReEntry && (AssetManager.Instance.AssetManagerState < AssetState.Run || GameManager.ActiveGameplay == null))
      return;
    NetworkManager.Stage = Phase;
    switch (NetworkManager.Stage)
    {
      case LoginPhase.LP_Checking:
        this.CheckTime = 5f;
        AssetManager.Instance.AssetManagerState = AssetState.Load;
        long.TryParse(PlayerPrefs.GetString("UserID"), out NetworkManager.UserID);
        break;
      case LoginPhase.LP_Updating:
        this.CheckTime = 5f;
        this.UpdateTime = 15f;
        break;
      case LoginPhase.LP_Preparing:
        this.CheckTime = this.UpdateTime = 0.0f;
        break;
      case LoginPhase.LP_Disconnect:
      case LoginPhase.LP_ReConnect:
        this.Refurbishment = this.ReplyConnect;
        NetworkManager.MatrixReloaded = NetworkManager.CallOfDirty = false;
        int num1;
        NetworkManager.parse_pos = num1 = 0;
        NetworkManager.read_pos = num1;
        this.BeatTime = this.LinkTime = this.LockTime = this.FrozenTime = this.RetryTime = (float) num1;
        NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999);
        MessagePacket.Clear();
        NetworkManager.Disconnect();
        if (NetworkManager.OnRecover() || NetworkManager.DieHard)
        {
          UpdateController.OnIGGLogin();
          break;
        }
        NetworkManager.LockMe(false);
        if ((NetworkManager.LastStage == LoginPhase.LP_IGG || NetworkManager.Connecting || this.Refurbishment) && !NetworkManager.MatrixReboot)
        {
          UpdateController.OnIGGLogin();
          break;
        }
        NetworkManager.LastStage = NetworkManager.Stage = LoginPhase.LP_Disconnect;
        break;
      case LoginPhase.LP_Connecting:
        NetworkManager.UserID = Kind;
        this.BeatTime = this.LinkTime = 0.0f;
        NetworkManager.Inception = NetworkManager.DieHard = false;
        NetworkManager.CallOfDirty = NetworkManager.Connecting = false;
        if (NetworkManager.OnReady())
        {
          NetworkManager.ConnectEx();
          break;
        }
        this.SetStage(LoginPhase.LP_Fail, 31L);
        break;
      case LoginPhase.LP_Connected:
        this.ConnectTime = 15f;
        this.ReplyConnect = false;
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_LOGIN_LOGINTOL;
        messagePacket1.Add(NetworkManager.UserID);
        messagePacket1.Add((byte) GameConstants.Version[1]);
        messagePacket1.Add((byte) GameConstants.Version[0]);
        messagePacket1.Add(GameConstants.Version[2]);
        messagePacket1.Add((byte) NetworkManager.UDID.Length);
        messagePacket1.Add(NetworkManager.UDID, NetworkManager.SessionKey.Length);
        messagePacket1.Add((byte) 1);
        messagePacket1.Add((byte) DataManager.Instance.UserLanguage);
        messagePacket1.Send(true);
        break;
      case LoginPhase.LP_ReEntry:
        Application.Quit();
        this.SetStage(LoginPhase.LP_Fallout, 0L);
        this.SetStage(LoginPhase.LP_Disconnect, 0L);
        Camera.main.backgroundColor = Color.clear;
        GameManager.SwitchGameplay(GameplayKind.Update);
        int num2;
        NetworkManager.RestInPiss = (num2 = 0) != 0;
        NetworkManager.MatrixReboot = num2 != 0;
        NetworkManager.MatrixReloaded = num2 != 0;
        break;
      case LoginPhase.LP_Logging:
        NetworkManager.ConnectEx();
        MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
        messagePacket2.Protocol = Protocol._MSG_LOGIN_LOGINTOP;
        messagePacket2.Add(NetworkManager.UserID);
        messagePacket2.Add(NetworkManager.Version);
        messagePacket2.Add(DataManager.Instance.BattleSeqID == 0UL ? (byte) 0 : (byte) 1);
        messagePacket2.Add(DataManager.Instance.bRecvKingdom);
        messagePacket2.Add((byte) NetworkManager.UDID.Length);
        messagePacket2.Add(NetworkManager.UDID, NetworkManager.SessionKey.Length);
        messagePacket2.Add(SocialManager.Instance.InviterIGGId);
        messagePacket2.Add(SocialManager.Instance.InviterName, 41);
        messagePacket2.Send(true);
        break;
      case LoginPhase.LP_Login:
        if (Kind == 0L)
        {
          this.SetStage(LoginPhase.LP_Role, 0L);
          break;
        }
        if (Kind == 8L)
        {
          this.SetStage(LoginPhase.LP_KickAss, 0L);
          break;
        }
        NetworkManager.RestInPiss = NetworkManager.CallOfDirty = Kind == 110L;
        if (Kind == 9L || Kind == 14L)
        {
          this.SetStage(LoginPhase.LP_KissAss, Kind != 9L ? 999L : 109L, true);
          break;
        }
        this.SetStage(LoginPhase.LP_Fail, 100L + Kind);
        break;
      case LoginPhase.LP_Logon:
        if (NetworkManager.OnRecover())
          NetworkManager.Stage = LoginPhase.LP_Disconnect;
        else
          NetworkManager.LastStage = NetworkManager.Stage = LoginPhase.LP_Disconnect;
        NetworkManager.LockMe();
        NetworkManager.Connecting = true;
        UpdateController.OnIGGLogin(true);
        break;
      case LoginPhase.LP_Role:
        NetworkManager.CheckRole();
        break;
      case LoginPhase.LP_Auto:
        NetworkManager.AutoLogin = true;
        this.ReplyConnect = false;
        if (NetworkManager.OnReady() || Kind > 0L || Force)
        {
          NetworkManager.LockMe();
          NetworkManager.Connecting = true;
          if (NetworkManager.OnRecover())
          {
            NetworkManager.Stage = LoginPhase.LP_Disconnect;
            break;
          }
          NetworkManager.LastStage = NetworkManager.Stage = LoginPhase.LP_Disconnect;
          break;
        }
        this.SetStage(LoginPhase.LP_Fail, 31L);
        break;
      case LoginPhase.LP_BBS:
        NetworkManager.Connecting = false;
        NetworkManager.LastStage = LoginPhase.LP_Fail;
        this.SetStage(LoginPhase.LP_Disconnect, 0L);
        GUIManager.Instance.CloseOKCancelBox();
        break;
      case LoginPhase.LP_GG:
        NetworkManager.LastStage = NetworkManager.Stage;
        NetworkManager.RestInPiss = Force;
        this.ConnectTime = this.FrozenTime = this.LinkTime = this.LockTime = this.BeatTime = this.RetryTime = 0.0f;
        NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999);
        NetworkManager.Disconnect();
        NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10056U), (object) Kind), (byte) 0);
        break;
      case LoginPhase.LP_InGame:
        NetworkManager.SendOK();
        this.ConnectTime = (float) (NetworkManager.JudgmentDay = 0L);
        PlayerPrefs.SetInt("Inception", 0);
        PlayerPrefs.SetString("UserID", NetworkManager.UserID.ToString());
        DataManager.StageDataController.CheckFirstInChapter();
        if ((long) DataManager.Instance.RoleAttr.BattleID != (long) DataManager.Instance.BattleSeqID)
          GameManager.OnRefresh(NetworkNews.Refresh_BattleFail);
        if (NetworkManager.OnRecover())
        {
          GUIManager.Instance.HideUILock(EUILock.All);
          GameManager.OnRefresh(NetworkNews.Login);
        }
        else
          GameManager.OnLogin();
        NetworkManager.LastStage = NetworkManager.Stage;
        break;
      case LoginPhase.LP_OnLine:
        NetworkManager.Inception = true;
        this.ConnectTime = 0.0f;
        NetworkManager.SendOK();
        break;
      case LoginPhase.LP_OffGrid:
        this.BeatTime = this.LinkTime = this.LockTime = this.FrozenTime = this.RetryTime = 0.0f;
        NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999);
        NetworkManager.Disconnect();
        this.ConnectTime = this.BeatTime = 0.0f;
        if (NetworkManager.DieHard)
        {
          NetworkManager.MatrixReloaded = true;
          break;
        }
        if (Kind == 0L && !Force)
        {
          NetworkManager.LetmeIn(string.Format("{0}: {1}{2}{3}", (object) DataManager.Instance.mStringTable.GetStringByID(108U), (object) NetworkManager.ServerPort, (object) (NetworkManager.Sequence <= NetworkManager.ServerPort ? (NetworkManager.Sequence != NetworkManager.ServerPort ? 1 : 0) : 0), (object) (!NetworkManager.Bizarre ? 0 : 1)), (byte) 0);
          break;
        }
        NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(!Force ? 108U : (Kind <= 0L ? 109U : (uint) Kind)), !Force || Kind > 0L ? (byte) 0 : (byte) 1);
        break;
      case LoginPhase.LP_KickAss:
        NetworkManager.MatrixReloaded = true;
        NetworkManager.DieHard = true;
        break;
      case LoginPhase.LP_KissAss:
        NetworkManager.CallOfDirty = !Force;
        NetworkManager.RestInPiss = Force;
        NetworkManager.LastStage = NetworkManager.Stage;
        this.SetStage(LoginPhase.LP_OffGrid, Kind, true);
        break;
      case LoginPhase.LP_Fallout:
        if (Kind > 0L)
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(103U), DataManager.Instance.mStringTable.GetStringByID(826U));
        if (NetworkManager.LastStage == LoginPhase.LP_IGG)
          break;
        NetworkManager.LastStage = LoginPhase.LP_Fail;
        break;
      case LoginPhase.LP_EpicFail:
        this.UpdateTime = 0.0f;
        DataManager.msgBuffer[0] = (byte) 1;
        DataManager.msgBuffer[1] = (byte) 27;
        DataManager.msgBuffer[2] = (byte) Kind;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        if (!Force)
          break;
        NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(8474U), (byte) 0);
        break;
      case LoginPhase.LP_Fatal:
        this.SetStage(LoginPhase.LP_Fail, 10055L, Force);
        break;
      case LoginPhase.LP_Fail:
        NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999);
        NetworkManager.Disconnect();
        this.ConnectTime = this.BeatTime = 0.0f;
        if (Kind > 10000L)
        {
          NetworkManager.LetmeIn(string.Format("{0}: {1}{2}{3}{4}", (object) DataManager.Instance.mStringTable.GetStringByID((uint) Kind), (object) (!Force ? 2 : 1), (object) (!NetworkManager.Ragnarok ? (NetworkManager.Sequence <= NetworkManager.ServerPort ? 1 : 0) : 2), (object) (!NetworkManager.Ragnarok ? 0 : (NetworkManager.Sequence <= NetworkManager.ServerPort ? 1 : 0)), (object) (!NetworkManager.Bizarre ? 0 : 1)), (byte) 0);
          break;
        }
        if (Kind > 200L)
        {
          NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID((long) UpdateController.UpdateFallback != (Kind -= 100L) ? (uint) Kind : 8474U), (byte) 0);
          break;
        }
        if (Kind >= 100L || Force && Kind > 1L)
        {
          NetworkManager.JudgmentDay = Kind;
          switch (Kind)
          {
            case 102:
              NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(912U), (byte) 0);
              return;
            case 103:
              NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10058U), (object) (Kind -= 100L), (object) DataManager.Instance.mStringTable.GetStringByID(10054U)), (byte) 0);
              return;
            case 106:
              NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(57U), (byte) 0);
              return;
            case 110:
              NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10058U), (object) (Kind -= 100L), (object) DataManager.Instance.mStringTable.GetStringByID(10052U)), (byte) 0);
              return;
            case 113:
              NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(998U), (byte) 0);
              return;
            case 115:
              NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10058U), (object) (Kind -= 100L), (object) DataManager.Instance.mStringTable.GetStringByID(10053U)), (byte) 0);
              return;
            default:
              NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10056U), (object) (Kind -= 100L)), (byte) 0);
              return;
          }
        }
        else
        {
          if (Kind > 10L)
          {
            NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(102U), (byte) 0);
            break;
          }
          if (Kind > 1L)
          {
            NetworkManager.LetmeIn(this.BlackHawkDown[0], (byte) 1);
            break;
          }
          if (Kind == 1L && NetworkManager.JudgmentDay == 113L)
          {
            NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(998U), (byte) 0);
            break;
          }
          if (Kind > 0L || !NetworkManager.OnRecover())
          {
            NetworkManager.LetmeIn(string.Format("{0}: {1}{2}{3}{4}", (object) DataManager.Instance.mStringTable.GetStringByID(107U), (object) NetworkManager.ServerPort, (object) (!Force ? (NetworkManager.Sequence <= NetworkManager.ServerPort ? 1 : 0) : 2), (object) (NetworkManager.Sequence <= NetworkManager.ServerPort ? (NetworkManager.Sequence != NetworkManager.ServerPort ? 1 : 0) : 0), (object) (!NetworkManager.Bizarre ? 0 : 1)), (byte) 0);
            break;
          }
          NetworkManager.MatrixReboot = true;
          break;
        }
      case LoginPhase.LP_Lost:
        if (NetworkManager.CallOfDirty)
          break;
        this.SetStage(LoginPhase.LP_Login, 110L);
        break;
    }
  }

  public static void SendName(string name)
  {
    ushort data1 = 0;
    byte data2 = 1;
    NetworkManager.UserName = "南港隊長Sucks";
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_CREATEROLE;
    messagePacket.AddSeqId();
    messagePacket.Add(NetworkManager.UserID);
    messagePacket.Add(NetworkManager.UserName, 13);
    messagePacket.Add(data1);
    messagePacket.Add(data2);
    messagePacket.Send();
  }

  public static void SendOK()
  {
    NetworkManager.instance.LinkTime = 0.0f;
    NetworkManager.instance.BeatTime = 15f;
    long serverTime = DataManager.Instance.RoleAttr.ServerTime;
    DataManager.Instance.ServerTime = serverTime;
    NetworkManager.ServerTime = (double) serverTime;
    NetworkManager.PickupTime = Time.realtimeSinceStartup;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_CLIENTINITOVER;
    messagePacket.AddSeqId();
    messagePacket.Add(NetworkManager.UserID);
    messagePacket.Send();
  }

  public static void CheckRole()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Add(NetworkManager.UserID);
    messagePacket.Add(DataManager.Instance.BattleSeqID == 0UL ? (byte) 0 : (byte) 1);
    messagePacket.Send();
  }

  public static void ConnectEx()
  {
    try
    {
      NetworkManager.LockMe();
      if (NetworkManager.socket != null)
        NetworkManager.Disconnect();
      NetworkManager.Instance.ConnectTime = (float) (NetworkManager.Sequence = 15);
      NetworkManager.Bizarre = NetworkManager.ServerIP.Equals("69.25.100.20");
      NetworkManager.ServerPort = NetworkManager.Stage != LoginPhase.LP_Connecting ? 2 : 1;
      if (NetworkManager.SendSAEA.RemoteEndPoint == null)
      {
        NetworkManager.Armageddon = NetworkManager.Ragnarok = true;
      }
      else
      {
        NetworkManager.Ragnarok = false;
        NetworkManager.socket = new Socket(NetworkManager.nowAddressFamily, SocketType.Stream, ProtocolType.Tcp)
        {
          Blocking = false,
          SendTimeout = 0,
          ReceiveTimeout = 0
        };
        try
        {
          NetworkManager.socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, true);
          NetworkManager.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, (object) NetworkManager.LOL);
        }
        catch
        {
        }
        finally
        {
          if (NetworkManager.socket.BeginConnect(NetworkManager.SendSAEA.RemoteEndPoint, new AsyncCallback(NetworkManager.ConnectCallback), (object) NetworkManager.socket).CompletedSynchronously)
            NetworkManager.ConnectCallback((IAsyncResult) null);
        }
      }
    }
    catch
    {
      NetworkManager.Armageddon = NetworkManager.Ragnarok = true;
    }
  }

  private static void ConnectCallback(IAsyncResult ar)
  {
    try
    {
      if (NetworkManager.Armageddon || ar == null || NetworkManager.socket == null || NetworkManager.socket.Handle.ToInt32() == -1 || (Socket) ar.AsyncState != NetworkManager.socket)
        return;
      NetworkManager.Instance.ConnectTime = (float) (NetworkManager.Sequence = 0);
      if (((Socket) ar.AsyncState).Connected)
      {
        if (NetworkManager.Stage != LoginPhase.LP_Logging)
          NetworkManager.Instance.ReplyConnect = true;
        else
          NetworkManager.Instance.ConnectTime = 15f;
        try
        {
          NetworkManager.socket.EndConnect(ar);
        }
        catch
        {
        }
      }
      else
      {
        if (NetworkManager.Armageddon)
        {
          if (ar == null)
            return;
        }
        try
        {
          if (ar == null)
            return;
          NetworkManager.socket.EndConnect(ar);
        }
        catch
        {
        }
        finally
        {
          NetworkManager.LostInSpace = true;
        }
      }
    }
    catch
    {
      NetworkManager.Armageddon = true;
    }
  }

  public static void SendSocket(MessagePacket pak)
  {
    if (NetworkPeeper.Stage < LoginPhase.LP_Connected || pak == null || pak.Length <= pak.Offset)
      return;
    pak.Offset += NetworkPeeper.Sucket.Send(pak.Data.GetBuffer(), pak.Data.GetIndex(pak.Offset), pak.Length - pak.Offset, SocketFlags.None, out NetworkManager.SucketError);
    if (pak.Length > pak.Offset)
      return;
    NetworkPeeper.SendBuff.Dequeue();
    NetworkManager.Cleansing();
  }

  public static void Cleansing()
  {
    if (NetworkPeeper.SendBuff.Count != 0 || NetworkManager.SendBuff.Count != 0)
      return;
    NetworkManager.write_pos = 0;
  }

  public static void Disconnect()
  {
    NetworkManager.Instance.ConnectTime = 0.0f;
    NetworkManager.write_pos = 0;
    if (NetworkManager.socket != null)
    {
      NetworkManager.socket.Close();
      NetworkManager.socket = (Socket) null;
    }
    NetworkManager.Instance.ReplyConnect = NetworkManager.Sending = false;
    NetworkManager.LostInSpace = NetworkManager.Armageddon = false;
    NetworkManager.SendBuff.Clear();
    MessagePacket.Clear();
    NetworkManager.GuestController.Drop();
    NetworkManager.Stage = LoginPhase.LP_Disconnect;
  }

  public static void SendPacket(MessagePacket pak)
  {
    if (NetworkManager.Stage < LoginPhase.LP_Connected || pak == null)
      return;
    if (pak.Length > pak.Offset)
    {
      NetworkManager.Sending = true;
      pak.Offset += NetworkManager.socket.Send(pak.Data.GetBuffer(), pak.Data.GetIndex(pak.Offset), pak.Length - pak.Offset, SocketFlags.None, out SocketError _);
      if (pak.Length > pak.Offset)
        return;
      if (pak.Protocol == Protocol._MSG_LOGIN_LOGINTOL || pak.Protocol == Protocol._MSG_LOGIN_LOGINTOP)
        NetworkManager.Sequence = NetworkManager.ServerPort;
      NetworkManager.SendBuff.Dequeue();
      if (NetworkPeeper.SendBuff.Count == 0 && NetworkManager.SendBuff.Count == 0)
        NetworkManager.write_pos = 0;
      NetworkManager.Sending = false;
    }
    else
      NetworkManager.Sending = false;
  }

  public static void CheckBuffer()
  {
    try
    {
      NetworkManager.GuestController.CheckBuffer();
      if (NetworkManager.socket == null || !NetworkManager.socket.Connected)
        return;
      if (NetworkManager.socket.Poll(0, SelectMode.SelectWrite) && NetworkManager.SendBuff.Count > 0)
        NetworkManager.SendPacket((MessagePacket) NetworkManager.SendBuff.Peek());
      while (NetworkManager.socket != null && NetworkManager.socket.Poll(0, SelectMode.SelectRead))
      {
        if (NetworkManager.read_pos >= 4096)
        {
          if (NetworkManager.parse_pos > 0)
            Buffer.BlockCopy((Array) NetworkManager.ReadData, NetworkManager.parse_pos, (Array) NetworkManager.ReadData, 0, NetworkManager.read_pos -= NetworkManager.parse_pos);
          else
            NetworkManager.Resume(true);
          NetworkManager.parse_pos = 0;
          break;
        }
        int num1 = NetworkManager.socket.Receive(NetworkManager.ReadData, NetworkManager.read_pos, NetworkManager.ReadData.Length - NetworkManager.read_pos, SocketFlags.None, out SocketError _);
        if (num1 == 0)
        {
          NetworkManager.OnDrop();
          break;
        }
        if (NetworkManager.read_pos + num1 > 4096)
          break;
        NetworkManager.read_pos += num1;
        while (NetworkManager.read_pos - NetworkManager.parse_pos >= 4)
        {
          ushort num2 = GameConstants.ConvertBytesToUShort(NetworkManager.ReadData, NetworkManager.parse_pos);
          if (num2 < (ushort) 4 || num2 > (ushort) 4096)
            NetworkManager.parse_pos += 4;
          else if ((int) num2 <= NetworkManager.read_pos - NetworkManager.parse_pos)
          {
            MessagePacket MP = new MessagePacket(ref NetworkManager.ReadData, NetworkManager.parse_pos + 4, (int) num2 - 4);
            MP.Protocol = (Protocol) GameConstants.ConvertBytesToUShort(NetworkManager.ReadData, NetworkManager.parse_pos + 2);
            NetworkManager.Cipher(NetworkManager.ReadData, MP.Data.GetIndex(), MP.Length);
            NetworkManager.parse_pos += (int) num2;
            DispatchManager.Dispatcher(MP);
          }
          else
            break;
        }
        if (NetworkManager.parse_pos > 0)
          Buffer.BlockCopy((Array) NetworkManager.ReadData, NetworkManager.parse_pos, (Array) NetworkManager.ReadData, 0, NetworkManager.read_pos -= NetworkManager.parse_pos);
        NetworkManager.parse_pos = 0;
      }
    }
    catch
    {
      NetworkManager.parse_pos = NetworkManager.read_pos = 0;
    }
  }

  private static void ProcessSend(SocketAsyncEventArgs e)
  {
    MessagePacket userToken = e.UserToken as MessagePacket;
    userToken.Offset += e.BytesTransferred;
    if (userToken.Length > userToken.Offset)
    {
      NetworkManager.SendPacket(userToken);
    }
    else
    {
      NetworkManager.SendBuff.Dequeue();
      NetworkManager.Sending = false;
      NetworkManager.CheckBuffer();
    }
  }

  private static void ProcessReceive(SocketAsyncEventArgs e)
  {
    if (e.BytesTransferred <= 0 || NetworkManager.read_pos + e.BytesTransferred > 4096)
      return;
    Buffer.BlockCopy((Array) e.Buffer, 0, (Array) NetworkManager.ReadData, NetworkManager.read_pos, e.BytesTransferred);
    int num = (int) GameConstants.ConvertBytesToUShort(NetworkManager.ReadData, NetworkManager.parse_pos);
    NetworkManager.read_pos += e.BytesTransferred;
    if (num <= NetworkManager.read_pos - NetworkManager.parse_pos)
      NetworkManager.parse_pos += num;
    if (NetworkManager.socket.ReceiveAsync(e))
      return;
    NetworkManager.ProcessReceive(e);
  }

  private static void IO_Completed(object sender, SocketAsyncEventArgs e)
  {
    switch (e.LastOperation)
    {
      case SocketAsyncOperation.Receive:
        if (e.SocketError != SocketError.Success)
          break;
        NetworkManager.ProcessReceive(e);
        break;
      case SocketAsyncOperation.Send:
        if (e.SocketError != SocketError.Success)
          break;
        NetworkManager.ProcessSend(e);
        break;
    }
  }

  public void Update()
  {
    NetworkManager.DeltaTime = -NetworkManager.RealTime + (NetworkManager.RealTime = Time.realtimeSinceStartup);
    if (NetworkManager.ServerTime > 0.0)
    {
      NetworkManager.ServerTime += (double) NetworkManager.DeltaTime;
      if ((double) (NetworkManager.SynchTime = NetworkManager.RealTime - NetworkManager.PickupTime) >= 1.0)
      {
        DataManager.Instance.ServerTime = (long) NetworkManager.ServerTime;
        NetworkManager.PickupTime = NetworkManager.RealTime;
      }
    }
    DownloadController.Check();
    DataManager.Instance.Update();
    if (NetworkManager.MatrixReboot)
      this.SetStage(LoginPhase.LP_ReEntry, 0L);
    else if ((NetworkManager.MatrixReloaded || NetworkManager.Connected() && (double) this.LockTime > 0.0 && (double) (this.LockTime -= NetworkManager.DeltaTime) <= 0.0 || (double) this.LinkTime > 0.0 && (double) (this.LinkTime -= NetworkManager.DeltaTime) <= 0.0 || NetworkManager.Connected() && (double) this.FrozenTime > 0.0 && (double) (this.FrozenTime -= NetworkManager.DeltaTime) <= 0.0) && !IGGGameSDK.Instance.NotConnect)
      this.SetStage(LoginPhase.LP_ReConnect, 0L);
    else if (this.ReplyConnect)
    {
      this.SetStage(LoginPhase.LP_Connected, 0L);
    }
    else
    {
      if ((double) this.BeatTime > 0.0 && (double) (this.BeatTime -= NetworkManager.DeltaTime) <= 0.0 && !IGGGameSDK.Instance.NotConnect)
        NetworkManager.HeartBeat();
      else if (NetworkManager.Connecting && ((double) this.LockTime > 0.0 && (double) (this.LockTime -= NetworkManager.DeltaTime) <= 0.0 || (double) this.FrozenTime > 0.0 && (double) (this.FrozenTime -= NetworkManager.DeltaTime) <= 0.0) && !IGGGameSDK.Instance.NotConnect)
        this.SetStage(LoginPhase.LP_GG, 0L);
      else if (NetworkManager.LostInSpace || (double) this.ConnectTime > 0.0 && (double) (this.ConnectTime -= NetworkManager.DeltaTime) <= 0.0)
        this.SetStage(LoginPhase.LP_Fail, 1L, NetworkManager.LostInSpace);
      else if (NetworkManager.Armageddon)
        this.SetStage(LoginPhase.LP_Fatal, 0L, NetworkManager.Stage == LoginPhase.LP_Connecting);
      if ((double) this.CheckTime > 0.0)
        this.CheckTime -= NetworkManager.DeltaTime;
      if ((double) this.CheckTime < 0.0)
        this.CheckTime = 0.0f;
      if ((double) this.UpdateTime > 0.0 && (double) (this.UpdateTime -= NetworkManager.DeltaTime) <= 0.0)
        this.SetStage(LoginPhase.LP_EpicFail, 0L);
      else if ((double) this.RequestTime > 0.0 && (double) (this.RequestTime -= NetworkManager.DeltaTime) <= 0.0)
        DownloadController.Fallback();
      NetworkManager.CheckBuffer();
    }
  }

  public static void Peeping(MessagePacket Mp)
  {
    switch (Mp.ReadByte())
    {
      case 0:
        NetworkManager.guest.Enter(Mp);
        return;
      case 1:
        NetworkManager.guest.Resume();
        return;
      case 2:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(103U), DataManager.Instance.mStringTable.GetStringByID(911U));
        break;
      default:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(103U), string.Format("{0}:{1}", (object) DataManager.Instance.mStringTable.GetStringByID(911U), (object) Mp.Data[0]));
        break;
    }
    NetworkManager.guest.Drop();
    GameManager.OnRefresh(NetworkNews.GuestConnectFail);
  }

  public bool ViewKingdom(ushort KingdomId) => NetworkManager.guest.View(KingdomId);

  public void ViewClose() => NetworkManager.guest.Drop();

  public class PBuffer
  {
    public byte[] Data = new byte[4096];
    public int read;
  }
}
