// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeEndpointDetails
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeEndpointDetails : BaseReferenceHolder
  {
    internal NativeEndpointDetails(IntPtr pointer)
      : base(pointer)
    {
    }

    internal string EndpointId()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_arg, out_size) => NearbyConnectionTypes.EndpointDetails_GetEndpointId(this.SelfPtr(), out_arg, out_size)));
    }

    internal string DeviceId()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_arg, out_size) => NearbyConnectionTypes.EndpointDetails_GetDeviceId(this.SelfPtr(), out_arg, out_size)));
    }

    internal string Name()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_arg, out_size) => NearbyConnectionTypes.EndpointDetails_GetName(this.SelfPtr(), out_arg, out_size)));
    }

    internal string ServiceId()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_arg, out_size) => NearbyConnectionTypes.EndpointDetails_GetServiceId(this.SelfPtr(), out_arg, out_size)));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      NearbyConnectionTypes.EndpointDetails_Dispose(selfPointer);
    }

    internal EndpointDetails ToDetails()
    {
      return new EndpointDetails(this.EndpointId(), this.DeviceId(), this.Name(), this.ServiceId());
    }

    internal static NativeEndpointDetails FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (NativeEndpointDetails) null : new NativeEndpointDetails(pointer);
    }
  }
}
