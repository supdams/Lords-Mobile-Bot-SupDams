// Decompiled with JetBrains decompiler
// Type: MailBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
[Serializable]
public struct MailBox
{
  public MailType Type;
  public MailType Kind;
  public uint Serial;
  public long Timing;
  public bool Change;
  public bool Check;
  public bool Read;
  public byte Flag;
}
