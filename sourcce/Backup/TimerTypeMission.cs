// Decompiled with JetBrains decompiler
// Type: TimerTypeMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class TimerTypeMission
{
  private const byte MissionMax = 15;
  public long ResetTime;
  public long MissionTime;
  public byte MissionCount;
  public byte ProcessIdx;
  public _TimeMission[] TimeMission = new _TimeMission[15];
}
