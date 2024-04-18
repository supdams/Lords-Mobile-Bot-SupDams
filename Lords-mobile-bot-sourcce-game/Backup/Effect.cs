// Decompiled with JetBrains decompiler
// Type: Effect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Effect
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort String_infoID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StringID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort InfoID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ValueID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StatusIcon;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EffectIcon;
}
