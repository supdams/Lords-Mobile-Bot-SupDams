// Decompiled with JetBrains decompiler
// Type: ArmyAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class ArmyAimMission : ManorAimEver
{
  private ushort RecordBeginIndex;

  public ArmyAimMission(ushort[] RecordMark)
    : base(RecordMark)
  {
    this.ManorBuildData = new ManorCheck[29];
    this.RecordBeginIndex = (ushort) 1;
    this.Init();
  }

  public override void SetCompleteWhileLogin()
  {
    for (int index = 0; index < this.ManorBuildData.Length; ++index)
      this.UpdateCheckIndex((ushort) ((uint) index + (uint) this.KeyBegin), this.RecordMark[index + (int) this.RecordBeginIndex]);
  }

  public override void UpdateCheckIndex(ushort Key, ushort Val)
  {
    this.CheckValueChanged(Key, (ushort) 0);
  }

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    this.RecordMark[(int) Key] += Val;
    if (!base.CheckValueChanged(Key, this.RecordMark[(int) Key]))
      return false;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    return true;
  }
}
