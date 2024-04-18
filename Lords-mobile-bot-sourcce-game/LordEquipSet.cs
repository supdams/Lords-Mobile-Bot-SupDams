// Decompiled with JetBrains decompiler
// Type: LordEquipSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class LordEquipSet
{
  public CString Name;
  public uint[] SerialNO;

  public LordEquipSet() => this.SerialNO = new uint[8];

  public bool isInSet(uint serial)
  {
    for (int index = 0; index < this.SerialNO.Length; ++index)
    {
      if ((int) this.SerialNO[index] == (int) serial)
        return true;
    }
    return false;
  }

  public bool isSetEmpty()
  {
    for (int index = 0; index < this.SerialNO.Length; ++index)
    {
      if (this.SerialNO[index] > 0U)
        return false;
    }
    return true;
  }
}
