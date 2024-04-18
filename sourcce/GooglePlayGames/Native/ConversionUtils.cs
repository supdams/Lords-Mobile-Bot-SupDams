// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.ConversionUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi;
using GooglePlayGames.Native.Cwrapper;
using System;
using UnityEngine;

#nullable disable
namespace GooglePlayGames.Native
{
  internal static class ConversionUtils
  {
    internal static GooglePlayGames.BasicApi.ResponseStatus ConvertResponseStatus(
      CommonErrorStatus.ResponseStatus status)
    {
      switch (status + 5)
      {
        case ~CommonErrorStatus.ResponseStatus.ERROR_LICENSE_CHECK_FAILED:
          return GooglePlayGames.BasicApi.ResponseStatus.Timeout;
        case CommonErrorStatus.ResponseStatus.VALID:
          return GooglePlayGames.BasicApi.ResponseStatus.VersionUpdateRequired;
        case CommonErrorStatus.ResponseStatus.VALID_BUT_STALE:
          return GooglePlayGames.BasicApi.ResponseStatus.NotAuthorized;
        case CommonErrorStatus.ResponseStatus.VALID | CommonErrorStatus.ResponseStatus.VALID_BUT_STALE:
          return GooglePlayGames.BasicApi.ResponseStatus.InternalError;
        case ~CommonErrorStatus.ResponseStatus.ERROR_TIMEOUT:
          return GooglePlayGames.BasicApi.ResponseStatus.LicenseCheckFailed;
        case (CommonErrorStatus.ResponseStatus) 6:
          return GooglePlayGames.BasicApi.ResponseStatus.Success;
        case (CommonErrorStatus.ResponseStatus) 7:
          return GooglePlayGames.BasicApi.ResponseStatus.SuccessWithStale;
        default:
          throw new InvalidOperationException("Unknown status: " + (object) status);
      }
    }

    internal static CommonStatusCodes ConvertResponseStatusToCommonStatus(
      CommonErrorStatus.ResponseStatus status)
    {
      switch (status + 5)
      {
        case ~CommonErrorStatus.ResponseStatus.ERROR_LICENSE_CHECK_FAILED:
          return CommonStatusCodes.Timeout;
        case CommonErrorStatus.ResponseStatus.VALID:
          return CommonStatusCodes.ServiceVersionUpdateRequired;
        case CommonErrorStatus.ResponseStatus.VALID_BUT_STALE:
          return CommonStatusCodes.AuthApiAccessForbidden;
        case CommonErrorStatus.ResponseStatus.VALID | CommonErrorStatus.ResponseStatus.VALID_BUT_STALE:
          return CommonStatusCodes.InternalError;
        case ~CommonErrorStatus.ResponseStatus.ERROR_TIMEOUT:
          return CommonStatusCodes.LicenseCheckFailed;
        case (CommonErrorStatus.ResponseStatus) 6:
          return CommonStatusCodes.Success;
        case (CommonErrorStatus.ResponseStatus) 7:
          return CommonStatusCodes.SuccessCached;
        default:
          Debug.LogWarning((object) ("Unknown ResponseStatus: " + (object) status + ", defaulting to CommonStatusCodes.Error"));
          return CommonStatusCodes.Error;
      }
    }

    internal static GooglePlayGames.BasicApi.UIStatus ConvertUIStatus(
      CommonErrorStatus.UIStatus status)
    {
      switch (status + 12)
      {
        case ~(CommonErrorStatus.UIStatus.ERROR_INTERNAL | CommonErrorStatus.UIStatus.VALID):
          return GooglePlayGames.BasicApi.UIStatus.UiBusy;
        case (CommonErrorStatus.UIStatus) 6:
          return GooglePlayGames.BasicApi.UIStatus.UserClosedUI;
        case (CommonErrorStatus.UIStatus) 7:
          return GooglePlayGames.BasicApi.UIStatus.Timeout;
        case (CommonErrorStatus.UIStatus) 8:
          return GooglePlayGames.BasicApi.UIStatus.VersionUpdateRequired;
        case (CommonErrorStatus.UIStatus) 9:
          return GooglePlayGames.BasicApi.UIStatus.NotAuthorized;
        case ~(CommonErrorStatus.UIStatus.ERROR_UI_BUSY | CommonErrorStatus.UIStatus.VALID):
          return GooglePlayGames.BasicApi.UIStatus.InternalError;
        case (CommonErrorStatus.UIStatus) 13:
          return GooglePlayGames.BasicApi.UIStatus.Valid;
        default:
          throw new InvalidOperationException("Unknown status: " + (object) status);
      }
    }

    internal static GooglePlayGames.Native.Cwrapper.Types.DataSource AsDataSource(GooglePlayGames.BasicApi.DataSource source)
    {
      switch (source)
      {
        case GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork:
          return GooglePlayGames.Native.Cwrapper.Types.DataSource.CACHE_OR_NETWORK;
        case GooglePlayGames.BasicApi.DataSource.ReadNetworkOnly:
          return GooglePlayGames.Native.Cwrapper.Types.DataSource.NETWORK_ONLY;
        default:
          throw new InvalidOperationException("Found unhandled DataSource: " + (object) source);
      }
    }
  }
}
