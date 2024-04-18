// Decompiled with JetBrains decompiler
// Type: ArabicFixerTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using StringExtensions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
public class ArabicFixerTool
{
  public static bool showTashkeel = true;
  private List<TashkeelLocation> tashkeelLocation = new List<TashkeelLocation>();
  private CString ctext1 = new CString(512);
  private CString ctext2 = new CString(512);
  private CString tashkeelStr = new CString(512);
  private char SkipChar = Convert.ToChar(21);
  private static ArabicFixerTool _instance;

  public static ArabicFixerTool Instance
  {
    get
    {
      if (ArabicFixerTool._instance == null)
        ArabicFixerTool._instance = new ArabicFixerTool();
      return ArabicFixerTool._instance;
    }
  }

  private string RemoveTashkeel(string str, ref List<TashkeelLocation> tashkeelLocation)
  {
    tashkeelLocation.Clear();
    int strLen = str.GetStrLen();
    this.tashkeelStr.ClearString();
    for (int index = 0; index < strLen; ++index)
    {
      if (str[index] == 'ً')
        tashkeelLocation.Add(new TashkeelLocation('ً', index));
      else if (str[index] == 'ٌ')
        tashkeelLocation.Add(new TashkeelLocation('ٌ', index));
      else if (str[index] == 'ٍ')
        tashkeelLocation.Add(new TashkeelLocation('ٍ', index));
      else if (str[index] == 'َ')
        tashkeelLocation.Add(new TashkeelLocation('َ', index));
      else if (str[index] == 'ُ')
        tashkeelLocation.Add(new TashkeelLocation('ُ', index));
      else if (str[index] == 'ِ')
        tashkeelLocation.Add(new TashkeelLocation('ِ', index));
      else if (str[index] == 'ّ')
        tashkeelLocation.Add(new TashkeelLocation('ّ', index));
      else if (str[index] == 'ْ')
        tashkeelLocation.Add(new TashkeelLocation('ْ', index));
      else if (str[index] == 'ٓ')
        tashkeelLocation.Add(new TashkeelLocation('ٓ', index));
      else
        this.tashkeelStr.Append(str[index]);
    }
    return this.tashkeelStr.ToString();
  }

  private unsafe void ReturnTashkeel(CString letters, List<TashkeelLocation> tashkeelLocation)
  {
    int index1 = 0;
    int length = letters.Length;
    string str = letters.ToString();
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    for (int index2 = 0; index2 < length; ++index2)
    {
      ++index1;
      for (int index3 = 0; index3 < tashkeelLocation.Count; ++index3)
      {
        if (tashkeelLocation[index3].position == index1)
        {
          chPtr[index1] = tashkeelLocation[index3].tashkeel;
          ++index1;
        }
      }
    }
    str = (string) null;
  }

  public unsafe string FixLine(string str, bool showTashkeel = false)
  {
    ArabicFixerTool.showTashkeel = showTashkeel;
    string str1 = this.RemoveTashkeel(str, ref this.tashkeelLocation);
    this.ctext1.ClearString();
    this.ctext2.ClearString();
    this.ctext1.Append(str1);
    this.ctext2.Append(str1);
    if (this.ctext1.Length == 0)
      return string.Empty;
    string str2 = this.ctext1.ToString();
    char* chPtr1 = (char*) ((IntPtr) str2 + RuntimeHelpers.OffsetToStringData);
    string str3 = this.ctext2.ToString();
    char* chPtr2 = (char*) ((IntPtr) str3 + RuntimeHelpers.OffsetToStringData);
    for (int index = 0; index < this.ctext1.Length; ++index)
    {
      bool flag = false;
      if (index == 0)
        chPtr1[index] = (char) ArabicTable.ArabicMapper.Convert((int) chPtr1[index]);
      if (this.ctext1.Length - 1 > index)
        chPtr1[index + 1] = (char) ArabicTable.ArabicMapper.Convert((int) chPtr1[index + 1]);
      if (chPtr1[index] == 'ﻝ' && this.ctext1.Length - 1 > index)
      {
        if (chPtr1[index + 1] == 'ﺇ')
        {
          chPtr1[index] = 'ﻷ';
          chPtr2[index + 1] = this.SkipChar;
          flag = true;
        }
        else if (chPtr1[index + 1] == 'ﺍ')
        {
          chPtr1[index] = 'ﻹ';
          chPtr2[index + 1] = this.SkipChar;
          flag = true;
        }
        else if (chPtr1[index + 1] == 'ﺃ')
        {
          chPtr1[index] = 'ﻵ';
          chPtr2[index + 1] = this.SkipChar;
          flag = true;
        }
        else if (chPtr1[index + 1] == 'ﺁ')
        {
          chPtr1[index] = 'ﻳ';
          chPtr2[index + 1] = this.SkipChar;
          flag = true;
        }
      }
      if (!ArabicFixerTool.IsIgnoredCharacter(chPtr1[index]) && chPtr1[index] != 'A')
      {
        if (ArabicFixerTool.IsMiddleLetter(this.ctext1, index))
          chPtr2[index] = (char) ((uint) chPtr1[index] + 3U);
        else if (ArabicFixerTool.IsFinishingLetter(this.ctext1, index))
          chPtr2[index] = (char) ((uint) chPtr1[index] + 1U);
        else if (ArabicFixerTool.IsLeadingLetter(this.ctext1, index))
          chPtr2[index] = (char) ((uint) chPtr1[index] + 2U);
      }
      if (flag)
      {
        ++index;
        if (this.ctext1.Length - 1 > index)
          chPtr1[index + 1] = (char) ArabicTable.ArabicMapper.Convert((int) chPtr1[index + 1]);
      }
    }
    str3 = (string) null;
    str2 = (string) null;
    if (ArabicFixerTool.showTashkeel)
      this.ReturnTashkeel(this.ctext2, this.tashkeelLocation);
    this.ctext1.ClearString();
    this.ctext1.Append(this.ctext2);
    this.ctext2.ClearString();
    for (int index = this.ctext1.Length - 1; index >= 0; --index)
      this.ctext2.Append(this.ctext1[index]);
    return this.ctext2.ToString();
  }

