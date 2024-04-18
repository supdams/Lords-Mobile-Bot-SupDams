// Decompiled with JetBrains decompiler
// Type: _ManorAimTypeMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public abstract class _ManorAimTypeMission
{
  public abstract void AddData(ushort Priority, ushort Key, ushort Val);

  public abstract void AddDataFail(ushort Priority);

  public abstract void SetCompleteWhileLogin();

  public abstract bool CheckValueChanged(ushort Key, ushort Val);

  public abstract void UpdateCheckIndex(ushort Key, ushort Val);

  public abstract void Reset();

  public abstract void ClearAll();
}
