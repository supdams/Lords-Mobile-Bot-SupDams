// Decompiled with JetBrains decompiler
// Type: PetEvolutionSpeed
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class PetEvolutionSpeed : SpeedupBase
{
  public PetEvolutionSpeed(EQueueBarIndex QueueBar)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MainTitleStr = mStringTable.GetStringByID(16059U);
    this.CompleteImmContStr = mStringTable.GetStringByID(16081U);
    this.CompleteImmBntStr = mStringTable.GetStringByID(223U);
    this.bFreeSpeedup = true;
    this.bImmediate = true;
    this.QueueBar = (byte) QueueBar;
    this.UseTarget = _UseItemTarget.PET_STARUP;
    this.FilterType = (byte) 1;
  }

  public override void SendImmediate() => PetManager.Instance.Send_PET_STARUP_INSTANT((ushort) 0);

  public override void SendImmediateFree() => PetManager.Instance.Send_PET_STARUP_FREECOMPLETE();
}
