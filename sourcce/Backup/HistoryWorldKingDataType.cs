// Decompiled with JetBrains decompiler
// Type: HistoryWorldKingDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class HistoryWorldKingDataType
{
  public ushort HomeKingdomID;
  public CString AllianceTag;
  public CString Name;
  public uint OccupyTime;
  public long TakeOfficeTime;

  public HistoryWorldKingDataType()
  {
    this.AllianceTag = StringManager.Instance.SpawnString();
    this.Name = StringManager.Instance.SpawnString();
  }
}
