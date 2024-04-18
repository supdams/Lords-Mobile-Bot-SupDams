// Decompiled with JetBrains decompiler
// Type: TalentTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TalentTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort TalentID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort NameID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Graphic;
  [MarshalAs(UnmanagedType.U1)]
  public byte LevelMax;
  [MarshalAs(UnmanagedType.U2)]
  public ushort NeedTalentID;
  [MarshalAs(UnmanagedType.U1)]
  public byte NeedTalentLv;
}
