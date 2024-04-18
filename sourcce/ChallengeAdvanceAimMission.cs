// Decompiled with JetBrains decompiler
// Type: ChallengeAdvanceAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class ChallengeAdvanceAimMission : ManorAimNow
{
  public ChallengeAdvanceAimMission()
  {
    this.ManorBuildData = new ManorCheck[48];
    this.Init();
  }

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    Key /= (ushort) 3;
    return base.CheckValueChanged(Key, Val);
  }

  public override void SetCompleteWhileLogin()
  {
    int num = (int) DataManager.StageDataController.StageRecord[3] / 3;
    for (ushort index = 1; (int) index <= num; ++index)
    {
      int stagePoint = DataManager.StageDataController.GetStagePoint((ushort) ((uint) index * 3U), (byte) 3);
      if (stagePoint > 0)
        this.CheckValueChanged((ushort) ((uint) index * 3U), (ushort) stagePoint);
    }
  }
}
