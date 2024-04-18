// Decompiled with JetBrains decompiler
// Type: MailSaveOrder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public class MailSaveOrder
{
  public uint Id;
  public byte IsFavorite;

  public MailSaveOrder(uint id, byte favor)
  {
    this.IsFavorite = favor;
    this.Id = id;
  }
}
