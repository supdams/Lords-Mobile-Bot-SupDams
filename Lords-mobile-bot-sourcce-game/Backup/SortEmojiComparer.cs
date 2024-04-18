// Decompiled with JetBrains decompiler
// Type: SortEmojiComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class SortEmojiComparer : IComparer<ushort>
{
  public int Compare(ushort x, ushort y)
  {
    Emote recordByKey1 = DataManager.MapDataController.EmoteTable.GetRecordByKey(x);
    Emote recordByKey2 = DataManager.MapDataController.EmoteTable.GetRecordByKey(y);
    if (!GUIManager.Instance.HasEmotionPck(x) && GUIManager.Instance.HasEmotionPck(y))
      return 1;
    if (GUIManager.Instance.HasEmotionPck(x) && !GUIManager.Instance.HasEmotionPck(y))
      return -1;
    if (DataManager.Instance.CheckEmojiSave(x) && !DataManager.Instance.CheckEmojiSave(y))
      return 1;
    if (!DataManager.Instance.CheckEmojiSave(x) && DataManager.Instance.CheckEmojiSave(y))
      return -1;
    if ((int) recordByKey1.Weight < (int) recordByKey2.Weight)
      return 1;
    return (int) recordByKey1.Weight > (int) recordByKey2.Weight ? -1 : 0;
  }
}
