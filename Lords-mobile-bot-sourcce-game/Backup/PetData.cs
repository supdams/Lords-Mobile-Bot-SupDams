// Decompiled with JetBrains decompiler
// Type: PetData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class PetData
{
  private int _DataIdx;
  private ushort _ID;
  public byte Rare;
  public byte Level;
  public uint Exp;
  public byte Enhance;
  public byte[] SkillLv = new byte[4];
  public uint[] SkillExp = new uint[4];
  public ushort[] SkillID;
  public PetManager.EPetState PetState;
  private static readonly double[] PetGrowMod = new double[4]
  {
    0.0,
    0.01,
    0.3,
    1.0
  };
  private static readonly double[] PetRareMod = new double[6]
  {
    0.0,
    0.3,
    0.4,
    0.6,
    0.8,
    1.0
  };
  private static ulong FullGrowPower = 250000;
  private static readonly double[] PetSkillLevelMod = new double[11]
  {
    0.0,
    0.0,
    0.05,
    0.1,
    0.15,
    0.2,
    0.3,
    0.4,
    0.5,
    0.6,
    1.0
  };
  private static readonly double[] PetSkillRareMod = new double[6]
  {
    0.0,
    0.16,
    0.32,
    0.48,
    0.72,
    1.0
  };
  private static ulong FullSkillPower = 250000;

  public PetData(int Index) => this._DataIdx = Index;

  public int DataIndex => this._DataIdx;

  public ushort ID
  {
    set
    {
      if ((int) value == (int) this._ID)
        return;
      this._ID = value;
      PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(this._ID);
      this.Rare = recordByKey.Rare;
      this.SkillID = recordByKey.PetSkill;
    }
    get => this._ID;
  }

  public void AddState(PetManager.EPetState state) => this.PetState |= state;

  public bool CheckState(PetManager.EPetState state) => (this.PetState & state) == state;

  public void Remove(PetManager.EPetState state) => this.PetState &= ~state;

  public void Init()
  {
    this.Level = (byte) 0;
    this.Exp = 0U;
    this.Enhance = (byte) 0;
    Array.Clear((Array) this.SkillLv, 0, this.SkillLv.Length);
    Array.Clear((Array) this.SkillExp, 0, this.SkillExp.Length);
    this.PetState = PetManager.EPetState.None;
  }

  public byte GetMaxLevel(bool bCheckRoleLv = true)
  {
    byte maxLevel = 60;
    if (this.Enhance == (byte) 0)
      maxLevel = (byte) 20;
    else if (this.Enhance == (byte) 1)
      maxLevel = (byte) 50;
    if (bCheckRoleLv)
    {
      byte level = DataManager.Instance.RoleAttr.Level;
      if (level <= (byte) 15)
        maxLevel = (byte) 15;
      else if ((int) level < (int) maxLevel)
        maxLevel = level;
    }
    return maxLevel;
  }

  public bool IsFullSkillLevel() => this.CheckState(PetManager.EPetState.Limit);

  public void UpdateLevelState()
  {
    PetManager instance = PetManager.Instance;
    PetTbl recordByKey1 = instance.PetTable.GetRecordByKey(this.ID);
    bool flag = true;
    for (int index = 0; index < 4; ++index)
    {
      if (recordByKey1.PetSkill[index] != (ushort) 0)
      {
        PetSkillTbl recordByKey2 = instance.PetSkillTable.GetRecordByKey(recordByKey1.PetSkill[index]);
        if (recordByKey2.UpLevel != (byte) 0 && (int) this.SkillLv[index] < (int) recordByKey2.UpLevel)
          flag = false;
      }
    }
    if (flag && this.Level == (byte) 60)
    {
      this.AddState(PetManager.EPetState.Limit);
    }
    else
    {
      this.Remove(PetManager.EPetState.Limit);
      uint needExp = instance.GetNeedExp(this.Level, recordByKey1.Rare);
      if ((int) this.Level >= (int) this.GetMaxLevel(false) && this.Level != (byte) 60 && this.Exp >= needExp - 1U)
        this.AddState(PetManager.EPetState.LockLimit);
      else
        this.Remove(PetManager.EPetState.LockLimit);
    }
  }

  public ulong getPetPower()
  {
    ulong num = 0;
    int index1 = Mathf.Clamp((int) this.Enhance + 1, 0, PetData.PetGrowMod.Length - 1);
    int index2 = Mathf.Clamp((int) this.Rare, 0, PetData.PetRareMod.Length - 1);
    ulong petPower = num + (ulong) ((double) PetData.FullGrowPower * PetData.PetGrowMod[index1] * PetData.PetRareMod[index2]);
    for (int index3 = 0; index3 < this.SkillLv.Length; ++index3)
    {
      if (this.SkillLv[index3] > (byte) 0)
      {
        int index4 = Mathf.Clamp((int) this.SkillLv[index3], 0, PetData.PetSkillLevelMod.Length - 1);
        petPower += (ulong) ((double) PetData.FullSkillPower * PetData.PetSkillLevelMod[index4] * PetData.PetSkillRareMod[index2]);
      }
    }
    return petPower;
  }
}
