// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.TokenClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
namespace GooglePlayGames
{
  internal interface TokenClient
  {
    string GetEmail();

    string GetAccessToken();

    void GetIdToken(string serverClientId, Action<string> idTokenCallback);

    void SetRationale(string rationale);
  }
}
