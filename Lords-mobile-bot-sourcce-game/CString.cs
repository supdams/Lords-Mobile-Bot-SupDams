// Decompiled with JetBrains decompiler
// Type: CString
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
public class CString
{
  private int m_Length;
  private int m_MaxLength;
  private string MyString;
  public byte ReferenceCount;

  public CString(int Capacity)
  {
    this.m_MaxLength = Capacity;
    this.MyString = new string(char.MinValue, this.m_MaxLength);
  }

  public int Length
  {
    get => this.m_Length;
    set
    {
      if (value > 0 && value <= this.m_MaxLength)
        this.m_Length = value;
      else
        this.ClearString();
    }
  }

  public int MaxLength => this.m_MaxLength;

  public char this[int index]
  {
    get => index < this.MaxLength ? this.MyString[index] : throw new IndexOutOfRangeException();
  }

  ~CString() => this.MyString = (string) null;

  public override string ToString() => this.MyString;

  public unsafe void SetLength(int length)
  {
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    int* numPtr = (int*) chPtr;
    if (length < 0 || length > this.m_MaxLength)
      return;
    numPtr[-1] = length;
    str = (string) null;
  }

  public unsafe void ClearString()
  {
    if (this.MyString == null)
      return;
    this.m_Length = 0;
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    *chPtr = char.MinValue;
    str = (string) null;
  }

  public unsafe void SetChar(int index, char ch)
  {
    if (this.MyString == null || index < 0 || index >= this.m_MaxLength)
      return;
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    if (index < this.m_Length)
      chPtr[index] = ch;
    str = (string) null;
  }

  private unsafe void InternalInsert(int StartIndex, string textS, int SLength)
  {
    if (textS == null || this.MyString == null || StartIndex < 0 || StartIndex >= this.m_MaxLength || StartIndex + SLength > this.m_MaxLength || this.m_Length + SLength > this.m_MaxLength)
      return;
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    for (int index = this.m_Length - 1; index >= StartIndex; --index)
      chPtr[index + SLength] = this.MyString[index];
    for (int index = 0; index < SLength; ++index)
      chPtr[StartIndex + index] = textS[index];
    this.m_Length += SLength;
    chPtr[this.m_Length] = char.MinValue;
    str = (string) null;
  }

  public void Insert(int StartIndex, string textS, int SLength = -1)
  {
    if (textS == null)
      return;
    this.InternalInsert(StartIndex, textS, SLength != -1 ? SLength : textS.Length);
  }

  public void Insert(int StartIndex, CString textS, int SLength = -1)
  {
    if (textS == null)
      return;
    this.InternalInsert(StartIndex, textS.ToString(), SLength != -1 ? SLength : textS.Length);
  }

  private unsafe void InternalAppend(string value, int Lengthv)
  {
    if (this.MyString == null || value == null || Lengthv == 0)
      return;
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    int index;
    for (index = 0; index < Lengthv && index + this.m_Length < this.m_MaxLength; ++index)
    {
      chPtr[index + this.m_Length] = value[index];
      if (value[index] == char.MinValue)
        break;
    }
    this.m_Length = index + this.m_Length;
    if (this.m_Length < this.m_MaxLength)
      chPtr[this.m_Length] = char.MinValue;
    str = (string) null;
  }

  public void Append(string value)
  {
    if (value == null)
      return;
    this.InternalAppend(value, value.Length);
  }

  public void Append(CString value)
  {
    if (value == null)
      return;
    this.InternalAppend(value.ToString(), value.Length);
  }

  public unsafe void Append(char value)
  {
    if (this.MyString == null || this.m_Length >= this.m_MaxLength)
      return;
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    chPtr[this.m_Length++] = value;
    if (this.m_Length < this.m_MaxLength)
      chPtr[this.m_Length] = char.MinValue;
    str = (string) null;
  }

