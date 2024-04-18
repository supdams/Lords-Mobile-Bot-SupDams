// Decompiled with JetBrains decompiler
// Type: BoyerMooreStringMatcher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
public class BoyerMooreStringMatcher
{
  public string Pattern;
  private Dictionary<char, int> badCharactorShifts = new Dictionary<char, int>();
  private int[] goodSuffixShifts;
  private static int dstringmax = Convert.ToInt32("9fff", 16);
  private static int dstringmin = Convert.ToInt32("4e00", 16);

  public BoyerMooreStringMatcher(string tmpStr)
  {
    if (this.Pattern != null)
      return;
    this.Pattern = tmpStr.ToLower();
    this.BuildBadCharactorHeuristic();
    this.BuildGoodSuffixHeuristic();
  }

  public void UnLoad()
  {
    this.Pattern = (string) null;
    this.badCharactorShifts.Clear();
    this.goodSuffixShifts = (int[]) null;
  }

  private static int Max(int a, int b) => a > b ? a : b;

  private static bool IsChinese(char mchar)
  {
    int int32 = Convert.ToInt32(mchar);
    return int32 >= BoyerMooreStringMatcher.dstringmin && int32 < BoyerMooreStringMatcher.dstringmax;
  }

  private static bool CheckWord(char mchar)
  {
    return char.IsWhiteSpace(mchar) || char.IsSymbol(mchar) || char.IsPunctuation(mchar) || BoyerMooreStringMatcher.IsChinese(mchar);
  }

  private void BuildBadCharactorHeuristic()
  {
    int length = this.Pattern.Length;
    for (int index = 0; index < length; ++index)
    {
      if (!this.badCharactorShifts.ContainsKey(this.Pattern[index]))
        this.badCharactorShifts.Add(this.Pattern[index], length - 1 - index);
      else
        this.badCharactorShifts[this.Pattern[index]] = length - 1 - index;
    }
  }

  private void BuildGoodSuffixHeuristic()
  {
    int length = this.Pattern.Length;
    this.goodSuffixShifts = new int[length];
    int[] suffixLengthArray = this.GetSuffixLengthArray();
    for (int index = 0; index < length; ++index)
      this.goodSuffixShifts[index] = length;
    int index1 = 0;
    for (int index2 = length - 1; index2 >= -1; --index2)
    {
      if (index2 == -1 || suffixLengthArray[index2] == index2 + 1)
      {
        for (; index1 < length - 1 - index2; ++index1)
        {
          if (this.goodSuffixShifts[index1] == length)
            this.goodSuffixShifts[index1] = length - 1 - index2;
        }
      }
    }
    for (int index3 = 0; index3 < length - 1; ++index3)
      this.goodSuffixShifts[length - 1 - suffixLengthArray[index3]] = length - 1 - index3;
  }

  private int[] GetSuffixLengthArray()
  {
    int length = this.Pattern.Length;
    int[] suffixLengthArray = new int[length];
    int num = 0;
    suffixLengthArray[length - 1] = length;
    int index1 = length - 1;
    for (int index2 = length - 2; index2 >= 0; --index2)
    {
      if (index2 > index1 && suffixLengthArray[index2 + length - 1 - num] < index2 - index1)
      {
        suffixLengthArray[index2] = suffixLengthArray[index2 + length - 1 - num];
      }
      else
      {
        if (index2 < index1)
          index1 = index2;
        num = index2;
        while (index1 >= 0 && (int) this.Pattern[index1] == (int) this.Pattern[index1 + length - 1 - num])
          --index1;
        suffixLengthArray[index2] = num - index1;
      }
    }
    return suffixLengthArray;
  }

  private int GetBadCharactorShift(char tmp)
  {
    return this.badCharactorShifts.ContainsKey(tmp) ? this.badCharactorShifts[tmp] : this.Pattern.Length;
  }

  public bool TryMatch(string text, bool Accurate = false)
  {
    int length1 = text.Length;
    int length2 = this.Pattern.Length;
    int num = 0;
    while (num <= length1 - length2)
    {
      int index = length2 - 1;
      while (index >= 0 && (int) this.Pattern[index] == (int) char.ToLower(text[num + index]))
        --index;
      if (index < 0)
      {
        if (!Accurate || (num == 0 || BoyerMooreStringMatcher.CheckWord(text[num - 1])) && (num + length2 == length1 || BoyerMooreStringMatcher.CheckWord(text[num + length2])))
          return true;
        num += this.goodSuffixShifts[0];
      }
      else
        num += BoyerMooreStringMatcher.Max(this.goodSuffixShifts[index], this.GetBadCharactorShift(char.ToLower(text[num + index])) - (length2 - 1) + index);
    }
    return false;
  }

  public void CheckAndRePlace(char[] text, bool Accurate = false)
  {
    int length1 = text.Length;
    int length2 = this.Pattern.Length;
    int num = 0;
    while (num <= length1 - length2)
    {
      int index1 = length2 - 1;
      while (index1 >= 0 && (int) this.Pattern[index1] == (int) char.ToLower(text[num + index1]))
        --index1;
      if (index1 < 0)
      {
        if (!Accurate || (num == 0 || BoyerMooreStringMatcher.CheckWord(text[num - 1])) && (num + length2 == length1 || BoyerMooreStringMatcher.CheckWord(text[num + length2])))
        {
          for (int index2 = 0; index2 < length2; ++index2)
            text[num + index2] = '*';
        }
        num += this.goodSuffixShifts[0];
      }
      else
        num += BoyerMooreStringMatcher.Max(this.goodSuffixShifts[index1], this.GetBadCharactorShift(char.ToLower(text[num + index1])) - (length2 - 1) + index1);
    }
  }

  public unsafe void CheckAndRePlace(string text, bool Accurate = false)
  {
    int length1 = text.Length;
    int length2 = this.Pattern.Length;
    int num = 0;
    while (num <= length1 - length2)
    {
      int index1 = length2 - 1;
      while (index1 >= 0 && (int) this.Pattern[index1] == (int) char.ToLower(text[num + index1]))
        --index1;
      if (index1 < 0)
      {
        if (!Accurate || (num == 0 || BoyerMooreStringMatcher.CheckWord(text[num - 1])) && (num + length2 == length1 || BoyerMooreStringMatcher.CheckWord(text[num + length2])))
        {
          string str = text;
          char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
          for (int index2 = 0; index2 < length2; ++index2)
            chPtr[num + index2] = '*';
          str = (string) null;
        }
        num += this.goodSuffixShifts[0];
      }
      else
        num += BoyerMooreStringMatcher.Max(this.goodSuffixShifts[index1], this.GetBadCharactorShift(char.ToLower(text[num + index1])) - (length2 - 1) + index1);
    }
  }
}
