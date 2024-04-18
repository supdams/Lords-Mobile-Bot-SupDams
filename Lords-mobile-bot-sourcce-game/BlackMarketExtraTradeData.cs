// Decompiled with JetBrains decompiler
// Type: BlackMarketExtraTradeData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct BlackMarketExtraTradeData
{
  public byte TradePos;
  public byte LocksBought;
  public ushort itemID;
  public byte Discount;
  public byte DataLen;
  public ComboBoxTBItemDataType[] ItemContain;

  public BlackMarketExtraTradeData(byte tmp)
  {
    this.TradePos = (byte) 0;
    this.LocksBought = (byte) 0;
    this.itemID = (ushort) 0;
    this.Discount = (byte) 0;
    this.DataLen = (byte) 0;
    this.ItemContain = new ComboBoxTBItemDataType[200];
  }
}
