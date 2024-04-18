// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeQuest : BaseReferenceHolder, IQuest
  {
    private volatile NativeQuestMilestone mCachedMilestone;

    internal NativeQuest(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    public string Id
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => Quest.Quest_Id(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string Name
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => Quest.Quest_Name(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string Description
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => Quest.Quest_Description(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string BannerUrl
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => Quest.Quest_BannerUrl(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string IconUrl
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => Quest.Quest_IconUrl(this.SelfPtr(), out_string, out_size)));
      }
    }

    public DateTime StartTime
    {
      get => PInvokeUtilities.FromMillisSinceUnixEpoch(Quest.Quest_StartTime(this.SelfPtr()));
    }

    public DateTime ExpirationTime
    {
      get => PInvokeUtilities.FromMillisSinceUnixEpoch(Quest.Quest_ExpirationTime(this.SelfPtr()));
    }

    public DateTime? AcceptedTime
    {
      get
      {
        long millisSinceEpoch = Quest.Quest_AcceptedTime(this.SelfPtr());
        return millisSinceEpoch == 0L ? new DateTime?() : new DateTime?(PInvokeUtilities.FromMillisSinceUnixEpoch(millisSinceEpoch));
      }
    }

    public IQuestMilestone Milestone
    {
      get
      {
        if (this.mCachedMilestone == null)
          this.mCachedMilestone = NativeQuestMilestone.FromPointer(Quest.Quest_CurrentMilestone(this.SelfPtr()));
        return (IQuestMilestone) this.mCachedMilestone;
      }
    }

    public GooglePlayGames.BasicApi.Quests.QuestState State
    {
      get
      {
        Types.QuestState questState = Quest.Quest_State(this.SelfPtr());
        switch (questState)
        {
          case Types.QuestState.UPCOMING:
            return GooglePlayGames.BasicApi.Quests.QuestState.Upcoming;
          case Types.QuestState.OPEN:
            return GooglePlayGames.BasicApi.Quests.QuestState.Open;
          case Types.QuestState.ACCEPTED:
            return GooglePlayGames.BasicApi.Quests.QuestState.Accepted;
          case Types.QuestState.COMPLETED:
            return GooglePlayGames.BasicApi.Quests.QuestState.Completed;
          case Types.QuestState.EXPIRED:
            return GooglePlayGames.BasicApi.Quests.QuestState.Expired;
          case Types.QuestState.FAILED:
            return GooglePlayGames.BasicApi.Quests.QuestState.Failed;
          default:
            throw new InvalidOperationException("Unknown state: " + (object) questState);
        }
      }
    }

    internal bool Valid() => Quest.Quest_Valid(this.SelfPtr());

    protected override void CallDispose(HandleRef selfPointer) => Quest.Quest_Dispose(selfPointer);

    public override string ToString()
    {
      if (this.IsDisposed())
        return "[NativeQuest: DELETED]";
      return string.Format("[NativeQuest: Id={0}, Name={1}, Description={2}, BannerUrl={3}, IconUrl={4}, State={5}, StartTime={6}, ExpirationTime={7}, AcceptedTime={8}]", (object) this.Id, (object) this.Name, (object) this.Description, (object) this.BannerUrl, (object) this.IconUrl, (object) this.State, (object) this.StartTime, (object) this.ExpirationTime, (object) this.AcceptedTime);
    }

    internal static NativeQuest FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (NativeQuest) null : new NativeQuest(pointer);
    }
  }
}
