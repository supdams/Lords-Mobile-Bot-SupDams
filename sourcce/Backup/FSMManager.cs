// Decompiled with JetBrains decompiler
// Type: FSMManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class FSMManager
{
  public const int BehaviourCount = 27;
  public FSMUnit[] m_FSMUnit;
  public static FSMManager m_Self;
  public bool bIsSiegeMode;
  public bool bIsBattleOver;
  public int MaxCaptiver;
  public int CaptivingCount;

  private FSMManager()
  {
    this.m_FSMUnit = new FSMUnit[27];
    this.m_FSMUnit[0] = (FSMUnit) new FSMMoving(this);
    this.m_FSMUnit[1] = (FSMUnit) new FSMIdle(this);
    this.m_FSMUnit[2] = (FSMUnit) new FSMIdle_FastRun(this);
    this.m_FSMUnit[3] = (FSMUnit) new FSMIdleWithoutClump(this);
    this.m_FSMUnit[4] = (FSMUnit) new FSMMeleeFight(this);
    this.m_FSMUnit[8] = (FSMUnit) new FSMMeleeFight_Wall(this);
    this.m_FSMUnit[5] = (FSMUnit) new FSMMeleeFightImmediate(this);
    this.m_FSMUnit[6] = (FSMUnit) new FSMRangeFight(this);
    this.m_FSMUnit[7] = (FSMUnit) new FSMRangeFight_Wall(this);
    this.m_FSMUnit[9] = (FSMUnit) new FSMTryFight(this);
    this.m_FSMUnit[11] = (FSMUnit) new FSMDie(this);
    this.m_FSMUnit[12] = (FSMUnit) new FSMDying(this);
    this.m_FSMUnit[13] = (FSMUnit) new FSMLordDying(this);
    this.m_FSMUnit[14] = (FSMUnit) new FSMLordDie(this);
    this.m_FSMUnit[15] = (FSMUnit) new FSMSpread(this);
    this.m_FSMUnit[10] = (FSMUnit) new FSMMoveToTarget(this);
    this.m_FSMUnit[16] = (FSMUnit) new FSMArcherSpread(this);
    this.m_FSMUnit[17] = (FSMUnit) new FSMVictory(this);
    this.m_FSMUnit[18] = (FSMUnit) new FSMMoveOutOfTown(this);
    this.m_FSMUnit[19] = (FSMUnit) new FSMJumpFromWall(this);
    this.m_FSMUnit[20] = (FSMUnit) new FSMLoseTarget(this);
    this.m_FSMUnit[21] = (FSMUnit) new FSMGoCaptiving(this);
    this.m_FSMUnit[22] = (FSMUnit) new FSMAttackerRunAway(this);
    this.m_FSMUnit[23] = (FSMUnit) new FSMDefenserChasing(this);
    this.m_FSMUnit[24] = (FSMUnit) new FSMDefenserRunAway(this);
    this.m_FSMUnit[25] = (FSMUnit) new FSMAttackerChasing(this);
    this.m_FSMUnit[26] = (FSMUnit) new FSMOutsideHeroDisplay(this);
  }

  public static FSMManager Instance
  {
    get
    {
      if (FSMManager.m_Self == null)
        FSMManager.m_Self = new FSMManager();
      return FSMManager.m_Self;
    }
  }

  public FSMUnit getState(EStateName name) => this.m_FSMUnit[(int) name];
}
