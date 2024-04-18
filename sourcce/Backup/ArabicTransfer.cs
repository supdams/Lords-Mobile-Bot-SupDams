// Decompiled with JetBrains decompiler
// Type: ArabicTransfer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using StringExtensions;
using System.Globalization;
using System.Text;

#nullable disable
public class ArabicTransfer
{
  private const byte ArabicRichMax = 10;
  private CString TempStr;
  private CString CharStr;
  private CString ArabicStr;
  private CString[] ArabicRichTextBuffer = new CString[10];
  private int ArabicRichEnd;
  public eTextCheck TextState;
  private readonly char[][] ReplaceStr = new char[2][]
  {
    new char[6]{ '(', ')', '{', '}', '[', ']' },
    new char[6]{ ')', '(', '}', '{', ']', '[' }
  };
  private static ArabicTransfer _instance;

  private ArabicTransfer()
  {
    for (int index = 0; index < this.ArabicRichTextBuffer.Length; ++index)
      this.ArabicRichTextBuffer[index] = new CString(17);
    this.TempStr = new CString(1024);
    this.CharStr = new CString(1024);
    this.ArabicStr = new CString(1024);
  }

  public static ArabicTransfer Instance
  {
    get
    {
      if (ArabicTransfer._instance == null)
        ArabicTransfer._instance = new ArabicTransfer();
      return ArabicTransfer._instance;
    }
  }

  public string Transfer(string str, CString tmpStr)
  {
    this.TempStr.ClearString();
    this.CharStr.ClearString();
    tmpStr.ClearString();
    this.ArabicRichEnd = 0;
    byte num1 = 0;
    byte num2 = 0;
    this.TextState = eTextCheck.Text_None;
    string empty = string.Empty;
    this.ArabicStr.ClearString();
    CString cstring = tmpStr;
    int strLen = str.GetStrLen();
    for (int index1 = 0; index1 < strLen; ++index1)
    {
      char ch = str[index1];
      if (ch != char.MinValue)
      {
        byte num3 = 0;
        if (this.IsArabic(ch))
        {
          this.ArabicStr.Append(ch);
          if (this.CheckYenRule(str, index1))
            num1 = (byte) 1;
        }
        else
        {
          if (this.ArabicStr.Length > 0)
          {
            this.TempStr.ClearString();
            this.TempStr.Append(ArabicFixerTool.Instance.FixLine(this.ArabicStr.ToString()));
            cstring.Insert(0, this.TempStr, this.TempStr.Length);
            this.ArabicStr.ClearString();
          }
          for (int index2 = 0; index2 < this.ReplaceStr[0].Length; ++index2)
          {
            if ((int) this.ReplaceStr[0][index2] == (int) ch)
            {
              ch = this.ReplaceStr[1][index2];
              this.TempStr.ClearString();
              this.TempStr.Append(ch);
              cstring.Insert(0, this.TempStr, this.TempStr.Length);
              num3 = (byte) 1;
              break;
            }
          }
          if (num3 != (byte) 1)
          {
            if (ch >= '٠' && ch <= '٩' || ch >= '۰' && ch <= 'ۺ')
              cstring.Insert(0, this.PraseArabicNumber(str, ref index1), this.TempStr.Length);
            else if (ch == '<')
              cstring.Insert(0, this.PraseRichText(str, ref index1), this.TempStr.Length);
            else if (ch >= '0' && ch <= '9' || ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
              cstring.Insert(0, this.PraseNumber(str, ref index1), this.TempStr.Length);
            else if (char.GetUnicodeCategory(ch) == UnicodeCategory.Surrogate)
            {
              num2 = (byte) 1;
              cstring.Insert(0, this.Praseemotion(str, ref index1), this.TempStr.Length);
            }
            else
            {
              this.TempStr.ClearString();
              this.TempStr.Append(ch);
              cstring.Insert(0, this.TempStr, this.TempStr.Length);
            }
          }
        }
      }
      else
        break;
    }
    if (num2 == (byte) 1)
      this.TextState |= eTextCheck.Text_Emoticon;
    else
      this.TextState |= eTextCheck.Text_NonEmoticon;
    if (num1 == (byte) 0)
    {
      this.TextState |= eTextCheck.Text_NonArabic;
      if (num2 != (byte) 1)
        return str;
      cstring.ClearString();
      cstring.Append(str);
      return cstring.ToString();
    }
    this.TextState |= eTextCheck.Text_Arabic;
    if (this.ArabicStr.Length > 0)
    {
      this.TempStr.ClearString();
      this.TempStr.Append(ArabicFixerTool.Instance.FixLine(this.ArabicStr.ToString()));
      cstring.Insert(0, this.TempStr, this.TempStr.Length);
    }
    return cstring.ToString();
  }

  public bool IsArabic(char character)
  {
    return (character < '٠' || character > '٩') && (character < '۰' || character > 'ۺ') && (character >= '\u0600' && character <= 'ۿ' || character >= 'ݐ' && character <= 'ݿ' || character >= 'ﭐ' && character <= 'ﰿ' || character >= 'ﹰ' && character <= 'ﻼ');
  }

  public bool CheckYenRule(string str, int index)
  {
    return index > 0 && this.IsArabic(str[index - 1]) || index < str.Length - 1 && this.IsArabic(str[index + 1]);
  }

  public bool IsYenText(char character, char prechar) => character == 'و' && prechar == ')';

  public bool IsArabicStr(string str)
  {
    if (str == null)
      return false;
    for (int index = 0; index < str.Length && str[index] != char.MinValue; ++index)
    {
      if (this.IsArabic(str[index]))
        return true;
    }
    return false;
  }

  private string PraseArabicNumber(string str, ref int index)
  {
    this.TempStr.ClearString();
    while (index < str.Length && str[index] != char.MinValue && (str[index] >= '٠' && str[index] <= '٩' || str[index] >= '۰' && str[index] <= 'ۺ'))
    {
      this.TempStr.Append(str[index]);
      ++index;
    }
    if (this.TempStr.Length > 0)
      --index;
    return this.TempStr.ToString();
  }

  private string PraseNumber(string str, ref int index)
  {
    this.TempStr.ClearString();
    int strLen = str.GetStrLen();
    while (index < strLen && (str[index] >= '0' && str[index] <= '9' || str[index] == ',' || str[index] == '.' || str[index] == ':' || str[index] >= 'a' && str[index] <= 'z' || str[index] >= 'A' && str[index] <= 'Z'))
    {
      this.TempStr.Append(str[index]);
      ++index;
    }
    if (this.TempStr.Length > 0)
      --index;
    return this.TempStr.ToString();
  }

  private string PraseRichText(string str, ref int index)
  {
    this.TempStr.ClearString();
    if (index >= str.Length - 1)
      return string.Empty;
    switch (str[index + 1])
    {
      case '/':
        while (index < str.Length && str[index] != char.MinValue && str[index] != '>')
          ++index;
        int index1 = 0;
        if (this.ArabicRichEnd > 0)
          index1 = --this.ArabicRichEnd % 10;
        this.TempStr.Append(this.ArabicRichTextBuffer[index1]);
        break;
      case 'c':
        while (index < str.Length)
        {
          this.TempStr.Append(str[index]);
          if (str[index] != char.MinValue && str[index] != '>')
            ++index;
          else
            break;
        }
        int index2 = this.ArabicRichEnd++ % 10;
        this.ArabicRichTextBuffer[index2].ClearString();
        this.ArabicRichTextBuffer[index2].Append(this.TempStr);
        this.TempStr.ClearString();
        this.TempStr.Append("</color>");
        break;
    }
    return this.TempStr.ToString();
  }

  public CString ReserveString(CString str)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.Append(str);
    str.ClearString();
    for (int index = cstring.Length - 1; index >= 0; --index)
      str.Append(cstring[index]);
    return str;
  }

