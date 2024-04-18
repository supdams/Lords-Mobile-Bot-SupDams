// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Quests.IQuestsClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GooglePlayGames.BasicApi.Quests
{
  public interface IQuestsClient
  {
    void Fetch(DataSource source, string questId, Action<ResponseStatus, IQuest> callback);

    void FetchMatchingState(
      DataSource source,
      QuestFetchFlags flags,
      Action<ResponseStatus, List<IQuest>> callback);

    void ShowAllQuestsUI(
      Action<QuestUiResult, IQuest, IQuestMilestone> callback);

    void ShowSpecificQuestUI(
      IQuest quest,
      Action<QuestUiResult, IQuest, IQuestMilestone> callback);

    void Accept(IQuest quest, Action<QuestAcceptStatus, IQuest> callback);

    void ClaimMilestone(
      IQuestMilestone milestone,
      Action<QuestClaimMilestoneStatus, IQuest, IQuestMilestone> callback);
  }
}
