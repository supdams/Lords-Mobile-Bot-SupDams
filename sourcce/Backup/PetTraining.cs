// Decompiled with JetBrains decompiler
// Type: PetTraining
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct PetTraining
{
  public PetManager.EPetTrainDataState m_State;
  public PetTrainingSet m_PetTrainingSet;
  public uint m_TotalExp;
  public uint m_CancelExp;
  public TimeEventDataType m_EventTime;
  private byte m_CoachHeroCount;
  private bool bHasInstance;

  public PetTraining(PetManager.EPetTrainDataState state)
  {
    this.m_State = state;
    this.m_CoachHeroCount = (byte) 0;
    this.m_TotalExp = 0U;
    this.m_CancelExp = 0U;
    this.m_PetTrainingSet = new PetTrainingSet();
    this.m_EventTime.BeginTime = 0L;
    this.m_EventTime.RequireTime = 0U;
    this.bHasInstance = true;
  }

  public byte CoachHeroCount
  {
    get
    {
      return this.m_PetTrainingSet.m_CoachHeroId != null ? (byte) this.m_PetTrainingSet.m_CoachHeroId.Count : (byte) 0;
    }
  }

  public bool HasInstance => this.bHasInstance;

  public void AddCoachHero(ushort id)
  {
    if (this.m_PetTrainingSet.m_CoachHeroId == null || this.m_PetTrainingSet.m_CoachHeroId.Count >= 100)
      return;
    this.m_PetTrainingSet.m_CoachHeroId.Add(id);
  }

  public void Empty()
  {
    this.m_CoachHeroCount = (byte) 0;
    this.m_TotalExp = 0U;
    this.m_CancelExp = 0U;
    this.m_EventTime.BeginTime = 0L;
    this.m_EventTime.RequireTime = 0U;
    this.m_PetTrainingSet.Empty();
  }

  public void SetState(PetManager.EPetTrainDataState state)
  {
    this.m_State = state;
    if (state != PetManager.EPetTrainDataState.Empty && state != PetManager.EPetTrainDataState.Closed && state != PetManager.EPetTrainDataState.NextOpen)
      return;
    this.Empty();
  }
}
