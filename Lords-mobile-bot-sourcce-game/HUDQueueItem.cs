// Decompiled with JetBrains decompiler
// Type: HUDQueueItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class HUDQueueItem
{
  public const byte QueueSize = 20;
  public byte Count;
  public byte PushIndex;
  public byte PopIndex;
  public CString[] Message;
  public ushort[] Type;
  private byte bInit;

  public HUDQueueItem()
  {
    this.Message = new CString[20];
    this.Type = new ushort[20];
  }

  private void CheckInit()
  {
    if (this.bInit != (byte) 0)
      return;
    for (byte index = 0; index < (byte) 20; ++index)
      this.Message[(int) index] = StringManager.Instance.SpawnString(100);
    this.Count = this.PushIndex = this.PopIndex;
    this.bInit = (byte) 1;
  }

  public void Destroy()
  {
    for (byte index = 0; index < (byte) 20; ++index)
    {
      StringManager.Instance.DeSpawnString(this.Message[(int) index]);
      this.Message[(int) index] = (CString) null;
    }
    this.Count = (byte) 0;
    this.bInit = (byte) 0;
  }

  public bool Push(string Msg, ushort Type)
  {
    this.CheckInit();
    if (this.Count == (byte) 20)
      return false;
    this.PushIndex %= (byte) 20;
    this.Message[(int) this.PushIndex].ClearString();
    this.Message[(int) this.PushIndex].Append(Msg);
    this.Type[(int) this.PushIndex++] = Type;
    ++this.Count;
    return true;
  }

  public void Pop(out string Msg, out ushort Type)
  {
    this.CheckInit();
    if (this.Count == (byte) 0)
    {
      Msg = (string) null;
      Type = (ushort) 0;
    }
    else
    {
      this.PopIndex %= (byte) 20;
      Msg = this.Message[(int) this.PopIndex].ToString();
      Type = this.Type[(int) this.PopIndex++];
      --this.Count;
    }
  }
}
