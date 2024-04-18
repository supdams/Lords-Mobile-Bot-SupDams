// Decompiled with JetBrains decompiler
// Type: TalkDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class TalkDataType
{
  public byte TalkKind;
  public byte FuncKind;
  public long PlayID;
  public ushort PlayerPicID;
  public byte VIPRank;
  public byte TitleID;
  public ushort WTitleID;
  public ushort NTitleID;
  public byte SpecialBlockID;
  public CString TitleName;
  public CString PlayerName;
  public CString ShowName;
  public CString MainText;
  public CString OriginalText;
  public long TalkTime;
  public long TalkID;
  public float TotalHeight;
  public byte AllyRank;
  public CString NickNameText;
  public ushort KingdomID;
  public byte bHaveArabic;
  public byte TitleLine;
  public byte bCheckDirtyWord;
  public Vector2[] TitlePos = new Vector2[2];
  public bool bHasLoc;
  public bool bHasLocT;
  public int BeginIndex = -1;
  public int EndIndex = -1;
  public int BeginIndexT = -1;
  public int EndIndexT = -1;
  public int King = -1;
  public int LocX = -1;
  public int LocY = -1;
  public long NPCID;
  public byte TranslateShow = 1;
  public ushort TranslateLanguage;
  public eTranslateState TranslateState;
  public CString TranslateText;
  public float TotalHeightT;
  public ushort EmojiKey;

  public TalkDataType()
  {
    this.TitleName = new CString(4);
    this.PlayerName = new CString(13);
    this.ShowName = new CString(29);
    this.MainText = new CString(431);
    this.OriginalText = new CString(401);
    this.TranslateText = new CString(431);
    this.NickNameText = new CString(11);
  }

  public void Initial()
  {
    this.TalkKind = (byte) 0;
    this.FuncKind = (byte) 0;
    this.PlayID = 0L;
    this.PlayerPicID = (ushort) 0;
    this.VIPRank = (byte) 0;
    this.TitleID = (byte) 0;
    this.WTitleID = (ushort) 0;
    this.NTitleID = (ushort) 0;
    this.bCheckDirtyWord = (byte) 0;
    this.SpecialBlockID = (byte) 0;
    this.TitleName.Length = 0;
    this.PlayerName.Length = 0;
    this.ShowName.Length = 0;
    this.MainText.Length = 0;
    this.OriginalText.Length = 0;
    this.TalkTime = 0L;
    this.TalkID = 0L;
    this.TotalHeight = 0.0f;
    this.bHaveArabic = (byte) 0;
    this.TitleLine = (byte) 0;
    this.bHasLoc = false;
    this.bHasLocT = false;
    this.BeginIndex = -1;
    this.EndIndex = -1;
    this.BeginIndexT = -1;
    this.EndIndexT = -1;
    this.King = -1;
    this.LocX = -1;
    this.LocY = -1;
    this.NPCID = 0L;
    this.AllyRank = (byte) 0;
    this.NickNameText.Length = 0;
    this.KingdomID = (ushort) 0;
    this.TranslateShow = (byte) 0;
    this.TranslateLanguage = (ushort) 0;
    this.TranslateState = eTranslateState.Untranslated;
    this.TranslateText.Length = 0;
    this.TotalHeightT = 0.0f;
    this.EmojiKey = (ushort) 0;
  }

  public void TranslateComplete(ushort Language)
  {
    this.TranslateShow = (byte) 1;
    this.TranslateLanguage = Language;
    this.TotalHeightT = 0.0f;
    this.TranslateState = eTranslateState.completed;
  }
}
