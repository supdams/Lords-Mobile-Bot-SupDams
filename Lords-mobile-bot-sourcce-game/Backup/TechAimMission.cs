// Decompiled with JetBrains decompiler
// Type: TechAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class TechAimMission : ManorAimNow
{
  public TechAimMission()
  {
    this.ManorBuildData = new ManorCheck[DataManager.Instance.TechCount];
    this.Init();
  }

  public override void SetCompleteWhileLogin()
  {
    DataManager instance = DataManager.Instance;
    for (int index = 0; index < this.ManorBuildData.Length; ++index)
    {
      ushort num = (ushort) (index + 1);
      this.UpdateCheckIndex(num, (ushort) instance.GetTechLevel(num));
    }
  }
}
