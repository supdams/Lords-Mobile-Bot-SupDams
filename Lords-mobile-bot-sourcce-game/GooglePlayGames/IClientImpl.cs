﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.IClientImpl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.PInvoke;

#nullable disable
namespace GooglePlayGames
{
  internal interface IClientImpl
  {
    PlatformConfiguration CreatePlatformConfiguration();

    TokenClient CreateTokenClient(bool reset);
  }
}