// Decompiled with JetBrains decompiler
// Type: MessageBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MessageBoard
{
  public long MessageID;
  public long MessageTime;
  public byte AllianceOrRole;
  public ushort PicID;
  public CString NameStr;
  public CString AllianceNameStr;
  public CString AllianceTagStr;
  public CString ShowName;
  public CString MessageStr;
  public float TotalHeight;
  public byte TranslateShow = 1;
  public ushort TranslateLanguage;
  public eTranslateState TranslateState;
  public CString TranslateText;
  public float TotalHeightT;
  public bool bSelfMessage;
  public byte bHaveArabic;

  public MessageBoard()
  {
    this.NameStr = new CString(13);
    this.AllianceNameStr = new CString(21);
    this.AllianceTagStr = new CString(4);
    this.ShowName = new CString(50);
    this.MessageStr = new CString(431);
    this.TranslateText = new CString(431);
  }

  public void Initial()
  {
    this.MessageID = 0L;
    this.MessageTime = 0L;
    this.AllianceOrRole = (byte) 0;
    this.PicID = (ushort) 0;
    this.NameStr.Length = 0;
    this.MessageStr.Length = 0;
    this.TotalHeight = 0.0f;
    this.TranslateShow = (byte) 0;
    this.TranslateLanguage = (ushort) 0;
    this.TranslateState = eTranslateState.Untranslated;
    this.TranslateText.Length = 0;
    this.TotalHeightT = 0.0f;
    this.bSelfMessage = false;
    this.bHaveArabic = (byte) 0;
  }

  public void TranslateComplete(ushort Language)
  {
    this.TranslateShow = (byte) 1;
    this.TranslateLanguage = Language;
    this.TotalHeightT = 0.0f;
    this.TranslateState = eTranslateState.completed;
  }
}
