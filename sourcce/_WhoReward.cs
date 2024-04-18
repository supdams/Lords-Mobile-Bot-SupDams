// Decompiled with JetBrains decompiler
// Type: _WhoReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public abstract class _WhoReward
{
  public string TitleStr;
  public string MainStr;
  public bool IsKing;

  public abstract bool CheckReward();

  public abstract bool CheckAndOpenList(int ID);
}
