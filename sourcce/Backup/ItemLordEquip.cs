// Decompiled with JetBrains decompiler
// Type: ItemLordEquip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct ItemLordEquip
{
  public ushort ItemID;
  public byte Color;
  public byte[] GemColor;
  public ushort[] Gem;
  public uint SerialNO;
  public long ExpireTime;

  public void Init()
  {
    this.ItemID = (ushort) 0;
    this.SerialNO = 0U;
    this.Color = (byte) 0;
    this.Gem = new ushort[4];
    this.GemColor = new byte[4];
    for (int index = 0; index < 4; ++index)
    {
      this.GemColor[index] = (byte) 0;
      this.Gem[index] = (ushort) 0;
    }
  }

  public void Clear()
  {
    this.ItemID = (ushort) 0;
    this.SerialNO = 0U;
    this.Color = (byte) 0;
    for (int index = 0; index < 4; ++index)
    {
      this.GemColor[index] = (byte) 0;
      this.Gem[index] = (ushort) 0;
    }
    this.ExpireTime = 0L;
  }

  public bool haveGem()
  {
    for (int index = 0; index < 4; ++index)
    {
      if (this.Gem[index] != (ushort) 0)
        return true;
    }
    return false;
  }

  public ItemLordEquip Clone()
  {
    ItemLordEquip itemLordEquip = new ItemLordEquip();
    itemLordEquip.Init();
    itemLordEquip.ItemID = this.ItemID;
    itemLordEquip.SerialNO = this.SerialNO;
    itemLordEquip.Color = this.Color;
    itemLordEquip.ExpireTime = this.ExpireTime;
    for (int index = 0; index < 4; ++index)
    {
      itemLordEquip.GemColor[index] = this.GemColor[index];
      itemLordEquip.Gem[index] = this.Gem[index];
    }
    return itemLordEquip;
  }

  public LordEquipSerialData CloneSerial()
  {
    LordEquipSerialData lordEquipSerialData = new LordEquipSerialData();
    lordEquipSerialData.Init();
    lordEquipSerialData.ItemID = this.ItemID;
    lordEquipSerialData.Color = this.Color;
    for (int index = 0; index < 4; ++index)
    {
      lordEquipSerialData.GemColor[index] = this.GemColor[index];
      lordEquipSerialData.Gem[index] = this.Gem[index];
    }
    return lordEquipSerialData;
  }
}
