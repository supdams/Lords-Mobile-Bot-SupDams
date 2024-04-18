// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.RealtimeRoomConfigBuilder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class RealtimeRoomConfigBuilder : BaseReferenceHolder
  {
    internal RealtimeRoomConfigBuilder(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal RealtimeRoomConfigBuilder PopulateFromUIResponse(PlayerSelectUIResponse response)
    {
      RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_PopulateFromPlayerSelectUIResponse(this.SelfPtr(), response.AsPointer());
      return this;
    }

    internal RealtimeRoomConfigBuilder SetVariant(uint variantValue)
    {
      uint variant = variantValue != 0U ? variantValue : uint.MaxValue;
      RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetVariant(this.SelfPtr(), variant);
      return this;
    }

    internal RealtimeRoomConfigBuilder AddInvitedPlayer(string playerId)
    {
      RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_AddPlayerToInvite(this.SelfPtr(), playerId);
      return this;
    }

    internal RealtimeRoomConfigBuilder SetExclusiveBitMask(ulong bitmask)
    {
      RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetExclusiveBitMask(this.SelfPtr(), bitmask);
      return this;
    }

    internal RealtimeRoomConfigBuilder SetMinimumAutomatchingPlayers(uint minimum)
    {
      RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetMinimumAutomatchingPlayers(this.SelfPtr(), minimum);
      return this;
    }

    internal RealtimeRoomConfigBuilder SetMaximumAutomatchingPlayers(uint maximum)
    {
      RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetMaximumAutomatchingPlayers(this.SelfPtr(), maximum);
      return this;
    }

    internal RealtimeRoomConfig Build()
    {
      return new RealtimeRoomConfig(RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_Create(this.SelfPtr()));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_Dispose(selfPointer);
    }

    internal static RealtimeRoomConfigBuilder Create()
    {
      return new RealtimeRoomConfigBuilder(RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_Construct());
    }
  }
}