  private void SwapCH(ref char ch1, ref char ch2)
  {
  }

  internal static bool IsIgnoredCharacter(char ch)
  {
    bool flag1 = char.IsPunctuation(ch);
    bool flag2 = char.IsNumber(ch);
    bool flag3 = char.IsLower(ch);
    bool flag4 = char.IsUpper(ch);
    bool flag5 = char.IsSymbol(ch);
    bool flag6 = ch == 'ﭖ' || ch == 'ﭺ' || ch == 'ﮊ' || ch == 'ﮒ';
    bool flag7 = ch <= '\uFEFF' && ch >= 'ﹰ' || flag6;
    return flag1 || flag2 || flag3 || flag4 || flag5 || !flag7 || ch == 'a' || ch == '>' || ch == '<' || ch == '؛';
  }

  internal static bool IsLeadingLetter(CString letters, int index)
  {
    return (index == 0 || letters[index - 1] == ' ' || letters[index - 1] == '*' || letters[index - 1] == 'A' || char.IsPunctuation(letters[index - 1]) || letters[index - 1] == '>' || letters[index - 1] == '<' || letters[index - 1] == 'ﺍ' || letters[index - 1] == 'ﺩ' || letters[index - 1] == 'ﺫ' || letters[index - 1] == 'ﺭ' || letters[index - 1] == 'ﺯ' || letters[index - 1] == 'ﮊ' || letters[index - 1] == 'ﻯ' || letters[index - 1] == 'ﻭ' || letters[index - 1] == 'ﺁ' || letters[index - 1] == 'ﺃ' || letters[index - 1] == 'ﺇ' || letters[index - 1] == 'ﺅ') && letters[index] != ' ' && letters[index] != 'ﺩ' && letters[index] != 'ﺫ' && letters[index] != 'ﺭ' && letters[index] != 'ﺯ' && letters[index] != 'ﮊ' && letters[index] != 'ﺍ' && letters[index] != 'ﺃ' && letters[index] != 'ﺇ' && letters[index] != 'ﻭ' && letters[index] != 'ﺀ' && index < letters.Length - 1 && letters[index + 1] != ' ' && !char.IsPunctuation(letters[index + 1]) && letters[index + 1] != 'ﺀ';
  }

  internal static bool IsFinishingLetter(CString letters, int index)
  {
    return index != 0 && letters[index - 1] != ' ' && letters[index - 1] != '*' && letters[index - 1] != 'A' && letters[index - 1] != 'ﺩ' && letters[index - 1] != 'ﺫ' && letters[index - 1] != 'ﺭ' && letters[index - 1] != 'ﺯ' && letters[index - 1] != 'ﮊ' && letters[index - 1] != 'ﻯ' && letters[index - 1] != 'ﻭ' && letters[index - 1] != 'ﺍ' && letters[index - 1] != 'ﺁ' && letters[index - 1] != 'ﺃ' && letters[index - 1] != 'ﺇ' && letters[index - 1] != 'ﺅ' && letters[index - 1] != 'ﺀ' && !char.IsPunctuation(letters[index - 1]) && letters[index - 1] != '>' && letters[index - 1] != '<' && letters[index] != ' ' && index < letters.Length && letters[index] != 'ﺀ';
  }

  internal static bool IsMiddleLetter(CString letters, int index)
  {
    if (index != 0 && letters[index] != ' ' && letters[index] != 'ﺍ' && letters[index] != 'ﺩ' && letters[index] != 'ﺫ' && letters[index] != 'ﺭ' && letters[index] != 'ﺯ' && letters[index] != 'ﮊ' && letters[index] != 'ﻯ' && letters[index] != 'ﻭ' && letters[index] != 'ﺁ' && letters[index] != 'ﺃ' && letters[index] != 'ﺇ' && letters[index] != 'ﺅ' && letters[index] != 'ﺀ' && letters[index - 1] != 'ﺍ' && letters[index - 1] != 'ﺩ' && letters[index - 1] != 'ﺫ' && letters[index - 1] != 'ﺭ' && letters[index - 1] != 'ﺯ' && letters[index - 1] != 'ﮊ' && letters[index - 1] != 'ﻯ' && letters[index - 1] != 'ﻭ' && letters[index - 1] != 'ﺁ' && letters[index - 1] != 'ﺃ' && letters[index - 1] != 'ﺇ' && letters[index - 1] != 'ﺅ' && letters[index - 1] != 'ﺀ' && letters[index - 1] != '>' && letters[index - 1] != '<' && letters[index - 1] != ' ' && letters[index - 1] != '*' && !char.IsPunctuation(letters[index - 1]) && index < letters.Length - 1 && letters[index + 1] != ' ' && letters[index + 1] != '\r' && letters[index + 1] != 'A' && letters[index + 1] != '>' && letters[index + 1] != '>')
    {
      if (letters[index + 1] != 'ﺀ')
      {
        try
        {
          return !char.IsPunctuation(letters[index + 1]);
        }
        catch
        {
          return false;
        }
      }
    }
    return false;
  }
}
