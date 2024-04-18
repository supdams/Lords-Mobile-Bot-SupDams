// Decompiled with JetBrains decompiler
// Type: EmojiData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct EmojiData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmojiKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GroupIconID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort IconID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SoundID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort sizeX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort sizeY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Xoffset;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Yoffset;
  [MarshalAs(UnmanagedType.U1)]
  public byte KeyFrame;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MapTime;
  [MarshalAs(UnmanagedType.U4)]
  public uint UseTime;
  [MarshalAs(UnmanagedType.U1)]
  public byte EmojiType;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionOne;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionTwo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionThree;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EmotionFour;
}
