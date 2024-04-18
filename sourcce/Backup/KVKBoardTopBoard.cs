// Decompiled with JetBrains decompiler
// Type: KVKBoardTopBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class KVKBoardTopBoard
{
  public long SortTime;
  public ushort TopKingdom;
  public ushort KvKTopAlliKingdomID;
  public uint KvKTopAlliAllianceID;
  public CString KvKTopAlliTag;
  public CString KvKTopAlliName;
  public ulong KvKTopAlliScore;
  public ushort KvKTopAlliEmblem;
  public CString KvKAlliTopPlayerName;
  public ulong KvKAlliTopPlayerValue;
  public ushort KvKAlliTopPlayerHead;
  public uint KingdomEventRequireTime;
  public ushort KvKTopPlayerKingdomID;
  public CString KvKTopPlayerTag;
  public CString KvKTopPlayerName;
  public ulong KvKPlayerValue;
  public ushort KvKPlayerHead;
  public ulong AllianceID;

  public KVKBoardTopBoard()
  {
    this.KvKTopAlliTag = StringManager.Instance.SpawnString();
    this.KvKTopAlliName = StringManager.Instance.SpawnString();
    this.KvKAlliTopPlayerName = StringManager.Instance.SpawnString();
    this.KvKTopPlayerTag = StringManager.Instance.SpawnString();
    this.KvKTopPlayerName = StringManager.Instance.SpawnString();
  }
}
