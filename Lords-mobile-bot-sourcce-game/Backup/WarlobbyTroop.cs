// Decompiled with JetBrains decompiler
// Type: WarlobbyTroop
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class WarlobbyTroop
{
  public byte ListIndex;
  public CString AllyName;
  public int AllyNameID;
  public byte AllyVIP;
  public byte AllyRank;
  public TimeEventDataType MarchTime;
  public ushort TroopFlag;
  public uint TotalTroopNum;
  public byte TroopSize;
  public uint[][] TroopData;
  public static byte DelIndex = byte.MaxValue;

  public WarlobbyTroop(int index)
  {
    this.ListIndex = (byte) index;
    this.AllyName = StringManager.Instance.SpawnString(13);
    this.TroopData = new uint[4][];
    for (int index1 = 0; index1 < this.TroopData.Length; ++index1)
      this.TroopData[index1] = new uint[4];
  }

  public void Init(MessagePacket MP)
  {
    MP.ReadStringPlus(13, this.AllyName);
    this.AllyNameID = this.AllyName.GetHashCode(false);
    this.AllyVIP = MP.ReadByte();
    this.AllyRank = MP.ReadByte();
    this.MarchTime.BeginTime = MP.ReadLong();
    this.MarchTime.RequireTime = MP.ReadUInt();
    this.TroopFlag = MP.ReadUShort();
    this.TroopSize = (byte) 0;
    this.TotalTroopNum = 0U;
    for (int index = 0; index < 16; ++index)
    {
      if (((int) this.TroopFlag >> index & 1) == 1)
      {
        this.TroopData[index >> 2][index & 3] = MP.ReadUInt();
        this.TotalTroopNum += this.TroopData[index >> 2][index & 3];
        ++this.TroopSize;
      }
      else
        this.TroopData[index >> 2][index & 3] = 0U;
    }
  }

  public void Empty()
  {
    this.AllyName.ClearString();
    this.AllyNameID = 0;
    this.AllyVIP = this.AllyRank = this.TroopSize = (byte) 0;
    this.TroopFlag = (ushort) 0;
    this.TotalTroopNum = 0U;
  }
}
