// Decompiled with JetBrains decompiler
// Type: PayErrorCode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal enum PayErrorCode
{
  None = 0,
  ErrorItemIDEmpty = 101, // 0x00000065
  ErrorItemInfo = 102, // 0x00000066
  ErrorNoRelevantInfo = 103, // 0x00000067
  ErrorIggGetway = 104, // 0x00000068
  ErrorIggGetway2 = 105, // 0x00000069
  ErrorPayEmpty = 106, // 0x0000006A
  ErrorPayInfomation = 107, // 0x0000006B
  ErrorPayRelevantInfo = 108, // 0x0000006C
  ErrorPaylaunch = 109, // 0x0000006D
  ErrorPayOther = 110, // 0x0000006E
  ErrorBuyRepeat = 111, // 0x0000006F
  ErrorPaymentIsNotReady = 201, // 0x000000C9
  ErrorPaymentFailed = 202, // 0x000000CA
  ErrorPaymentGetway = 203, // 0x000000CB
}
