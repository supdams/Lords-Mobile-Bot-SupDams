// Decompiled with JetBrains decompiler
// Type: SerialBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class SerialBox
{
  public uint Serial;
  public bool Read;
  public bool Save;
  public byte Flag;
  public byte Type;
  public bool Pull;
  public bool Keep;
  public CombatCollectReport Sub;

  public SerialBox()
  {
  }

  public SerialBox(uint serial, byte flag, bool read, bool save, bool pull = true, bool keep = true)
  {
    this.Serial = serial;
    this.Read = read;
    this.Keep = keep;
    this.Save = save;
    this.Flag = flag;
    this.Pull = pull;
  }
}
