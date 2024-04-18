// Decompiled with JetBrains decompiler
// Type: StringManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
public class StringManager
{
  public const int MAX_SSTRING = 50;
  private List<CString> StaticString = new List<CString>();
  private int StaticNowCount = -1;
  private int ListCount = 10;
  private int[] LengthArray = new int[10]
  {
    10,
    50,
    70,
    100,
    150,
    300,
    500,
    800,
    1200,
    3500
  };
  private int[] CountArray = new int[10]
  {
    150,
    100,
    50,
    30,
    20,
    10,
    10,
    5,
    3,
    3
  };
  private List<CString> StringPool10 = new List<CString>();
  private List<CString> StringPool30 = new List<CString>();
  private List<CString> StringPool70 = new List<CString>();
  private List<CString> StringPool100 = new List<CString>();
  private List<CString> StringPool150 = new List<CString>();
  private List<CString> StringPool300 = new List<CString>();
  private List<CString> StringPool500 = new List<CString>();
  private List<CString> StringPool800 = new List<CString>();
  private List<CString> StringPool1200 = new List<CString>();
  private List<CString> StringPool3500 = new List<CString>();
  public int FormatStringCount;
  public CString[] FormatS = new CString[50];
  public static string InputTemp = "1";
  private static StringManager instance;

  private StringManager()
  {
    for (int index = 0; index < 50; ++index)
      this.StaticString.Add(new CString(1024));
    for (int Index = 0; Index < this.ListCount; ++Index)
    {
      List<CString> list = this.GetList(Index);
      if (list != null)
      {
        for (int index = 0; index < this.CountArray[Index]; ++index)
        {
          CString cstring = new CString(this.LengthArray[Index]);
          list.Add(cstring);
        }
      }
    }
    for (int index = 0; index < this.FormatS.Length; ++index)
    {
      CString cstring = new CString(1024);
      this.FormatS[index] = cstring;
    }
  }

  public static StringManager Instance
  {
    get
    {
      if (StringManager.instance == null)
        StringManager.instance = new StringManager();
      return StringManager.instance;
    }
  }

  ~StringManager()
  {
  }

  public CString StaticString1024()
  {
    ++this.StaticNowCount;
    if (this.StaticNowCount >= 50)
      this.StaticNowCount = 0;
    this.StaticString[this.StaticNowCount].ClearString();
    return this.StaticString[this.StaticNowCount];
  }

  private List<CString> GetList(int Index)
  {
    switch (Index)
    {
      case 0:
        return this.StringPool10;
      case 1:
        return this.StringPool30;
      case 2:
        return this.StringPool70;
      case 3:
        return this.StringPool100;
      case 4:
        return this.StringPool150;
      case 5:
        return this.StringPool300;
      case 6:
        return this.StringPool500;
      case 7:
        return this.StringPool800;
      case 8:
        return this.StringPool1200;
      case 9:
        return this.StringPool3500;
      default:
        return (List<CString>) null;
    }
  }

  private int CalculateIndex(int StringLength)
  {
    int index1 = -1;
    if (StringLength <= this.LengthArray[0])
      return 0;
    for (int index2 = 1; index2 < this.ListCount; ++index2)
    {
      if (StringLength > this.LengthArray[index2 - 1] && StringLength <= this.LengthArray[index2])
      {
        index1 = index2;
        break;
      }
    }
    return index1;
  }

  private int DeSpawnFindIndex(int StringLength)
  {
    for (int index = 0; index < this.ListCount; ++index)
    {
      if (StringLength == this.LengthArray[index])
        return index;
    }
    return -1;
  }

  public CString SpawnString(int StringLength = 30)
  {
    CString cstring1 = (CString) null;
    int index1 = this.CalculateIndex(StringLength);
    if (index1 == -1)
      return cstring1;
    List<CString> list = this.GetList(index1);
    if (list == null)
      return cstring1;
    if (list.Count <= 0)
    {
      for (int index2 = 0; index2 < this.CountArray[index1]; ++index2)
      {
        CString cstring2 = new CString(this.LengthArray[index1]);
        list.Add(cstring2);
      }
    }
    CString cstring3 = list[list.Count - 1];
    ++cstring3.ReferenceCount;
    cstring3.ClearString();
    list.RemoveAt(list.Count - 1);
    return cstring3;
  }

