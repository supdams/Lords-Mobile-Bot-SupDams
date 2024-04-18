// Decompiled with JetBrains decompiler
// Type: _AchieveTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _AchieveTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort AchievementID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MissionID;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
  public char[] AchievementName;
}
