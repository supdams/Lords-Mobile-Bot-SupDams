// Decompiled with JetBrains decompiler
// Type: AllianceWarBroudUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class AllianceWarBroudUnit
{
  public uint AlliacneID;
  public CString AllianceTag;
  public CString Name;
  public ulong Power;
  public int Score;

  public AllianceWarBroudUnit()
  {
    this.AllianceTag = StringManager.Instance.SpawnString();
    this.Name = StringManager.Instance.SpawnString();
  }
}
