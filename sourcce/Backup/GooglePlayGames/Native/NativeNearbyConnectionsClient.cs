// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.NativeNearbyConnectionsClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace GooglePlayGames.Native
{
  internal class NativeNearbyConnectionsClient : INearbyConnectionClient
  {
    private readonly NearbyConnectionsManager mManager;

    internal NativeNearbyConnectionsClient(NearbyConnectionsManager manager)
    {
      this.mManager = Misc.CheckNotNull<NearbyConnectionsManager>(manager);
    }

    public int MaxUnreliableMessagePayloadLength() => 1168;

    public int MaxReliableMessagePayloadLength() => 4096;

    public void SendReliable(List<string> recipientEndpointIds, byte[] payload)
    {
      this.InternalSend(recipientEndpointIds, payload, true);
    }

    public void SendUnreliable(List<string> recipientEndpointIds, byte[] payload)
    {
      this.InternalSend(recipientEndpointIds, payload, false);
    }

    private void InternalSend(List<string> recipientEndpointIds, byte[] payload, bool isReliable)
    {
      if (recipientEndpointIds == null)
        throw new ArgumentNullException(nameof (recipientEndpointIds));
      if (payload == null)
        throw new ArgumentNullException(nameof (payload));
      if (recipientEndpointIds.Contains((string) null))
        throw new InvalidOperationException("Cannot send a message to a null recipient");
      if (recipientEndpointIds.Count == 0)
      {
        Logger.w("Attempted to send a reliable message with no recipients");
      }
      else
      {
        if (isReliable)
        {
          if (payload.Length > this.MaxReliableMessagePayloadLength())
            throw new InvalidOperationException("cannot send more than " + (object) this.MaxReliableMessagePayloadLength() + " bytes");
        }
        else if (payload.Length > this.MaxUnreliableMessagePayloadLength())
          throw new InvalidOperationException("cannot send more than " + (object) this.MaxUnreliableMessagePayloadLength() + " bytes");
        foreach (string recipientEndpointId in recipientEndpointIds)
        {
          if (isReliable)
            this.mManager.SendReliable(recipientEndpointId, payload);
          else
            this.mManager.SendUnreliable(recipientEndpointId, payload);
        }
      }
    }

    public void StartAdvertising(
      string name,
      List<string> appIdentifiers,
      TimeSpan? advertisingDuration,
      Action<AdvertisingResult> resultCallback,
      Action<ConnectionRequest> requestCallback)
    {
      Misc.CheckNotNull<List<string>>(appIdentifiers, nameof (appIdentifiers));
      Misc.CheckNotNull<Action<AdvertisingResult>>(resultCallback, nameof (resultCallback));
      Misc.CheckNotNull<Action<ConnectionRequest>>(requestCallback, "connectionRequestCallback");
      if (advertisingDuration.HasValue && advertisingDuration.Value.Ticks < 0L)
        throw new InvalidOperationException("advertisingDuration must be positive");
      resultCallback = Callbacks.AsOnGameThreadCallback<AdvertisingResult>(resultCallback);
      requestCallback = Callbacks.AsOnGameThreadCallback<ConnectionRequest>(requestCallback);
      this.mManager.StartAdvertising(name, appIdentifiers.Select<string, NativeAppIdentifier>(new Func<string, NativeAppIdentifier>(NativeAppIdentifier.FromString)).ToList<NativeAppIdentifier>(), NativeNearbyConnectionsClient.ToTimeoutMillis(advertisingDuration), (Action<long, NativeStartAdvertisingResult>) ((localClientId, result) => resultCallback(result.AsResult())), (Action<long, NativeConnectionRequest>) ((localClientId, request) => requestCallback(request.AsRequest())));
    }

    private static long ToTimeoutMillis(TimeSpan? span)
    {
      return span.HasValue ? PInvokeUtilities.ToMilliseconds(span.Value) : 0L;
    }

    public void StopAdvertising() => this.mManager.StopAdvertising();

    public void SendConnectionRequest(
      string name,
      string remoteEndpointId,
      byte[] payload,
      Action<ConnectionResponse> responseCallback,
      IMessageListener listener)
    {
      Misc.CheckNotNull<string>(remoteEndpointId, nameof (remoteEndpointId));
      Misc.CheckNotNull<byte[]>(payload, nameof (payload));
      Misc.CheckNotNull<Action<ConnectionResponse>>(responseCallback, nameof (responseCallback));
      Misc.CheckNotNull<IMessageListener>(listener, nameof (listener));
      responseCallback = Callbacks.AsOnGameThreadCallback<ConnectionResponse>(responseCallback);
      using (NativeMessageListenerHelper messageListener = NativeNearbyConnectionsClient.ToMessageListener(listener))
        this.mManager.SendConnectionRequest(name, remoteEndpointId, payload, (Action<long, NativeConnectionResponse>) ((localClientId, response) => responseCallback(response.AsResponse(localClientId))), messageListener);
    }

    private static NativeMessageListenerHelper ToMessageListener(IMessageListener listener)
    {
      listener = (IMessageListener) new NativeNearbyConnectionsClient.OnGameThreadMessageListener(listener);
      NativeMessageListenerHelper messageListener = new NativeMessageListenerHelper();
      messageListener.SetOnMessageReceivedCallback((NativeMessageListenerHelper.OnMessageReceived) ((localClientId, endpointId, data, isReliable) => listener.OnMessageReceived(endpointId, data, isReliable)));
      messageListener.SetOnDisconnectedCallback((Action<long, string>) ((localClientId, endpointId) => listener.OnRemoteEndpointDisconnected(endpointId)));
      return messageListener;
    }

    public void AcceptConnectionRequest(
      string remoteEndpointId,
      byte[] payload,
      IMessageListener listener)
    {
      Misc.CheckNotNull<string>(remoteEndpointId, nameof (remoteEndpointId));
      Misc.CheckNotNull<byte[]>(payload, nameof (payload));
      Misc.CheckNotNull<IMessageListener>(listener, nameof (listener));
      Logger.d("Calling AcceptConncectionRequest");
      this.mManager.AcceptConnectionRequest(remoteEndpointId, payload, NativeNearbyConnectionsClient.ToMessageListener(listener));
      Logger.d("Called!");
    }

    public void StartDiscovery(
      string serviceId,
      TimeSpan? advertisingTimeout,
      IDiscoveryListener listener)
    {
      Misc.CheckNotNull<string>(serviceId, nameof (serviceId));
      Misc.CheckNotNull<IDiscoveryListener>(listener, nameof (listener));
      using (NativeEndpointDiscoveryListenerHelper discoveryListener = NativeNearbyConnectionsClient.ToDiscoveryListener(listener))
        this.mManager.StartDiscovery(serviceId, NativeNearbyConnectionsClient.ToTimeoutMillis(advertisingTimeout), discoveryListener);
    }

    private static NativeEndpointDiscoveryListenerHelper ToDiscoveryListener(
      IDiscoveryListener listener)
    {
      listener = (IDiscoveryListener) new NativeNearbyConnectionsClient.OnGameThreadDiscoveryListener(listener);
      NativeEndpointDiscoveryListenerHelper discoveryListener = new NativeEndpointDiscoveryListenerHelper();
      discoveryListener.SetOnEndpointFound((Action<long, NativeEndpointDetails>) ((localClientId, endpoint) => listener.OnEndpointFound(endpoint.ToDetails())));
      discoveryListener.SetOnEndpointLostCallback((Action<long, string>) ((localClientId, lostEndpointId) => listener.OnEndpointLost(lostEndpointId)));
      return discoveryListener;
    }

    public void StopDiscovery(string serviceId)
    {
      Misc.CheckNotNull<string>(serviceId, nameof (serviceId));
      this.mManager.StopDiscovery(serviceId);
    }

    public void RejectConnectionRequest(string requestingEndpointId)
    {
      Misc.CheckNotNull<string>(requestingEndpointId, nameof (requestingEndpointId));
      this.mManager.RejectConnectionRequest(requestingEndpointId);
    }

    public void DisconnectFromEndpoint(string remoteEndpointId)
    {
      this.mManager.DisconnectFromEndpoint(remoteEndpointId);
    }

    public void StopAllConnections() => this.mManager.StopAllConnections();

    public string LocalEndpointId() => this.mManager.LocalEndpointId();

    public string LocalDeviceId() => this.mManager.LocalDeviceId();

    public string GetAppBundleId() => this.mManager.AppBundleId;

    public string GetServiceId() => NearbyConnectionsManager.ServiceId;

    protected class OnGameThreadMessageListener : IMessageListener
    {
      private readonly IMessageListener mListener;

      public OnGameThreadMessageListener(IMessageListener listener)
      {
        this.mListener = Misc.CheckNotNull<IMessageListener>(listener);
      }

      public void OnMessageReceived(string remoteEndpointId, byte[] data, bool isReliableMessage)
      {
        PlayGamesHelperObject.RunOnGameThread((Action) (() => this.mListener.OnMessageReceived(remoteEndpointId, data, isReliableMessage)));
      }

      public void OnRemoteEndpointDisconnected(string remoteEndpointId)
      {
        PlayGamesHelperObject.RunOnGameThread((Action) (() => this.mListener.OnRemoteEndpointDisconnected(remoteEndpointId)));
      }
    }

    protected class OnGameThreadDiscoveryListener : IDiscoveryListener
    {
      private readonly IDiscoveryListener mListener;

      public OnGameThreadDiscoveryListener(IDiscoveryListener listener)
      {
        this.mListener = Misc.CheckNotNull<IDiscoveryListener>(listener);
      }

      public void OnEndpointFound(EndpointDetails discoveredEndpoint)
      {
        PlayGamesHelperObject.RunOnGameThread((Action) (() => this.mListener.OnEndpointFound(discoveredEndpoint)));
      }

      public void OnEndpointLost(string lostEndpointId)
      {
        PlayGamesHelperObject.RunOnGameThread((Action) (() => this.mListener.OnEndpointLost(lostEndpointId)));
      }
    }
  }
}
