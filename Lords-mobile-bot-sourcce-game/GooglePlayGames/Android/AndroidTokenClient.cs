// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Android.AndroidTokenClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using Com.Google.Android.Gms.Common.Api;
using GooglePlayGames.OurUtils;
using System;
using UnityEngine;

#nullable disable
namespace GooglePlayGames.Android
{
  internal class AndroidTokenClient : TokenClient
  {
    private const string TokenFragmentClass = "com.google.games.bridge.TokenFragment";
    private const string FetchTokenSignature = "(Landroid/app/Activity;Ljava/lang/String;ZZZLjava/lang/String;)Lcom/google/android/gms/common/api/PendingResult;";
    private const string FetchTokenMethod = "fetchToken";
    private bool fetchingEmail;
    private bool fetchingAccessToken;
    private bool fetchingIdToken;
    private string accountName;
    private string accessToken;
    private string idToken;
    private string idTokenScope;
    private Action<string> idTokenCb;
    private string rationale;
    private bool apiAccessDenied;
    private int apiWarningFreq = 100000;
    private int apiWarningCount;
    private int webClientWarningFreq = 100000;
    private int webClientWarningCount;

    public static AndroidJavaObject GetActivity()
    {
      using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        return androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
    }

    public void SetRationale(string rationale) => this.rationale = rationale;

    internal void Fetch(
      string scope,
      bool fetchEmail,
      bool fetchAccessToken,
      bool fetchIdToken,
      Action<bool> doneCallback)
    {
      if (this.apiAccessDenied)
      {
        if (this.apiWarningCount++ % this.apiWarningFreq == 0)
        {
          Logger.w("Access to API denied");
          this.apiWarningCount = this.apiWarningCount / this.apiWarningFreq + 1;
        }
        doneCallback(false);
      }
      else
        PlayGamesHelperObject.RunOnGameThread((Action) (() => AndroidTokenClient.FetchToken(scope, this.rationale, fetchEmail, fetchAccessToken, fetchIdToken, (Action<int, string, string, string>) ((rc, access, id, email) =>
        {
          if (rc != 0)
          {
            this.apiAccessDenied = rc == 3001;
            Logger.w("Non-success returned from fetch: " + (object) rc);
            doneCallback(false);
          }
          else
          {
            if (fetchAccessToken)
              Logger.d("a = " + access);
            if (fetchEmail)
              Logger.d("email = " + email);
            if (fetchIdToken)
              Logger.d("idt = " + id);
            if (fetchAccessToken && !string.IsNullOrEmpty(access))
              this.accessToken = access;
            if (fetchIdToken && !string.IsNullOrEmpty(id))
            {
              this.idToken = id;
              this.idTokenCb(this.idToken);
            }
            if (fetchEmail && !string.IsNullOrEmpty(email))
              this.accountName = email;
            doneCallback(true);
          }
        }))));
    }

    internal static void FetchToken(
      string scope,
      string rationale,
      bool fetchEmail,
      bool fetchAccessToken,
      bool fetchIdToken,
      Action<int, string, string, string> callback)
    {
      object[] args = new object[6];
      jvalue[] jniArgArray = AndroidJNIHelper.CreateJNIArgArray(args);
      try
      {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.TokenFragment"))
        {
          using (AndroidJavaObject activity = AndroidTokenClient.GetActivity())
          {
            IntPtr staticMethodId = AndroidJNI.GetStaticMethodID(androidJavaClass.GetRawClass(), "fetchToken", "(Landroid/app/Activity;Ljava/lang/String;ZZZLjava/lang/String;)Lcom/google/android/gms/common/api/PendingResult;");
            jniArgArray[0].l = activity.GetRawObject();
            jniArgArray[1].l = AndroidJNI.NewStringUTF(rationale);
            jniArgArray[2].z = fetchEmail;
            jniArgArray[3].z = fetchAccessToken;
            jniArgArray[4].z = fetchIdToken;
            jniArgArray[5].l = AndroidJNI.NewStringUTF(scope);
            new PendingResult<TokenResult>(AndroidJNI.CallStaticObjectMethod(androidJavaClass.GetRawClass(), staticMethodId, jniArgArray)).setResultCallback((ResultCallback<TokenResult>) new TokenResultCallback(callback));
          }
        }
      }
      catch (Exception ex)
      {
        Logger.e("Exception launching token request: " + ex.Message);
        Logger.e(ex.ToString());
      }
      finally
      {
        AndroidJNIHelper.DeleteJNIArgArray(args, jniArgArray);
      }
    }

    private string GetAccountName()
    {
      if (string.IsNullOrEmpty(this.accountName) && !this.fetchingEmail)
      {
        this.fetchingEmail = true;
        this.Fetch(this.idTokenScope, true, false, false, (Action<bool>) (ok => this.fetchingEmail = false));
      }
      return this.accountName;
    }

    public string GetEmail() => this.GetAccountName();

    public string GetAccessToken()
    {
      if (string.IsNullOrEmpty(this.accessToken) && !this.fetchingAccessToken)
      {
        this.fetchingAccessToken = true;
        this.Fetch(this.idTokenScope, false, true, false, (Action<bool>) (rc => this.fetchingAccessToken = false));
      }
      return this.accessToken;
    }

    [Obsolete("Use PlayGamesPlatform.GetServerAuthCode()")]
    public void GetIdToken(string serverClientId, Action<string> idTokenCallback)
    {
      if (string.IsNullOrEmpty(serverClientId))
      {
        if (this.webClientWarningCount++ % this.webClientWarningFreq == 0)
        {
          Logger.w("serverClientId is empty, cannot get Id Token");
          this.webClientWarningCount = this.webClientWarningCount / this.webClientWarningFreq + 1;
        }
        idTokenCallback((string) null);
      }
      else
      {
        string str = "audience:server:client_id:" + serverClientId;
        if (string.IsNullOrEmpty(this.idToken) || str != this.idTokenScope)
        {
          if (this.fetchingIdToken)
            return;
          this.fetchingIdToken = true;
          this.idTokenScope = str;
          this.idTokenCb = idTokenCallback;
          this.Fetch(this.idTokenScope, false, false, true, (Action<bool>) (ok =>
          {
            this.fetchingIdToken = false;
            if (!ok)
              this.idTokenCb((string) null);
            else
              this.idTokenCb(this.idToken);
          }));
        }
        else
          idTokenCallback(this.idToken);
      }
    }
  }
}
