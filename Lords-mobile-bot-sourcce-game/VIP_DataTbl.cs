// Decompiled with JetBrains decompiler
// Type: VIP_DataTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct VIP_DataTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort VIPLevel;
  [MarshalAs(UnmanagedType.U4)]
  public uint VIPPoint;
  [MarshalAs(UnmanagedType.U2)]
  public ushort loginPoint;
  [MarshalAs(UnmanagedType.U2)]
  public ushort dailyAdd;
  [MarshalAs(UnmanagedType.U1)]
  public byte QuickCompleteMin;
  [MarshalAs(UnmanagedType.U1)]
  public byte moraleBanner;
  [MarshalAs(UnmanagedType.U1)]
  public byte DailyResetElite;
  [MarshalAs(UnmanagedType.U1)]
  public byte SkillPointMax;
  [MarshalAs(UnmanagedType.U1)]
  public byte UnlockBuySkill;
  [MarshalAs(UnmanagedType.U1)]
  public byte AutoDailyMission;
  [MarshalAs(UnmanagedType.U1)]
  public byte AutoDailyAlliMission;
  [MarshalAs(UnmanagedType.U1)]
  public byte AutoFightMission;
  [MarshalAs(UnmanagedType.U1)]
  public byte VipMission;
  [MarshalAs(UnmanagedType.U1)]
  public byte DailyMission;
  [MarshalAs(UnmanagedType.U1)]
  public byte AlliMission;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
  public ushort[] Effects;
}
