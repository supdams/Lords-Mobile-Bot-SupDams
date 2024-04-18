// Decompiled with JetBrains decompiler
// Type: NewbieLog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class NewbieLog
{
  public static void Log(ENewbieLogKind kind, byte step)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_UPDATENEWBIELOG;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) kind);
    messagePacket.Add(step);
    messagePacket.Send();
  }
}
