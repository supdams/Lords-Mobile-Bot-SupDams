// Decompiled with JetBrains decompiler
// Type: SearchPlayerDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct SearchPlayerDataType
{
  public ushort Head;
  public CString Name;
  public CString AllianceTag;
  public ulong Power;
  public ulong TroopKillNum;

  public SearchPlayerDataType(int len = 0)
  {
    this.Head = (ushort) 1;
    this.Name = StringManager.Instance.SpawnString(13);
    this.AllianceTag = StringManager.Instance.SpawnString(3);
    this.Power = 0UL;
    this.TroopKillNum = 0UL;
  }
}
