// Decompiled with JetBrains decompiler
// Type: MessageBuff
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MessageBuff
{
  public byte[] Data;
  public int position;
  public int last_pos;
  public int parse_pos;

  public MessageBuff(int size) => this.Data = new byte[size];

  public void Clear() => this.parse_pos = 0;
}
