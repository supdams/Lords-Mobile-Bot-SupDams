// Decompiled with JetBrains decompiler
// Type: BuildAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class BuildAimMission : ManorAimNow
{
  public BuildAimMission()
  {
    this.ManorBuildData = new ManorCheck[DataManager.Instance.BuildsTypeData.TableCount];
    this.Init();
  }

  public override void SetCompleteWhileLogin()
  {
    BuildsData buildingData = GUIManager.Instance.BuildingData;
    for (int index = 0; index < this.ManorBuildData.Length; ++index)
    {
      ushort num = (ushort) (index + 1);
      byte level = buildingData.GetBuildData(num, (ushort) 0).Level;
      this.UpdateCheckIndex(num, (ushort) level);
    }
  }

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    if (this.ManorBuildData[(int) Key - (int) this.KeyBegin].CondiVal > (int) Val)
      Val = (ushort) GUIManager.Instance.BuildingData.GetBuildData(Key, (ushort) 0).Level;
    return base.CheckValueChanged(Key, Val);
  }
}
