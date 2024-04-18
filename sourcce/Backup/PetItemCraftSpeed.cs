// Decompiled with JetBrains decompiler
// Type: PetItemCraftSpeed
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class PetItemCraftSpeed : SpeedupBase
{
  public PetItemCraftSpeed(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(14667U);
    this.CompleteImmContStr = mStringTable.GetStringByID(14668U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(14658U);
    this.bFreeSpeedup = false;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.ItemCraft;
    this.FilterType = (byte) 22;
  }

  public override void SendImmediate()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMCRAFT_START;
    messagePacket.AddSeqId();
    messagePacket.Add((ushort) 0);
    messagePacket.Add((ushort) 0);
    messagePacket.Add((byte) 2);
    messagePacket.Send();
  }

  public override void SendImmediateFree()
  {
  }
}
