// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Android.AndroidClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using System;
using UnityEngine;

#nullable disable
namespace GooglePlayGames.Android
{
  internal class AndroidClient : IClientImpl
  {
    internal const string BridgeActivityClass = "com.google.games.bridge.NativeBridgeActivity";
    private const string LaunchBridgeMethod = "launchBridgeIntent";
    private const string LaunchBridgeSignature = "(Landroid/app/Activity;Landroid/content/Intent;)V";
    private TokenClient tokenClient;

    public PlatformConfiguration CreatePlatformConfiguration()
    {
      AndroidPlatformConfiguration platformConfiguration = AndroidPlatformConfiguration.Create();
      using (AndroidJavaObject activity = AndroidTokenClient.GetActivity())
      {
        platformConfiguration.SetActivity(activity.GetRawObject());
        platformConfiguration.SetOptionalIntentHandlerForUI((Action<IntPtr>) (intent =>
        {
          IntPtr intentRef = AndroidJNI.NewGlobalRef(intent);
          PlayGamesHelperObject.RunOnGameThread((Action) (() =>
          {
            try
            {
              AndroidClient.LaunchBridgeIntent(intentRef);
            }
            finally
            {
              AndroidJNI.DeleteGlobalRef(intentRef);
            }
          }));
        }));
      }
      return (PlatformConfiguration) platformConfiguration;
    }

    public TokenClient CreateTokenClient(bool reset)
    {
      if (this.tokenClient == null || reset)
        this.tokenClient = (TokenClient) new AndroidTokenClient();
      return this.tokenClient;
    }

    private static void LaunchBridgeIntent(IntPtr bridgedIntent)
    {
      object[] args = new object[2];
      jvalue[] jniArgArray = AndroidJNIHelper.CreateJNIArgArray(args);
      try
      {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.NativeBridgeActivity"))
        {
          using (AndroidJavaObject activity = AndroidTokenClient.GetActivity())
          {
            IntPtr staticMethodId = AndroidJNI.GetStaticMethodID(androidJavaClass.GetRawClass(), "launchBridgeIntent", "(Landroid/app/Activity;Landroid/content/Intent;)V");
            jniArgArray[0].l = activity.GetRawObject();
            jniArgArray[1].l = bridgedIntent;
            AndroidJNI.CallStaticVoidMethod(androidJavaClass.GetRawClass(), staticMethodId, jniArgArray);
          }
        }
      }
      catch (Exception ex)
      {
        Logger.e("Exception launching bridge intent: " + ex.Message);
        Logger.e(ex.ToString());
      }
      finally
      {
        AndroidJNIHelper.DeleteJNIArgArray(args, jniArgArray);
      }
    }
  }
}
