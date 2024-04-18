// Decompiled with JetBrains decompiler
// Type: AssetUpdate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class AssetUpdate
{
  public int id;
  public byte kind;
  public byte type;
  public string path;

  public AssetUpdate(string path, byte kind, byte type, int id)
  {
    this.path = string.Copy(path);
    this.kind = kind;
    this.type = type;
    this.id = id;
  }
}
