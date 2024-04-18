// Decompiled with JetBrains decompiler
// Type: EGUIQueueLock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public enum EGUIQueueLock
{
  UIQL_UI_notAllowPopUps = 1,
  UIQL_Battle = 2,
  UIQL_Newbie = 4,
  UIQL_Stage = 8,
  UIQL_Update = 16, // 0x00000010
  UIQL_Hero = 32, // 0x00000020
  UIQL_Transition = 64, // 0x00000040
  UIQL_Mall = 128, // 0x00000080
  UIQL_Expedition = 256, // 0x00000100
  UIQL_Newbie_Protocal_ExtLock = 512, // 0x00000200
  UIQL_BattleReport = 1024, // 0x00000400
  UIQL_ArenaBattle = 2048, // 0x00000800
  UIQL_PetLevelUp = 4096, // 0x00001000
}
