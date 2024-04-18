// Decompiled with JetBrains decompiler
// Type: PetTrainingSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public struct PetTrainingSet
{
  public ushort m_PetId;
  public List<ushort> m_CoachHeroId;

  public PetTrainingSet(int maxCoach = 100)
  {
    this.m_PetId = (ushort) 0;
    this.m_CoachHeroId = maxCoach < 0 || maxCoach > DataManager.Instance.MaxCurHeroData ? new List<ushort>(DataManager.Instance.MaxCurHeroData) : new List<ushort>(maxCoach);
    this.m_CoachHeroId.Clear();
  }

  public void Empty()
  {
    this.m_PetId = (ushort) 0;
    if (this.m_CoachHeroId == null)
      return;
    this.m_CoachHeroId.Clear();
  }
}
