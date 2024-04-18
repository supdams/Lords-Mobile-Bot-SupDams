// Decompiled with JetBrains decompiler
// Type: AI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AI
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort AIKey;
  [MarshalAs(UnmanagedType.U1)]
  public byte Search;
  [MarshalAs(UnmanagedType.U1)]
  public byte ChangTime;
  [MarshalAs(UnmanagedType.U1)]
  public byte GoodSkillSearch;
}
