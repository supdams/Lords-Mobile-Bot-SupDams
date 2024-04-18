// Decompiled with JetBrains decompiler
// Type: MapPrisoner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MapPrisoner
{
  public uint Bounty;
  public CString TagName;

  public MapPrisoner(uint Money, ushort kingdomID, CString AlliTAG, CString Name)
  {
    this.Bounty = Money;
    this.TagName = StringManager.Instance.SpawnString(50);
    this.TagName.ClearString();
    GameConstants.GetNameString(this.TagName, kingdomID, Name, AlliTAG);
  }

  ~MapPrisoner()
  {
  }
}
