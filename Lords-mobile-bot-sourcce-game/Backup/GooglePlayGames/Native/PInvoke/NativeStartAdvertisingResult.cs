// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeStartAdvertisingResult
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
  internal class NativeStartAdvertisingResult : BaseReferenceHolder
  {
    internal NativeStartAdvertisingResult(IntPtr pointer)
      : base(pointer)
    {
    }

    internal int GetStatus()
    {
      return NearbyConnectionTypes.StartAdvertisingResult_GetStatus(this.SelfPtr());
    }

    internal string LocalEndpointName()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_arg, out_size) => NearbyConnectionTypes.StartAdvertisingResult_GetLocalEndpointName(this.SelfPtr(), out_arg, out_size)));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      NearbyConnectionTypes.StartAdvertisingResult_Dispose(selfPointer);
    }

    internal AdvertisingResult AsResult()
    {
      return new AdvertisingResult((GooglePlayGames.BasicApi.ResponseStatus) Enum.ToObject(typeof (GooglePlayGames.BasicApi.ResponseStatus), this.GetStatus()), this.LocalEndpointName());
    }

    internal static NativeStartAdvertisingResult FromPointer(IntPtr pointer)
    {
      return pointer == IntPtr.Zero ? (NativeStartAdvertisingResult) null : new NativeStartAdvertisingResult(pointer);
    }
  }
}
