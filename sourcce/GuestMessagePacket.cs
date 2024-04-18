// Decompiled with JetBrains decompiler
// Type: GuestMessagePacket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class GuestMessagePacket : MessagePacket
{
  public static int Sequence;

  public GuestMessagePacket(byte Id)
    : base((ushort) 1024)
  {
    this.Channel = Id;
  }

  public override void AddSeqId() => this.Add(++GuestMessagePacket.Sequence);
}
