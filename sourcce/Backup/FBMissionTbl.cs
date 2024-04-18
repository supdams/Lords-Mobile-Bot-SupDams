// Decompiled with JetBrains decompiler
// Type: FBMissionTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FBMissionTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Name;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
  public _FBMissionCont[] MissionItems;
  [MarshalAs(UnmanagedType.U2)]
  public ushort OwnPrice;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FriendPrice;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
  public ushort[] OwnProcressDescribe;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
  public ushort[] Preserve;
}
