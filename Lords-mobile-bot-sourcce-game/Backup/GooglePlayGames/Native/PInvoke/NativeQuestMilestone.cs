// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeQuestMilestone
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
  internal class NativeQuestMilestone : BaseReferenceHolder, IQuestMilestone
  {
    internal NativeQuestMilestone(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    public string Id
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => QuestMilestone.QuestMilestone_Id(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string EventId
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => QuestMilestone.QuestMilestone_EventId(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string QuestId
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => QuestMilestone.QuestMilestone_QuestId(this.SelfPtr(), out_string, out_size)));
      }
    }

    public ulong CurrentCount => QuestMilestone.QuestMilestone_CurrentCount(this.SelfPtr());

    public ulong TargetCount => QuestMilestone.QuestMilestone_TargetCount(this.SelfPtr());

    public byte[] CompletionRewardData
    {
      get
      {
        return PInvokeUtilities.OutParamsToArray<byte>((PInvokeUtilities.OutMethod<byte>) ((out_bytes, out_size) => QuestMilestone.QuestMilestone_CompletionRewardData(this.SelfPtr(), out_bytes, out_size)));
      }
    }

    public MilestoneState State
    {
      get
      {
        Types.QuestMilestoneState questMilestoneState = QuestMilestone.QuestMilestone_State(this.SelfPtr());
        switch (questMilestoneState)
        {
          case Types.QuestMilestoneState.NOT_STARTED:
            return MilestoneState.NotStarted;
          case Types.QuestMilestoneState.NOT_COMPLETED:
            return MilestoneState.NotCompleted;
          case Types.QuestMilestoneState.COMPLETED_NOT_CLAIMED:
            return MilestoneState.CompletedNotClaimed;
          case Types.QuestMilestoneState.CLAIMED:
            return MilestoneState.Claimed;
          default:
            throw new InvalidOperationException("Unknown state: " + (object) questMilestoneState);
        }
      }
    }

    internal bool Valid() => QuestMilestone.QuestMilestone_Valid(this.SelfPtr());

    protected override void CallDispose(HandleRef selfPointer)
    {
      QuestMilestone.QuestMilestone_Dispose(selfPointer);
    }

    public override string ToString()
    {
      return string.Format("[NativeQuestMilestone: Id={0}, EventId={1}, QuestId={2}, CurrentCount={3}, TargetCount={4}, State={5}]", (object) this.Id, (object) this.EventId, (object) this.QuestId, (object) this.CurrentCount, (object) this.TargetCount, (object) this.State);
    }

    internal static NativeQuestMilestone FromPointer(IntPtr pointer)
    {
      return pointer == IntPtr.Zero ? (NativeQuestMilestone) null : new NativeQuestMilestone(pointer);
    }
  }
}
