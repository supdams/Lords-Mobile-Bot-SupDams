// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Android.TokenResultCallback
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using Com.Google.Android.Gms.Common.Api;
using System;

#nullable disable
namespace GooglePlayGames.Android
{
  internal class TokenResultCallback : ResultCallbackProxy<TokenResult>
  {
    private Action<int, string, string, string> callback;

    public TokenResultCallback(Action<int, string, string, string> callback)
    {
      this.callback = callback;
    }

    public override void OnResult(TokenResult arg_Result_1)
    {
      this.callback(arg_Result_1.getStatus().getStatusCode(), arg_Result_1.getAccessToken(), arg_Result_1.getIdToken(), arg_Result_1.getEmail());
    }
  }
}
