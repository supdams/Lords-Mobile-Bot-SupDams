// Decompiled with JetBrains decompiler
// Type: LordEquipSerialData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LordEquipSerialData
{
  public ushort ItemID;
  public byte Color;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public byte[] GemColor;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public ushort[] Gem;
  public uint DontUse;

  public void Init()
  {
    this.ItemID = (ushort) 0;
    this.DontUse = 0U;
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
    this.DontUse = 0U;
    this.Color = (byte) 0;
    for (int index = 0; index < 4; ++index)
    {
      this.GemColor[index] = (byte) 0;
      this.Gem[index] = (ushort) 0;
    }
  }
}
