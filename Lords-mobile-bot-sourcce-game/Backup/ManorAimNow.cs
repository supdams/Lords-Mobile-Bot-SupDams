// Decompiled with JetBrains decompiler
// Type: ManorAimNow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class ManorAimNow : ManorAimChecked
{
  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    Key -= this.KeyBegin;
    if (this.ManorBuildData.Length <= (int) Key || this.ManorBuildData[(int) Key].CondiVal == (int) Val)
      return false;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    int index = this.ManorBuildData[(int) Key].CheckIndex;
    if (this.ManorBuildData[(int) Key].CondiVal < (int) Val)
    {
      for (; index < this.ManorBuildData[(int) Key].LvCondi.Count && (int) this.ManorBuildData[(int) Key].LvCondi[index] <= (int) Val; ++index)
      {
        missionDataManager.AddRewardMission(this.ManorBuildData[(int) Key].Priority[index]);
        this.ManorBuildData[(int) Key].CondPriority = (int) this.ManorBuildData[(int) Key].Priority[index];
      }
    }
    else if (this.ManorBuildData[(int) Key].CondiVal > (int) Val)
    {
      if (index >= this.ManorBuildData[(int) Key].LvCondi.Count)
        index = this.ManorBuildData[(int) Key].LvCondi.Count - 1;
      for (; index > 0; --index)
      {
        if ((int) this.ManorBuildData[(int) Key].LvCondi[index] < (int) Val)
        {
          if (this.ManorBuildData[(int) Key].LvCondi.Count > index + 1)
          {
            ++index;
            break;
          }
          break;
        }
      }
      if (index < 0)
        index = 0;
      if (this.ManorBuildData[(int) Key].Priority.Count > 0)
        missionDataManager.UpdateReCommandSaveIndex(this.ManorBuildData[(int) Key].Priority[index]);
    }
    if (this.ManorBuildData[(int) Key].CheckIndex < index)
    {
      if (missionDataManager.bFirst == (byte) 0)
      {
        CString cstring1 = StringManager.Instance.StaticString1024();
        CString cstring2 = StringManager.Instance.StaticString1024();
        StringTable mStringTable = DataManager.Instance.mStringTable;
        for (int checkIndex = this.ManorBuildData[(int) Key].CheckIndex; checkIndex < index; ++checkIndex)
        {
          cstring1.ClearString();
          cstring2.ClearString();
          ushort missionId = missionDataManager.GetMissionID(this.ManorBuildData[(int) Key].Priority[checkIndex]);
          if (!missionDataManager.CheckBoolMark(missionId))
          {
            ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(missionId);
            if (missionDataManager.RecommandTable.Achievement[(int) missionId] > (byte) 0)
              missionDataManager.AchievementMgr.UnlockAchievement(missionDataManager.RecommandTable.Achievement[(int) missionId]);
            missionDataManager.GetNarrative(cstring1, ref recordByKey);
            cstring2.StringToFormat(cstring1);
            cstring2.AppendFormat(mStringTable.GetStringByID(7941U));
            GUIManager.Instance.AddHUDQueue(cstring2.ToString(), (ushort) 25);
          }
        }
      }
      else
      {
        missionDataManager.bFirst = byte.MaxValue;
        for (int checkIndex = this.ManorBuildData[(int) Key].CheckIndex; checkIndex < index; ++checkIndex)
        {
          ushort missionId = missionDataManager.GetMissionID(this.ManorBuildData[(int) Key].Priority[checkIndex]);
          if (missionDataManager.RecommandTable.Achievement[(int) missionId] > (byte) 0)
            missionDataManager.AchievementMgr.UnlockAchievement(missionDataManager.RecommandTable.Achievement[(int) missionId]);
        }
      }
    }
    this.ManorBuildData[(int) Key].CondiVal = (int) Val;
    this.ManorBuildData[(int) Key].CheckIndex = index;
    return true;
  }

  public override void UpdateCheckIndex(ushort Key, ushort Val)
  {
    this.ManorBuildData[(int) Key - (int) this.KeyBegin].Reset();
    this.CheckValueChanged(Key, Val);
  }
}
