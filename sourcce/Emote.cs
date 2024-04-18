// Decompiled with JetBrains decompiler
// Type: Emote
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Emote
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmojiIndex;
  [MarshalAs(UnmanagedType.U1)]
  public byte SelectionPicNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Weight;
  [MarshalAs(UnmanagedType.U4)]
  public uint ProductID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GiftID;
  [MarshalAs(UnmanagedType.U1)]
  public byte GiftCount;
  [MarshalAs(UnmanagedType.U1)]
  public byte TabScale;
  [MarshalAs(UnmanagedType.U1)]
  public byte FirstShow;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionTwo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionThree;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionFour;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionFive;
}