  public bool DeSpawnString(CString str)
  {
    if (str == null)
      return false;
    if (str.ReferenceCount != (byte) 0)
      ;
    int index = this.DeSpawnFindIndex(str.MaxLength);
    if (index == -1)
      return false;
    List<CString> list = this.GetList(index);
    if (list == null)
      return false;
    --str.ReferenceCount;
    list.Add(str);
    return true;
  }

  private static unsafe void reverse(CString s, int len)
  {
    if (s == null)
      return;
    int index1 = 0;
    int index2 = len - 1;
    while (index1 < index2)
    {
      string str = s.ToString();
      char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
      char ch = chPtr[index1];
      chPtr[index1] = chPtr[index2];
      chPtr[index2] = ch;
      ++index1;
      --index2;
      str = (string) null;
    }
  }

  public static unsafe int IntToStr(CString s, long x, int digits = 1, bool bNumber = false)
  {
    if (s == null)
      return -1;
    int len = 0;
    int num1 = 0;
    int num2 = x >= 0L ? 1 : -1;
    if (num2 < 0)
      x *= -1L;
    string str = s.ToString();
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    while (x != 0L)
    {
      if (bNumber && num1 == 3)
      {
        chPtr[len++] = ',';
        num1 = 0;
      }
      chPtr[len++] = GameConstants.numChar[x % 10L];
      x = (long) ((double) x * 0.1);
      if (bNumber)
        ++num1;
    }
    while (len < digits)
      chPtr[len++] = GameConstants.numChar[0];
    if (num2 < 0)
      chPtr[len++] = '-';
    StringManager.reverse(s, len);
    chPtr[len] = char.MinValue;
    s.Length = len;
    str = (string) null;
    return len;
  }

  public static unsafe int ulongToStr(CString s, ulong x, int digits = 1, bool bNumber = false)
  {
    if (s == null)
      return -1;
    int len = 0;
    int num = 0;
    string str = s.ToString();
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    while (x != 0UL)
    {
      if (bNumber && num == 3)
      {
        chPtr[len++] = ',';
        num = 0;
      }
      chPtr[len++] = GameConstants.numChar[x % 10UL];
      x = (ulong) ((double) x * 0.1);
      if (bNumber)
        ++num;
    }
    while (len < digits)
      chPtr[len++] = GameConstants.numChar[0];
    StringManager.reverse(s, len);
    chPtr[len] = char.MinValue;
    s.Length = len;
    str = (string) null;
    return len;
  }

  public static unsafe void FloatToStr(
    CString s,
    float f,
    int afterpoint = -1,
    bool bAfterPointShowZero = true)
  {
    int num1 = 1;
    int num2 = -1;
    int num3 = (double) f >= 0.0 ? 1 : -1;
    if (num3 < 0)
      f *= -1f;
    long num4;
    if (afterpoint < 0)
    {
      num4 = (long) f;
      float num5 = f - (float) num4;
      afterpoint = 0;
      while ((double) num5 != 0.0 && (double) num5 >= 0.0)
      {
        float num6 = f * (float) Math.Pow(10.0, (double) (afterpoint + 1));
        num4 = (long) num6;
        num5 = num6 - (float) num4;
        ++afterpoint;
      }
    }
    else
    {
      Decimal num7 = (Decimal) f;
      for (int index = 0; index < afterpoint; ++index)
        num7 *= 10M;
      num4 = (long) num7;
    }
    while ((double) (f *= 0.1f) >= 1.0)
      ++num1;
    if (!bAfterPointShowZero && afterpoint > 0)
    {
      long num8 = num4;
      int y = 0;
      for (int index = 0; index < afterpoint && num8 % 10L == 0L; ++index)
      {
        ++y;
        num8 /= 10L;
      }
      if (y > 0)
      {
        num4 /= (long) (int) Math.Pow(10.0, (double) y);
        afterpoint -= y;
      }
    }
    if (afterpoint > 0)
    {
      num2 = num1;
      num1 = num1 + 1 + afterpoint;
    }
    if (num3 < 0)
    {
      ++num1;
      if (num2 != -1)
        ++num2;
    }
    string str = s.ToString();
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    for (int index1 = num1; index1 >= 0; --index1)
    {
      if (index1 == num1)
        chPtr[index1] = char.MinValue;
      else if (index1 == num2)
        chPtr[index1] = '.';
      else if (num3 < 0 && index1 == 0)
      {
        chPtr[index1] = '-';
      }
      else
      {
        long index2 = num4 % 10L;
        if (index2 < 0L)
          index2 *= -1L;
        chPtr[index1] = GameConstants.numChar[index2];
        num4 = (long) (int) ((double) num4 * 0.10000000149011612);
      }
    }
    s.Length = num1;
    str = (string) null;
  }

