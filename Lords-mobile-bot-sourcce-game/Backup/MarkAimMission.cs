// Decompiled with JetBrains decompiler
// Type: MarkAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MarkAimMission : ManorAimEver
{
  public MarkAimMission(ushort[] RecordMark)
    : base(RecordMark)
  {
    this.KeyBegin = (ushort) 101;
    this.ManorBuildData = new ManorCheck[RecordMark.Length - (int) this.KeyBegin];
    this.Init();
  }

  public override void AddDataFail(ushort Priority)
  {
    DataManager.MissionDataManager.RecommandTable.RecommandID[(int) Priority] = (ushort) 0;
  }

  public override bool CheckValueChanged(ushort Key, ushort Val)
  {
    switch (Key)
    {
      case 103:
        switch ((EActivityCircleEventType) Val)
        {
          case EActivityCircleEventType.EACET_SoloEvent:
            ActivityDataType activityDataType1 = ActivityManager.Instance.ActivityData[(int) Val];
            ushort num1 = 0;
            for (int index = 0; index < 3; ++index)
            {
              if (activityDataType1.RequireScore[index] > 0U && activityDataType1.EventScore >= (ulong) activityDataType1.RequireScore[index])
                ++num1;
            }
            if ((int) this.RecordMark[(int) Key - (int) this.KeyBegin] >= (int) num1)
              return false;
            Val = num1;
            break;
          case EActivityCircleEventType.EACET_InfernalEvent:
            Key = (ushort) 104;
            goto case EActivityCircleEventType.EACET_SoloEvent;
          default:
            return false;
        }
        break;
      case 136:
        switch (Val)
        {
          case 0:
            ActivityDataType activityDataType2 = ActivityManager.Instance.KvKActivityData[(int) Val];
            ushort num2 = 0;
            for (int index = 0; index < 3; ++index)
            {
              if (activityDataType2.RequireScore[index] > 0U && activityDataType2.EventScore >= (ulong) activityDataType2.RequireScore[index])
                ++num2;
            }
            if ((int) this.RecordMark[(int) Key - (int) this.KeyBegin] >= (int) num2)
              return false;
            Val = num2;
            break;
          case 2:
            Key = (ushort) 138;
            goto case 0;
          case 3:
            Key = (ushort) 137;
            goto case 0;
          default:
            return false;
        }
        break;
    }
    if (DataManager.MissionDataManager.GetMarkNarrativeType(Key) == _eMarkAimNarrativeType.Accumlate)
      this.RecordMark[(int) Key] += Val;
    else if ((int) this.RecordMark[(int) Key] < (int) Val)
      this.RecordMark[(int) Key] = Val;
    if (!base.CheckValueChanged(Key, this.RecordMark[(int) Key]))
      return false;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    return true;
  }

  public override void SetCompleteWhileLogin()
  {
    for (ushort index = 0; (int) index < this.ManorBuildData.Length; ++index)
      base.CheckValueChanged((ushort) ((uint) this.KeyBegin + (uint) index), this.RecordMark[(int) this.KeyBegin + (int) index]);
  }
}
