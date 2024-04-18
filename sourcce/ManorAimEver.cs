// Decompiled with JetBrains decompiler
// Type: ManorAimEver
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class ManorAimEver : ManorAimChecked
{
  protected ushort[] RecordMark;

  public ManorAimEver(ushort[] RecordMark) => this.RecordMark = RecordMark;

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    Key -= this.KeyBegin;
    if (this.ManorBuildData.Length <= (int) Key || this.ManorBuildData[(int) Key].CondiVal >= (int) Val || this.ManorBuildData[(int) Key].CheckIndex >= this.ManorBuildData[(int) Key].LvCondi.Count)
      return false;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    int checkIndex1;
    for (checkIndex1 = this.ManorBuildData[(int) Key].CheckIndex; checkIndex1 < this.ManorBuildData[(int) Key].LvCondi.Count && (int) this.ManorBuildData[(int) Key].LvCondi[checkIndex1] <= (int) Val; ++checkIndex1)
      missionDataManager.AddRewardMission(this.ManorBuildData[(int) Key].Priority[checkIndex1]);
    if (this.ManorBuildData[(int) Key].CheckIndex < checkIndex1)
    {
      if (missionDataManager.bFirst == (byte) 0)
      {
        CString cstring1 = StringManager.Instance.StaticString1024();
        CString cstring2 = StringManager.Instance.StaticString1024();
        StringTable mStringTable = DataManager.Instance.mStringTable;
        for (int checkIndex2 = this.ManorBuildData[(int) Key].CheckIndex; checkIndex2 < checkIndex1; ++checkIndex2)
        {
          cstring1.ClearString();
          cstring2.ClearString();
          ushort missionId = missionDataManager.GetMissionID(this.ManorBuildData[(int) Key].Priority[checkIndex2]);
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
        for (int checkIndex3 = this.ManorBuildData[(int) Key].CheckIndex; checkIndex3 < checkIndex1; ++checkIndex3)
        {
          ushort missionId = missionDataManager.GetMissionID(this.ManorBuildData[(int) Key].Priority[checkIndex3]);
          if (missionDataManager.RecommandTable.Achievement[(int) missionId] > (byte) 0)
            missionDataManager.AchievementMgr.UnlockAchievement(missionDataManager.RecommandTable.Achievement[(int) missionId]);
        }
      }
    }
    this.ManorBuildData[(int) Key].CondiVal = (int) Val;
    this.ManorBuildData[(int) Key].CheckIndex = checkIndex1;
    return true;
  }

  public override void UpdateCheckIndex(ushort Key, ushort Val) => this.CheckValueChanged(Key, Val);
}
