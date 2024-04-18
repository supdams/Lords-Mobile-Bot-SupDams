// Decompiled with JetBrains decompiler
// Type: NormalAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class NormalAimMission : StageAimMission
{
  public NormalAimMission()
  {
    this.ManorBuildData = new ManorCheck[1];
    this.Init();
  }

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    Val /= (ushort) 3;
    return base.CheckValueChanged(Key, Val);
  }
}