  public unsafe void Append(char value, int repeatCount)
  {
    if (this.MyString == null || repeatCount <= 0)
      return;
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    while (repeatCount > 0)
    {
      if (this.m_Length < this.m_MaxLength)
      {
        chPtr[this.m_Length++] = value;
        --repeatCount;
      }
      else
        repeatCount = 0;
    }
    if (this.m_Length < this.m_MaxLength)
      chPtr[this.m_Length] = char.MinValue;
    str = (string) null;
  }

  private void InternalAppendFormat(string format, int lengthf)
  {
    if (this.MyString == null || format == null)
      return;
    StringManager instance = StringManager.Instance;
    int index1 = 0;
    while (true)
    {
      bool flag;
      int repeatCount;
      do
      {
        if (index1 < lengthf)
        {
          char ch = format[index1];
          ++index1;
          if (ch == '}')
          {
            if (index1 >= lengthf || format[index1] != '}')
              return;
            ++index1;
          }
          if (ch == '{')
          {
            if (index1 >= lengthf || format[index1] != '{')
            {
              --index1;
              goto label_13;
            }
            else
              ++index1;
          }
          this.Append(ch);
          continue;
        }
label_13:
        if (index1 == lengthf)
          return;
        int index2 = index1 + 1;
        char ch1;
        if (index2 == lengthf || (ch1 = format[index2]) < '0' || ch1 > '9')
          return;
        int index3 = 0;
        do
        {
          index3 = index3 * 10 + (int) ch1 - 48;
          ++index2;
          if (index2 == lengthf)
            return;
          ch1 = format[index2];
          switch (ch1)
          {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
              continue;
            default:
              goto label_22;
          }
        }
        while (index3 < 1000000);
label_22:
        CString[] formatS = instance.FormatS;
        if (index3 < formatS.Length)
        {
          while (index2 < lengthf && (ch1 = format[index2]) == ' ')
            ++index2;
          flag = false;
          int num = 0;
          if (ch1 == ',')
          {
            ++index2;
            while (index2 < lengthf && format[index2] == ' ')
              ++index2;
            if (index2 == lengthf)
              return;
            ch1 = format[index2];
            if (ch1 == '-')
            {
              flag = true;
              ++index2;
              if (index2 == lengthf)
                return;
              ch1 = format[index2];
            }
            if (ch1 < '0' || ch1 > '9')
              return;
            do
            {
              num = num * 10 + (int) ch1 - 48;
              ++index2;
              if (index2 == lengthf)
                return;
              ch1 = format[index2];
            }
            while (ch1 >= '0' && ch1 <= '9' && num < 1000000);
          }
          while (index2 < lengthf && (ch1 = format[index2]) == ' ')
            ++index2;
          CString cstring1 = instance.StaticString1024();
          if (ch1 == ':')
          {
            int index4 = index2 + 1;
            while (index4 != lengthf)
            {
              ch1 = format[index4];
              ++index4;
              switch (ch1)
              {
                case '{':
                  if (index4 >= lengthf || format[index4] != '{')
                    return;
                  ++index4;
                  break;
                case '}':
                  if (index4 < lengthf && format[index4] == '}')
                  {
                    ++index4;
                    break;
                  }
                  index2 = index4 - 1;
                  goto label_54;
              }
              cstring1.Append(ch1);
            }
            return;
          }
label_54:
          if (ch1 != '}')
            return;
          index1 = index2 + 1;
          CString cstring2 = (CString) null;
          if (formatS[index3] != null)
            cstring2 = formatS[index3];
          if (cstring2 == null)
            cstring2 = instance.StaticString1024();
          repeatCount = num - cstring2.Length;
          if (!flag && repeatCount > 0)
            this.Append(' ', repeatCount);
          this.Append(cstring2);
        }
        else
          goto label_55;
      }
      while (!flag || repeatCount <= 0);
      this.Append(' ', repeatCount);
    }
label_55:;
  }

  public void AppendFormat(string format)
  {
    StringManager.Instance.FormatStringCount = 0;
    if (format == null)
      return;
    this.InternalAppendFormat(format, format.Length);
  }

  public void AppendFormat(CString format)
  {
    StringManager.Instance.FormatStringCount = 0;
    if (format == null)
      return;
    this.InternalAppendFormat(format.ToString(), format.Length);
  }