  private string GetKeyString(string str, int index, char keyEnd, byte bReserve = 0)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    CString textS = StringManager.Instance.StaticString1024();
    for (; index < str.Length && (int) str[index] != (int) keyEnd; ++index)
    {
      if (bReserve == (byte) 0)
      {
        cstring.Append(str[index]);
      }
      else
      {
        textS.ClearString();
        textS.Append(str[index]);
        cstring.Insert(0, textS, 1);
      }
    }
    return cstring.ToString();
  }

  private int FindStringPosition(string str, int index, string findStr)
  {
    int strLen = findStr.GetStrLen();
    if (index == 0 || index < strLen)
      return -1;
    for (; index >= 0; --index)
    {
      bool flag = true;
      if (index < strLen)
        return -1;
      for (int index1 = 0; index1 < strLen; ++index1)
      {
        if ((int) findStr[index1] != (int) str[index - strLen + index1])
        {
          flag = false;
          break;
        }
      }
      if (flag)
        return index - strLen;
    }
    return -1;
  }

  private string PraseCustomParmeter(string str, ref int index)
  {
    this.TempStr.ClearString();
    while (index < str.Length)
    {
      char ch = str[index];
      if (ch == '%' || ch >= 'a' && ch <= 'z')
      {
        this.TempStr.Append(ch);
        ++index;
      }
      else
        break;
    }
    if (this.TempStr.Length > 0)
      --index;
    return this.TempStr.ToString();
  }

  private string Praseemotion(string str, ref int index)
  {
    this.TempStr.ClearString();
    this.TempStr.Append(str[index]);
    ++index;
    while (index < str.Length)
    {
      char c = str[index];
      if (char.GetUnicodeCategory(c) == UnicodeCategory.Surrogate)
      {
        this.TempStr.Append(c);
        ++index;
      }
      else
        break;
    }
    return this.TempStr.ToString();
  }

  private int FindFirstChar(string str, ref int index, char ch)
  {
    int firstChar = -1;
    for (int index1 = index; index1 < str.Length && str[index1] != char.MinValue; ++index1)
    {
      if ((int) str[index1] == (int) ch)
        firstChar = index1;
    }
    return firstChar;
  }

  public string ReverseExceptNums(string _outTextField)
  {
    StringBuilder stringBuilder = new StringBuilder();
    int length1 = 0;
    int length2 = _outTextField.Length;
    while (length2 > 0)
    {
      --length2;
      if (!char.IsDigit(_outTextField[length2]))
      {
        if (length1 > 0)
          stringBuilder.Append(_outTextField.Substring(length2 + 1, length1));
        length1 = 0;
        stringBuilder.Append(_outTextField[length2]);
      }
      else
        ++length1;
    }
    if (length1 > 0)
      stringBuilder.Append(_outTextField.Substring(0, length1));
    return stringBuilder.ToString();
  }
}
