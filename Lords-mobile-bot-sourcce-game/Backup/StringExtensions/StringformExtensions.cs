// Decompiled with JetBrains decompiler
// Type: StringExtensions.StringformExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace StringExtensions
{
  public static class StringformExtensions
  {
    public static int GetStrLen(this string str)
    {
      int index = 0;
      while (index < str.Length && str[index] != char.MinValue)
        ++index;
      return index;
    }
  }
}
