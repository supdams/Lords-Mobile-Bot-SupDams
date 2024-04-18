// Decompiled with JetBrains decompiler
// Type: QueueBarDataComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class QueueBarDataComparer : IComparer<byte>
{
  public int Compare(byte x, byte y)
  {
    QueueBarData queueBarData1 = DataManager.Instance.queueBarData[(int) x];
    QueueBarData queueBarData2 = DataManager.Instance.queueBarData[(int) y];
    if (!queueBarData1.bActive)
      return queueBarData2.bActive ? 1 : 0;
    if (!queueBarData2.bActive)
      return -1;
    eTimerSpriteType queueBarSpriteType1 = DataManager.Instance.GetQueueBarSpriteType((EQueueBarIndex) x);
    eTimerSpriteType queueBarSpriteType2 = DataManager.Instance.GetQueueBarSpriteType((EQueueBarIndex) y);
    if (queueBarSpriteType1 != eTimerSpriteType.Idle && queueBarSpriteType2 == eTimerSpriteType.Idle)
      return 1;
    if (queueBarSpriteType1 == eTimerSpriteType.Idle && queueBarSpriteType2 != eTimerSpriteType.Idle)
      return -1;
    if (queueBarSpriteType1 != eTimerSpriteType.Free && queueBarSpriteType2 == eTimerSpriteType.Free)
      return 1;
    if (queueBarSpriteType1 == eTimerSpriteType.Free && queueBarSpriteType2 != eTimerSpriteType.Free)
      return -1;
    if (queueBarSpriteType1 != eTimerSpriteType.Help && queueBarSpriteType2 == eTimerSpriteType.Help)
      return 1;
    if (queueBarSpriteType1 == eTimerSpriteType.Help && queueBarSpriteType2 != eTimerSpriteType.Help)
      return -1;
    if (queueBarData1.StartTime < queueBarData2.StartTime)
      return 1;
    return queueBarData1.StartTime > queueBarData2.StartTime ? -1 : 0;
  }
}
