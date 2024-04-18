// Decompiled with JetBrains decompiler
// Type: RecordAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public class RecordAimMission : ManorAimNow
{
  public byte MaxEnhanceID;
  public byte DefenderNum;
  public byte[] HeroEnhanceNum;

  public RecordAimMission()
  {
    this.ManorBuildData = new ManorCheck[29];
    this.Init();
    this.HeroEnhanceNum = new byte[11];
  }

  public override void AddData(ushort Priority, ushort Key, ushort Val)
  {
    if (Key == (ushort) 29)
      Val = (ushort) ((uint) ushort.MaxValue - (uint) Val);
    base.AddData(Priority, Key, Val);
  }

  public override void SetCompleteWhileLogin()
  {
    this.UpdateHeroEnhance();
    for (ushort Key = 8; Key <= (ushort) 18; ++Key)
      this.CheckValueChanged(Key, (ushort) this.HeroEnhanceNum[(int) Key - 8]);
  }

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    if (Key == (ushort) 19)
    {
      ushort[] defendersId = DataManager.Instance.m_DefendersID;
      this.DefenderNum = (byte) 1;
      for (byte index = 1; (int) index < defendersId.Length; ++index)
      {
        if (defendersId[(int) index] > (ushort) 0)
          ++this.DefenderNum;
      }
      Val = (ushort) this.DefenderNum;
    }
    return base.CheckValueChanged(Key, Val);
  }

  public void UpdateHeroEnhance()
  {
    DataManager instance = DataManager.Instance;
    this.MaxEnhanceID = (byte) 0;
    Array.Clear((Array) this.HeroEnhanceNum, 0, this.HeroEnhanceNum.Length);
    for (uint index = 0; index < instance.CurHeroDataCount; ++index)
    {
      CurHeroData curHeroData = instance.curHeroData.Find(instance.sortHeroData[(IntPtr) index]);
      if (curHeroData.Enhance >= (byte) 2 && curHeroData.Enhance <= (byte) 12)
        ++this.HeroEnhanceNum[(int) curHeroData.Enhance - 2];
    }
    for (int index = this.HeroEnhanceNum.Length - 2; index >= 0; --index)
      this.HeroEnhanceNum[index] = (byte) ((uint) this.HeroEnhanceNum[index] + (uint) this.HeroEnhanceNum[index + 1]);
  }
}