  public static unsafe void DoubleToStr(
    CString s,
    double f,
    int afterpoint = -1,
    bool bAfterPointShowZero = true)
  {
    int num1 = 1;
    int num2 = -1;
    int num3 = f >= 0.0 ? 1 : -1;
    if (num3 < 0)
      f *= -1.0;
    long num4;
    if (afterpoint < 0)
    {
      num4 = (long) f;
      double num5 = f - (double) num4;
      afterpoint = 0;
      while (num5 != 0.0 && num5 >= 0.0)
      {
        double num6 = f * Math.Pow(10.0, (double) (afterpoint + 1));
        num4 = (long) num6;
        num5 = num6 - (double) num4;
        ++afterpoint;
      }
    }
    else
    {
      Decimal num7 = (Decimal) f;
      for (int index = 0; index < afterpoint; ++index)
        num7 *= 10M;
      num4 = (long) num7;
    }
    while ((f *= 0.10000000149011612) >= 1.0)
      ++num1;
    if (!bAfterPointShowZero && afterpoint > 0)
    {
      long num8 = num4;
      int y = 0;
      for (int index = 0; index < afterpoint && num8 % 10L == 0L; ++index)
      {
        ++y;
        num8 /= 10L;
      }
      if (y > 0)
      {
        num4 /= (long) (int) Math.Pow(10.0, (double) y);
        afterpoint -= y;
      }
    }
    if (afterpoint > 0)
    {
      num2 = num1;
      num1 = num1 + 1 + afterpoint;
    }
    if (num3 < 0)
    {
      ++num1;
      if (num2 != -1)
        ++num2;
    }
    string str = s.ToString();
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    for (int index1 = num1; index1 >= 0; --index1)
    {
      if (index1 == num1)
        chPtr[index1] = char.MinValue;
      else if (index1 == num2)
        chPtr[index1] = '.';
      else if (num3 < 0 && index1 == 0)
      {
        chPtr[index1] = '-';
      }
      else
      {
        long index2 = num4 % 10L;
        if (index2 < 0L)
          index2 *= -1L;
        chPtr[index1] = GameConstants.numChar[index2];
        num4 = (long) (int) ((double) num4 * 0.10000000149011612);
      }
    }
    s.Length = num1;
    str = (string) null;
  }

  public bool IntToFormat(long x, int digits = 1, bool bNumber = false)
  {
    if (this.FormatStringCount >= this.FormatS.Length)
      return false;
    StringManager.IntToStr(this.FormatS[this.FormatStringCount], x, digits, bNumber);
    ++this.FormatStringCount;
    return true;
  }

  public bool uLongToFormat(ulong x, int digits = 1, bool bNumber = false)
  {
    if (this.FormatStringCount >= this.FormatS.Length)
      return false;
    StringManager.ulongToStr(this.FormatS[this.FormatStringCount], x, digits, bNumber);
    ++this.FormatStringCount;
    return true;
  }

  public bool FloatToFormat(float f, int afterpoint = -1, bool bAfterPointShowZero = true)
  {
    if (this.FormatStringCount >= this.FormatS.Length)
      return false;
    StringManager.FloatToStr(this.FormatS[this.FormatStringCount], f, afterpoint, bAfterPointShowZero);
    ++this.FormatStringCount;
    return true;
  }

  public bool DoubleToFormat(double f, int afterpoint = -1, bool bAfterPointShowZero = true)
  {
    if (this.FormatStringCount >= this.FormatS.Length)
      return false;
    StringManager.DoubleToStr(this.FormatS[this.FormatStringCount], f, afterpoint, bAfterPointShowZero);
    ++this.FormatStringCount;
    return true;
  }

  public bool StringToFormat(CString tmpS)
  {
    if (this.FormatStringCount >= this.FormatS.Length)
      return false;
    this.FormatS[this.FormatStringCount].ClearString();
    this.FormatS[this.FormatStringCount].Append(tmpS);
    ++this.FormatStringCount;
    return true;
  }

  public bool StringToFormat(string tmpS)
  {
    if (this.FormatStringCount >= this.FormatS.Length)
      return false;
    this.FormatS[this.FormatStringCount].ClearString();
    this.FormatS[this.FormatStringCount].Append(tmpS);
    ++this.FormatStringCount;
    return true;
  }
}
