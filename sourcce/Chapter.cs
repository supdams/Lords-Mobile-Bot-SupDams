// Decompiled with JetBrains decompiler
// Type: Chapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Chapter
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ChapterKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ChapterName;
  [MarshalAs(UnmanagedType.U1)]
  public byte MapID;
  [MarshalAs(UnmanagedType.U1)]
  public byte NeedLV;
  [MarshalAs(UnmanagedType.U1)]
  public byte Power;
  [MarshalAs(UnmanagedType.U2)]
  public ushort OpenTipsID;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
  public WordVector3[] BigPointPos;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
  public WordVector3[] PointPos;
  [MarshalAs(UnmanagedType.Struct)]
  public WordVector3 CameraPos;
  [MarshalAs(UnmanagedType.Struct)]
  public WordVector3 CameraRot;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HeroID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Hero_ItemID;
  [MarshalAs(UnmanagedType.U1)]
  public byte Hero_ItemNum;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public Stage_ItemData[] Items;
}
