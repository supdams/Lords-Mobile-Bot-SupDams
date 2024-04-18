// Decompiled with JetBrains decompiler
// Type: KVSBoardTopBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class KVSBoardTopBoard
{
  public long SortTime;
  public ushort KVSTopKingdom;
  public ushort KVSTopAlliKingdomID;
  public uint KVSTopAlliAllianceID;
  public CString KVSTopAlliTag;
  public CString KVSTopAlliName;
  public ulong KVSTopAlliScore;
  public ushort KVSTopAlliEmblem;
  public ushort KVSTopPlayerKingdomID;
  public CString KVSTopPlayerTag;
  public CString KVSTopPlayerName;
  public ulong KVSPlayerValue;
  public ushort KVSPlayerHead;
  public CString KvKAlliTopPlayerName;
  public ulong KvKAlliTopPlayerValue;
  public ushort KvKAlliTopPlayerHead;
  public ushort KVKTopKingdom;
  public ushort KvKTopAlliKingdomID;
  public uint KvKTopAlliAllianceID;
  public CString KvKTopAlliTag;
  public CString KvKTopAlliName;
  public ulong KvKTopAlliScore;
  public ushort KvKTopAlliEmblem;
  public ushort KvKTopPlayerKingdomID;
  public CString KvKTopPlayerTag;
  public CString KvKTopPlayerName;
  public ulong KvKPlayerValue;
  public ushort KvKPlayerHead;
  public uint KingdomEventRequireTime;
  public ulong AllianceID;

  public KVSBoardTopBoard()
  {
    this.KVSTopAlliTag = StringManager.Instance.SpawnString();
    this.KVSTopAlliName = StringManager.Instance.SpawnString();
    this.KVSTopPlayerTag = StringManager.Instance.SpawnString();
    this.KVSTopPlayerName = StringManager.Instance.SpawnString();
    this.KvKTopAlliTag = StringManager.Instance.SpawnString();
    this.KvKTopAlliName = StringManager.Instance.SpawnString();
    this.KvKTopPlayerTag = StringManager.Instance.SpawnString();
    this.KvKTopPlayerName = StringManager.Instance.SpawnString();
    this.KvKAlliTopPlayerName = StringManager.Instance.SpawnString();
  }
}