  public bool IntToFormat(long x, int digits = 1, bool bNumber = false)
  {
    return StringManager.Instance.IntToFormat(x, digits, bNumber);
  }

  public bool uLongToFormat(ulong x, int digits = 1, bool bNumber = false)
  {
    return StringManager.Instance.uLongToFormat(x, digits, bNumber);
  }

  public bool FloatToFormat(float f, int afterpoint = -1, bool bAfterPointShowZero = true)
  {
    return StringManager.Instance.FloatToFormat(f, afterpoint, bAfterPointShowZero);
  }

  public bool DoubleToFormat(double f, int afterpoint = -1, bool bAfterPointShowZero = true)
  {
    return StringManager.Instance.DoubleToFormat(f, afterpoint, bAfterPointShowZero);
  }

  public bool StringToFormat(CString tmpS) => StringManager.Instance.StringToFormat(tmpS);

  public bool StringToFormat(string tmpS) => StringManager.Instance.StringToFormat(tmpS);

  public unsafe void ToUpper()
  {
    string str = this.MyString.ToString();
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    for (int index = 0; index < this.m_Length; ++index)
      chPtr[index] = 'a' > this.MyString[index] || this.MyString[index] > 'z' ? this.MyString[index] : (char) ((uint) this.MyString[index] & 4294967263U);
    str = (string) null;
  }

  public unsafe int GetHashCode(bool bToUpper = false)
  {
    int hashCode;
    if (bToUpper)
    {
      CString cstring = StringManager.Instance.StaticString1024();
      string str = cstring.ToString();
      char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
      int index;
      for (index = 0; index < this.m_Length && index < cstring.MaxLength; ++index)
        chPtr[index] = 'a' > this.MyString[index] || this.MyString[index] > 'z' ? this.MyString[index] : (char) ((uint) this.MyString[index] & 4294967263U);
      chPtr[index] = char.MinValue;
      cstring.SetLength(index);
      hashCode = cstring.ToString().GetHashCode();
      cstring.SetLength(cstring.MaxLength);
      str = (string) null;
    }
    else
    {
      string str = this.MyString;
      char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
      this.SetLength(this.m_Length);
      hashCode = this.MyString.GetHashCode();
      this.SetLength(this.m_MaxLength);
      str = (string) null;
    }
    return hashCode;
  }

  public void Substring(CString s, int startIndex)
  {
    if (s == null || startIndex <= 0 || startIndex >= s.Length)
      return;
    this.Substring(s.ToString(), startIndex, s.Length - startIndex);
  }

  public void Substring(string s, int startIndex)
  {
    if (s == null || startIndex <= 0 || startIndex >= s.Length)
      return;
    this.Substring(s, startIndex, s.Length - startIndex);
  }

  public void Substring(string s, int startIndex, int length)
  {
    if (length == 0)
      return;
    this.InternalSubString(s, startIndex, length);
  }

  private unsafe void InternalSubString(string s, int startIndex, int length)
  {
    if (this.MyString == null || s == null)
      return;
    string str = this.MyString;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    int index;
    for (index = 0; index < length && index < this.m_MaxLength && index + startIndex < s.Length; ++index)
    {
      chPtr[index] = s[index + startIndex];
      if (s[index + startIndex] == char.MinValue)
        break;
    }
    this.m_Length = index;
    if (this.m_Length < this.m_MaxLength)
      chPtr[this.m_Length] = char.MinValue;
    str = (string) null;
  }

  public void CheckBannedWord()
  {
    if (DataManager.Instance.m_BannedWord == null)
      return;
    this.SetLength(this.Length);
    DataManager.Instance.m_BannedWord.CheckBannedWord(this.MyString);
    this.SetLength(this.MaxLength);
  }

  public bool ChackHasBannedWord()
  {
    if (DataManager.Instance.m_BannedWord == null)
      return false;
    this.SetLength(this.Length);
    bool flag = DataManager.Instance.m_BannedWord.ChackHasBannedWord(this.MyString);
    this.SetLength(this.MaxLength);
    return flag;
  }
}
